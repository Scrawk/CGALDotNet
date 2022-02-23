#include "Point2_EEK.h"
#include <CGAL/Point_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Point_2<EEK> Point2;

void* Point2_EEK_Create()
{
	return new Point2();
}

void* Point2_EEK_CreateFromPoint(const Point2d& point)
{
	auto p = point.ToCGAL<EEK>();
	return new Point2(p.x(), p.y());
}

void Point2_EEK_Release(void* ptr)
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

double Point2_EEK_GetX(void* ptr)
{
	auto p = CastToPoint2(ptr);
	return CGAL::to_double(p->x());
}

double Point2_EEK_GetY(void* ptr)
{
	auto p = CastToPoint2(ptr);
	return CGAL::to_double(p->y());
}

Point2d Point2_EEK_GetPoint(void* ptr)
{
	auto p = CastToPoint2(ptr);
	return Point2d::FromCGAL<EEK>(*p);
}

void Point2_EEK_SetX(void* ptr, double x)
{
	auto p = CastToPoint2(ptr);
	(*p)[0] = x;
}

void Point2_EEK_SetY(void* ptr, double y)
{
	auto p = CastToPoint2(ptr);
	(*p)[1] = y;
}

void Point2_EEK_SetPoint(void* ptr, const Point2d& point)
{
	auto p = CastToPoint2(ptr);
	(*p)[0] = point.x;
	(*p)[1] = point.y;
}

void* Point2_EEK_Copy(void* ptr)
{
	auto p = CastToPoint2(ptr);
	auto p2 = new Point2();

	(*p2) = *p;
	return p2;
}

void* Point2_EEK_Convert(void* ptr)
{
	typedef CGAL::Cartesian_converter<EEK, EIK> Converter;
	Converter convert;

	auto p = CastToPoint2(ptr);
	auto x = convert(p->x());
	auto y = convert(p->y());

	return new CGAL::Point_2<EIK>(x, y);
}
