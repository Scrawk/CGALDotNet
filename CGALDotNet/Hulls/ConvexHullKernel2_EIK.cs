using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNet.Polygons;

namespace CGALDotNet.Hulls
{
    internal class ConvexHullKernel2_EIK : ConvexHullKernel2
    {
        internal override string Name => "EIK";

        internal static readonly ConvexHullKernel2 Instance = new ConvexHullKernel2_EIK();

        internal override IntPtr Create()
        {
            return ConvexHull2_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            ConvexHull2_EIK_Release(ptr);
        }

        internal override IntPtr CreateHull(Point2d[] points, int count, HULL_METHOD method)
        {
            return ConvexHull2_EIK_CreateHull(points, count, method);
        }

        internal override IntPtr UpperHull(Point2d[] points, int count)
        {
            return ConvexHull2_EIK_UpperHull(points, count);
        }

        internal override IntPtr LowerHull(Point2d[] points, int count)
        {
            return ConvexHull2_EIK_LowerHull(points, count);
        }

        internal override bool IsStronglyConvexCCW(Point2d[] points, int count)
        {
            return ConvexHull2_EIK_IsStronglyConvexCCW(points, count);
        }

        internal override bool IsStronglyConvexCW(Point2d[] points, int count)
        {
            return IsStronglyConvexCW(points, count);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConvexHull2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EIK_CreateHull([In] Point2d[] points, int count, HULL_METHOD method);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EIK_UpperHull([In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull2_EIK_LowerHull([In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConvexHull2_EIK_IsStronglyConvexCCW([In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConvexHull2_EIK_IsStronglyConvexCW([In] Point2d[] points, int count);
    }
}
