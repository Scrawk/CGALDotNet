#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include <CGAL/enum.h>


extern "C"
{

	CGALWRAPPER_API void* Polyline3_EIK_Create();

	CGALWRAPPER_API void* Polyline3_EIK_CreateWithCount(int count);

	CGALWRAPPER_API void Polyline3_EIK_Release(void* ptr);

	CGALWRAPPER_API int Polyline3_EIK_Count(void* ptr);

	CGALWRAPPER_API void* Polyline3_EIK_Copy(void* ptr);

	CGALWRAPPER_API void* Polyline3_EIK_Convert(void* ptr, CGAL_KERNEL k);

	CGALWRAPPER_API void Polyline3_EIK_Clear(void* ptr);

	CGALWRAPPER_API  int Polyline3_EIK_Capacity(void* ptr);

	CGALWRAPPER_API  void Polyline3_EIK_Resize(void* ptr, int count);

	CGALWRAPPER_API  void Polyline3_EIK_Reverse(void* ptr);

	CGALWRAPPER_API void Polyline3_EIK_ShrinkToFit(void* ptr);

	CGALWRAPPER_API  void Polyline3_EIK_Erase(void* ptr, int index);

	CGALWRAPPER_API  void Polyline3_EIK_EraseRange(void* ptr, int start, int count);

	CGALWRAPPER_API void Polyline3_EIK_Insert(void* ptr, int index, Point3d point);

	CGALWRAPPER_API void Polyline3_EIK_InsertRange(void* ptr, int start, int count, Point3d* points);

	CGALWRAPPER_API BOOL Polyline3_EIK_IsClosed(void* ptr, double threshold);

	CGALWRAPPER_API double Polyline3_EIK_SqLength(void* ptr);

	CGALWRAPPER_API Point3d Polyline3_EIK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void Polyline3_EIK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyline3_EIK_GetSegments(void* ptr, Segment3d* segments, int count);

	CGALWRAPPER_API void Polyline3_EIK_SetPoint(void* ptr, int index, const Point3d& point);

	CGALWRAPPER_API void Polyline3_EIK_SetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyline3_EIK_Transform(void* ptr, const Matrix4x4d& matrix);


}


