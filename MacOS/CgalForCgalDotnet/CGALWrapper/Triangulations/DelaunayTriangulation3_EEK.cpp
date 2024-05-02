#pragma once
#include "DelaunayTriangulation3_EEK.h"
#include "BaseTriangulation3.h"
#include "DelaunayTriangulation3.h"

typedef typename CGAL::Triangulation_vertex_base_with_info_3<int, EEK>		Vb;
typedef typename CGAL::Delaunay_triangulation_cell_base_3<EEK>                Cb;
typedef typename CGAL::Triangulation_data_structure_3<Vb, Cb>               Tds;

typedef CGAL::Delaunay_triangulation_3<EEK, Tds> 						DelaunayTriangulation_3;

typedef typename DelaunayTriangulation_3::Point						Point_3;
typedef typename DelaunayTriangulation_3::Cell_handle				Cell;
typedef typename DelaunayTriangulation_3::Vertex_handle				Vertex;

typedef DelaunayTriangulation3<EEK, DelaunayTriangulation_3, Vertex, Cell> Tri3;

void* DelaunayTriangulation3_EEK_Create()
{
	return Tri3::NewTriangulation3();
}

void DelaunayTriangulation3_EEK_Release(void* ptr)
{
	Tri3::DeleteTriangulation3(ptr);
}

void* DelaunayTriangulation3_EEK_Copy(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->Copy();
}

void DelaunayTriangulation3_EEK_Clear(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->Clear();
}

int DelaunayTriangulation3_EEK_BuildStamp(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->buildStamp;
}

int DelaunayTriangulation3_EEK_Dimension(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->Dimension();
}

BOOL DelaunayTriangulation3_EEK_IsValid(void* ptr, BOOL verbose)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->IsValid(verbose);
}

int DelaunayTriangulation3_EEK_FiniteVertexCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FiniteVertexCount();
}

int DelaunayTriangulation3_EEK_VertexCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->VertexCount();
}

int DelaunayTriangulation3_EEK_CellCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->CellCount();
}

int DelaunayTriangulation3_EEK_FiniteCellCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FiniteCellCount();
}

int DelaunayTriangulation3_EEK_EdgeCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->EdgeCount();
}

int DelaunayTriangulation3_EEK_FiniteEdgeCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FiniteEdgeCount();
}

int DelaunayTriangulation3_EEK_FacetCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FacetCount();
}

int DelaunayTriangulation3_EEK_FiniteFacetCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FiniteFacetCount();
}

void DelaunayTriangulation3_EEK_InsertPoint(void* ptr, const Point3d& point)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->InsertPoint(point);
}

void DelaunayTriangulation3_EEK_InsertPoints(void* ptr, Point3d* points, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->InsertPoints(points, count);
}

void DelaunayTriangulation3_EEK_InsertInCell(void* ptr, int index, const Point3d& point)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->InsertInCell(index, point);
}

int DelaunayTriangulation3_EEK_Locate(void* ptr, const Point3d& point)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->Locate(point);
}

void DelaunayTriangulation3_EEK_GetCircumcenters(void* ptr, Point3d* Circumcenters, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetCircumcenters(Circumcenters, count);
}

void DelaunayTriangulation3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetPoints(points, count);
}

void DelaunayTriangulation3_EEK_GetVertices(void* ptr, TriVertex3* vertices, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetVertices(vertices, count);
}

BOOL DelaunayTriangulation3_EEK_GetVertex(void* ptr, int index, TriVertex3& vertex)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->GetVertex(index, vertex);
}

void DelaunayTriangulation3_EEK_GetCells(void* ptr, TriCell3* cells, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetCells(cells, count);
}

BOOL DelaunayTriangulation3_EEK_GetCell(void* ptr, int index, TriCell3& cell)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->GetCell(index, cell);
}

void DelaunayTriangulation3_EEK_GetSegmentIndices(void* ptr, int* indices, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetSegmentIndices(indices, count);
}

void DelaunayTriangulation3_EEK_GetTriangleIndices(void* ptr, int* indices, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetTriangleIndices(indices, count);
}

void DelaunayTriangulation3_EEK_GetTetrahedraIndices(void* ptr, int* indices, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetTetrahedraIndices(indices, count);
}

void DelaunayTriangulation3_EEK_GetSegments(void* ptr, Segment3d* segments, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetSegments(segments, count);
}

void DelaunayTriangulation3_EEK_GetTriangles(void* ptr, Triangle3d* triangles, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetTriangles(triangles, count);
}

void DelaunayTriangulation3_EEK_GetTetahedrons(void* ptr, Tetahedron3d* tetahedrons, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetTetahedrons(tetahedrons, count);
}

void DelaunayTriangulation3_EEK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->Transform(matrix);
}

BOOL DelaunayTriangulation3_EEK_Move(void* ptr, int index, const Point3d& point, BOOL ifNoCollision)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->Move(index, point, ifNoCollision);
}

int DelaunayTriangulation3_EEK_NearestVertex(void* ptr, const Point3d& point)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->NearestVertex(point);
}

int DelaunayTriangulation3_EEK_NearestVertexInCell(void* ptr, int index, const Point3d& point)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->NearestVertexInCell(index, point);
}

BOOL DelaunayTriangulation3_EEK_RemoveVertex(void* ptr, int index)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->RemoveVertex(index);
}
