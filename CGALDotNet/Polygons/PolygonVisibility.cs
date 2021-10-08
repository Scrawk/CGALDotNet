using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public enum POLYGON_VISIBILITY
    {
        ROTATION_SWEEP,
        TRIANGULAR_EXPANSION
    }

    /// <summary>
    /// The generic polgon visibility class
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonVisibility<K> : PolygonVisibility where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of polygon visibility.
        /// </summary>
        public static readonly PolygonVisibility<K> Instance = new PolygonVisibility<K>();

        /// <summary>
        /// Create new polygon visibility.
        /// </summary>
        public PolygonVisibility() : base(new K())
        {

        }

        /// <summary>
        /// Compute the visibility from a simple polygon.
        /// </summary>
        /// <param name="point">The visibility point.</param>
        /// <param name="polygon">A simple polygon that contains the point.</param>
        /// <param name="result">The visibility result.</param>
        /// <returns>True if result was computed</returns>
        public bool ComputeVisibility(Point2d point, Polygon2<K> polygon,  out Polygon2<K> result)
        {
            if(polygon.ContainsPoint(point))
            {
                CheckPolygon(polygon);
                var ptr = Kernel.ComputeVisibilitySimple(point, polygon.Ptr);
                result = new Polygon2<K>(ptr);

                if (result.IsClockWise)
                    polygon.Reverse();

                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Compute the visibility from a polygon with holes.
        /// </summary>
        /// <param name="method">What method to use.</param>
        /// <param name="point">The visibility point.</param>
        /// <param name="polygon">A polygon with holes that contains the point.</param>
        /// <param name="result">The visibility result.</param>
        /// <returns>True if result was computed</returns>
        public bool ComputeVisibility(POLYGON_VISIBILITY method, Point2d point, PolygonWithHoles2<K> polygon, out PolygonWithHoles2<K> result)
        {
            switch (method)
            {
                case POLYGON_VISIBILITY.ROTATION_SWEEP:
                    return ComputeVisibilityRSV(point, polygon, out result);

                case POLYGON_VISIBILITY.TRIANGULAR_EXPANSION:
                    return ComputeVisibilityTEV(point, polygon, out result);

                default:
                    return ComputeVisibilityTEV(point, polygon, out result);
            }
        }

        /// <summary>
        /// Compute the visibility from a polygon with holes 
        /// using the triangular expansion method.
        /// </summary>
        /// <param name="point">The visibility point.</param>
        /// <param name="polygon">A polygon with holes that contains the point.</param>
        /// <param name="result">The visibility result.</param>
        /// <returns>True if result was computed</returns>
        public bool ComputeVisibilityTEV(Point2d point, PolygonWithHoles2<K> polygon, out PolygonWithHoles2<K> result)
        {
            if (polygon.ContainsPoint(point))
            {
                //CheckPolygon(polygon);
                var ptr = Kernel.ComputeVisibilityTEV(point, polygon.Ptr);
                result = new PolygonWithHoles2<K>(ptr);

                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Compute the visibility from a polygon with holes 
        /// using the rotational sweep method.
        /// </summary>
        /// <param name="point">The visibility point.</param>
        /// <param name="polygon">A polygon with holes that contains the point.</param>
        /// <param name="result">The visibility result.</param>
        /// <returns>True if result was computed</returns>
        public bool ComputeVisibilityRSV(Point2d point, PolygonWithHoles2<K> polygon, out PolygonWithHoles2<K> result)
        {
            if (polygon.ContainsPoint(point))
            {
                //CheckPolygon(polygon);
                var ptr = Kernel.ComputeVisibilityRSV(point, polygon.Ptr);
                result = new PolygonWithHoles2<K>(ptr);

                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

    }

    /// <summary>
    /// The abstract polygon visibility class.
    /// </summary>
    public abstract class PolygonVisibility : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonVisibility()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonVisibility(CGALKernel kernel)
        {
            Kernel = kernel.PolygonVisibilityKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The offset kernel.
        /// </summary>
        protected private PolygonVisibilityKernel Kernel { get; private set; }

        /// <summary>
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

        /// <summary>
        /// Check if the polygon is valid.
        /// Should be simple and ccw.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        /// <returns>True if valid</returns>
        public bool IsValid(Polygon2 polygon)
        {
            if (!CheckInput)
                return true;
            else
                return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        /// <summary>
        /// Check if the polygon is valid to offset.
        /// Should be simple and ccw.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected void CheckPolygon(Polygon2 polygon)
        {
            if (!CheckInput) return;

            if (!IsValid(polygon))
                throw new Exception("Poylgon must be simple and ccw.");
        }

        /// <summary>
        /// Release the unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
