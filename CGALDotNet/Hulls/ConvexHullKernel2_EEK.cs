using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNet.Polygons;

namespace CGALDotNet.Hulls
{
    internal class ConvexHullKernel2_EEK : ConvexHullKernel2
    {
        internal override string Name => "EEK";

        internal static readonly ConvexHullKernel2 Instance = new ConvexHullKernel2_EEK();

        internal override IntPtr Create()
        {
            return ConvexHull2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            ConvexHull2_EEK_Release(ptr);
        }

        internal override IntPtr CreateHull(Point2d[] points, int count, HULL_METHOD method)
        {
            return ConvexHull2_EEK_CreateHull(points, count, method);
        }

        internal override IntPtr UpperHull(Point2d[] points, int count)
        {
            return ConvexHull2_EEK_UpperHull(points, count);
        }

        internal override IntPtr LowerHull(Point2d[] points, int count)
        {
            return ConvexHull2_EEK_LowerHull(points, count);
        }

        internal override bool IsStronglyConvexCCW(Point2d[] points, int count)
        {
            return ConvexHull2_EEK_IsStronglyConvexCCW(points, count);
        }

        internal override bool IsStronglyConvexCW(Point2d[] points, int count)
        {
            return IsStronglyConvexCW(points, count);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConvexHull2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EEK_CreateHull([In] Point2d[] points, int count, HULL_METHOD method);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EEK_UpperHull([In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EEK_LowerHull([In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConvexHull2_EEK_IsStronglyConvexCCW([In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConvexHull2_EEK_IsStronglyConvexCW([In] Point2d[] points, int count);
    }
}
