#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* TetrahedralRemeshing_EEK_Create();

	CGALWRAPPER_API void TetrahedralRemeshing_EEK_Release(void* ptr);

	CGALWRAPPER_API void TetrahedralRemeshing_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API int TetrahedralRemeshing_EEK_Remesh(void* ptr, double targetLength, int iterations, Point3d* points, int count);

}