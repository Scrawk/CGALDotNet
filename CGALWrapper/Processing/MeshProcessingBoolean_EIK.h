#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingBoolean_EIK_Create();

	CGALWRAPPER_API void MeshProcessingBoolean_EIK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_Union_PH(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_Difference_PH(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_Intersection_PH(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_Clip_PH(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_PlaneClip_PH(void* meshPtr1, Plane3d plane, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_BoxClip_PH(void* meshPtr1, Box3d box, void** resultPtr);

	CGALWRAPPER_API  BOOL MeshProcessingBoolean_EIK_SurfaceIntersection_PH(void* meshPtr1, void* meshPtr2);

	//Surface Mesh

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_Union_SM(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_Difference_SM(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_Intersection_SM(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_Clip_SM(void* meshPtr1, void* meshPtr2, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_PlaneClip_SM(void* meshPtr1, Plane3d plane, void** resultPtr);

	CGALWRAPPER_API BOOL MeshProcessingBoolean_EIK_BoxClip_SM(void* meshPtr1, Box3d box, void** resultPtr);

	CGALWRAPPER_API  BOOL MeshProcessingBoolean_EIK_SurfaceIntersection_SM(void* meshPtr1, void* meshPtr2);

}

