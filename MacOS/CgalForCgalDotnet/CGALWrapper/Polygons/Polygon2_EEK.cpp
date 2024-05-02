
#include "Polygon2_EEK.h"
#include "Polygon2.h"

#include <CGAL/Polygon_2.h>

void* Polygon2_EEK_Create()
{
	return Polygon2<EEK>::NewPolygon2();
}

void Polygon2_EEK_Release(void* ptr)
{
	Polygon2<EEK>::DeletePolygon2(ptr);
}

int Polygon2_EEK_Count(void* ptr)
{
	// auto polygon = Polygon2<EEK>::CastToPolygon2(ptr);
	return Polygon2<EEK>::Count(ptr);
}

Box2d Polygon2_EEK_GetBoundingBox(void* ptr)
{
	return Polygon2<EEK>::GetBoundingBox(ptr);
}

void* Polygon2_EEK_Copy(void* ptr)
{
	return Polygon2<EEK>::Copy(ptr);
}

void* Polygon2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Polygon2<EEK>::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Polygon2<EEK>::Convert<EEK>(ptr);

	default:
		return Polygon2<EEK>::Convert<EEK>(ptr);
	}
}

void Polygon2_EEK_Clear(void* ptr)
{
	Polygon2<EEK>::Clear(ptr);
}

int Polygon2_EEK_Capacity(void* ptr)
{
	return Polygon2<EEK>::Capacity(ptr);
}

void Polygon2_EEK_Resize(void* ptr, int count)
{
	Polygon2<EEK>::Resize(ptr, count);
}

void Polygon2_EEK_ShrinkToFit(void* ptr)
{
	Polygon2<EEK>::ShrinkToFit(ptr);
}

void Polygon2_EEK_Erase(void* ptr, int index)
{
	Polygon2<EEK>::Erase(ptr, index);
}

void Polygon2_EEK_EraseRange(void* ptr, int start, int count)
{
	Polygon2<EEK>::Erase(ptr, start, count);
}

void Polygon2_EEK_Insert(void* ptr, int index, Point2d point)
{
	Polygon2<EEK>::Insert(ptr, index, point);
}

void Polygon2_EEK_InsertRange(void* ptr, int start, int count, Point2d* points)
{
	Polygon2<EEK>::Insert(ptr, start, count, points);
}

double Polygon2_EEK_SqPerimeter(void* ptr)
{
	return Polygon2<EEK>::SqPerimeter(ptr);
}

Point2d Polygon2_EEK_GetPoint(void* ptr, int index)
{
	return Polygon2<EEK>::GetPoint(ptr, index);
}

void Polygon2_EEK_GetPoints(void* ptr, Point2d* points, int count)
{
	Polygon2<EEK>::GetPoints(ptr, points, count);
}

void Polygon2_EEK_GetSegments(void* ptr, Segment2d* segments, int count)
{
	Polygon2<EEK>::GetSegments(ptr, segments, count);
}

void Polygon2_EEK_SetPoint(void* ptr, int index, const Point2d& point)
{
	Polygon2<EEK>::SetPoint(ptr, index, point);
}

void Polygon2_EEK_SetPoints(void* ptr, Point2d* points, int count)
{
	Polygon2<EEK>::SetPoints(ptr, points, count);
}

void Polygon2_EEK_Reverse(void* ptr)
{
	Polygon2<EEK>::Reverse(ptr);
}

BOOL Polygon2_EEK_IsSimple(void* ptr)
{
	auto polygon = (CGAL::Polygon_2<EEK>*)ptr;
	return polygon->is_simple();

	//return Polygon2<EEK>::IsSimple<(ptr);
}

BOOL Polygon2_EEK_IsConvex(void* ptr)
{
	return Polygon2<EEK>::IsConvex(ptr);
}

CGAL::Orientation Polygon2_EEK_Orientation(void* ptr)
{
	return Polygon2<EEK>::Orientation(ptr);
}

CGAL::Oriented_side Polygon2_EEK_OrientedSide(void* ptr, const Point2d& point)
{
	return Polygon2<EEK>::OrientedSide(ptr, point);
}

CGAL::Bounded_side Polygon2_EEK_BoundedSide(void* ptr, const Point2d& point)
{
	return Polygon2<EEK>::BoundedSide(ptr, point);
}

double Polygon2_EEK_SignedArea(void* ptr)
{
	return Polygon2<EEK>::SignedArea(ptr);
}

void Polygon2_EEK_Translate(void* ptr, const Point2d& translation)
{
	Polygon2<EEK>::Translate(ptr, translation);
}

void Polygon2_EEK_Rotate(void* ptr, double rotation)
{
	Polygon2<EEK>::Rotate(ptr, rotation);
}

void Polygon2_EEK_Scale(void* ptr, double scale)
{
	Polygon2<EEK>::Scale(ptr, scale);
}

void Polygon2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	Polygon2<EEK>::Transform(ptr, translation, rotation, scale);
}

BOOL Polygon2_EEK_ContainsPoint(void* ptr, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary)
{
	return Polygon2<EEK>::ContainsPoint(ptr, point, orientation, inculdeBoundary);
}
