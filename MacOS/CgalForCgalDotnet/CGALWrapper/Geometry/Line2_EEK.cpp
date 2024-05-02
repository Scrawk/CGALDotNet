
#include "Line2_EEK.h"
#include <CGAL/Line_2.h>
#include <CGAL/Aff_transformation_2.h>

typedef CGAL::Line_2<EEK> Line2;
typedef CGAL::Point_2<EEK> Point2;
typedef CGAL::Aff_transformation_2<EEK> Transformation2;

Point2* CastToPoint2(void* ptr);

void* Line2_EEK_Create(double a, double b, double c)
{
	return new Line2(a, b, c);
}

void* Line2_EEK_CreateFromPoints(const Point2d& p1, const Point2d& p2)
{
	return new Line2(p1.ToCGAL<EEK>(), p2.ToCGAL<EEK>());
}

void* Line2_EEK_CreateFromPointVector(const Point2d& p, const Vector2d& v)
{
	return new Line2(p.ToCGAL<EEK>(), v.ToCGAL<EEK>());
}

void Line2_EEK_Release(void* ptr)
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

double Line2_EEK_GetA(void* ptr)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->a());
}

double Line2_EEK_GetB(void* ptr)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->b());
}

double Line2_EEK_GetC(void* ptr)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->c());
}

void Line2_EEK_SetA(void* ptr, double a)
{
	auto line = CastToLine2(ptr);
	(*line) = Line2(a, line->b(), line->c());
}

void Line2_EEK_SetB(void* ptr, double b)
{
	auto line = CastToLine2(ptr);
	(*line) = Line2(line->a(), b, line->c());
}

void Line2_EEK_SetC(void* ptr, double c)
{
	auto line = CastToLine2(ptr);
	(*line) = Line2(line->a(), line->b(), c);
}

BOOL Line2_EEK_IsDegenerate(void* ptr)
{
	auto line = CastToLine2(ptr);
	return line->is_degenerate();
}

BOOL Line2_EEK_IsHorizontal(void* ptr)
{
	auto line = CastToLine2(ptr);
	return line->is_horizontal();
}

BOOL Line2_EEK_IsVertical(void* ptr)
{
	auto line = CastToLine2(ptr);
	return line->is_vertical();
}

BOOL Line2_EEK_HasOn(void* linePtr, const Point2d& point)
{
	auto line = CastToLine2(linePtr);
	return line->has_on(point.ToCGAL<EEK>());
}

BOOL Line2_EEK_HasOnNegativeSide(void* linePtr, const Point2d& point)
{
	auto line = CastToLine2(linePtr);
	return line->has_on_negative_side(point.ToCGAL<EEK>());
}

BOOL Line2_EEK_HasOnPositiveSide(void* linePtr, const Point2d& point)
{
	auto line = CastToLine2(linePtr);
	return line->has_on_positive_side(point.ToCGAL<EEK>());
}

void* Line2_EEK_Opposite(void* ptr)
{
	auto line = CastToLine2(ptr);
	auto nline = NewLine2();
	(*nline) = line->opposite();
	return nline;
}

void* Line2_EEK_Perpendicular(void* ptr, const Point2d& point)
{
	auto line = CastToLine2(ptr);
	auto nline = NewLine2();
	(*nline) = line->perpendicular(point.ToCGAL<EEK>());
	return nline;
}

double Line2_EEK_X_On_Y(void* ptr, double y)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->x_at_y(y));
}

double Line2_EEK_Y_On_X(void* ptr, double x)
{
	auto line = CastToLine2(ptr);
	return CGAL::to_double(line->y_at_x(x));
}

Vector2d Line2_EEK_Vector(void* ptr)
{
	auto line = CastToLine2(ptr);
	auto v = line->to_vector();
	return Vector2d::FromCGAL<EEK>(v);
}

void Line2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto line = CastToLine2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EEK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*line) = line->transform(T * R * S);
}

void* Line2_EEK_Copy(void* ptr)
{
	auto l = CastToLine2(ptr);
	auto l2 = new Line2();

	(*l2) = *l;
	return l2;
}

void* Line2_EEK_Convert(void* ptr)
{
	typedef CGAL::Cartesian_converter<EEK, EIK> Converter;
	Converter convert;

	auto l = CastToLine2(ptr);
	auto a = convert(l->a());
	auto b = convert(l->b());
	auto c = convert(l->c());

	return new CGAL::Line_2<EIK>(a, b, c);
}


template<class K2>
static void* Convert(Line2* l)
{
	CGAL::Cartesian_converter<EEK, K2> convert;

	auto a = convert(l->a());
	auto b = convert(l->b());
	auto c = convert(l->c());

	return new CGAL::Line_2<K2>(a, b, c);
}

void* Line2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto l = CastToLine2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(l);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(l);

	default:
		return Convert<EEK>(l);
	}
}
