#pragma once
#include "DelaunayTriangulation3_EEK.h"
#include "DelaunayTriangulation3.h"

void* DelaunayTriangulation3_EEK_Create()
{
	return DelaunayTriangulation3<EEK>::NewTriangulation3();
}

void DelaunayTriangulation3_EEK_Release(void* ptr)
{
	DelaunayTriangulation3<EEK>::DeleteTriangulation3(ptr);
}

void DelaunayTriangulation3_EEK_Clear(void* ptr)
{
	DelaunayTriangulation3<EEK>::Clear(ptr);
}

void* DelaunayTriangulation3_EEK_Copy(void* ptr)
{
	return DelaunayTriangulation3<EEK>::Copy(ptr);
}

int DelaunayTriangulation3_EEK_Dimension(void* ptr)
{
	return DelaunayTriangulation3<EEK>::Dimension(ptr);
}

BOOL DelaunayTriangulation3_EEK_IsValid(void* ptr)
{
	return DelaunayTriangulation3<EEK>::IsValid(ptr);
}

int DelaunayTriangulation3_EEK_VertexCount(void* ptr)
{
	return DelaunayTriangulation3<EEK>::VertexCount(ptr);
}

int DelaunayTriangulation3_EEK_CellCount(void* ptr)
{
	return DelaunayTriangulation3<EEK>::CellCount(ptr);
}

int DelaunayTriangulation3_EEK_FiniteCellCount(void* ptr)
{
	return DelaunayTriangulation3<EEK>::FiniteCellCount(ptr);
}

int DelaunayTriangulation3_EEK_EdgeCount(void* ptr)
{
	return DelaunayTriangulation3<EEK>::EdgeCount(ptr);
}

int DelaunayTriangulation3_EEK_FiniteEdgeCount(void* ptr)
{
	return DelaunayTriangulation3<EEK>::FiniteEdgeCount(ptr);
}

int DelaunayTriangulation3_EEK_FacetCount(void* ptr)
{
	return DelaunayTriangulation3<EEK>::FacetCount(ptr);
}

int DelaunayTriangulation3_EEK_FiniteFacetCount(void* ptr)
{
	return DelaunayTriangulation3<EEK>::FiniteFacetCount(ptr);
}

void DelaunayTriangulation3_EEK_InsertPoint(void* ptr, const Point3d& point)
{
	DelaunayTriangulation3<EEK>::InsertPoint(ptr, point);
}

void DelaunayTriangulation3_EEK_InsertPoints(void* ptr, Point3d* points, int count)
{
	DelaunayTriangulation3<EEK>::InsertPoints(ptr, points, count);
}

void DelaunayTriangulation3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	DelaunayTriangulation3<EEK>::GetPoints(ptr, points, count);
}

void DelaunayTriangulation3_EEK_GetSegmentIndices(void* ptr, int* indices, int count)
{
	DelaunayTriangulation3<EEK>::GetSegmentIndices(ptr, indices, count);
}

void DelaunayTriangulation3_EEK_GetTriangleIndices(void* ptr, int* indices, int count)
{
	DelaunayTriangulation3<EEK>::GetTriangleIndices(ptr, indices, count);
}

void DelaunayTriangulation3_EEK_GetTetrahedraIndices(void* ptr, int* indices, int count)
{
	DelaunayTriangulation3<EEK>::GetTetrahedraIndices(ptr, indices, count);
}

void DelaunayTriangulation3_EEK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	DelaunayTriangulation3<EEK>::Transform(ptr, matrix);
}