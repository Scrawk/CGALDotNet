#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/enum.h>

enum class HULL_METHOD : int
{
	DEFAULT,
	AKL_TOUSSAINT,
	BYKAT,
	EDDY,
	GRAHAM_ANDREW,
	JARVIS
};

extern "C"
{
	CGALWRAPPER_API void* ConvexHull2_EIK_Create();

	CGALWRAPPER_API void ConvexHull2_EIK_Release(void* ptr);

	CGALWRAPPER_API void* ConvexHull2_EIK_CreateHull(Point2d* points, int count, HULL_METHOD method);

	CGALWRAPPER_API void* ConvexHull2_EIK_UpperHull(Point2d* points, int count);

	CGALWRAPPER_API void* ConvexHull2_EIK_LowerHull(Point2d* points, int count);

	CGALWRAPPER_API BOOL ConvexHull2_EIK_IsStronglyConvexCCW(Point2d* points, int count);

	CGALWRAPPER_API BOOL ConvexHull2_EIK_IsStronglyConvexCW(Point2d* points, int count);

}