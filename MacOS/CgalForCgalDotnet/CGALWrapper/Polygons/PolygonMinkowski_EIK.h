#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>


extern "C"
{
	CGALWRAPPER_API void* PolygonMinkowski_EIK_Create();

	CGALWRAPPER_API void PolygonMinkowski_EIK_Release(void* ptr);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSum(void* polyPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSumPWH(void* pwhPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSum_SSAB(void* polyPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSum_OptimalConvex(void* polyPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSum_HertelMehlhorn(void* polyPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSum_GreeneConvex(void* polyPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSum_Vertical(void* polyPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSumPWH_Vertical(void* pwhPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSum_Triangle(void* polyPtr1, void* polyPtr2);

	CGALWRAPPER_API void* PolygonMinkowski_EIK_MinkowskiSumPWH_Triangle(void* pwhPtr1, void* polyPtr2);

}

