using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
    internal class SurfaceMeshKernel3_EEK : SurfaceMeshKernel3
    {
        internal override string KernelName => "EEK";

        internal static readonly SurfaceMeshKernel3 Instance = new SurfaceMeshKernel3_EEK();

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

        internal override IntPtr Copy(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_Copy(ptr);
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

        internal override int AddTriangle(IntPtr ptr, int v0, int v1, int v2)
        {
            return SurfaceMesh3_EEK_AddTriangle(ptr, v0, v1, v2);
        }

        internal override int AddQuad(IntPtr ptr, int v0, int v1, int v2, int v3)
        {
            return SurfaceMesh3_EEK_AddQuad(ptr, v0, v1, v2, v3);
        }

        internal override bool HasGarbage(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_HasGarbage(ptr);
        }

        internal override void CollectGarbage(IntPtr ptr)
        {
            SurfaceMesh3_EEK_CollectGarbage(ptr);   
        }

        internal override void SetRecycleGarbage(IntPtr ptr, bool collect)
        {
            SurfaceMesh3_EEK_SetRecycleGarbage(ptr, collect);   
        }

        internal override bool DoesRecycleGarbage(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_DoesRecycleGarbage(ptr);    
        }

        internal override int VertexDegree(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_VertexDegree(ptr, index);   
        }

        internal override int FaceDegree(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_FaceDegree(ptr, index); 
        }

        internal override bool VertexIsIsolated(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_VertexIsIsolated(ptr, index);   
        }

        internal override bool VertexIsBorder(IntPtr ptr, int index, bool check_all_incident_halfedges)
        {
            return SurfaceMesh3_EEK_VertexIsBorder(ptr, index, check_all_incident_halfedges);
        }

        internal override bool EdgeIsBorder(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_EdgeIsBorder(ptr, index);
        }

        internal override int NextHalfedge(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_NextHalfedge(ptr, index);   
        }

        internal override int PreviousHalfedge(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_PreviousHalfedge(ptr, index);   
        }

        internal override int OppositeHalfedge(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_OppositeHalfedge(ptr, index);   
        }

        internal override int SourceVertex(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_SourceVertex(ptr, index);
        }

        internal override int TargetVertex(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_TargetVertex(ptr, index);
        }

        internal override void RemoveVertex(IntPtr ptr, int index)
        {
            SurfaceMesh3_EEK_RemoveVertex(ptr, index);  
        }

        internal override void RemoveEdge(IntPtr ptr, int index)
        {
            SurfaceMesh3_EEK_RemoveEdge(ptr, index);
        }

        internal override void RemoveFace(IntPtr ptr, int index)
        {
            SurfaceMesh3_EEK_RemoveFace(ptr, index);
        }

        internal override bool IsVertexValid(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsVertexValid(ptr, index);
        }

        internal override bool IsEdgeValid(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsEdgeValid(ptr, index);
        }

        internal override bool IsHalfedgeValid(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsHalfedgeValid(ptr, index);
        }

        internal override bool IsFaceValid(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsFaceValid(ptr, index);
        }

        internal override Point3d GetPoint(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_GetPoint(ptr, index);
        }

        internal override void GetPoints(IntPtr ptr, Point3d[] points, int count)
        {
            SurfaceMesh3_EEK_GetPoints (ptr, points, count);
        }

        internal override void Transform(IntPtr ptr, Matrix4x4d matrix)
        {
            SurfaceMesh3_EEK_Transform(ptr, matrix);
        }

        internal override void CreateTriangleMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] indices, int indicesCount)
        {
            SurfaceMesh3_EEK_CreateTriangleMesh (ptr, points, pointsCount, indices, indicesCount);
        }

        //internal override bool CheckFaceVertices(IntPtr ptr, int count)
        //{
        //    return SurfaceMesh3_EEK_CheckFaceVertices(ptr, count);
        //}

        //internal override int MaxFaceVertices(IntPtr ptr)
        //{
        //    return SurfaceMesh3_EEK_MaxFaceVertices(ptr);
        //}

        //internal override void GetTriangleIndices(IntPtr ptr, int[] indices, int count)
        //{
        //    SurfaceMesh3_EEK_GetTriangleIndices(ptr, indices, count);
        //}

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceMesh3_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceMesh3_EEK_Copy(IntPtr ptr);

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
        private static extern int SurfaceMesh3_EEK_AddTriangle(IntPtr ptr, int v0, int v1, int v2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddQuad(IntPtr ptr, int v0, int v1, int v2, int v3);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_HasGarbage(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_CollectGarbage(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_SetRecycleGarbage(IntPtr ptr, bool collect);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_DoesRecycleGarbage(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_VertexDegree(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_FaceDegree(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_VertexIsIsolated(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_VertexIsBorder(IntPtr ptr, int index, bool check_all_incident_halfedges);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_EdgeIsBorder(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_NextHalfedge(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_PreviousHalfedge(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_OppositeHalfedge(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_SourceVertex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_TargetVertex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_RemoveVertex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_RemoveEdge(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_RemoveFace(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsVertexValid(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsEdgeValid(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsHalfedgeValid(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsFaceValid(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point3d SurfaceMesh3_EEK_GetPoint(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetPoints(IntPtr ptr, [Out] Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Transform(IntPtr ptr, Matrix4x4d matrix);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_CreateTriangleMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] indices, int indicesCount);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_CheckFaceVertices(IntPtr ptr, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_MaxFaceVertices(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetTriangleIndices(IntPtr ptr,[Out] int[] indices, int count);

    }
}
