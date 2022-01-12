#include "SurfaceSubdivision_EEK.h"
#include "SurfaceSubdivision.h"

void* SurfaceSubdivision_EEK_Create()
{
	return SurfaceSubdivision<EEK>::NewSurfaceSubdivision();
}

void SurfaceSubdivision_EEK_Release(void* ptr)
{
	SurfaceSubdivision<EEK>::DeleteSurfaceSubdivision(ptr);
}

void SurfaceSubdivision_EEK_SubdivePolyhedron_CatmullClark(void* polyPtr, int iterations)
{
	SurfaceSubdivision<EEK>::SubdivePolyhedron_CatmullClark(polyPtr, iterations);
}

void SurfaceSubdivision_EEK_SubdivePolyhedron_Loop(void* polyPtr, int iterations)
{
	SurfaceSubdivision<EEK>::SubdivePolyhedron_Loop(polyPtr, iterations);
}

void SurfaceSubdivision_EEK_SubdivePolyhedron_Sqrt3(void* polyPtr, int iterations)
{
	SurfaceSubdivision<EEK>::SubdivePolyhedron_Sqrt3(polyPtr, iterations);
}
