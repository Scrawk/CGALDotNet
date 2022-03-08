#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Point2_EEK.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Line2_EEK_Create(double a, double b, double c);

	CGALWRAPPER_API void* Line2_EEK_CreateFromPoints(const Point2d& p1, const Point2d& p2);

	CGALWRAPPER_API void* Line2_EEK_CreateFromPointVector(const Point2d& p, const Vector2d& v);

	CGALWRAPPER_API void Line2_EEK_Release(void* ptr);

	CGALWRAPPER_API double Line2_EEK_GetA(void* ptr);

	CGALWRAPPER_API double Line2_EEK_GetB(void* ptr);

	CGALWRAPPER_API double Line2_EEK_GetC(void* ptr);

	CGALWRAPPER_API void Line2_EEK_SetA(void* ptr, double a);

	CGALWRAPPER_API void Line2_EEK_SetB(void* ptr, double b);

	CGALWRAPPER_API void Line2_EEK_SetC(void* ptr, double c);

	CGALWRAPPER_API BOOL Line2_EEK_IsDegenerate(void* ptr);

	CGALWRAPPER_API BOOL Line2_EEK_IsHorizontal(void* ptr);

	CGALWRAPPER_API BOOL Line2_EEK_IsVertical(void* ptr);

	CGALWRAPPER_API BOOL Line2_EEK_HasOn(void* linePtr, const Point2d& point);

	CGALWRAPPER_API BOOL Line2_EEK_HasOnNegativeSide(void* linePtr, const Point2d& point);

	CGALWRAPPER_API BOOL Line2_EEK_HasOnPositiveSide(void* linePtr, const Point2d& point);

	CGALWRAPPER_API void* Line2_EEK_Opposite(void* ptr);

	CGALWRAPPER_API void* Line2_EEK_Perpendicular(void* ptr, const Point2d& point);

	CGALWRAPPER_API double Line2_EEK_X_On_Y(void* ptr, double y);

	CGALWRAPPER_API double Line2_EEK_Y_On_X(void* ptr, double x);

	CGALWRAPPER_API Vector2d Line2_EEK_Vector(void* ptr);

	CGALWRAPPER_API void Line2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Line2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void* Line2_EEK_Convert(void* ptr, CGAL_KERNEL k);
}

