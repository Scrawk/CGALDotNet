#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* SkinSurfaceMeshing_EEK_Create();

	CGALWRAPPER_API void SkinSurfaceMeshing_EEK_Release(void* ptr);

}