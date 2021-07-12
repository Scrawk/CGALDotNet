#include "pch.h"
#include "Util.h"
#include "Polygon2_EIK.h"
#include "Polygon2.h"

void* Polygon2_EIK_Create()
{
	return Util_Create<CGAL::Polygon_2<EIK>>();
}

void* Polygon2_EIK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	return Polygon2_CreateFromPoints<EIK>(points, startIndex, count);
}

void Polygon2_EIK_Release(void* ptr)
{
	Util_Release<CGAL::Polygon_2<EIK>>(ptr);
}

int Polygon2_EIK_Count(void* ptr)
{
	return Polygon2_Count<EIK>(ptr);
}

void* Polygon2_EIK_Copy(void* ptr)
{
	return Polygon2_Copy<EIK>(ptr);
}

void Polygon2_EIK_Clear(void* ptr)
{
	Polygon2_Clear<EIK>(ptr);
}

Point2d Polygon2_EIK_GetPoint(void* ptr, int index)
{
	return Polygon2_GetPoint<EIK>(ptr, index);
}

void Polygon2_EIK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2_GetPoints<EIK>(ptr, points, startIndex, count);
}

void Polygon2_EIK_SetPoint(void* ptr, int index, Point2d point)
{
	Polygon2_SetPoint<EIK>(ptr, index, point);
}

void Polygon2_EIK_SetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2_SetPoints<EIK>(ptr, points, startIndex, count);
}

void Polygon2_EIK_Reverse(void* ptr)
{
	Polygon2_Reverse<EIK>(ptr);
}

bool Polygon2_EIK_IsSimple(void* ptr)
{
	return Polygon2_IsSimple<EIK>(ptr);
}

bool Polygon2_EIK_IsConvex(void* ptr)
{
	return Polygon2_IsConvex<EIK>(ptr);
}

CGAL::Orientation Polygon2_EIK_Orientation(void* ptr)
{
	return Polygon2_Orientation<EIK>(ptr);
}

CGAL::Oriented_side Polygon2_EIK_OrientedSide(void* ptr, Point2d point)
{
	return Polygon2_OrientedSide<EIK>(ptr, point);
}

double Polygon2_EIK_SignedArea(void* ptr)
{
	return Polygon2_SignedArea<EIK>(ptr);
}
