using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Hulls
{
    internal class ConvexHullKernel3_EEK : ConvexHullKernel3
    {
        internal override string Name => "EEK";

        internal static readonly ConvexHullKernel3 Instance = new ConvexHullKernel3_EEK();

        internal override IntPtr Create()
        {
            return ConvexHull3_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            ConvexHull3_EEK_Release(ptr);
        }

        internal override IntPtr CreateHullAsPolyhedronFromPoints(Point3d[] points, int count)
        {
            return ConvexHull3_EEK_CreateHullAsPolyhedronFromPoints(points, count);
        }

        internal override IntPtr CreateHullAsSurfaceMeshFromPoints(Point3d[] points, int count)
        {
            return ConvexHull3_EEK_CreateHullAsSurfaceMeshFromPoints((Point3d[])points, count);
        }

        internal override IntPtr CreateHullAsPolyhedronFromPlanes(Plane3d[] planes, int count)
        {
            return ConvexHull3_EEK_CreateHullAsPolyhedronFromPlanes(planes, count);  
        }

        internal override IntPtr CreateHullAsSurfaceMeshFromPlanes(Plane3d[] planes, int count)
        {
            return ConvexHull3_EEK_CreateHullAsSurfaceMeshFromPlanes(planes, count);
        }

        internal override bool IsPolyhedronStronglyConvex(IntPtr ptr)
        {
            return ConvexHull3_EEK_IsPolyhedronStronglyConvex(ptr);
        }

        internal override bool IsSurfaceMeshStronglyConvex(IntPtr ptr)
        {
            return ConvexHull3_EEK_IsSurfaceMeshStronglyConvex(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConvexHull3_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EEK_CreateHullAsPolyhedronFromPoints(Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EEK_CreateHullAsSurfaceMeshFromPoints(Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EEK_CreateHullAsPolyhedronFromPlanes(Plane3d[] planes, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConvexHull3_EEK_CreateHullAsSurfaceMeshFromPlanes(Plane3d[] planes, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConvexHull3_EEK_IsPolyhedronStronglyConvex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConvexHull3_EEK_IsSurfaceMeshStronglyConvex(IntPtr ptr);
    }
}
