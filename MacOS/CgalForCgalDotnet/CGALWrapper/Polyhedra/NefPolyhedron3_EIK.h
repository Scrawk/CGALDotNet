#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

extern "C"
{

	CGALWRAPPER_API void* NefPolyhedron3_EIK_CreateFromSpace(int space);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_CreateFromPlane(Plane3d plane, int boundary);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_CreateFromPolyhedron(void* ptr);

	CGALWRAPPER_API void NefPolyhedron3_EIK_Release(void* ptr);

	CGALWRAPPER_API void NefPolyhedron3_EIK_Clear(void* ptr, int space);

	CGALWRAPPER_API BOOL NefPolyhedron3_EIK_IsEmpty(void* ptr);

	CGALWRAPPER_API BOOL NefPolyhedron3_EIK_IsSimple(void* ptr);

	CGALWRAPPER_API BOOL NefPolyhedron3_EIK_IsSpace(void* ptr);

	CGALWRAPPER_API BOOL NefPolyhedron3_EIK_IsValid(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EIK_EdgeCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EIK_FacetCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EIK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EIK_HalfFacetCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EIK_VertexCount(void* ptr);

	CGALWRAPPER_API int NefPolyhedron3_EIK_VolumeCount(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_Intersection(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_Join(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_Difference(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_SymmetricDifference(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_Complement(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_Interior(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_Boundary(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_Closure(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_Regularization(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_MinkowskiSum(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_ConvertToPolyhedron(void* ptr);

	CGALWRAPPER_API void* NefPolyhedron3_EIK_ConvertToSurfaceMesh(void* ptr);

	CGALWRAPPER_API void NefPolyhedron3_EIK_ConvexDecomposition(void* ptr);

	CGALWRAPPER_API void NefPolyhedron3_EIK_GetVolumes(void* ptr, void** volumes, int count);

}