#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonPartition2_EEK_Create();

	CGALWRAPPER_API void PolygonPartition2_EEK_Release(void* ptr);

	CGALWRAPPER_API BOOL PolygonPartition2_Is_Y_Monotone(void* ptr, void* polyPtr);

	CGALWRAPPER_API void  PolygonPartition2_Y_MonotonePartition2(void* ptr, void* polyPtr);

}

