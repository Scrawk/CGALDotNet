#include "MeshProcessingRepair_EEK.h"
#include "MeshProcessingRepair.h"

void* MeshProcessingRepair_EEK_Create()
{
	return MeshProcessingRepair<EEK>::NewMeshProcessingRepair();
}

void MeshProcessingRepair_EEK_Release(void* ptr)
{
	MeshProcessingRepair<EEK>::DeleteMeshProcessingRepair(ptr);
}

int MeshProcessingRepair_EEK_DegenerateHalfEdgeCount(void* ptr)
{
	return MeshProcessingRepair<EEK>::DegenerateHalfEdgeCount(ptr);
}

int MeshProcessingRepair_EEK_DegenerateTriangleCount(void* ptr)
{
	return MeshProcessingRepair<EEK>::DegenerateTriangleCount(ptr);
}

int MeshProcessingRepair_EEK_NeedleTriangleCount(void* ptr, double threshold)
{
	return MeshProcessingRepair<EEK>::NeedleTriangleCount(ptr, threshold);
}

int MeshProcessingRepair_EEK_NonManifoldVertexCount(void* ptr)
{
	return MeshProcessingRepair<EEK>::NonManifoldVertexCount(ptr);
}

void MeshProcessingRepair_EEK_RepairPolygonSoup(void* ptr)
{
	MeshProcessingRepair<EEK>::RepairPolygonSoup(ptr);
}

int MeshProcessingRepair_EEK_StitchBoundaryCycles(void* ptr)
{
	return MeshProcessingRepair<EEK>::StitchBoundaryCycles(ptr);
}

int MeshProcessingRepair_EEK_StitchBorders(void* ptr)
{
	return MeshProcessingRepair<EEK>::StitchBorders(ptr);
}

int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle(void* ptr)
{
	return MeshProcessingRepair<EEK>::MergeDuplicatedVerticesInBoundaryCycle(ptr);
}

int MeshProcessingRepair_EEK_RemoveIsolatedVertices(void* ptr)
{
	return MeshProcessingRepair<EEK>::RemoveIsolatedVertices(ptr);
}

void MeshProcessingRepair_EEK_PolygonMeshToPolygonSoup(void* ptr, int* triangles, int triangleCount, int* quads, int quadCount)
{
	MeshProcessingRepair<EEK>::PolygonMeshToPolygonSoup(ptr, triangles, triangleCount, quads, quadCount);
}
