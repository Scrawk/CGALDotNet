#include "PolygonVisibility_EIK.h"
#include "PolygonVisiblity.h"

void* PolygonVisibility_EIK_Create()
{
	return PolygonVisibility<EIK>::NewPolygonVisibility();
}

void PolygonVisibility_EIK_Release(void* ptr)
{
	PolygonVisibility<EIK>::DeletePolygonVisibility(ptr);
}

void* PolygonVisibility_EIK_ComputeVisibilitySimple(const Point2d& point, void* polyPtr)
{
	return PolygonVisibility<EIK>::ComputeVisibilitySimple(point, polyPtr);
}

void* PolygonVisibility_EIK_ComputeVisibilityTEV(const Point2d& point, void* pwhPtr)
{
	return PolygonVisibility<EIK>::ComputeVisibilityTEV(point, pwhPtr);
}

void* PolygonVisibility_EIK_ComputeVisibilityRSV(const Point2d& point, void* pwhPtr)
{
	return PolygonVisibility<EIK>::ComputeVisibilityRSV(point, pwhPtr);
}
