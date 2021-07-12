#pragma once
#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/enum.h>


template<class K>
int PolygonWithHoles2_HoleCount(void* ptr)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;
	return pwh->number_of_holes();
}

template<class K>
void* PolygonWithHoles2_Copy(void* ptr)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;
	return new CGAL::Polygon_with_holes_2<K>(*pwh);
}

template<class K>
void PolygonWithHoles2_Clear(void* ptr)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;
	pwh->clear();
}

template<class K>
void* PolygonWithHoles2_CreateFromPolygon(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return new CGAL::Polygon_with_holes_2<K>(*polygon);
}

template<class K>
void* PolygonWithHoles2_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	auto polygon = new CGAL::Polygon_2<K>();

	for (int i = 0; i < count; i++)
	{
		double x = points[startIndex + i].x;
		double y = points[startIndex + i].y;

		polygon->push_back(CGAL::Point_2<K>(x, y));
	}

	return new CGAL::Polygon_with_holes_2<K>(*polygon);
}


