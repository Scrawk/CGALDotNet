#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>


extern "C"
{
	CGALWRAPPER_API void* Box2_EEK_Create(const Point2d& min, const Point2d& max);

	CGALWRAPPER_API void Box2_EEK_Release(void* ptr);

	CGALWRAPPER_API void* Box2_EEK_Copy(void* ptr);

	CGALWRAPPER_API Point2d Box2_EEK_GetMin(void* ptr);

	CGALWRAPPER_API void Box2_EEK_SetMin(void* ptr, const Point2d& point);

	CGALWRAPPER_API Point2d Box2_EEK_GetMax(void* ptr);

	CGALWRAPPER_API void Box2_EEK_SetMax(void* ptr, const Point2d& point);

	CGALWRAPPER_API double Box2_EEK_Area(void* ptr);

	CGALWRAPPER_API CGAL::Bounded_side Box2_EEK_BoundedSide(void* ptr, const Point2d& point);

	CGALWRAPPER_API BOOL Box2_EEK_ContainsPoint(void* ptr, const Point2d& point, BOOL inculdeBoundary);

	CGALWRAPPER_API BOOL Box2_EEK_IsDegenerate(void* ptr);

	CGALWRAPPER_API void Box2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Box2_EEK_Convert(void* ptr, CGAL_KERNEL k);
}
