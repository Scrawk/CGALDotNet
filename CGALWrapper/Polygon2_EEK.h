#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

typedef CGAL::Polygon_2<EEK> Polygon2_EEK;

extern "C" CGALWRAPPER_API void* Polygon2_EEK_Create();

extern "C" CGALWRAPPER_API void* Polygon2_EEK_CreateFromPoints(Point2d * points, int startIndex, int count);

extern "C" CGALWRAPPER_API void Polygon2_EEK_Release(void* ptr);

extern "C" CGALWRAPPER_API Point2d Polygon2_EEK_GetPoint(void* ptr, int index);

extern "C" CGALWRAPPER_API void Polygon2_EEK_GetPoints(void* ptr, Point2d * points, int startIndex, int count);

extern "C" CGALWRAPPER_API void Polygon2_EEK_SetPoint(void* ptr, int index, Point2d point);

extern "C" CGALWRAPPER_API void Polygon2_EEK_SetPoints(void* ptr, Point2d * points, int startIndex, int count);

extern "C" CGALWRAPPER_API void Polygon2_EEK_Reverse(void* ptr);

extern "C" CGALWRAPPER_API bool Polygon2_EEK_IsSimple(void* ptr);

extern "C" CGALWRAPPER_API bool Polygon2_EEK_IsConvex(void* ptr);

extern "C" CGALWRAPPER_API CGAL::Orientation Polygon2_EEK_Orientation(void* ptr);

extern "C" CGALWRAPPER_API CGAL::Oriented_side Polygon2_EEK_OrientedSide(void* ptr, Point2d point);

extern "C" CGALWRAPPER_API double Polygon2_EEK_SignedArea(void* ptr);

extern "C" CGALWRAPPER_API void Polygon2_EEK_Clear(void* ptr);

