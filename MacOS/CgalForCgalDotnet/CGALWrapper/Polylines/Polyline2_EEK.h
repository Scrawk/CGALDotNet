#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>


extern "C"
{

	CGALWRAPPER_API void* Polyline2_EEK_Create();

	CGALWRAPPER_API void* Polyline2_EEK_CreateWithCount(int count);

	CGALWRAPPER_API void Polyline2_EEK_Release(void* ptr);

	CGALWRAPPER_API int Polyline2_EEK_Count(void* ptr);

	CGALWRAPPER_API void* Polyline2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void* Polyline2_EEK_Convert(void* ptr, CGAL_KERNEL k);

	CGALWRAPPER_API void Polyline2_EEK_Clear(void* ptr);

	CGALWRAPPER_API  int Polyline2_EEK_Capacity(void* ptr);

	CGALWRAPPER_API  void Polyline2_EEK_Resize(void* ptr, int count);

	CGALWRAPPER_API  void Polyline2_EEK_Reverse(void* ptr);

	CGALWRAPPER_API void Polyline2_EEK_ShrinkToFit(void* ptr);

	CGALWRAPPER_API  void Polyline2_EEK_Erase(void* ptr, int index);

	CGALWRAPPER_API  void Polyline2_EEK_EraseRange(void* ptr, int start, int count);

	CGALWRAPPER_API void Polyline2_EEK_Insert(void* ptr, int index, Point2d point);

	CGALWRAPPER_API void Polyline2_EEK_InsertRange(void* ptr, int start, int count, Point2d* points);

	CGALWRAPPER_API BOOL Polyline2_EEK_IsClosed(void* ptr, double threshold);

	CGALWRAPPER_API double Polyline2_EEK_SqLength(void* ptr);

	CGALWRAPPER_API Point2d Polyline2_EEK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void Polyline2_EEK_GetPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void Polyline2_EEK_GetSegments(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API void Polyline2_EEK_SetPoint(void* ptr, int index, const Point2d& point);

	CGALWRAPPER_API void Polyline2_EEK_SetPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void Polyline2_EEK_Translate(void* ptr, const Point2d& translation);

	CGALWRAPPER_API void Polyline2_EEK_Rotate(void* ptr, double rotation);

	CGALWRAPPER_API void Polyline2_EEK_Scale(void* ptr, double scale);

	CGALWRAPPER_API void Polyline2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);


}


