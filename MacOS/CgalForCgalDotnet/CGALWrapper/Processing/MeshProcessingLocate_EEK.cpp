#include "MeshProcessingLocate_EEK.h"
#include "MeshProcessingLocate.h"

void* MeshProcessingLocate_EEK_Create()
{
	return MeshProcessingLocate<EEK>::NewMeshProcessingLocate();
}

void MeshProcessingLocate_EEK_Release(void* ptr)
{
	MeshProcessingLocate<EEK>::DeleteMeshProcessingLocate(ptr);
}

//Polyhedron

Point3d MeshProcessingLocate_EEK_RandomLocationOnMesh_PH(void* ptr)
{
	return MeshProcessingLocate<EEK>::RandomLocationOnMesh_PH(ptr);
}

MeshHitResult MeshProcessingLocate_EEK_LocateFaceRay_PH(void* ptr, const Ray3d& ray)
{
	return MeshProcessingLocate<EEK>::LocateFace_PH(ptr, ray);
}

MeshHitResult MeshProcessingLocate_EEK_LocateFacePoint_PH(void* ptr, const Point3d& point)
{
	return MeshProcessingLocate<EEK>::LocateFace_PH(ptr, point);
}

//SurfaceMesh

Point3d MeshProcessingLocate_EEK_RandomLocationOnMesh_SM(void* ptr)
{
	return MeshProcessingLocate<EEK>::RandomLocationOnMesh_SM(ptr);
}

MeshHitResult MeshProcessingLocate_EEK_LocateFaceRay_SM(void* ptr, const Ray3d& ray)
{
	return MeshProcessingLocate<EEK>::LocateFace_SM(ptr, ray);
}

MeshHitResult MeshProcessingLocate_EEK_LocateFacePoint_SM(void* ptr, const Point3d& point)
{
	return MeshProcessingLocate<EEK>::LocateFace_SM(ptr, point);
}