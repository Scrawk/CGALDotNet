#include "SurfaceSubdivision_EIK.h"
#include "SurfaceSubdivision.h"

void* SurfaceSubdivision_EIK_Create()
{
	return SurfaceSubdivision<EIK>::NewSurfaceSubdivision();
}

void SurfaceSubdivision_EIK_Release(void* ptr)
{
	SurfaceSubdivision<EIK>::DeleteSurfaceSubdivision(ptr);
}

void SurfaceSubdivision_EIK_SubdivePolyhedron_CatmullClark(void* polyPtr, int iterations)
{
	SurfaceSubdivision<EIK>::SubdivePolyhedron_CatmullClark(polyPtr, iterations);
}

void SurfaceSubdivision_EIK_SubdivePolyhedron_Loop(void* polyPtr, int iterations)
{
	SurfaceSubdivision<EIK>::SubdivePolyhedron_Loop(polyPtr, iterations);
}

void SurfaceSubdivision_EIK_SubdivePolyhedron_Sqrt3(void* polyPtr, int iterations)
{
	SurfaceSubdivision<EIK>::SubdivePolyhedron_Sqrt3(polyPtr, iterations);
}
