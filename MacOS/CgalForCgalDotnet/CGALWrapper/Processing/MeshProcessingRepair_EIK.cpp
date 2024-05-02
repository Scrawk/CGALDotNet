#include "MeshProcessingRepair_EIK.h"
#include "MeshProcessingRepair.h"

void* MeshProcessingRepair_EIK_Create()
{
	return MeshProcessingRepair<EIK>::NewMeshProcessingRepair();
}

void MeshProcessingRepair_EIK_Release(void* ptr)
{
	MeshProcessingRepair<EIK>::DeleteMeshProcessingRepair(ptr);
}

//Polyhedron

int MeshProcessingRepair_EIK_DegenerateEdgeCount_PH(void* ptr)
{
	return MeshProcessingRepair<EIK>::DegenerateEdgeCount_PH(ptr);
}

int MeshProcessingRepair_EIK_DegenerateTriangleCount_PH(void* ptr)
{
	return MeshProcessingRepair<EIK>::DegenerateTriangleCount_PH(ptr);
}

int MeshProcessingRepair_EIK_NeedleTriangleCount_PH(void* ptr, double threshold)
{
	return MeshProcessingRepair<EIK>::NeedleTriangleCount_PH(ptr, threshold);
}

int MeshProcessingRepair_EIK_NonManifoldVertexCount_PH(void* ptr)
{
	return MeshProcessingRepair<EIK>::NonManifoldVertexCount_PH(ptr);
}

void MeshProcessingRepair_EIK_RepairPolygonSoup_PH(void* ptr)
{
	MeshProcessingRepair<EIK>::RepairPolygonSoup_PH(ptr);
}

int MeshProcessingRepair_EIK_StitchBoundaryCycles_PH(void* ptr)
{
	return MeshProcessingRepair<EIK>::StitchBoundaryCycles_PH(ptr);
}

int MeshProcessingRepair_EIK_StitchBorders_PH(void* ptr)
{
	return MeshProcessingRepair<EIK>::StitchBorders_PH(ptr);
}

int MeshProcessingRepair_EIK_MergeDuplicatedVerticesInBoundaryCycle_PH(void* ptr, int index)
{
	return MeshProcessingRepair<EIK>::MergeDuplicatedVerticesInBoundaryCycle_PH(ptr, index);
}

int MeshProcessingRepair_EIK_MergeDuplicatedVerticesInBoundaryCycles_PH(void* ptr)
{
	return MeshProcessingRepair<EIK>::MergeDuplicatedVerticesInBoundaryCycles_PH(ptr);
}

int MeshProcessingRepair_EIK_RemoveIsolatedVertices_PH(void* ptr)
{
	return MeshProcessingRepair<EIK>::RemoveIsolatedVertices_PH(ptr);
}

//SurfaceMesh

int MeshProcessingRepair_EIK_DegenerateEdgeCount_SM(void* ptr)
{
	return MeshProcessingRepair<EIK>::DegenerateEdgeCount_SM(ptr);
}

int MeshProcessingRepair_EIK_DegenerateTriangleCount_SM(void* ptr)
{
	return MeshProcessingRepair<EIK>::DegenerateTriangleCount_SM(ptr);
}

int MeshProcessingRepair_EIK_NeedleTriangleCount_SM(void* ptr, double threshold)
{
	return MeshProcessingRepair<EIK>::NeedleTriangleCount_SM(ptr, threshold);
}

int MeshProcessingRepair_EIK_NonManifoldVertexCount_SM(void* ptr)
{
	return MeshProcessingRepair<EIK>::NonManifoldVertexCount_SM(ptr);
}

void MeshProcessingRepair_EIK_RepairPolygonSoup_SM(void* ptr)
{
	MeshProcessingRepair<EIK>::RepairPolygonSoup_SM(ptr);
}

int MeshProcessingRepair_EIK_StitchBoundaryCycles_SM(void* ptr)
{
	return MeshProcessingRepair<EIK>::StitchBoundaryCycles_SM(ptr);
}

int MeshProcessingRepair_EIK_StitchBorders_SM(void* ptr)
{
	return MeshProcessingRepair<EIK>::StitchBorders_SM(ptr);
}

int MeshProcessingRepair_EIK_MergeDuplicatedVerticesInBoundaryCycle_SM(void* ptr, int index)
{
	return MeshProcessingRepair<EIK>::MergeDuplicatedVerticesInBoundaryCycle_SM(ptr, index);
}

int MeshProcessingRepair_EIK_MergeDuplicatedVerticesInBoundaryCycles_SM(void* ptr)
{
	return MeshProcessingRepair<EIK>::MergeDuplicatedVerticesInBoundaryCycles_SM(ptr);
}

int MeshProcessingRepair_EIK_RemoveIsolatedVertices_SM(void* ptr)
{
	return MeshProcessingRepair<EIK>::RemoveIsolatedVertices_SM(ptr);
}

