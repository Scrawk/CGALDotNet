using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Arrangements
{
    internal class SweepLineKernel_EEK : SweepLineKernel
    {
        internal override string Name => "EEK";

        internal static readonly SweepLineKernel Instance = new SweepLineKernel_EEK();

        internal override IntPtr Create()
        {
            return SweepLine2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SweepLine2_EEK_Release(ptr);
        }

        internal override void ClearPointBuffer(IntPtr ptr)
        {
            SweepLine2_EEK_ClearPointBuffer(ptr);
        }

        internal override void ClearSegmentBuffer(IntPtr ptr)
        {
            SweepLine2_EEK_ClearSegmentBuffer(ptr);
        }

        internal override int PointBufferSize(IntPtr ptr)
        {
            return SweepLine2_EEK_PointBufferSize(ptr);
        }

        internal override int SegmentBufferSize(IntPtr ptr)
        {
            return SweepLine2_EEK_SegmentBufferSize(ptr);
        }

        internal override bool DoIntersect(IntPtr ptr, Segment2d[] segments, int count)
        {
            return SweepLine2_EEK_DoIntersect(ptr, segments, count);
        }

        internal override int ComputeSubcurves(IntPtr ptr, Segment2d[] segments, int count)
        {
            return SweepLine2_EEK_ComputeSubcurves(ptr, segments, count);
        }

        internal override int ComputeIntersectionPoints(IntPtr ptr, Segment2d[] segments, int count)
        {
            return SweepLine2_EEK_ComputeIntersectionPoints(ptr, segments, count);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            SweepLine2_EEK_GetPoints(ptr, points, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            SweepLine2_EEK_GetSegments(ptr, segments, count);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SweepLine2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EEK_ClearPointBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EEK_ClearSegmentBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EEK_PointBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EEK_SegmentBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SweepLine2_EEK_DoIntersect(IntPtr ptr, [In] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EEK_ComputeSubcurves(IntPtr ptr, [In] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EEK_ComputeIntersectionPoints(IntPtr ptr, [In] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EEK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);
    }
}
