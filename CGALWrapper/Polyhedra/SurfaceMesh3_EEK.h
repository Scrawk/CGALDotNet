#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"

extern "C"
{
	CGALWRAPPER_API void* SurfaceMesh3_EEK_Create();

	CGALWRAPPER_API void SurfaceMesh3_EEK_Release(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Clear(void* ptr);

	CGALWRAPPER_API void* SurfaceMesh3_EEK_Copy(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsValid(void* ptr);

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

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsVertexValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsEdgeValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsHalfedgeValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsFaceValid(void* ptr, int index);

	CGALWRAPPER_API Point3d SurfaceMesh3_EEK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Transform(void* ptr, const Matrix4x4d& matrix);

	CGALWRAPPER_API void SurfaceMesh3_EEK_CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* indices, int indicesCount);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_CheckFaceVertices(void* ptr, int count);

	CGALWRAPPER_API int SurfaceMesh3_EEK_MaxFaceVertices(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetTriangleIndices(void* ptr, int* indices, int count);

}