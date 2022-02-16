
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

void Line2_EEK_Release(void* ptr)
{
	auto obj = static_cast<Line2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

Line2* NewLine2()
{
	return new Line2();
}

Line2* CastToLine2(void* ptr)
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

void* Line2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto line = CastToLine2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EEK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	auto nline = NewLine2();
	(*nline) = line->transform(T * R * S);

	return nline;
}