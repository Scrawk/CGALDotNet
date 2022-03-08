#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API void* Point2_EIK_Create();

	CGALWRAPPER_API void* Point2_EIK_CreateFromPoint(const Point2d& point);

	CGALWRAPPER_API void Point2_EIK_Release(void* ptr);

	CGALWRAPPER_API double Point2_EIK_GetX(void* ptr);

	CGALWRAPPER_API double Point2_EIK_GetY(void* ptr);

	CGALWRAPPER_API void Point2_EIK_SetX(void* ptr, double x);

	CGALWRAPPER_API void Point2_EIK_SetY(void* ptr, double y);

	CGALWRAPPER_API void* Point2_EIK_Copy(void* ptr);

	CGALWRAPPER_API void* Point2_EIK_Convert(void* ptr, CGAL_KERNEL k);

}

