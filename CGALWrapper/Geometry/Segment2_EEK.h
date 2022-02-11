#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Segment2_EEK_Create(const Point2d& a, const Point2d& b);

	CGALWRAPPER_API void Segment2_EEK_Release(void* ptr);
}

