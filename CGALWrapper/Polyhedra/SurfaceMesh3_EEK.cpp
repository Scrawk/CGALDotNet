#include "SurfaceMesh3_EEK.h"
#include "SurfaceMesh3.h"

#include <unordered_set>

void* SurfaceMesh3_EEK_Create()
{
	return SurfaceMesh3<EEK>::NewSurfaceMesh();
}

void SurfaceMesh3_EEK_Release(void* ptr)
{
	SurfaceMesh3<EEK>::DeleteSurfaceMesh(ptr);
}

void SurfaceMesh3_EEK_Clear(void* ptr)
{
	SurfaceMesh3<EEK>::Clear(ptr);
}

void* SurfaceMesh3_EEK_Copy(void* ptr)
{
	return SurfaceMesh3<EEK>::Copy(ptr);
}

void Polyhedron3_EEK_Join(void* ptr, void* otherPtr)
{
	SurfaceMesh3<EEK>::Join(ptr, otherPtr);
}

BOOL SurfaceMesh3_EEK_IsValid(void* ptr)
{
	return SurfaceMesh3<EEK>::IsValid(ptr);
}

int SurfaceMesh3_EEK_VertexCount(void* ptr)
{
	return SurfaceMesh3<EEK>::VertexCount(ptr);
}

int SurfaceMesh3_EEK_HalfEdgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::HalfEdgeCount(ptr);
}

int SurfaceMesh3_EEK_EdgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::EdgeCount(ptr);
}

int SurfaceMesh3_EEK_FaceCount(void* ptr)
{
	return SurfaceMesh3<EEK>::FaceCount(ptr);
}

int SurfaceMesh3_EEK_AddVertex(void* ptr, Point3d point)
{
	return SurfaceMesh3<EEK>::AddVertex(ptr, point);
}

int SurfaceMesh3_EEK_AddEdge(void* ptr, int v0, int v1)
{
	return SurfaceMesh3<EEK>::AddEdge(ptr, v0, v1);
}

int SurfaceMesh3_EEK_AddTriangle(void* ptr, int v0, int v1, int v2)
{
	return SurfaceMesh3<EEK>::AddTriangle(ptr, v0, v1, v2);
}

int SurfaceMesh3_EEK_AddQuad(void* ptr, int v0, int v1, int v2, int v3)
{
	return SurfaceMesh3<EEK>::AddQuad(ptr, v0, v1, v2, v3);
}

BOOL SurfaceMesh3_EEK_HasGarbage(void* ptr)
{
	return SurfaceMesh3<EEK>::HasGarbage(ptr);
}

void SurfaceMesh3_EEK_CollectGarbage(void* ptr)
{
	SurfaceMesh3<EEK>::CollectGarbage(ptr);
}

void SurfaceMesh3_EEK_SetRecycleGarbage(void* ptr, BOOL collect)
{
	SurfaceMesh3<EEK>::SetRecycleGarbage(ptr, collect);
}

BOOL SurfaceMesh3_EEK_DoesRecycleGarbage(void* ptr)
{
	return SurfaceMesh3<EEK>::DoesRecycleGarbage(ptr);
}

int SurfaceMesh3_EEK_VertexDegree(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::VertexDegree(ptr, index);
}

int SurfaceMesh3_EEK_FaceDegree(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::FaceDegree(ptr, index);
}

BOOL SurfaceMesh3_EEK_VertexIsIsolated(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::VertexIsIsolated(ptr, index);
}

BOOL SurfaceMesh3_EEK_VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
{
	return SurfaceMesh3<EEK>::VertexIsBorder(ptr, index, check_all_incident_halfedges);
}

BOOL SurfaceMesh3_EEK_EdgeIsBorder(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::EdgeIsBorder(ptr, index);
}

int SurfaceMesh3_EEK_NextHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::NextHalfedge(ptr, index);
}

int SurfaceMesh3_EEK_PreviousHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::PreviousHalfedge(ptr, index);
}

int SurfaceMesh3_EEK_OppositeHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::OppositeHalfedge(ptr, index);
}

int SurfaceMesh3_EEK_SourceVertex(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::SourceVertex(ptr, index);
}

int SurfaceMesh3_EEK_TargetVertex(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::TargetVertex(ptr, index);
}

void SurfaceMesh3_EEK_RemoveVertex(void* ptr, int index)
{
	SurfaceMesh3<EEK>::RemoveVertex(ptr, index);
}

void SurfaceMesh3_EEK_RemoveEdge(void* ptr, int index)
{
	SurfaceMesh3<EEK>::RemoveEdge(ptr, index);
}

void SurfaceMesh3_EEK_RemoveFace(void* ptr, int index)
{
	SurfaceMesh3<EEK>::RemoveFace(ptr, index);
}

void SurfaceMesh3_EEK_RemoveProperyMaps(void* ptr)
{
	SurfaceMesh3<EEK>::RemoveProperyMaps(ptr);
}

BOOL SurfaceMesh3_EEK_IsVertexValid(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsVertexValid(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsEdgeValid(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsEdgeValid(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsHalfedgeValid(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsHalfedgeValid(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsFaceValid(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsFaceValid(ptr, index);
}

Point3d SurfaceMesh3_EEK_GetPoint(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::GetPoint(ptr, index);
}

void SurfaceMesh3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	SurfaceMesh3<EEK>::GetPoints(ptr, points, count);
}

void SurfaceMesh3_EEK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	SurfaceMesh3<EEK>::Transform(ptr, matrix);
}

BOOL SurfaceMesh3_EEK_IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
{
	return SurfaceMesh3<EEK>::IsVertexBorder(ptr, index, check_all_incident_halfedges);
}

BOOL SurfaceMesh3_EEK_IsHalfedgeBorder(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsHalfedgeBorder(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsEdgeBorder(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsEdgeBorder(ptr, index);
}

int SurfaceMesh3_EEK_BorderEdgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::BorderEdgeCount(ptr);
}

BOOL SurfaceMesh3_EEK_IsClosed(void* ptr)
{
	return SurfaceMesh3<EEK>::IsClosed(ptr);
}

BOOL SurfaceMesh3_EEK_CheckFaceVertexCount(void* ptr, int count)
{
	return SurfaceMesh3<EEK>::CheckFaceVertexCount(ptr, count);
}

FaceVertexCount SurfaceMesh3_EEK_GetFaceVertexCount(void* ptr)
{
	return SurfaceMesh3<EEK>::GetFaceVertexCount(ptr);
}

void SurfaceMesh3_EEK_CreateTriangleQuadMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int trianglesCount, int* quads, int quadsCount)
{
	SurfaceMesh3<EEK>::CreateTriangleQuadMesh(ptr, points, pointsCount, triangles, trianglesCount, quads, quadsCount);
}

void SurfaceMesh3_EEK_GetTriangleQuadIndices(void* ptr, int* triangles, int trianglesCount, int* quads, int quadsCount)
{
	SurfaceMesh3<EEK>::GetTriangleQuadIndices(ptr, triangles, trianglesCount, quads, quadsCount);
}






