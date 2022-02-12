#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Polyhedra/MeshHitResult.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingLocate_EIK_Create();

	CGALWRAPPER_API void MeshProcessingLocate_EIK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API Point3d MeshProcessingLocate_EIK_RandomLocationOnMesh_PH(void* ptr);

	CGALWRAPPER_API MeshHitResult MeshProcessingLocate_EIK_LocateFaceRay_PH(void* ptr, const Ray3d& ray);

	CGALWRAPPER_API MeshHitResult MeshProcessingLocate_EIK_LocateFacePoint_PH(void* ptr, const Point3d& point);

	//SurfaceMesh

	CGALWRAPPER_API Point3d MeshProcessingLocate_EIK_RandomLocationOnMesh_SM(void* ptr);

	CGALWRAPPER_API MeshHitResult MeshProcessingLocate_EIK_LocateFaceRay_SM(void* ptr, const Ray3d& ray);

	CGALWRAPPER_API MeshHitResult MeshProcessingLocate_EIK_LocateFacePoint_SM(void* ptr, const Point3d& point);
}

