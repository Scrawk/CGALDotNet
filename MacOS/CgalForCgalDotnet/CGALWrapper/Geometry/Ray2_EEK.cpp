
#include "Ray2_EEK.h"
#include <CGAL/Ray_2.h>
#include <CGAL/Aff_transformation_2.h>

typedef CGAL::Ray_2<EEK> Ray2;
typedef CGAL::Line_2<EEK> Line2;
typedef CGAL::Point_2<EEK> Point2;
typedef CGAL::Aff_transformation_2<EEK> Transformation2;

void* Ray2_EEK_Create(const Point2d& position, const Vector2d& direction)
{
	auto p = position.ToCGAL<EEK>();
	auto d = direction.ToCGAL<EEK>();

	return new Ray2(p, d);
}

void Ray2_EEK_Release(void* ptr)
{
	auto obj = static_cast<Ray2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

static Ray2* CastToRay2(void* ptr)
{
	return static_cast<Ray2*>(ptr);
}

static Ray2* NewRay2()
{
	return new Ray2();
}

BOOL Ray2_EEK_IsDegenerate(void* ptr)
{
	auto ray = CastToRay2(ptr);
	return ray->is_degenerate();
}

BOOL Ray2_EEK_IsHorizontal(void* ptr)
{
	auto ray = CastToRay2(ptr);
	return ray->is_horizontal();
}

BOOL Ray2_EEK_IsVertical(void* ptr)
{
	auto ray = CastToRay2(ptr);
	return ray->is_vertical();
}

BOOL Ray2_EEK_HasOn(void* rayPtr, const Point2d& point)
{
	auto ray = CastToRay2(rayPtr);
	return ray->has_on(point.ToCGAL<EEK>());
}

Point2d Ray2_EEK_Source(void* ptr)
{
	auto ray = CastToRay2(ptr);
	auto p = ray->source();
	return Point2d::FromCGAL<EEK>(p);
}

Vector2d Ray2_EEK_Vector(void* ptr)
{
	auto ray = CastToRay2(ptr);
	auto v = ray->to_vector();
	return Vector2d::FromCGAL<EEK>(v);
}

void* Ray2_EEK_Opposite(void* ptr)
{
	auto ray = CastToRay2(ptr);
	auto nray = NewRay2();
	(*nray) = ray->opposite();
	return nray;
}

void* Ray2_EEK_Line(void* ptr)
{
	auto ray = CastToRay2(ptr);
	auto line = new Line2();
	(*line) = ray->supporting_line();
	return line;
}

void Ray2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto ray = CastToRay2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EEK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*ray) = ray->transform(T * R * S);
}

void* Ray2_EEK_Copy(void* ptr)
{
	auto r = CastToRay2(ptr);
	auto r2 = new Ray2();

	(*r2) = *r;
	return r2;
}

template<class K2>
static void* Convert(Ray2* r)
{
	CGAL::Cartesian_converter<EEK, K2> convert;

	auto p = convert(r->source());
	auto d = convert(r->direction());

	return new CGAL::Ray_2<K2>(p, d);
}

void* Ray2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto r = CastToRay2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(r);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(r);

	default:
		return Convert<EEK>(r);
	}
}
