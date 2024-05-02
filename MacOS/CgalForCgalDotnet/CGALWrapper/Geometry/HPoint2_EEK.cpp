#include "HPoint2_EEK.h"
#include <CGAL/Point_2.h>
#include <CGAL/Weighted_point_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Weighted_point_2<EEK> HPoint2;
typedef CGAL::Point_2<EEK> Point2;

void* HPoint2_EEK_Create()
{
	return new HPoint2();
}

void* HPoint2_EEK_CreateFromPoint(const HPoint2d& point)
{
	auto p = point.ToCGALWeightedPoint<EEK>();
	return new HPoint2(p.x(), p.y());
}

void HPoint2_EEK_Release(void* ptr)
{
	auto obj = static_cast<HPoint2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

static HPoint2* CastToHPoint2(void* ptr)
{
	return static_cast<HPoint2*>(ptr);
}

double HPoint2_EEK_GetX(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	return CGAL::to_double(p->hx());
}

double HPoint2_EEK_GetY(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	return CGAL::to_double(p->hy());
}

double HPoint2_EEK_GetW(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	return CGAL::to_double(p->hw());
}

void HPoint2_EEK_SetX(void* ptr, double x)
{
	auto p = CastToHPoint2(ptr);
	(*p) = HPoint2(Point2(x, p->y()), p->hw());
}

void HPoint2_EEK_SetY(void* ptr, double y)
{
	auto p = CastToHPoint2(ptr);
	(*p) = HPoint2(Point2(p->x(), y), p->hw());
}

void HPoint2_EEK_SetW(void* ptr, double w)
{
	auto p = CastToHPoint2(ptr);
	(*p) = HPoint2(Point2(p->x(), p->y()), p->hw());
}

void* HPoint2_EEK_Copy(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	auto p2 = new HPoint2();

	(*p2) = *p;
	return p2;
}

void* HPoint2_EEK_Convert(void* ptr)
{
	typedef CGAL::Cartesian_converter<EEK, EIK> EEK_to_EIK;
	EEK_to_EIK convert;

	auto p = CastToHPoint2(ptr);
	auto hx = convert((*p)[0]);
	auto hy = convert((*p)[1]);
	auto hw = convert((*p)[2]);

	return new CGAL::Weighted_point_2<EIK>(CGAL::Point_2<EIK>(hx, hy), hw);
}


template<class K2>
static void* Convert(HPoint2* hp)
{
	CGAL::Cartesian_converter<EEK, K2> convert;

	auto hx = convert((*hp)[0]);
	auto hy = convert((*hp)[1]);
	auto hw = convert((*hp)[2]);
	auto p = CGAL::Point_2<K2>(hx, hy);

	return  new CGAL::Weighted_point_2<K2>(p, hw);
}

void* HPoint2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto p = CastToHPoint2(ptr);

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
