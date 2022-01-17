#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonMeshProcessingMeshing_EEK_Create();

	CGALWRAPPER_API void PolygonMeshProcessingMeshing_EEK_Release(void* ptr);

	CGALWRAPPER_API void PolygonMeshProcessingMeshing_EEK_Extrude(void* polyPtr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingMeshing_EEK_Fair(void* polyPtr);

	CGALWRAPPER_API int PolygonMeshProcessingMeshing_EEK_Refine(void* polyPtr, double density_control_factor);

	CGALWRAPPER_API void PolygonMeshProcessingMeshing_EEK_IsotropicRemeshing(void* polyPtr, int iterations, double target_edge_length);

	CGALWRAPPER_API void PolygonMeshProcessingMeshing_EEK_RandomPerturbation(void* polyPtr, double perturbation_max_size);

	CGALWRAPPER_API void PolygonMeshProcessingMeshing_EEK_SmoothMesh(void* polyPtr);

	CGALWRAPPER_API void PolygonMeshProcessingMeshing_EEK_SmoothShape(void* polyPtr);

	CGALWRAPPER_API void PolygonMeshProcessingMeshing_EEK_SplitLongEdges(void* polyPtr, double target_edge_length);

}

