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

static Point2* CastToPoint2(void* ptr)
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

template<class K2>
static void* Convert(Point2* p)
{
	CGAL::Cartesian_converter<EIK, K2> convert;

	auto x = convert((*p)[0]);
	auto y = convert((*p)[1]);

	return new CGAL::Point_2<K2>(x, y);
}

void* Point2_EIK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto p = CastToPoint2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(p);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(p);

	default:
		return Convert<EIK>(p);
	}
}
