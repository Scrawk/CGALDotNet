#include "PolygonMeshProcessingMeshing_EEK.h"
#include "PolygonMeshProcessingMeshing.h"

void* PolygonMeshProcessingMeshing_EEK_Create()
{
	return PolygonMeshProcessingMeshing<EEK>::NewPolygonMeshProcessingMeshing();
}

void PolygonMeshProcessingMeshing_EEK_Release(void* ptr)
{
	PolygonMeshProcessingMeshing<EEK>::DeletePolygonMeshProcessingMeshing(ptr);
}
