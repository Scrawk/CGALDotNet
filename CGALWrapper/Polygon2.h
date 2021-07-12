#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h> 

template<class K>
int Polygon2_Count(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return polygon->size();
}

template<class K>
void* Polygon2_Copy(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return new CGAL::Polygon_2<K>(*polygon);
}

template<class K>
void Polygon2_Clear(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	polygon->clear();
}

template<class K>
void* Polygon2_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	auto polygon = new CGAL::Polygon_2<K>();

	for (int i = 0; i < count; i++)
	{
		double x = points[startIndex + i].x;
		double y = points[startIndex + i].y;

		polygon->push_back(CGAL::Point_2<K>(x, y));
	}

	return polygon;
}

template<class K>
Point2d Polygon2_GetPoint(void* ptr, int index)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	auto point = polygon->vertex(index);

	return { CGAL::to_double(point.x()), CGAL::to_double(point.y()) };
}

template<class K>
void Polygon2_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;

	for (int i = 0; i < count; i++)
	{
		auto point = polygon->vertex(i);

		points[startIndex + i].x = CGAL::to_double(point.x());
		points[startIndex + i].y = CGAL::to_double(point.y());
	}
}

template<class K>
void Polygon2_SetPoint(void* ptr, int index, Point2d point)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	(*polygon)[index] = CGAL::Point_2<K>(point.x, point.y);
}

template<class K>
void Polygon2_SetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;

	for (int i = 0; i < count; i++)
	{
		(*polygon)[i] = CGAL::Point_2<K>(points[startIndex + i].x, points[startIndex + i].y);
	}
}

template<class K>
void Polygon2_Reverse(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	polygon->reverse_orientation();
}

template<class K>
bool Polygon2_IsSimple(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return polygon->is_simple();
}

template<class K>
bool Polygon2_IsConvex(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return polygon->is_convex();
}

template<class K>
CGAL::Orientation Polygon2_Orientation(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return polygon->orientation();
}

template<class K>
CGAL::Oriented_side Polygon2_OrientedSide(void* ptr, Point2d point)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return polygon->oriented_side(CGAL::Point_2<K>(point.x, point.y));
}

template<class K>
double Polygon2_SignedArea(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return CGAL::to_double(polygon->area());
}




