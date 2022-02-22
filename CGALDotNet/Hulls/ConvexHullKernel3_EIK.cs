using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Hulls
{
    internal class ConvexHullKernel3_EIK : ConvexHullKernel3
    {
        internal override string Name => "EIK";

        internal static readonly ConvexHullKernel3 Instance = new ConvexHullKernel3_EIK();

        internal override IntPtr Create()
        {
            return ConvexHull3_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            ConvexHull3_EIK_Release(ptr);
        }

        internal override IntPtr CreateHullAsPolyhedronFromPoints(Point3d[] points, int count)
        {
            return ConvexHull3_EIK_CreateHullAsPolyhedronFromPoints(points, count);
        }

        internal override IntPtr CreateHullAsSurfaceMeshFromPoints(Point3d[] points, int count)
        {
            return ConvexHull3_EIK_CreateHullAsSurfaceMeshFromPoints((Point3d[])points, count);
        }

        internal override IntPtr CreateHullAsPolyhedronFromPlanes(Plane3d[] planes, int count)
        {
            return ConvexHull3_EIK_CreateHullAsPolyhedronFromPlanes(planes, count);
        }

        internal override IntPtr CreateHullAsSurfaceMeshFromPlanes(Plane3d[] planes, int count)
        {
            return ConvexHull3_EIK_CreateHullAsSurfaceMeshFromPlanes(planes, count);
        }

        internal override bool IsPolyhedronStronglyConvex(IntPtr ptr)
        {
            return ConvexHull3_EIK_IsPolyhedronStronglyConvex(ptr);
        }

        internal override bool IsSurfaceMeshStronglyConvex(IntPtr ptr)
        {
            return ConvexHull3_EIK_IsSurfaceMeshStronglyConvex(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConvexHull3_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EIK_CreateHullAsPolyhedronFromPoints(Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EIK_CreateHullAsSurfaceMeshFromPoints(Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EIK_CreateHullAsPolyhedronFromPlanes(Plane3d[] planes, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EIK_CreateHullAsSurfaceMeshFromPlanes(Plane3d[] planes, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConvexHull3_EIK_IsPolyhedronStronglyConvex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConvexHull3_EIK_IsSurfaceMeshStronglyConvex(IntPtr ptr);
    }
}
