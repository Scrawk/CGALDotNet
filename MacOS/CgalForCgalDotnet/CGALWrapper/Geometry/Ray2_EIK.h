#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Ray2_EIK_Create(const Point2d& position, const Vector2d& direction);

	CGALWRAPPER_API void Ray2_EIK_Release(void* ptr);

	CGALWRAPPER_API BOOL Ray2_EIK_IsDegenerate(void* ptr);

	CGALWRAPPER_API BOOL Ray2_EIK_IsHorizontal(void* ptr);

	CGALWRAPPER_API BOOL Ray2_EIK_IsVertical(void* ptr);

	CGALWRAPPER_API BOOL Ray2_EIK_HasOn(void* rayPtr, const Point2d& point);

	CGALWRAPPER_API Point2d Ray2_EIK_Source(void* ptr);

	CGALWRAPPER_API Vector2d Ray2_EIK_Vector(void* ptr);

	CGALWRAPPER_API void* Ray2_EIK_Opposite(void* ptr);

	CGALWRAPPER_API void* Ray2_EIK_Line(void* ptr);

	CGALWRAPPER_API void Ray2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Ray2_EIK_Copy(void* ptr, CGAL_KERNEL k);
}

