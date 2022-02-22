using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

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
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonVisibility<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Compute the visibility from a simple polygon with no holes.
        /// This class implements the algorithm of B.Joe and R.B.Simpson [4]. The algorithm is a modification
        /// and extension of the linear time algorithm of Lee [5]. It computes the visibility region from a 
        /// viewpoint that is in the interior or on the boundary of the polygon.
        /// While scanning the boundary the algorithm uses a stack to manipulate the vertices, and ultimately
        /// yields the visibility region.For each scanned edge, at most 2 points are pushed onto the stack.
        /// Overall, at most 2 n points are pushed or popped. Thus, the time and space complexities of the
        /// algorithm are O(n) even in case of degeneracies such as needles, where n is the number of the vertices of the polygon.
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
        /// <param name="point">The visibility point.</param>
        /// <param name="polygon">A polygon with holes that contains the point.</param>
        /// <param name="result">The visibility result.</param>
        /// <returns>True if result was computed</returns>
        public bool ComputeVisibility(Point2d point, PolygonWithHoles2<K> polygon, out PolygonWithHoles2<K> result)
        {
            return ComputeVisibilityRSV(point, polygon, out result);
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
        /// Compute the visibility from a polygon with holes using the triangular expansion method.
        /// The algorithm does not require preprocessing. It relies on the algorithm of T. 
        /// Asano [1] based on angular plane sweep, with a time complexity of O(nlogn) in the number of vertices.
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
        /// Compute the visibility from a polygon with holes using the rotational sweep method.
        /// The algorithm obtains a constrained triangulation from the input arrangement, then computes visibility by 
        /// expanding the triangle that contains the query point. Preprocessing takes O(n) time and O(n) space, where 
        /// n is the number of vertices of input polygon. The query time is O(nh), where h is the number of holes+1 of 
        /// input polygon. Thus, for simple polygons (or a polygon with a constant number of holes) the algorithm 
        /// complexity is linear, but it is O(n2) in the worst case, as the number of holes can be linear in n.
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
    public abstract class PolygonVisibility : PolygonAlgorithm
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
        /// Release the unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
