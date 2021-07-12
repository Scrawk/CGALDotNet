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

}

void* PolygonWithHoles2_EEK_CreateFromPolygon(void* ptr)
{
	return PolygonWithHoles2_CreateFromPolygon<EEK>(ptr);
}

void* PolygonWithHoles2_EEK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	return PolygonWithHoles2_CreateFromPoints<EEK>(points, startIndex, count);
}
