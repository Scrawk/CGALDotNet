using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Hulls
{
    internal sealed class ConvexHullKernel2_EEK : ConvexHullKernel2
    {
        private const string DLL_NAME = "CGALWrapper.dll";

        private const CallingConvention CDECL = CallingConvention.Cdecl;

        internal static readonly ConvexHullKernel2 Instance = new ConvexHullKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return ConvexHull2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            ConvexHull2_EEK_Release(ptr);
        }

        internal override IntPtr CreateHull(Point2d[] points, int startIndex, int count, HULL_METHOD method)
        {
            return ConvexHull2_EEK_CreateHull(points, startIndex, count, method);
        }

        internal override IntPtr UpperHull(Point2d[] points, int startIndex, int count)
        {
            return ConvexHull2_EEK_UpperHull(points, startIndex, count);
        }

        internal override IntPtr LowerHull(Point2d[] points, int startIndex, int count)
        {
            return ConvexHull2_EEK_LowerHull(points, startIndex, count);
        }

        internal override bool IsStronglyConvexCCW(Point2d[] points, int startIndex, int count)
        {
            return ConvexHull2_EEK_IsStronglyConvexCCW(points, startIndex, count);
        }

        internal override bool IsStronglyConvexCW(Point2d[] points, int startIndex, int count)
        {
            return IsStronglyConvexCW(points, startIndex, count);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ConvexHull2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ConvexHull2_EEK_CreateHull([In] Point2d[] points, int startIndex, int count, HULL_METHOD method);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ConvexHull2_EEK_UpperHull([In] Point2d[] points, int startIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ConvexHull2_EEK_LowerHull([In] Point2d[] points, int startIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool ConvexHull2_EEK_IsStronglyConvexCCW([In] Point2d[] points, int startIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool ConvexHull2_EEK_IsStronglyConvexCW([In] Point2d[] points, int startIndex, int count);
    }
}
