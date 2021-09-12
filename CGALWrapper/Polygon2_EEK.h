#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include <CGAL/enum.h>


extern "C"
{
	CGALWRAPPER_API void* Polygon2_EEK_Create();

	CGALWRAPPER_API void Polygon2_EEK_Release(void* ptr);

	CGALWRAPPER_API int Polygon2_EEK_Count(void* ptr);

	CGALWRAPPER_API void* Polygon2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void Polygon2_EEK_Clear(void* ptr);

	CGALWRAPPER_API Point2d Polygon2_EEK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void Polygon2_EEK_GetPoints(void* ptr, Point2d * points, int startIndex, int count);

	CGALWRAPPER_API void Polygon2_EEK_GetSegments(void* ptr, Segment2d* segments, int startIndex, int count);

	CGALWRAPPER_API void Polygon2_EEK_SetPoint(void* ptr, int index, Point2d point);

	CGALWRAPPER_API void Polygon2_EEK_SetPoints(void* ptr, Point2d * points, int startIndex, int count);

	CGALWRAPPER_API void Polygon2_EEK_Reverse(void* ptr);

	CGALWRAPPER_API BOOL Polygon2_EEK_IsSimple(void* ptr);

	CGALWRAPPER_API BOOL Polygon2_EEK_IsConvex(void* ptr);

	CGALWRAPPER_API CGAL::Orientation Polygon2_EEK_Orientation(void* ptr);

	CGALWRAPPER_API CGAL::Oriented_side Polygon2_EEK_OrientedSide(void* ptr, Point2d point);

	CGALWRAPPER_API CGAL::Bounded_side Polygon2_EEK_BoundedSide(void* ptr, Point2d point);

	CGALWRAPPER_API double Polygon2_EEK_SignedArea(void* ptr);

	CGALWRAPPER_API void Polygon2_EEK_Translate(void* ptr, Point2d translation);

	CGALWRAPPER_API void Polygon2_EEK_Rotate(void* ptr, double rotation);

	CGALWRAPPER_API void Polygon2_EEK_Scale(void* ptr, double scale);

	CGALWRAPPER_API void Polygon2_EEK_Transform(void* ptr, Point2d translation, double rotation, double scale);

	CGALWRAPPER_API BOOL Polygon2_EEK_ContainsPoint(void* ptr, Point2d point, CGAL::Orientation orientation, BOOL inculdeBoundary);

}


