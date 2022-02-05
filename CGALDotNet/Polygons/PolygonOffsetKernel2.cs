using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonOffsetKernel2 : CGALObjectKernel
    {

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract int PolygonBufferSize(IntPtr ptr);

        internal abstract int SegmentBufferSize(IntPtr ptr);

        internal abstract void ClearPolygonBuffer(IntPtr ptr);

        internal abstract void ClearSegmentBuffer(IntPtr ptr);

        internal abstract IntPtr GetBufferedPolygon(IntPtr ptr, int index);

        internal abstract Segment2d GetSegment(IntPtr ptr, int index);

        internal abstract void GetSegments(IntPtr ptr, Segment2d[] segments, int count);

        internal abstract void CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        internal abstract void CreateInteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly);

        internal abstract void CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        internal abstract void CreateExteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly);

        internal abstract void CreateInteriorSkeleton(IntPtr ptr, IntPtr polyPtr, bool includeBorder);

        internal abstract void CreateInteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, bool includeBorder);

        internal abstract void CreateExteriorSkeleton(IntPtr ptr, IntPtr polyPtr, double maxOffset, bool includeBorder);

        internal abstract void CreateExteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, double maxOffset, bool includeBorder);
    }
}
