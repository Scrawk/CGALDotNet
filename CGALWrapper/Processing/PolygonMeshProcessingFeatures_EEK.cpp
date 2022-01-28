#include "PolygonMeshProcessingFeatures_EEK.h"
#include "PolygonMeshProcessingFeatures.h"

void* PolygonMeshProcessingFeatures_EEK_Create()
{
	return PolygonMeshProcessingFeatures<EEK>::NewPolygonMeshProcessingFeatures();
}

void PolygonMeshProcessingFeatures_EEK_Release(void* ptr)
{
	PolygonMeshProcessingFeatures<EEK>::DeletePolygonMeshProcessingFeatures(ptr);
}

//Polyhedron 

int PolygonMeshProcessingFeatures_EEK_DetectSharpEdges_PH(void* feaPtr, void* meshPtr, double feature_angle)
{
	return PolygonMeshProcessingFeatures<EEK>::DetectSharpEdges_PH(feaPtr, meshPtr, feature_angle);
}

void PolygonMeshProcessingFeatures_EEK_GetSharpEdges_PH(void* feaPtr, void* meshPtr, int* indices, int count)
{
	PolygonMeshProcessingFeatures<EEK>::GetSharpEdges_PH(feaPtr, meshPtr, indices, count);
}

Index2 PolygonMeshProcessingFeatures_EEK_SharpEdgesSegmentation_PH(void* feaPtr, void* meshPtr, double feature_angle)
{
	return PolygonMeshProcessingFeatures<EEK>::SharpEdgesSegmentation_PH(feaPtr, meshPtr, feature_angle);
}

void PolygonMeshProcessingFeatures_EEK_ClearPatchBuffer_PH(void* feaPtr)
{
	PolygonMeshProcessingFeatures<EEK>::ClearPatchBuffer_PH(feaPtr);
}

int PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceCount_PH(void* feaPtr, int patchIndex)
{
	return PolygonMeshProcessingFeatures<EEK>::GetPatchBufferFaceCount_PH(feaPtr, patchIndex);
}

int PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceIndex_PH(void* feaPtr, int patchIndex, int faceIndex)
{
	return PolygonMeshProcessingFeatures<EEK>::GetPatchBufferFaceIndex_PH(feaPtr, patchIndex, faceIndex);
}

//Surface Mesh

int PolygonMeshProcessingFeatures_EEK_DetectSharpEdges_SM(void* feaPtr, void* meshPtr, double feature_angle)
{
	return PolygonMeshProcessingFeatures<EEK>::DetectSharpEdges_SM(feaPtr, meshPtr, feature_angle);
}

void PolygonMeshProcessingFeatures_EEK_GetSharpEdges_SM(void* feaPtr, void* meshPtr, int* indices, int count)
{
	PolygonMeshProcessingFeatures<EEK>::GetSharpEdges_SM(feaPtr, meshPtr, indices, count);
}

Index2 PolygonMeshProcessingFeatures_EEK_SharpEdgesSegmentation_SM(void* feaPtr, void* meshPtr, double feature_angle)
{
	return PolygonMeshProcessingFeatures<EEK>::SharpEdgesSegmentation_SM(feaPtr, meshPtr, feature_angle);
}

void PolygonMeshProcessingFeatures_EEK_ClearPatchBuffer_SM(void* feaPtr)
{
	PolygonMeshProcessingFeatures<EEK>::ClearPatchBuffer_SM(feaPtr);
}

int PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceCount_SM(void* feaPtr, int patchIndex)
{
	return PolygonMeshProcessingFeatures<EEK>::GetPatchBufferFaceCount_SM(feaPtr, patchIndex);
}

int PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceIndex_SM(void* feaPtr, int patchIndex, int faceIndex)
{
	return PolygonMeshProcessingFeatures<EEK>::GetPatchBufferFaceIndex_SM(feaPtr, patchIndex, faceIndex);
}



