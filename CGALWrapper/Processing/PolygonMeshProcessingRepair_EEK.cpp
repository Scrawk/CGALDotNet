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

int PolygonMeshProcessingRepair_EEK_DegenerateHalfEdgeCount(void* ptr)
{
	return PolygonMeshProcessingRepair<EEK>::DegenerateHalfEdgeCount(ptr);
}

int PolygonMeshProcessingRepair_EEK_DegenerateTriangleCount(void* ptr)
{
	return PolygonMeshProcessingRepair<EEK>::DegenerateTriangleCount(ptr);
}

int PolygonMeshProcessingRepair_EEK_NeedleTriangleCount(void* ptr, double threshold)
{
	return PolygonMeshProcessingRepair<EEK>::NeedleTriangleCount(ptr, threshold);
}

int PolygonMeshProcessingRepair_EEK_NonManifoldVertexCount(void* ptr)
{
	return PolygonMeshProcessingRepair<EEK>::NonManifoldVertexCount(ptr);
}

void PolygonMeshProcessingRepair_EEK_RepairPolygonSoup(void* ptr)
{
	PolygonMeshProcessingRepair<EEK>::RepairPolygonSoup(ptr);
}

int PolygonMeshProcessingRepair_EEK_StitchBoundaryCycles(void* ptr)
{
	return PolygonMeshProcessingRepair<EEK>::StitchBoundaryCycles(ptr);
}

int PolygonMeshProcessingRepair_EEK_StitchBorders(void* ptr)
{
	return PolygonMeshProcessingRepair<EEK>::StitchBorders(ptr);
}

int PolygonMeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle(void* ptr)
{
	return PolygonMeshProcessingRepair<EEK>::MergeDuplicatedVerticesInBoundaryCycle(ptr);
}

int PolygonMeshProcessingRepair_EEK_RemoveIsolatedVertices(void* ptr)
{
	return PolygonMeshProcessingRepair<EEK>::RemoveIsolatedVertices(ptr);
}

void PolygonMeshProcessingRepair_EEK_PolygonMeshToPolygonSoup(void* ptr, int* triangles, int triangleCount, int* quads, int quadCount)
{
	PolygonMeshProcessingRepair<EEK>::PolygonMeshToPolygonSoup(ptr, triangles, triangleCount, quads, quadCount);
}
