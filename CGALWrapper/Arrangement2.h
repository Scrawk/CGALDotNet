#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>

enum class ARRANGEMENT2_ELEMENT : int
{
	VERTEX,
	EDGE,
	FACE,
	HALF_EDGE,
	ISOLATED_VERTEX,
	VERTEX_AT_INFINITY,
	UNBOUNDED_FACE
};

template<class K>
class Arrangement2
{

private:

	Arrangement2() {}

public:

	typedef CGAL::Arr_segment_traits_2<EEK> Traits_2;
	typedef Traits_2::Point_2 Point_2;
	typedef Traits_2::X_monotone_curve_2 Segment_2;
	typedef CGAL::Arrangement_2<Traits_2> Arrangement_2;

	static void* CreateFromSegments(Segment2d* segments, int startIndex, int count)
	{
		auto arr = new Arrangement_2();

		for (auto i = 0; i < count; i++)
		{
			auto a = segments[startIndex + i].a.To<K>();
			auto b = segments[startIndex + i].b.To<K>();
			auto seg = Segment_2(a, b);

			CGAL::insert(*arr, seg);
		}

		return arr;
	}

	static int ElementCount(void* ptr, ARRANGEMENT2_ELEMENT element)
	{
		auto arr = (Arrangement_2*)ptr;

		switch (element)
		{
		case ARRANGEMENT2_ELEMENT::VERTEX:
			return (int)arr->number_of_vertices();

		case ARRANGEMENT2_ELEMENT::EDGE:
			return (int)arr->number_of_edges();

		case ARRANGEMENT2_ELEMENT::FACE:
			return (int)arr->number_of_faces();

		case ARRANGEMENT2_ELEMENT::HALF_EDGE:
			return (int)arr->number_of_halfedges();

		case ARRANGEMENT2_ELEMENT::ISOLATED_VERTEX:
			return (int)arr->number_of_isolated_vertices();

		case ARRANGEMENT2_ELEMENT::VERTEX_AT_INFINITY:
			return (int)arr->number_of_vertices_at_infinity();

		case ARRANGEMENT2_ELEMENT::UNBOUNDED_FACE:
			return (int)arr->number_of_unbounded_faces();
		}

		return 0;
	}

};

