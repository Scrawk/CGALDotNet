#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* PolygonSimplification2_EEK_Create();

	CGALWRAPPER_API void PolygonSimplification2_EEK_Release(void* ptr);

	CGALWRAPPER_API void* PolygonSimplification2_EEK_Simplify(void* polyPtr, double theshold);

	CGALWRAPPER_API void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles(void* pwhPtr, double theshold);

}
