using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{
    /// <summary>
    /// Type of polygon partitions.
    /// </summary>
    public enum POLYGON_PARTITION
    {
        OPTIMAL_CONVEX,
        APPROX_CONVEX,
        GREENE_APROX_CONVEX,
        Y_MONOTONE
    }

    /// <summary>
    /// Generic polygon partition class.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class PolygonPartition2<K> : PolygonPartition2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of polygon partition.
        /// </summary>
        public static readonly PolygonPartition2<K> Instance = new PolygonPartition2<K>();

        /// <summary>
        /// Create new polygon partition.
        /// </summary>
        public PolygonPartition2() : base(new K())
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonPartition2<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Is this polygon Y monotonic.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>True if y monotonic.</returns>
        public bool Is_Y_Monotone(Polygon2<K> polygon)
        {
            CheckPolygon(polygon);
            return Kernel.Is_Y_Monotone(Ptr, polygon.Ptr);
        }

        /// <summary>
        /// Is this polygon Y monotonic.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>True if y monotonic.</returns>
        public bool Is_Y_Monotone(PolygonWithHoles2<K> polygon)
        {
            CheckPolygon(polygon);
            return Kernel.Is_Y_MonotonePWH(Ptr, polygon.Ptr);
        }

        /// <summary>
        /// Partition a polygon.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void Partition(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            GreeneApproxConvex(polygon, results);
        }

        /// <summary>
        /// Partition a polygon.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void Partition(PolygonWithHoles2<K> polygon, List<Polygon2<K>> results)
        {
            GreeneApproxConvex(polygon, results);
        }

        /// <summary>
        /// Partition a polygon.
        /// </summary>
        /// <param name="type">The type of partition to perfrom.</param>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void Partition(POLYGON_PARTITION type, Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            switch (type)
            {
                case POLYGON_PARTITION.OPTIMAL_CONVEX:
                    OptimalConvex(polygon, results);
                    break;

                case POLYGON_PARTITION.APPROX_CONVEX:
                    ApproxConvex(polygon, results);
                    break;

                case POLYGON_PARTITION.GREENE_APROX_CONVEX:
                    GreeneApproxConvex(polygon, results);
                    break;

                case POLYGON_PARTITION.Y_MONOTONE:
                    Y_Monotone(polygon, results);
                    break;
            }
        }

        /// <summary>
        /// Partition a polygon.
        /// </summary>
        /// <param name="type">The type of partition to perfrom.</param>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void Partition(POLYGON_PARTITION type, PolygonWithHoles2<K> polygon, List<Polygon2<K>> results)
        {
            switch (type)
            {
                case POLYGON_PARTITION.OPTIMAL_CONVEX:
                    OptimalConvex(polygon, results);
                    break;

                case POLYGON_PARTITION.APPROX_CONVEX:
                    ApproxConvex(polygon, results);
                    break;

                case POLYGON_PARTITION.GREENE_APROX_CONVEX:
                    GreeneApproxConvex(polygon, results);
                    break;

                case POLYGON_PARTITION.Y_MONOTONE:
                    Y_Monotone(polygon, results);
                    break;
            }
        }

        /// <summary>
        /// Partition in to Y monotonic polygons.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void Y_Monotone(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            int count = Kernel.Y_MonotonePartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Partition in to Y monotonic polygons.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void Y_Monotone(PolygonWithHoles2<K> polygon, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            int count = Kernel.Y_MonotonePartitionPWH(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Partition the polygon into convex polygons where the number of
        /// convex polygons produced is no more than four times the minimal number.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void ApproxConvex(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            int count = Kernel.ApproxConvexPartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Partition the polygon into convex polygons where the number of
        /// convex polygons produced is no more than four times the minimal number.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void ApproxConvex(PolygonWithHoles2<K> polygon, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            int count = Kernel.ApproxConvexPartitionPWH(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Partition the polygon into convex polygons where the number of
        /// convex polygons produced is no more than four times the minimal number.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void GreeneApproxConvex(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            int count = Kernel.GreeneApproxConvexPartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Partition the polygon into convex polygons where the number of
        /// convex polygons produced is no more than four times the minimal number.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void GreeneApproxConvex(PolygonWithHoles2<K> polygon, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            int count = Kernel.GreeneApproxConvexPartitionPWH(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Partition the polygon into convex polygons where the number of 
        /// convex polygons produced is minimal.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void OptimalConvex(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            int count = Kernel.OptimalConvexPartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Partition the polygon into convex polygons where the number of 
        /// convex polygons produced is minimal.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void OptimalConvex(PolygonWithHoles2<K> polygon, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            int count = Kernel.OptimalConvexPartitionPWH(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Copy the new polygons into the result array
        /// and the clear the buffer.
        /// </summary>
        /// <param name="count">The number of polygons in buffer.</param>
        /// <param name="results">The resulting polygons.</param>
        private void CopyBufferAndClear(int count, List<Polygon2<K>> results)
        {
            for (int i = 0; i < count; i++)
            {
                var ptr = Kernel.CopyBufferItem(Ptr, i);
                results.Add(new Polygon2<K>(ptr));
            }

            Kernel.ClearBuffer(Ptr);
        }

        private bool PartitionIsValid(Polygon2<K> polygon)
        {
            return Kernel.PartitionIsValid(Ptr, polygon.Ptr);
        }

        private bool ConvexPartitionIsValid(Polygon2<K> polygon)
        {
            return Kernel.ConvexPartitionIsValid(Ptr, polygon.Ptr);
        }

    }

    /// <summary>
    /// The abstract base class.
    /// </summary>
    public abstract class PolygonPartition2 : PolygonAlgorithm
    {
        private PolygonPartition2()
        {

        }

        internal PolygonPartition2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonPartitionKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The partition kernel.
        /// </summary>
        protected private PolygonPartitionKernel2 Kernel { get; private set; }

        /// <summary>
        /// Clear the unmanaged buffer.
        /// </summary>
        protected void ClearBuffer()
        {
            Kernel.ClearBuffer(Ptr);
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
