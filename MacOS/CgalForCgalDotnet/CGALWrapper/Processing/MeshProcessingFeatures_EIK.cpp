#include "MeshProcessingFeatures_EIK.h"
#include "MeshProcessingFeatures.h"

void* MeshProcessingFeatures_EIK_Create()
{
	return MeshProcessingFeatures<EIK>::NewMeshProcessingFeatures();
}

void MeshProcessingFeatures_EIK_Release(void* ptr)
{
	MeshProcessingFeatures<EIK>::DeleteMeshProcessingFeatures(ptr);
}

//Polyhedron 

int MeshProcessingFeatures_EIK_DetectSharpEdges_PH(void* feaPtr, void* meshPtr, double feature_angle)
{
	return MeshProcessingFeatures<EIK>::DetectSharpEdges_PH(feaPtr, meshPtr, feature_angle);
}

void MeshProcessingFeatures_EIK_GetSharpEdges_PH(void* feaPtr, void* meshPtr, int* indices, int count)
{
	MeshProcessingFeatures<EIK>::GetSharpEdges_PH(feaPtr, meshPtr, indices, count);
}

Index2 MeshProcessingFeatures_EIK_SharpEdgesSegmentation_PH(void* feaPtr, void* meshPtr, double feature_angle)
{
	return MeshProcessingFeatures<EIK>::SharpEdgesSegmentation_PH(feaPtr, meshPtr, feature_angle);
}

void MeshProcessingFeatures_EIK_ClearPatchBuffer_PH(void* feaPtr)
{
	MeshProcessingFeatures<EIK>::ClearPatchBuffer_PH(feaPtr);
}

int MeshProcessingFeatures_EIK_GetPatchBufferFaceCount_PH(void* feaPtr, int patchIndex)
{
	return MeshProcessingFeatures<EIK>::GetPatchBufferFaceCount_PH(feaPtr, patchIndex);
}

int MeshProcessingFeatures_EIK_GetPatchBufferFaceIndex_PH(void* feaPtr, int patchIndex, int faceIndex)
{
	return MeshProcessingFeatures<EIK>::GetPatchBufferFaceIndex_PH(feaPtr, patchIndex, faceIndex);
}

MinMaxAvg MeshProcessingFeatures_EIK_EdgeLengthMinMaxAvg_PH(void* ptr)
{
	return MeshProcessingFeatures<EIK>::EdgeLengthMinMaxAvg_PH(ptr);
}

MinMaxAvg MeshProcessingFeatures_EIK_FaceAreaMinMaxAvg_PH(void* ptr)
{
	return MeshProcessingFeatures<EIK>::FaceAreaMinMaxAvg_PH(ptr);
}

//Surface Mesh

int MeshProcessingFeatures_EIK_DetectSharpEdges_SM(void* feaPtr, void* meshPtr, double feature_angle)
{
	return MeshProcessingFeatures<EIK>::DetectSharpEdges_SM(feaPtr, meshPtr, feature_angle);
}

void MeshProcessingFeatures_EIK_GetSharpEdges_SM(void* feaPtr, void* meshPtr, int* indices, int count)
{
	MeshProcessingFeatures<EIK>::GetSharpEdges_SM(feaPtr, meshPtr, indices, count);
}

Index2 MeshProcessingFeatures_EIK_SharpEdgesSegmentation_SM(void* feaPtr, void* meshPtr, double feature_angle)
{
	return MeshProcessingFeatures<EIK>::SharpEdgesSegmentation_SM(feaPtr, meshPtr, feature_angle);
}

void MeshProcessingFeatures_EIK_ClearPatchBuffer_SM(void* feaPtr)
{
	MeshProcessingFeatures<EIK>::ClearPatchBuffer_SM(feaPtr);
}

int MeshProcessingFeatures_EIK_GetPatchBufferFaceCount_SM(void* feaPtr, int patchIndex)
{
	return MeshProcessingFeatures<EIK>::GetPatchBufferFaceCount_SM(feaPtr, patchIndex);
}

int MeshProcessingFeatures_EIK_GetPatchBufferFaceIndex_SM(void* feaPtr, int patchIndex, int faceIndex)
{
	return MeshProcessingFeatures<EIK>::GetPatchBufferFaceIndex_SM(feaPtr, patchIndex, faceIndex);
}

MinMaxAvg MeshProcessingFeatures_EIK_EdgeLengthMinMaxAvg_SM(void* ptr)
{
	return MeshProcessingFeatures<EIK>::EdgeLengthMinMaxAvg_SM(ptr);
}

MinMaxAvg MeshProcessingFeatures_EIK_FaceAreaMinMaxAvg_SM(void* ptr)
{
	return MeshProcessingFeatures<EIK>::FaceAreaMinMaxAvg_SM(ptr);
}



