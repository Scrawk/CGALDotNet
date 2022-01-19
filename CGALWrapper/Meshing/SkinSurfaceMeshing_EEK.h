#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* SkinSurfaceMeshing_EEK_Create();

	CGALWRAPPER_API void SkinSurfaceMeshing_EEK_Release(void* ptr);

	CGALWRAPPER_API void* SkinSurfaceMeshing_EEK_MakeSkinSurface_Point3d(double shrinkfactor, BOOL subdivide, Point3d* points, int count);

	CGALWRAPPER_API void* SkinSurfaceMeshing_EEK_MakeSkinSurface_HPoint3d(double shrinkfactor, BOOL subdivide, HPoint3d* points, int count);

}