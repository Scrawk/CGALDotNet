#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "FaceVertexCount.h"

extern "C"
{
	CGALWRAPPER_API void* SurfaceMesh3_EEK_Create();

	CGALWRAPPER_API void SurfaceMesh3_EEK_Release(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Clear(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces);

	CGALWRAPPER_API	void SurfaceMesh3_EEK_ClearProperyMaps(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL force);

	CGALWRAPPER_API void* SurfaceMesh3_EEK_Copy(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsValid(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsVertexValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsFaceValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsHalfedgeValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsEdgeValid(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_EdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_FaceCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddVertex(void* ptr, Point3d point);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddEdge(void* ptr, int v0, int v1);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddTriangle(void* ptr, int v0, int v1, int v2);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddQuad(void* ptr, int v0, int v1, int v2, int v3);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_HasGarbage(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_CollectGarbage(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_SetRecycleGarbage(void* ptr, BOOL collect);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_DoesRecycleGarbage(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_VertexDegree(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_FaceDegree(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_VertexIsIsolated(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_EdgeIsBorder(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_NextHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_PreviousHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_OppositeHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_SourceVertex(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_TargetVertex(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EEK_RemoveVertex(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EEK_RemoveEdge(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EEK_RemoveFace(void* ptr, int index);

	CGALWRAPPER_API Point3d SurfaceMesh3_EEK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Transform(void* ptr, const Matrix4x4d& matrix);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsHalfedgeBorder(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsEdgeBorder(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_BorderEdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_IsClosed(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_CheckFaceVertexCount(void* ptr, int count);

	CGALWRAPPER_API FaceVertexCount SurfaceMesh3_EEK_GetFaceVertexCount(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_CreateTriangleQuadMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int trianglesCount, int* quads, int quadsCount);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetTriangleQuadIndices(void* ptr, int* triangles, int trianglesCount, int* quads, int quadsCount);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Join(void* ptr, void* otherPtr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_BuildAABBTree(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ReleaseAABBTree(void* ptr);

	CGALWRAPPER_API Box3d SurfaceMesh3_EEK_GetBoundingBox(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ReadOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void SurfaceMesh3_EEK_WriteOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Triangulate(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_DoesSelfIntersect(void* ptr);

	CGALWRAPPER_API double SurfaceMesh3_EEK_Area(void* ptr);

	CGALWRAPPER_API Point3d SurfaceMesh3_EEK_Centroid(void* ptr);

	CGALWRAPPER_API double SurfaceMesh3_EEK_Volume(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_DoesBoundAVolume(void* ptr);

	CGALWRAPPER_API CGAL::Bounded_side SurfaceMesh3_EEK_SideOfTriangleMesh(void* ptr, const Point3d& point);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides);

	CGALWRAPPER_API MinMaxAvg SurfaceMesh3_EEK_MinMaxEdgeLength(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetCentroids(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API int SurfaceMesh3_EEK_PropertyMapCount(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ComputeVertexNormals(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ComputeFaceNormals(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetVertexNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetFaceNormals(void* ptr, Vector3d* normals, int count);

	

}