#pragma once
#include "Triangulation3_EEK.h"
#include "Triangulation3.h"

void* Triangulation3_EEK_Create()
{
	return Triangulation3<EEK>::NewTriangulation3();
}

void Triangulation3_EEK_Release(void* ptr)
{
	Triangulation3<EEK>::DeleteTriangulation3(ptr);
}

void Triangulation3_EEK_Clear(void* ptr)
{
	Triangulation3<EEK>::Clear(ptr);
}

void* Triangulation3_EEK_Copy(void* ptr)
{
	return Triangulation3<EEK>::Copy(ptr);
}

int Triangulation3_EEK_Dimension(void* ptr)
{
	return Triangulation3<EEK>::Dimension(ptr);
}

BOOL Triangulation3_EEK_IsValid(void* ptr)
{
	return Triangulation3<EEK>::IsValid(ptr);
}

int Triangulation3_EEK_VertexCount(void* ptr)
{
	return Triangulation3<EEK>::VertexCount(ptr);
}

int Triangulation3_EEK_CellCount(void* ptr)
{
	return Triangulation3<EEK>::CellCount(ptr);
}

int Triangulation3_EEK_FiniteCellCount(void* ptr)
{
	return Triangulation3<EEK>::FiniteCellCount(ptr);
}

int Triangulation3_EEK_EdgeCount(void* ptr)
{
	return Triangulation3<EEK>::EdgeCount(ptr);
}

int Triangulation3_EEK_FiniteEdgeCount(void* ptr)
{
	return Triangulation3<EEK>::FiniteEdgeCount(ptr);
}

int Triangulation3_EEK_FacetCount(void* ptr)
{
	return Triangulation3<EEK>::FacetCount(ptr);
}

int Triangulation3_EEK_FiniteFacetCount(void* ptr)
{
	return Triangulation3<EEK>::FiniteFacetCount(ptr);
}

void Triangulation3_EEK_InsertPoint(void* ptr, const Point3d& point)
{
	Triangulation3<EEK>::InsertPoint(ptr, point);
}

void Triangulation3_EEK_InsertPoints(void* ptr, Point3d* points, int count)
{
	Triangulation3<EEK>::InsertPoints(ptr, points, count);
}

void Triangulation3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	Triangulation3<EEK>::GetPoints(ptr, points, count);
}

void Triangulation3_EEK_GetSegmentIndices(void* ptr, int* indices, int count)
{
	Triangulation3<EEK>::GetSegmentIndices(ptr, indices, count);
}

void Triangulation3_EEK_GetTriangleIndices(void* ptr, int* indices, int count)
{
	Triangulation3<EEK>::GetTriangleIndices(ptr, indices, count);
}

void Triangulation3_EEK_GetTetrahedraIndices(void* ptr, int* indices, int count)
{
	Triangulation3<EEK>::GetTetrahedraIndices(ptr, indices, count);
}