#include "PolygonMeshProcessingConnected_EEK.h"
#include "PolygonMeshProcessingConnected.h"

void* PolygonMeshProcessingConnected_EEK_Create()
{
	return PolygonMeshProcessingConnected<EEK>::NewPolygonMeshProcessingConnected();
}

void PolygonMeshProcessingConnected_EEK_Release(void* ptr)
{
	PolygonMeshProcessingConnected<EEK>::DeletePolygonMeshProcessingConnected(ptr);
}
