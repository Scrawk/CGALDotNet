﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
    internal sealed class SweepLineKernel_EEK : SweepLineKernel
    {
        private const string DLL_NAME = "CGALWrapper.dll";

        private const CallingConvention CDECL = CallingConvention.Cdecl;

        internal static readonly SweepLineKernel Instance = new SweepLineKernel_EEK();

        public override string ToString()
        {
            return string.Format("[SweepLine<{0}>: ]", Name);
        }

        internal override string Name => "EEK";

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

        internal override bool DoIntersect(IntPtr ptr, Segment2d[] segments, int startIndex, int count)
        {
            return SweepLine2_EEK_DoIntersect(ptr, segments, startIndex, count);
        }

        internal override int ComputeSubcurves(IntPtr ptr, Segment2d[] segments, int startIndex, int count)
        {
            return SweepLine2_EEK_ComputeSubcurves(ptr, segments, startIndex, count);
        }

        internal override int ComputeIntersectionPoints(IntPtr ptr, Segment2d[] segments, int startIndex, int count)
        {
            return SweepLine2_EEK_ComputeIntersectionPoints(ptr, segments, startIndex, count);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int startIndex, int count)
        {
            SweepLine2_EEK_GetPoints(ptr, points, startIndex, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int startIndex, int count)
        {
            SweepLine2_EEK_GetSegments(ptr, segments, startIndex, count);
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
        private static extern bool SweepLine2_EEK_DoIntersect(IntPtr ptr, [In] Segment2d[] segments, int startIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EEK_ComputeSubcurves(IntPtr ptr, [In] Segment2d[] segments, int startIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SweepLine2_EEK_ComputeIntersectionPoints(IntPtr ptr, [In] Segment2d[] segments, int startIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int startIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SweepLine2_EEK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int startIndex, int count);
    }
}