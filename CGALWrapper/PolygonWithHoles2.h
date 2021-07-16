#pragma once
#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/enum.h>

#define BOUNDARY_INDEX -1

template<class K>
CGAL::Polygon_2<K>* GetBoundaryOrHole(void* ptr, int index, bool forceBoundary = false)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;

	if (index == BOUNDARY_INDEX)
	{
		if (!forceBoundary && pwh->is_unbounded())
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
int PolygonWithHoles2_PointCount(void* ptr, int index)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		polygon->size();
	else
		return 0;
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
Point2d PolygonWithHoles2_GetPoint(void* ptr, int polyIndex, int pointIndex)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, polyIndex);
	if (polygon != nullptr)
	{
		auto polygon = (CGAL::Polygon_2<K>*)ptr;
		auto point = polygon->vertex(pointIndex);

		return { CGAL::to_double(point.x()), CGAL::to_double(point.y()) };
	}
	else
	{
		return { 0, 0 };
	}
}

template<class K>
void PolygonWithHoles2_GetPoints(void* ptr, Point2d* points, int polyIndex, int startIndex, int count)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, polyIndex);
	if (polygon != nullptr)
	{
		for (auto i = 0; i < count; i++)
		{
			auto point = polygon->vertex(i);
			points[startIndex + i].x = CGAL::to_double(point.x());
			points[startIndex + i].y = CGAL::to_double(point.y());
		}
	}
}

template<class K>
void PolygonWithHoles2_SetPoint(void* ptr, int polyIndex, int pointIndex, Point2d point)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, polyIndex);
	if (polygon != nullptr)
	{
		auto polygon = (CGAL::Polygon_2<K>*)ptr;
		(*polygon)[pointIndex] = CGAL::Point_2<K>(point.x, point.y);
	}
}

template<class K>
void PolygonWithHoles2_SetPoints(void* ptr, Point2d* points, int polyIndex, int startIndex, int count)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, polyIndex, true);
	if (polygon != nullptr)
	{
		auto size = polygon->size();

		for (auto i = 0; i < count; i++)
		{
			int index = startIndex + i;

			if (index < size)
				(*polygon)[i] = points[index].To<K>();
			else
				polygon->push_back(points[index].To<K>());
		}
	}
}

template<class K>
void PolygonWithHoles2_AddHoleFromPolygon(void* pwhPtr, void* polygonPtr)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)pwhPtr;
	auto polygon = (CGAL::Polygon_2<K>*)polygonPtr;
	pwh->add_hole(*polygon);
}

template<class K>
void PolygonWithHoles2_RemoveHole(void* ptr, int index)
{
	auto pwh = (CGAL::Polygon_with_holes_2<K>*)ptr;
	pwh->erase_hole(pwh->holes_begin() + index);
}

template<class K>
void* PolygonWithHoles2_CopyPolygon(void* ptr, int index)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
		return new CGAL::Polygon_2<K>(*polygon);
	else
		return nullptr;
}

template<class K>
void PolygonWithHoles2_ReversePolygon(void* ptr, int index)
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

template<class K>
void PolygonWithHoles2_Translate(void* ptr, int index, Point2d translation)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
	{
		CGAL::Aff_transformation_2<K> transformation(CGAL::TRANSLATION, translation.ToVector<K>());
		(*polygon) = CGAL::transform(transformation, *polygon);
	}
}

template<class K>
void PolygonWithHoles2_Rotate(void* ptr, int index, double rotation)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
	{
		CGAL::Aff_transformation_2<K> transformation(CGAL::ROTATION, sin(rotation), cos(rotation));
		(*polygon) = CGAL::transform(transformation, *polygon);
	}
}

template<class K>
void PolygonWithHoles2_Scale(void* ptr, int index, double scale)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
	{
		CGAL::Aff_transformation_2<K> transformation(CGAL::SCALING, scale);
		(*polygon) = CGAL::transform(transformation, *polygon);
	}
}

template<class K>
void PolygonWithHoles2_Transform(void* ptr, int index, Point2d translation, double rotation, double scale)
{
	auto polygon = GetBoundaryOrHole<K>(ptr, index);
	if (polygon != nullptr)
	{
		CGAL::Aff_transformation_2<K> T(CGAL::TRANSLATION, translation.ToVector<K>());
		CGAL::Aff_transformation_2<K> R(CGAL::ROTATION, sin(rotation), cos(rotation));
		CGAL::Aff_transformation_2<K> S(CGAL::SCALING, scale);

		(*polygon) = CGAL::transform(T * R * S, *polygon);
	}

}



