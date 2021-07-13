#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

extern "C" CGALWRAPPER_API void PolygonBoolean2_EEK_ClearBuffer();

extern "C" CGALWRAPPER_API void* PolygonBoolean2_EEK_CopyBufferItem(int index);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_P_P(void* ptr1, void* ptr2);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_P_PWH(void* ptr1, void* ptr2);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_PWH_PWH(void* ptr1, void* ptr2);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_P_P(void* ptr1, void* ptr2, void** resultPtr);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_P_PWH(void* ptr1, void* ptr2, void** resultPtr);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_PWH_PWH(void* ptr1, void* ptr2, void** resultPtr);

extern "C" CGALWRAPPER_API int PolygonBoolean2_EEK_Intersect_P_P(void* ptr1, void* ptr2);

