#include "MeshProcessingMeshing_EEK.h"
#include "MeshProcessingMeshing.h"

void* MeshProcessingMeshing_EEK_Create()
{
	return MeshProcessingMeshing<EEK>::NewMeshProcessingMeshing();
}

void MeshProcessingMeshing_EEK_Release(void* ptr)
{
	MeshProcessingMeshing<EEK>::DeleteMeshProcessingMeshing(ptr);
}

//Polyhedron

void* MeshProcessingMeshing_EEK_Extrude_PH(void* meshPtr, Vector3d dir)
{
	return MeshProcessingMeshing<EEK>::Extrude_PH(meshPtr, dir);
}

Index2 MeshProcessingMeshing_EEK_Fair_PH(void* meshPtr, int index, int k_ring)
{
	return MeshProcessingMeshing<EEK>::Fair_PH(meshPtr, index, k_ring);
}

Index2 MeshProcessingMeshing_EEK_Refine_PH(void* meshPtr, double density_control_factor)
{
	return MeshProcessingMeshing<EEK>::Refine_PH(meshPtr, density_control_factor);
}

int MeshProcessingMeshing_EEK_IsotropicRemeshing_PH(void* meshPtr, int iterations, double target_edge_length)
{
	return MeshProcessingMeshing<EEK>::IsotropicRemeshing_PH(meshPtr, iterations, target_edge_length);
}

void MeshProcessingMeshing_EEK_RandomPerturbation_PH(void* meshPtr, double perturbation_max_size)
{
	MeshProcessingMeshing<EEK>::RandomPerturbation_PH(meshPtr, perturbation_max_size);
}

void MeshProcessingMeshing_EEK_SmoothMesh_PH(void* meshPtr, double featureAngle, int iterations)
{
	MeshProcessingMeshing<EEK>::SmoothMesh_PH(meshPtr, featureAngle, iterations);
}

void MeshProcessingMeshing_EEK_SmoothShape_PH(void* meshPtr, double timeStep, int iterations)
{
	MeshProcessingMeshing<EEK>::SmoothShape_PH(meshPtr, timeStep, iterations);
}

int MeshProcessingMeshing_EEK_SplitLongEdges_PH(void* meshPtr, double target_edge_length)
{
	return MeshProcessingMeshing<EEK>::SplitLongEdges_PH(meshPtr, target_edge_length);
}

BOOL MeshProcessingMeshing_EEK_TriangulateFace_PH(void* meshPtr, int index)
{
	return MeshProcessingMeshing<EEK>::TriangulateFace_PH(meshPtr, index);
}

BOOL MeshProcessingMeshing_EEK_TriangulateFaces_PH(void* meshPtr, int* faces, int count)
{
	return MeshProcessingMeshing<EEK>::TriangulateFaces_PH(meshPtr, faces, count);
}

//Surface Mesh

void* MeshProcessingMeshing_EEK_Extrude_SM(void* meshPtr, Vector3d dir)
{
	return MeshProcessingMeshing<EEK>::Extrude_SM(meshPtr, dir);
}

Index2 MeshProcessingMeshing_EEK_Fair_SM(void* meshPtr, int index, int k_ring)
{
	return MeshProcessingMeshing<EEK>::Fair_SM(meshPtr, index, k_ring);
}

Index2 MeshProcessingMeshing_EEK_Refine_SM(void* meshPtr, double density_control_factor)
{
	return MeshProcessingMeshing<EEK>::Refine_SM(meshPtr, density_control_factor);
}

int MeshProcessingMeshing_EEK_IsotropicRemeshing_SM(void* meshPtr, int iterations, double target_edge_length)
{
	return MeshProcessingMeshing<EEK>::IsotropicRemeshing_SM(meshPtr, iterations, target_edge_length);
}

void MeshProcessingMeshing_EEK_RandomPerturbation_SM(void* meshPtr, double perturbation_max_size)
{
	MeshProcessingMeshing<EEK>::RandomPerturbation_SM(meshPtr, perturbation_max_size);
}

void MeshProcessingMeshing_EEK_SmoothMesh_SM(void* meshPtr, double featureAngle, int iterations)
{
	MeshProcessingMeshing<EEK>::SmoothMesh_SM(meshPtr, featureAngle, iterations);
}

void MeshProcessingMeshing_EEK_SmoothShape_SM(void* meshPtr, double timeStep, int iterations)
{
	MeshProcessingMeshing<EEK>::SmoothShape_SM(meshPtr, timeStep, iterations);
}

int MeshProcessingMeshing_EEK_SplitLongEdges_SM(void* meshPtr, double target_edge_length)
{
	return MeshProcessingMeshing<EEK>::SplitLongEdges_SM(meshPtr, target_edge_length);
}

BOOL MeshProcessingMeshing_EEK_TriangulateFace_SM(void* meshPtr, int index)
{
	return MeshProcessingMeshing<EEK>::TriangulateFace_SM(meshPtr, index);
}

BOOL MeshProcessingMeshing_EEK_TriangulateFaces_SM(void* meshPtr, int* faces, int count)
{
	return MeshProcessingMeshing<EEK>::TriangulateFaces_SM(meshPtr, faces, count);
}
