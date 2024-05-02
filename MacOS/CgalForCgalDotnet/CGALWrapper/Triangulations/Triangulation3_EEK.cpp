#pragma once
#include "Triangulation3_EEK.h"
#include "Triangulation3.h"
#include "BaseTriangulation3.h"


typedef CGAL::Triangulation_vertex_base_with_info_3<int, EEK> Vb;
typedef CGAL::Triangulation_cell_base_with_info_3<int, EEK>	Cb;
typedef CGAL::Triangulation_data_structure_3<Vb, Cb>        Tds;

typedef CGAL::Triangulation_3<EEK, Tds>						Triangulation_3;

typedef typename Triangulation_3::Point						Point_3;
typedef typename Triangulation_3::Cell_handle				Cell;
typedef typename Triangulation_3::Vertex_handle				Vertex;
typedef typename Triangulation_3::Edge						Edge;

typedef Triangulation3<EEK, Triangulation_3, Vertex, Cell> Tri3;

void* Triangulation3_EEK_Create()
{
	return Tri3::NewTriangulation3();
}

void Triangulation3_EEK_Release(void* ptr)
{
	Tri3::DeleteTriangulation3(ptr);
}

void Triangulation3_EEK_Clear(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->Clear();
}

void* Triangulation3_EEK_Copy(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->Copy();
}

int Triangulation3_EEK_BuildStamp(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->buildStamp;
}

int Triangulation3_EEK_Dimension(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->Dimension();
}

BOOL Triangulation3_EEK_IsValid(void* ptr, BOOL verbose)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->IsValid(verbose);
}

int Triangulation3_EEK_FiniteVertexCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FiniteVertexCount();
}

int Triangulation3_EEK_VertexCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->VertexCount();
}

int Triangulation3_EEK_CellCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->CellCount();
}

int Triangulation3_EEK_FiniteCellCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FiniteCellCount();
}

int Triangulation3_EEK_EdgeCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->EdgeCount();
}

int Triangulation3_EEK_FiniteEdgeCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FiniteEdgeCount();
}

int Triangulation3_EEK_FacetCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FacetCount();
}

int Triangulation3_EEK_FiniteFacetCount(void* ptr)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->FiniteFacetCount();
}

void Triangulation3_EEK_InsertPoint(void* ptr, const Point3d& point)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->InsertPoint(point);
}

void Triangulation3_EEK_InsertPoints(void* ptr, Point3d* points, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->InsertPoints(points, count);
}

void Triangulation3_EEK_InsertInCell(void* ptr, int index, const Point3d& point)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->InsertInCell(index, point);
}

int Triangulation3_EEK_Locate(void* ptr, const Point3d& point)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->Locate(point);
}

void Triangulation3_EEK_GetCircumcenters(void* ptr, Point3d* Circumcenters, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetCircumcenters(Circumcenters, count);
}

void Triangulation3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetPoints(points, count);
}

void Triangulation3_EEK_GetVertices(void* ptr, TriVertex3* vertices, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetVertices(vertices, count);
}

BOOL Triangulation3_EEK_GetVertex(void* ptr, int index, TriVertex3& vertex)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->GetVertex(index, vertex);
}

void Triangulation3_EEK_GetCells(void* ptr, TriCell3* cells, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetCells(cells, count);
}

BOOL Triangulation3_EEK_GetCell(void* ptr, int index, TriCell3& cell)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	return tri->GetCell(index, cell);
}

void Triangulation3_EEK_GetSegmentIndices(void* ptr, int* indices, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetSegmentIndices(indices, count);
}

void Triangulation3_EEK_GetTriangleIndices(void* ptr, int* indices, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetTriangleIndices(indices, count);
}

void Triangulation3_EEK_GetTetrahedraIndices(void* ptr, int* indices, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetTetrahedraIndices(indices, count);
}

void Triangulation3_EEK_GetSegments(void* ptr, Segment3d* segments, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetSegments(segments, count);
}

void Triangulation3_EEK_GetTriangles(void* ptr, Triangle3d* triangles, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetTriangles(triangles, count);
}

void Triangulation3_EEK_GetTetahedrons(void* ptr, Tetahedron3d* tetahedrons, int count)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->GetTetahedrons(tetahedrons, count);
}

void Triangulation3_EEK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	auto tri = Tri3::CastToTriangulation3(ptr);
	tri->Transform(matrix);
}



