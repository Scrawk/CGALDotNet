#include "Point2_EIK.h"
#include <CGAL/Point_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Point_2<EIK> Point2;

void* Point2_EIK_Create()
{
	return new Point2();
}

void* Point2_EIK_CreateFromPoint(const Point2d& point)
{
	auto p = point.ToCGAL<EIK>();
	return new Point2(p.x(), p.y());
}

void Point2_EIK_Release(void* ptr)
{
	auto obj = static_cast<Point2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

Point2* CastToPoint2(void* ptr)
{
	return static_cast<Point2*>(ptr);
}

double Point2_EIK_GetX(void* ptr)
{
	auto p = CastToPoint2(ptr);
	return CGAL::to_double(p->x());
}

double Point2_EIK_GetY(void* ptr)
{
	auto p = CastToPoint2(ptr);
	return CGAL::to_double(p->y());
}

Point2d Point2_EIK_GetPoint(void* ptr)
{
	auto p = CastToPoint2(ptr);
	return Point2d::FromCGAL<EIK>(*p);
}

void Point2_EIK_SetX(void* ptr, double x)
{
	auto p = CastToPoint2(ptr);
	(*p) = Point2(x, p->y());
}

void Point2_EIK_SetY(void* ptr, double y)
{
	auto p = CastToPoint2(ptr);
	(*p) = Point2(p->x(), y);
}

void Point2_EIK_SetPoint(void* ptr, const Point2d& point)
{
	auto p = CastToPoint2(ptr);
	(*p) = Point2(point.x, point.y);
}

void* Point2_EIK_Copy(void* ptr)
{
	auto p = CastToPoint2(ptr);
	auto p2 = new Point2();

	(*p2) = *p;
	return p2;
}

void* Point2_EIK_Convert(void* ptr)
{
	typedef CGAL::Cartesian_converter<EEK, EIK> Converter;
	Converter convert;

	auto p = CastToPoint2(ptr);
	auto x = convert(p->x());
	auto y = convert(p->y());

	return new CGAL::Point_2<EIK>(x, y);
}
