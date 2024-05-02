
#include "Intersections_shapes_EIK.h"
#include "Intersections_shapes.h"

/*****************************************************
*                                                    *
*            Point2d DoIntersect Functions           *
*                                                    *
******************************************************/

BOOL Intersections_Shapes_EIK_DoIntersect_PointLine(Point2d point, Line2d line)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, line);
}

BOOL Intersections_Shapes_EIK_DoIntersect_PointRay(Point2d point, Ray2d ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, ray);
}

BOOL Intersections_Shapes_EIK_DoIntersect_PointSegment(Point2d point, Segment2d segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, segment);
}

BOOL Intersections_Shapes_EIK_DoIntersect_PointTriangle(Point2d point, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, triangle);
}

BOOL Intersections_Shapes_EIK_DoIntersect_PointBox(Point2d point, Box2d box)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, box);
}

/*****************************************************
*                                                    *
*            Line2d DoIntersect Functions            *
*                                                    *
******************************************************/

BOOL Intersections_Shapes_EIK_DoIntersect_LinePoint(Line2d line, Point2d point)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, point);
}

BOOL Intersections_Shapes_EIK_DoIntersect_LineLine(Line2d line, Line2d line2)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, line2);
}

BOOL Intersections_Shapes_EIK_DoIntersect_LineRay(Line2d line, Ray2d ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, ray);
}

BOOL Intersections_Shapes_EIK_DoIntersect_LineSegment(Line2d line, Segment2d segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, segment);
}

BOOL Intersections_Shapes_EIK_DoIntersect_LineTriangle(Line2d line, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, triangle);
}

BOOL Intersections_Shapes_EIK_DoIntersect_LineBox(Line2d line, Box2d box)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, box);
}

/*****************************************************
*                                                    *
*            Ray2d DoIntersect Functions             *
*                                                    *
******************************************************/

BOOL Intersections_Shapes_EIK_DoIntersect_RayPoint(Ray2d ray, Point2d point)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, point);
}

BOOL Intersections_Shapes_EIK_DoIntersect_RayLine(Ray2d ray, Line2d line)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, line);
}

BOOL Intersections_Shapes_EIK_DoIntersect_RayRay(Ray2d ray, Ray2d ray2)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, ray2);
}

BOOL Intersections_Shapes_EIK_DoIntersect_RaySegment(Ray2d ray, Segment2d segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, segment);
}

BOOL Intersections_Shapes_EIK_DoIntersect_RayTriangle(Ray2d ray, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, triangle);
}

BOOL Intersections_Shapes_EIK_DoIntersect_RayBox(Ray2d ray, Box2d box)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, box);
}

/*****************************************************
*                                                    *
*            Segment2d DoIntersect Functions         *
*                                                    *
******************************************************/

BOOL Intersections_Shapes_EIK_DoIntersect_SegmentPoint(Segment2d segment, Point2d point)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, point);
}

BOOL Intersections_Shapes_EIK_DoIntersect_SegmentLine(Segment2d segment, Line2d line)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, line);
}

BOOL Intersections_Shapes_EIK_DoIntersect_SegmentRay(Segment2d segment, Ray2d ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, ray);
}

BOOL Intersections_Shapes_EIK_DoIntersect_SegmentSegment(Segment2d segment, Segment2d segment2)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, segment2);
}

BOOL Intersections_Shapes_EIK_DoIntersect_SegmentTriangle(Segment2d segment, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, triangle);
}

BOOL Intersections_Shapes_EIK_DoIntersect_SegmentBox(Segment2d segment, Box2d box)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, box);
}

/*****************************************************
*                                                    *
*            Triangle2d DoIntersect Functions        *
*                                                    *
******************************************************/

BOOL Intersections_Shapes_EIK_DoIntersect_TrianglePoint(Triangle2d triangle, Point2d point)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, point);
}

BOOL Intersections_Shapes_EIK_DoIntersect_TriangleLine(Triangle2d triangle, Line2d line)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, line);
}

BOOL Intersections_Shapes_EIK_DoIntersect_TriangleRay(Triangle2d triangle, Ray2d ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, ray);
}

BOOL Intersections_Shapes_EIK_DoIntersect_TriangleSegment(Triangle2d triangle, Segment2d segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, segment);
}

BOOL Intersections_Shapes_EIK_DoIntersect_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, triangle2);
}

BOOL Intersections_Shapes_EIK_DoIntersect_TriangleBox(Triangle2d triangle, Box2d box)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, box);
}

/*****************************************************
*                                                    *
*            Box2d DoIntersect Functions             *
*                                                    *
******************************************************/

BOOL Intersections_Shapes_EIK_DoIntersect_BoxPoint(Box2d box, Point2d point)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, point);
}

BOOL Intersections_Shapes_EIK_DoIntersect_BoxLine(Box2d box, Line2d line)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, line);
}

BOOL Intersections_Shapes_EIK_DoIntersect_BoxRay(Box2d box, Ray2d ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, ray);
}

BOOL Intersections_Shapes_EIK_DoIntersect_BoxSegment(Box2d box, Segment2d segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, segment);
}

BOOL Intersections_Shapes_EIK_DoIntersect_BoxTriangle(Box2d box, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, triangle);
}

BOOL Intersections_Shapes_EIK_DoIntersect_BoxBox(Box2d box, Box2d box2)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, box2);
}

/*****************************************************
*                                                    *
*            Point2d Intersection Functions          *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointLine(Point2d point, Line2d line)
{
	return Intersections_Shapes<EIK>::Intersection(point, line);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointRay(Point2d point, Ray2d ray)
{
	return Intersections_Shapes<EIK>::Intersection(point, ray);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointSegment(Point2d point, Segment2d segment)
{
	return Intersections_Shapes<EIK>::Intersection(point, segment);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointTriangle(Point2d point, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::Intersection(point, triangle);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointBox(Point2d point, Box2d box)
{
	return Intersections_Shapes<EIK>::Intersection(point, box);
}

/*****************************************************
*                                                    *
*            Line2d Intersection Functions           *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Shapes_EIK_Intersection_LinePoint(Line2d line, Point2d point)
{
	return Intersections_Shapes<EIK>::Intersection(point, line);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineLine(Line2d line, Line2d line2)
{
	return Intersections_Shapes<EIK>::Intersection(line, line2);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineRay(Line2d line, Ray2d ray)
{
	return Intersections_Shapes<EIK>::Intersection(line, ray);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineSegment(Line2d line, Segment2d segment)
{
	return Intersections_Shapes<EIK>::Intersection(line, segment);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineTriangle(Line2d line, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::Intersection(line, triangle);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineBox(Line2d line, Box2d box)
{
	return Intersections_Shapes<EIK>::Intersection(line, box);
}

/*****************************************************
*                                                    *
*            Ray2d Intersection Functions            *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayPoint(Ray2d ray, Point2d point)
{
	return Intersections_Shapes<EIK>::Intersection(ray, point);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayLine(Ray2d ray, Line2d line)
{
	return Intersections_Shapes<EIK>::Intersection(ray, line);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayRay(Ray2d ray, Ray2d ray2)
{
	return Intersections_Shapes<EIK>::Intersection(ray, ray2);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_RaySegment(Ray2d ray, Segment2d segment)
{
	return Intersections_Shapes<EIK>::Intersection(ray, segment);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayTriangle(Ray2d ray, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::Intersection(ray, triangle);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayBox(Ray2d ray, Box2d box)
{
	return Intersections_Shapes<EIK>::Intersection(ray, box);
}

/*****************************************************
*                                                    *
*            Segment2d Intersection Functions        *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentPoint(Segment2d segment, Point2d point)
{
	return Intersections_Shapes<EIK>::Intersection(segment, point);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentLine(Segment2d segment, Line2d line)
{
	return Intersections_Shapes<EIK>::Intersection(segment, line);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentRay(Segment2d segment, Ray2d ray)
{
	return Intersections_Shapes<EIK>::Intersection(segment, ray);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentSegment(Segment2d segment, Segment2d segment2)
{
	return Intersections_Shapes<EIK>::Intersection(segment, segment);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentTriangle(Segment2d segment, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::Intersection(segment, triangle);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentBox(Segment2d segment, Box2d box)
{
	return Intersections_Shapes<EIK>::Intersection(segment, box);
}

/*****************************************************
*                                                    *
*            Triangle2d Intersection Functions       *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Shapes_EIK_Intersection_TrianglePoint(Triangle2d triangle, Point2d point)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, point);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleLine(Triangle2d triangle, Line2d line)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, line);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleRay(Triangle2d triangle, Ray2d ray)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, ray);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleSegment(Triangle2d triangle, Segment2d segment)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, segment);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, triangle2);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleBox(Triangle2d triangle, Box2d box)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, box);
}

/*****************************************************
*                                                    *
*            Box2d Intersection Functions            *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxPoint(Box2d box, Point2d point)
{
	return Intersections_Shapes<EIK>::Intersection(box, point);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxLine(Box2d box, Line2d line)
{
	return Intersections_Shapes<EIK>::Intersection(box, line);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxRay(Box2d box, Ray2d ray)
{
	return Intersections_Shapes<EIK>::Intersection(box, ray);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxSegment(Box2d box, Segment2d segment)
{
	return Intersections_Shapes<EIK>::Intersection(box, segment);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxTriangle(Box2d box, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::Intersection(box, triangle);
}

IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxBox(Box2d box, Box2d box2)
{
	return Intersections_Shapes<EIK>::Intersection(box, box2);
}

/*****************************************************
*                                                    *
*            Point2d SqrDistance Functions           *
*                                                    *
******************************************************/

double Intersections_Shapes_EIK_SqrDistance_PointPoint(Point2d point, Point2d point2)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, point2);
}

double Intersections_Shapes_EIK_SqrDistance_PointLine(Point2d point, Line2d line)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, line);
}

double Intersections_Shapes_EIK_SqrDistance_PointRay(Point2d point, Ray2d ray)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, ray);
}

double Intersections_Shapes_EIK_SqrDistance_PointSegment(Point2d point, Segment2d segment)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, segment);
}

double Intersections_Shapes_EIK_SqrDistance_PointTriangle(Point2d point, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, triangle);
}

/*****************************************************
*                                                    *
*            Line2d SqrDistance Functions            *
*                                                    *
******************************************************/

double Intersections_Shapes_EIK_SqrDistance_LinePoint(Line2d line, Point2d point)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, point);
}

double Intersections_Shapes_EIK_SqrDistance_LineLine(Line2d line, Line2d line2)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, line2);
}

double Intersections_Shapes_EIK_SqrDistance_LineRay(Line2d line, Ray2d ray)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, ray);
}

double Intersections_Shapes_EIK_SqrDistance_LineSegment(Line2d line, Segment2d segment)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, segment);
}

double Intersections_Shapes_EIK_SqrDistance_LineTriangle(Line2d line, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, triangle);
}

/*****************************************************
*                                                    *
*            Ray2d SqrDistance Functions             *
*                                                    *
******************************************************/

double Intersections_Shapes_EIK_SqrDistance_RayPoint(Ray2d ray, Point2d point)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, point);
}

double Intersections_Shapes_EIK_SqrDistance_RayLine(Ray2d ray, Line2d line)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, line);
}

double Intersections_Shapes_EIK_SqrDistance_RayRay(Ray2d ray, Ray2d ray2)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, ray2);
}

double Intersections_Shapes_EIK_SqrDistance_RaySegment(Ray2d ray, Segment2d segment)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, segment);
}

double Intersections_Shapes_EIK_SqrDistance_RayTriangle(Ray2d ray, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, triangle);
}

/*****************************************************
*                                                    *
*            Segment2d SqrDistance Functions         *
*                                                    *
******************************************************/

double Intersections_Shapes_EIK_SqrDistance_SegmentPoint(Segment2d segment, Point2d point)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, point);
}

double Intersections_Shapes_EIK_SqrDistance_SegmentLine(Segment2d segment, Line2d line)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, line);
}

double Intersections_Shapes_EIK_SqrDistance_SegmentRay(Segment2d segment, Ray2d ray)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, ray);
}

double Intersections_Shapes_EIK_SqrDistance_SegmentSegment(Segment2d segment, Segment2d segment2)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, segment2);
}

double Intersections_Shapes_EIK_SqrDistance_SegmentTriangle(Segment2d segment, Triangle2d triangle)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, triangle);
}

/*****************************************************
*                                                    *
*            Triangle2d SqrDistance Functions        *
*                                                    *
******************************************************/

double Intersections_Shapes_EIK_SqrDistance_TrianglePoint(Triangle2d triangle, Point2d point)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, point);
}

double Intersections_Shapes_EIK_SqrDistance_TriangleLine(Triangle2d triangle, Line2d line)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, line);
}

double Intersections_Shapes_EIK_SqrDistance_TriangleRay(Triangle2d triangle, Ray2d ray)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, ray);
}

double Intersections_Shapes_EIK_SqrDistance_TriangleSegment(Triangle2d triangle, Segment2d segment)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, segment);
}

double Intersections_Shapes_EIK_SqrDistance_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, triangle2);
}


