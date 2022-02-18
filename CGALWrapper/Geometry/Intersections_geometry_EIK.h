#pragma once
#include "../CGALWrapper.h"
#include "Geometry2.h"
#include "Intersections_shapes.h"

#include <CGAL/Intersections.h>
#include <CGAL/enum.h>

extern "C"
{
	/*****************************************************
	*                                                    *
	*            Point2d DoIntersect Functions           *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API BOOL Intersections_Geometry_EIK_DoIntersect_PointLine(Point2d point, Line2d line);

	CGALWRAPPER_API BOOL Intersections_Geometry_EIK_DoIntersect_PointRay(Point2d point, Ray2d ray);

	CGALWRAPPER_API BOOL Intersections_Geometry_EIK_DoIntersect_PointSegment(Point2d point, Segment2d segment);

	CGALWRAPPER_API BOOL Intersections_Geometry_EIK_DoIntersect_PointTriangle(Point2d point, Triangle2d triangle);

	CGALWRAPPER_API BOOL Intersections_Geometry_EIK_DoIntersect_PointBox(Point2d point, Box2d box);

};

