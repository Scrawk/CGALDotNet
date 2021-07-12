#include "pch.h"
#include "Util.h"
#include "Polygon2_EIK.h"
#include "Polygon2.h"

void* Polygon2_EIK_Create()
{
	return Util_Create<Polygon2_EIK>();
}

void* Polygon2_EIK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	return Polygon2_CreateFromPoints<Polygon2_EIK, Point2_EIK>(points, startIndex, count);
}

void Polygon2_EIK_Release(void* ptr)
{
	Util_Release<Polygon2_EIK>(ptr);
}

Point2d Polygon2_EIK_GetPoint(void* ptr, int index)
{
	return Polygon2_GetPoint<Polygon2_EIK>(ptr, index);
}

void Polygon2_EIK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2_GetPoints<Polygon2_EIK>(ptr, points, startIndex, count);
}

void Polygon2_EIK_SetPoint(void* ptr, int index, Point2d point)
{
	Polygon2_SetPoint<Polygon2_EIK, Point2_EIK>(ptr, index, point);
}

void Polygon2_EIK_SetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2_SetPoints<Polygon2_EIK, Point2_EIK>(ptr, points, startIndex, count);
}

void Polygon2_EIK_Reverse(void* ptr)
{
	Polygon2_Reverse<Polygon2_EIK>(ptr);
}

bool Polygon2_EIK_IsSimple(void* ptr)
{
	return Polygon2_IsSimple<Polygon2_EIK>(ptr);
}

bool Polygon2_EIK_IsConvex(void* ptr)
{
	return Polygon2_IsConvex<Polygon2_EIK>(ptr);
}

CGAL::Orientation Polygon2_EIK_Orientation(void* ptr)
{
	return Polygon2_Orientation<Polygon2_EIK>(ptr);
}

CGAL::Oriented_side Polygon2_EIK_OrientedSide(void* ptr, Point2d point)
{
	return Polygon2_OrientedSide<Polygon2_EIK, Point2_EIK>(ptr, point);
}

double Polygon2_EIK_SignedArea(void* ptr)
{
	return Polygon2_SignedArea<Polygon2_EIK>(ptr);
}

void Polygon2_EIK_Clear(void* ptr)
{
	Polygon2_Clear<Polygon2_EIK>(ptr);
}
