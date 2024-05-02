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

//Polyhedron

void SurfaceSubdivision_EEK_Subdive_CatmullClark_PH(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EEK>::Subdive_CatmullClark_PH(meshPtr, iterations);
}

void SurfaceSubdivision_EEK_Subdive_Loop_PH(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EEK>::Subdive_Loop_PH(meshPtr, iterations);
}

void SurfaceSubdivision_EEK_Subdive_Sqrt3_PH(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EEK>::Subdive_Sqrt3_PH(meshPtr, iterations);
}

void SurfaceSubdivision_EEK_Subdive_DooSabin_PH(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EEK>::Subdive_DooSabin_PH(meshPtr, iterations);
}

//Surface Mesh

void SurfaceSubdivision_EEK_Subdive_CatmullClark_SM(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EEK>::Subdive_CatmullClark_SM(meshPtr, iterations);
}

void SurfaceSubdivision_EEK_Subdive_Loop_SM(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EEK>::Subdive_Loop_SM(meshPtr, iterations);
}

void SurfaceSubdivision_EEK_Subdive_Sqrt3_SM(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EEK>::Subdive_Loop_SM(meshPtr, iterations);
}

void SurfaceSubdivision_EEK_Subdive_DooSabin_SM(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EEK>::Subdive_Loop_SM(meshPtr, iterations);
}
