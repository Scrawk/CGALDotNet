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

//Polyhedron

int MeshProcessingRepair_EEK_DegenerateEdgeCount_PH(void* ptr)
{
	return MeshProcessingRepair<EEK>::DegenerateEdgeCount_PH(ptr);
}

int MeshProcessingRepair_EEK_DegenerateTriangleCount_PH(void* ptr)
{
	return MeshProcessingRepair<EEK>::DegenerateTriangleCount_PH(ptr);
}

int MeshProcessingRepair_EEK_NeedleTriangleCount_PH(void* ptr, double threshold)
{
	return MeshProcessingRepair<EEK>::NeedleTriangleCount_PH(ptr, threshold);
}

int MeshProcessingRepair_EEK_NonManifoldVertexCount_PH(void* ptr)
{
	return MeshProcessingRepair<EEK>::NonManifoldVertexCount_PH(ptr);
}

void MeshProcessingRepair_EEK_RepairPolygonSoup_PH(void* ptr)
{
	MeshProcessingRepair<EEK>::RepairPolygonSoup_PH(ptr);
}

int MeshProcessingRepair_EEK_StitchBoundaryCycles_PH(void* ptr)
{
	return MeshProcessingRepair<EEK>::StitchBoundaryCycles_PH(ptr);
}

int MeshProcessingRepair_EEK_StitchBorders_PH(void* ptr)
{
	return MeshProcessingRepair<EEK>::StitchBorders_PH(ptr);
}

int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle_PH(void* ptr, int index)
{
	return MeshProcessingRepair<EEK>::MergeDuplicatedVerticesInBoundaryCycle_PH(ptr, index);
}

int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycles_PH(void* ptr)
{
	return MeshProcessingRepair<EEK>::MergeDuplicatedVerticesInBoundaryCycles_PH(ptr);
}

int MeshProcessingRepair_EEK_RemoveIsolatedVertices_PH(void* ptr)
{
	return MeshProcessingRepair<EEK>::RemoveIsolatedVertices_PH(ptr);
}

//SurfaceMesh

int MeshProcessingRepair_EEK_DegenerateEdgeCount_SM(void* ptr)
{
	return MeshProcessingRepair<EEK>::DegenerateEdgeCount_SM(ptr);
}

int MeshProcessingRepair_EEK_DegenerateTriangleCount_SM(void* ptr)
{
	return MeshProcessingRepair<EEK>::DegenerateTriangleCount_SM(ptr);
}

int MeshProcessingRepair_EEK_NeedleTriangleCount_SM(void* ptr, double threshold)
{
	return MeshProcessingRepair<EEK>::NeedleTriangleCount_SM(ptr, threshold);
}

int MeshProcessingRepair_EEK_NonManifoldVertexCount_SM(void* ptr)
{
	return MeshProcessingRepair<EEK>::NonManifoldVertexCount_SM(ptr);
}

void MeshProcessingRepair_EEK_RepairPolygonSoup_SM(void* ptr)
{
	MeshProcessingRepair<EEK>::RepairPolygonSoup_SM(ptr);
}

int MeshProcessingRepair_EEK_StitchBoundaryCycles_SM(void* ptr)
{
	return MeshProcessingRepair<EEK>::StitchBoundaryCycles_SM(ptr);
}

int MeshProcessingRepair_EEK_StitchBorders_SM(void* ptr)
{
	return MeshProcessingRepair<EEK>::StitchBorders_SM(ptr);
}

int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle_SM(void* ptr, int index)
{
	return MeshProcessingRepair<EEK>::MergeDuplicatedVerticesInBoundaryCycle_SM(ptr, index);
}

int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycles_SM(void* ptr)
{
	return MeshProcessingRepair<EEK>::MergeDuplicatedVerticesInBoundaryCycles_SM(ptr);
}

int MeshProcessingRepair_EEK_RemoveIsolatedVertices_SM(void* ptr)
{
	return MeshProcessingRepair<EEK>::RemoveIsolatedVertices_SM(ptr);
}

