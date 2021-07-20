#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "Polygon2.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Triangulation_2.h>

template<class K>
class Triangulation2
{

public:

	typedef CGAL::Triangulation_2<K> Triangulation_2;
	typedef typename Triangulation_2::Point_2 Point_2;

	//typedef typename Triangulation_2::Vertex_handle Vertex_handle;
	//typedef typename Triangulation2::Finite_vertex_handles Finite_vertex_handles;

private:

	Triangulation_2 model;

public:

	Triangulation2()
	{

	}

	~Triangulation2()
	{

	}

	inline static Triangulation2* CastToTriangulation(void* ptr)
	{
		return static_cast<Triangulation2*>(ptr);
	}

	static void* CreateFromPoints(Point2d* points, int startIndex, int count)
	{
		auto tri = new Triangulation2();

		std::vector<Point_2> list(count);

		for (auto i = startIndex; i < count; i++)
			list.push_back(points[i].To<K>());

		//tri->model.insert(list.begin(), list.end());

		return tri;
	}

	static void* CreateFromPolygon(void* ptr)
	{
		auto tri = new Triangulation2();

		auto polygon = Polygon2<K>::CastToPolygon2(ptr);

		tri->model.insert(polygon->vertices_begin(), polygon->vertices_end());

		return tri;
	}

	static void Clear(void* ptr)
	{
		auto tri = CastToTriangulation(ptr);
		tri->model.clear();
	}

	static BOOL IsValid(void* ptr)
	{
		auto tri = CastToTriangulation(ptr);
		return tri->model.is_valid();
	}

	static int VertexCount(void* ptr)
	{
		auto tri = CastToTriangulation(ptr);
		return (int)tri->model.number_of_vertices();
	}

	static int FaceCount(void* ptr)
	{
		auto tri = CastToTriangulation(ptr);
		return (int)tri->model.number_of_faces();
	}

	static void GetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto tri = CastToTriangulation(ptr);
		int i = startIndex;

		for (auto it = tri->model.finite_vertices_begin(); it != tri->model.finite_vertices_end(); ++it, ++i)
		{
			points[i].From<K>(it->point());
		}
	}

};
