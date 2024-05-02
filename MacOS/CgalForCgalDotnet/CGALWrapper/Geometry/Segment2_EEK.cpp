
#include "Segment2_EEK.h"
#include <CGAL/Segment_2.h>
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Segment_2<EEK> Segment2;
typedef CGAL::Line_2<EEK> Line2;
typedef CGAL::Point_2<EEK> Point2;
typedef CGAL::Aff_transformation_2<EEK> Transformation2;

void* Segment2_EEK_Create(const Point2d& a, const Point2d& b)
{
	auto A = a.ToCGAL<EEK>();
	auto B = b.ToCGAL<EEK>();

	return new Segment2(A, B);
}

void Segment2_EEK_Release(void* ptr)
{
	auto obj = static_cast<Segment2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

static Segment2* CastToSegment2(void* ptr)
{
	return static_cast<Segment2*>(ptr);
}

static Segment2* NewSegment2()
{
	return new Segment2();
}

Point2d Segment2_EEK_GetVertex(void* ptr, int i)
{
	auto seg = CastToSegment2(ptr);
	return Point2d::FromCGAL<EEK>(seg->vertex(i));
}

void Segment2_EEK_SetVertex(void* ptr, int i, const Point2d& point)
{
	if (i < 0 || i >= 2) return;

	auto seg = CastToSegment2(ptr);
	(*seg)[i] = point.ToCGAL<EEK>();
}

Point2d Segment2_EEK_Min(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return Point2d::FromCGAL<EEK>(seg->min());
}

Point2d Segment2_EEK_Max(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return Point2d::FromCGAL<EEK>(seg->max());
}

BOOL Segment2_EEK_IsDegenerate(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return seg->is_degenerate();
}

BOOL Segment2_EEK_IsHorizontal(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return seg->is_horizontal();
}

BOOL Segment2_EEK_IsVertical(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return seg->is_vertical();
}

BOOL Segment2_EEK_HasOn(void* segPtr, const Point2d& point)
{
	auto seg = CastToSegment2(segPtr);
	return seg->has_on(point.ToCGAL<EEK>());
}

Vector2d Segment2_EEK_Vector(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	auto v = seg->to_vector();
	return Vector2d::FromCGAL<EEK>(v);
}

void* Segment2_EEK_Line(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	auto line = new Line2();
	(*line) = seg->supporting_line();
	return line;
}

double Segment2_EEK_SqrLength(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return CGAL::to_double(seg->squared_length());
}

void Segment2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto seg = CastToSegment2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EEK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*seg) = seg->transform(T * R * S);
}

void* Segment2_EEK_Copy(void* ptr)
{
	auto s = CastToSegment2(ptr);
	auto s2 = new Segment2();

	(*s2) = *s;
	return s2;
}

template<class K2>
static void* Convert(Segment2* s)
{
	CGAL::Cartesian_converter<EEK, K2> convert;

	auto a = convert(s->source());
	auto b = convert(s->target());

	return new CGAL::Segment_2<K2>(a, b);
}

void* Segment2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto s = CastToSegment2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(s);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(s);

	default:
		return Convert<EEK>(s);
	}
}
