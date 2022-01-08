#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "TriUtil.h"
#include "TriangulationMap3.h"

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

	TriangulationMap3<K, Vertex, Cell> map;

	Triangulation3()
	{
		map.OnModelChanged();
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
		map.ClearMaps();
		map.OnModelChanged();
	}

	static void* Copy(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		auto copy = new Triangulation3<K>();
		copy->model = tri->model;
		return copy;
	}

	static void SetIndices(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		tri->map.OnModelChanged();
		tri->map.SetIndices(tri->model);
	}

	static int BuildStamp(void* ptr)
	{
		auto tri = CastToTriangulation3(ptr);
		return tri->map.BuildStamp();
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
		tri->map.OnModelChanged();
	}

	static void InsertPoints(void* ptr, Point3d* points, int count)
	{
		auto tri = CastToTriangulation3(ptr);

		std::vector<Point_3> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();

		tri->model.insert(list.begin(), list.end());
		tri->map.OnModelChanged();
	}

};