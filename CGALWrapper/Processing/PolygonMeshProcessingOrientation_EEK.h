#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonMeshProcessingOrientation_EEK_Create();

	CGALWRAPPER_API void PolygonMeshProcessingOrientation_EEK_Release(void* ptr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume(void* polyPtr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingOrientation_EEK_IsOutwardOriented(void* polyPtr);

	CGALWRAPPER_API void PolygonMeshProcessingOrientation_EEK_Orient(void* polyPtr);

	CGALWRAPPER_API void PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume(void* polyPtr);

	CGALWRAPPER_API void PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations(void* polyPtr);

}

