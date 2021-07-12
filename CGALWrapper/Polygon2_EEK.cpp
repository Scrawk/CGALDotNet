#include "pch.h"
#include "Util.h"
#include "Polygon2_EEK.h"
#include "Polygon2.h"

void* Polygon2_EEK_Create()
{
	return Util_Create<CGAL::Polygon_2<EEK>>();
}

void* Polygon2_EEK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	return Polygon2_CreateFromPoints<EEK>(points, startIndex, count);
}

void Polygon2_EEK_Release(void* ptr)
{
	Util_Release<CGAL::Polygon_2<EEK>>(ptr);
}

int Polygon2_EEK_Count(void* ptr)
{
	return Polygon2_Count<EEK>(ptr);
}

void* Polygon2_EEK_Copy(void* ptr)
{
	return Polygon2_Copy<EEK>(ptr);
}

void Polygon2_EEK_Clear(void* ptr)
{
	Polygon2_Clear<EEK>(ptr);
}

Point2d Polygon2_EEK_GetPoint(void* ptr, int index)
{
	return Polygon2_GetPoint<EEK>(ptr, index);
}

void Polygon2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2_GetPoints<EEK>(ptr, points, startIndex, count);
}

void Polygon2_EEK_SetPoint(void* ptr, int index, Point2d point)
{
	Polygon2_SetPoint<EEK>(ptr, index, point);
}

void Polygon2_EEK_SetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2_SetPoints<EEK>(ptr, points, startIndex, count);
}

void Polygon2_EEK_Reverse(void* ptr)
{
	Polygon2_Reverse<EEK>(ptr);
}

bool Polygon2_EEK_IsSimple(void* ptr)
{
	return Polygon2_IsSimple<EEK>(ptr);
}

bool Polygon2_EEK_IsConvex(void* ptr)
{
	return Polygon2_IsConvex<EEK>(ptr);
}

CGAL::Orientation Polygon2_EEK_Orientation(void* ptr)
{
	return Polygon2_Orientation<EEK>(ptr);
}

CGAL::Oriented_side Polygon2_EEK_OrientedSide(void* ptr, Point2d point)
{
	return Polygon2_OrientedSide<EEK>(ptr, point);
}

double Polygon2_EEK_SignedArea(void* ptr)
{
	return Polygon2_SignedArea<EEK>(ptr);
}
