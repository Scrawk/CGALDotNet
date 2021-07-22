#pragma once
#include "pch.h"
#include "Util.h"
#include "Triangulation2_EEK.h"
#include "Triangulation2.h"

void* Triangulation2_EEK_Create()
{
	return Util::Create<Triangulation2<EEK>>();
}

void Triangulation2_EEK_Release(void* ptr)
{
	Util::Release<Triangulation2<EEK>>(ptr);
}

void Triangulation2_EEK_Clear(void* ptr)
{
	Triangulation2<EEK>::Clear(ptr);
}

void* Triangulation2_EEK_Copy(void* ptr)
{
	return Triangulation2<EEK>::Copy(ptr);
}

BOOL Triangulation2_EEK_IsValid(void* ptr)
{
	return Triangulation2<EEK>::IsValid(ptr);
}

int Triangulation2_EEK_VertexCount(void* ptr)
{
	return Triangulation2<EEK>::VertexCount(ptr);
}

int Triangulation2_EEK_FaceCount(void* ptr)
{
	return Triangulation2<EEK>::FaceCount(ptr);
}

void Triangulation2_EEK_InsertPoint(void* ptr, Point2d point)
{
	Triangulation2<EEK>::InsertPoint(ptr, point);
}

void Triangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Triangulation2<EEK>::InsertPoints(ptr, points, startIndex, count);
}

void Triangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr)
{
	Triangulation2<EEK>::InsertPolygon(triPtr, polyPtr);
}

void Triangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	Triangulation2<EEK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void Triangulation2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Triangulation2<EEK>::GetPoints(ptr, points, startIndex, count);
}

void Triangulation2_EEK_GetIndices(void* ptr, int* indices, int startIndex, int count)
{
	Triangulation2<EEK>::GetIndices(ptr, indices, startIndex, count);
}

BOOL Triangulation2_EEK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	return Triangulation2<EEK>::GetVertex(ptr, index, vertex);
}

void Triangulation2_EEK_GetVertices(void* ptr, TriVertex2* vertices, int startIndex, int count)
{
	Triangulation2<EEK>::GetVertices(ptr, vertices, startIndex, count);
}

bool Triangulation2_EEK_GetFace(void* ptr, int index, TriFace2& face)
{
	return Triangulation2<EEK>::GetFace(ptr, index, face);
}

void Triangulation2_EEK_GetFaces(void* ptr, TriFace2* faces, int startIndex, int count)
{
	Triangulation2<EEK>::GetFaces(ptr, faces, startIndex, count);
}

BOOL Triangulation2_EEK_LocateFace(void* ptr, Point2d point, TriFace2& face)
{
	return Triangulation2<EEK>::LocateFace(ptr, point, face);
}

BOOL Triangulation2_EEK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex)
{
	return Triangulation2<EEK>::MoveVertex(ptr, index, point, ifNoCollision, vertex);
}

BOOL Triangulation2_EEK_RemoveVertex(void* ptr, int index)
{
	return Triangulation2<EEK>::RemoveVertex(ptr, index);
}

BOOL Triangulation2_EEK_FlipEdge(void* ptr, int faceIndex, int neighbour)
{
	return Triangulation2<EEK>::FlipEdge(ptr, faceIndex, neighbour);
}



