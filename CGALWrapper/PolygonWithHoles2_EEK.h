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

extern "C" CGALWRAPPER_API void PolygonWithHoles2_EEK_ClearBoundary(void* ptr);

extern "C" CGALWRAPPER_API void* PolygonWithHoles2_EEK_CreateFromPolygon(void* ptr);

extern "C" CGALWRAPPER_API void* PolygonWithHoles2_EEK_CreateFromPoints(Point2d * points, int startIndex, int count);

extern "C" CGALWRAPPER_API void PolygonWithHoles2_EEK_AddHoleFromPolygon(void* pwhPtr, void* polygonPtr);

extern "C" CGALWRAPPER_API void PolygonWithHoles2_EEK_AddHoleFromPoints(void* ptr, Point2d * points, int startIndex, int count);

extern "C" CGALWRAPPER_API void PolygonWithHoles2_EEK_RemoveHole(void* ptr, int index);

extern "C" CGALWRAPPER_API void* PolygonWithHoles2_EEK_CopyHole(void* ptr, int index);

extern "C" CGALWRAPPER_API void PolygonWithHoles2_EEK_ReverseHole(void* ptr, int index);

extern "C" CGALWRAPPER_API bool PolygonWithHoles2_EEK_IsUnbounded(void* ptr);

extern "C" CGALWRAPPER_API bool PolygonWithHoles2_EEK_IsSimple(void* ptr, int index);

extern "C" CGALWRAPPER_API bool PolygonWithHoles2_EEK_IsConvex(void* ptr, int index);

extern "C" CGALWRAPPER_API CGAL::Orientation PolygonWithHoles2_EEK_Orientation(void* ptr, int index);

extern "C" CGALWRAPPER_API CGAL::Oriented_side PolygonWithHoles2_EEK_OrientedSide(void* ptr, int index, Point2d point);

extern "C" CGALWRAPPER_API double PolygonWithHoles2_EEK_SignedArea(void* ptr, int index);
