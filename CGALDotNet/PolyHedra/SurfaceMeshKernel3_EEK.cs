using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{
    internal class SurfaceMeshKernel3_EEK : SurfaceMeshKernel3
    {
        internal static readonly SurfaceMeshKernel3 Instance = new SurfaceMeshKernel3_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return SurfaceMesh3_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SurfaceMesh3_EEK_Release(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            SurfaceMesh3_EEK_Clear(ptr);
        }

        internal override bool IsValid(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_IsValid(ptr);
        }

        internal override int VertexCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_VertexCount(ptr);
        }

        internal override int HalfEdgeCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_HalfEdgeCount(ptr);
        }

        internal override int EdgeCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_EdgeCount(ptr);
        }

        internal override int FaceCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_FaceCount(ptr);
        }

        internal override int AddVertex(IntPtr ptr, Point3d point)
        {
            return SurfaceMesh3_EEK_AddVertex(ptr, point);
        }

        internal override int AddEdge(IntPtr ptr, int v0, int v1)
        {
            return SurfaceMesh3_EEK_AddEdge(ptr, v0, v1);
        }

        internal override int AddFace(IntPtr ptr, int v0, int v1, int v2)
        {
            return SurfaceMesh3_EEK_AddFace(ptr, v0, v1, v2);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceMesh3_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsValid(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_VertexCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_HalfEdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_EdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_FaceCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddVertex(IntPtr ptr, Point3d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddEdge(IntPtr ptr, int v0, int v1);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddFace(IntPtr ptr, int v0, int v1, int v2);

    }
}
