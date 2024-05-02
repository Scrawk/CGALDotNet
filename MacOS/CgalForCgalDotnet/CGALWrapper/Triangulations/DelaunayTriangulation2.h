#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"
#include "../Polygons/PolygonWithHoles2.h"
#include "TriUtil.h"
#include "TriVertex2.h"
#include "TriFace2.h"
#include "TriangulationMap2.h"
#include "BaseTriangulation2.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Delaunay_triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>
#include <CGAL/Delaunay_mesh_face_base_2.h>
#include <CGAL/Delaunay_mesh_vertex_base_2.h>

template<class K, class TRI, class VERT, class FACE>
class DelaunayTriangulation2 : public BaseTriangulation2<K, TRI, VERT, FACE>
{

public:

	typedef typename K::Point_2 Point_2;
	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K> Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;
	typedef CGAL::Delaunay_triangulation_2<K, Tds> Triangulation_2;
	typedef typename Triangulation_2::Face_handle Face;
	typedef typename Triangulation_2::Vertex_handle Vertex;

private:

public:

	inline static DelaunayTriangulation2* NewTriangulation2()
	{
		return new DelaunayTriangulation2();
	}

	inline static void DeleteTriangulation2(void* ptr)
	{
		auto obj = static_cast<DelaunayTriangulation2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static DelaunayTriangulation2* CastToTriangulation2(void* ptr)
	{
		return static_cast<DelaunayTriangulation2*>(ptr);
	}

	void* Copy()
	{
		auto copy = NewTriangulation2();
		copy->model = this->model;
		return copy;
	}

	template<class K2>
	static void* Convert(void* ptr)
	{
		typedef CGAL::Cartesian_converter<K, K2> Converter;
		Converter convert;

		auto tri = NewTriangulation2();
		auto tri2 = new DelaunayTriangulation2<K2, Triangulation_2, Vertex, Face>();

		for (const auto& vert : tri->model.finite_vertex_handles())
		{
			auto p = convert(vert->point());
			//tri2->model.insert(p);
		}

		return tri2;
	}

	//Delauny only

	void VoronoiCount(int& numSegments, int& numRays)
	{
		numSegments = 0;
		numRays = 0;

		for (auto eit = this->model.edges_begin(); eit != this->model.edges_end(); ++eit)
		{
			CGAL::Object o = this->model.dual(eit);
			if (CGAL::object_cast<typename K::Segment_2>(&o))
				numSegments++;
			else if (CGAL::object_cast<typename K::Ray_2>(&o))
				numRays++;
		}
	}

	int VoronoiSegmentCount()
	{
		int count = 0;
		for (auto eit = this->model.edges_begin(); eit != this->model.edges_end(); ++eit)
		{
			CGAL::Object o = this->model.dual(eit);
			if (CGAL::object_cast<typename K::Segment_2>(&o))
				++count;
		}

		return count;
	}

	int VoronoiRayCount()
	{
		int count = 0;
		for (auto eit = this->model.edges_begin(); eit != this->model.edges_end(); ++eit)
		{
			CGAL::Object o = this->model.dual(eit);
			if (CGAL::object_cast<typename K::Ray_2>(&o))
				++count;
		}

		return count;
	}

	void GetVoronoiSegments(Segment2d* segments, int count)
	{
		int i = 0;
		for (auto eit = this->model.edges_begin(); eit != this->model.edges_end(); ++eit)
		{
			if (i >= count) return;

			CGAL::Object o = this->model.dual(eit);
			if (auto seg = CGAL::object_cast<typename K::Segment_2>(&o))
				segments[i++] = Segment2d::FromCGAL<K>(seg->source(), seg->target());
		}
	}

	void GetVoronoiRays(Ray2d* rays, int count)
	{
		int i = 0;
		for (auto eit = this->model.edges_begin(); eit != this->model.edges_end(); ++eit)
		{
			if (i >= count) return;

			CGAL::Object o = this->model.dual(eit);
			if (auto ray = CGAL::object_cast<typename K::Ray_2>(&o))
				rays[i++] = Ray2d::FromCGAL<K>(ray->source(), ray->to_vector());
		}
	}


};
