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

void* PolygonVisibility_EEK_ComputeVisibilitySimple(const Point2d& point, void* polyPtr)
{
	return PolygonVisibility<EEK>::ComputeVisibilitySimple(point, polyPtr);
}

void* PolygonVisibility_EEK_ComputeVisibilityTEV(const Point2d& point, void* pwhPtr)
{
	return PolygonVisibility<EEK>::ComputeVisibilityTEV(point, pwhPtr);
}

void* PolygonVisibility_EEK_ComputeVisibilityRSV(const Point2d& point, void* pwhPtr)
{
	return PolygonVisibility<EEK>::ComputeVisibilityRSV(point, pwhPtr);
}
