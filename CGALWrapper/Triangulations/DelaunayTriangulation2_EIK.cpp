#pragma once

#include "DelaunayTriangulation2_EIK.h"
#include "DelaunayTriangulation2.h"

void* DelaunayTriangulation2_EIK_Create()
{
	return DelaunayTriangulation2<EIK>::NewTriangulation2();
}

void DelaunayTriangulation2_EIK_Release(void* ptr)
{
	DelaunayTriangulation2<EIK>::DeleteTriangulation2(ptr);
}

void DelaunayTriangulation2_EIK_Clear(void* ptr)
{
	DelaunayTriangulation2<EIK>::Clear(ptr);
}

void* DelaunayTriangulation2_EIK_Copy(void* ptr)
{
	return DelaunayTriangulation2<EIK>::Copy(ptr);
}

void DelaunayTriangulation_EIK_SetIndices(void* ptr)
{
	DelaunayTriangulation2<EIK>::SetIndices(ptr);
}

int DelaunayTriangulation2_EIK_BuildStamp(void* ptr)
{
	return DelaunayTriangulation2<EIK>::BuildStamp(ptr);
}

BOOL DelaunayTriangulation2_EIK_IsValid(void* ptr, int level)
{
	return DelaunayTriangulation2<EIK>::IsValid(ptr, level);
}

int DelaunayTriangulation2_EIK_VertexCount(void* ptr)
{
	return DelaunayTriangulation2<EIK>::VertexCount(ptr);
}

int DelaunayTriangulation2_EIK_FaceCount(void* ptr)
{
	return DelaunayTriangulation2<EIK>::FaceCount(ptr);
}

void DelaunayTriangulation2_EIK_InsertPoint(void* ptr, Point2d point)
{
	DelaunayTriangulation2<EIK>::InsertPoint(ptr, point);
}

void DelaunayTriangulation2_EIK_InsertPoints(void* ptr, Point2d* points, int count)
{
	DelaunayTriangulation2<EIK>::InsertPoints(ptr, points, count);
}

void DelaunayTriangulation2_EIK_InsertPolygon(void* triPtr, void* polyPtr)
{
	DelaunayTriangulation2<EIK>::InsertPolygon(triPtr, polyPtr);
}

void DelaunayTriangulation2_EIK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	DelaunayTriangulation2<EIK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void DelaunayTriangulation2_EIK_GetPoints(void* ptr, Point2d* points, int count)
{
	DelaunayTriangulation2<EIK>::GetPoints(ptr, points, count);
}

void DelaunayTriangulation2_EIK_GetIndices(void* ptr, int* indices, int count)
{
	DelaunayTriangulation2<EIK>::GetIndices(ptr, indices, count);
}

BOOL DelaunayTriangulation2_EIK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	return DelaunayTriangulation2<EIK>::GetVertex(ptr, index, vertex);
}

void DelaunayTriangulation2_EIK_GetVertices(void* ptr, TriVertex2* vertices, int count)
{
	DelaunayTriangulation2<EIK>::GetVertices(ptr, vertices, count);
}

bool DelaunayTriangulation2_EIK_GetFace(void* ptr, int index, TriFace2& face)
{
	return DelaunayTriangulation2<EIK>::GetFace(ptr, index, face);
}

void DelaunayTriangulation2_EIK_GetFaces(void* ptr, TriFace2* faces, int count)
{
	DelaunayTriangulation2<EIK>::GetFaces(ptr, faces, count);
}

BOOL DelaunayTriangulation2_EIK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
{
	return DelaunayTriangulation2<EIK>::GetSegment(ptr, faceIndex, neighbourIndex, segment);
}

BOOL DelaunayTriangulation2_EIK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
{
	return DelaunayTriangulation2<EIK>::GetTriangle(ptr, faceIndex, triangle);
}

void DelaunayTriangulation2_EIK_GetTriangles(void* ptr, Triangle2d* triangles, int count)
{
	DelaunayTriangulation2<EIK>::GetTriangles(ptr, triangles, count);
}

BOOL DelaunayTriangulation2_EIK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
{
	return DelaunayTriangulation2<EIK>::GetCircumcenter(ptr, faceIndex, circumcenter);
}

void DelaunayTriangulation2_EIK_GetCircumcenters(void* ptr, Point2d* circumcenters, int count)
{
	DelaunayTriangulation2<EIK>::GetCircumcenters(ptr, circumcenters, count);
}

int DelaunayTriangulation2_EIK_NeighbourIndex(void* ptr, int faceIndex, int index)
{
	return DelaunayTriangulation2<EIK>::NeighbourIndex(ptr, faceIndex, index);
}

BOOL DelaunayTriangulation2_EIK_LocateFace(void* ptr, Point2d point, TriFace2& face)
{
	return DelaunayTriangulation2<EIK>::LocateFace(ptr, point, face);
}

BOOL DelaunayTriangulation2_EIK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex)
{
	return DelaunayTriangulation2<EIK>::MoveVertex(ptr, index, point, ifNoCollision, vertex);
}

BOOL DelaunayTriangulation2_EIK_RemoveVertex(void* ptr, int index)
{
	return DelaunayTriangulation2<EIK>::RemoveVertex(ptr, index);
}

BOOL DelaunayTriangulation2_EIK_FlipEdge(void* ptr, int faceIndex, int neighbour)
{
	return DelaunayTriangulation2<EIK>::FlipEdge(ptr, faceIndex, neighbour);
}

void DelaunayTriangulation2_EIK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	DelaunayTriangulation2<EIK>::Transform(ptr, translation, rotation, scale);
}

//Delaunay only

int DelaunayTriangulation2_EIK_VoronoiSegmentCount(void* ptr)
{
	return DelaunayTriangulation2<EIK>::VoronoiSegmentCount(ptr);
}

int DelaunayTriangulation2_EIK_VoronoiRayCount(void* ptr)
{
	return DelaunayTriangulation2<EIK>::VoronoiRayCount(ptr);
}

void DelaunayTriangulation2_EIK_VoronoiCount(void* ptr, int& numSegments, int& numRays)
{
	DelaunayTriangulation2<EIK>::VoronoiCount(ptr, numSegments, numRays);
}

void DelaunayTriangulation2_EIK_GetVoronoiSegments(void* ptr, Segment2d* segments, int count)
{
	DelaunayTriangulation2<EIK>::GetVoronoiSegments(ptr, segments, count);
}

void DelaunayTriangulation2_EIK_GetVoronoiRays(void* ptr, Ray2d* rays, int count)
{
	DelaunayTriangulation2<EIK>::GetVoronoiRays(ptr, rays, count);
}