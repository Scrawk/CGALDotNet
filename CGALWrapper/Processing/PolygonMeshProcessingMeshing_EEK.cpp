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

void PolygonMeshProcessingMeshing_EEK_Extrude(void* polyPtr)
{
	PolygonMeshProcessingMeshing<EEK>::Extrude(polyPtr);
}

BOOL PolygonMeshProcessingMeshing_EEK_Fair(void* polyPtr)
{
	return PolygonMeshProcessingMeshing<EEK>::Fair(polyPtr);
}

int PolygonMeshProcessingMeshing_EEK_Refine(void* polyPtr, double density_control_factor)
{
	return PolygonMeshProcessingMeshing<EEK>::Refine(polyPtr, density_control_factor);
}

void PolygonMeshProcessingMeshing_EEK_IsotropicRemeshing(void* polyPtr, int iterations, double target_edge_length)
{
	PolygonMeshProcessingMeshing<EEK>::IsotropicRemeshing(polyPtr, iterations, target_edge_length);
}

void PolygonMeshProcessingMeshing_EEK_RandomPerturbation(void* polyPtr, double perturbation_max_size)
{
	PolygonMeshProcessingMeshing<EEK>::RandomPerturbation(polyPtr, perturbation_max_size);
}

void PolygonMeshProcessingMeshing_EEK_SmoothMesh(void* polyPtr)
{
	PolygonMeshProcessingMeshing<EEK>::SmoothMesh(polyPtr);
}

void PolygonMeshProcessingMeshing_EEK_SmoothShape(void* polyPtr)
{
	PolygonMeshProcessingMeshing<EEK>::SmoothShape(polyPtr);
}

void PolygonMeshProcessingMeshing_EEK_SplitLongEdges(void* polyPtr, double target_edge_length)
{
	PolygonMeshProcessingMeshing<EEK>::SplitLongEdges(polyPtr, target_edge_length);
}
