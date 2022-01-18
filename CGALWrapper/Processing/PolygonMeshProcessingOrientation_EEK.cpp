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

BOOL PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume(void* polyPtr)
{
	return PolygonMeshProcessingOrientation<EEK>::DoesBoundAVolume(polyPtr);
}

BOOL PolygonMeshProcessingOrientation_EEK_IsOutwardOriented(void* polyPtr)
{
	return PolygonMeshProcessingOrientation<EEK>::IsOutwardOriented(polyPtr);
}

void PolygonMeshProcessingOrientation_EEK_Orient(void* polyPtr)
{
	PolygonMeshProcessingOrientation<EEK>::Orient(polyPtr);
}

void PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume(void* polyPtr)
{
	PolygonMeshProcessingOrientation<EEK>::OrientToBoundAVolume(polyPtr);
}

void PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations(void* polyPtr)
{
	PolygonMeshProcessingOrientation<EEK>::ReverseFaceOrientations(polyPtr);
}
