#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API void* Vector2_EIK_Create();

	CGALWRAPPER_API void* Vector2_EIK_CreateFromVector(const Vector2d& vector);

	CGALWRAPPER_API void Vector2_EIK_Release(void* ptr);

	CGALWRAPPER_API double Vector2_EIK_GetX(void* ptr);

	CGALWRAPPER_API double Vector2_EIK_GetY(void* ptr);

	CGALWRAPPER_API void Vector2_EIK_SetX(void* ptr, double x);

	CGALWRAPPER_API void Vector2_EIK_SetY(void* ptr, double y);

	CGALWRAPPER_API double Vector2_EIK_SqrLength(void* ptr);

	CGALWRAPPER_API void* Vector2_EIK_Perpendicular(void* ptr, CGAL::Orientation orientation);

	CGALWRAPPER_API void Vector2_EIK_Normalize(void* ptr);

	CGALWRAPPER_API double Vector2_EIK_Magnitude(void* ptr);

	CGALWRAPPER_API void* Vector2_EIK_Copy(void* ptr);

	CGALWRAPPER_API void* Vector2_EIK_Convert(void* ptr, CGAL_KERNEL k);

}

