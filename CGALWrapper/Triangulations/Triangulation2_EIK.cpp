#pragma once
#include "Triangulation2_EIK.h"
#include "Triangulation2.h"

#include <CGAL/Constrained_Delaunay_triangulation_2.h>
#include <CGAL/Triangulation_conformer_2.h>

void* Triangulation2_EIK_Create()
{
	return Triangulation2<EIK>::NewTriangulation2();
}

void Triangulation2_EIK_Release(void* ptr)
{
	Triangulation2<EIK>::DeleteTriangulation2(ptr);
}

void Triangulation2_EIK_Clear(void* ptr)
{
	Triangulation2<EIK>::Clear(ptr);
}

void* Triangulation2_EIK_Copy(void* ptr)
{
	return Triangulation2<EIK>::Copy(ptr);
}

void Triangulation2_EIK_SetIndices(void* ptr)
{
	Triangulation2<EIK>::SetIndices(ptr);
}

int Triangulation2_EIK_BuildStamp(void* ptr)
{
	return Triangulation2<EIK>::BuildStamp(ptr);
}

BOOL Triangulation2_EIK_IsValid(void* ptr, int level)
{
	return Triangulation2<EIK>::IsValid(ptr, level);
}

int Triangulation2_EIK_VertexCount(void* ptr)
{
	return Triangulation2<EIK>::VertexCount(ptr);
}

int Triangulation2_EIK_FaceCount(void* ptr)
{
	return Triangulation2<EIK>::FaceCount(ptr);
}

void Triangulation2_EIK_InsertPoint(void* ptr, Point2d point)
{
	Triangulation2<EIK>::InsertPoint(ptr, point);
}

void Triangulation2_EIK_InsertPoints(void* ptr, Point2d* points, int count)
{
	Triangulation2<EIK>::InsertPoints(ptr, points, count);
}

void Triangulation2_EIK_InsertPolygon(void* triPtr, void* polyPtr)
{
	Triangulation2<EIK>::InsertPolygon(triPtr, polyPtr);
}

void Triangulation2_EIK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	Triangulation2<EIK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void Triangulation2_EIK_GetPoints(void* ptr, Point2d* points, int count)
{
	Triangulation2<EIK>::GetPoints(ptr, points, count);
}

void Triangulation2_EIK_GetIndices(void* ptr, int* indices, int count)
{
	Triangulation2<EIK>::GetIndices(ptr, indices, count);
}

BOOL Triangulation2_EIK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	return Triangulation2<EIK>::GetVertex(ptr, index, vertex);
}

void Triangulation2_EIK_GetVertices(void* ptr, TriVertex2* vertices, int count)
{
	Triangulation2<EIK>::GetVertices(ptr, vertices, count);
}

bool Triangulation2_EIK_GetFace(void* ptr, int index, TriFace2& face)
{
	return Triangulation2<EIK>::GetFace(ptr, index, face);
}

void Triangulation2_EIK_GetFaces(void* ptr, TriFace2* faces, int count)
{
	Triangulation2<EIK>::GetFaces(ptr, faces, count);
}

BOOL Triangulation2_EIK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
{
	return Triangulation2<EIK>::GetSegment(ptr, faceIndex, neighbourIndex, segment);
}

BOOL Triangulation2_EIK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
{
	return Triangulation2<EIK>::GetTriangle(ptr, faceIndex, triangle);
}

void Triangulation2_EIK_GetTriangles(void* ptr, Triangle2d* triangles, int count)
{
	Triangulation2<EIK>::GetTriangles(ptr, triangles, count);
}

BOOL Triangulation2_EIK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
{
	return Triangulation2<EIK>::GetCircumcenter(ptr, faceIndex, circumcenter);
}

void Triangulation2_EIK_GetCircumcenters(void* ptr, Point2d* circumcenters, int count)
{
	Triangulation2<EIK>::GetCircumcenters(ptr, circumcenters, count);
}

int Triangulation2_EIK_NeighbourIndex(void* ptr, int faceIndex, int index)
{
	return Triangulation2<EIK>::NeighbourIndex(ptr, faceIndex, index);
}

BOOL Triangulation2_EIK_LocateFace(void* ptr, Point2d point, TriFace2& face)
{
	return Triangulation2<EIK>::LocateFace(ptr, point, face);
}

BOOL Triangulation2_EIK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex)
{
	return Triangulation2<EIK>::MoveVertex(ptr, index, point, ifNoCollision, vertex);
}

BOOL Triangulation2_EIK_RemoveVertex(void* ptr, int index)
{
	return Triangulation2<EIK>::RemoveVertex(ptr, index);
}

BOOL Triangulation2_EIK_FlipEdge(void* ptr, int faceIndex, int neighbour)
{
	return Triangulation2<EIK>::FlipEdge(ptr, faceIndex, neighbour);
}

void Triangulation2_EIK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	Triangulation2<EIK>::Transform(ptr, translation, rotation, scale);
}








