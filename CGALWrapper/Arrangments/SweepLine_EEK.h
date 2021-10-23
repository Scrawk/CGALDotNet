#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "SweepLine.h"

extern "C"
{
	CGALWRAPPER_API void* SweepLine2_EEK_Create();

	CGALWRAPPER_API void SweepLine2_EEK_Release(void* ptr);

	CGALWRAPPER_API void SweepLine2_EEK_ClearPointBuffer(void* ptr);

	CGALWRAPPER_API void SweepLine2_EEK_ClearSegmentBuffer(void* ptr);

	CGALWRAPPER_API int SweepLine2_EEK_PointBufferSize(void* ptr);

	CGALWRAPPER_API int SweepLine2_EEK_SegmentBufferSize(void* ptr);

	CGALWRAPPER_API BOOL SweepLine2_EEK_DoIntersect(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API int SweepLine2_EEK_ComputeSubcurves(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API int SweepLine2_EEK_ComputeIntersectionPoints(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API void SweepLine2_EEK_GetPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void SweepLine2_EEK_GetSegments(void* ptr, Segment2d* segments, int count);
}
