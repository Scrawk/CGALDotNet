#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingLocate_EEK_Create();

	CGALWRAPPER_API void MeshProcessingLocate_EEK_Release(void* ptr);


	CGALWRAPPER_API Point3d MeshProcessingLocate_EEK_RandomLocationOnMesh_PH(void* ptr);

	CGALWRAPPER_API BOOL MeshProcessingLocate_EEK_RandomLocationOnFace_PH(void* ptr, int index, Point3d& point);
}

