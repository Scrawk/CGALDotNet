#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

template<class POLYGON, class POINT>
void* Polygon2_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	auto polygon = new POLYGON();

	for (int i = 0; i < count; i++)
	{
		double x = points[startIndex + i].x;
		double y = points[startIndex + i].y;

		polygon->push_back(POINT(x, y));
	}

	return polygon;
}

template<class POLYGON>
Point2d Polygon2_GetPoint(void* ptr, int index)
{
	auto polygon = (POLYGON*)ptr;
	auto point = polygon->vertex(index);

	return { CGAL::to_double(point.x()), CGAL::to_double(point.y()) };
}

template<class POLYGON>
void Polygon2_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	auto polygon = (POLYGON*)ptr;

	for (int i = 0; i < count; i++)
	{
		auto point = polygon->vertex(i);

		points[startIndex + i].x = CGAL::to_double(point.x());
		points[startIndex + i].y = CGAL::to_double(point.y());
	}
}

template<class POLYGON, class POINT>
void Polygon2_SetPoint(void* ptr, int index, Point2d point)
{
	auto polygon = (POLYGON*)ptr;
	(*polygon)[index] = POINT(point.x, point.y);
}

template<class POLYGON, class POINT>
void Polygon2_SetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	auto polygon = (POLYGON*)ptr;

	for (int i = 0; i < count; i++)
	{
		(*polygon)[i] = POINT(points[startIndex + i].x, points[startIndex + i].y);
	}
}

template<class POLYGON>
void Polygon2_Reverse(void* ptr)
{
	auto polygon = (POLYGON*)ptr;
	polygon->reverse_orientation();
}

template<class POLYGON>
bool Polygon2_IsSimple(void* ptr)
{
	auto polygon = (POLYGON*)ptr;
	return polygon->is_simple();
}

template<class POLYGON>
bool Polygon2_IsConvex(void* ptr)
{
	auto polygon = (POLYGON*)ptr;
	return polygon->is_convex();
}

template<class POLYGON>
CGAL::Orientation Polygon2_Orientation(void* ptr)
{
	auto polygon = (POLYGON*)ptr;
	return polygon->orientation();
}

template<class POLYGON, class POINT>
CGAL::Oriented_side Polygon2_OrientedSide(void* ptr, Point2d point)
{
	auto polygon = (POLYGON*)ptr;
	return polygon->oriented_side(POINT(point.x, point.y));
}

template<class POLYGON>
double Polygon2_Area(void* ptr)
{
	auto polygon = (POLYGON*)ptr;
	return CGAL::to_double(polygon->area());
}

template<class POLYGON>
void Polygon2_Clear(void* ptr)
{
	auto polygon = (POLYGON*)ptr;
	polygon->clear();
}



