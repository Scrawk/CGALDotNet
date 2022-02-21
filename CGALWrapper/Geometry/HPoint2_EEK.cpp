#include "HPoint2_EEK.h"
#include <CGAL/Point_2.h>
#include <CGAL/Weighted_point_2.h>

typedef CGAL::Weighted_point_2<EEK> HPoint2;

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

HPoint2* CastToHPoint2(void* ptr)
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

HPoint2d HPoint2_EEK_GetPoint(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	return HPoint2d::FromCGAL<EEK>(*p);
}

void HPoint2_EEK_SetX(void* ptr, double x)
{
	auto p = CastToHPoint2(ptr);
	(*p)[0] = x;
}

void HPoint2_EEK_SetY(void* ptr, double y)
{
	auto p = CastToHPoint2(ptr);
	(*p)[1] = y;
}

void HPoint2_EEK_SetW(void* ptr, double w)
{
	auto p = CastToHPoint2(ptr);
	(*p)[2] = w;
}

void HPoint2_EEK_SetPoint(void* ptr, const HPoint2d& point)
{
	auto p = CastToHPoint2(ptr);
	(*p)[0] = point.hx;
	(*p)[1] = point.hy;
	(*p)[2] = point.hw;
}

void* HPoint2_EEK_Copy(void* ptr)
{
	auto p = CastToHPoint2(ptr);
	auto p2 = new HPoint2();

	(*p2) = *p;
	return p2;
}
