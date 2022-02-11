
#include "Ray2_EEK.h"
#include <CGAL/Ray_2.h>

typedef CGAL::Ray_2<EEK> Ray2;

void* Ray2_EEK_Create(const Point2d& position, const Vector2d& direction)
{
	auto p = position.ToCGAL<EEK>();
	auto d = direction.ToCGAL<EEK>();

	return new Ray2(p, d);
}

void Ray2_EEK_Release(void* ptr)
{
	auto obj = static_cast<Ray2*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

Ray2* CastToRay2(void* ptr)
{
	return static_cast<Ray2*>(ptr);
}
