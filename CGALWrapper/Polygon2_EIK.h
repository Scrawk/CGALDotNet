#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

typedef CGAL::Polygon_2<EIK> Polygon2_EIK;

extern "C" CGALWRAPPER_API void* Polygon2_EIK_Create();

extern "C" CGALWRAPPER_API void* Polygon2_EIK_CreateFromPoints(Point2d * points, int startIndex, int count);

extern "C" CGALWRAPPER_API void Polygon2_EIK_Release(void* ptr);

extern "C" CGALWRAPPER_API Point2d Polygon2_EIK_GetPoint(void* ptr, int index);

extern "C" CGALWRAPPER_API void Polygon2_EIK_GetPoints(void* ptr, Point2d * points, int startIndex, int count);

extern "C" CGALWRAPPER_API void Polygon2_EIK_SetPoint(void* ptr, int index, Point2d point);

extern "C" CGALWRAPPER_API void Polygon2_EIK_SetPoints(void* ptr, Point2d * points, int startIndex, int count);

extern "C" CGALWRAPPER_API void Polygon2_EIK_Reverse(void* ptr);

extern "C" CGALWRAPPER_API bool Polygon2_EIK_IsSimple(void* ptr);

extern "C" CGALWRAPPER_API bool Polygon2_EIK_IsConvex(void* ptr);

extern "C" CGALWRAPPER_API CGAL::Orientation Polygon2_EIK_Orientation(void* ptr);

extern "C" CGALWRAPPER_API CGAL::Oriented_side Polygon2_EIK_OrientedSide(void* ptr, Point2d point);

extern "C" CGALWRAPPER_API double Polygon2_EIK_Area(void* ptr);

extern "C" CGALWRAPPER_API void Polygon2_EIK_Clear(void* ptr);


