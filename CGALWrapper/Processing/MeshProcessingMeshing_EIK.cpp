#include "MeshProcessingMeshing_EIK.h"
#include "MeshProcessingMeshing.h"

void* MeshProcessingMeshing_EIK_Create()
{
	return MeshProcessingMeshing<EIK>::NewMeshProcessingMeshing();
}

void MeshProcessingMeshing_EIK_Release(void* ptr)
{
	MeshProcessingMeshing<EIK>::DeleteMeshProcessingMeshing(ptr);
}

//Polyhedron

void* MeshProcessingMeshing_EIK_Extrude_PH(void* meshPtr, Vector3d dir)
{
	return MeshProcessingMeshing<EIK>::Extrude_PH(meshPtr, dir);
}

Index2 MeshProcessingMeshing_EIK_Fair_PH(void* meshPtr, int index, int k_ring)
{
	return MeshProcessingMeshing<EIK>::Fair_PH(meshPtr, index, k_ring);
}

Index2 MeshProcessingMeshing_EIK_Refine_PH(void* meshPtr, double density_control_factor)
{
	return MeshProcessingMeshing<EIK>::Refine_PH(meshPtr, density_control_factor);
}

int MeshProcessingMeshing_EIK_IsotropicRemeshing_PH(void* meshPtr, int iterations, double target_edge_length)
{
	return MeshProcessingMeshing<EIK>::IsotropicRemeshing_PH(meshPtr, iterations, target_edge_length);
}

void MeshProcessingMeshing_EIK_RandomPerturbation_PH(void* meshPtr, double perturbation_max_size)
{
	MeshProcessingMeshing<EIK>::RandomPerturbation_PH(meshPtr, perturbation_max_size);
}

void MeshProcessingMeshing_EIK_SmoothMesh_PH(void* meshPtr, double featureAngle, int iterations)
{
	MeshProcessingMeshing<EIK>::SmoothMesh_PH(meshPtr, featureAngle, iterations);
}

void MeshProcessingMeshing_EIK_SmoothShape_PH(void* meshPtr, double timeStep, int iterations)
{
	MeshProcessingMeshing<EIK>::SmoothShape_PH(meshPtr, timeStep, iterations);
}

int MeshProcessingMeshing_EIK_SplitLongEdges_PH(void* meshPtr, double target_edge_length)
{
	return MeshProcessingMeshing<EIK>::SplitLongEdges_PH(meshPtr, target_edge_length);
}

BOOL MeshProcessingMeshing_EIK_TriangulateFace_PH(void* meshPtr, int index)
{
	return MeshProcessingMeshing<EIK>::TriangulateFace_PH(meshPtr, index);
}

BOOL MeshProcessingMeshing_EIK_TriangulateFaces_PH(void* meshPtr, int* faces, int count)
{
	return MeshProcessingMeshing<EIK>::TriangulateFaces_PH(meshPtr, faces, count);
}

//Surface Mesh

void* MeshProcessingMeshing_EIK_Extrude_SM(void* meshPtr, Vector3d dir)
{
	return MeshProcessingMeshing<EIK>::Extrude_SM(meshPtr, dir);
}

Index2 MeshProcessingMeshing_EIK_Fair_SM(void* meshPtr, int index, int k_ring)
{
	return MeshProcessingMeshing<EIK>::Fair_SM(meshPtr, index, k_ring);
}

Index2 MeshProcessingMeshing_EIK_Refine_SM(void* meshPtr, double density_control_factor)
{
	return MeshProcessingMeshing<EIK>::Refine_SM(meshPtr, density_control_factor);
}

int MeshProcessingMeshing_EIK_IsotropicRemeshing_SM(void* meshPtr, int iterations, double target_edge_length)
{
	return MeshProcessingMeshing<EIK>::IsotropicRemeshing_SM(meshPtr, iterations, target_edge_length);
}

void MeshProcessingMeshing_EIK_RandomPerturbation_SM(void* meshPtr, double perturbation_max_size)
{
	MeshProcessingMeshing<EIK>::RandomPerturbation_SM(meshPtr, perturbation_max_size);
}

void MeshProcessingMeshing_EIK_SmoothMesh_SM(void* meshPtr, double featureAngle, int iterations)
{
	MeshProcessingMeshing<EIK>::SmoothMesh_SM(meshPtr, featureAngle, iterations);
}

void MeshProcessingMeshing_EIK_SmoothShape_SM(void* meshPtr, double timeStep, int iterations)
{
	MeshProcessingMeshing<EIK>::SmoothShape_SM(meshPtr, timeStep, iterations);
}

int MeshProcessingMeshing_EIK_SplitLongEdges_SM(void* meshPtr, double target_edge_length)
{
	return MeshProcessingMeshing<EIK>::SplitLongEdges_SM(meshPtr, target_edge_length);
}

BOOL MeshProcessingMeshing_EIK_TriangulateFace_SM(void* meshPtr, int index)
{
	return MeshProcessingMeshing<EIK>::TriangulateFace_SM(meshPtr, index);
}

BOOL MeshProcessingMeshing_EIK_TriangulateFaces_SM(void* meshPtr, int* faces, int count)
{
	return MeshProcessingMeshing<EIK>::TriangulateFaces_SM(meshPtr, faces, count);
}
