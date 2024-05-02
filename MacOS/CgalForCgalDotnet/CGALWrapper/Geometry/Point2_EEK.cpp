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

static Point2* CastToPoint2(void* ptr)
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

void Point2_EEK_SetX(void* ptr, double x)
{
	auto p = CastToPoint2(ptr);
	(*p) = Point2(x, p->y());
}

void Point2_EEK_SetY(void* ptr, double y)
{
	auto p = CastToPoint2(ptr);
	(*p) = Point2(p->x(), y);
}

void* Point2_EEK_Copy(void* ptr)
{
	auto p = CastToPoint2(ptr);
	auto p2 = new Point2();

	(*p2) = *p;
	return p2;
}

template<class K2>
static void* Convert(Point2* p)
{
	CGAL::Cartesian_converter<EEK, K2> convert;

	auto x = convert((*p)[0]);
	auto y = convert((*p)[1]);

	return new CGAL::Point_2<K2>(x, y);
}

void* Point2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto p = CastToPoint2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(p);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(p);

	default:
		return Convert<EEK>(p);
	}
}
