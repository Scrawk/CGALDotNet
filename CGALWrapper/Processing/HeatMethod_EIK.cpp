#include "HeatMethod_EIK.h"
#include "HeatMethod.h"

void* HeatMethod_EIK_Create()
{
	return HeatMethod<EIK>::NewHeatMethod();
}

void HeatMethod_EIK_Release(void* ptr)
{
	HeatMethod<EIK>::DeleteHeatMethod(ptr);
}

double HeatMethod_EIK_GetDistance(void* ptr, int index)
{
	return HeatMethod<EIK>::GetDistance(ptr, index);
}

void HeatMethod_EIK_ClearDistances(void* ptr)
{
	HeatMethod<EIK>::ClearDistances(ptr);
}

int HeatMethod_EIK_EstimateGeodesicDistances_SM(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT)
{
	return HeatMethod<EIK>::EstimateGeodesicDistances_SM(ptr, meshPtr, vertexIndex, useIDT);
}

int HeatMethod_EIK_EstimateGeodesicDistances_PH(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT)
{
	return HeatMethod<EIK>::EstimateGeodesicDistances_PH(ptr, meshPtr, vertexIndex, useIDT);
}
