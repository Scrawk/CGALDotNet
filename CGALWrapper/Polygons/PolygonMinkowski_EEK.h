#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>


extern "C"
{
	CGALWRAPPER_API void* PolygonMinkowski_EEK_Create();

	CGALWRAPPER_API void PolygonMinkowski_EEK_Release(void* ptr);

	CGALWRAPPER_API void* PolygonMinkowski_EEK_MinkowskiSum(void* polyPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EEK_MinkowskiSumDecomp(void* polyPtr1, void* polyPtr2, int decomp);

}

