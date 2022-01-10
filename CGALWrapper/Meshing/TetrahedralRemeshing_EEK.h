#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* TetrahedralRemeshing_EEK_Create();

	CGALWRAPPER_API void TetrahedralRemeshing_EEK_Release(void* ptr);

}