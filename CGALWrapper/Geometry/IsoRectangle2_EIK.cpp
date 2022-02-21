
#include "IsoRectangle2_EIK.h"
#include <CGAL/Iso_rectangle_2.h>
#include <CGAL/Aff_transformation_2.h>

typedef CGAL::Iso_rectangle_2<EIK> IsoRectangle2;
typedef CGAL::Aff_transformation_2<EIK> Transformation2;

void* IsoRectangle2_EIK_Create(const Point2d& min, const Point2d& max)
{
	auto _min = min.ToCGAL<EIK>();
	auto _max = max.ToCGAL<EIK>();

	return new IsoRectangle2(_min, _max);
}

void IsoRectangle2_EIK_Release(void* ptr)
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

IsoRectangle2* NewIsoRectangle2()
{
	return new IsoRectangle2();
}

Point2d IsoRectangle2_EIK_GetMin(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return Point2d::FromCGAL<EIK>(rec->min());
}

void IsoRectangle2_EIK_SetMin(void* ptr, const Point2d& point)
{
	auto rec = CastToIsoRectangle2(ptr);
	(*rec)[0] = point.ToCGAL<EIK>();
}

Point2d IsoRectangle2_EIK_GetMax(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return Point2d::FromCGAL<EIK>(rec->max());
}

void IsoRectangle2_EIK_SetMax(void* ptr, const Point2d& point)
{
	auto rec = CastToIsoRectangle2(ptr);
	(*rec)[1] = point.ToCGAL<EIK>();
}

double IsoRectangle2_EIK_Area(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return CGAL::to_double(rec->area());
}

CGAL::Bounded_side IsoRectangle2_EIK_BoundedSide(void* ptr, const Point2d& point)
{
	auto rec = CastToIsoRectangle2(ptr);
	auto p = point.ToCGAL<EIK>();
	return rec->bounded_side(p);
}

BOOL IsoRectangle2_EIK_ContainsPoint(void* ptr, const Point2d& point, BOOL inculdeBoundary)
{
	auto rec = CastToIsoRectangle2(ptr);
	auto side = rec->bounded_side(point.ToCGAL<EIK>());

	if (inculdeBoundary && side == CGAL::Bounded_side::ON_BOUNDARY)
		return true;

	return side == CGAL::Bounded_side::ON_BOUNDED_SIDE;
}

BOOL IsoRectangle2_EIK_IsDegenerate(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return rec->is_degenerate();
}

void IsoRectangle2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto rec = CastToIsoRectangle2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EIK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*rec) = rec->transform(T * R * S);
}

void* IsoRectangle2_EIK_Copy(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	auto nrec = NewIsoRectangle2();

	(*nrec) = *rec;
	return nrec;
}

