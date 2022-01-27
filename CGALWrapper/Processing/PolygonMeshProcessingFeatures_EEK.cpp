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

int PolygonMeshProcessingFeatures_EEK_DetectSharpEdges(void* feaPtr, void* polyPtr, double feature_angle)
{
	return PolygonMeshProcessingFeatures<EEK>::DetectSharpEdges_PH(feaPtr, polyPtr, feature_angle);
}

int PolygonMeshProcessingFeatures_EEK_SharpEdgesSegmentation(void* feaPtr, void* polyPtr, double feature_angle)
{
	return PolygonMeshProcessingFeatures<EEK>::SharpEdgesSegmentation_PH(feaPtr, polyPtr, feature_angle);
}

