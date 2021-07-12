#pragma once
#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Boolean_set_operations_2.h>
#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

template<class POLYGON>
bool PolygonBoolean2_DoIntersect(void* ptr1, void* ptr2)
{
	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	return CGAL::do_intersect(*polygon1, *polygon2);
}

template<class POLYGON, class POLYGON_WITH_HOLES>
bool PolygonBoolean2_Join(void* ptr1, void* ptr2, void** resultPtr)
{
	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	auto result = new POLYGON_WITH_HOLES();

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
