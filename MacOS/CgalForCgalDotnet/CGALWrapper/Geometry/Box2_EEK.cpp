
#include "Box2_EEK.h"
#include <CGAL/Iso_rectangle_2.h>
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Iso_rectangle_2<EEK> Box2;
typedef CGAL::Aff_transformation_2<EEK> Transformation2;

void* Box2_EEK_Create(const Point2d& min, const Point2d& max)
{
	auto _min = min.ToCGAL<EEK>();
	auto _max = max.ToCGAL<EEK>();

	return new Box2(_min, _max);
}

void Box2_EEK_Release(void* ptr)
{
	auto obj = static_cast<Box2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

static Box2* CastToBox2(void* ptr)
{
	return static_cast<Box2*>(ptr);
}

static Box2* NewBox2()
{
	return new Box2();
}

Point2d Box2_EEK_GetMin(void* ptr)
{
	auto rec = CastToBox2(ptr);
	return Point2d::FromCGAL<EEK>(rec->min());
}

void Box2_EEK_SetMin(void* ptr, const Point2d& point)
{
	auto rec = CastToBox2(ptr);
	(*rec) = Box2(point.ToCGAL<EEK>(), rec->max());
}

Point2d Box2_EEK_GetMax(void* ptr)
{
	auto rec = CastToBox2(ptr);
	return Point2d::FromCGAL<EEK>(rec->max());
}

void Box2_EEK_SetMax(void* ptr, const Point2d& point)
{
	auto rec = CastToBox2(ptr);
	(*rec) = Box2(rec->min(), point.ToCGAL<EEK>());
}

double Box2_EEK_Area(void* ptr)
{
	auto rec = CastToBox2(ptr);
	return CGAL::to_double(rec->area());
}

CGAL::Bounded_side Box2_EEK_BoundedSide(void* ptr, const Point2d& point)
{
	auto rec = CastToBox2(ptr);
	auto p = point.ToCGAL<EEK>();
	return rec->bounded_side(p);
}

BOOL Box2_EEK_ContainsPoint(void* ptr, const Point2d& point, BOOL inculdeBoundary)
{
	auto rec = CastToBox2(ptr);
	auto side = rec->bounded_side(point.ToCGAL<EEK>());

	if (inculdeBoundary && side == CGAL::Bounded_side::ON_BOUNDARY)
		return true;

	return side == CGAL::Bounded_side::ON_BOUNDED_SIDE;
}

BOOL Box2_EEK_IsDegenerate(void* ptr)
{
	auto rec = CastToBox2(ptr);
	return rec->is_degenerate();
}

void Box2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto rec = CastToBox2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EEK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*rec) = rec->transform(T * R * S);
}

void* Box2_EEK_Copy(void* ptr)
{
	auto rec = CastToBox2(ptr);
	auto nrec = NewBox2();

	(*nrec) = *rec;
	return nrec;
}

template<class K2>
static void* Convert(Box2* rec)
{
	CGAL::Cartesian_converter<EEK, K2> convert;

	auto min = convert(rec->min());
	auto max = convert(rec->max());

	return new CGAL::Iso_rectangle_2<K2>(min, max);
}

void* Box2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto rec = CastToBox2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(rec);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(rec);

	default:
		return Convert<EEK>(rec);
	}
}

