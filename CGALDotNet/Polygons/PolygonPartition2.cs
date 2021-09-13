﻿using System;
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
        /// Is this polygon Y monotonic.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>True if y monotonic.</returns>
        public bool Is_Y_Monotone(Polygon2<K> polygon)
        {
            return Kernel.Is_Y_Monotone(Ptr, polygon.Ptr);
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
        /// Partition in to Y monotonic polygons.
        /// </summary>
        /// <param name="polygon">The polygon to partition.</param>
        /// <param name="results">The resulting polygons.</param>
        public void Y_Monotone(Polygon2<K> polygon, List<Polygon2<K>> results)
        {
            int count = Kernel.Y_MonotonePartition(Ptr, polygon.Ptr);
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
            int count = Kernel.ApproxConvexPartition(Ptr, polygon.Ptr);
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
            int count = Kernel.GreeneApproxConvexPartition(Ptr, polygon.Ptr);
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
            int count = Kernel.OptimalConvexPartition(Ptr, polygon.Ptr);
            CopyBufferAndClear(count, results);
        }

        /// <summary>
        /// Copy the new polygons into the result array
        /// and the clear the buffer.
        /// </summary>
        /// <param name="count">The number of polygons in buffer.</param>
        // <param name="results">The resulting polygons.</param>
        private void CopyBufferAndClear(int count, List<Polygon2<K>> results)
        {
            for (int i = 0; i < count; i++)
            {
                var ptr = Kernel.CopyBufferItem(Ptr, i);
                results.Add(new Polygon2<K>(ptr));
            }

            Kernel.ClearBuffer(Ptr);
        }

        /// <summary>
        /// Is this a valid polygon.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        /// <returns>If the polygon is simple and ccw.</returns>
        public bool IsValid(Polygon2<K> polygon)
        {
            if (!CheckInput)
                return true;
            else
                return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        private void CheckPolygon(Polygon2<K> polygon)
        {
            if (!CheckInput) return;

            if (!IsValid(polygon))
                throw new Exception("Poylgon must be simple and counter clock wise to partition.");
        }

        private void CheckPolygons(Polygon2<K> polygon1, Polygon2<K> polygon2)
        {
            if (!CheckInput) return;

            if (!IsValid(polygon1))
                throw new Exception("Poylgon must be simple and counter clock wise to partition.");

            if (!IsValid(polygon2))
                throw new Exception("Poylgon must be simple and counter clock wise to partition.");
        }

    }

    /// <summary>
    /// The abstract base class.
    /// </summary>
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

        /// <summary>
        /// The partition kernel.
        /// </summary>
        protected private PolygonPartitionKernel2 Kernel { get; private set; }

        /// <summary>
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

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
