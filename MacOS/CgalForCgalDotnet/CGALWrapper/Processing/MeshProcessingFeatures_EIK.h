#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Index.h"
#include "../Geometry/MinMax.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingFeatures_EIK_Create();

	CGALWRAPPER_API void MeshProcessingFeatures_EIK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API  int MeshProcessingFeatures_EIK_DetectSharpEdges_PH(void* feaPtr, void* meshPtr, double feature_angle);

	CGALWRAPPER_API void MeshProcessingFeatures_EIK_GetSharpEdges_PH(void* feaPtr, void* meshPtr, int* indices, int count);

	CGALWRAPPER_API Index2 MeshProcessingFeatures_EIK_SharpEdgesSegmentation_PH(void* feaPtr, void* meshPtr, double feature_angle);

	CGALWRAPPER_API void MeshProcessingFeatures_EIK_ClearPatchBuffer_PH(void* feaPtr);

	CGALWRAPPER_API int MeshProcessingFeatures_EIK_GetPatchBufferFaceCount_PH(void* feaPtr, int patchIndex);

	CGALWRAPPER_API int MeshProcessingFeatures_EIK_GetPatchBufferFaceIndex_PH(void* feaPtr, int patchIndex, int faceIndex);

	CGALWRAPPER_API MinMaxAvg MeshProcessingFeatures_EIK_EdgeLengthMinMaxAvg_PH(void* ptr);

	CGALWRAPPER_API MinMaxAvg MeshProcessingFeatures_EIK_FaceAreaMinMaxAvg_PH(void* ptr);

	//Surface Mesh

	CGALWRAPPER_API  int MeshProcessingFeatures_EIK_DetectSharpEdges_SM(void* feaPtr, void* meshPtr, double feature_angle);

	CGALWRAPPER_API void MeshProcessingFeatures_EIK_GetSharpEdges_SM(void* feaPtr, void* meshPtr, int* indices, int count);

	CGALWRAPPER_API Index2 MeshProcessingFeatures_EIK_SharpEdgesSegmentation_SM(void* feaPtr, void* meshPtr, double feature_angle);

	CGALWRAPPER_API void MeshProcessingFeatures_EIK_ClearPatchBuffer_SM(void* feaPtr);

	CGALWRAPPER_API int MeshProcessingFeatures_EIK_GetPatchBufferFaceCount_SM(void* feaPtr, int patchIndex);

	CGALWRAPPER_API int MeshProcessingFeatures_EIK_GetPatchBufferFaceIndex_SM(void* feaPtr, int patchIndex, int faceIndex);

	CGALWRAPPER_API MinMaxAvg MeshProcessingFeatures_EIK_EdgeLengthMinMaxAvg_SM(void* ptr);

	CGALWRAPPER_API MinMaxAvg MeshProcessingFeatures_EIK_FaceAreaMinMaxAvg_SM(void* ptr);

}

