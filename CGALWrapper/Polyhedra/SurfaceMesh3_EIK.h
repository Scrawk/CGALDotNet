#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"

extern "C"
{
	CGALWRAPPER_API void* SurfaceMesh3_EIK_Create();

	CGALWRAPPER_API void SurfaceMesh3_EIK_Release(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_Clear(void* ptr);

	CGALWRAPPER_API void* SurfaceMesh3_EIK_Copy(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsValid(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_VertexCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_EdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_FaceCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddVertex(void* ptr, Point3d point);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddEdge(void* ptr, int v0, int v1);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddTriangle(void* ptr, int v0, int v1, int v2);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddQuad(void* ptr, int v0, int v1, int v2, int v3);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_HasGarbage(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_CollectGarbage(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_SetRecycleGarbage(void* ptr, BOOL collect);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_DoesRecycleGarbage(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_VertexDegree(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_FaceDegree(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_VertexIsIsolated(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_EdgeIsBorder(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_NextHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_PreviousHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_OppositeHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_SourceVertex(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_TargetVertex(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EIK_RemoveVertex(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EIK_RemoveEdge(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EIK_RemoveFace(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsVertexValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsEdgeValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsHalfedgeValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsFaceValid(void* ptr, int index);

	CGALWRAPPER_API Point3d SurfaceMesh3_EIK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void SurfaceMesh3_EIK_Transform(void* ptr, const Matrix4x4d& matrix);

	CGALWRAPPER_API void SurfaceMesh3_EIK_CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* indices, int indicesCount);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_CheckFaceVertices(void* ptr, int count);

	CGALWRAPPER_API int SurfaceMesh3_EIK_MaxFaceVertices(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetTriangleIndices(void* ptr, int* indices, int count);

}