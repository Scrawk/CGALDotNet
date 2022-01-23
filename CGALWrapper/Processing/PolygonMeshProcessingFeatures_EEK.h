#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonMeshProcessingFeatures_EEK_Create();

	CGALWRAPPER_API void PolygonMeshProcessingFeatures_EEK_Release(void* ptr);

	CGALWRAPPER_API  int PolygonMeshProcessingFeatures_EEK_DetectSharpEdges(void* feaPtr, void* polyPtr, double feature_angle);

	CGALWRAPPER_API  int PolygonMeshProcessingFeatures_EEK_SharpEdgesSegmentation(void* feaPtr, void* polyPtr, double feature_angle);

}

