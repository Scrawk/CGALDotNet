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

//Polyhedron

void SurfaceSubdivision_EIK_Subdive_CatmullClark_PH(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EIK>::Subdive_CatmullClark_PH(meshPtr, iterations);
}

void SurfaceSubdivision_EIK_Subdive_Loop_PH(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EIK>::Subdive_Loop_PH(meshPtr, iterations);
}

void SurfaceSubdivision_EIK_Subdive_Sqrt3_PH(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EIK>::Subdive_Sqrt3_PH(meshPtr, iterations);
}

void SurfaceSubdivision_EIK_Subdive_DooSabin_PH(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EIK>::Subdive_DooSabin_PH(meshPtr, iterations);
}

//Surface Mesh

void SurfaceSubdivision_EIK_Subdive_CatmullClark_SM(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EIK>::Subdive_CatmullClark_SM(meshPtr, iterations);
}

void SurfaceSubdivision_EIK_Subdive_Loop_SM(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EIK>::Subdive_Loop_SM(meshPtr, iterations);
}

void SurfaceSubdivision_EIK_Subdive_Sqrt3_SM(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EIK>::Subdive_Loop_SM(meshPtr, iterations);
}

void SurfaceSubdivision_EIK_Subdive_DooSabin_SM(void* meshPtr, int iterations)
{
	SurfaceSubdivision<EIK>::Subdive_Loop_SM(meshPtr, iterations);
}
