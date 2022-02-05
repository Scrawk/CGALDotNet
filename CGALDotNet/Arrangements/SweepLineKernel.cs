using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Arrangements
{
    internal abstract class SweepLineKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

		internal abstract void ClearPointBuffer(IntPtr ptr);

		internal abstract void ClearSegmentBuffer(IntPtr ptr);

		internal abstract int PointBufferSize(IntPtr ptr);

		internal abstract int SegmentBufferSize(IntPtr ptr);

		internal abstract bool DoIntersect(IntPtr ptr, Segment2d[] segments, int count);

		internal abstract int ComputeSubcurves(IntPtr ptr, Segment2d[] segments, int count);

		internal abstract int ComputeIntersectionPoints(IntPtr ptr, Segment2d[] segments, int count);

		internal abstract void GetPoints(IntPtr ptr, Point2d[] points, int count);

		internal abstract void GetSegments(IntPtr ptr, Segment2d[] segments, int count);
	}
}
