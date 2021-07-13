#pragma once
#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Boolean_set_operations_2.h>
#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

template<class P1, class P2>
bool PolygonBoolean2_DoIntersect(P1* polygon1, P2* polygon2)
{
	return CGAL::do_intersect(*polygon1, *polygon2);
}

template<class K>
bool PolygonBoolean2_DoIntersect_P_P(void* ptr1, void* ptr2)
{
	using POLYGON = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	return PolygonBoolean2_DoIntersect<POLYGON, POLYGON>(polygon1, polygon2);
}

template<class K>
bool PolygonBoolean2_DoIntersect_P_PWH(void* ptr1, void* ptr2)
{
	using POLYGON = CGAL::Polygon_2<K>;
	using PWH = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	return PolygonBoolean2_DoIntersect<POLYGON, PWH>(polygon1, polygon2);
}

template<class K>
bool PolygonBoolean2_DoIntersect_PWH_PWH(void* ptr1, void* ptr2)
{
	using PWH = CGAL::Polygon_2<K>;

	auto polygon1 = (PWH*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	return PolygonBoolean2_DoIntersect<PWH, PWH>(polygon1, polygon2);
}

template<class K, class P1, class P2>
bool PolygonBoolean2_Join(P1* polygon1, P2* polygon2, void** resultPtr)
{
	auto result = new CGAL::Polygon_with_holes_2<K>();

	if (CGAL::join(*polygon1, *polygon2, *result))
	{
		*resultPtr = result;
		return true;
	}
	else
	{
		delete result;
		result = nullptr;
		return false;
	}
}

template<class K>
bool PolygonBoolean2_Join_P_P(void* ptr1, void* ptr2, void** resultPtr)
{
	using POLYGON = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	return PolygonBoolean2_Join<K, POLYGON, POLYGON>(polygon1, polygon2, resultPtr);
}

template<class K>
bool PolygonBoolean2_Join_P_PWH(void* ptr1, void* ptr2, void** resultPtr)
{
	using POLYGON = CGAL::Polygon_2<K>;
	using PWH = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	return PolygonBoolean2_Join<K, POLYGON, PWH>(polygon1, polygon2, resultPtr);
}

template<class K>
bool PolygonBoolean2_Join_PWH_PWH(void* ptr1, void* ptr2, void** resultPtr)
{
	using PWH = CGAL::Polygon_2<K>;

	auto polygon1 = (PWH*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	return PolygonBoolean2_Join<K, PWH, PWH>(polygon1, polygon2, resultPtr);
}


