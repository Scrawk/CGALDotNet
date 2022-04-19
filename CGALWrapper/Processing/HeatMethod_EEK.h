#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* HeatMethod_EEK_Create();

	CGALWRAPPER_API void HeatMethod_EEK_Release(void* ptr);

	CGALWRAPPER_API double HeatMethod_EEK_GetDistance(void* ptr, int index);

	CGALWRAPPER_API void HeatMethod_EEK_ClearDistances(void* ptr);

	CGALWRAPPER_API int HeatMethod_EEK_EstimateGeodesicDistances_SM(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT);

	CGALWRAPPER_API int HeatMethod_EEK_EstimateGeodesicDistances_PH(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT);
}

