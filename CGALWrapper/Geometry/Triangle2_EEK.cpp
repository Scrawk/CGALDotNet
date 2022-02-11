
#include "Triangle2_EEK.h"
#include <CGAL/Triangle_2.h>

typedef CGAL::Triangle_2<EEK> Triangle2;

void* Triangle2_EEK_Create(const Point2d& a, const Point2d& b, const Point2d& c)
{
	auto A = a.ToCGAL<EEK>();
	auto B = b.ToCGAL<EEK>();
	auto C = c.ToCGAL<EEK>();

	return new Triangle2(A, B, C);
}

void Triangle2_EEK_Release(void* ptr)
{
	auto obj = static_cast<Triangle2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

Triangle2* CastToTriangle2(void* ptr)
{
	return static_cast<Triangle2*>(ptr);
}
