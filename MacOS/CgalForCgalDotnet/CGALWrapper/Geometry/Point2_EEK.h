#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API void* Point2_EEK_Create();

	CGALWRAPPER_API void* Point2_EEK_CreateFromPoint(const Point2d& point);

	CGALWRAPPER_API void Point2_EEK_Release(void* ptr);

	CGALWRAPPER_API double Point2_EEK_GetX(void* ptr);

	CGALWRAPPER_API double Point2_EEK_GetY(void* ptr);

	CGALWRAPPER_API void Point2_EEK_SetX(void* ptr, double x);

	CGALWRAPPER_API void Point2_EEK_SetY(void* ptr, double y);

	CGALWRAPPER_API void* Point2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void* Point2_EEK_Convert(void* ptr, CGAL_KERNEL k);

}

