
#include "Intersections_geometry_EIK.h"
#include "Intersections_geometry.h"

/*****************************************************
*                                                    *
*            Point2 DoIntersect Functions            *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_PointLine(void* point, void* line)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointLine(point, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointRay(void* point, void* ray)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointRay(point, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointSegment(void* point, void* segment)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointSegment(point, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointTriangle(void* point, void* triangle)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointTriangle(point, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointBox(void* point, void* box)
{
	return Intersections_Geometry<EIK>::DoIntersect_PointBox(point, box);
}

/*****************************************************
*                                                    *
*            Line2 DoIntersect Functions             *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_LinePoint(void* line, void* point)
{
	return Intersections_Geometry<EIK>::DoIntersect_LinePoint(line, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineLine(void* line, void* line2)
{
	return Intersections_Geometry<EIK>::DoIntersect_LineLine(line, line2);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineRay(void* line, void* ray)
{
	return Intersections_Geometry<EIK>::DoIntersect_LineRay(line, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineSegment(void* line, void* segment)
{
	return Intersections_Geometry<EIK>::DoIntersect_LineSegment(line, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineTriangle(void* line, void* triangle)
{
	return Intersections_Geometry<EIK>::DoIntersect_LineTriangle(line, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineBox(void* line, void* box)
{
	return Intersections_Geometry<EIK>::DoIntersect_LineBox(line, box);
}

/*****************************************************
*                                                    *
*            Ray2 DoIntersect Functions              *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_RayPoint(void* ray, void* point)
{
	return Intersections_Geometry<EIK>::DoIntersect_RayPoint(ray, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RayLine(void* ray, void* line)
{
	return Intersections_Geometry<EIK>::DoIntersect_RayLine(ray, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RayRay(void* ray, void* ray2)
{
	return Intersections_Geometry<EIK>::DoIntersect_RayRay(ray, ray2);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RaySegment(void* ray, void* segment)
{
	return Intersections_Geometry<EIK>::DoIntersect_RaySegment(ray, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RayTriangle(void* ray, void* triangle)
{
	return Intersections_Geometry<EIK>::DoIntersect_RayTriangle(ray, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RayBox(void* ray, void* box)
{
	return Intersections_Geometry<EIK>::DoIntersect_RayBox(ray, box);
}

/*****************************************************
*                                                    *
*            Segment2 DoIntersect Functions          *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentPoint(void* segment, void* point)
{
	return Intersections_Geometry<EIK>::DoIntersect_SegmentPoint(segment, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentLine(void* segment, void* line)
{
	return Intersections_Geometry<EIK>::DoIntersect_SegmentLine(segment, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentRay(void* segment, void* ray)
{
	return Intersections_Geometry<EIK>::DoIntersect_SegmentRay(segment, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentSegment(void* segment, void* segment2)
{
	return Intersections_Geometry<EIK>::DoIntersect_SegmentSegment(segment, segment2);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentTriangle(void* segment, void* triangle)
{
	return Intersections_Geometry<EIK>::DoIntersect_SegmentTriangle(segment, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentBox(void* segment, void* box)
{
	return Intersections_Geometry<EIK>::DoIntersect_SegmentBox(segment, box);
}

/*****************************************************
*                                                    *
*            Triangle DoIntersect Functions          *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_TrianglePoint(void* triangle, void* point)
{
	return Intersections_Geometry<EIK>::DoIntersect_TrianglePoint(triangle, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleLine(void* triangle, void* line)
{
	return Intersections_Geometry<EIK>::DoIntersect_TriangleLine(triangle, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleRay(void* triangle, void* ray)
{
	return Intersections_Geometry<EIK>::DoIntersect_TriangleRay(triangle, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleSegment(void* triangle, void* segment)
{
	return Intersections_Geometry<EIK>::DoIntersect_TriangleSegment(triangle, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleTriangle(void* triangle, void* triangle2)
{
	return Intersections_Geometry<EIK>::DoIntersect_TriangleTriangle(triangle, triangle2);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleBox(void* triangle, void* box)
{
	return Intersections_Geometry<EIK>::DoIntersect_TriangleBox(triangle, box);
}

/*****************************************************
*                                                    *
*            Box2 DoIntersect Functions             *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_BoxPoint(void* box, void* point)
{
	return Intersections_Geometry<EIK>::DoIntersect_BoxPoint(box, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxLine(void* box, void* line)
{
	return Intersections_Geometry<EIK>::DoIntersect_BoxLine(box, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxRay(void* box, void* ray)
{
	return Intersections_Geometry<EIK>::DoIntersect_BoxRay(box, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxSegment(void* box, void* segment)
{
	return Intersections_Geometry<EIK>::DoIntersect_BoxSegment(box, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxTriangle(void* box, void* triangle)
{
	return Intersections_Geometry<EIK>::DoIntersect_BoxTriangle(box, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxBox(void* box, void* box2)
{
	return Intersections_Geometry<EIK>::DoIntersect_BoxBox(box, box2);
}

/*****************************************************
*                                                    *
*            Point2 Intersection Functions           *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointLine(void* point, void* line)
{
	return Intersections_Geometry<EIK>::Intersection_PointLine(point, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointRay(void* point, void* ray)
{
	return Intersections_Geometry<EIK>::Intersection_PointRay(point, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointSegment(void* point, void* segment)
{
	return Intersections_Geometry<EIK>::Intersection_PointSegment(point, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointTriangle(void* point, void* triangle)
{
	return Intersections_Geometry<EIK>::Intersection_PointTriangle(point, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointBox(void* point, void* box)
{
	return Intersections_Geometry<EIK>::Intersection_PointBox(point, box);
}

/*****************************************************
*                                                    *
*            Line Intersection Functions             *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LinePoint(void* line, void* point)
{
	return Intersections_Geometry<EIK>::Intersection_LinePoint(point, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineLine(void* line, void* line2)
{
	return Intersections_Geometry<EIK>::Intersection_LineLine(line, line2);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineRay(void* line, void* ray)
{
	return Intersections_Geometry<EIK>::Intersection_LineRay(line, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineSegment(void* line, void* segment)
{
	return Intersections_Geometry<EIK>::Intersection_LineSegment(line, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineTriangle(void* line, void* triangle)
{
	return Intersections_Geometry<EIK>::Intersection_LineTriangle(line, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineBox(void* line, void* box)
{
	return Intersections_Geometry<EIK>::Intersection_LineBox(line, box);
}

/*****************************************************
*                                                    *
*            Ray2 Intersection Functions             *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayPoint(void* ray, void* point)
{
	return Intersections_Geometry<EIK>::Intersection_RayPoint(ray, point);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayLine(void* ray, void* line)
{
	return Intersections_Geometry<EIK>::Intersection_RayLine(ray, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayRay(void* ray, void* ray2)
{
	return Intersections_Geometry<EIK>::Intersection_RayRay(ray, ray2);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RaySegment(void* ray, void* segment)
{
	return Intersections_Geometry<EIK>::Intersection_RaySegment(ray, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayTriangle(void* ray, void* triangle)
{
	return Intersections_Geometry<EIK>::Intersection_RayTriangle(ray, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayBox(void* ray, void* box)
{
	return Intersections_Geometry<EIK>::Intersection_RayBox(ray, box);
}

/*****************************************************
*                                                    *
*            Segment2 Intersection Functions         *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentPoint(void* segment, void* point)
{
	return Intersections_Geometry<EIK>::Intersection_SegmentPoint(segment, point);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentLine(void* segment, void* line)
{
	return Intersections_Geometry<EIK>::Intersection_SegmentLine(segment, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentRay(void* segment, void* ray)
{
	return Intersections_Geometry<EIK>::Intersection_SegmentRay(segment, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentSegment(void* segment, void* segment2)
{
	return Intersections_Geometry<EIK>::Intersection_SegmentSegment(segment, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentTriangle(void* segment, void* triangle)
{
	return Intersections_Geometry<EIK>::Intersection_SegmentTriangle(segment, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentBox(void* segment, void* box)
{
	return Intersections_Geometry<EIK>::Intersection_SegmentBox(segment, box);
}

/*****************************************************
*                                                    *
*            Triangle2 Intersection Functions        *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TrianglePoint(void* triangle, void* point)
{
	return Intersections_Geometry<EIK>::Intersection_TrianglePoint(triangle, point);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleLine(void* triangle, void* line)
{
	return Intersections_Geometry<EIK>::Intersection_TriangleLine(triangle, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleRay(void* triangle, void* ray)
{
	return Intersections_Geometry<EIK>::Intersection_TriangleRay(triangle, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleSegment(void* triangle, void* segment)
{
	return Intersections_Geometry<EIK>::Intersection_TriangleSegment(triangle, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleTriangle(void* triangle, void* triangle2)
{
	return Intersections_Geometry<EIK>::Intersection_TriangleTriangle(triangle, triangle2);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleBox(void* triangle, void* box)
{
	return Intersections_Geometry<EIK>::Intersection_TriangleBox(triangle, box);
}

/*****************************************************
*                                                    *
*            Box2 Intersection Functions             *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxPoint(void* box, void* point)
{
	return Intersections_Geometry<EIK>::Intersection_BoxPoint(box, point);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxLine(void* box, void* line)
{
	return Intersections_Geometry<EIK>::Intersection_BoxLine(box, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxRay(void* box, void* ray)
{
	return Intersections_Geometry<EIK>::Intersection_BoxRay(box, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxSegment(void* box, void* segment)
{
	return Intersections_Geometry<EIK>::Intersection_BoxSegment(box, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxTriangle(void* box, void* triangle)
{
	return Intersections_Geometry<EIK>::Intersection_BoxTriangle(box, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxBox(void* box, void* box2)
{
	return Intersections_Geometry<EIK>::Intersection_BoxBox(box, box2);
}

/*****************************************************
*                                                    *
*            Point2 SqrDistance Functions            *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_PointPoint(void* point, void* point2)
{
	return Intersections_Geometry<EIK>::SqrDistance_PointPoint(point, point2);
}

double Intersections_Geometry_EIK_SqrDistance_PointLine(void* point, void* line)
{
	return Intersections_Geometry<EIK>::SqrDistance_PointLine(point, line);
}

double Intersections_Geometry_EIK_SqrDistance_PointRay(void* point, void* ray)
{
	return Intersections_Geometry<EIK>::SqrDistance_PointRay(point, ray);
}

double Intersections_Geometry_EIK_SqrDistance_PointSegment(void* point, void* segment)
{
	return Intersections_Geometry<EIK>::SqrDistance_PointSegment(point, segment);
}

double Intersections_Geometry_EIK_SqrDistance_PointTriangle(void* point, void* triangle)
{
	return Intersections_Geometry<EIK>::SqrDistance_PointTriangle(point, triangle);
}

/*****************************************************
*                                                    *
*            Line2 SqrDistance Functions             *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_LinePoint(void* line, void* point)
{
	return Intersections_Geometry<EIK>::SqrDistance_LinePoint(line, point);
}

double Intersections_Geometry_EIK_SqrDistance_LineLine(void* line, void* line2)
{
	return Intersections_Geometry<EIK>::SqrDistance_LineLine(line, line2);
}

double Intersections_Geometry_EIK_SqrDistance_LineRay(void* line, void* ray)
{
	return Intersections_Geometry<EIK>::SqrDistance_LineRay(line, ray);
}

double Intersections_Geometry_EIK_SqrDistance_LineSegment(void* line, void* segment)
{
	return Intersections_Geometry<EIK>::SqrDistance_LineSegment(line, segment);
}

double Intersections_Geometry_EIK_SqrDistance_LineTriangle(void* line, void* triangle)
{
	return Intersections_Geometry<EIK>::SqrDistance_LineTriangle(line, triangle);
}

/*****************************************************
*                                                    *
*            Ray2 SqrDistance Functions              *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_RayPoint(void* ray, void* point)
{
	return Intersections_Geometry<EIK>::SqrDistance_RayPoint(ray, point);
}

double Intersections_Geometry_EIK_SqrDistance_RayLine(void* ray, void* line)
{
	return Intersections_Geometry<EIK>::SqrDistance_RayLine(ray, line);
}

double Intersections_Geometry_EIK_SqrDistance_RayRay(void* ray, void* ray2)
{
	return Intersections_Geometry<EIK>::SqrDistance_RayRay(ray, ray2);
}

double Intersections_Geometry_EIK_SqrDistance_RaySegment(void* ray, void* segment)
{
	return Intersections_Geometry<EIK>::SqrDistance_RaySegment(ray, segment);
}

double Intersections_Geometry_EIK_SqrDistance_RayTriangle(void* ray, void* triangle)
{
	return Intersections_Geometry<EIK>::SqrDistance_RayTriangle(ray, triangle);
}

/*****************************************************
*                                                    *
*            Segment2 SqrDistance Functions          *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_SegmentPoint(void* segment, void* point)
{
	return Intersections_Geometry<EIK>::SqrDistance_SegmentPoint(segment, point);
}

double Intersections_Geometry_EIK_SqrDistance_SegmentLine(void* segment, void* line)
{
	return Intersections_Geometry<EIK>::SqrDistance_SegmentLine(segment, line);
}

double Intersections_Geometry_EIK_SqrDistance_SegmentRay(void* segment, void* ray)
{
	return Intersections_Geometry<EIK>::SqrDistance_SegmentRay(segment, ray);
}

double Intersections_Geometry_EIK_SqrDistance_SegmentSegment(void* segment, void* segment2)
{
	return Intersections_Geometry<EIK>::SqrDistance_SegmentSegment(segment, segment2);
}

double Intersections_Geometry_EIK_SqrDistance_SegmentTriangle(void* segment, void* triangle)
{
	return Intersections_Geometry<EIK>::SqrDistance_SegmentTriangle(segment, triangle);
}

/*****************************************************
*                                                    *
*            Triangle2 SqrDistance Functions         *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_TrianglePoint(void* triangle, void* point)
{
	return Intersections_Geometry<EIK>::SqrDistance_TrianglePoint(triangle, point);
}

double Intersections_Geometry_EIK_SqrDistance_TriangleLine(void* triangle, void* line)
{
	return Intersections_Geometry<EIK>::SqrDistance_TriangleLine(triangle, line);
}

double Intersections_Geometry_EIK_SqrDistance_TriangleRay(void* triangle, void* ray)
{
	return Intersections_Geometry<EIK>::SqrDistance_TriangleRay(triangle, ray);
}

double Intersections_Geometry_EIK_SqrDistance_TriangleSegment(void* triangle, void* segment)
{
	return Intersections_Geometry<EIK>::SqrDistance_TriangleSegment(triangle, segment);
}

double Intersections_Geometry_EIK_SqrDistance_TriangleTriangle(void* triangle, void* triangle2)
{
	return Intersections_Geometry<EIK>::SqrDistance_TriangleTriangle(triangle, triangle2);
}


