#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

extern "C"
{

	CGALWRAPPER_API void* PolygonPartition2_EIK_Create();

	CGALWRAPPER_API void PolygonPartition2_EIK_Release(void* ptr);

	CGALWRAPPER_API void PolygonPartition2_EIK_ClearBuffer(void* ptr);

	CGALWRAPPER_API int PolygonPartition2_EIK_BufferCount(void* ptr);

	CGALWRAPPER_API void* PolygonPartition2_EIK_CopyBufferItem(void* ptr, int index);

	CGALWRAPPER_API BOOL PolygonPartition2_EIK_Is_Y_Monotone(void* ptr, void* polyPtr);

	CGALWRAPPER_API BOOL PolygonPartition2_EIK_Is_Y_MonotonePWH(void* ptr, void* polyPtr);

	CGALWRAPPER_API BOOL PolygonPartition2_EIK_PartitionIsValid(void* ptr, void* polyPtr);

	CGALWRAPPER_API BOOL PolygonPartition2_EIK_ConvexPartitionIsValid(void* ptr, void* polyPtr);

	CGALWRAPPER_API int  PolygonPartition2_EIK_Y_MonotonePartition(void* ptr, void* polyPtr);

	CGALWRAPPER_API int  PolygonPartition2_EIK_Y_MonotonePartitionPWH(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EIK_ApproxConvexPartition(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EIK_ApproxConvexPartitionPWH(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EIK_GreeneApproxConvexPartition(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EIK_GreeneApproxConvexPartitionPWH(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EIK_OptimalConvexPartition(void* ptr, void* polyPtr);

	CGALWRAPPER_API int PolygonPartition2_EIK_OptimalConvexPartitionPWH(void* ptr, void* polyPtr);

}

