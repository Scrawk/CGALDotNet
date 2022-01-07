#include "SurfaceMesh3_EIK.h"
#include "SurfaceMesh3.h"

#include <unordered_set>

void* SurfaceMesh3_EIK_Create()
{
	return SurfaceMesh3<EIK>::NewSurfaceMesh();
}

void SurfaceMesh3_EIK_Release(void* ptr)
{
	SurfaceMesh3<EIK>::DeleteSurfaceMesh(ptr);
}

void SurfaceMesh3_EIK_Clear(void* ptr)
{
	SurfaceMesh3<EIK>::Clear(ptr);
}

void* SurfaceMesh3_EIK_Copy(void* ptr)
{
	return SurfaceMesh3<EIK>::Copy(ptr);
}

BOOL SurfaceMesh3_EIK_IsValid(void* ptr)
{
	return SurfaceMesh3<EIK>::IsValid(ptr);
}

int SurfaceMesh3_EIK_VertexCount(void* ptr)
{
	return SurfaceMesh3<EIK>::VertexCount(ptr);
}

int SurfaceMesh3_EIK_HalfEdgeCount(void* ptr)
{
	return SurfaceMesh3<EIK>::HalfEdgeCount(ptr);
}

int SurfaceMesh3_EIK_EdgeCount(void* ptr)
{
	return SurfaceMesh3<EIK>::EdgeCount(ptr);
}

int SurfaceMesh3_EIK_FaceCount(void* ptr)
{
	return SurfaceMesh3<EIK>::FaceCount(ptr);
}

int SurfaceMesh3_EIK_AddVertex(void* ptr, Point3d point)
{
	return SurfaceMesh3<EIK>::AddVertex(ptr, point);
}

int SurfaceMesh3_EIK_AddEdge(void* ptr, int v0, int v1)
{
	return SurfaceMesh3<EIK>::AddEdge(ptr, v0, v1);
}

int SurfaceMesh3_EIK_AddTriangle(void* ptr, int v0, int v1, int v2)
{
	return SurfaceMesh3<EIK>::AddTriangle(ptr, v0, v1, v2);
}

int SurfaceMesh3_EIK_AddQuad(void* ptr, int v0, int v1, int v2, int v3)
{
	return SurfaceMesh3<EIK>::AddQuad(ptr, v0, v1, v2, v3);
}

BOOL SurfaceMesh3_EIK_HasGarbage(void* ptr)
{
	return SurfaceMesh3<EIK>::HasGarbage(ptr);
}

void SurfaceMesh3_EIK_CollectGarbage(void* ptr)
{
	SurfaceMesh3<EIK>::CollectGarbage(ptr);
}

void SurfaceMesh3_EIK_SetRecycleGarbage(void* ptr, BOOL collect)
{
	SurfaceMesh3<EIK>::SetRecycleGarbage(ptr, collect);
}

BOOL SurfaceMesh3_EIK_DoesRecycleGarbage(void* ptr)
{
	return SurfaceMesh3<EIK>::DoesRecycleGarbage(ptr);
}

int SurfaceMesh3_EIK_VertexDegree(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::VertexDegree(ptr, index);
}

int SurfaceMesh3_EIK_FaceDegree(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::FaceDegree(ptr, index);
}

BOOL SurfaceMesh3_EIK_VertexIsIsolated(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::VertexIsIsolated(ptr, index);
}

BOOL SurfaceMesh3_EIK_VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
{
	return SurfaceMesh3<EIK>::VertexIsBorder(ptr, index, check_all_incident_halfedges);
}

BOOL SurfaceMesh3_EIK_EdgeIsBorder(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::EdgeIsBorder(ptr, index);
}

int SurfaceMesh3_EIK_NextHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::NextHalfedge(ptr, index);
}

int SurfaceMesh3_EIK_PreviousHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::PreviousHalfedge(ptr, index);
}

int SurfaceMesh3_EIK_OppositeHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::OppositeHalfedge(ptr, index);
}

int SurfaceMesh3_EIK_SourceVertex(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::SourceVertex(ptr, index);
}

int SurfaceMesh3_EIK_TargetVertex(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::TargetVertex(ptr, index);
}

void SurfaceMesh3_EIK_RemoveVertex(void* ptr, int index)
{
	SurfaceMesh3<EIK>::RemoveVertex(ptr, index);
}

void SurfaceMesh3_EIK_RemoveEdge(void* ptr, int index)
{
	SurfaceMesh3<EIK>::RemoveEdge(ptr, index);
}

void SurfaceMesh3_EIK_RemoveFace(void* ptr, int index)
{
	SurfaceMesh3<EIK>::RemoveFace(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsVertexValid(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsVertexValid(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsEdgeValid(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsEdgeValid(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsHalfedgeValid(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsHalfedgeValid(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsFaceValid(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsFaceValid(ptr, index);
}

Point3d SurfaceMesh3_EIK_GetPoint(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::GetPoint(ptr, index);
}

void SurfaceMesh3_EIK_GetPoints(void* ptr, Point3d* points, int count)
{
	SurfaceMesh3<EIK>::GetPoints(ptr, points, count);
}

void SurfaceMesh3_EIK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	SurfaceMesh3<EIK>::Transform(ptr, matrix);
}

void SurfaceMesh3_EIK_CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* indices, int indicesCount)
{
	SurfaceMesh3<EIK>::CreateTriangleMesh(ptr, points, pointsCount, indices, indicesCount);
}

BOOL SurfaceMesh3_EIK_CheckFaceVertices(void* ptr, int count)
{
	return false;
	//return SurfaceMesh3<EIK>::CheckFaceVertices(ptr, count);
}

int SurfaceMesh3_EIK_MaxFaceVertices(void* ptr)
{
	return 0;
	//return SurfaceMesh3<EIK>::MaxFaceVertices(ptr);
}
void SurfaceMesh3_EIK_GetTriangleIndices(void* ptr, int* indices, int count)
{
	//SurfaceMesh3<EIK>::GetTriangleIndices(ptr, indices, count);
}

