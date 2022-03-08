#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Ray2_EEK_Create(const Point2d& position, const Vector2d& direction);

	CGALWRAPPER_API void Ray2_EEK_Release(void* ptr);

	CGALWRAPPER_API BOOL Ray2_EEK_IsDegenerate(void* ptr);

	CGALWRAPPER_API BOOL Ray2_EEK_IsHorizontal(void* ptr);

	CGALWRAPPER_API BOOL Ray2_EEK_IsVertical(void* ptr);

	CGALWRAPPER_API BOOL Ray2_EEK_HasOn(void* rayPtr, const Point2d& point);

	CGALWRAPPER_API Point2d Ray2_EEK_Source(void* ptr);

	CGALWRAPPER_API Vector2d Ray2_EEK_Vector(void* ptr);

	CGALWRAPPER_API void* Ray2_EEK_Opposite(void* ptr);

	CGALWRAPPER_API void* Ray2_EEK_Line(void* ptr);

	CGALWRAPPER_API void Ray2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Ray2_EEK_Copy(void* ptr, CGAL_KERNEL k);
}

