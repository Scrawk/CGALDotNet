#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void PolygonBoolean2_EEK_ClearBuffer();

	CGALWRAPPER_API void* PolygonBoolean2_EEK_CopyBufferItem(int index);

	CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_P_P(void* ptr1, void* ptr2);

	CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_P_PWH(void* ptr1, void* ptr2);

	CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_PWH_PWH(void* ptr1, void* ptr2);

	CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_P_P(void* ptr1, void* ptr2, void** resultPtr);

	CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_P_PWH(void* ptr1, void* ptr2, void** resultPtr);

	CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_PWH_PWH(void* ptr1, void* ptr2, void** resultPtr);

	CGALWRAPPER_API int PolygonBoolean2_EEK_Intersect_P_P(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_Intersect_P_PWH(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_Intersect_PWH_PWH(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_Difference_P_P(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_Difference_P_PWH(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_Difference_PWH_PWH(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_SymmetricDifference_P_P(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_SymmetricDifference_P_PWH(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_SymmetricDifference_PWH_PWH(void* ptr1, void* ptr2);

	CGALWRAPPER_API int PolygonBoolean2_EEK_Complement_PWH(void* ptr);
}


