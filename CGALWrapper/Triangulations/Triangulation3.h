#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "TriUtil.h"
//#include "TriangulationMap3.h"

#include <vector>
#include "CGAL/Point_3.h"
#include <CGAL/Triangulation_3.h>
#include <CGAL/Triangulation_cell_base_with_info_3.h>
#include <CGAL/Triangulation_vertex_base_with_info_3.h>
#include <CGAL/Aff_transformation_3.h>

template<class K>
class Triangulation3
{

public:

	typedef CGAL::Triangulation_vertex_base_with_info_3<int, K> Vb;
	typedef CGAL::Triangulation_cell_base_with_info_3<int, K>	Cb;
	typedef CGAL::Triangulation_data_structure_3<Vb, Cb>        Tds;

	typedef CGAL::Triangulation_3<K, Tds>						Triangulation_3;

	typedef typename Triangulation_3::Point						Point_3;
	typedef typename Triangulation_3::Cell_handle				Cell;
	typedef typename Triangulation_3::Vertex_handle				Vertex;

	typedef CGAL::Aff_transformation_3<K>						Transformation_3;

public:

	Triangulation_3 model;

	//TriangulationMap3<K, Vertex, Cell> map;

	Triangulation3()
	{
		//map.OnModelChanged();
	}

	~Triangulation3()
	{

	}

	inline static Triangulation3* NewTriangulation3()
	{
		return new Triangulation3();
	}

	inline static void DeleteTriangulation3(void* ptr)
	{
		auto obj = static_cast<Triangulation3*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static Triangulation3* CastToTriangulation3(void* ptr)
	{
		return static_cast<Triangulation3*>(ptr);
	}

	static void Clear(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		tri->Clear();
	}

	void Clear()
	{
		model.clear();
	}

	static void* Copy(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		auto copy = new Triangulation3<K>();
		copy->model = tri->model;
		return copy;
	}

	static int Dimension(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return tri->model.dimension();
	}

	static BOOL IsValid(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return tri->model.is_valid();
	}

	static int VertexCount(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return (int)tri->model.number_of_vertices();
	}

	static int CellCount(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return (int)tri->model.number_of_cells();
	}

	static int FiniteCellCount(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return (int)tri->model.number_of_finite_cells();
	}

	static int EdgeCount(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return (int)tri->model.number_of_edges();
	}

	static int FiniteEdgeCount(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return (int)tri->model.number_of_finite_edges();
	}

	static int FacetCount(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return (int)tri->model.number_of_facets();
	}

	static int FiniteFacetCount(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return (int)tri->model.number_of_finite_facets();
	}

	static void InsertPoint(void* ptr, const Point3d& point)
	{
		auto tri = CastToTriangulation3(ptr);
		tri->model.insert(point.ToCGAL<K>());
	}

	static void InsertPoints(void* ptr, Point3d* points, int count)
	{
		auto tri = CastToTriangulation3(ptr);

		std::vector<Point_3> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();

		tri->model.insert(list.begin(), list.end());
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto tri = CastToTriangulation3(ptr);

		int num = (int)tri->model.number_of_vertices();

		int i = 0;
		for (const auto& vert : tri->model.finite_vertex_handles())
		{
			points[i++] = Point3d::FromCGAL<K>(vert->point());

			if (i >= count) return;
			if (i >= num) return;
		}
			
	}

	void MarkVertices()
	{
		int index = 0;
		for (auto vert : model.all_vertex_handles())
		{
			if (!model.is_infinite(vert))
				vert->info() = index++;
			else
				vert->info() = NULL_INDEX;
		}
	}

	static void GetSegmentIndices(void* ptr, int* indices, int count)
	{
		auto tri = CastToTriangulation3(ptr);
		tri->MarkVertices();
			
		int num = (int)tri->model.number_of_finite_edges();

		int index = 0;
		for (auto edge = tri->model.finite_edges_begin(); edge != tri->model.finite_edges_end(); ++edge)
		{
			indices[index * 2 + 0] = edge->first->vertex(0)->info();
			indices[index * 2 + 1] = edge->first->vertex(1)->info();

			index++;

			if (index * 2 >= count) return;
			if (index >= num) return;
		}
	}

	static void GetTriangleIndices(void* ptr, int* indices, int count)
	{
		auto tri = CastToTriangulation3(ptr);
		tri->MarkVertices();

		int num = (int)tri->model.number_of_finite_facets();

		int index = 0;
		for (auto face = tri->model.finite_facets_begin(); face != tri->model.finite_facets_end(); ++face)
		{
			indices[index * 3 + 0] = face->first->vertex(0)->info();
			indices[index * 3 + 1] = face->first->vertex(1)->info();
			indices[index * 3 + 2] = face->first->vertex(2)->info();

			index++;

			if (index * 3 >= count) return;
			if (index >= num) return;
		}
	}

	static void GetTetrahedraIndices(void* ptr, int* indices, int count)
	{
		auto tri = CastToTriangulation3(ptr);
		tri->MarkVertices();

		int num = (int)tri->model.number_of_finite_cells();

		int index = 0;
		for (auto cell = tri->model.finite_cells_begin(); cell != tri->model.finite_cells_end(); ++cell)
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

};