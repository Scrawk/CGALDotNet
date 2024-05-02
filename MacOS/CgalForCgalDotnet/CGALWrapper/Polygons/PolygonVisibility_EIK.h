#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* PolygonVisibility_EIK_Create();

	CGALWRAPPER_API void PolygonVisibility_EIK_Release(void* ptr);

	CGALWRAPPER_API void* PolygonVisibility_EIK_ComputeVisibilitySimple(const Point2d& point, void* polyPtr);

	CGALWRAPPER_API void* PolygonVisibility_EIK_ComputeVisibilityTEV(const Point2d& point, void* pwhPtr);

	CGALWRAPPER_API void* PolygonVisibility_EIK_ComputeVisibilityRSV(const Point2d& point, void* pwhPtr);
}

