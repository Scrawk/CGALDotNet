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
