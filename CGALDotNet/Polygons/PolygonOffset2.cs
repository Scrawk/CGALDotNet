using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{

    public enum OFFSET
    {
        INTERIOR,
        EXTERIOR
    }

    /// <summary>
    /// The generic polgon offset class
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonOffset2<K> : PolygonOffset2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of polygon offset.
        /// </summary>
        public static readonly PolygonOffset2<K> Instance = new PolygonOffset2<K>();

        /// <summary>
        /// Create new polygon offset.
        /// </summary>
        public PolygonOffset2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonOffset2<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Create a interior or exterior offset.
        /// </summary>
        /// <param name="offset">The offset type</param>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="amount">The offset amount</param>
        /// <param name="results">The offset polygon</param>
        public void CreateOffset(OFFSET offset, Polygon2<K> polygon, double amount, List<Polygon2<K>> results)
        {
            if (offset == OFFSET.INTERIOR)
                CreateInteriorOffset(polygon, amount, results);
            else
                CreateExteriorOffset(polygon, amount, results);
        }

        /// <summary>
        /// Create a interior or exterior offset.
        /// </summary>
        /// <param name="offset">The offset type</param>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="amount">The offset amount</param>
        /// <param name="results">The offset polygon</param>
        public void CreateOffset(OFFSET offset, PolygonWithHoles2<K> polygon, double amount, List<Polygon2<K>> results)
        {
            if (offset == OFFSET.INTERIOR)
                CreateInteriorOffset(polygon, amount, results);
            else
                CreateExteriorOffset(polygon, amount, results);
        }

        /// <summary>
        /// Create a interior offset.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="offset">The offset amount</param>
        /// <param name="results">The offset polygon</param>
        public void CreateInteriorOffset(Polygon2<K> polygon, double offset, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            Kernel.CreateInteriorOffset(Ptr, polygon.Ptr, offset);

            int count = PolygonBufferSize();

            for (int i = 0; i < count; i++)
            {
                var ptr = GetBufferedPolygon(i);
                results.Add(new Polygon2<K>(ptr));
            }

            ClearPolygonBuffer();
        }

        /// <summary>
        /// Create a interior offset.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="offset">The offset amount</param>
        /// <param name="results">The offset polygon</param>
        public void CreateInteriorOffset(PolygonWithHoles2<K> polygon, double offset, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            Kernel.CreateInteriorOffsetPWH(Ptr, polygon.Ptr, offset, false);

            int count = PolygonBufferSize();

            for (int i = 0; i < count; i++)
            {
                var ptr = GetBufferedPolygon(i);
                results.Add(new Polygon2<K>(ptr));
            }

            ClearPolygonBuffer();
        }

        /// <summary>
        /// Create a exterior offset.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="offset">The offset amount</param>
        /// <param name="results">The offset polygon</param>
        public void CreateExteriorOffset(Polygon2<K> polygon, double offset, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            Kernel.CreateExteriorOffset(Ptr, polygon.Ptr, offset);

            int count = PolygonBufferSize();

            for (int i = 0; i < count; i++)
            {
                var ptr = GetBufferedPolygon(i);
                results.Add(new Polygon2<K>(ptr));
            }

            ClearPolygonBuffer();
        }

        /// <summary>
        /// Create a exterior offset.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="offset">The offset amount</param>
        /// <param name="results">The offset polygon</param>
        public void CreateExteriorOffset(PolygonWithHoles2<K> polygon, double offset, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);
            Kernel.CreateExteriorOffsetPWH(Ptr, polygon.Ptr, offset, false);

            int count = PolygonBufferSize();

            for (int i = 0; i < count; i++)
            {
                var ptr = GetBufferedPolygon(i);
                results.Add(new Polygon2<K>(ptr));
            }

            ClearPolygonBuffer();
        }

        /// <summary>
        /// Create the interior skeleton of the polygon.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="includeBorder">Should the polygon be included as the border.</param>
        /// <param name="results">The skeletons segments.</param>
        public void CreateInteriorSkeleton(Polygon2<K> polygon, bool includeBorder, List<Segment2d> results)
        {
            CheckPolygon(polygon);
            Kernel.CreateInteriorSkeleton(Ptr, polygon.Ptr, includeBorder);

            int count = SegmentBufferSize();

            for (int i = 0; i < count; i++)
                results.Add(GetBufferedSegment(i));

            ClearSegmentBuffer();
        }

        /// <summary>
        /// Create the interior skeleton of the polygon.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="includeBorder">Should the polygon be included as the border.</param>
        /// <param name="results">The skeletons segments.</param>
        public void CreateInteriorSkeleton(PolygonWithHoles2<K> polygon, bool includeBorder, List<Segment2d> results)
        {
            CheckPolygon(polygon);
            Kernel.CreateInteriorSkeletonPWH(Ptr, polygon.Ptr, includeBorder);

            int count = SegmentBufferSize();

            for (int i = 0; i < count; i++)
                results.Add(GetBufferedSegment(i));

            ClearSegmentBuffer();
        }

        /// <summary>
        /// Create the exterior skeleton of the polygon.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="maxOffset">The bounding boxes offset from the polygons edges. Must be > 0.</param>
        /// <param name="includeBorder">Should the polygon be included as the border.</param>
        /// <param name="results">The skeletons segments.</param>
        public void CreateExteriorSkeleton(Polygon2<K> polygon, double maxOffset, bool includeBorder, List<Segment2d> results)
        {
            CheckPolygon(polygon);
            if (maxOffset <= 0) return;

            Kernel.CreateExteriorSkeleton(Ptr, polygon.Ptr, maxOffset, includeBorder);

            int count = SegmentBufferSize();

            for (int i = 0; i < count; i++)
                results.Add(GetBufferedSegment(i));

            ClearSegmentBuffer();
        }


        /// <summary>
        /// Create the exterior skeleton of the polygon.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="maxOffset">The bounding boxes offset from the polygons edges. Must be > 0.</param>
        /// <param name="includeBorder">Should the polygon be included as the border.</param>
        /// <param name="results">The skeletons segments.</param>
        public void CreateExteriorSkeleton(PolygonWithHoles2<K> polygon, double maxOffset, bool includeBorder, List<Segment2d> results)
        {
            CheckPolygon(polygon);
            if (maxOffset <= 0) return;

            Kernel.CreateExteriorSkeletonPWH(Ptr, polygon.Ptr, maxOffset, includeBorder);

            int count = SegmentBufferSize();

            for (int i = 0; i < count; i++)
                results.Add(GetBufferedSegment(i));

            ClearSegmentBuffer();
        }
    }

    /// <summary>
    /// The abstract polygon offset class.
    /// </summary>
    public abstract class PolygonOffset2 : PolygonAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonOffset2()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonOffset2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonOffsetKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The offset kernel.
        /// </summary>
        protected private PolygonOffsetKernel2 Kernel { get; private set; }

        /// <summary>
        /// Get the number off polygons in the buffer.
        /// </summary>
        /// <returns></returns>
        protected int PolygonBufferSize()
        {
            return Kernel.PolygonBufferSize(Ptr);
        }

        /// <summary>
        /// The size of the segment buffer.
        /// </summary>
        /// <returns>The number of segments in the buffer.</returns>
        protected int SegmentBufferSize()
        {
            return Kernel.SegmentBufferSize(Ptr);
        }

        /// <summary>
        /// Get the unmanaged point to the polygon at the buffer index
        /// </summary>
        /// <param name="index">The index in the buffer.</param>
        /// <returns>The pointer</returns>
        protected IntPtr GetBufferedPolygon(int index)
        {
            return Kernel.GetBufferedPolygon(Ptr, index);
        }

        /// <summary>
        /// Get the segment from buffer.
        /// </summary>
        /// <param name="index">The segments index.</param>
        /// <returns>The segment.</returns>
        protected Segment2d GetBufferedSegment(int index)
        {
            return Kernel.GetSegment(Ptr, index);
        }

        /// <summary>
        /// Clear the polygon buffer.
        /// </summary>
        protected void ClearPolygonBuffer()
        {
            Kernel.ClearPolygonBuffer(Ptr);
        }

        /// <summary>
        /// Clear the segment buffer.
        /// </summary>
        protected void ClearSegmentBuffer()
        {
            Kernel.ClearSegmentBuffer(Ptr);
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
