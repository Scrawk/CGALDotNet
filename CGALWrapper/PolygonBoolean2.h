#pragma once
#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Boolean_set_operations_2.h>
#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

template<class K>
bool PolygonBoolean2_DoIntersect(void* ptr1, void* ptr2)
{
	auto polygon1 = (CGAL::Polygon_2<K>*)ptr1;
	auto polygon2 = (CGAL::Polygon_2<K>*)ptr2;

	return CGAL::do_intersect(*polygon1, *polygon2);
}

template<class K>
bool PolygonBoolean2_Join(void* ptr1, void* ptr2, void** resultPtr)
{
	auto polygon1 = (CGAL::Polygon_2<K>*)ptr1;
	auto polygon2 = (CGAL::Polygon_2<K>*)ptr2;

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
