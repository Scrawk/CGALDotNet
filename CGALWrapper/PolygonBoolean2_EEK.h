#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

typedef CGAL::Polygon_2<EEK> Polygon2_EEK;

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_DoIntersect(void* ptr1, void* ptr2);

extern "C" CGALWRAPPER_API bool PolygonBoolean2_EEK_Join(void* ptr1, void* ptr2, void** resultPtr);

