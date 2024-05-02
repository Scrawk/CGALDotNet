
#include "Line2_EIK.h"
#include <CGAL/Line_2.h>
#include <CGAL/Aff_transformation_2.h>

typedef CGAL::Line_2<EIK> Line2;
typedef CGAL::Point_2<EIK> Point2;
typedef CGAL::Aff_transformation_2<EIK> Transformation2;

Point2* CastToPoint2(void* ptr);

void* Line2_EIK_Create(double a, double b, double c)
{
	return new Line2(a, b, c);
}

void* Line2_EIK_CreateFromPoints(const Point2d& p1, const Point2d& p2)
{
	return new Line2(p1.ToCGAL<EIK>(), p2.ToCGAL<EIK>());
}

void* Line2_EIK_CreateFromPointVector(const Point2d& p, const Vector2d& v)
{
	return new Line2(p.ToCGAL<EIK>(), v.ToCGAL<EIK>());
}

void Line2_EIK_Release(void* ptr)
{
	auto obj = static_cast<Line2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

static Line2* NewLine2()
{
	return new Line2();
}

static Line2* CastToLine2(void* ptr)
{
	return static_cast<Line2*>(ptr);
}

double Line2_EIK_GetA(void* ptr)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->a());
}

double Line2_EIK_GetB(void* ptr)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->b());
}

double Line2_EIK_GetC(void* ptr)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->c());
}

void Line2_EIK_SetA(void* ptr, double a)
{
	auto line = CastToLine2(ptr);
	(*line) = Line2(a, line->b(), line->c());
}

void Line2_EIK_SetB(void* ptr, double b)
{
	auto line = CastToLine2(ptr);
	(*line) = Line2(line->a(), b, line->c());
}

void Line2_EIK_SetC(void* ptr, double c)
{
	auto line = CastToLine2(ptr);
	(*line) = Line2(line->a(), line->b(), c);
}

BOOL Line2_EIK_IsDegenerate(void* ptr)
{
	auto line = CastToLine2(ptr);
	return line->is_degenerate();
}

BOOL Line2_EIK_IsHorizontal(void* ptr)
{
	auto line = CastToLine2(ptr);
	return line->is_horizontal();
}

BOOL Line2_EIK_IsVertical(void* ptr)
{
	auto line = CastToLine2(ptr);
	return line->is_vertical();
}

BOOL Line2_EIK_HasOn(void* linePtr, const Point2d& point)
{
	auto line = CastToLine2(linePtr);
	return line->has_on(point.ToCGAL<EIK>());
}

BOOL Line2_EIK_HasOnNegativeSide(void* linePtr, const Point2d& point)
{
	auto line = CastToLine2(linePtr);
	return line->has_on_negative_side(point.ToCGAL<EIK>());
}

BOOL Line2_EIK_HasOnPositiveSide(void* linePtr, const Point2d& point)
{
	auto line = CastToLine2(linePtr);
	return line->has_on_positive_side(point.ToCGAL<EIK>());
}

void* Line2_EIK_Opposite(void* ptr)
{
	auto line = CastToLine2(ptr);
	auto nline = NewLine2();
	(*nline) = line->opposite();
	return nline;
}

void* Line2_EIK_Perpendicular(void* ptr, const Point2d& point)
{
	auto line = CastToLine2(ptr);
	auto nline = NewLine2();
	(*nline) = line->perpendicular(point.ToCGAL<EIK>());
	return nline;
}

double Line2_EIK_X_On_Y(void* ptr, double y)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->x_at_y(y));
}

double Line2_EIK_Y_On_X(void* ptr, double x)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->y_at_x(x));
}

Vector2d Line2_EIK_Vector(void* ptr)
{
	auto line = CastToLine2(ptr);
	auto v = line->to_vector();
	return Vector2d::FromCGAL<EIK>(v);
}

void Line2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto line = CastToLine2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EIK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*line) = line->transform(T * R * S);
}

void* Line2_EIK_Copy(void* ptr)
{
	auto l = CastToLine2(ptr);
	auto l2 = new Line2();

	(*l2) = *l;
	return l2;
}

template<class K2>
static void* Convert(Line2* l)
{
	CGAL::Cartesian_converter<EIK, K2> convert;

	auto a = convert(l->a());
	auto b = convert(l->b());
	auto c = convert(l->c());

	return new CGAL::Line_2<K2>(a, b, c);
}

void* Line2_EIK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto l = CastToLine2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(l);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(l);

	default:
		return Convert<EIK>(l);
	}
}
