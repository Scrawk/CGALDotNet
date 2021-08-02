#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

extern "C"
{

	CGALWRAPPER_API void* PolygonVisibility2_EEK_Create();

	CGALWRAPPER_API void PolygonVisibility2_EEK_Release(void* ptr);

	CGALWRAPPER_API void* PolygonVisibility2_EEK_ComputeVisibility(Point2d point, Segment2d* segments, int startIndex, int count);

}