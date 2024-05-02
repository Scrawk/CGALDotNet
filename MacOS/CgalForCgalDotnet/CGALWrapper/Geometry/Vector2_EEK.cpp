#include "Vector2_EEK.h"
#include <CGAL/Vector_2.h>
#include <CGAL/Cartesian_converter.h>

typedef EEK::FT FT;
typedef CGAL::Vector_2<EEK> Vector2;

void* Vector2_EEK_Create()
{
	return new Vector2();
}

void* Vector2_EEK_CreateFromVector(const Vector2d& point)
{
	auto p = point.ToCGAL<EEK>();
	return new Vector2(p.x(), p.y());
}

void Vector2_EEK_Release(void* ptr)
{
	auto obj = static_cast<Vector2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

static Vector2* CastToVector2(void* ptr)
{
	return static_cast<Vector2*>(ptr);
}

double Vector2_EEK_GetX(void* ptr)
{
	auto p = CastToVector2(ptr);
	return CGAL::to_double(p->x());
}

double Vector2_EEK_GetY(void* ptr)
{
	auto p = CastToVector2(ptr);
	return CGAL::to_double(p->y());
}

void Vector2_EEK_SetX(void* ptr, double x)
{
	auto p = CastToVector2(ptr);
	(*p) = Vector2(x, p->y());
}

void Vector2_EEK_SetY(void* ptr, double y)
{
	auto p = CastToVector2(ptr);
	(*p) = Vector2(p->x(), y);
}

double Vector2_EEK_SqrLength(void* ptr)
{
	auto p = CastToVector2(ptr);
	return CGAL::to_double(p->squared_length());
}

void* Vector2_EEK_Perpendicular(void* ptr, CGAL::Orientation orientation)
{
	auto p = CastToVector2(ptr);
	auto v = new Vector2();
	(*v) = p->perpendicular(orientation);
	return v;
}

void Vector2_EEK_Normalize(void* ptr)
{
	auto p = CastToVector2(ptr);
	auto sq_len = CGAL::to_double(p->squared_length());

	if (sq_len == 0) return;

	auto len = CGAL::sqrt(sq_len);
	(*p) = Vector2(p->x() / len, p->y() / len);
}

double Vector2_EEK_Magnitude(void* ptr)
{
	auto p = CastToVector2(ptr);
	auto sq_len = CGAL::to_double(p->squared_length());

	if (sq_len == 0) return 0;
	return CGAL::sqrt(sq_len);
}

void* Vector2_EEK_Copy(void* ptr)
{
	auto v = CastToVector2(ptr);
	auto v2 = new Vector2();

	(*v2) = *v;
	return v2;
}

template<class K2>
static void* Convert(Vector2* v)
{
	CGAL::Cartesian_converter<EEK, K2> convert;

	auto x = convert((*v)[0]);
	auto y = convert((*v)[1]);

	return new CGAL::Vector_2<K2>(x, y);
}

void* Vector2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	auto p = CastToVector2(ptr);

	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Convert<EIK>(p);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Convert<EEK>(p);

	default:
		return Convert<EEK>(p);
	}
}
