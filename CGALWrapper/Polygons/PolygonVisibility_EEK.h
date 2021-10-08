#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* PolygonVisibility_EEK_Create();

	CGALWRAPPER_API void PolygonVisibility_EEK_Release(void* ptr);

	CGALWRAPPER_API void* PolygonVisibility_EEK_ComputeVisibilitySimple(Point2d point, void* polyPtr);

	CGALWRAPPER_API void* PolygonVisibility_EEK_ComputeVisibilityTEV(Point2d point, void* pwhPtr);

	CGALWRAPPER_API void* PolygonVisibility_EEK_ComputeVisibilityRSV(Point2d point, void* pwhPtr);
}

