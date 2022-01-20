#include "PolygonMeshProcessingConnections_EEK.h"
#include "PolygonMeshProcessingConnections.h"

void* PolygonMeshProcessingConnections_EEK_Create()
{
	return PolygonMeshProcessingConnections<EEK>::NewPolygonMeshProcessingConnections();
}

void PolygonMeshProcessingConnections_EEK_Release(void* ptr)
{
	PolygonMeshProcessingConnections<EEK>::DeletePolygonMeshProcessingConnections(ptr);
}

void PolygonMeshProcessingConnections_EEK_PolyhedronConnectedComponents(void* polyPtr)
{
	PolygonMeshProcessingConnections<EEK>::PolyhedronConnectedComponents(polyPtr);
}

int PolygonMeshProcessingConnections_EEK_PolyhedronSplitConnectedComponents(void* polyPtr)
{
	return PolygonMeshProcessingConnections<EEK>::PolyhedronSplitConnectedComponents(polyPtr);
}

int PolygonMeshProcessingConnections_EEK_PolyhedronKeepLargestConnectedComponents(void* polyPtr, int nb_components_to_keep)
{
	return PolygonMeshProcessingConnections<EEK>::PolyhedronKeepLargestConnectedComponents(polyPtr, nb_components_to_keep);
}
