#include "pch.h"
#include "PolygonSimplification2_EEK.h"
#include "PolygonSimplification2.h"
#include "Util.h"
#include <vector>
#include <list>

void* PolygonSimplification2_EEK_Create()
{
	return Util::Create<PolygonSimplification2<EEK>>();
}

void PolygonSimplification2_EEK_Release(void* ptr)
{
	Util::Release<PolygonSimplification2<EEK>>(ptr);
}

void* PolygonSimplification2_EEK_Simplify(void* polyPtr, double theshold)
{	
	return PolygonSimplification2<EEK>::Simplify(polyPtr, theshold);
}

void* PolygonSimplification2_EEK_SimplifyPolygonWithHoles(void* pwhPtr, double theshold)
{
	return PolygonSimplification2<EEK>::SimplifyPolygonWithHoles(pwhPtr, theshold);
}
