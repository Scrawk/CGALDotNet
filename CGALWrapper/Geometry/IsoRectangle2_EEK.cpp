
#include "IsoRectangle2_EEK.h"
#include <CGAL/Iso_rectangle_2.h>
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Iso_rectangle_2<EEK> IsoRectangle2;
typedef CGAL::Aff_transformation_2<EEK> Transformation2;

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

IsoRectangle2* NewIsoRectangle2()
{
	return new IsoRectangle2();
}

Point2d IsoRectangle2_EEK_GetMin(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return Point2d::FromCGAL<EEK>(rec->min());
}

void IsoRectangle2_EEK_SetMin(void* ptr, const Point2d& point)
{
	auto rec = CastToIsoRectangle2(ptr);
	(*rec)[0] = point.ToCGAL<EEK>();
}

Point2d IsoRectangle2_EEK_GetMax(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return Point2d::FromCGAL<EEK>(rec->max());
}

void IsoRectangle2_EEK_SetMax(void* ptr, const Point2d& point)
{
	auto rec = CastToIsoRectangle2(ptr);
	(*rec)[1] = point.ToCGAL<EEK>();
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

BOOL IsoRectangle2_EEK_IsDegenerate(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	return rec->is_degenerate();
}

void IsoRectangle2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto rec = CastToIsoRectangle2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EEK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*rec) = rec->transform(T * R * S);
}

void* IsoRectangle2_EEK_Copy(void* ptr)
{
	auto rec = CastToIsoRectangle2(ptr);
	auto nrec = NewIsoRectangle2();

	(*nrec) = *rec;
	return nrec;
}

void* IsoRectangle2_EEK_Convert(void* ptr)
{
	typedef CGAL::Cartesian_converter<EEK, EIK> EEK_to_EIK;
	EEK_to_EIK ExactToInexact;

	auto rec = CastToIsoRectangle2(ptr);
	auto min = ExactToInexact(rec->min());
	auto max = ExactToInexact(rec->max());

	return new CGAL::Iso_rectangle_2<EIK>(min, max);
}

