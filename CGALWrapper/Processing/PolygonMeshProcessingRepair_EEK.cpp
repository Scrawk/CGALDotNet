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
