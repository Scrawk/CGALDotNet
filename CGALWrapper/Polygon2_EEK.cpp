#include "pch.h"
#include "Util.h"
#include "Polygon2_EEK.h"
#include "Polygon2.h"

void* Polygon2_EEK_Create()
{
	return Util_Create<Polygon2_EEK>();
}

void* Polygon2_EEK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	return Polygon2_CreateFromPoints<Polygon2_EEK, Point2_EEK>(points, startIndex, count);
}

void Polygon2_EEK_Release(void* ptr)
{
	Util_Release<Polygon2_EEK>(ptr);
}

Point2d Polygon2_EEK_GetPoint(void* ptr, int index)
{
	return Polygon2_GetPoint<Polygon2_EEK>(ptr, index);
}

void Polygon2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2_GetPoints<Polygon2_EEK>(ptr, points, startIndex, count);
}

void Polygon2_EEK_SetPoint(void* ptr, int index, Point2d point)
{
	Polygon2_SetPoint<Polygon2_EEK, Point2_EEK>(ptr, index, point);
}

void Polygon2_EEK_SetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2_SetPoints<Polygon2_EEK, Point2_EEK>(ptr, points, startIndex, count);
}

void Polygon2_EEK_Reverse(void* ptr)
{
	Polygon2_Reverse<Polygon2_EEK>(ptr);
}

bool Polygon2_EEK_IsSimple(void* ptr)
{
	return Polygon2_IsSimple<Polygon2_EEK>(ptr);
}

bool Polygon2_EEK_IsConvex(void* ptr)
{
	return Polygon2_IsConvex<Polygon2_EEK>(ptr);
}

CGAL::Orientation Polygon2_EEK_Orientation(void* ptr)
{
	return Polygon2_Orientation<Polygon2_EEK>(ptr);
}

CGAL::Oriented_side Polygon2_EEK_OrientedSide(void* ptr, Point2d point)
{
	return Polygon2_OrientedSide<Polygon2_EEK, Point2_EEK>(ptr, point);
}

double Polygon2_EEK_Area(void* ptr)
{
	return Polygon2_Area<Polygon2_EEK>(ptr);
}

void Polygon2_EEK_Clear(void* ptr)
{
	Polygon2_Clear<Polygon2_EEK>(ptr);
}
