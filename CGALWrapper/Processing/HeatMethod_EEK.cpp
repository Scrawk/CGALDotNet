#include "HeatMethod_EEK.h"
#include "HeatMethod.h"

void* HeatMethod_EEK_Create()
{
	return HeatMethod<EEK>::NewHeatMethod();
}

void HeatMethod_EEK_Release(void* ptr)
{
	HeatMethod<EEK>::DeleteHeatMethod(ptr);
}

double HeatMethod_EEK_GetDistance(void* ptr, int index)
{
	return HeatMethod<EEK>::GetDistance(ptr, index);
}

void HeatMethod_EEK_ClearDistances(void* ptr)
{
	HeatMethod<EEK>::ClearDistances(ptr);
}

int HeatMethod_EEK_EstimateGeodesicDistances_SM(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT)
{
	return HeatMethod<EEK>::EstimateGeodesicDistances_SM(ptr, meshPtr, vertexIndex, useIDT);
}

int HeatMethod_EEK_EstimateGeodesicDistances_PH(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT)
{
	return HeatMethod<EEK>::EstimateGeodesicDistances_PH(ptr, meshPtr, vertexIndex, useIDT);
}
