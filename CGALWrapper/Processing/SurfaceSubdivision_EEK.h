#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* SurfaceSubdivision_EEK_Create();

	CGALWRAPPER_API void SurfaceSubdivision_EEK_Release(void* ptr);

	CGALWRAPPER_API void SurfaceSubdivision_EEK_SubdivePolyhedron_CatmullClark(void* polyPtr, int iterations);

	CGALWRAPPER_API void SurfaceSubdivision_EEK_SubdivePolyhedron_DooSabin(void* polyPtr, int iterations);

	CGALWRAPPER_API void SurfaceSubdivision_EEK_SubdivePolyhedron_Loop(void* polyPtr, int iterations);

	CGALWRAPPER_API void SurfaceSubdivision_EEK_SubdivePolyhedron_Sqrt3(void* polyPtr, int iterations);

}