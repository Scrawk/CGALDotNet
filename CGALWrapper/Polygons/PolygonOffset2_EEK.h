#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* PolygonOffset2_EEK_Create();

	CGALWRAPPER_API void PolygonOffset2_EEK_Release(void* ptr);

	CGALWRAPPER_API int PolygonOffset2_EEK_PolygonBufferSize(void* ptr);

	CGALWRAPPER_API int PolygonOffset2_EEK_SegmentBufferSize(void* ptr);

	CGALWRAPPER_API void PolygonOffset2_EEK_ClearPolygonBuffer(void* ptr);

	CGALWRAPPER_API void PolygonOffset2_EEK_ClearSegmentBuffer(void* ptr);

	CGALWRAPPER_API void* PolygonOffset2_EEK_GetBufferedPolygon(void* ptr, int index);

	CGALWRAPPER_API Segment2d PolygonOffset2_EEK_GetSegment(void* ptr, int index);

	CGALWRAPPER_API void PolygonOffset2_EEK_GetSegments(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API void PolygonOffset2_EEK_CreateInteriorOffset(void* ptr, void* polyPtr, double offset);

	CGALWRAPPER_API void PolygonOffset2_EEK_CreateInteriorOffsetPWH(void* ptr, void* pwhPtr, double offset, BOOL boundaryOnly);

	CGALWRAPPER_API void PolygonOffset2_EEK_CreateExteriorOffset(void* ptr, void* polyPtr, double offset);

	CGALWRAPPER_API void PolygonOffset2_EEK_CreateExteriorOffsetPWH(void* ptr, void* pwhPtr, double offset, BOOL boundaryOnly);

	CGALWRAPPER_API void PolygonOffset2_EEK_CreateInteriorSkeleton(void* ptr, void* polyPtr, BOOL includeBorder);

	CGALWRAPPER_API void PolygonOffset2_EEK_CreateInteriorSkeletonPWH(void* ptr, void* pwhPtr, BOOL includeBorder);

	CGALWRAPPER_API void PolygonOffset2_EEK_CreateExteriorSkeleton(void* ptr, void* polyPtr, double maxOffset, BOOL includeBorder);

	CGALWRAPPER_API void PolygonOffset2_EEK_CreateExteriorSkeletonPWH(void* ptr, void* pwhPtr, double maxOffset, BOOL includeBorder);

}
