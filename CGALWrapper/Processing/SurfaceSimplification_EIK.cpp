#include "SurfaceSimplification_EIK.h"
#include "SurfaceSimplification.h"

void* SurfaceSimplification_EIK_Create()
{
	return SurfaceSimplification<EIK>::NewSimplification();
}

void SurfaceSimplification_EIK_Release(void* ptr)
{
	SurfaceSimplification<EIK>::DeleteSurfaceSimplification(ptr);
}

void SurfaceSimplification_EIK_Simplify_PH(void* meshPtr, double stop_ratio)
{
	SurfaceSimplification<EIK>::Simplify_PH(meshPtr, stop_ratio);
}

void SurfaceSimplification_EIK_Simplify_SM(void* meshPtr, double stop_ratio)
{
	SurfaceSimplification<EIK>::Simplify_SM(meshPtr, stop_ratio);
}
