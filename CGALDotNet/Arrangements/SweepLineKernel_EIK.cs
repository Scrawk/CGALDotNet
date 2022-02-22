using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Arrangements
{
    internal class SweepLineKernel_EIK : SweepLineKernel
    {
        internal override string Name => "EIK";

        internal static readonly SweepLineKernel Instance = new SweepLineKernel_EIK();

        internal override IntPtr Create()
        {
            return SweepLine2_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SweepLine2_EIK_Release(ptr);
        }

        internal override void ClearPointBuffer(IntPtr ptr)
        {
            SweepLine2_EIK_ClearPointBuffer(ptr);
        }

        internal override void ClearSegmentBuffer(IntPtr ptr)
        {
            SweepLine2_EIK_ClearSegmentBuffer(ptr);
        }

        internal override int PointBufferSize(IntPtr ptr)
        {
            return SweepLine2_EIK_PointBufferSize(ptr);
        }

        internal override int SegmentBufferSize(IntPtr ptr)
        {
            return SweepLine2_EIK_SegmentBufferSize(ptr);
        }

        internal override bool DoIntersect(IntPtr ptr, Segment2d[] segments, int count)
        {
            return SweepLine2_EIK_DoIntersect(ptr, segments, count);
        }

        internal override int ComputeSubcurves(IntPtr ptr, Segment2d[] segments, int count)
        {
            return SweepLine2_EIK_ComputeSubcurves(ptr, segments, count);
        }

        internal override int ComputeIntersectionPoints(IntPtr ptr, Segment2d[] segments, int count)
        {
            return SweepLine2_EIK_ComputeIntersectionPoints(ptr, segments, count);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            SweepLine2_EIK_GetPoints(ptr, points, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            SweepLine2_EIK_GetSegments(ptr, segments, count);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SweepLine2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EIK_ClearPointBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EIK_ClearSegmentBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EIK_PointBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EIK_SegmentBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SweepLine2_EIK_DoIntersect(IntPtr ptr, [In] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EIK_ComputeSubcurves(IntPtr ptr, [In] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EIK_ComputeIntersectionPoints(IntPtr ptr, [In] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EIK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EIK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);
    }
}
