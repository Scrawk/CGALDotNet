#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Index.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingMeshing_EEK_Create();

	CGALWRAPPER_API void MeshProcessingMeshing_EEK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API void* MeshProcessingMeshing_EEK_Extrude_PH(void* meshPtr, Vector3d dir);

	CGALWRAPPER_API Index2 MeshProcessingMeshing_EEK_Fair_PH(void* meshPtr, int index, int k_ring);

	CGALWRAPPER_API Index2 MeshProcessingMeshing_EEK_Refine_PH(void* meshPtr, double density_control_factor);

	CGALWRAPPER_API int MeshProcessingMeshing_EEK_IsotropicRemeshing_PH(void* meshPtr, int iterations, double target_edge_length);

	CGALWRAPPER_API void MeshProcessingMeshing_EEK_RandomPerturbation_PH(void* meshPtr, double perturbation_max_size);

	CGALWRAPPER_API void MeshProcessingMeshing_EEK_SmoothMesh_PH(void* meshPtr, double featureAngle, int iterations);

	CGALWRAPPER_API void MeshProcessingMeshing_EEK_SmoothShape_PH(void* meshPtr, double timeStep, int iterations);

	CGALWRAPPER_API int MeshProcessingMeshing_EEK_SplitLongEdges_PH(void* meshPtr, double target_edge_length);

	CGALWRAPPER_API BOOL MeshProcessingMeshing_EEK_TriangulateFace_PH(void* meshPtr, int index);

	CGALWRAPPER_API BOOL MeshProcessingMeshing_EEK_TriangulateFaces_PH(void* meshPtr, int* faces, int count);

	//Surface Mesh

	CGALWRAPPER_API void* MeshProcessingMeshing_EEK_Extrude_SM(void* meshPtr, Vector3d dir);

	CGALWRAPPER_API Index2 MeshProcessingMeshing_EEK_Fair_SM(void* meshPtr, int index, int k_ring);

	CGALWRAPPER_API Index2 MeshProcessingMeshing_EEK_Refine_SM(void* meshPtr, double density_control_factor);

	CGALWRAPPER_API int MeshProcessingMeshing_EEK_IsotropicRemeshing_SM(void* meshPtr, int iterations, double target_edge_length);

	CGALWRAPPER_API void MeshProcessingMeshing_EEK_RandomPerturbation_SM(void* meshPtr, double perturbation_max_size);

	CGALWRAPPER_API void MeshProcessingMeshing_EEK_SmoothMesh_SM(void* meshPtr, double featureAngle, int iterations);

	CGALWRAPPER_API void MeshProcessingMeshing_EEK_SmoothShape_SM(void* meshPtr, double timeStep, int iterations);

	CGALWRAPPER_API int MeshProcessingMeshing_EEK_SplitLongEdges_SM(void* meshPtr, double target_edge_length);

	CGALWRAPPER_API BOOL MeshProcessingMeshing_EEK_TriangulateFace_SM(void* meshPtr, int index);

	CGALWRAPPER_API BOOL MeshProcessingMeshing_EEK_TriangulateFaces_SM(void* meshPtr, int* faces, int count);
}

