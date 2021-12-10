
#include "PolygonSimplification2_EIK.h"
#include "PolygonSimplification2.h"
#include <vector>
#include <list>

void* PolygonSimplification2_EIK_Create()
{
	return PolygonSimplification2<EIK>::NewPolygonSimplification2();
}

void PolygonSimplification2_EIK_Release(void* ptr)
{
	PolygonSimplification2<EIK>::DeletePolygonSimplification2(ptr);
}

void* PolygonSimplification2_EIK_Simplify(void* polyPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
{
	return PolygonSimplification2<EIK>::Simplify(polyPtr, costFunc, stopFunc, theshold);
}

void* PolygonSimplification2_EIK_SimplifyPolygonWithHoles_All(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
{
	return PolygonSimplification2<EIK>::SimplifyPolygonWithHoles_All(pwhPtr, costFunc, stopFunc, theshold);
}

void* PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Boundary(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
{
	return PolygonSimplification2<EIK>::SimplifyPolygonWithHoles_Boundary(pwhPtr, costFunc, stopFunc, theshold);
}

void* PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Holes(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
{
	return PolygonSimplification2<EIK>::SimplifyPolygonWithHoles_Holes(pwhPtr, costFunc, stopFunc, theshold);
}

void* PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Hole(void* pwhPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold, int index)
{
	return PolygonSimplification2<EIK>::SimplifyPolygonWithHoles_Hole(pwhPtr, costFunc, stopFunc, theshold, index);
}
