using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{
    /// <summary>
    /// Cost options for simplification.
    /// </summary>
    public enum POLYGON_SIMP_COST_FUNC
    {
        SQUARE_DIST,
        SCALED_SQ_DIST
    };

    /// <summary>
    /// Stop distance options for simplification.
    /// </summary>
    public enum POLYGON_SIMP_STOP_FUNC
    {
        BELOW_RATIO,
        BELOW_THRESHOLD,
        ABOVE_THRESHOLD
    };

    /// <summary>
    /// Paramaters for poylgon simplification.
    /// </summary>
    public struct PolygonSimplificationParams
    {
        public POLYGON_SIMP_COST_FUNC cost;
        public POLYGON_SIMP_STOP_FUNC stop;
        public double threshold;

        /// <summary>
        /// The default param settings.
        /// </summary>
        public static PolygonSimplificationParams Default
        {
            get
            {
                var param = new PolygonSimplificationParams();
                param.stop = POLYGON_SIMP_STOP_FUNC.BELOW_THRESHOLD;
                param.cost = POLYGON_SIMP_COST_FUNC.SQUARE_DIST;
                param.threshold = 0.5;

                return param;
            }
        }

        /// <summary>
        /// The param as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[PolygonSimplificationParams: Cost={0}, Stop={1}, Threshold={2}]",
                cost, stop, threshold);
        }
    }

    /// <summary>
    /// Generic polygon simplification class.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class PolygonSimplification2<K> : PolygonSimplification2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of polygon simplification.
        /// </summary>
        public static readonly PolygonSimplification2<K> Instance = new PolygonSimplification2<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonSimplification2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonSimplification2<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Simplify the polygon.
        /// </summary>
        /// <param name="polygon">The polygon to simplify. Must be simple.</param>
        /// <param name="param">The simplification parameters.</param>
        /// <returns>The simplified polygon.</returns>
        public Polygon2<K> Simplify(Polygon2<K> polygon, PolygonSimplificationParams param)
        {
            CheckPolygon(polygon);
            var ptr = Kernel.SimplifyPolygon(polygon.Ptr, param);
            return new Polygon2<K>(ptr);
        }

        /// <summary>
        /// Simplify the polygon.
        /// </summary>
        /// <param name="polygon">The polygon to simplify. Must be simple.</param>
        /// <param name="param">The simplification parameters.</param>
        /// <returns>The simplified polygon ptr.</returns>
        internal IntPtr SimplifyPtr(Polygon2<K> polygon, PolygonSimplificationParams param)
        {
            CheckPolygon(polygon);
            return Kernel.SimplifyPolygon(polygon.Ptr, param);
        }

        /// <summary>
        /// Simplify the polygons boundary and all the holes.
        /// </summary>
        /// <param name="polygon">The polygon to simplify. Must be simple.</param>
        /// <param name="param">The simplification parameters.</param>
        /// <returns>The simplified polygon.</returns>
        public PolygonWithHoles2<K> Simplify(PolygonWithHoles2<K> polygon, PolygonSimplificationParams param)
        {
            CheckPolygon(polygon);
            var ptr = Kernel.SimplifyPolygonWithHoles_All(polygon.Ptr, param);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Simplify the polygons boundary and all the holes.
        /// </summary>
        /// <param name="polygon">The polygon to simplify. Must be simple.</param>
        /// <param name="param">The simplification parameters.</param>
        /// <returns>The simplified polygons ptr.</returns>
        internal IntPtr SimplifyPtr(PolygonWithHoles2<K> polygon, PolygonSimplificationParams param)
        {
            CheckPolygon(polygon);
            return Kernel.SimplifyPolygonWithHoles_All(polygon.Ptr, param);
        }

        /// <summary>
        /// Simplify the polygons boundary.
        /// </summary>
        /// <param name="polygon">The polygon to simplify. Must be simple.</param>
        /// <param name="param">The simplification parameters.</param>
        /// <returns>The simplified polygon.</returns>
        public PolygonWithHoles2<K> SimplifyBoundary(PolygonWithHoles2<K> polygon, PolygonSimplificationParams param)
        {
            CheckPolygon(polygon);
            var ptr = Kernel.SimplifyPolygonWithHoles_Boundary(polygon.Ptr, param);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Simplify the polygons holes.
        /// </summary>
        /// <param name="polygon">The polygon to simplify. Must be simple.</param>
        /// <param name="param">The simplification parameters.</param>
        /// <returns>The simplified polygon.</returns>
        public PolygonWithHoles2<K> SimplifyHoles(PolygonWithHoles2<K> polygon, PolygonSimplificationParams param)
        {
            CheckPolygon(polygon);
            var ptr = Kernel.SimplifyPolygonWithHoles_Holes(polygon.Ptr, param);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Simplify one of the polygons holes.
        /// </summary>
        /// <param name="polygon">The polygon to simplify. Must be simple.</param>
        /// <param name="param">The simplification parameters.</param>
        /// <param name="index">The hole index to simplify.</param>
        /// <returns>The simplified polygon.</returns>
        public PolygonWithHoles2<K> SimplifyHole(PolygonWithHoles2<K> polygon, PolygonSimplificationParams param, int index)
        {
            CheckPolygon(polygon);
            var ptr = Kernel.SimplifyPolygonWithHoles_Hole(polygon.Ptr, param, index);
            return new PolygonWithHoles2<K>(ptr);
        }

    }

    /// <summary>
    /// Abstract polygon simplification class.
    /// </summary>
    public abstract class PolygonSimplification2 : PolygonAlgorithm
    {
        private PolygonSimplification2()
        {

        }

        internal PolygonSimplification2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonSimplificationKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The simplification kernel.
        /// </summary>
        protected private PolygonSimplificationKernel2 Kernel { get; private set; }

        /// <summary>
        /// Release unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
