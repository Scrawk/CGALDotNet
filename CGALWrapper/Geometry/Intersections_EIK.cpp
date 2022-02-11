#include "../pch.h"
#include "Intersections_EIK.h"
#include "Intersections.h"

//Point

BOOL Intersections_EIK_DoIntersect_PointLine(Point2d point, Line2d line)
{
	return Intersections<EIK>::DoIntersect(point, line);
}

BOOL Intersections_EIK_DoIntersect_PointRay(Point2d point, Ray2d ray)
{
	return Intersections<EIK>::DoIntersect(point, ray);
}

BOOL Intersections_EIK_DoIntersect_PointSegment(Point2d point, Segment2d segment)
{
	return Intersections<EIK>::DoIntersect(point, segment);
}

BOOL Intersections_EIK_DoIntersect_PointTriangle(Point2d point, Triangle2d triangle)
{
	return Intersections<EIK>::DoIntersect(point, triangle);
}

BOOL Intersections_EIK_DoIntersect_PointBox(Point2d point, Box2d box)
{
	return Intersections<EIK>::DoIntersect(point, box);
}

//Line

BOOL Intersections_EIK_DoIntersect_LinePoint(Line2d line, Point2d point)
{
	return Intersections<EIK>::DoIntersect(line, point);
}

BOOL Intersections_EIK_DoIntersect_LineLine(Line2d line, Line2d line2)
{
	return Intersections<EIK>::DoIntersect(line, line2);
}

BOOL Intersections_EIK_DoIntersect_LineRay(Line2d line, Ray2d ray)
{
	return Intersections<EIK>::DoIntersect(line, ray);
}

BOOL Intersections_EIK_DoIntersect_LineSegment(Line2d line, Segment2d segment)
{
	return Intersections<EIK>::DoIntersect(line, segment);
}

BOOL Intersections_EIK_DoIntersect_LineTriangle(Line2d line, Triangle2d triangle)
{
	return Intersections<EIK>::DoIntersect(line, triangle);
}

BOOL Intersections_EIK_DoIntersect_LineBox(Line2d line, Box2d box)
{
	return Intersections<EIK>::DoIntersect(line, box);
}

//Ray

BOOL Intersections_EIK_DoIntersect_RayPoint(Ray2d ray, Point2d point)
{
	return Intersections<EIK>::DoIntersect(ray, point);
}

BOOL Intersections_EIK_DoIntersect_RayLine(Ray2d ray, Line2d line)
{
	return Intersections<EIK>::DoIntersect(ray, line);
}

BOOL Intersections_EIK_DoIntersect_RayRay(Ray2d ray, Ray2d ray2)
{
	return Intersections<EIK>::DoIntersect(ray, ray2);
}

BOOL Intersections_EIK_DoIntersect_RaySegment(Ray2d ray, Segment2d segment)
{
	return Intersections<EIK>::DoIntersect(ray, segment);
}

BOOL Intersections_EIK_DoIntersect_RayTriangle(Ray2d ray, Triangle2d triangle)
{
	return Intersections<EIK>::DoIntersect(ray, triangle);
}

BOOL Intersections_EIK_DoIntersect_RayBox(Ray2d ray, Box2d box)
{
	return Intersections<EIK>::DoIntersect(ray, box);
}

//Segment

BOOL Intersections_EIK_DoIntersect_SegmentPoint(Segment2d segment, Point2d point)
{
	return Intersections<EIK>::DoIntersect(segment, point);
}

BOOL Intersections_EIK_DoIntersect_SegmentLine(Segment2d segment, Line2d line)
{
	return Intersections<EIK>::DoIntersect(segment, line);
}

BOOL Intersections_EIK_DoIntersect_SegmentRay(Segment2d segment, Ray2d ray)
{
	return Intersections<EIK>::DoIntersect(segment, ray);
}

BOOL Intersections_EIK_DoIntersect_SegmentSegment(Segment2d segment, Segment2d segment2)
{
	return Intersections<EIK>::DoIntersect(segment, segment2);
}

BOOL Intersections_EIK_DoIntersect_SegmentTriangle(Segment2d segment, Triangle2d triangle)
{
	return Intersections<EIK>::DoIntersect(segment, triangle);
}

BOOL Intersections_EIK_DoIntersect_SegmentBox(Segment2d segment, Box2d box)
{
	return Intersections<EIK>::DoIntersect(segment, box);
}

//Triangle

BOOL Intersections_EIK_DoIntersect_TrianglePoint(Triangle2d triangle, Point2d point)
{
	return Intersections<EIK>::DoIntersect(triangle, point);
}

BOOL Intersections_EIK_DoIntersect_TriangleLine(Triangle2d triangle, Line2d line)
{
	return Intersections<EIK>::DoIntersect(triangle, line);
}

BOOL Intersections_EIK_DoIntersect_TriangleRay(Triangle2d triangle, Ray2d ray)
{
	return Intersections<EIK>::DoIntersect(triangle, ray);
}

BOOL Intersections_EIK_DoIntersect_TriangleSegment(Triangle2d triangle, Segment2d segment)
{
	return Intersections<EIK>::DoIntersect(triangle, segment);
}

BOOL Intersections_EIK_DoIntersect_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2)
{
	return Intersections<EIK>::DoIntersect(triangle, triangle2);
}

BOOL Intersections_EIK_DoIntersect_TriangleBox(Triangle2d triangle, Box2d box)
{
	return Intersections<EIK>::DoIntersect(triangle, box);
}

//Box

BOOL Intersections_EIK_DoIntersect_BoxPoint(Box2d box, Point2d point)
{
	return Intersections<EIK>::DoIntersect(box, point);
}

BOOL Intersections_EIK_DoIntersect_BoxLine(Box2d box, Line2d line)
{
	return Intersections<EIK>::DoIntersect(box, line);
}

BOOL Intersections_EIK_DoIntersect_BoxRay(Box2d box, Ray2d ray)
{
	return Intersections<EIK>::DoIntersect(box, ray);
}

BOOL Intersections_EIK_DoIntersect_BoxSegment(Box2d box, Segment2d segment)
{
	return Intersections<EIK>::DoIntersect(box, segment);
}

BOOL Intersections_EIK_DoIntersect_BoxTriangle(Box2d box, Triangle2d triangle)
{
	return Intersections<EIK>::DoIntersect(box, triangle);
}

BOOL Intersections_EIK_DoIntersect_BoxBox(Box2d box, Box2d box2)
{
	return Intersections<EIK>::DoIntersect(box, box2);
}

//Point

IntersectionResult2d Intersections_EIK_Intersection_PointLine(Point2d point, Line2d line)
{
	return Intersections<EIK>::Intersection(point, line);
}

IntersectionResult2d Intersections_EIK_Intersection_PointRay(Point2d point, Ray2d ray)
{
	return Intersections<EIK>::Intersection(point, ray);
}

IntersectionResult2d Intersections_EIK_Intersection_PointSegment(Point2d point, Segment2d segment)
{
	return Intersections<EIK>::Intersection(point, segment);
}

IntersectionResult2d Intersections_EIK_Intersection_PointTriangle(Point2d point, Triangle2d triangle)
{
	return Intersections<EIK>::Intersection(point, triangle);
}

IntersectionResult2d Intersections_EIK_Intersection_PointBox(Point2d point, Box2d box)
{
	return Intersections<EIK>::Intersection(point, box);
}

//Line

IntersectionResult2d Intersections_EIK_Intersection_LinePoint(Line2d line, Point2d point)
{
	return Intersections<EIK>::Intersection(point, line);
}

IntersectionResult2d Intersections_EIK_Intersection_LineLine(Line2d line, Line2d line2)
{
	return Intersections<EIK>::Intersection(line, line2);
}

IntersectionResult2d Intersections_EIK_Intersection_LineRay(Line2d line, Ray2d ray)
{
	return Intersections<EIK>::Intersection(line, ray);
}

IntersectionResult2d Intersections_EIK_Intersection_LineSegment(Line2d line, Segment2d segment)
{
	return Intersections<EIK>::Intersection(line, segment);
}

IntersectionResult2d Intersections_EIK_Intersection_LineTriangle(Line2d line, Triangle2d triangle)
{
	return Intersections<EIK>::Intersection(line, triangle);
}

IntersectionResult2d Intersections_EIK_Intersection_LineBox(Line2d line, Box2d box)
{
	return Intersections<EIK>::Intersection(line, box);
}

//Ray

IntersectionResult2d Intersections_EIK_Intersection_RayPoint(Ray2d ray, Point2d point)
{
	return Intersections<EIK>::Intersection(ray, point);
}

IntersectionResult2d Intersections_EIK_Intersection_RayLine(Ray2d ray, Line2d line)
{
	return Intersections<EIK>::Intersection(ray, line);
}

IntersectionResult2d Intersections_EIK_Intersection_RayRay(Ray2d ray, Ray2d ray2)
{
	return Intersections<EIK>::Intersection(ray, ray2);
}

IntersectionResult2d Intersections_EIK_Intersection_RaySegment(Ray2d ray, Segment2d segment)
{
	return Intersections<EIK>::Intersection(ray, segment);
}

IntersectionResult2d Intersections_EIK_Intersection_RayTriangle(Ray2d ray, Triangle2d triangle)
{
	return Intersections<EIK>::Intersection(ray, triangle);
}

IntersectionResult2d Intersections_EIK_Intersection_RayBox(Ray2d ray, Box2d box)
{
	return Intersections<EIK>::Intersection(ray, box);
}

//Segment

IntersectionResult2d Intersections_EIK_Intersection_SegmentPoint(Segment2d segment, Point2d point)
{
	return Intersections<EIK>::Intersection(segment, point);
}

IntersectionResult2d Intersections_EIK_Intersection_SegmentLine(Segment2d segment, Line2d line)
{
	return Intersections<EIK>::Intersection(segment, line);
}

IntersectionResult2d Intersections_EIK_Intersection_SegmentRay(Segment2d segment, Ray2d ray)
{
	return Intersections<EIK>::Intersection(segment, ray);
}

IntersectionResult2d Intersections_EIK_Intersection_SegmentSegment(Segment2d segment, Segment2d segment2)
{
	return Intersections<EIK>::Intersection(segment, segment);
}

IntersectionResult2d Intersections_EIK_Intersection_SegmentTriangle(Segment2d segment, Triangle2d triangle)
{
	return Intersections<EIK>::Intersection(segment, triangle);
}

IntersectionResult2d Intersections_EIK_Intersection_SegmentBox(Segment2d segment, Box2d box)
{
	return Intersections<EIK>::Intersection(segment, box);
}

//Triangle

IntersectionResult2d Intersections_EIK_Intersection_TrianglePoint(Triangle2d triangle, Point2d point)
{
	return Intersections<EIK>::Intersection(triangle, point);
}

IntersectionResult2d Intersections_EIK_Intersection_TriangleLine(Triangle2d triangle, Line2d line)
{
	return Intersections<EIK>::Intersection(triangle, line);
}

IntersectionResult2d Intersections_EIK_Intersection_TriangleRay(Triangle2d triangle, Ray2d ray)
{
	return Intersections<EIK>::Intersection(triangle, ray);
}

IntersectionResult2d Intersections_EIK_Intersection_TriangleSegment(Triangle2d triangle, Segment2d segment)
{
	return Intersections<EIK>::Intersection(triangle, segment);
}

IntersectionResult2d Intersections_EIK_Intersection_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2)
{
	return Intersections<EIK>::Intersection(triangle, triangle2);
}

IntersectionResult2d Intersections_EIK_Intersection_TriangleBox(Triangle2d triangle, Box2d box)
{
	return Intersections<EIK>::Intersection(triangle, box);
}

//Box

IntersectionResult2d Intersections_EIK_Intersection_BoxPoint(Box2d box, Point2d point)
{
	return Intersections<EIK>::Intersection(box, point);
}

IntersectionResult2d Intersections_EIK_Intersection_BoxLine(Box2d box, Line2d line)
{
	return Intersections<EIK>::Intersection(box, line);
}

IntersectionResult2d Intersections_EIK_Intersection_BoxRay(Box2d box, Ray2d ray)
{
	return Intersections<EIK>::Intersection(box, ray);
}

IntersectionResult2d Intersections_EIK_Intersection_BoxSegment(Box2d box, Segment2d segment)
{
	return Intersections<EIK>::Intersection(box, segment);
}

IntersectionResult2d Intersections_EIK_Intersection_BoxTriangle(Box2d box, Triangle2d triangle)
{
	return Intersections<EIK>::Intersection(box, triangle);
}

IntersectionResult2d Intersections_EIK_Intersection_BoxBox(Box2d box, Box2d box2)
{
	return Intersections<EIK>::Intersection(box, box2);
}
