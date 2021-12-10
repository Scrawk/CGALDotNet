#include "../pch.h"
#include "PolygonWithHoles2_EIK.h"
#include "PolygonWithHoles2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/Boolean_set_operations_2.h>

void* PolygonWithHoles2_EIK_Create()
{
	return PolygonWithHoles2<EIK>::NewPolygonWithHoles2();
}

void PolygonWithHoles2_EIK_Release(void* ptr)
{
	PolygonWithHoles2<EIK>::DeletePolygonWithHoles2(ptr);
}

int PolygonWithHoles2_EIK_HoleCount(void* ptr)
{
	return PolygonWithHoles2<EIK>::HoleCount(ptr);
}

int PolygonWithHoles2_EIK_PointCount(void* ptr, int index)
{
	return PolygonWithHoles2<EIK>::PointCount(ptr, index);
}

void* PolygonWithHoles2_EIK_Copy(void* ptr)
{
	return PolygonWithHoles2<EIK>::Copy(ptr);
}

void PolygonWithHoles2_EIK_Clear(void* ptr)
{
	PolygonWithHoles2<EIK>::Clear(ptr);
}

void PolygonWithHoles2_EIK_ClearBoundary(void* ptr)
{
	PolygonWithHoles2<EIK>::ClearBoundary(ptr);
}

void PolygonWithHoles2_EIK_ClearHoles(void* ptr)
{
	PolygonWithHoles2<EIK>::ClearHoles(ptr);
}

void* PolygonWithHoles2_EIK_CreateFromPolygon(void* ptr)
{
	return PolygonWithHoles2<EIK>::CreateFromPolygon(ptr);
}

void* PolygonWithHoles2_EIK_CreateFromPoints(Point2d* points, int count)
{
	return PolygonWithHoles2<EIK>::CreateFromPoints(points, count);
}

Point2d PolygonWithHoles2_EIK_GetPoint(void* ptr, int polyIndex, int pointIndex)
{
	return PolygonWithHoles2<EIK>::GetPoint(ptr, polyIndex, pointIndex);
}

void PolygonWithHoles2_EIK_GetPoints(void* ptr, Point2d* points, int polyIndex, int count)
{
	PolygonWithHoles2<EIK>::GetPoints(ptr, points, polyIndex, count);
}

void PolygonWithHoles2_EIK_SetPoint(void* ptr, int polyIndex, int pointIndex, const Point2d& point)
{
	PolygonWithHoles2<EIK>::SetPoint(ptr, polyIndex, pointIndex, point);
}

void PolygonWithHoles2_EIK_SetPoints(void* ptr, Point2d* points, int polyIndex, int count)
{
	PolygonWithHoles2<EIK>::SetPoints(ptr, points, polyIndex, count);
}

void PolygonWithHoles2_EIK_AddHoleFromPolygon(void* pwhPtr, void* polygonPtr)
{
	PolygonWithHoles2<EIK>::AddHoleFromPolygon(pwhPtr, polygonPtr);
}

void PolygonWithHoles2_EIK_AddHoleFromPoints(void* ptr, Point2d* points, int count)
{
	PolygonWithHoles2<EIK>::AddHoleFromPoints(ptr, points, count);
}

void PolygonWithHoles2_EIK_RemoveHole(void* ptr, int index)
{
	PolygonWithHoles2<EIK>::RemoveHole(ptr, index);
}

void* PolygonWithHoles2_EIK_CopyPolygon(void* ptr, int index)
{
	return PolygonWithHoles2<EIK>::CopyPolygon(ptr, index);
}

void PolygonWithHoles2_EIK_ReversePolygon(void* ptr, int index)
{
	PolygonWithHoles2<EIK>::ReversePolygon(ptr, index);
}

BOOL PolygonWithHoles2_EIK_IsUnbounded(void* ptr)
{
	return PolygonWithHoles2<EIK>::IsUnbounded(ptr);
}

Box2d PolygonWithHoles2_EIK_GetBoundingBox(void* ptr, int index)
{
	return PolygonWithHoles2<EIK>::GetBoundingBox(ptr, index);
}

BOOL PolygonWithHoles2_EIK_IsSimple(void* ptr, int index)
{
	return PolygonWithHoles2<EIK>::IsSimple(ptr, index);
}

BOOL PolygonWithHoles2_EIK_IsConvex(void* ptr, int index)
{
	return PolygonWithHoles2<EIK>::IsConvex(ptr, index);
}

CGAL::Orientation PolygonWithHoles2_EIK_Orientation(void* ptr, int index)
{
	return PolygonWithHoles2<EIK>::Orientation(ptr, index);
}

CGAL::Oriented_side PolygonWithHoles2_EIK_OrientedSide(void* ptr, int index, const Point2d& point)
{
	return PolygonWithHoles2<EIK>::OrientedSide(ptr, index, point);
}

double PolygonWithHoles2_EIK_SignedArea(void* ptr, int index)
{
	return PolygonWithHoles2<EIK>::SignedArea(ptr, index);
}

void PolygonWithHoles2_EIK_Translate(void* ptr, int index, const Point2d& translation)
{
	PolygonWithHoles2<EIK>::Translate(ptr, index, translation);
}

void PolygonWithHoles2_EIK_Rotate(void* ptr, int index, double rotation)
{
	PolygonWithHoles2<EIK>::Rotate(ptr, index, rotation);
}

void PolygonWithHoles2_EIK_Scale(void* ptr, int index, double scale)
{
	PolygonWithHoles2<EIK>::Scale(ptr, index, scale);
}

void PolygonWithHoles2_EIK_Transform(void* ptr, int index, const Point2d& translation, double rotation, double scale)
{
	PolygonWithHoles2<EIK>::Transform(ptr, index, translation, rotation, scale);
}

BOOL PolygonWithHoles2_EIK_ContainsPoint(void* ptr, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary)
{
	return PolygonWithHoles2<EIK>::ContainsPoint(ptr, point, orientation, inculdeBoundary);
}

void* PolygonWithHoles2_EIK_ConnectHoles(void* ptr)
{
	return PolygonWithHoles2<EIK>::ConnectHoles(ptr);
}



