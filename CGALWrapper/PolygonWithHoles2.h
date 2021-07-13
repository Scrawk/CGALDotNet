#pragma once
#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/enum.h>

template<class K>
CGAL::Polygon_2<K>* GetBoundaryOrHole(void* ptr, int index)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;

	if (index == -1)
	{
		if (pwh->is_unbounded())
			return nullptr;
		else
			return &pwh->outer_boundary();
	}
	else
	{
		return &pwh->holes().at(index);
	}
}

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
void PolygonWithHoles2_ClearBoundary(void* ptr)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;
	pwh->outer_boundary().clear();
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
	auto polygon = CGAL::Polygon_2<K>();

	for (auto i = 0; i < count; i++)
		polygon.push_back(points[startIndex + i].To<K>());

	return new CGAL::Polygon_with_holes_2<K>(polygon);
}

template<class K>
void PolygonWithHoles2_AddHoleFromPolygon(void* pwhPtr, void* polygonPtr)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)pwhPtr;
	auto polygon = (CGAL::Polygon_2<K>*)polygonPtr;
	pwh->add_hole(*polygon);
}

template<class K>
void PolygonWithHoles2_AddHoleFromPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;
	auto polygon = CGAL::Polygon_2<K>();

	for (auto i = 0; i < count; i++)
		polygon.push_back(points[startIndex + i].To<K>());

	pwh->add_hole(polygon);
}

template<class K>
void PolygonWithHoles2_RemoveHole(void* ptr, int index)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;
	pwh->erase_hole(pwh->holes_begin() + index);
}

template<class K>
void* PolygonWithHoles2_CopyHole(void* ptr, int index)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		return new CGAL::Polygon_2<K>(*polygon);
	else
		return nullptr;
}

template<class K>
void PolygonWithHoles2_ReverseHole(void* ptr, int index)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		return polygon->reverse_orientation();
}

template<class K>
bool PolygonWithHoles2_IsUnbounded(void* ptr)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;
	return pwh->is_unbounded();
} 

template<class K>
bool PolygonWithHoles2_IsSimple(void* ptr, int index)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		return polygon->is_simple();
	else
		return false;
}

template<class K>
bool PolygonWithHoles2_IsConvex(void* ptr, int index)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		return polygon->is_convex();
	else
		return false;
}

template<class K>
CGAL::Orientation PolygonWithHoles2_Orientation(void* ptr, int index)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		return polygon->orientation();
	else
		return CGAL::Orientation::DEGENERATE;
}

template<class K>
CGAL::Oriented_side PolygonWithHoles2_OrientedSide(void* ptr, int index, Point2d point)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		return polygon->oriented_side(point.To<EEK>());
	else
		return CGAL::Oriented_side::DEGENERATE;
}

template<class K>
double PolygonWithHoles2_SignedArea(void* ptr, int index)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		return CGAL::to_double(polygon->area());
	else
		return 0;
}



