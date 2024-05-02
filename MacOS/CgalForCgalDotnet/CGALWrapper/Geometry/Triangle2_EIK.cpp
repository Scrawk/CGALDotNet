
#include "Triangle2_EIK.h"
#include <CGAL/Triangle_2.h>
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Triangle_2<EIK> Triangle2;
typedef CGAL::Point_2<EIK> Point2;
typedef CGAL::Aff_transformation_2<EIK> Transformation2;

void* Triangle2_EIK_Create(const Point2d& a, const Point2d& b, const Point2d& c)
{
	auto A = a.ToCGAL<EIK>();
	auto B = b.ToCGAL<EIK>();
	auto C = c.ToCGAL<EIK>();

	return new Triangle2(A, B, C);
}

void Triangle2_EIK_Release(void* ptr)
{
	auto obj = static_cast<Triangle2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

static Triangle2* CastToTriangle2(void* ptr)
{
	return static_cast<Triangle2*>(ptr);
}

static Triangle2* NewTriangle2()
{
	return new Triangle2();
}

Point2d Triangle2_EIK_GetVertex(void* ptr, int i)
{
	auto tri = CastToTriangle2(ptr);
	return Point2d::FromCGAL<EIK>(tri->vertex(i));
}

void Triangle2_EIK_SetVertex(void* ptr, int i, const Point2d& point)
{

	auto tri = CastToTriangle2(ptr);
	
	if (i == 0)
	{
		auto p = point.ToCGAL<EIK>();
		(*tri) = Triangle2(p, tri->vertex(1), tri->vertex(2));
	}
	else if(i == 1)
	{
		auto p = point.ToCGAL<EIK>();
		(*tri) = Triangle2(tri->vertex(0), p, tri->vertex(2));
	}
	else
	{
		auto p = point.ToCGAL<EIK>();
		(*tri) = Triangle2(tri->vertex(0), tri->vertex(1), p);
	}
}

double Triangle2_EIK_Area(void* ptr)
{
	auto tri = CastToTriangle2(ptr);
	return CGAL::to_double(tri->area());
}

CGAL::Bounded_side Triangle2_EIK_BoundedSide(void* ptr, const Point2d& point)
{
	auto tri = CastToTriangle2(ptr);
	auto p = point.ToCGAL<EIK>();
	return tri->bounded_side(p);
}

CGAL::Sign Triangle2_EIK_OrientedSide(void* ptr, const Point2d& point)
{
	auto tri = CastToTriangle2(ptr);
	auto p = point.ToCGAL<EIK>();
	return tri->oriented_side(p);
}

CGAL::Sign Triangle2_EIK_Orientation(void* ptr)
{
	auto tri = CastToTriangle2(ptr);
	return tri->orientation();
}

BOOL Triangle2_EIK_IsDegenerate(void* ptr)
{
	auto tri = CastToTriangle2(ptr);
	return tri->is_degenerate();
}

void Triangle2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto tri = CastToTriangle2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EIK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*tri) = tri->transform(T * R * S);
}

void* Triangle2_EIK_Copy(void* ptr)
{
	auto t = CastToTriangle2(ptr);
	auto t2 = new Triangle2();

	(*t2) = *t;
	return t2;
}

template<class K2>
static void* Convert(Triangle2* t)
{
	CGAL::Cartesian_converter<EIK, K2> convert;

	auto a = convert(t->vertex(0));
	auto b = convert(t->vertex(1));
	auto c = convert(t->vertex(2));

	return new CGAL::Triangle_2<K2>(a, b, c);
}

void* Triangle2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto t = CastToTriangle2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(t);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(t);

	default:
		return Convert<EIK>(t);
	}
}
