#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingConnections_EIK_Create();

	CGALWRAPPER_API void MeshProcessingConnections_EIK_Release(void* ptr);

	//Polyhedron 
	CGALWRAPPER_API int MeshProcessingConnections_EIK_ConnectedComponents_PH(void* meshPtr);

	CGALWRAPPER_API int MeshProcessingConnections_EIK_ConnectedComponent_PH(void* ptr, void* meshPtr, int index);

	CGALWRAPPER_API void MeshProcessingConnections_EIK_GetConnectedComponentsFaceIndex_PH(void* ptr, void* meshPtr, int* indices, int count);

	CGALWRAPPER_API int MeshProcessingConnections_EIK_SplitConnectedComponents_PH(void* ptr, void* meshPtr);

	CGALWRAPPER_API void MeshProcessingConnections_EIK_GetSplitConnectedComponents_PH(void* ptr, void** meshPtrs, int count);

	CGALWRAPPER_API int MeshProcessingConnections_EIK_KeepLargeConnectedComponents_PH(void* meshPtr, int threshold_value);

	CGALWRAPPER_API int MeshProcessingConnections_EIK_KeepLargestConnectedComponents_PH(void* meshPtr, int nb_components_to_keep);

	//Surface Mesh
	CGALWRAPPER_API int MeshProcessingConnections_EIK_ConnectedComponents_SM(void* meshPtr);

	CGALWRAPPER_API int MeshProcessingConnections_EIK_ConnectedComponent_SM(void* ptr, void* meshPtr, int index);

	CGALWRAPPER_API void MeshProcessingConnections_EIK_GetConnectedComponentsFaceIndex_SM(void* ptr, void* meshPtr, int* indices, int count);

	CGALWRAPPER_API int MeshProcessingConnections_EIK_SplitConnectedComponents_SM(void* ptr, void* meshPtr);

	CGALWRAPPER_API void MeshProcessingConnections_EIK_GetSplitConnectedComponents_SM(void* ptr, void** meshPtrs, int count);

	CGALWRAPPER_API int MeshProcessingConnections_EIK_KeepLargeConnectedComponents_SM(void* meshPtr, int threshold_value);

	CGALWRAPPER_API int MeshProcessingConnections_EIK_KeepLargestConnectedComponents_SM(void* meshPtr, int nb_components_to_keep);
}

