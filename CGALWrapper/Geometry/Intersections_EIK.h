#pragma once
#include "../CGALWrapper.h"
#include "Geometry2.h"
#include "Intersections.h"

#include <CGAL/Intersections.h>
#include <CGAL/enum.h>

extern "C"
{
	//Point

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_PointLine(Point2d point, Line2d line);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_PointRay(Point2d point, Ray2d ray);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_PointSegment(Point2d point, Segment2d segment);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_PointTriangle(Point2d point, Triangle2d triangle);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_PointBox(Point2d point, Box2d box);

	//Line

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_LinePoint(Line2d line, Point2d point);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_LineLine(Line2d line, Line2d line2);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_LineRay(Line2d line, Ray2d ray);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_LineSegment(Line2d line, Segment2d segment);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_LineTriangle(Line2d line, Triangle2d triangle);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_LineBox(Line2d line, Box2d box);

	//Ray

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_RayPoint(Ray2d ray, Point2d point);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_RayLine(Ray2d ray, Line2d line);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_RayRay(Ray2d ray, Ray2d ray2);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_RaySegment(Ray2d ray, Segment2d segment);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_RayTriangle(Ray2d ray, Triangle2d triangle);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_RayBox(Ray2d ray, Box2d box);

	//Segment

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_SegmentPoint(Segment2d segment, Point2d point);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_SegmentLine(Segment2d segment, Line2d line);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_SegmentRay(Segment2d segment, Ray2d ray);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_SegmentSegment(Segment2d segment, Segment2d segment2);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_SegmentTriangle(Segment2d segment, Triangle2d triangle);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_SegmentBox(Segment2d segment, Box2d box);

	//Triangle

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_TrianglePoint(Triangle2d triangle, Point2d point);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_TriangleLine(Triangle2d triangle, Line2d line);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_TriangleRay(Triangle2d triangle, Ray2d ray);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_TriangleSegment(Triangle2d triangle, Segment2d segment);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_TriangleBox(Triangle2d triangle, Box2d box);

	//Box

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_BoxPoint(Box2d box, Point2d point);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_BoxLine(Box2d box, Line2d line);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_BoxRay(Box2d box, Ray2d ray);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_BoxSegment(Box2d box, Segment2d segment);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_BoxTriangle(Box2d box, Triangle2d triangle);

	CGALWRAPPER_API BOOL Intersections_EIK_DoIntersect_BoxBox(Box2d box, Box2d box2);

	//point

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_PointLine(Point2d point, Line2d line);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_PointRay(Point2d point, Ray2d ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_PointSegment(Point2d point, Segment2d segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_PointTriangle(Point2d point, Triangle2d triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_PointBox(Point2d point, Box2d box);

	//line

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_LinePoint(Line2d line, Point2d point);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_LineLine(Line2d line, Line2d line2);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_LineRay(Line2d line, Ray2d ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_LineSegment(Line2d line, Segment2d segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_LineTriangle(Line2d line, Triangle2d triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_LineBox(Line2d line, Box2d box);

	//ray

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_RayPoint(Ray2d ray, Point2d point);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_RayLine(Ray2d ray, Line2d line);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_RayRay(Ray2d ray, Ray2d ray2);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_RaySegment(Ray2d ray, Segment2d segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_RayTriangle(Ray2d ray, Triangle2d triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_RayBox(Ray2d ray, Box2d box);

	//segment

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_SegmentPoint(Segment2d segment, Point2d point);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_SegmentLine(Segment2d segment, Line2d line);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_SegmentRay(Segment2d segment, Ray2d ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_SegmentSegment(Segment2d segment, Segment2d segment2);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_SegmentTriangle(Segment2d segment, Triangle2d triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_SegmentBox(Segment2d segment, Box2d box);

	//triangle

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_TrianglePoint(Triangle2d triangle, Point2d point);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_TriangleLine(Triangle2d triangle, Line2d line);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_TriangleRay(Triangle2d triangle, Ray2d ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_TriangleSegment(Triangle2d triangle, Segment2d segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_TriangleBox(Triangle2d triangle, Box2d box);

	//box

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_BoxPoint(Box2d box, Point2d point);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_BoxLine(Box2d box, Line2d line);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_BoxRay(Box2d box, Ray2d ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_BoxSegment(Box2d box, Segment2d segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_BoxTriangle(Box2d box, Triangle2d triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_EIK_Intersection_BoxBox(Box2d box, Box2d box2);
};

