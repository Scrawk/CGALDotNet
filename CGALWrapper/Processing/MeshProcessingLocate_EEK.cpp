#include "MeshProcessingLocate_EEK.h"
#include "MeshProcessingLocate.h"

void* MeshProcessingLocate_EEK_Create()
{
	return MeshProcessingLocate<EEK>::NewMeshProcessingLocate();
}

void MeshProcessingLocate_EEK_Release(void* ptr)
{
	MeshProcessingLocate<EEK>::DeleteMeshProcessingLocate(ptr);
}

Point3d MeshProcessingLocate_EEK_RandomLocationOnMesh_PH(void* ptr)
{
	return MeshProcessingLocate<EEK>::RandomLocationOnMesh_PH(ptr);
}

BOOL MeshProcessingLocate_EEK_RandomLocationOnFace_PH(void* ptr, int index, Point3d& point)
{
	return MeshProcessingLocate<EEK>::RandomLocationOnFace_PH(ptr, index, point);
}