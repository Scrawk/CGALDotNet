#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Segment2_EIK_Create(const Point2d& a, const Point2d& b);

	CGALWRAPPER_API void Segment2_EIK_Release(void* ptr);

	CGALWRAPPER_API Point2d Segment2_EIK_GetVertex(void* ptr, int i);

	CGALWRAPPER_API void Segment2_EIK_SetVertex(void* ptr, int i, const Point2d& point);

	CGALWRAPPER_API Point2d Segment2_EIK_Min(void* ptr);

	CGALWRAPPER_API Point2d Segment2_EIK_Max(void* ptr);

	CGALWRAPPER_API BOOL Segment2_EIK_IsDegenerate(void* ptr);

	CGALWRAPPER_API BOOL Segment2_EIK_IsHorizontal(void* ptr);

	CGALWRAPPER_API BOOL Segment2_EIK_IsVertical(void* ptr);

	CGALWRAPPER_API BOOL Segment2_EIK_HasOn(void* segPtr, const Point2d& point);

	CGALWRAPPER_API Vector2d Segment2_EIK_Vector(void* ptr);

	CGALWRAPPER_API void* Segment2_EIK_Line(void* ptr);

	CGALWRAPPER_API double Segment2_EIK_SqrLength(void* ptr);

	CGALWRAPPER_API void Segment2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Segment2_EIK_Copy(void* ptr);

	CGALWRAPPER_API void* Segment2_EIK_Convert(void* ptr, CGAL_KERNEL k);
}

