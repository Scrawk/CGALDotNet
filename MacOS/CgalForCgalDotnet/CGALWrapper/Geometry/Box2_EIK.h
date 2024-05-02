#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>


extern "C"
{
	CGALWRAPPER_API void* Box2_EIK_Create(const Point2d& min, const Point2d& max);

	CGALWRAPPER_API void Box2_EIK_Release(void* ptr);

	CGALWRAPPER_API void* Box2_EIK_Copy(void* ptr);

	CGALWRAPPER_API Point2d Box2_EIK_GetMin(void* ptr);

	CGALWRAPPER_API void Box2_EIK_SetMin(void* ptr, const Point2d& point);

	CGALWRAPPER_API Point2d Box2_EIK_GetMax(void* ptr);

	CGALWRAPPER_API void Box2_EIK_SetMax(void* ptr, const Point2d& point);

	CGALWRAPPER_API double Box2_EIK_Area(void* ptr);

	CGALWRAPPER_API CGAL::Bounded_side Box2_EIK_BoundedSide(void* ptr, const Point2d& point);

	CGALWRAPPER_API BOOL Box2_EIK_ContainsPoint(void* ptr, const Point2d& point, BOOL inculdeBoundary);

	CGALWRAPPER_API BOOL Box2_EIK_IsDegenerate(void* ptr);

	CGALWRAPPER_API void Box2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Box2_EIK_Convert(void* ptr, CGAL_KERNEL k);
}
