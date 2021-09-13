using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{

    public enum POLYGON_SIMP_COST_FUNC
    {
        SQUARE_DIST,
        SCALED_SQ_DIST
    };

    public enum POLYGON_SIMP_STOP_FUNC
    {
        BELOW_RATIO,
        BELOW_THRESHOLD,
        ABOVE_THRESHOLD
    };

    public sealed class PolygonSimplification2<K> : PolygonSimplification2 where K : CGALKernel, new()
    {

        public static readonly PolygonSimplification2<K> Instance = new PolygonSimplification2<K>();

        public PolygonSimplification2() : base(new K())
        {

        }

        public Polygon2<K> Simplify(Polygon2<K> polygon, double threshold)
        {
            var ptr = Kernel.SimplifyPolygon(polygon.Ptr, threshold);
            return new Polygon2<K>(ptr);
        }

        public PolygonWithHoles2<K> Simplify(PolygonWithHoles2<K> polygon, double threshold)
        {
            var ptr = Kernel.SimplifyPolygonWithHoles(polygon.Ptr, threshold);
            return new PolygonWithHoles2<K>(ptr);
        }
    }

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

        protected private PolygonSimplificationKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
