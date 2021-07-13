#include "pch.h"
#include "Util.h"
#include "PolygonWithHoles2_EEK.h"
#include "PolygonWithHoles2.h"

void* PolygonWithHoles2_EEK_Create()
{
	return Util_Create<CGAL::Polygon_with_holes_2<EEK>>();
}

void PolygonWithHoles2_EEK_Release(void* ptr)
{
	Util_Release<CGAL::Polygon_with_holes_2<EEK>>(ptr);
}

int PolygonWithHoles2_EEK_HoleCount(void* ptr)
{
	return PolygonWithHoles2_HoleCount<EEK>(ptr);
}

void* PolygonWithHoles2_EEK_Copy(void* ptr)
{
	return PolygonWithHoles2_Copy<EEK>(ptr);
}

void PolygonWithHoles2_EEK_Clear(void* ptr)
{
	PolygonWithHoles2_Clear<EEK>(ptr);
}

void PolygonWithHoles2_EEK_ClearBoundary(void* ptr)
{
	PolygonWithHoles2_ClearBoundary<EEK>(ptr);
}

void* PolygonWithHoles2_EEK_CreateFromPolygon(void* ptr)
{
	return PolygonWithHoles2_CreateFromPolygon<EEK>(ptr);
}

void* PolygonWithHoles2_EEK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	return PolygonWithHoles2_CreateFromPoints<EEK>(points, startIndex, count);
}

void PolygonWithHoles2_EEK_AddHoleFromPolygon(void* pwhPtr, void* polygonPtr)
{
	PolygonWithHoles2_AddHoleFromPolygon<EEK>(pwhPtr, polygonPtr);
}

void PolygonWithHoles2_EEK_AddHoleFromPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	PolygonWithHoles2_AddHoleFromPoints<EEK>(ptr, points, startIndex, count);
}

void PolygonWithHoles2_EEK_RemoveHole(void* ptr, int index)
{
	PolygonWithHoles2_RemoveHole<EEK>(ptr, index);
}

void* PolygonWithHoles2_EEK_CopyHole(void* ptr, int index)
{
	return PolygonWithHoles2_CopyHole<EEK>(ptr, index);
}

void PolygonWithHoles2_EEK_ReverseHole(void* ptr, int index)
{
	PolygonWithHoles2_ReverseHole<EEK>(ptr, index);
}

bool PolygonWithHoles2_EEK_IsUnbounded(void* ptr)
{
	return PolygonWithHoles2_IsUnbounded<EEK>(ptr);
}

bool PolygonWithHoles2_EEK_IsSimple(void* ptr, int index)
{
	return PolygonWithHoles2_IsSimple<EEK>(ptr, index);
}

bool PolygonWithHoles2_EEK_IsConvex(void* ptr, int index)
{
	return PolygonWithHoles2_IsConvex<EEK>(ptr, index);
}

CGAL::Orientation PolygonWithHoles2_EEK_Orientation(void* ptr, int index)
{
	return PolygonWithHoles2_Orientation<EEK>(ptr, index);
}

CGAL::Oriented_side PolygonWithHoles2_EEK_OrientedSide(void* ptr, int index, Point2d point)
{
	return PolygonWithHoles2_OrientedSide<EEK>(ptr, index, point);
}

double PolygonWithHoles2_EEK_SignedArea(void* ptr, int index)
{
	return PolygonWithHoles2_SignedArea<EEK>(ptr, index);
}
