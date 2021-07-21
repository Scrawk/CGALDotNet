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

void Triangulation2_EEK_SetVertexIndices(void* ptr)
{
	Triangulation2<EEK>::SetVertexIndices(ptr);
}

void Triangulation2_EEK_SetFaceIndices(void* ptr)
{
	Triangulation2<EEK>::SetFaceIndices(ptr);
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

void Triangulation2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Triangulation2<EEK>::GetPoints(ptr, points, startIndex, count);
}

void Triangulation2_EEK_GetIndices(void* ptr, int* indices, int startIndex, int count)
{
	Triangulation2<EEK>::GetIndices(ptr, indices, startIndex, count);
}

int Triangulation2_EEK_GetPolygonIndices(void* triPtr, void* polyPtr, int* indices, int startIndex, int count, CGAL::Orientation orientation)
{
	return Triangulation2<EEK>::GetPolygonIndices(triPtr, polyPtr, indices, startIndex, count, orientation);
}

