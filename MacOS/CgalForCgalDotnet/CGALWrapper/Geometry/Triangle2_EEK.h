#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* Triangle2_EEK_Create(const Point2d& a, const Point2d& b, const Point2d& c);

	CGALWRAPPER_API void Triangle2_EEK_Release(void* ptr);

	CGALWRAPPER_API Point2d Triangle2_EEK_GetVertex(void* ptr, int i);

	CGALWRAPPER_API void Triangle2_EEK_SetVertex(void* ptr, int i, const Point2d& point);

	CGALWRAPPER_API double Triangle2_EEK_Area(void* ptr);

	CGALWRAPPER_API CGAL::Bounded_side Triangle2_EEK_BoundedSide(void* ptr, const Point2d& point);

	CGALWRAPPER_API CGAL::Sign Triangle2_EEK_OrientedSide(void* ptr, const Point2d& point);

	CGALWRAPPER_API CGAL::Sign Triangle2_EEK_Orientation(void* ptr);

	CGALWRAPPER_API BOOL Triangle2_EEK_IsDegenerate(void* ptr);

	CGALWRAPPER_API void Triangle2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API void* Triangle2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void* Triangle2_EEK_Convert(void* ptr, CGAL_KERNEL k);
}

