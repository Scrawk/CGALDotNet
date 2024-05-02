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
	CGALWRAPPER_API void* ConvexHull2_EEK_Create();

	CGALWRAPPER_API void ConvexHull2_EEK_Release(void* ptr);

	CGALWRAPPER_API void* ConvexHull2_EEK_CreateHull(Point2d* points, int count, HULL_METHOD method);

	CGALWRAPPER_API void* ConvexHull2_EEK_UpperHull(Point2d* points, int count);

	CGALWRAPPER_API void* ConvexHull2_EEK_LowerHull(Point2d* points, int count);

	CGALWRAPPER_API BOOL ConvexHull2_EEK_IsStronglyConvexCCW(Point2d* points, int count);

	CGALWRAPPER_API BOOL ConvexHull2_EEK_IsStronglyConvexCW(Point2d* points, int count);

}