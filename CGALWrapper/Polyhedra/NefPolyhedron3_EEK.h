#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

extern "C"
{

	CGALWRAPPER_API void* NefPolyhedron3_EEK_CreateFromSpace(int space);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_CreateFromPlane(Plane3d plane, int boundary);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_CreateFromPolyhedron(void* ptr);

	CGALWRAPPER_API void NefPolyhedron3_EEK_Release(void* ptr);

	CGALWRAPPER_API void NefPolyhedron3_EEK_Clear(void* ptr);

	CGALWRAPPER_API BOOL NefPolyhedron3_EEK_IsEmpty(void* ptr);

	CGALWRAPPER_API BOOL NefPolyhedron3_EEK_IsSimple(void* ptr);

	CGALWRAPPER_API BOOL NefPolyhedron3_EEK_IsSpace(void* ptr);

	CGALWRAPPER_API BOOL NefPolyhedron3_EEK_IsValid(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EEK_EdgeCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EEK_FacetCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EEK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EEK_HalfFacetCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EEK_VolumeCount(void* ptr);

}