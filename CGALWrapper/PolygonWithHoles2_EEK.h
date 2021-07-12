#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/enum.h>

extern "C" CGALWRAPPER_API void* PolygonWithHoles2_EEK_Create();

extern "C" CGALWRAPPER_API void PolygonWithHoles2_EEK_Release(void* ptr);

extern "C" CGALWRAPPER_API int PolygonWithHoles2_EEK_HoleCount(void* ptr);

extern "C" CGALWRAPPER_API void* PolygonWithHoles2_EEK_Copy(void* ptr);

extern "C" CGALWRAPPER_API void PolygonWithHoles2_EEK_Clear(void* ptr);

extern "C" CGALWRAPPER_API void* PolygonWithHoles2_EEK_CreateFromPolygon(void* ptr);

extern "C" CGALWRAPPER_API void* PolygonWithHoles2_EEK_CreateFromPoints(Point2d * points, int startIndex, int count);
