#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include <CGAL/enum.h>


extern "C"
{

	CGALWRAPPER_API void* Polyline3_EEK_Create();

	CGALWRAPPER_API void* Polyline3_EEK_CreateWithCount(int count);

	CGALWRAPPER_API void Polyline3_EEK_Release(void* ptr);

	CGALWRAPPER_API int Polyline3_EEK_Count(void* ptr);

	CGALWRAPPER_API void* Polyline3_EEK_Copy(void* ptr);

	CGALWRAPPER_API void* Polyline3_EEK_Convert(void* ptr, CGAL_KERNEL k);

	CGALWRAPPER_API void Polyline3_EEK_Clear(void* ptr);

	CGALWRAPPER_API  int Polyline3_EEK_Capacity(void* ptr);

	CGALWRAPPER_API  void Polyline3_EEK_Resize(void* ptr, int count);

	CGALWRAPPER_API  void Polyline3_EEK_Reverse(void* ptr);

	CGALWRAPPER_API void Polyline3_EEK_ShrinkToFit(void* ptr);

	CGALWRAPPER_API  void Polyline3_EEK_Erase(void* ptr, int index);

	CGALWRAPPER_API  void Polyline3_EEK_EraseRange(void* ptr, int start, int count);

	CGALWRAPPER_API void Polyline3_EEK_Insert(void* ptr, int index, Point3d point);

	CGALWRAPPER_API void Polyline3_EEK_InsertRange(void* ptr, int start, int count, Point3d* points);

	CGALWRAPPER_API BOOL Polyline3_EEK_IsClosed(void* ptr, double threshold);

	CGALWRAPPER_API double Polyline3_EEK_SqLength(void* ptr);

	CGALWRAPPER_API Point3d Polyline3_EEK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void Polyline3_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyline3_EEK_GetSegments(void* ptr, Segment3d* segments, int count);

	CGALWRAPPER_API void Polyline3_EEK_SetPoint(void* ptr, int index, const Point3d& point);

	CGALWRAPPER_API void Polyline3_EEK_SetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyline3_EEK_Transform(void* ptr, const Matrix4x4d& matrix);


}


