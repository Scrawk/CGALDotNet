#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonMeshProcessingBoolean_EEK_Create();

	CGALWRAPPER_API void PolygonMeshProcessingBoolean_EEK_Release(void* ptr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronUnion(void* polyPtr1, void* polyPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronDifference(void* polyPtr1, void* polyPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronIntersection(void* polyPtr1, void* polyPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronClip(void* polyPtr1, void* polyPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingBoolean_EEK_PlaneClip(void* polyPtr1, Plane3d plane, void** resultPtr);

	CGALWRAPPER_API BOOL PolygonMeshProcessingBoolean_EEK_BoxClip(void* polyPtr1, Box3d box, void** resultPtr);

	CGALWRAPPER_API  BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronSurfaceIntersection(void* polyPtr1, void* polyPtr2);

}

