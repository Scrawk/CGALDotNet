#pragma once

#include "DelaunayTriangulation2_EEK.h"
#include "DelaunayTriangulation2.h"

void* DelaunayTriangulation2_EEK_Create()
{
	return DelaunayTriangulation2<EEK>::NewTriangulation2();
}

void DelaunayTriangulation2_EEK_Release(void* ptr)
{
	DelaunayTriangulation2<EEK>::DeleteTriangulation2(ptr);
}

void DelaunayTriangulation2_EEK_Clear(void* ptr)
{
	DelaunayTriangulation2<EEK>::Clear(ptr);
}

void* DelaunayTriangulation2_EEK_Copy(void* ptr)
{
	return DelaunayTriangulation2<EEK>::Copy(ptr);
}

void DelaunayTriangulation_EEK_SetIndices(void* ptr)
{
	DelaunayTriangulation2<EEK>::SetIndices(ptr);
}

int DelaunayTriangulation2_EEK_BuildStamp(void* ptr)
{
	return DelaunayTriangulation2<EEK>::BuildStamp(ptr);
}

BOOL DelaunayTriangulation2_EEK_IsValid(void* ptr, int level)
{
	return DelaunayTriangulation2<EEK>::IsValid(ptr, level);
}

int DelaunayTriangulation2_EEK_VertexCount(void* ptr)
{
	return DelaunayTriangulation2<EEK>::VertexCount(ptr);
}

int DelaunayTriangulation2_EEK_FaceCount(void* ptr)
{
	return DelaunayTriangulation2<EEK>::FaceCount(ptr);
}

void DelaunayTriangulation2_EEK_InsertPoint(void* ptr, Point2d point)
{
	DelaunayTriangulation2<EEK>::InsertPoint(ptr, point);
}

void DelaunayTriangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::InsertPoints(ptr, points, startIndex, count);
}

void DelaunayTriangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr)
{
	DelaunayTriangulation2<EEK>::InsertPolygon(triPtr, polyPtr);
}

void DelaunayTriangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	DelaunayTriangulation2<EEK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void DelaunayTriangulation2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::GetPoints(ptr, points, startIndex, count);
}

void DelaunayTriangulation2_EEK_GetIndices(void* ptr, int* indices, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::GetIndices(ptr, indices, startIndex, count);
}

BOOL DelaunayTriangulation2_EEK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	return DelaunayTriangulation2<EEK>::GetVertex(ptr, index, vertex);
}

void DelaunayTriangulation2_EEK_GetVertices(void* ptr, TriVertex2* vertices, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::GetVertices(ptr, vertices, startIndex, count);
}

bool DelaunayTriangulation2_EEK_GetFace(void* ptr, int index, TriFace2& face)
{
	return DelaunayTriangulation2<EEK>::GetFace(ptr, index, face);
}

void DelaunayTriangulation2_EEK_GetFaces(void* ptr, TriFace2* faces, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::GetFaces(ptr, faces, startIndex, count);
}

BOOL DelaunayTriangulation2_EEK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
{
	return DelaunayTriangulation2<EEK>::GetSegment(ptr, faceIndex, neighbourIndex, segment);
}

BOOL DelaunayTriangulation2_EEK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
{
	return DelaunayTriangulation2<EEK>::GetTriangle(ptr, faceIndex, triangle);
}

void DelaunayTriangulation2_EEK_GetTriangles(void* ptr, Triangle2d* triangles, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::GetTriangles(ptr, triangles, startIndex, count);
}

BOOL DelaunayTriangulation2_EEK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
{
	return DelaunayTriangulation2<EEK>::GetCircumcenter(ptr, faceIndex, circumcenter);
}

void DelaunayTriangulation2_EEK_GetCircumcenters(void* ptr, Point2d* circumcenters, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::GetCircumcenters(ptr, circumcenters, startIndex, count);
}

int DelaunayTriangulation2_EEK_NeighbourIndex(void* ptr, int faceIndex, int index)
{
	return DelaunayTriangulation2<EEK>::NeighbourIndex(ptr, faceIndex, index);
}

BOOL DelaunayTriangulation2_EEK_LocateFace(void* ptr, Point2d point, TriFace2& face)
{
	return DelaunayTriangulation2<EEK>::LocateFace(ptr, point, face);
}

BOOL DelaunayTriangulation2_EEK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex)
{
	return DelaunayTriangulation2<EEK>::MoveVertex(ptr, index, point, ifNoCollision, vertex);
}

BOOL DelaunayTriangulation2_EEK_RemoveVertex(void* ptr, int index)
{
	return DelaunayTriangulation2<EEK>::RemoveVertex(ptr, index);
}

BOOL DelaunayTriangulation2_EEK_FlipEdge(void* ptr, int faceIndex, int neighbour)
{
	return DelaunayTriangulation2<EEK>::FlipEdge(ptr, faceIndex, neighbour);
}

//Delaunay only

int DelaunayTriangulation2_EEK_VoronoiSegmentCount(void* ptr)
{
	return DelaunayTriangulation2<EEK>::VoronoiSegmentCount(ptr);
}

int DelaunayTriangulation2_EEK_VoronoiRayCount(void* ptr)
{
	return DelaunayTriangulation2<EEK>::VoronoiRayCount(ptr);
}

void DelaunayTriangulation2_EEK_VoronoiCount(void* ptr, int& numSegments, int& numRays)
{
	DelaunayTriangulation2<EEK>::VoronoiCount(ptr, numSegments, numRays);
}

void DelaunayTriangulation2_EEK_GetVoronoiSegments(void* ptr, Segment2d* segments, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::GetVoronoiSegments(ptr, segments, startIndex, count);
}

void DelaunayTriangulation2_EEK_GetVoronoiRays(void* ptr, Ray2d* rays, int startIndex, int count)
{
	DelaunayTriangulation2<EEK>::GetVoronoiRays(ptr, rays, startIndex, count);
}