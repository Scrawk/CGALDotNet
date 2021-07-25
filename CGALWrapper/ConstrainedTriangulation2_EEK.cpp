#pragma once
#include "pch.h"
#include "Util.h"
#include "ConstrainedTriangulation2_EEK.h"
#include "ConstrainedTriangulation2.h"

void* ConstrainedTriangulation2_EEK_Create()
{
	return Util::Create<ConstrainedTriangulation2<EEK>>();
}

void ConstrainedTriangulation2_EEK_Release(void* ptr)
{
	Util::Release<ConstrainedTriangulation2<EEK>>(ptr);
}

void ConstrainedTriangulation2_EEK_Clear(void* ptr)
{
	ConstrainedTriangulation2<EEK>::Clear(ptr);
}

void* ConstrainedTriangulation2_EEK_Copy(void* ptr)
{
	return ConstrainedTriangulation2<EEK>::Copy(ptr);
}

BOOL ConstrainedTriangulation2_EEK_IsValid(void* ptr)
{
	return ConstrainedTriangulation2<EEK>::IsValid(ptr);
}

int ConstrainedTriangulation2_EEK_VertexCount(void* ptr)
{
	return ConstrainedTriangulation2<EEK>::VertexCount(ptr);
}

int ConstrainedTriangulation2_EEK_FaceCount(void* ptr)
{
	return ConstrainedTriangulation2<EEK>::FaceCount(ptr);
}

void ConstrainedTriangulation2_EEK_InsertPoint(void* ptr, Point2d point)
{
	ConstrainedTriangulation2<EEK>::InsertPoint(ptr, point);
}

void ConstrainedTriangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::InsertPoints(ptr, points, startIndex, count);
}

void ConstrainedTriangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr)
{
	ConstrainedTriangulation2<EEK>::InsertPolygon(triPtr, polyPtr);
}

void ConstrainedTriangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	ConstrainedTriangulation2<EEK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void ConstrainedTriangulation2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetPoints(ptr, points, startIndex, count);
}

void ConstrainedTriangulation2_EEK_GetIndices(void* ptr, int* indices, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetIndices(ptr, indices, startIndex, count);
}

BOOL ConstrainedTriangulation2_EEK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	return ConstrainedTriangulation2<EEK>::GetVertex(ptr, index, vertex);
}

void ConstrainedTriangulation2_EEK_GetVertices(void* ptr, TriVertex2* vertices, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetVertices(ptr, vertices, startIndex, count);
}

bool ConstrainedTriangulation2_EEK_GetFace(void* ptr, int index, TriFace2& face)
{
	return ConstrainedTriangulation2<EEK>::GetFace(ptr, index, face);
}

void ConstrainedTriangulation2_EEK_GetFaces(void* ptr, TriFace2* faces, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetFaces(ptr, faces, startIndex, count);
}

BOOL ConstrainedTriangulation2_EEK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
{
	return ConstrainedTriangulation2<EEK>::GetSegment(ptr, faceIndex, neighbourIndex, segment);
}

BOOL ConstrainedTriangulation2_EEK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
{
	return ConstrainedTriangulation2<EEK>::GetTriangle(ptr, faceIndex, triangle);
}

void ConstrainedTriangulation2_EEK_GetTriangles(void* ptr, Triangle2d* triangles, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetTriangles(ptr, triangles, startIndex, count);
}

BOOL ConstrainedTriangulation2_EEK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
{
	return ConstrainedTriangulation2<EEK>::GetCircumcenter(ptr, faceIndex, circumcenter);
}

void ConstrainedTriangulation2_EEK_GetCircumcenters(void* ptr, Point2d* circumcenters, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetCircumcenters(ptr, circumcenters, startIndex, count);
}

BOOL ConstrainedTriangulation2_EEK_LocateFace(void* ptr, Point2d point, TriFace2& face)
{
	return ConstrainedTriangulation2<EEK>::LocateFace(ptr, point, face);
}

BOOL ConstrainedTriangulation2_EEK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex)
{
	return ConstrainedTriangulation2<EEK>::MoveVertex(ptr, index, point, ifNoCollision, vertex);
}

BOOL ConstrainedTriangulation2_EEK_RemoveVertex(void* ptr, int index)
{
	return ConstrainedTriangulation2<EEK>::RemoveVertex(ptr, index);
}

BOOL ConstrainedTriangulation2_EEK_FlipEdge(void* ptr, int faceIndex, int neighbour)
{
	return ConstrainedTriangulation2<EEK>::FlipEdge(ptr, faceIndex, neighbour);
}

//Constrained only

int ConstrainedTriangulation2_EEK_ConstrainedEdgesCount(void* ptr)
{
	return ConstrainedTriangulation2<EEK>::ConstrainedEdgesCount(ptr);
}

BOOL ConstrainedTriangulation2_EEK_HasIncidentConstraints(void* ptr, int index)
{
	return ConstrainedTriangulation2<EEK>::HasIncidentConstraints(ptr, index);
}

int ConstrainedTriangulation2_EEK_IncidentConstraintCount(void* ptr, int index)
{
	return ConstrainedTriangulation2<EEK>::IncidentConstraintCount(ptr, index);
}

void ConstrainedTriangulation2_EEK_InsertSegmentConstraintFromPoints(void* ptr, Point2d a, Point2d b)
{
	ConstrainedTriangulation2<EEK>::InsertSegmentConstraint(ptr, a, b);
}

void ConstrainedTriangulation2_EEK_InsertSegmentConstraintFromVertices(void* ptr, int vertIndex1, int vertIndex2)
{
	ConstrainedTriangulation2<EEK>::InsertSegmentConstraint(ptr, vertIndex1, vertIndex2);
}

void ConstrainedTriangulation2_EEK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::InsertSegmentConstraints(ptr, segments, startIndex, count);
}

void ConstrainedTriangulation2_EEK_InsertPolygonConstraint(void* triPtr, void* polyPtr)
{
	ConstrainedTriangulation2<EEK>::InsertPolygonConstraint(triPtr, polyPtr);
}

void ConstrainedTriangulation2_EEK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr)
{
	ConstrainedTriangulation2<EEK>::InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
}

void ConstrainedTriangulation2_EEK_GetEdgeConstraints(void* ptr, TriEdgeConstraint2* constraints, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetConstraints(ptr, constraints, startIndex, count);
}

void ConstrainedTriangulation2_EEK_GetSegmentConstraints(void* ptr, Segment2d* constraints, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetConstraints(ptr, constraints, startIndex, count);
}

void ConstrainedTriangulation2_EEK_GetIncidentConstraints(void* ptr, int vertexIndex, TriEdgeConstraint2* constraints, int startIndex, int count)
{
	ConstrainedTriangulation2<EEK>::GetIncidentConstraints(ptr, vertexIndex, constraints, startIndex, count);
}

void ConstrainedTriangulation2_EEK_RemoveConstraint(void* ptr, int faceIndex, int neighbourIndex)
{
	ConstrainedTriangulation2<EEK>::RemoveConstraint(ptr, faceIndex, neighbourIndex);
}

void ConstrainedTriangulation2_EEK_RemoveIncidentConstraints(void* ptr, int vertexIndex)
{
	ConstrainedTriangulation2<EEK>::RemoveIncidentConstraints(ptr, vertexIndex);
}

int ConstrainedTriangulation2_EEK_GetPolygonIndices(void* ptrTri, void* polyPtr, int* indices, int startIndex, int count, CGAL::Orientation orientation)
{
	return ConstrainedTriangulation2<EEK>::GetPolygonIndices(ptrTri, polyPtr, indices, startIndex, count, orientation);
}

int ConstrainedTriangulation2_EEK_GetPolygonWithHolesIndices(void* ptrTri, void* pwhPtr, int* indices, int startIndex, int count, CGAL::Orientation orientation)
{
	return ConstrainedTriangulation2<EEK>::GetPolygonWithHolesIndices(ptrTri, pwhPtr, indices, startIndex, count, orientation);
}
