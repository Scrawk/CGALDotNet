#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* SkinSurfaceMeshing_EEK_Create();

	CGALWRAPPER_API void SkinSurfaceMeshing_EEK_Release(void* ptr);

	CGALWRAPPER_API void* SkinSurfaceMeshing_EEK_MakeSkinSurface(double shrinkfactor, BOOL subdivide, HPoint3d* points, int count);

}