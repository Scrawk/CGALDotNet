#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Index.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingMeshing_EIK_Create();

	CGALWRAPPER_API void MeshProcessingMeshing_EIK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API void* MeshProcessingMeshing_EIK_Extrude_PH(void* meshPtr, Vector3d dir);

	CGALWRAPPER_API Index2 MeshProcessingMeshing_EIK_Fair_PH(void* meshPtr, int index, int k_ring);

	CGALWRAPPER_API Index2 MeshProcessingMeshing_EIK_Refine_PH(void* meshPtr, double density_control_factor);

	CGALWRAPPER_API int MeshProcessingMeshing_EIK_IsotropicRemeshing_PH(void* meshPtr, int iterations, double target_edge_length);

	CGALWRAPPER_API void MeshProcessingMeshing_EIK_RandomPerturbation_PH(void* meshPtr, double perturbation_max_size);

	CGALWRAPPER_API void MeshProcessingMeshing_EIK_SmoothMesh_PH(void* meshPtr, double featureAngle, int iterations);

	CGALWRAPPER_API void MeshProcessingMeshing_EIK_SmoothShape_PH(void* meshPtr, double timeStep, int iterations);

	CGALWRAPPER_API int MeshProcessingMeshing_EIK_SplitLongEdges_PH(void* meshPtr, double target_edge_length);

	CGALWRAPPER_API BOOL MeshProcessingMeshing_EIK_TriangulateFace_PH(void* meshPtr, int index);

	CGALWRAPPER_API BOOL MeshProcessingMeshing_EIK_TriangulateFaces_PH(void* meshPtr, int* faces, int count);

	//Surface Mesh

	CGALWRAPPER_API void* MeshProcessingMeshing_EIK_Extrude_SM(void* meshPtr, Vector3d dir);

	CGALWRAPPER_API Index2 MeshProcessingMeshing_EIK_Fair_SM(void* meshPtr, int index, int k_ring);

	CGALWRAPPER_API Index2 MeshProcessingMeshing_EIK_Refine_SM(void* meshPtr, double density_control_factor);

	CGALWRAPPER_API int MeshProcessingMeshing_EIK_IsotropicRemeshing_SM(void* meshPtr, int iterations, double target_edge_length);

	CGALWRAPPER_API void MeshProcessingMeshing_EIK_RandomPerturbation_SM(void* meshPtr, double perturbation_max_size);

	CGALWRAPPER_API void MeshProcessingMeshing_EIK_SmoothMesh_SM(void* meshPtr, double featureAngle, int iterations);

	CGALWRAPPER_API void MeshProcessingMeshing_EIK_SmoothShape_SM(void* meshPtr, double timeStep, int iterations);

	CGALWRAPPER_API int MeshProcessingMeshing_EIK_SplitLongEdges_SM(void* meshPtr, double target_edge_length);

	CGALWRAPPER_API BOOL MeshProcessingMeshing_EIK_TriangulateFace_SM(void* meshPtr, int index);

	CGALWRAPPER_API BOOL MeshProcessingMeshing_EIK_TriangulateFaces_SM(void* meshPtr, int* faces, int count);
}

