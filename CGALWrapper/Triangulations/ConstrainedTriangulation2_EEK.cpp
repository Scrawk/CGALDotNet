#pragma once

#include "ConstrainedTriangulation2_EEK.h"
#include "ConstrainedTriangulation2.h"
#include <CGAL/Aff_transformation_2.h>

void* ConstrainedTriangulation2_EEK_Create()
{
	return ConstrainedTriangulation2<EEK>::NewTriangulation2();
}

void ConstrainedTriangulation2_EEK_Release(void* ptr)
{
	ConstrainedTriangulation2<EEK>::DeleteTriangulation2(ptr);
}

void ConstrainedTriangulation2_EEK_Clear(void* ptr)
{
	ConstrainedTriangulation2<EEK>::Clear(ptr);
}

void* ConstrainedTriangulation2_EEK_Copy(void* ptr)
{
	return ConstrainedTriangulation2<EEK>::Copy(ptr);
}

void ConstrainedTriangulation_EEK_SetIndices(void* ptr)
{
	ConstrainedTriangulation2<EEK>::SetIndices(ptr);
}

int ConstrainedTriangulation2_EEK_BuildStamp(void* ptr)
{
	return ConstrainedTriangulation2<EEK>::BuildStamp(ptr);
}

BOOL ConstrainedTriangulation2_EEK_IsValid(void* ptr, int level)
{
	return ConstrainedTriangulation2<EEK>::IsValid(ptr, level);
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

void ConstrainedTriangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int count)
{
	ConstrainedTriangulation2<EEK>::InsertPoints(ptr, points, count);
}

void ConstrainedTriangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr)
{
	ConstrainedTriangulation2<EEK>::InsertPolygon(triPtr, polyPtr);
}

void ConstrainedTriangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	ConstrainedTriangulation2<EEK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void ConstrainedTriangulation2_EEK_GetPoints(void* ptr, Point2d* points, int count)
{
	ConstrainedTriangulation2<EEK>::GetPoints(ptr, points, count);
}

void ConstrainedTriangulation2_EEK_GetIndices(void* ptr, int* indices, int count)
{
	ConstrainedTriangulation2<EEK>::GetIndices(ptr, indices, count);
}

BOOL ConstrainedTriangulation2_EEK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	return ConstrainedTriangulation2<EEK>::GetVertex(ptr, index, vertex);
}

void ConstrainedTriangulation2_EEK_GetVertices(void* ptr, TriVertex2* vertices, int count)
{
	ConstrainedTriangulation2<EEK>::GetVertices(ptr, vertices, count);
}

bool ConstrainedTriangulation2_EEK_GetFace(void* ptr, int index, TriFace2& face)
{
	return ConstrainedTriangulation2<EEK>::GetFace(ptr, index, face);
}

void ConstrainedTriangulation2_EEK_GetFaces(void* ptr, TriFace2* faces, int count)
{
	ConstrainedTriangulation2<EEK>::GetFaces(ptr, faces, count);
}

BOOL ConstrainedTriangulation2_EEK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
{
	return ConstrainedTriangulation2<EEK>::GetSegment(ptr, faceIndex, neighbourIndex, segment);
}

BOOL ConstrainedTriangulation2_EEK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
{
	return ConstrainedTriangulation2<EEK>::GetTriangle(ptr, faceIndex, triangle);
}

void ConstrainedTriangulation2_EEK_GetTriangles(void* ptr, Triangle2d* triangles, int count)
{
	ConstrainedTriangulation2<EEK>::GetTriangles(ptr, triangles, count);
}

BOOL ConstrainedTriangulation2_EEK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
{
	return ConstrainedTriangulation2<EEK>::GetCircumcenter(ptr, faceIndex, circumcenter);
}

void ConstrainedTriangulation2_EEK_GetCircumcenters(void* ptr, Point2d* circumcenters, int count)
{
	ConstrainedTriangulation2<EEK>::GetCircumcenters(ptr, circumcenters, count);
}

int ConstrainedTriangulation2_EEK_NeighbourIndex(void* ptr, int faceIndex, int index)
{
	return ConstrainedTriangulation2<EEK>::NeighbourIndex(ptr, faceIndex, index);
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

void ConstrainedTriangulation2_EEK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	ConstrainedTriangulation2<EEK>::Transform(ptr, translation, rotation, scale);
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

void ConstrainedTriangulation2_EEK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int count)
{
	ConstrainedTriangulation2<EEK>::InsertSegmentConstraints(ptr, segments, count);
}

void ConstrainedTriangulation2_EEK_InsertPolygonConstraint(void* triPtr, void* polyPtr)
{
	ConstrainedTriangulation2<EEK>::InsertPolygonConstraint(triPtr, polyPtr);
}

void ConstrainedTriangulation2_EEK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr)
{
	ConstrainedTriangulation2<EEK>::InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
}

void ConstrainedTriangulation2_EEK_GetEdgeConstraints(void* ptr, TriEdge2* constraints, int count)
{
	ConstrainedTriangulation2<EEK>::GetConstraints(ptr, constraints, count);
}

void ConstrainedTriangulation2_EEK_GetSegmentConstraints(void* ptr, Segment2d* constraints, int count)
{
	ConstrainedTriangulation2<EEK>::GetConstraints(ptr, constraints, count);
}

void ConstrainedTriangulation2_EEK_GetIncidentConstraints(void* ptr, int vertexIndex, TriEdge2* constraints, int count)
{
	ConstrainedTriangulation2<EEK>::GetIncidentConstraints(ptr, vertexIndex, constraints, count);
}

void ConstrainedTriangulation2_EEK_RemoveConstraint(void* ptr, int faceIndex, int neighbourIndex)
{
	ConstrainedTriangulation2<EEK>::RemoveConstraint(ptr, faceIndex, neighbourIndex);
}

void ConstrainedTriangulation2_EEK_RemoveIncidentConstraints(void* ptr, int vertexIndex)
{
	ConstrainedTriangulation2<EEK>::RemoveIncidentConstraints(ptr, vertexIndex);
}

int ConstrainedTriangulation2_EEK_MarkDomains(void* ptr, int* indices, int count)
{
	return ConstrainedTriangulation2<EEK>::MarkDomains(ptr, indices, count);
}


