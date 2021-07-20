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

void* Triangulation2_EEK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	return Triangulation2<EEK>::CreateFromPoints(points, startIndex, count);
}

void* Triangulation2_EEK_CreateFromPolygon(void* ptr)
{
	return Triangulation2<EEK>::CreateFromPolygon(ptr);
}

void Triangulation2_EEK_Clear(void* ptr)
{
	Triangulation2<EEK>::Clear(ptr);
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

void Triangulation2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Triangulation2<EEK>::GetPoints(ptr, points, startIndex, count);
}
