#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "TriUtil.h"

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
	bool cellIndexMapBuilt = false;

	bool vertexIndexMapBuilt = false;

	int buildStamp = 1;

	void Clear()
	{
		model.clear();
		cellIndexMap.clear();
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

		int index = 0;
		for (auto& vert : model.finite_vertex_handles())
		{
			vert->info() = index++;
		}

		buildStamp++;
		vertexIndexMapBuilt = true;
	}

	void BuildCellIndices()
	{
		if (cellIndexMapBuilt) return;

		cellIndexMap.clear();

		int index = 0;
		for (auto& cell = model.finite_cells_begin(); cell != model.finite_cells_end(); ++cell)
		{
			cellIndexMap.insert(std::pair<CELL, int>(cell, index));
			index++;
		}
	
		buildStamp++;
		cellIndexMapBuilt = true;
	}

	int GetCellIndex(CELL c)
	{
		BuildCellIndices();
		return cellIndexMap[c];
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
