#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "Polygon2.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>

template<class K>
class Triangulation2
{

public:

	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K> Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;

	typedef CGAL::Triangulation_2<K, Tds> Triangulation_2;
	typedef typename Triangulation_2::Point Point_2;

private:

	Triangulation_2 model;

public:

	Triangulation2()
	{

	}

	~Triangulation2()
	{

	}

	inline static Triangulation2* CastToTriangulation2(void* ptr)
	{
		return static_cast<Triangulation2*>(ptr);
	}

	static void Clear(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->model.clear();
	}

	static void* Copy(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);

		auto copy = new Triangulation2<K>();
		copy->model = tri->model;

		return copy;
	}

	static BOOL IsValid(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return tri->model.is_valid();
	}

	static int VertexCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return (int)tri->model.number_of_vertices();
	}

	static int FaceCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return (int)tri->model.number_of_faces();
	}

	static void SetVertexIndices(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		int index = 0;

		for (auto& vert : tri->model.finite_vertex_handles())
			vert->info() = index++;
	}

	static void SetFaceIndices(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		int index = 0;

		for (auto& face : tri->model.finite_face_handles())
			face->info() = index++;
	}

	static void InsertPoint(void* ptr, Point2d point)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->model.insert(point.To<K>());
	}

	static void InsertPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto tri = CastToTriangulation2(ptr);

		std::vector<Point_2> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[startIndex + i].To<K>();

		tri->model.insert(list.begin(), list.end());
	}

	static void InsertPolygon(void* triPtr, void* polyPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto polygon = Polygon2<K>::CastToPolygon2(polyPtr);
		tri->model.insert(polygon->vertices_begin(), polygon->vertices_end());
	}

	static void GetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = startIndex;

		for (const auto& vert : tri->model.finite_vertex_handles())
			points[i++].From<K>(vert->point());
	}

	static void GetIndices(void* ptr, int* indices, int startIndex, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = startIndex;

		for (auto& face : tri->model.finite_face_handles())
		{
			indices[i * 3 + 0] = face->vertex(0)->info();
			indices[i * 3 + 1] = face->vertex(1)->info();
			indices[i * 3 + 2] = face->vertex(2)->info();

			i++;
		}
	}



};
