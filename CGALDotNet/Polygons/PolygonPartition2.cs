using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{

    public enum POLYGON_PARTION
    {
        OPTIMAL_CONVEX,
        APPROX_CONVEX,
        GREENE_APROX_CONVEX,
        Y_MONOTONE
    }

    public sealed class PolygonPartition2<K> : PolygonPartition2 where K : CGALKernel, new()
    {

        public static readonly PolygonPartition2<K> Instance = new PolygonPartition2<K>();

        public PolygonPartition2() : base(new K())
        {

        }

        public bool Is_Y_Monotone(Polygon2<K> polygon)
        {
            return Kernel.Is_Y_Monotone(Ptr, polygon.Ptr);
        }

        public void Partition(POLYGON_PARTION type, Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            switch (type)
            {
                case POLYGON_PARTION.OPTIMAL_CONVEX:
                    OptimalConvex(polygon, results);
                    break;

                case POLYGON_PARTION.APPROX_CONVEX:
                    ApproxConvex(polygon, results);
                    break;

                case POLYGON_PARTION.GREENE_APROX_CONVEX:
                    GreeneApproxConvex(polygon, results);
                    break;

                case POLYGON_PARTION.Y_MONOTONE:
                    Y_Monotone(polygon, results);
                    break;
            }
        }

        public void Y_Monotone(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            int count = Kernel.Y_MonotonePartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        public void ApproxConvex(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            int count = Kernel.ApproxConvexPartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        public void GreeneApproxConvex(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            int count = Kernel.GreeneApproxConvexPartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        public void OptimalConvex(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            int count = Kernel.OptimalConvexPartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        private void CopyBufferAndClear(int count, List<Polygon2<K>> results)
        {
            for (int i = 0; i < count; i++)
            {
                var ptr = Kernel.CopyBufferItem(Ptr, i);
                results.Add(new Polygon2<K>(ptr));
            }

            Kernel.ClearBuffer(Ptr);
        }

    }

    public abstract class PolygonPartition2 : CGALObject
    {
        private PolygonPartition2()
        {

        }

        internal PolygonPartition2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonPartitionKernel2;
            Ptr = Kernel.Create();
        }

        protected private PolygonPartitionKernel2 Kernel { get; private set; }

        protected void ClearBuffer()
        {
            Kernel.ClearBuffer(Ptr);
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
