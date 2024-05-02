#include "MeshProcessingFeatures_EEK.h"
#include "MeshProcessingFeatures.h"

void* MeshProcessingFeatures_EEK_Create()
{
	return MeshProcessingFeatures<EEK>::NewMeshProcessingFeatures();
}

void MeshProcessingFeatures_EEK_Release(void* ptr)
{
	MeshProcessingFeatures<EEK>::DeleteMeshProcessingFeatures(ptr);
}

//Polyhedron 

int MeshProcessingFeatures_EEK_DetectSharpEdges_PH(void* feaPtr, void* meshPtr, double feature_angle)
{
	return MeshProcessingFeatures<EEK>::DetectSharpEdges_PH(feaPtr, meshPtr, feature_angle);
}

void MeshProcessingFeatures_EEK_GetSharpEdges_PH(void* feaPtr, void* meshPtr, int* indices, int count)
{
	MeshProcessingFeatures<EEK>::GetSharpEdges_PH(feaPtr, meshPtr, indices, count);
}

Index2 MeshProcessingFeatures_EEK_SharpEdgesSegmentation_PH(void* feaPtr, void* meshPtr, double feature_angle)
{
	return MeshProcessingFeatures<EEK>::SharpEdgesSegmentation_PH(feaPtr, meshPtr, feature_angle);
}

void MeshProcessingFeatures_EEK_ClearPatchBuffer_PH(void* feaPtr)
{
	MeshProcessingFeatures<EEK>::ClearPatchBuffer_PH(feaPtr);
}

int MeshProcessingFeatures_EEK_GetPatchBufferFaceCount_PH(void* feaPtr, int patchIndex)
{
	return MeshProcessingFeatures<EEK>::GetPatchBufferFaceCount_PH(feaPtr, patchIndex);
}

int MeshProcessingFeatures_EEK_GetPatchBufferFaceIndex_PH(void* feaPtr, int patchIndex, int faceIndex)
{
	return MeshProcessingFeatures<EEK>::GetPatchBufferFaceIndex_PH(feaPtr, patchIndex, faceIndex);
}

MinMaxAvg MeshProcessingFeatures_EEK_EdgeLengthMinMaxAvg_PH(void* ptr)
{
	return MeshProcessingFeatures<EEK>::EdgeLengthMinMaxAvg_PH(ptr);
}

MinMaxAvg MeshProcessingFeatures_EEK_FaceAreaMinMaxAvg_PH(void* ptr)
{
	return MeshProcessingFeatures<EEK>::FaceAreaMinMaxAvg_PH(ptr);
}

//Surface Mesh

int MeshProcessingFeatures_EEK_DetectSharpEdges_SM(void* feaPtr, void* meshPtr, double feature_angle)
{
	return MeshProcessingFeatures<EEK>::DetectSharpEdges_SM(feaPtr, meshPtr, feature_angle);
}

void MeshProcessingFeatures_EEK_GetSharpEdges_SM(void* feaPtr, void* meshPtr, int* indices, int count)
{
	MeshProcessingFeatures<EEK>::GetSharpEdges_SM(feaPtr, meshPtr, indices, count);
}

Index2 MeshProcessingFeatures_EEK_SharpEdgesSegmentation_SM(void* feaPtr, void* meshPtr, double feature_angle)
{
	return MeshProcessingFeatures<EEK>::SharpEdgesSegmentation_SM(feaPtr, meshPtr, feature_angle);
}

void MeshProcessingFeatures_EEK_ClearPatchBuffer_SM(void* feaPtr)
{
	MeshProcessingFeatures<EEK>::ClearPatchBuffer_SM(feaPtr);
}

int MeshProcessingFeatures_EEK_GetPatchBufferFaceCount_SM(void* feaPtr, int patchIndex)
{
	return MeshProcessingFeatures<EEK>::GetPatchBufferFaceCount_SM(feaPtr, patchIndex);
}

int MeshProcessingFeatures_EEK_GetPatchBufferFaceIndex_SM(void* feaPtr, int patchIndex, int faceIndex)
{
	return MeshProcessingFeatures<EEK>::GetPatchBufferFaceIndex_SM(feaPtr, patchIndex, faceIndex);
}

MinMaxAvg MeshProcessingFeatures_EEK_EdgeLengthMinMaxAvg_SM(void* ptr)
{
	return MeshProcessingFeatures<EEK>::EdgeLengthMinMaxAvg_SM(ptr);
}

MinMaxAvg MeshProcessingFeatures_EEK_FaceAreaMinMaxAvg_SM(void* ptr)
{
	return MeshProcessingFeatures<EEK>::FaceAreaMinMaxAvg_SM(ptr);
}



