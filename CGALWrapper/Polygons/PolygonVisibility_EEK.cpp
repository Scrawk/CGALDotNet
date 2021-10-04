#include "PolygonVisibility_EEK.h"
#include "PolygonVisiblity.h"

void* PolygonVisibility_EEK_Create()
{
	return PolygonVisibility<EEK>::NewPolygonVisibility();
}

void PolygonVisibility_EEK_Release(void* ptr)
{
	PolygonVisibility<EEK>::DeletePolygonVisibility(ptr);
}

void PolygonVisibility_EEK_Test()
{
	PolygonVisibility<EEK>::Test();
}
