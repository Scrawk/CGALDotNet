#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Line2_EEK_Create(double a, double b, double c);

	CGALWRAPPER_API void Line2_EEK_Release(void* ptr);
}

