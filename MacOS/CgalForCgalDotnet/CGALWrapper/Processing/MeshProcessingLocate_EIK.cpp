#include "MeshProcessingLocate_EIK.h"
#include "MeshProcessingLocate.h"

void* MeshProcessingLocate_EIK_Create()
{
	return MeshProcessingLocate<EIK>::NewMeshProcessingLocate();
}

void MeshProcessingLocate_EIK_Release(void* ptr)
{
	MeshProcessingLocate<EIK>::DeleteMeshProcessingLocate(ptr);
}

//Polyhedron

Point3d MeshProcessingLocate_EIK_RandomLocationOnMesh_PH(void* ptr)
{
	return MeshProcessingLocate<EIK>::RandomLocationOnMesh_PH(ptr);
}

MeshHitResult MeshProcessingLocate_EIK_LocateFaceRay_PH(void* ptr, const Ray3d& ray)
{
	return MeshProcessingLocate<EIK>::LocateFace_PH(ptr, ray);
}

MeshHitResult MeshProcessingLocate_EIK_LocateFacePoint_PH(void* ptr, const Point3d& point)
{
	return MeshProcessingLocate<EIK>::LocateFace_PH(ptr, point);
}

//SurfaceMesh

Point3d MeshProcessingLocate_EIK_RandomLocationOnMesh_SM(void* ptr)
{
	return MeshProcessingLocate<EIK>::RandomLocationOnMesh_SM(ptr);
}

MeshHitResult MeshProcessingLocate_EIK_LocateFaceRay_SM(void* ptr, const Ray3d& ray)
{
	return MeshProcessingLocate<EIK>::LocateFace_SM(ptr, ray);
}

MeshHitResult MeshProcessingLocate_EIK_LocateFacePoint_SM(void* ptr, const Point3d& point)
{
	return MeshProcessingLocate<EIK>::LocateFace_SM(ptr, point);
}