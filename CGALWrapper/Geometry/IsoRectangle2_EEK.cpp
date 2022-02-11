
#include "IsoRectangle2_EEK.h"
#include <CGAL/Iso_rectangle_2.h>

typedef CGAL::Iso_rectangle_2<EEK> IsoRectangle2;

void* IsoRectangle2_EEK_Create(const Point2d& min, const Point2d& max)
{
	auto _min = min.ToCGAL<EEK>();
	auto _max = max.ToCGAL<EEK>();

	return new IsoRectangle2(_min, _max);
}

void IsoRectangle2_EEK_Release(void* ptr)
{
	auto obj = static_cast<IsoRectangle2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

IsoRectangle2* CastToIsoRectangle2(void* ptr)
{
	return static_cast<IsoRectangle2*>(ptr);
}

Point2d IsoRectangle2_EEK_GetMin(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return Point2d::FromCGAL<EEK>(rec->min());
}

Point2d IsoRectangle2_EEK_GetMax(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return Point2d::FromCGAL<EEK>(rec->max());
}

double IsoRectangle2_EEK_Area(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return CGAL::to_double(rec->area());
}

CGAL::Bounded_side IsoRectangle2_EEK_BoundedSide(void* ptr, const Point2d& point)
{
	auto rec = CastToIsoRectangle2(ptr);
	auto p = point.ToCGAL<EEK>();
	return rec->bounded_side(p);
}

BOOL IsoRectangle2_EEK_ContainsPoint(void* ptr, const Point2d& point, BOOL inculdeBoundary)
{
	auto rec = CastToIsoRectangle2(ptr);
	auto side = rec->bounded_side(point.ToCGAL<EEK>());

	if (inculdeBoundary && side == CGAL::Bounded_side::ON_BOUNDARY)
		return true;

	return side == CGAL::Bounded_side::ON_BOUNDED_SIDE;
}

