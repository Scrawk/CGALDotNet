#include "../pch.h"
#include "PolygonWithHoles2_EEK.h"
#include "PolygonWithHoles2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/Boolean_set_operations_2.h>

void* PolygonWithHoles2_EEK_Create()
{
	return PolygonWithHoles2<EEK>::NewPolygonWithHoles2();
}

void PolygonWithHoles2_EEK_Release(void* ptr)
{
	PolygonWithHoles2<EEK>::DeletePolygonWithHoles2(ptr);
}

int PolygonWithHoles2_EEK_HoleCount(void* ptr)
{
	return PolygonWithHoles2<EEK>::HoleCount(ptr);
}

int PolygonWithHoles2_EEK_PointCount(void* ptr, int index)
{
	return PolygonWithHoles2<EEK>::PointCount(ptr, index);
}

void* PolygonWithHoles2_EEK_Copy(void* ptr)
{
	return PolygonWithHoles2<EEK>::Copy(ptr);
}

void* PolygonWithHoles2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return PolygonWithHoles2<EEK>::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return PolygonWithHoles2<EEK>::Convert<EEK>(ptr);

	default:
		return PolygonWithHoles2<EEK>::Convert<EEK>(ptr);
	}
}

void PolygonWithHoles2_EEK_Clear(void* ptr)
{
	PolygonWithHoles2<EEK>::Clear(ptr);
}

void PolygonWithHoles2_EEK_ClearBoundary(void* ptr)
{
	PolygonWithHoles2<EEK>::ClearBoundary(ptr);
}

void PolygonWithHoles2_EEK_ClearHoles(void* ptr)
{
	PolygonWithHoles2<EEK>::ClearHoles(ptr);
}

void* PolygonWithHoles2_EEK_CreateFromPolygon(void* ptr)
{
	return PolygonWithHoles2<EEK>::CreateFromPolygon(ptr);
}

void* PolygonWithHoles2_EEK_CreateFromPoints(Point2d* points, int count)
{
	return PolygonWithHoles2<EEK>::CreateFromPoints(points, count);
}

Point2d PolygonWithHoles2_EEK_GetPoint(void* ptr, int polyIndex, int pointIndex)
{
	return PolygonWithHoles2<EEK>::GetPoint(ptr, polyIndex, pointIndex);
}

void PolygonWithHoles2_EEK_GetPoints(void* ptr, Point2d* points, int polyIndex, int count)
{
	PolygonWithHoles2<EEK>::GetPoints(ptr, points, polyIndex, count);
}

void PolygonWithHoles2_EEK_SetPoint(void* ptr, int polyIndex, int pointIndex, const Point2d& point)
{
	PolygonWithHoles2<EEK>::SetPoint(ptr, polyIndex, pointIndex, point);
}

void PolygonWithHoles2_EEK_SetPoints(void* ptr, Point2d* points, int polyIndex, int count)
{
	PolygonWithHoles2<EEK>::SetPoints(ptr, points, polyIndex, count);
}

void PolygonWithHoles2_EEK_AddHoleFromPolygon(void* pwhPtr, void* polygonPtr)
{
	PolygonWithHoles2<EEK>::AddHoleFromPolygon(pwhPtr, polygonPtr);
}

void PolygonWithHoles2_EEK_AddHoleFromPoints(void* ptr, Point2d* points, int count)
{
	PolygonWithHoles2<EEK>::AddHoleFromPoints(ptr, points, count);
}

void PolygonWithHoles2_EEK_RemoveHole(void* ptr, int index)
{
	PolygonWithHoles2<EEK>::RemoveHole(ptr, index);
}

void* PolygonWithHoles2_EEK_CopyPolygon(void* ptr, int index)
{
	return PolygonWithHoles2<EEK>::CopyPolygon(ptr, index);
}

void PolygonWithHoles2_EEK_ReversePolygon(void* ptr, int index)
{
	PolygonWithHoles2<EEK>::ReversePolygon(ptr, index);
}

BOOL PolygonWithHoles2_EEK_IsUnbounded(void* ptr)
{
	return PolygonWithHoles2<EEK>::IsUnbounded(ptr);
}

Box2d PolygonWithHoles2_EEK_GetBoundingBox(void* ptr, int index)
{
	return PolygonWithHoles2<EEK>::GetBoundingBox(ptr, index);
}

BOOL PolygonWithHoles2_EEK_IsSimple(void* ptr, int index)
{
	return PolygonWithHoles2<EEK>::IsSimple(ptr, index);
}

BOOL PolygonWithHoles2_EEK_IsConvex(void* ptr, int index)
{
	return PolygonWithHoles2<EEK>::IsConvex(ptr, index);
}

CGAL::Orientation PolygonWithHoles2_EEK_Orientation(void* ptr, int index)
{
	return PolygonWithHoles2<EEK>::Orientation(ptr, index);
}

CGAL::Oriented_side PolygonWithHoles2_EEK_OrientedSide(void* ptr, int index, const Point2d& point)
{
	return PolygonWithHoles2<EEK>::OrientedSide(ptr, index, point);
}

double PolygonWithHoles2_EEK_SignedArea(void* ptr, int index)
{
	return PolygonWithHoles2<EEK>::SignedArea(ptr, index);
}

void PolygonWithHoles2_EEK_Translate(void* ptr, int index, const Point2d& translation)
{
	PolygonWithHoles2<EEK>::Translate(ptr, index, translation);
}

void PolygonWithHoles2_EEK_Rotate(void* ptr, int index, double rotation)
{
	PolygonWithHoles2<EEK>::Rotate(ptr, index, rotation);
}

void PolygonWithHoles2_EEK_Scale(void* ptr, int index, double scale)
{
	PolygonWithHoles2<EEK>::Scale(ptr, index, scale);
}

void PolygonWithHoles2_EEK_Transform(void* ptr, int index, const Point2d& translation, double rotation, double scale)
{
	PolygonWithHoles2<EEK>::Transform(ptr, index, translation, rotation, scale);
}

BOOL PolygonWithHoles2_EEK_ContainsPoint(void* ptr, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary)
{
	return PolygonWithHoles2<EEK>::ContainsPoint(ptr, point, orientation, inculdeBoundary);
}

void* PolygonWithHoles2_EEK_ConnectHoles(void* ptr)
{
	return PolygonWithHoles2<EEK>::ConnectHoles(ptr);
}



