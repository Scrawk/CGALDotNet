#include "PolygonMeshProcessingMeshing_EEK.h"
#include "PolygonMeshProcessingMeshing.h"

void* PolygonMeshProcessingMeshing_EEK_Create()
{
	return PolygonMeshProcessingMeshing<EEK>::NewPolygonMeshProcessingMeshing();
}

void PolygonMeshProcessingMeshing_EEK_Release(void* ptr)
{
	PolygonMeshProcessingMeshing<EEK>::DeletePolygonMeshProcessingMeshing(ptr);
}

//Polyhedron

void* PolygonMeshProcessingMeshing_EEK_Extrude_PH(void* meshPtr, Vector3d dir)
{
	return PolygonMeshProcessingMeshing<EEK>::Extrude_PH(meshPtr, dir);
}

Index2 PolygonMeshProcessingMeshing_EEK_Fair_PH(void* meshPtr, int index, int k_ring)
{
	return PolygonMeshProcessingMeshing<EEK>::Fair_PH(meshPtr, index, k_ring);
}

Index2 PolygonMeshProcessingMeshing_EEK_Refine_PH(void* meshPtr, double density_control_factor)
{
	return PolygonMeshProcessingMeshing<EEK>::Refine_PH(meshPtr, density_control_factor);
}

int PolygonMeshProcessingMeshing_EEK_IsotropicRemeshing_PH(void* meshPtr, int iterations, double target_edge_length)
{
	return PolygonMeshProcessingMeshing<EEK>::IsotropicRemeshing_PH(meshPtr, iterations, target_edge_length);
}

void PolygonMeshProcessingMeshing_EEK_RandomPerturbation_PH(void* meshPtr, double perturbation_max_size)
{
	PolygonMeshProcessingMeshing<EEK>::RandomPerturbation_PH(meshPtr, perturbation_max_size);
}

void PolygonMeshProcessingMeshing_EEK_SmoothMesh_PH(void* meshPtr, double featureAngle, int iterations)
{
	PolygonMeshProcessingMeshing<EEK>::SmoothMesh_PH(meshPtr, featureAngle, iterations);
}

void PolygonMeshProcessingMeshing_EEK_SmoothShape_PH(void* meshPtr, double timeStep, int iterations)
{
	PolygonMeshProcessingMeshing<EEK>::SmoothShape_PH(meshPtr, timeStep, iterations);
}

int PolygonMeshProcessingMeshing_EEK_SplitLongEdges_PH(void* meshPtr, double target_edge_length)
{
	return PolygonMeshProcessingMeshing<EEK>::SplitLongEdges_PH(meshPtr, target_edge_length);
}

//Surface Mesh

void* PolygonMeshProcessingMeshing_EEK_Extrude_SM(void* meshPtr, Vector3d dir)
{
	return PolygonMeshProcessingMeshing<EEK>::Extrude_SM(meshPtr, dir);
}

Index2 PolygonMeshProcessingMeshing_EEK_Fair_SM(void* meshPtr, int index, int k_ring)
{
	return PolygonMeshProcessingMeshing<EEK>::Fair_SM(meshPtr, index, k_ring);
}

Index2 PolygonMeshProcessingMeshing_EEK_Refine_SM(void* meshPtr, double density_control_factor)
{
	return PolygonMeshProcessingMeshing<EEK>::Refine_SM(meshPtr, density_control_factor);
}

int PolygonMeshProcessingMeshing_EEK_IsotropicRemeshing_SM(void* meshPtr, int iterations, double target_edge_length)
{
	return PolygonMeshProcessingMeshing<EEK>::IsotropicRemeshing_SM(meshPtr, iterations, target_edge_length);
}

void PolygonMeshProcessingMeshing_EEK_RandomPerturbation_SM(void* meshPtr, double perturbation_max_size)
{
	PolygonMeshProcessingMeshing<EEK>::RandomPerturbation_SM(meshPtr, perturbation_max_size);
}

void PolygonMeshProcessingMeshing_EEK_SmoothMesh_SM(void* meshPtr, double featureAngle, int iterations)
{
	PolygonMeshProcessingMeshing<EEK>::SmoothMesh_SM(meshPtr, featureAngle, iterations);
}

void PolygonMeshProcessingMeshing_EEK_SmoothShape_SM(void* meshPtr, double timeStep, int iterations)
{
	PolygonMeshProcessingMeshing<EEK>::SmoothShape_SM(meshPtr, timeStep, iterations);
}

int PolygonMeshProcessingMeshing_EEK_SplitLongEdges_SM(void* meshPtr, double target_edge_length)
{
	return PolygonMeshProcessingMeshing<EEK>::SplitLongEdges_SM(meshPtr, target_edge_length);
}
