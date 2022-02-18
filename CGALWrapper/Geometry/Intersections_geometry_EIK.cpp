
#include "Intersections_geometry_EIK.h"
#include "Intersections_geometry.h"

/*****************************************************
*                                                    *
*            Point2 DoIntersect Functions            *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_PointLine(void* pointPtr, void* linePtr)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointLine(pointPtr, linePtr);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointRay(void* pointPtr, void* rayPtr)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointRay(pointPtr, rayPtr);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointSegment(void* pointPtr, void* segPtr)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointSegment(pointPtr, segPtr);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointTriangle(void* pointPtr, void* triPtr)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointTriangle(pointPtr, triPtr);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointBox(void* pointPtr, void* boxPtr)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointBox(pointPtr, boxPtr);
}
