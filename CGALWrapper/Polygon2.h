#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h> 
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Direction_2.h>

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

	for (auto i = 0; i < count; i++)
		polygon->push_back(points[startIndex + i].To<K>());

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

	for (auto i = 0; i < count; i++)
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

	for (auto i = 0; i < count; i++)
		(*polygon)[i] = points[startIndex + i].To<K>();
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
	return polygon->oriented_side(point.To<K>());
}

template<class K>
double Polygon2_SignedArea(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	return CGAL::to_double(polygon->area());
}

template<class K>
void Polygon2_Translate(void* ptr, Point2d translation)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	CGAL::Aff_transformation_2<K> transformation(CGAL::TRANSLATION, translation.ToVector<K>());
	(*polygon) = CGAL::transform(transformation, *polygon);
}

template<class K>
void Polygon2_Rotate(void* ptr, double rotation)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	CGAL::Aff_transformation_2<K> transformation(CGAL::ROTATION, sin(rotation), cos(rotation));
	(*polygon) = CGAL::transform(transformation, *polygon);
}

template<class K>
void Polygon2_Scale(void* ptr, double scale)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;
	CGAL::Aff_transformation_2<K> transformation(CGAL::SCALING, scale);
	(*polygon) = CGAL::transform(transformation, *polygon);
}

template<class K>
void Polygon2_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	auto polygon = (CGAL::Polygon_2<K>*)ptr;

	CGAL::Aff_transformation_2<K> T(CGAL::TRANSLATION, translation.ToVector<K>());
	CGAL::Aff_transformation_2<K> R(CGAL::ROTATION, sin(rotation), cos(rotation));
	CGAL::Aff_transformation_2<K> S(CGAL::SCALING, scale);

	(*polygon) = CGAL::transform(T * R * S, *polygon);
}





