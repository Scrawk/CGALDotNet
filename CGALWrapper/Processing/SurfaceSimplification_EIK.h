#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* SurfaceSimplification_EIK_Create();

	CGALWRAPPER_API void SurfaceSimplification_EIK_Release(void* ptr);

	CGALWRAPPER_API void SurfaceSimplification_EIK_SimplifyPolyhedron(void* polyPtr, double stop_ratio);

}