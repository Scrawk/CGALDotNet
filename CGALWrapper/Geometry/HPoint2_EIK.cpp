#include "HPoint2_EIK.h"
#include <CGAL/Point_2.h>
#include <CGAL/Weighted_point_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Weighted_point_2<EIK> HPoint2;
typedef CGAL::Point_2<EIK> Point2;

void* HPoint2_EIK_Create()
{
	return new HPoint2();
}

void* HPoint2_EIK_CreateFromPoint(const HPoint2d& point)
{
	auto p = point.ToCGALWeightedPoint<EIK>();
	return new HPoint2(p.x(), p.y());
}

void HPoint2_EIK_Release(void* ptr)
{
	auto obj = static_cast<HPoint2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

HPoint2* CastToHPoint2(void* ptr)
{
	return static_cast<HPoint2*>(ptr);
}

double HPoint2_EIK_GetX(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	return CGAL::to_double(p->hx());
}

double HPoint2_EIK_GetY(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	return CGAL::to_double(p->hy());
}

double HPoint2_EIK_GetW(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	return CGAL::to_double(p->hw());
}

void HPoint2_EIK_SetX(void* ptr, double x)
{
	auto p = CastToHPoint2(ptr);
	(*p) = HPoint2(Point2(x, p->y()), p->hw());
}

void HPoint2_EIK_SetY(void* ptr, double y)
{
	auto p = CastToHPoint2(ptr);
	(*p) = HPoint2(Point2(p->x(), y), p->hw());
}

void HPoint2_EIK_SetW(void* ptr, double w)
{
	auto p = CastToHPoint2(ptr);
	(*p) = HPoint2(Point2(p->x(), p->y()), p->hw());
}

void* HPoint2_EIK_Copy(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	auto p2 = new HPoint2();

	(*p2) = *p;
	return p2;
}

void* HPoint2_EIK_Convert(void* ptr)
{
	typedef CGAL::Cartesian_converter<EIK, EEK> EIK_to_EEK;
	EIK_to_EEK convert;

	auto p = CastToHPoint2(ptr);
	auto hx = convert((*p)[0]);
	auto hy = convert((*p)[1]);
	auto hw = convert((*p)[2]);

	return new CGAL::Weighted_point_2<EEK>(CGAL::Point_2<EEK>(hx, hy), hw);
}
