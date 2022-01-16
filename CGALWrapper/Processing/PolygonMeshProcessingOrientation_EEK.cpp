#include "PolygonMeshProcessingOrientation_EEK.h"
#include "PolygonMeshProcessingOrientation.h"

void* PolygonMeshProcessingOrientation_EEK_Create()
{
	return PolygonMeshProcessingOrientation<EEK>::NewPolygonMeshProcessingOrientation();
}

void PolygonMeshProcessingOrientation_EEK_Release(void* ptr)
{
	PolygonMeshProcessingOrientation<EEK>::DeletePolygonMeshProcessingOrientation(ptr);
}
