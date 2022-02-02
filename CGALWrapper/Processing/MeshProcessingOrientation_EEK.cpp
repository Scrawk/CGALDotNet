#include "MeshProcessingOrientation_EEK.h"
#include "MeshProcessingOrientation.h"

void* MeshProcessingOrientation_EEK_Create()
{
	return MeshProcessingOrientation<EEK>::NewMeshProcessingOrientation();
}

void MeshProcessingOrientation_EEK_Release(void* ptr)
{
	MeshProcessingOrientation<EEK>::DeleteMeshProcessingOrientation(ptr);
}

//Polyhedron

BOOL MeshProcessingOrientation_EEK_DoesBoundAVolume_PH(void* meshPtr)
{
	return MeshProcessingOrientation<EEK>::DoesBoundAVolume_PH(meshPtr);
}

BOOL MeshProcessingOrientation_EEK_IsOutwardOriented_PH(void* meshPtr)
{
	return MeshProcessingOrientation<EEK>::IsOutwardOriented_PH(meshPtr);
}

void MeshProcessingOrientation_EEK_Orient_PH(void* meshPtr)
{
	MeshProcessingOrientation<EEK>::Orient_PH(meshPtr);
}

void MeshProcessingOrientation_EEK_OrientToBoundAVolume_PH(void* meshPtr)
{
	MeshProcessingOrientation<EEK>::OrientToBoundAVolume_PH(meshPtr);
}

void MeshProcessingOrientation_EEK_ReverseFaceOrientations_PH(void* meshPtr)
{
	MeshProcessingOrientation<EEK>::ReverseFaceOrientations_PH(meshPtr);
}

//Surface Mesh

BOOL MeshProcessingOrientation_EEK_DoesBoundAVolume_SM(void* meshPtr)
{
	return MeshProcessingOrientation<EEK>::DoesBoundAVolume_SM(meshPtr);
}

BOOL MeshProcessingOrientation_EEK_IsOutwardOriented_SM(void* meshPtr)
{
	return MeshProcessingOrientation<EEK>::IsOutwardOriented_SM(meshPtr);
}

void MeshProcessingOrientation_EEK_Orient_SM(void* meshPtr)
{
	MeshProcessingOrientation<EEK>::Orient_SM(meshPtr);
}

void MeshProcessingOrientation_EEK_OrientToBoundAVolume_SM(void* meshPtr)
{
	MeshProcessingOrientation<EEK>::OrientToBoundAVolume_SM(meshPtr);
}

void MeshProcessingOrientation_EEK_ReverseFaceOrientations_SM(void* meshPtr)
{
	MeshProcessingOrientation<EEK>::ReverseFaceOrientations_SM(meshPtr);
}
