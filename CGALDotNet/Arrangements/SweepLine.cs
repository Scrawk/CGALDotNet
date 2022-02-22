using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Arrangements
{
    /// <summary>
    /// The generic sweep line class.
    /// </summary>
    /// <typeparam name="K">The kernel.</typeparam>
    public sealed class SweepLine<K> : SweepLine where K : CGALKernel, new()
    {
        /// <summary>
        /// A static instanceof a sweep line.
        /// </summary>
        public static readonly SweepLine<K> Instance = new SweepLine<K>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SweepLine() : base(new K())
        {

        }

        /// <summary>
        /// Create from a unmanaged pointer.
        /// </summary>
        /// <param name="ptr"></param>
        internal SweepLine(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The sweep line as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[SweepLine<{0}>: ]", Kernel.Name);
        }

    }

    /// <summary>
    /// The abstract sweep line.
    /// </summary>
    public abstract class SweepLine : CGALObject
    {
        /// <summary>
        /// The default sweep line.
        /// </summary>
        private SweepLine()
        {

        }

        /// <summary>
        /// Create from the kernel.
        /// </summary>
        /// <param name="kernel">A kernel that implements a sweep line.</param>
        internal SweepLine(CGALKernel kernel)
        {
            Kernel = kernel.SweepLineKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Create from the kernel and unmanaged pointer.
        /// </summary>
        /// <param name="kernel">A kernel that implements a sweep line.</param>
        /// <param name="ptr">A unmanaged pointer to a sweep line.</param>
        internal SweepLine(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.SweepLineKernel;
        }

        /// <summary>
        /// The sweep line kernel.
        /// </summary>
        protected private SweepLineKernel Kernel { get; private set; }

        /// <summary>
        /// Do any of the segments in the array intersect.
        /// </summary>
        /// <param name="segments">The segment array.</param>
        /// <param name="count">The ararys length.</param>
        /// <returns>Do any of the segments in the array intersect.</returns>
        public bool DoIntersect(Segment2d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);
            return Kernel.DoIntersect(Ptr, segments, count);
        }

        /// <summary>
        /// Compute all the sub segemnts from the intersection 
        /// of the segments in the array.
        /// </summary>
        /// <param name="segments">The segment array.</param>
        /// <param name="count">The ararys length.</param>
        /// <returns>The sub segments.</returns>
        public Segment2d[] ComputeSubcurves(Segment2d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);

            int len = Kernel.ComputeSubcurves(Ptr, segments, count);
            var subSegments = new Segment2d[len];

            if (len > 0)
            {
                GetSegments(subSegments, len);
                ClearSegmentBuffer();
            }

            return subSegments;
        }

        /// <summary>
        /// Compute all the intersection points from the 
        /// segments in the array.
        /// </summary>
        /// <param name="segments">The segment array.</param>
        /// <param name="count">The ararys length.</param>
        /// <returns>The intersection points.</returns>
        public Point2d[] ComputeIntersectionPoints(Segment2d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);

            int len = Kernel.ComputeIntersectionPoints(Ptr, segments, count);
            var points = new Point2d[len];

            if (len > 0)
            {
                GetPoints(points, len);
                ClearPointBuffer();
            }

            return points;
        }

        /// <summary>
        /// Get all the points in the point buffer.
        /// </summary>
        /// <param name="points">A point array the size of the point buffer.</param>
        /// <param name="count">The ararys length.</param>
        private void GetPoints(Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
        }

        /// <summary>
        /// Get all the segments in the point buffer.
        /// </summary>
        /// <param name="segments">A segment array the size of the segment buffer.</param>
        /// <param name="count">The ararys length.</param>
        private void GetSegments(Segment2d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);
            Kernel.GetSegments(Ptr, segments, count);
        }

        /// <summary>
        /// Clear the point buffer.
        /// </summary>
        private void ClearPointBuffer()
        {
            Kernel.ClearPointBuffer(Ptr);
        }

        /// <summary>
        /// Clear the segment buffer.
        /// </summary>
        private void ClearSegmentBuffer()
        {
            Kernel.ClearSegmentBuffer(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int PointBufferSize()
        {
            return Kernel.PointBufferSize(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int SegmentBufferSize()
        {
            return Kernel.SegmentBufferSize(Ptr);
        }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
