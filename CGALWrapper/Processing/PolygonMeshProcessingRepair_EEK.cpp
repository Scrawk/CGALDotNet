#include "PolygonMeshProcessingRepair_EEK.h"
#include "PolygonMeshProcessingRepair.h"

void* PolygonMeshProcessingRepair_EEK_Create()
{
	return PolygonMeshProcessingRepair<EEK>::NewPolygonMeshProcessingRepair();
}

void PolygonMeshProcessingRepair_EEK_Release(void* ptr)
{
	PolygonMeshProcessingRepair<EEK>::DeletePolygonMeshProcessingRepair(ptr);
}
