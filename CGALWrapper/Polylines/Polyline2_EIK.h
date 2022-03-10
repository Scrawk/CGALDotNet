#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>


extern "C"
{

	CGALWRAPPER_API void* Polyline2_EIK_Create();

	CGALWRAPPER_API void* Polyline2_EIK_CreateWithCount(int count);

	CGALWRAPPER_API void Polyline2_EIK_Release(void* ptr);

	CGALWRAPPER_API int Polyline2_EIK_Count(void* ptr);

	CGALWRAPPER_API void* Polyline2_EIK_Copy(void* ptr);

	CGALWRAPPER_API void* Polyline2_EIK_Convert(void* ptr, CGAL_KERNEL k);

	CGALWRAPPER_API void Polyline2_EIK_Clear(void* ptr);

	CGALWRAPPER_API  int Polyline2_EIK_Capacity(void* ptr);

	CGALWRAPPER_API  void Polyline2_EIK_Resize(void* ptr, int count);

	CGALWRAPPER_API  void Polyline2_EIK_Reverse(void* ptr);

	CGALWRAPPER_API void Polyline2_EIK_ShrinkToFit(void* ptr);

	CGALWRAPPER_API  void Polyline2_EIK_Erase(void* ptr, int index);

	CGALWRAPPER_API  void Polyline2_EIK_EraseRange(void* ptr, int start, int count);

	CGALWRAPPER_API void Polyline2_EIK_Insert(void* ptr, int index, Point2d point);

	CGALWRAPPER_API void Polyline2_EIK_InsertRange(void* ptr, int start, int count, Point2d* points);

	CGALWRAPPER_API BOOL Polyline2_EIK_IsClosed(void* ptr, double threshold);

	CGALWRAPPER_API double Polyline2_EIK_SqLength(void* ptr);

	CGALWRAPPER_API Point2d Polyline2_EIK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void Polyline2_EIK_GetPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void Polyline2_EIK_GetSegments(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API void Polyline2_EIK_SetPoint(void* ptr, int index, const Point2d& point);

	CGALWRAPPER_API void Polyline2_EIK_SetPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void Polyline2_EIK_Translate(void* ptr, const Point2d& translation);

	CGALWRAPPER_API void Polyline2_EIK_Rotate(void* ptr, double rotation);

	CGALWRAPPER_API void Polyline2_EIK_Scale(void* ptr, double scale);

	CGALWRAPPER_API void Polyline2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);


}


