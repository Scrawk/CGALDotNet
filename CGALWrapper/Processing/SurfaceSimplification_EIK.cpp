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

void SurfaceSimplification_EIK_SimplifyPolyhedron(void* polyPtr, double stop_ratio)
{
	SurfaceSimplification<EIK>::SimplifyPolyhedron(polyPtr, stop_ratio);
}
