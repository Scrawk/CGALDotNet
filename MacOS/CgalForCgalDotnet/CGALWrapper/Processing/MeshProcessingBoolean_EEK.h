#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingBoolean_EEK_Create();

	CGALWRAPPER_API void MeshProcessingBoolean_EEK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_Union_PH(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_Difference_PH(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_Intersection_PH(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_Clip_PH(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_PlaneClip_PH(void* meshPtr1, Plane3d plane, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_BoxClip_PH(void* meshPtr1, Box3d box, void** resultPtr);

	CGALWRAPPER_API  BOOL MeshProcessingBoolean_EEK_SurfaceIntersection_PH(void* meshPtr1, void* meshPtr2);

	//Surface Mesh

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_Union_SM(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_Difference_SM(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_Intersection_SM(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_Clip_SM(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_PlaneClip_SM(void* meshPtr1, Plane3d plane, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EEK_BoxClip_SM(void* meshPtr1, Box3d box, void** resultPtr);

	CGALWRAPPER_API  BOOL MeshProcessingBoolean_EEK_SurfaceIntersection_SM(void* meshPtr1, void* meshPtr2);

}

