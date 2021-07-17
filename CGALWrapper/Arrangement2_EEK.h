#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "Arrangement2.h"

extern "C"
{
	CGALWRAPPER_API void* Arrangement2_EEK_Create();

	CGALWRAPPER_API void* Arrangement2_EEK_CreateFromSegments(Segment2d* segments, int startIndex, int count);

	CGALWRAPPER_API void Arrangement2_EEK_Release(void* ptr);

	CGALWRAPPER_API int Arrangement2_EEK_ElementCount(void* ptr, ARRANGEMENT2_ELEMENT element);
}
