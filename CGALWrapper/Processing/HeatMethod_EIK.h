#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* HeatMethod_EIK_Create();

	CGALWRAPPER_API void HeatMethod_EIK_Release(void* ptr);

	CGALWRAPPER_API double HeatMethod_EIK_GetDistance(void* ptr, int index);

	CGALWRAPPER_API void HeatMethod_EIK_ClearDistances(void* ptr);

	CGALWRAPPER_API int HeatMethod_EIK_EstimateGeodesicDistances_SM(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT);

	CGALWRAPPER_API int HeatMethod_EIK_EstimateGeodesicDistances_PH(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT);
}

