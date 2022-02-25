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

Vector2* CastToVector2(void* ptr)
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

void* Vector2_EEK_Convert(void* ptr)
{
	typedef CGAL::Cartesian_converter<EEK, EIK> Converter;
	Converter convert;

	auto p = CastToVector2(ptr);
	auto x = convert(p->x());
	auto y = convert(p->y());

	return new CGAL::Vector_2<EIK>(x, y);
}
