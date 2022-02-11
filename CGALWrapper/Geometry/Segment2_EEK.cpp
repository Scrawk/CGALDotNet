
#include "Segment2_EEK.h"
#include <CGAL/Segment_2.h>

typedef CGAL::Segment_2<EEK> Segment2;

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

Segment2* CastToSegment2(void* ptr)
{
	return static_cast<Segment2*>(ptr);
}
