#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

typedef CGAL::Polygon_2<EEK> Polygon2_EEK;

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_P_P(void* ptr1, void* ptr2);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_P_PWH(void* ptr1, void* ptr2);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect_PWH_PWH(void* ptr1, void* ptr2);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_P_P(void* ptr1, void* ptr2, void** resultPtr);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_P_PWH(void* ptr1, void* ptr2, void** resultPtr);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_Join_PWH_PWH(void* ptr1, void* ptr2, void** resultPtr);

