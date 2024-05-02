
#include "Polygon2_EIK.h"
#include "Polygon2.h"

#include <CGAL/Polygon_2.h>

void* Polygon2_EIK_Create()
{
	return Polygon2<EIK>::NewPolygon2();
}

void Polygon2_EIK_Release(void* ptr)
{
	Polygon2<EIK>::DeletePolygon2(ptr);
}

int Polygon2_EIK_Count(void* ptr)
{
	// auto polygon = Polygon2<EIK>::CastToPolygon2(ptr);
	return Polygon2<EIK>::Count(ptr);
}

Box2d Polygon2_EIK_GetBoundingBox(void* ptr)
{
	return Polygon2<EIK>::GetBoundingBox(ptr);
}

void* Polygon2_EIK_Copy(void* ptr)
{
	return Polygon2<EIK>::Copy(ptr);
}

void* Polygon2_EIK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Polygon2<EIK>::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Polygon2<EIK>::Convert<EEK>(ptr);

	default:
		return Polygon2<EIK>::Convert<EIK>(ptr);
	}
}

void Polygon2_EIK_Clear(void* ptr)
{
	Polygon2<EIK>::Clear(ptr);
}

int Polygon2_EIK_Capacity(void* ptr)
{
	return Polygon2<EIK>::Capacity(ptr);
}

void Polygon2_EIK_Resize(void* ptr, int count)
{
	Polygon2<EIK>::Resize(ptr, count);
}

void Polygon2_EIK_ShrinkToFit(void* ptr)
{
	Polygon2<EIK>::ShrinkToFit(ptr);
}

void Polygon2_EIK_Erase(void* ptr, int index)
{
	Polygon2<EIK>::Erase(ptr, index);
}

void Polygon2_EIK_EraseRange(void* ptr, int start, int count)
{
	Polygon2<EIK>::Erase(ptr, start, count);
}

void Polygon2_EIK_Insert(void* ptr, int index, Point2d point)
{
	Polygon2<EIK>::Insert(ptr, index, point);
}

void Polygon2_EIK_InsertRange(void* ptr, int start, int count, Point2d* points)
{
	Polygon2<EIK>::Insert(ptr, start, count, points);
}

double Polygon2_EIK_SqPerimeter(void* ptr)
{
	return Polygon2<EIK>::SqPerimeter(ptr);
}

Point2d Polygon2_EIK_GetPoint(void* ptr, int index)
{
	return Polygon2<EIK>::GetPoint(ptr, index);
}

void Polygon2_EIK_GetPoints(void* ptr, Point2d* points, int count)
{
	Polygon2<EIK>::GetPoints(ptr, points, count);
}

void Polygon2_EIK_GetSegments(void* ptr, Segment2d* segments, int count)
{
	Polygon2<EIK>::GetSegments(ptr, segments, count);
}

void Polygon2_EIK_SetPoint(void* ptr, int index, const Point2d& point)
{
	Polygon2<EIK>::SetPoint(ptr, index, point);
}

void Polygon2_EIK_SetPoints(void* ptr, Point2d* points, int count)
{
	Polygon2<EIK>::SetPoints(ptr, points, count);
}

void Polygon2_EIK_Reverse(void* ptr)
{
	Polygon2<EIK>::Reverse(ptr);
}

BOOL Polygon2_EIK_IsSimple(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<EIK>*)ptr;
	return polygon->is_simple();

	//return Polygon2<EIK>::IsSimple<(ptr);
}

BOOL Polygon2_EIK_IsConvex(void* ptr)
{
	return Polygon2<EIK>::IsConvex(ptr);
}

CGAL::Orientation Polygon2_EIK_Orientation(void* ptr)
{
	return Polygon2<EIK>::Orientation(ptr);
}

CGAL::Oriented_side Polygon2_EIK_OrientedSide(void* ptr, const Point2d& point)
{
	return Polygon2<EIK>::OrientedSide(ptr, point);
}

CGAL::Bounded_side Polygon2_EIK_BoundedSide(void* ptr, const Point2d& point)
{
	return Polygon2<EIK>::BoundedSide(ptr, point);
}

double Polygon2_EIK_SignedArea(void* ptr)
{
	return Polygon2<EIK>::SignedArea(ptr);
}

void Polygon2_EIK_Translate(void* ptr, const Point2d& translation)
{
	Polygon2<EIK>::Translate(ptr, translation);
}

void Polygon2_EIK_Rotate(void* ptr, double rotation)
{
	Polygon2<EIK>::Rotate(ptr, rotation);
}

void Polygon2_EIK_Scale(void* ptr, double scale)
{
	Polygon2<EIK>::Scale(ptr, scale);
}

void Polygon2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	Polygon2<EIK>::Transform(ptr, translation, rotation, scale);
}

BOOL Polygon2_EIK_ContainsPoint(void* ptr, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary)
{
	return Polygon2<EIK>::ContainsPoint(ptr, point, orientation, inculdeBoundary);
}
