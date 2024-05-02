#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "SweepLine.h"

extern "C"
{
	CGALWRAPPER_API void* SweepLine2_EIK_Create();

	CGALWRAPPER_API void SweepLine2_EIK_Release(void* ptr);

	CGALWRAPPER_API void SweepLine2_EIK_ClearPointBuffer(void* ptr);

	CGALWRAPPER_API void SweepLine2_EIK_ClearSegmentBuffer(void* ptr);

	CGALWRAPPER_API int SweepLine2_EIK_PointBufferSize(void* ptr);

	CGALWRAPPER_API int SweepLine2_EIK_SegmentBufferSize(void* ptr);

	CGALWRAPPER_API BOOL SweepLine2_EIK_DoIntersect(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API int SweepLine2_EIK_ComputeSubcurves(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API int SweepLine2_EIK_ComputeIntersectionPoints(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API void SweepLine2_EIK_GetPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void SweepLine2_EIK_GetSegments(void* ptr, Segment2d* segments, int count);
}
