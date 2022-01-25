#include "PolygonMeshProcessingOrientation_EEK.h"
#include "PolygonMeshProcessingOrientation.h"

void* PolygonMeshProcessingOrientation_EEK_Create()
{
	return PolygonMeshProcessingOrientation<EEK>::NewPolygonMeshProcessingOrientation();
}

void PolygonMeshProcessingOrientation_EEK_Release(void* ptr)
{
	PolygonMeshProcessingOrientation<EEK>::DeletePolygonMeshProcessingOrientation(ptr);
}

//Polyhedron

BOOL PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume_PH(void* meshPtr)
{
	return PolygonMeshProcessingOrientation<EEK>::DoesBoundAVolume_PH(meshPtr);
}

BOOL PolygonMeshProcessingOrientation_EEK_IsOutwardOriented_PH(void* meshPtr)
{
	return PolygonMeshProcessingOrientation<EEK>::IsOutwardOriented_PH(meshPtr);
}

void PolygonMeshProcessingOrientation_EEK_Orient_PH(void* meshPtr)
{
	PolygonMeshProcessingOrientation<EEK>::Orient_PH(meshPtr);
}

void PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume_PH(void* meshPtr)
{
	PolygonMeshProcessingOrientation<EEK>::OrientToBoundAVolume_PH(meshPtr);
}

void PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations_PH(void* meshPtr)
{
	PolygonMeshProcessingOrientation<EEK>::ReverseFaceOrientations_PH(meshPtr);
}

//Surface Mesh

BOOL PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume_SM(void* meshPtr)
{
	return PolygonMeshProcessingOrientation<EEK>::DoesBoundAVolume_SM(meshPtr);
}

BOOL PolygonMeshProcessingOrientation_EEK_IsOutwardOriented_SM(void* meshPtr)
{
	return PolygonMeshProcessingOrientation<EEK>::IsOutwardOriented_SM(meshPtr);
}

void PolygonMeshProcessingOrientation_EEK_Orient_SM(void* meshPtr)
{
	PolygonMeshProcessingOrientation<EEK>::Orient_SM(meshPtr);
}

void PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume_SM(void* meshPtr)
{
	PolygonMeshProcessingOrientation<EEK>::OrientToBoundAVolume_SM(meshPtr);
}

void PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations_SM(void* meshPtr)
{
	PolygonMeshProcessingOrientation<EEK>::ReverseFaceOrientations_SM(meshPtr);
}
