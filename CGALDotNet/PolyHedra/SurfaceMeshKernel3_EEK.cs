using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
    internal class SurfaceMeshKernel3_EEK : SurfaceMeshKernel3
    {
        internal override string Name => "EEK";

        internal static readonly SurfaceMeshKernel3 Instance = new SurfaceMeshKernel3_EEK();

        internal override IntPtr Create()
        {
            return SurfaceMesh3_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SurfaceMesh3_EEK_Release(ptr);
        }

        internal override int GetBuildStamp(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_GetBuildStamp(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            SurfaceMesh3_EEK_Clear(ptr);
        }

        internal override void ClearIndexMaps(IntPtr ptr, bool vertices, bool faces, bool edges, bool halfedges)
        {
            SurfaceMesh3_EEK_ClearIndexMaps(ptr, vertices, faces, edges, halfedges);
        }

        internal override void ClearNormalMaps(IntPtr ptr, bool vertices, bool faces)
        {
            SurfaceMesh3_EEK_ClearNormalMaps(ptr, vertices, faces);
        }

        internal override void ClearProperyMaps(IntPtr ptr)
        {
            SurfaceMesh3_EEK_ClearProperyMaps(ptr);
        }

        internal override void BuildIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool halfedges, bool force)
        {
            SurfaceMesh3_EEK_BuildIndices(ptr, vertices, faces, edges, halfedges, force);
        }

        internal override void PrintIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool halfedges, bool force)
        {
            SurfaceMesh3_EEK_PrintIndices(ptr, vertices, faces, edges, halfedges, force);
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

        internal override int HalfedgeCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_HalfedgeCount(ptr);
        }

        internal override int EdgeCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_EdgeCount(ptr);
        }

        internal override int FaceCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_FaceCount(ptr);
        }

        internal override int RemovedVertexCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_RemovedVertexCount(ptr);
        }

        internal override int RemovedHalfedgeCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_RemovedHalfedgeCount(ptr);
        }

        internal override int RemovedEdgeCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_RemovedEdgeCount(ptr);
        }

        internal override int RemovedFaceCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_RemovedFaceCount(ptr);
        }

        internal override bool IsVertexRemoved(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsVertexRemoved(ptr, index);
        }

        internal override bool IsFaceRemoved(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsFaceRemoved(ptr, index);
        }

        internal override bool IsHalfedgeRemoved(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsHalfedgeRemoved(ptr, index);
        }

        internal override bool IsEdgeRemoved(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsEdgeRemoved(ptr, index);
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

        internal override int NextAroundSource(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_NextAroundSource(ptr, index);
        }

        internal override int NextAroundTarget(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_NextAroundTarget(ptr, index);
        }

        internal override int PreviousAroundSource(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_PreviousAroundSource(ptr, index);
        }

        internal override int PreviousAroundTarget(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_PreviousAroundTarget(ptr, index);
        }

        internal override int EdgesHalfedge(IntPtr ptr, int edgeIndex, int halfedgeIndex)
        {
            return SurfaceMesh3_EdgesHalfedge(ptr, edgeIndex, halfedgeIndex);
        }

        internal override bool RemoveVertex(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_RemoveVertex(ptr, index);
        }

        internal override bool RemoveEdge(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_RemoveEdge(ptr, index);
        }

        internal override bool RemoveFace(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_RemoveFace(ptr, index);
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
            SurfaceMesh3_EEK_GetPoints(ptr, points, count);
        }

        internal override void SetPoint(IntPtr ptr, int index, Point3d point)
        {
            SurfaceMesh3_EEK_SetPoint(ptr, index, point);
        }

        internal override void SetPoints(IntPtr ptr, Point3d[] points, int count)
        {
            SurfaceMesh3_EEK_SetPoints(ptr, points, count);
        }

        internal override bool GetSegment(IntPtr ptr, int index, out Segment3d segment)
        {
            return SurfaceMesh3_EEK_GetSegment(ptr, index, out segment);
        }

        internal override void GetSegments(IntPtr ptr, Segment3d[] segments, int count)
        {
            SurfaceMesh3_EEK_GetSegments(ptr, segments, count);
        }

        internal override bool GetTriangle(IntPtr ptr, int index, out Triangle3d tri)
        {
            return SurfaceMesh3_EEK_GetTriangle(ptr, index, out tri);
        }

        internal override void GetTriangles(IntPtr ptr, Triangle3d[] triangles, int count)
        {
            SurfaceMesh3_EEK_GetTriangles(ptr, triangles, count);
        }

        internal override bool GetVertex(IntPtr ptr, int index, out MeshVertex3 vert)
        {
            return SurfaceMesh3_EEK_GetVertex(ptr,index, out vert);
        }

        internal override void GetVertices(IntPtr ptr, MeshVertex3[] vertexArray, int count)
        {
            SurfaceMesh3_EEK_GetVertices(ptr, vertexArray, count);
        }

        internal override bool GetFace(IntPtr ptr, int index, out MeshFace3 face)
        {
            return SurfaceMesh3_EEK_GetFace(ptr, index, out face);
        }

        internal override void GetFaces(IntPtr ptr, MeshFace3[] faceArray, int count)
        {
            SurfaceMesh3_EEK_GetFaces(ptr, faceArray, count);
        }

        internal override bool GetHalfedge(IntPtr ptr, int index, out MeshHalfedge3 edge)
        {
            return SurfaceMesh3_EEK_GetHalfedge(ptr, index, out edge);
        }

        internal override void GetHalfedges(IntPtr ptr, MeshHalfedge3[] edgeArray, int count)
        {
            SurfaceMesh3_EEK_GetHalfedges(ptr, edgeArray, count);
        }

        internal override void Transform(IntPtr ptr, Matrix4x4d matrix)
        {
            SurfaceMesh3_EEK_Transform(ptr, matrix);
        }

        internal override bool IsVertexBorder(IntPtr ptr, int index, bool check_all_incident_halfedges)
        {
            return SurfaceMesh3_EEK_IsVertexBorder(ptr,index, check_all_incident_halfedges);
        }

        internal override bool IsHalfedgeBorder(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsHalfedgeBorder(ptr,index);
        }

        internal override bool IsEdgeBorder(IntPtr ptr, int index)
        {
            return SurfaceMesh3_EEK_IsEdgeBorder(ptr,index);
        }

        internal override int BorderEdgeCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_BorderEdgeCount(ptr);   
        }

        internal override bool IsClosed(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_IsClosed(ptr);
        }

        internal override bool CheckFaceVertexCount(IntPtr ptr, int count)
        {
            return SurfaceMesh3_EEK_CheckFaceVertexCount(ptr, count);   
        }

        internal override int AddPentagon(IntPtr ptr, int v0, int v1, int v2, int v3, int v4)
        {
            return SurfaceMesh3_EEK_AddPentagon(ptr, v0, v1, v2, v3, v4);
        }

        internal override int AddHexagon(IntPtr ptr, int v0, int v1, int v2, int v3, int v4, int v5)
        {
            return SurfaceMesh3_EEK_AddHexagon(ptr, v0, v1, v2, v3, v4, v5);
        }

        internal override int AddFace(IntPtr ptr, int[] indices, int count)
        {
            return SurfaceMesh3_EEK_AddFace(ptr, indices, count);
        }

        internal override void Join(IntPtr ptr, IntPtr otherPtr)
        {
            SurfaceMesh3_EEK_Join(ptr, otherPtr);
        }

        internal override void BuildAABBTree(IntPtr ptr)
        { 
            SurfaceMesh3_EEK_BuildAABBTree(ptr);
        }

        internal override void ReleaseAABBTree(IntPtr ptr)
        { 
            SurfaceMesh3_EEK_ReleaseAABBTree(ptr);
        }

        internal override Box3d GetBoundingBox(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_GetBoundingBox(ptr);
        }

        internal override void ReadOFF(IntPtr ptr, string filename)
        { 
            SurfaceMesh3_EEK_ReadOFF(ptr, filename);    
        }

        internal override void WriteOFF(IntPtr ptr, string filename)
        { 
            SurfaceMesh3_EEK_WriteOFF(ptr, filename);
        }

        internal override void Triangulate(IntPtr ptr)
        {
            SurfaceMesh3_EEK_Triangulate(ptr);
        }

        internal override bool DoesSelfIntersect(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_DoesBoundAVolume(ptr);
        }

        internal override double Area(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_Area(ptr);
        }

        internal override Point3d Centroid(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_Centroid(ptr);
        }

        internal override double Volume(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_Volume(ptr);
        }

        internal override bool DoesBoundAVolume(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_DoesBoundAVolume(ptr);
        }

        internal override BOUNDED_SIDE SideOfTriangleMesh(IntPtr ptr, Point3d point)
        {
            return SurfaceMesh3_EEK_SideOfTriangleMesh(ptr, point);
        }

        internal override bool DoIntersects(IntPtr ptr, IntPtr otherPtr, bool test_bounded_sides)
        {
            return SurfaceMesh3_EEK_DoIntersects(ptr, otherPtr, test_bounded_sides);
        }

        internal override void GetCentroids(IntPtr ptr, Point3d[] points, int count) 
        { 
            SurfaceMesh3_EEK_GetCentroids(ptr, points, count);  
        }

        internal override void ComputeVertexNormals(IntPtr ptr)
        {
            SurfaceMesh3_EEK_ComputeVertexNormals(ptr);
        }

        internal override void ComputeFaceNormals(IntPtr ptr)
        {
            SurfaceMesh3_EEK_ComputeFaceNormals(ptr);
        }

        internal override void GetVertexNormals(IntPtr ptr, Vector3d[] normals, int count)
        {
            SurfaceMesh3_EEK_GetVertexNormals(ptr, normals, count);
        }

        internal override void GetFaceNormals(IntPtr ptr, Vector3d[] normals, int count)
        {
            SurfaceMesh3_EEK_GetFaceNormals(ptr, normals, count);
        }

        internal override PolygonalCount GetPolygonalCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_GetPolygonalCount(ptr);    
        }

        internal override PolygonalCount GetDualPolygonalCount(IntPtr ptr)
        {
            return SurfaceMesh3_EEK_GetDualPolygonalCount(ptr);
        }

        internal override void CreatePolygonMesh(IntPtr ptr, Point2d[] points, int count, bool xz)
        {
            SurfaceMesh3_EEK_CreatePolygonMesh(ptr, points, count, xz);
        }

        internal override void CreatePolygonalMesh(IntPtr ptr,
            Point3d[] points, int pointsCount,
            int[] triangles, int triangleCount,
            int[] quads, int quadCount,
            int[] pentagons, int pentagonCount,
            int[] hexagons, int hexagonCount)
        {
            SurfaceMesh3_EEK_CreatePolygonalMesh(ptr, 
                points, pointsCount, 
                triangles, triangleCount, 
                quads, quadCount, 
                pentagons, pentagonCount, 
                hexagons, hexagonCount);
        }

        internal override void GetPolygonalIndices(IntPtr ptr,
            int[] triangles, int triangleCount,
            int[] quads, int quadCount,
            int[] pentagons, int pentagonCount,
            int[] hexagons, int hexagonCount)
        {
            SurfaceMesh3_EEK_GetPolygonalIndices(ptr,
                triangles, triangleCount,
                quads, quadCount,
                pentagons, pentagonCount,
                hexagons, hexagonCount);
        }

        internal override void GetDualPolygonalIndices(IntPtr ptr,
            int[] triangles, int triangleCount,
            int[] quads, int quadCount,
            int[] pentagons, int pentagonCount,
            int[] hexagons, int hexagonCount)
        {
            SurfaceMesh3_EEK_GetDualPolygonalIndices(ptr,
                triangles, triangleCount,
                quads, quadCount,
                pentagons, pentagonCount,
                hexagons, hexagonCount);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceMesh3_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_GetBuildStamp(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_ClearIndexMaps(IntPtr ptr, bool vertices, bool faces, bool halfedges, bool edges);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_ClearNormalMaps(IntPtr ptr, bool vertices, bool faces);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_ClearProperyMaps(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_BuildIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool halfedges, bool force);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_PrintIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool halfedges, bool build);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceMesh3_EEK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsValid(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_VertexCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_HalfedgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_EdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_FaceCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_RemovedVertexCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_RemovedHalfedgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_RemovedEdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_RemovedFaceCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsVertexRemoved(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsFaceRemoved(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsHalfedgeRemoved(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsEdgeRemoved(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddVertex(IntPtr ptr, Point3d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddEdge(IntPtr ptr, int v0, int v1);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddTriangle(IntPtr ptr, int v0, int v1, int v2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddQuad(IntPtr ptr, int v0, int v1, int v2, int v3);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddPentagon(IntPtr ptr, int v0, int v1, int v2, int v3, int v4);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddHexagon(IntPtr ptr, int v0, int v1, int v2, int v3, int v4, int v5);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_AddFace(IntPtr ptr, int[] indices, int count);

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
        private static extern bool SurfaceMesh3_EEK_RemoveVertex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_NextAroundSource(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_NextAroundTarget(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_PreviousAroundSource(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_PreviousAroundTarget(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EdgesHalfedge(IntPtr ptr, int edgeIndex, int halfedgeIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_RemoveEdge(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_RemoveFace(IntPtr ptr, int index);

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
        private static extern void SurfaceMesh3_EEK_SetPoint(IntPtr ptr, int index, Point3d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_SetPoints(IntPtr ptr, [Out] Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_GetSegment(IntPtr ptr, int index, [Out] out Segment3d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetSegments(IntPtr ptr, [Out] Segment3d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_GetTriangle(IntPtr ptr, int index, [Out] out Triangle3d tri);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetTriangles(IntPtr ptr, [Out] Triangle3d[] triangles, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_GetVertex(IntPtr ptr, int index, [Out] out MeshVertex3 vert);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetVertices(IntPtr ptr, [Out] MeshVertex3[] vertexArray, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_GetFace(IntPtr ptr, int index, [Out] out MeshFace3 face);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetFaces(IntPtr ptr, [Out] MeshFace3[] faceArray, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_GetHalfedge(IntPtr ptr, int index, [Out] out MeshHalfedge3 edge);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetHalfedges(IntPtr ptr, [Out] MeshHalfedge3[] edgeArray, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Transform(IntPtr ptr, Matrix4x4d matrix);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsVertexBorder(IntPtr ptr, int index, bool check_all_incident_halfedges);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsHalfedgeBorder(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsEdgeBorder(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesh3_EEK_BorderEdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_IsClosed(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_CheckFaceVertexCount(IntPtr ptr, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Join(IntPtr ptr, IntPtr otherPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_BuildAABBTree(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_ReleaseAABBTree(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Box3d SurfaceMesh3_EEK_GetBoundingBox(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_ReadOFF(IntPtr ptr, string filename);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_WriteOFF(IntPtr ptr, string filename);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_Triangulate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_DoesSelfIntersect(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double SurfaceMesh3_EEK_Area(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point3d SurfaceMesh3_EEK_Centroid(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double SurfaceMesh3_EEK_Volume(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_DoesBoundAVolume(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern BOUNDED_SIDE SurfaceMesh3_EEK_SideOfTriangleMesh(IntPtr ptr, Point3d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool SurfaceMesh3_EEK_DoIntersects(IntPtr ptr, IntPtr otherPtr, bool test_bounded_sides);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetCentroids(IntPtr ptr, [Out] Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_ComputeVertexNormals(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_ComputeFaceNormals(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetVertexNormals(IntPtr ptr, [Out] Vector3d[] normals, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetFaceNormals(IntPtr ptr, [Out] Vector3d[] normals, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern PolygonalCount SurfaceMesh3_EEK_GetPolygonalCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern PolygonalCount SurfaceMesh3_EEK_GetDualPolygonalCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_CreatePolygonMesh(IntPtr ptr, Point2d[] points, int count, bool xz);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_CreatePolygonalMesh(IntPtr ptr,
            Point3d[] points, int pointsCount,
            int[] triangles, int triangleCount,
            int[] quads, int quadCount,
            int[] pentagons, int pentagonCount,
            int[] hexagons, int hexagonCount);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetPolygonalIndices(IntPtr ptr,
            [Out] int[] triangles, int triangleCount,
            [Out] int[] quads, int quadCount,
            [Out] int[] pentagons, int pentagonCount,
            [Out] int[] hexagons, int hexagonCount);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesh3_EEK_GetDualPolygonalIndices(IntPtr ptr,
            [Out] int[] triangles, int triangleCount,
            [Out] int[] quads, int quadCount,
            [Out] int[] pentagons, int pentagonCount,
            [Out] int[] hexagons, int hexagonCount);

    }
}
