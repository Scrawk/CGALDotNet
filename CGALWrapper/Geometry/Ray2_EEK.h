#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Ray2_EEK_Create(const Point2d& position, const Vector2d& direction);

	CGALWRAPPER_API void Ray2_EEK_Release(void* ptr);
}

