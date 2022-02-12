#include "MeshProcessingOrientation_EIK.h"
#include "MeshProcessingOrientation.h"

void* MeshProcessingOrientation_EIK_Create()
{
	return MeshProcessingOrientation<EIK>::NewMeshProcessingOrientation();
}

void MeshProcessingOrientation_EIK_Release(void* ptr)
{
	MeshProcessingOrientation<EIK>::DeleteMeshProcessingOrientation(ptr);
}

//Polyhedron

BOOL MeshProcessingOrientation_EIK_DoesBoundAVolume_PH(void* meshPtr)
{
	return MeshProcessingOrientation<EIK>::DoesBoundAVolume_PH(meshPtr);
}

BOOL MeshProcessingOrientation_EIK_IsOutwardOriented_PH(void* meshPtr)
{
	return MeshProcessingOrientation<EIK>::IsOutwardOriented_PH(meshPtr);
}

void MeshProcessingOrientation_EIK_Orient_PH(void* meshPtr)
{
	MeshProcessingOrientation<EIK>::Orient_PH(meshPtr);
}

void MeshProcessingOrientation_EIK_OrientToBoundAVolume_PH(void* meshPtr)
{
	MeshProcessingOrientation<EIK>::OrientToBoundAVolume_PH(meshPtr);
}

void MeshProcessingOrientation_EIK_ReverseFaceOrientations_PH(void* meshPtr)
{
	MeshProcessingOrientation<EIK>::ReverseFaceOrientations_PH(meshPtr);
}

//Surface Mesh

BOOL MeshProcessingOrientation_EIK_DoesBoundAVolume_SM(void* meshPtr)
{
	return MeshProcessingOrientation<EIK>::DoesBoundAVolume_SM(meshPtr);
}

BOOL MeshProcessingOrientation_EIK_IsOutwardOriented_SM(void* meshPtr)
{
	return MeshProcessingOrientation<EIK>::IsOutwardOriented_SM(meshPtr);
}

void MeshProcessingOrientation_EIK_Orient_SM(void* meshPtr)
{
	MeshProcessingOrientation<EIK>::Orient_SM(meshPtr);
}

void MeshProcessingOrientation_EIK_OrientToBoundAVolume_SM(void* meshPtr)
{
	MeshProcessingOrientation<EIK>::OrientToBoundAVolume_SM(meshPtr);
}

void MeshProcessingOrientation_EIK_ReverseFaceOrientations_SM(void* meshPtr)
{
	MeshProcessingOrientation<EIK>::ReverseFaceOrientations_SM(meshPtr);
}
