
#include "Segment2_EIK.h"
#include <CGAL/Segment_2.h>
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Cartesian_converter.h>

typedef CGAL::Segment_2<EIK> Segment2;
typedef CGAL::Line_2<EIK> Line2;
typedef CGAL::Point_2<EIK> Point2;
typedef CGAL::Aff_transformation_2<EIK> Transformation2;

void* Segment2_EIK_Create(const Point2d& a, const Point2d& b)
{
	auto A = a.ToCGAL<EIK>();
	auto B = b.ToCGAL<EIK>();

	return new Segment2(A, B);
}

void Segment2_EIK_Release(void* ptr)
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

Point2d Segment2_EIK_GetVertex(void* ptr, int i)
{
	auto seg = CastToSegment2(ptr);
	return Point2d::FromCGAL<EIK>(seg->vertex(i));
}

void Segment2_EIK_SetVertex(void* ptr, int i, const Point2d& point)
{
	auto seg = CastToSegment2(ptr);

	if (i == 0)
	{
		auto p = point.ToCGAL<EIK>();
		(*seg) = Segment2(p, seg->target());
	}
	else
	{
		auto p = point.ToCGAL<EIK>();
		(*seg) = Segment2(seg->source(), p);
	}
	
}

Point2d Segment2_EIK_Min(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return Point2d::FromCGAL<EIK>(seg->min());
}

Point2d Segment2_EIK_Max(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return Point2d::FromCGAL<EIK>(seg->max());
}

BOOL Segment2_EIK_IsDegenerate(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return seg->is_degenerate();
}

BOOL Segment2_EIK_IsHorizontal(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return seg->is_horizontal();
}

BOOL Segment2_EIK_IsVertical(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return seg->is_vertical();
}

BOOL Segment2_EIK_HasOn(void* segPtr, const Point2d& point)
{
	auto seg = CastToSegment2(segPtr);
	return seg->has_on(point.ToCGAL<EIK>());
}

Vector2d Segment2_EIK_Vector(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	auto v = seg->to_vector();
	return Vector2d::FromCGAL<EIK>(v);
}

void* Segment2_EIK_Line(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	auto line = new Line2();
	(*line) = seg->supporting_line();
	return line;
}

double Segment2_EIK_SqrLength(void* ptr)
{
	auto seg = CastToSegment2(ptr);
	return CGAL::to_double(seg->squared_length());
}

void Segment2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	auto seg = CastToSegment2(ptr);

	Transformation2 T(CGAL::TRANSLATION, translation.ToVector<EIK>());
	Transformation2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
	Transformation2 S(CGAL::SCALING, scale);

	(*seg) = seg->transform(T * R * S);
}

void* Segment2_EIK_Copy(void* ptr)
{
	auto s = CastToSegment2(ptr);
	auto s2 = new Segment2();

	(*s2) = *s;
	return s2;
}

template<class K2>
static void* Convert(Segment2* s)
{
	CGAL::Cartesian_converter<EIK, K2> convert;

	auto a = convert(s->source());
	auto b = convert(s->target());

	return new CGAL::Segment_2<K2>(a, b);
}

void* Segment2_EIK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto s = CastToSegment2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(s);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(s);

	default:
		return Convert<EIK>(s);
	}
}
