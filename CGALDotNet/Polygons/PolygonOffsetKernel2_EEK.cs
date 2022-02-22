using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{
    internal class PolygonOffsetKernel2_EEK : PolygonOffsetKernel2
    {
        internal override string Name => "EEK";

        internal static readonly PolygonOffsetKernel2 Instance = new PolygonOffsetKernel2_EEK();

        internal override IntPtr Create()
        {
            return PolygonOffset2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonOffset2_EEK_Release(ptr);
        }

        internal override int PolygonBufferSize(IntPtr ptr)
        {
            return PolygonOffset2_EEK_PolygonBufferSize(ptr);
        }

        internal override int SegmentBufferSize(IntPtr ptr)
        {
            return PolygonOffset2_EEK_SegmentBufferSize(ptr);
        }

        internal override void ClearPolygonBuffer(IntPtr ptr)
        {
            PolygonOffset2_EEK_ClearPolygonBuffer(ptr);
        }

        internal override void ClearSegmentBuffer(IntPtr ptr)
        {
            PolygonOffset2_EEK_ClearSegmentBuffer(ptr);
        }

        internal override IntPtr GetBufferedPolygon(IntPtr ptr, int index)
        {
            return PolygonOffset2_EEK_GetBufferedPolygon(ptr, index);
        }

        internal override Segment2d GetSegment(IntPtr ptr, int index)
        {
            return PolygonOffset2_EEK_GetSegment(ptr, index);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            PolygonOffset2_EEK_GetSegments(ptr, segments, count);
        }

        internal override void CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset)
        {
            PolygonOffset2_EEK_CreateInteriorOffset(ptr, polyPtr, offset);
        }

        internal override void CreateInteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly)
        {
            PolygonOffset2_EEK_CreateInteriorOffsetPWH(ptr, pwhPtr, offset, boundaryOnly);
        }

        internal override void CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset)
        {
            PolygonOffset2_EEK_CreateExteriorOffset(ptr, polyPtr, offset);
        }

        internal override void CreateExteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly)
        {
            PolygonOffset2_EEK_CreateExteriorOffsetPWH(ptr, pwhPtr, offset, boundaryOnly);
        }

        internal override void CreateInteriorSkeleton(IntPtr ptr, IntPtr polyPtr, bool includeBorder)
        {
            PolygonOffset2_EEK_CreateInteriorSkeleton(ptr, polyPtr, includeBorder);
        }

        internal override void CreateInteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, bool includeBorder)
        {
            PolygonOffset2_EEK_CreateInteriorSkeletonPWH(ptr, pwhPtr, includeBorder);
        }

        internal override void CreateExteriorSkeleton(IntPtr ptr, IntPtr polyPtr, double maxOffset, bool includeBorder)
        {
            PolygonOffset2_EEK_CreateExteriorSkeleton(ptr, polyPtr, maxOffset, includeBorder);
        }

        internal override void CreateExteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, double maxOffset, bool includeBorder)
        {
            PolygonOffset2_EEK_CreateExteriorSkeletonPWH(ptr, pwhPtr, maxOffset, includeBorder);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonOffset2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonOffset2_EEK_PolygonBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonOffset2_EEK_SegmentBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_ClearPolygonBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_ClearSegmentBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonOffset2_EEK_GetBufferedPolygon(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Segment2d PolygonOffset2_EEK_GetSegment(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateInteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateExteriorOffsetPWH(IntPtr ptr, IntPtr pwhPtr, double offset, bool boundaryOnly);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateInteriorSkeleton(IntPtr ptr, IntPtr polyPtr, bool includeBorder);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateInteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, bool includeBorder);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateExteriorSkeleton(IntPtr ptr, IntPtr polyPtr, double maxOffset, bool includeBorder);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateExteriorSkeletonPWH(IntPtr ptr, IntPtr pwhPtr, double maxOffset, bool includeBorder);

    }
}
