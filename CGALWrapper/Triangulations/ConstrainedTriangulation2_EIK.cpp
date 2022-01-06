#pragma once

#include "ConstrainedTriangulation2_EIK.h"
#include "ConstrainedTriangulation2.h"
#include <CGAL/Aff_transformation_2.h>

void* ConstrainedTriangulation2_EIK_Create()
{
	return ConstrainedTriangulation2<EIK>::NewTriangulation2();
}

void ConstrainedTriangulation2_EIK_Release(void* ptr)
{
	ConstrainedTriangulation2<EIK>::DeleteTriangulation2(ptr);
}

void ConstrainedTriangulation2_EIK_Clear(void* ptr)
{
	ConstrainedTriangulation2<EIK>::Clear(ptr);
}

void* ConstrainedTriangulation2_EIK_Copy(void* ptr)
{
	return ConstrainedTriangulation2<EIK>::Copy(ptr);
}

void ConstrainedTriangulation_EIK_SetIndices(void* ptr)
{
	ConstrainedTriangulation2<EIK>::SetIndices(ptr);
}

int ConstrainedTriangulation2_EIK_BuildStamp(void* ptr)
{
	return ConstrainedTriangulation2<EIK>::BuildStamp(ptr);
}

BOOL ConstrainedTriangulation2_EIK_IsValid(void* ptr, int level)
{
	return ConstrainedTriangulation2<EIK>::IsValid(ptr, level);
}

int ConstrainedTriangulation2_EIK_VertexCount(void* ptr)
{
	return ConstrainedTriangulation2<EIK>::VertexCount(ptr);
}

int ConstrainedTriangulation2_EIK_FaceCount(void* ptr)
{
	return ConstrainedTriangulation2<EIK>::FaceCount(ptr);
}

void ConstrainedTriangulation2_EIK_InsertPoint(void* ptr, Point2d point)
{
	ConstrainedTriangulation2<EIK>::InsertPoint(ptr, point);
}

void ConstrainedTriangulation2_EIK_InsertPoints(void* ptr, Point2d* points, int count)
{
	ConstrainedTriangulation2<EIK>::InsertPoints(ptr, points, count);
}

void ConstrainedTriangulation2_EIK_InsertPolygon(void* triPtr, void* polyPtr)
{
	ConstrainedTriangulation2<EIK>::InsertPolygon(triPtr, polyPtr);
}

void ConstrainedTriangulation2_EIK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	ConstrainedTriangulation2<EIK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void ConstrainedTriangulation2_EIK_GetPoints(void* ptr, Point2d* points, int count)
{
	ConstrainedTriangulation2<EIK>::GetPoints(ptr, points, count);
}

void ConstrainedTriangulation2_EIK_GetIndices(void* ptr, int* indices, int count)
{
	ConstrainedTriangulation2<EIK>::GetIndices(ptr, indices, count);
}

BOOL ConstrainedTriangulation2_EIK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	return ConstrainedTriangulation2<EIK>::GetVertex(ptr, index, vertex);
}

void ConstrainedTriangulation2_EIK_GetVertices(void* ptr, TriVertex2* vertices, int count)
{
	ConstrainedTriangulation2<EIK>::GetVertices(ptr, vertices, count);
}

bool ConstrainedTriangulation2_EIK_GetFace(void* ptr, int index, TriFace2& face)
{
	return ConstrainedTriangulation2<EIK>::GetFace(ptr, index, face);
}

void ConstrainedTriangulation2_EIK_GetFaces(void* ptr, TriFace2* faces, int count)
{
	ConstrainedTriangulation2<EIK>::GetFaces(ptr, faces, count);
}

BOOL ConstrainedTriangulation2_EIK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
{
	return ConstrainedTriangulation2<EIK>::GetSegment(ptr, faceIndex, neighbourIndex, segment);
}

BOOL ConstrainedTriangulation2_EIK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
{
	return ConstrainedTriangulation2<EIK>::GetTriangle(ptr, faceIndex, triangle);
}

void ConstrainedTriangulation2_EIK_GetTriangles(void* ptr, Triangle2d* triangles, int count)
{
	ConstrainedTriangulation2<EIK>::GetTriangles(ptr, triangles, count);
}

BOOL ConstrainedTriangulation2_EIK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
{
	return ConstrainedTriangulation2<EIK>::GetCircumcenter(ptr, faceIndex, circumcenter);
}

void ConstrainedTriangulation2_EIK_GetCircumcenters(void* ptr, Point2d* circumcenters, int count)
{
	ConstrainedTriangulation2<EIK>::GetCircumcenters(ptr, circumcenters, count);
}

int ConstrainedTriangulation2_EIK_NeighbourIndex(void* ptr, int faceIndex, int index)
{
	return ConstrainedTriangulation2<EIK>::NeighbourIndex(ptr, faceIndex, index);
}

BOOL ConstrainedTriangulation2_EIK_LocateFace(void* ptr, Point2d point, TriFace2& face)
{
	return ConstrainedTriangulation2<EIK>::LocateFace(ptr, point, face);
}

BOOL ConstrainedTriangulation2_EIK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex)
{
	return ConstrainedTriangulation2<EIK>::MoveVertex(ptr, index, point, ifNoCollision, vertex);
}

BOOL ConstrainedTriangulation2_EIK_RemoveVertex(void* ptr, int index)
{
	return ConstrainedTriangulation2<EIK>::RemoveVertex(ptr, index);
}

BOOL ConstrainedTriangulation2_EIK_FlipEdge(void* ptr, int faceIndex, int neighbour)
{
	return ConstrainedTriangulation2<EIK>::FlipEdge(ptr, faceIndex, neighbour);
}

void ConstrainedTriangulation2_EIK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	ConstrainedTriangulation2<EIK>::Transform(ptr, translation, rotation, scale);
}

//Constrained only

int ConstrainedTriangulation2_EIK_ConstrainedEdgesCount(void* ptr)
{
	return ConstrainedTriangulation2<EIK>::ConstrainedEdgesCount(ptr);
}

BOOL ConstrainedTriangulation2_EIK_HasIncidentConstraints(void* ptr, int index)
{
	return ConstrainedTriangulation2<EIK>::HasIncidentConstraints(ptr, index);
}

int ConstrainedTriangulation2_EIK_IncidentConstraintCount(void* ptr, int index)
{
	return ConstrainedTriangulation2<EIK>::IncidentConstraintCount(ptr, index);
}

void ConstrainedTriangulation2_EIK_InsertSegmentConstraintFromPoints(void* ptr, Point2d a, Point2d b)
{
	ConstrainedTriangulation2<EIK>::InsertSegmentConstraint(ptr, a, b);
}

void ConstrainedTriangulation2_EIK_InsertSegmentConstraintFromVertices(void* ptr, int vertIndex1, int vertIndex2)
{
	ConstrainedTriangulation2<EIK>::InsertSegmentConstraint(ptr, vertIndex1, vertIndex2);
}

void ConstrainedTriangulation2_EIK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int count)
{
	ConstrainedTriangulation2<EIK>::InsertSegmentConstraints(ptr, segments, count);
}

void ConstrainedTriangulation2_EIK_InsertPolygonConstraint(void* triPtr, void* polyPtr)
{
	ConstrainedTriangulation2<EIK>::InsertPolygonConstraint(triPtr, polyPtr);
}

void ConstrainedTriangulation2_EIK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr)
{
	ConstrainedTriangulation2<EIK>::InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
}

void ConstrainedTriangulation2_EIK_GetEdgeConstraints(void* ptr, TriEdge2* constraints, int count)
{
	ConstrainedTriangulation2<EIK>::GetConstraints(ptr, constraints, count);
}

void ConstrainedTriangulation2_EIK_GetSegmentConstraints(void* ptr, Segment2d* constraints, int count)
{
	ConstrainedTriangulation2<EIK>::GetConstraints(ptr, constraints, count);
}

void ConstrainedTriangulation2_EIK_GetIncidentConstraints(void* ptr, int vertexIndex, TriEdge2* constraints, int count)
{
	ConstrainedTriangulation2<EIK>::GetIncidentConstraints(ptr, vertexIndex, constraints, count);
}

void ConstrainedTriangulation2_EIK_RemoveConstraint(void* ptr, int faceIndex, int neighbourIndex)
{
	ConstrainedTriangulation2<EIK>::RemoveConstraint(ptr, faceIndex, neighbourIndex);
}

void ConstrainedTriangulation2_EIK_RemoveIncidentConstraints(void* ptr, int vertexIndex)
{
	ConstrainedTriangulation2<EIK>::RemoveIncidentConstraints(ptr, vertexIndex);
}

int ConstrainedTriangulation2_EIK_MarkDomains(void* ptr, int* indices, int count)
{
	return ConstrainedTriangulation2<EIK>::MarkDomains(ptr, indices, count);
}


