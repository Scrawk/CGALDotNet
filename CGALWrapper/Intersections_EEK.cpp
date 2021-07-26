#include "pch.h"
#include "Intersections_EEK.h"
#include "Intersections.h"

//Point

BOOL Intersections_EEK_DoIntersect_PointLine(Point2d point, Line2d line)
{
	return Intersections<EEK>::DoIntersect(point, line);
}

BOOL Intersections_EEK_DoIntersect_PointRay(Point2d point, Ray2d ray)
{
	return Intersections<EEK>::DoIntersect(point, ray);
}

BOOL Intersections_EEK_DoIntersect_PointSegment(Point2d point, Segment2d segment)
{
	return Intersections<EEK>::DoIntersect(point, segment);
}

BOOL Intersections_EEK_DoIntersect_PointTriangle(Point2d point, Triangle2d triangle)
{
	return Intersections<EEK>::DoIntersect(point, triangle);
}

BOOL Intersections_EEK_DoIntersect_PointBox(Point2d point, Box2d box)
{
	return Intersections<EEK>::DoIntersect(point, box);
}

//Line

BOOL Intersections_EEK_DoIntersect_LinePoint(Line2d line, Point2d point)
{
	return Intersections<EEK>::DoIntersect(line, point);
}

BOOL Intersections_EEK_DoIntersect_LineLine(Line2d line, Line2d line2)
{
	return Intersections<EEK>::DoIntersect(line, line2);
}

BOOL Intersections_EEK_DoIntersect_LineRay(Line2d line, Ray2d ray)
{
	return Intersections<EEK>::DoIntersect(line, ray);
}

BOOL Intersections_EEK_DoIntersect_LineSegment(Line2d line, Segment2d segment)
{
	return Intersections<EEK>::DoIntersect(line, segment);
}

BOOL Intersections_EEK_DoIntersect_LineTriangle(Line2d line, Triangle2d triangle)
{
	return Intersections<EEK>::DoIntersect(line, triangle);
}

BOOL Intersections_EEK_DoIntersect_LineBox(Line2d line, Box2d box)
{
	return Intersections<EEK>::DoIntersect(line, box);
}

//Ray

BOOL Intersections_EEK_DoIntersect_RayPoint(Ray2d ray, Point2d point)
{
	return Intersections<EEK>::DoIntersect(ray, point);
}

BOOL Intersections_EEK_DoIntersect_RayLine(Ray2d ray, Line2d line)
{
	return Intersections<EEK>::DoIntersect(ray, line);
}

BOOL Intersections_EEK_DoIntersect_RayRay(Ray2d ray, Ray2d ray2)
{
	return Intersections<EEK>::DoIntersect(ray, ray2);
}

BOOL Intersections_EEK_DoIntersect_RaySegment(Ray2d ray, Segment2d segment)
{
	return Intersections<EEK>::DoIntersect(ray, segment);
}

BOOL Intersections_EEK_DoIntersect_RayTriangle(Ray2d ray, Triangle2d triangle)
{
	return Intersections<EEK>::DoIntersect(ray, triangle);
}

BOOL Intersections_EEK_DoIntersect_RayBox(Ray2d ray, Box2d box)
{
	return Intersections<EEK>::DoIntersect(ray, box);
}

//Point

IntersectionResult2d Intersections_EEK_Intersection_PointLine(Point2d point, Line2d line)
{
	return Intersections<EEK>::Intersection(point, line);
}

IntersectionResult2d Intersections_EEK_Intersection_PointRay(Point2d point, Ray2d ray)
{
	return Intersections<EEK>::Intersection(point, ray);
}

IntersectionResult2d Intersections_EEK_Intersection_PointSegment(Point2d point, Segment2d segment)
{
	return Intersections<EEK>::Intersection(point, segment);
}

IntersectionResult2d Intersections_EEK_Intersection_PointTriangle(Point2d point, Triangle2d triangle)
{
	return Intersections<EEK>::Intersection(point, triangle);
}

IntersectionResult2d Intersections_EEK_Intersection_PointBox(Point2d point, Box2d box)
{
	return Intersections<EEK>::Intersection(point, box);
}

//Line

IntersectionResult2d Intersections_EEK_Intersection_LinePoint(Line2d line, Point2d point)
{
	return Intersections<EEK>::Intersection(point, line);
}

IntersectionResult2d Intersections_EEK_Intersection_LineLine(Line2d line, Line2d line2)
{
	return Intersections<EEK>::Intersection(line, line2);
}

IntersectionResult2d Intersections_EEK_Intersection_LineRay(Line2d line, Ray2d ray)
{
	return Intersections<EEK>::Intersection(line, ray);
}

IntersectionResult2d Intersections_EEK_Intersection_LineSegment(Line2d line, Segment2d segment)
{
	return Intersections<EEK>::Intersection(line, segment);
}

IntersectionResult2d Intersections_EEK_Intersection_LineTriangle(Line2d line, Triangle2d triangle)
{
	return Intersections<EEK>::Intersection(line, triangle);
}

IntersectionResult2d Intersections_EEK_Intersection_LineBox(Line2d line, Box2d box)
{
	return Intersections<EEK>::Intersection(line, box);
}

//Ray

IntersectionResult2d Intersections_EEK_Intersection_LinePoint(Ray2d ray, Point2d point)
{
	return Intersections<EEK>::Intersection(ray, point);
}

IntersectionResult2d Intersections_EEK_Intersection_LineLine(Ray2d ray, Line2d line)
{
	return Intersections<EEK>::Intersection(ray, line);
}

IntersectionResult2d Intersections_EEK_Intersection_LineRay(Ray2d ray, Ray2d ray2)
{
	return Intersections<EEK>::Intersection(ray, ray2);
}

IntersectionResult2d Intersections_EEK_Intersection_LineSegment(Ray2d ray, Segment2d segment)
{
	return Intersections<EEK>::Intersection(ray, segment);
}

IntersectionResult2d Intersections_EEK_Intersection_LineTriangle(Ray2d ray, Triangle2d triangle)
{
	return Intersections<EEK>::Intersection(ray, triangle);
}

IntersectionResult2d Intersections_EEK_Intersection_LineBox(Ray2d ray, Box2d box)
{
	return Intersections<EEK>::Intersection(ray, box);
}
