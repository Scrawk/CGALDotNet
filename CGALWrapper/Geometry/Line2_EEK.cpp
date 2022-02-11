
#include "Line2_EEK.h"
#include <CGAL/Line_2.h>

typedef CGAL::Line_2<EEK> Line2;

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

Line2* CastToLine2(void* ptr)
{
	return static_cast<Line2*>(ptr);
}
