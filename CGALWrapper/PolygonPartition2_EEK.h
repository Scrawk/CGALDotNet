#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

extern "C"
{

	CGALWRAPPER_API void* PolygonPartition2_EEK_Create();

	CGALWRAPPER_API void PolygonPartition2_EEK_Release(void* ptr);

	CGALWRAPPER_API void PolygonPartition2_EEK_ClearBuffer(void* ptr);

	CGALWRAPPER_API int PolygonPartition2_EEK_BufferCount(void* ptr);

	CGALWRAPPER_API void* PolygonPartition2_EEK_CopyBufferItem(void* ptr, int index);

	CGALWRAPPER_API BOOL PolygonPartition2_EEK_Is_Y_Monotone(void* ptr, void* polyPtr);

	CGALWRAPPER_API BOOL PolygonPartition2_EEK_ConvexPartitionIsValid(void* ptr, void* polyPtr);

	CGALWRAPPER_API int  PolygonPartition2_EEK_Y_MonotonePartition(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EEK_ApproxConvexPartition(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EEK_GreeneApproxConvexPartition(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EEK_OptimalConvexPartition(void* ptr, void* polyPtr);

}

