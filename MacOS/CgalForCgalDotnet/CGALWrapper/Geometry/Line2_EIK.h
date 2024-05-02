#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Point2_EIK.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Line2_EIK_Create(double a, double b, double c);

	CGALWRAPPER_API void* Line2_EIK_CreateFromPoints(const Point2d& p1, const Point2d& p2);

	CGALWRAPPER_API void* Line2_EIK_CreateFromPointVector(const Point2d& p, const Vector2d& v);

	CGALWRAPPER_API void Line2_EIK_Release(void* ptr);

	CGALWRAPPER_API double Line2_EIK_GetA(void* ptr);

	CGALWRAPPER_API double Line2_EIK_GetB(void* ptr);

	CGALWRAPPER_API double Line2_EIK_GetC(void* ptr);

	CGALWRAPPER_API void Line2_EIK_SetA(void* ptr, double a);

	CGALWRAPPER_API void Line2_EIK_SetB(void* ptr, double b);

	CGALWRAPPER_API void Line2_EIK_SetC(void* ptr, double c);

	CGALWRAPPER_API BOOL Line2_EIK_IsDegenerate(void* ptr);

	CGALWRAPPER_API BOOL Line2_EIK_IsHorizontal(void* ptr);

	CGALWRAPPER_API BOOL Line2_EIK_IsVertical(void* ptr);

	CGALWRAPPER_API BOOL Line2_EIK_HasOn(void* linePtr, const Point2d& point);

	CGALWRAPPER_API BOOL Line2_EIK_HasOnNegativeSide(void* linePtr, const Point2d& point);

	CGALWRAPPER_API BOOL Line2_EIK_HasOnPositiveSide(void* linePtr, const Point2d& point);

	CGALWRAPPER_API void* Line2_EIK_Opposite(void* ptr);

	CGALWRAPPER_API void* Line2_EIK_Perpendicular(void* ptr, const Point2d& point);

	CGALWRAPPER_API double Line2_EIK_X_On_Y(void* ptr, double y);

	CGALWRAPPER_API double Line2_EIK_Y_On_X(void* ptr, double x);

	CGALWRAPPER_API Vector2d Line2_EIK_Vector(void* ptr);

	CGALWRAPPER_API void Line2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Line2_EIK_Copy(void* ptr);

	CGALWRAPPER_API void* Line2_EIK_Convert(void* ptr, CGAL_KERNEL k);
}

