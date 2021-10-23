
#include "PolygonSimplification2_EEK.h"
#include "PolygonSimplification2.h"
#include <vector>
#include <list>

void* PolygonSimplification2_EEK_Create()
{
	return PolygonSimplification2<EEK>::NewPolygonSimplification2();
}

void PolygonSimplification2_EEK_Release(void* ptr)
{
	PolygonSimplification2<EEK>::DeletePolygonSimplification2(ptr);
}

void* PolygonSimplification2_EEK_Simplify(void* polyPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
{	
	return PolygonSimplification2<EEK>::Simplify(polyPtr, costFunc, stopFunc, theshold);
}

void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles_All(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
{
	return PolygonSimplification2<EEK>::SimplifyPolygonWithHoles_All(pwhPtr, costFunc, stopFunc, theshold);
}

void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles_Boundary(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
{
	return PolygonSimplification2<EEK>::SimplifyPolygonWithHoles_Boundary(pwhPtr, costFunc, stopFunc, theshold);
}

void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles_Holes(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
{
	return PolygonSimplification2<EEK>::SimplifyPolygonWithHoles_Holes(pwhPtr, costFunc, stopFunc, theshold);
}

void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles_Hole(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold, int index)
{
	return PolygonSimplification2<EEK>::SimplifyPolygonWithHoles_Hole(pwhPtr, costFunc, stopFunc, theshold, index);
}
