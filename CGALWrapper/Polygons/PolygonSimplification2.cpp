
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

void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles(void* pwhPtr, double theshold)
{
	return PolygonSimplification2<EEK>::SimplifyPolygonWithHoles(pwhPtr, theshold);
}
