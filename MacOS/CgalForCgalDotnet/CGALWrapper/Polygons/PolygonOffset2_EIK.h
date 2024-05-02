#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* PolygonOffset2_EIK_Create();

	CGALWRAPPER_API void PolygonOffset2_EIK_Release(void* ptr);

	CGALWRAPPER_API int PolygonOffset2_EIK_PolygonBufferSize(void* ptr);

	CGALWRAPPER_API int PolygonOffset2_EIK_SegmentBufferSize(void* ptr);

	CGALWRAPPER_API void PolygonOffset2_EIK_ClearPolygonBuffer(void* ptr);

	CGALWRAPPER_API void PolygonOffset2_EIK_ClearSegmentBuffer(void* ptr);

	CGALWRAPPER_API void* PolygonOffset2_EIK_GetBufferedPolygon(void* ptr, int index);

	CGALWRAPPER_API Segment2d PolygonOffset2_EIK_GetSegment(void* ptr, int index);

	CGALWRAPPER_API void PolygonOffset2_EIK_GetSegments(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateInteriorOffset(void* ptr, void* polyPtr, double offset);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateInteriorOffsetPWH(void* ptr, void* pwhPtr, double offset, BOOL boundaryOnly);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateExteriorOffset(void* ptr, void* polyPtr, double offset);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateExteriorOffsetPWH(void* ptr, void* pwhPtr, double offset, BOOL boundaryOnly);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateInteriorSkeleton(void* ptr, void* polyPtr, BOOL includeBorder);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateInteriorSkeletonPWH(void* ptr, void* pwhPtr, BOOL includeBorder);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateExteriorSkeleton(void* ptr, void* polyPtr, double maxOffset, BOOL includeBorder);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateExteriorSkeletonPWH(void* ptr, void* pwhPtr, double maxOffset, BOOL includeBorder);

}
