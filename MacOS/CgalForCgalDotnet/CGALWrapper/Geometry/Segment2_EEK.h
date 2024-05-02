#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Segment2_EEK_Create(const Point2d& a, const Point2d& b);

	CGALWRAPPER_API void Segment2_EEK_Release(void* ptr);

	CGALWRAPPER_API Point2d Segment2_EEK_GetVertex(void* ptr, int i);

	CGALWRAPPER_API void Segment2_EEK_SetVertex(void* ptr, int i, const Point2d& point);

	CGALWRAPPER_API Point2d Segment2_EEK_Min(void* ptr);

	CGALWRAPPER_API Point2d Segment2_EEK_Max(void* ptr);

	CGALWRAPPER_API BOOL Segment2_EEK_IsDegenerate(void* ptr);

	CGALWRAPPER_API BOOL Segment2_EEK_IsHorizontal(void* ptr);

	CGALWRAPPER_API BOOL Segment2_EEK_IsVertical(void* ptr);

	CGALWRAPPER_API BOOL Segment2_EEK_HasOn(void* segPtr, const Point2d& point);

	CGALWRAPPER_API Vector2d Segment2_EEK_Vector(void* ptr);

	CGALWRAPPER_API void* Segment2_EEK_Line(void* ptr);

	CGALWRAPPER_API double Segment2_EEK_SqrLength(void* ptr);

	CGALWRAPPER_API void Segment2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Segment2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void* Segment2_EEK_Convert(void* ptr, CGAL_KERNEL k);
}

