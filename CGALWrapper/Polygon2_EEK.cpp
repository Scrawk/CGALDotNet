#include "pch.h"
#include "Util.h"
#include "Polygon2_EEK.h"
#include "Polygon2.h"

void* Polygon2_EEK_Create()
{
	return Util::Create<Polygon2<EEK>::Polygon_2>();
}

void* Polygon2_EEK_CreateFromPoints(Point2d* points, int startIndex, int count)
{
	return Polygon2<EEK>::CreateFromPoints(points, startIndex, count);
}

void Polygon2_EEK_Release(void* ptr)
{
	Util::Release<Polygon2<EEK>::Polygon_2>(ptr);
}

int Polygon2_EEK_Count(void* ptr)
{
	return Polygon2<EEK>::Count(ptr);
}

void* Polygon2_EEK_Copy(void* ptr)
{
	return Polygon2<EEK>::Copy(ptr);
}

void Polygon2_EEK_Clear(void* ptr)
{
	Polygon2<EEK>::Clear(ptr);
}

Point2d Polygon2_EEK_GetPoint(void* ptr, int index)
{
	return Polygon2<EEK>::GetPoint(ptr, index);
}

void Polygon2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2<EEK>::GetPoints(ptr, points, startIndex, count);
}

void Polygon2_EEK_SetPoint(void* ptr, int index, Point2d point)
{
	Polygon2<EEK>::SetPoint(ptr, index, point);
}

void Polygon2_EEK_SetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Polygon2<EEK>::SetPoints(ptr, points, startIndex, count);
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

CGAL::Oriented_side Polygon2_EEK_OrientedSide(void* ptr, Point2d point)
{
	return Polygon2<EEK>::OrientedSide(ptr, point);
}

double Polygon2_EEK_SignedArea(void* ptr)
{
	return Polygon2<EEK>::SignedArea(ptr);
}

void Polygon2_EEK_Translate(void* ptr, Point2d translation)
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

void Polygon2_EEK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	Polygon2<EEK>::Transform(ptr, translation, rotation, scale);
}

BOOL Polygon2_EEK_ContainsPoint(void* ptr, Point2d point, CGAL::Orientation orientation, BOOL inculdeBoundary)
{
	return Polygon2<EEK>::ContainsPoint(ptr, point, orientation, inculdeBoundary);
}
