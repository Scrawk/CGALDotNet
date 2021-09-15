#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>

enum COST_FUNC : int
{
	SQUARE_DIST,
	SCALED_SQ_DIST
};

enum STOP_FUNC : int
{
	BELOW_RATIO,
	BELOW_THRESHOLD,
	ABOVE_THRESHOLD
};

extern "C"
{
	CGALWRAPPER_API void* PolygonSimplification2_EEK_Create();

	CGALWRAPPER_API void PolygonSimplification2_EEK_Release(void* ptr);

	CGALWRAPPER_API void* PolygonSimplification2_EEK_Simplify(void* polyPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold);

	CGALWRAPPER_API void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles_All(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold);

	CGALWRAPPER_API void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles_Boundary(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold);

	CGALWRAPPER_API void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles_Holes(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold);

	CGALWRAPPER_API void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles_Hole(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold, int index);

}
