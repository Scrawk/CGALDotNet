#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonMeshProcessingConnections_EEK_Create();

	CGALWRAPPER_API void PolygonMeshProcessingConnections_EEK_Release(void* ptr);

	CGALWRAPPER_API void PolygonMeshProcessingConnections_EEK_PolyhedronConnectedComponents(void* polyPtr);

	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_PolyhedronSplitConnectedComponents(void* ptr, void* polyPtr);

	CGALWRAPPER_API void PolygonMeshProcessingConnections_EEK_PolyhedronGetSplitConnectedComponents(void* ptr, void** polyPtrs, int count);

	CGALWRAPPER_API int PolygonMeshProcessingConnections_EEK_PolyhedronKeepLargestConnectedComponents(void* polyPtr, int nb_components_to_keep);

}

