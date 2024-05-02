#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API void* Vector2_EEK_Create();

	CGALWRAPPER_API void* Vector2_EEK_CreateFromVector(const Vector2d& vector);

	CGALWRAPPER_API void Vector2_EEK_Release(void* ptr);

	CGALWRAPPER_API double Vector2_EEK_GetX(void* ptr);

	CGALWRAPPER_API double Vector2_EEK_GetY(void* ptr);

	CGALWRAPPER_API void Vector2_EEK_SetX(void* ptr, double x);

	CGALWRAPPER_API void Vector2_EEK_SetY(void* ptr, double y);

	CGALWRAPPER_API double Vector2_EEK_SqrLength(void* ptr);

	CGALWRAPPER_API void* Vector2_EEK_Perpendicular(void* ptr, CGAL::Orientation orientation);

	CGALWRAPPER_API void Vector2_EEK_Normalize(void* ptr);

	CGALWRAPPER_API double Vector2_EEK_Magnitude(void* ptr);

	CGALWRAPPER_API void* Vector2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void* Vector2_EEK_Convert(void* ptr, CGAL_KERNEL k);

}

