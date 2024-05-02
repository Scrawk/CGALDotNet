#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Circle2_EEK_Create(Point2d center, double sq_radius, CGAL::Orientation orientation);

	CGALWRAPPER_API void Circle2_EEK_Release(void* ptr);

};
