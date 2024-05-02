#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* SurfaceSimplification_EIK_Create();

	CGALWRAPPER_API void SurfaceSimplification_EIK_Release(void* ptr);

	CGALWRAPPER_API void SurfaceSimplification_EIK_Simplify_PH(void* meshPtr, double stop_ratio);

	CGALWRAPPER_API void SurfaceSimplification_EIK_Simplify_SM(void* meshPtr, double stop_ratio);
}