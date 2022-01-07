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

	CGALWRAPPER_API void NefPolyhedron3_EEK_Clear(void* ptr, int space);

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

	CGALWRAPPER_API void* NefPolyhedron3_EEK_Intersection(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_Join(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_Difference(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_SymmetricDifference(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_Complement(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_Interior(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_Boundary(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_Closure(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_Regularization(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_MinkowskiSum(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_ConvertToPolyhedron(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EEK_ConvertToSurfaceMesh(void* ptr);

	CGALWRAPPER_API void NefPolyhedron3_EEK_ConvexDecomposition(void* ptr);

	CGALWRAPPER_API void NefPolyhedron3_EEK_GetVolumes(void* ptr, void** volumes, int count);

}