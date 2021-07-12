#include "pch.h"
#include "Polygon2_EIK.h"

#include <CGAL/Polygon_2.h>

void* Polygon2_EIK_Create()
{
	return new Polygon2_EIK();
}

void* Polygon2_EIK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	auto polygon = new Polygon2_EIK();

	for (int i = 0; i < count; i++)
	{
		double x = points[startIndex + i].x;
		double y = points[startIndex + i].y;

		polygon->push_back(Point2_EIK(x, y));
	}

	return polygon;
}

void Polygon2_EIK_Release(void* ptr)
{
	auto poylgon = (Polygon2_EIK*)ptr;

	if (poylgon != nullptr)
	{
		delete poylgon;
		poylgon = nullptr;
	}
}

Point2d Polygon2_EIK_GetPoint(void* ptr, int index)
{
	auto polygon = (Polygon2_EIK*)ptr;
	auto point = polygon->vertex(index);

	return { point.x(), point.y() };
}

void Polygon2_EIK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	auto polygon = (Polygon2_EIK*)ptr;

	for (int i = 0; i < count; i++)
	{
		auto point = polygon->vertex(i);

		points[startIndex + i].x = point.x();
		points[startIndex + i].y = point.y();
	}
}

void Polygon2_EIK_SetPoint(void* ptr, int index, Point2d point)
{
	auto polygon = (Polygon2_EIK*)ptr;
	(*polygon)[index] = Point2_EIK(point.x, point.y);
}

void Polygon2_EIK_SetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	auto polygon = (Polygon2_EIK*)ptr;

	for (int i = 0; i < count; i++)
	{
		(*polygon)[i] = Point2_EIK(points[startIndex + i].x, points[startIndex + i].y);
	}
}

void Polygon2_EIK_Reverse(void* ptr)
{
	auto polygon = (Polygon2_EIK*)ptr;
	polygon->reverse_orientation();
}

bool Polygon2_EIK_IsSimple(void* ptr)
{
	auto polygon = (Polygon2_EIK*)ptr;
	return polygon->is_simple();
}

bool Polygon2_EIK_IsConvex(void* ptr)
{
	auto polygon = (Polygon2_EIK*)ptr;
	return polygon->is_convex();
}

CGAL::Orientation Polygon2_EIK_Orientation(void* ptr)
{
	auto polygon = (Polygon2_EIK*)ptr;
	return polygon->orientation();
}

CGAL::Oriented_side Polygon2_EIK_OrientedSide(void* ptr, Point2d point)
{
	auto polygon = (Polygon2_EIK*)ptr;
	return polygon->oriented_side(Point2_EIK(point.x, point.y));
}

double Polygon2_EIK_Area(void* ptr)
{
	auto polygon = (Polygon2_EIK*)ptr;
	return polygon->area();
}

void Polygon2_EIK_Clear(void* ptr)
{
	auto polygon = (Polygon2_EIK*)ptr;
	polygon->clear();
}