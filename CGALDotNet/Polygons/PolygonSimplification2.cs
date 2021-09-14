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
        public POLYGON_ELEMENT elements;
        public double threshold;

        public static PolygonSimplificationParams Default
        {
            get
            {
                var param = new PolygonSimplificationParams();
                param.stop = POLYGON_SIMP_STOP_FUNC.BELOW_THRESHOLD;
                param.cost = POLYGON_SIMP_COST_FUNC.SQUARE_DIST;
                param.elements = POLYGON_ELEMENT.ALL;
                param.threshold = 0.5;

                return param;
            }
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
        /// <returns>The simplified polygon.</returns>
        public PolygonWithHoles2<K> Simplify(PolygonWithHoles2<K> polygon, PolygonSimplificationParams param)
        {
            var ptr = Kernel.SimplifyPolygonWithHoles(polygon.Ptr, param);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Is this a valid polygon.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        /// <returns>If the polygon is simple.</returns>
        public bool IsValid(Polygon2<K> polygon)
        {
            if (!CheckInput)
                return true;
            else
                return polygon.IsSimple;
        }

        private void CheckPolygon(Polygon2<K> polygon)
        {
            if (!CheckInput) return;

            if (!IsValid(polygon))
                throw new Exception("Poylgon must be simple simplification.");
        }
    }

    /// <summary>
    /// Abstract polygon simplification class.
    /// </summary>
    public abstract class PolygonSimplification2 : CGALObject
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
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

        /// <summary>
        /// Release unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
