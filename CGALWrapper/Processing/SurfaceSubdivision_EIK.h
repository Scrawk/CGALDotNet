#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* SurfaceSubdivision_EIK_Create();

	CGALWRAPPER_API void SurfaceSubdivision_EIK_Release(void* ptr);

	CGALWRAPPER_API void SurfaceSubdivision_EIK_SubdivePolyhedron_CatmullClark(void* polyPtr, int iterations);

	CGALWRAPPER_API void SurfaceSubdivision_EIK_SubdivePolyhedron_Loop(void* polyPtr, int iterations);

	CGALWRAPPER_API void SurfaceSubdivision_EIK_SubdivePolyhedron_Sqrt3(void* polyPtr, int iterations);

}