#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "TriUtil.h"
#include "TriVertex3.h"
#include "TriCell3.h"

#include <vector>
#include <unordered_map>
#include "CGAL/Point_3.h"
#include <CGAL/Triangulation_3.h>
#include <CGAL/Triangulation_cell_base_with_info_3.h>
#include <CGAL/Triangulation_vertex_base_with_info_3.h>
#include <CGAL/Aff_transformation_3.h>
#include <CGAL/Cartesian_converter.h>

template<class K, class TRI, class VERT, class CELL>
class BaseTriangulation3
{


public:

	typedef typename K::Point_3 Point_3;
	typedef CGAL::Aff_transformation_3<K> Transformation_3;

	TRI model;

	std::unordered_map<CELL, int> cellIndexMap;
	std::unordered_map<int, CELL> cellMap;
	bool cellIndexMapBuilt = false;

	std::unordered_map<int, VERT> vertexMap;
	bool vertexIndexMapBuilt = false;

	int buildStamp = 1;

	void Clear()
	{
		model.clear();
		cellIndexMap.clear();
		vertexMap.clear();
		cellMap.clear();
	}

	int BuildStamp()
	{
		return buildStamp;
	}

	void OnModelChanged()
	{
		cellIndexMapBuilt = false;
		vertexIndexMapBuilt = false;
	}

	void BuildVertexIndices()
	{
		if (vertexIndexMapBuilt) return;

		vertexMap.clear();

		int index = 0;
		for (auto& vert : model.all_vertex_handles())
		{
			vert->info() = index;
			vertexMap.insert(std::pair<int, VERT>(index, vert));
			index++;
		}

		buildStamp++;
		vertexIndexMapBuilt = true;
	}

	void BuildCellIndices()
	{
		if (cellIndexMapBuilt) return;

		cellIndexMap.clear();
		cellMap.clear();

		int index = 0;
		for (auto cell = model.all_cells_begin(); cell != model.all_cells_end(); ++cell)
		{
			cellMap.insert(std::pair<int, CELL>(index, cell));
			cellIndexMap.insert(std::pair<CELL, int>(cell, index));
			index++;
		}
	
		buildStamp++;
		cellIndexMapBuilt = true;
	}

	int GetCellIndex(CELL c)
	{
		BuildCellIndices();

		auto item = cellIndexMap.find(c);
		if (item != cellIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	CELL GetCell(int i)
	{
		BuildCellIndices();

		auto item = cellMap.find(i);
		if (item != cellMap.end())
			return item->second;
		else
			return nullptr;
	}

	VERT GetVertex(int i)
	{
		BuildVertexIndices();

		auto item = vertexMap.find(i);
		if (item != vertexMap.end())
			return item->second;
		else
			return nullptr;
	}

	BOOL IsValid(int level)
	{
		return model.is_valid(level);
	}

	int VertexCount()
	{
		return (int)model.number_of_vertices();
	}

	int FaceCount()
	{
		return (int)model.number_of_faces();
	}

	int Dimension()
	{
		return model.dimension();
	}

	BOOL IsValid()
	{
		return model.is_valid();
	}

	int CellCount()
	{
		return (int)model.number_of_cells();
	}

	int FiniteCellCount()
	{
		return (int)model.number_of_finite_cells();
	}

	int EdgeCount()
	{
		return (int)model.number_of_edges();
	}

	int FiniteEdgeCount()
	{
		return (int)model.number_of_finite_edges();
	}

	int FacetCount()
	{
		return (int)model.number_of_facets();
	}

	int FiniteFacetCount()
	{
		return (int)model.number_of_finite_facets();
	}

	void InsertPoint(const Point3d& point)
	{
		model.insert(point.ToCGAL<K>());
		OnModelChanged();
	}

	void InsertPoints(Point3d* points, int count)
	{
		std::vector<Point_3> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();

		model.insert(list.begin(), list.end());
		OnModelChanged();
	}

	void InsertInCell(int index, const Point3d& point)
	{
		auto c = GetCell(index);
		if (c != nullptr)
		{
			model.insert_in_cell(point.ToCGAL<K>(), c);
			OnModelChanged();
		}
	}

	int Locate(const Point3d& point)
	{
		auto cell = model.locate(point.ToCGAL<K>());
		return GetCellIndex(cell);
	}

	void GetCircumcenters(Point3d* Circumcenters, int count)
	{
		int num = (int)model.number_of_cells();

		int i = 0;
		for (auto cell = model.all_cells_begin(); cell != model.all_cells_end(); ++cell)
		{
			Point3d c = { 0,0,0 };

			for (int j = 0; j < 4; j++)
			{
				c = c + Point3d::FromCGAL<EEK>(cell->vertex(j)->point());
			}

			Circumcenters[i] = c / 4;
		}
	}

	void GetPoints(Point3d* points, int count)
	{
		int num = (int)model.number_of_vertices();

		int i = 0;
		for (const auto& vert : model.finite_vertex_handles())
		{
			points[i++] = Point3d::FromCGAL<K>(vert->point());

			if (i >= count) return;
			if (i >= num) return;
		}
	}

	void GetVertices(TriVertex3* vertices, int count)
	{
		BuildVertexIndices();

		int num = (int)model.number_of_vertices();

		int i = 0;
		for (const auto& vert : model.finite_vertex_handles())
		{
			TriVertex3 v;
			v.Point = Point3d::FromCGAL<K>(vert->point());
			v.Degree = model.degree(vert);
			v.IsInfinite = model.is_infinite(vert);
			v.Index = vert->info();
			v.CellIndex = GetCellIndex(vert->cell());

			vertices[i++] = v;
	
			if (i >= count) return;
			if (i >= num) return;
		}
	}

	BOOL GetVertex(int index, TriVertex3& vertex)
	{
		BuildVertexIndices();
	
		auto vert = GetVertex(index);
		if(vert != nullptr)
		{
			vertex.Point = Point3d::FromCGAL<K>(vert->point());
			vertex.Degree = model.degree(vert);
			vertex.IsInfinite = model.is_infinite(vert);
			vertex.Index = vert->info();
			vertex.CellIndex = GetCellIndex(vert->cell());

			return TRUE;
		}
		else
		{
			vertex = TriVertex3::NullVertex();
			return FALSE;
		}
	}

	void GetCells(TriCell3* cells, int count)
	{
		BuildVertexIndices();

		int num = (int)model.number_of_cells();

		int i = 0;
		for (auto cell = model.all_cells_begin(); cell != model.all_cells_end(); ++cell)
		{
			TriCell3 c;
			c.IsInfinite = model.is_infinite(cell);
			c.Index = GetCellIndex(cell);
			c.VertexIndices[0] = cell->vertex(0)->info();
			c.VertexIndices[1] = cell->vertex(1)->info();
			c.VertexIndices[2] = cell->vertex(2)->info();
			c.VertexIndices[3] = cell->vertex(3)->info();
			c.NeighborIndices[0] = GetCellIndex(cell->neighbor(0));
			c.NeighborIndices[1] = GetCellIndex(cell->neighbor(1));
			c.NeighborIndices[2] = GetCellIndex(cell->neighbor(2));
			c.NeighborIndices[3] = GetCellIndex(cell->neighbor(3));

			cells[i++] = c;

			if (i >= count) return;
			if (i >= num) return;
		}
	}

	BOOL GetCell(int index, TriCell3& cell)
	{
		BuildVertexIndices();

		auto c = GetCell(index);
		if (c != nullptr)
		{
			cell.IsInfinite = model.is_infinite(c);
			cell.Index = GetCellIndex(c);
			cell.VertexIndices[0] = c->vertex(0)->info();
			cell.VertexIndices[1] = c->vertex(1)->info();
			cell.VertexIndices[2] = c->vertex(2)->info();
			cell.VertexIndices[3] = c->vertex(3)->info();
			cell.NeighborIndices[0] = GetCellIndex(c->neighbor(0));
			cell.NeighborIndices[1] = GetCellIndex(c->neighbor(1));
			cell.NeighborIndices[2] = GetCellIndex(c->neighbor(2));
			cell.NeighborIndices[3] = GetCellIndex(c->neighbor(3));

			return TRUE;
		}
		else
		{
			cell = TriCell3::NullCell();
			return FALSE;
		}
	}


	void GetSegmentIndices(int* indices, int count)
	{
		BuildVertexIndices();

		int num = (int)model.number_of_finite_edges();

		int index = 0;
		for (auto edge = model.finite_edges_begin(); edge != model.finite_edges_end(); ++edge)
		{
			indices[index * 2 + 0] = edge->first->vertex(0)->info();
			indices[index * 2 + 1] = edge->first->vertex(1)->info();

			index++;

			if (index * 2 >= count) return;
			if (index >= num) return;
		}
	}

	void GetTriangleIndices(int* indices, int count)
	{
		BuildVertexIndices();

		int num = (int)model.number_of_finite_facets();

		int index = 0;
		for (auto face = model.finite_facets_begin(); face != model.finite_facets_end(); ++face)
		{
			indices[index * 3 + 0] = face->first->vertex(0)->info();
			indices[index * 3 + 1] = face->first->vertex(1)->info();
			indices[index * 3 + 2] = face->first->vertex(2)->info();

			index++;

			if (index * 3 >= count) return;
			if (index >= num) return;
		}
	}

	void GetTetrahedraIndices(int* indices, int count)
	{
		BuildVertexIndices();

		int num = (int)model.number_of_finite_cells();

		int index = 0;
		for (auto cell = model.finite_cells_begin(); cell != model.finite_cells_end(); ++cell)
		{
			indices[index * 4 + 0] = cell->vertex(0)->info();
			indices[index * 4 + 1] = cell->vertex(1)->info();
			indices[index * 4 + 2] = cell->vertex(2)->info();
			indices[index * 4 + 3] = cell->vertex(3)->info();

			index++;

			if (index * 4 >= count) return;
			if (index >= num) return;
		}
	}

	void Transform(const Matrix4x4d& matrix)
	{
		auto m = matrix.ToCGAL<K>();

		for (auto vert = model.finite_vertices_begin(); vert != model.finite_vertices_end(); ++vert)
		{
			auto p = vert->point();
			vert->set_point(m.transform(p));
		}
	}
};
