using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{
    internal class PolygonOffsetKernel2_EIK : PolygonOffsetKernel2
    {
        internal override string Name => "EIK";

        internal static readonly PolygonOffsetKernel2 Instance = new PolygonOffsetKernel2_EIK();

        internal override IntPtr Create()
        {
            return PolygonOffset2_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonOffset2_EIK_Release(ptr);
        }

        internal override int PolygonBufferSize(IntPtr ptr)
        {
            return PolygonOffset2_EIK_PolygonBufferSize(ptr);
        }

        internal override int SegmentBufferSize(IntPtr ptr)
        {
            return PolygonOffset2_EIK_SegmentBufferSize(ptr);
        }

        internal override void ClearPolygonBuffer(IntPtr ptr)
        {
            PolygonOffset2_EIK_ClearPolygonBuffer(ptr);
        }

        internal override void ClearSegmentBuffer(IntPtr ptr)
        {
            PolygonOffset2_EIK_ClearSegmentBuffer(ptr);
        }

        internal override IntPtr GetBufferedPolygon(IntPtr ptr, int index)
        {
            return PolygonOffset2_EIK_GetBufferedPolygon(ptr, index);
        }

        internal override Segment2d GetSegment(IntPtr ptr, int index)
        {
            return PolygonOffset2_EIK_GetSegment(ptr, index);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            PolygonOffset2_EIK_GetSegments(ptr, segments, count);
        }

        internal override void CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset)
        {
            PolygonOffset2_EIK_CreateInteriorOffset(ptr, polyPtr, offset);
        }

        internal override void CreateInteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly)
        {
            PolygonOffset2_EIK_CreateInteriorOffsetPWH(ptr, pwhPtr, offset, boundaryOnly);
        }

        internal override void CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset)
        {
            PolygonOffset2_EIK_CreateExteriorOffset(ptr, polyPtr, offset);
        }

        internal override void CreateExteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly)
        {
            PolygonOffset2_EIK_CreateExteriorOffsetPWH(ptr, pwhPtr, offset, boundaryOnly);
        }

        internal override void CreateInteriorSkeleton(IntPtr ptr, IntPtr polyPtr, bool includeBorder)
        {
            PolygonOffset2_EIK_CreateInteriorSkeleton(ptr, polyPtr, includeBorder);
        }

        internal override void CreateInteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, bool includeBorder)
        {
            PolygonOffset2_EIK_CreateInteriorSkeletonPWH(ptr, pwhPtr, includeBorder);
        }

        internal override void CreateExteriorSkeleton(IntPtr ptr, IntPtr polyPtr, double maxOffset, bool includeBorder)
        {
            PolygonOffset2_EIK_CreateExteriorSkeleton(ptr, polyPtr, maxOffset, includeBorder);
        }

        internal override void CreateExteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, double maxOffset, bool includeBorder)
        {
            PolygonOffset2_EIK_CreateExteriorSkeletonPWH(ptr, pwhPtr, maxOffset, includeBorder);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonOffset2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonOffset2_EIK_PolygonBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonOffset2_EIK_SegmentBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_ClearPolygonBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_ClearSegmentBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonOffset2_EIK_GetBufferedPolygon(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Segment2d PolygonOffset2_EIK_GetSegment(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateInteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateExteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateInteriorSkeleton(IntPtr ptr, IntPtr polyPtr, bool includeBorder);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateInteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, bool includeBorder);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateExteriorSkeleton(IntPtr ptr, IntPtr polyPtr, double maxOffset, bool includeBorder);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateExteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, double maxOffset, bool includeBorder);

    }
}
