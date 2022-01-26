#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonMeshProcessingConnections_EEK_Create();

	CGALWRAPPER_API void PolygonMeshProcessingConnections_EEK_Release(void* ptr);

	//Polyhedron 
	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_ConnectedComponents_PH(void* meshPtr);

	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_ConnectedComponent_PH(void* meshPtr, int index);

	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_SplitConnectedComponents_PH(void* ptr, void* meshPtr);

	CGALWRAPPER_API void PolygonMeshProcessingConnections_EEK_GetSplitConnectedComponents_PH(void* ptr, void** meshPtrs, int count);

	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_KeepLargestConnectedComponents_PH(void* meshPtr, int nb_components_to_keep);

	//Surface Mesh
	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_ConnectedComponents_SM(void* meshPtr);

	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_ConnectedComponent_SM(void* meshPtr, int index);

	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_SplitConnectedComponents_SM(void* ptr, void* meshPtr);

	CGALWRAPPER_API void PolygonMeshProcessingConnections_EEK_GetSplitConnectedComponents_SM(void* ptr, void** meshPtrs, int count);

	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_KeepLargestConnectedComponents_SM(void* meshPtr, int nb_components_to_keep);
}

