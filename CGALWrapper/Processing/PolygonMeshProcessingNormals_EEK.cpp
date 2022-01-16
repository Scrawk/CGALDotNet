#include "PolygonMeshProcessingNormals_EEK.h"
#include "PolygonMeshProcessingNormals.h"

void* PolygonMeshProcessingNormals_EEK_Create()
{
	return PolygonMeshProcessingNormals<EEK>::NewPolygonMeshProcessingNormals();
}

void PolygonMeshProcessingNormals_EEK_Release(void* ptr)
{
	PolygonMeshProcessingNormals<EEK>::DeletePolygonMeshProcessingNormals(ptr);
}
