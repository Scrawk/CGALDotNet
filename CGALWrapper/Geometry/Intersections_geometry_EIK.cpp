
#include "Intersections_geometry_EIK.h"
#include "Intersections_geometry.h"

/*****************************************************
*                                                    *
*            void* DoIntersect Functions           *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_PointLine(void* point, void* line)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointRay(void* point, void* ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointSegment(void* point, void* segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointTriangle(void* point, void* triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_PointBox(void* point, void* box)
{
	return Intersections_Shapes<EIK>::DoIntersect(point, box);
}

/*****************************************************
*                                                    *
*            void* DoIntersect Functions            *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_LinePoint(void* line, void* point)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineLine(void* line, void* line2)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, line2);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineRay(void* line, void* ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineSegment(void* line, void* segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineTriangle(void* line, void* triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_LineBox(void* line, void* box)
{
	return Intersections_Shapes<EIK>::DoIntersect(line, box);
}

/*****************************************************
*                                                    *
*            void* DoIntersect Functions             *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_RayPoint(void* ray, void* point)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RayLine(void* ray, void* line)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RayRay(void* ray, void* ray2)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, ray2);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RaySegment(void* ray, void* segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RayTriangle(void* ray, void* triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_RayBox(void* ray, void* box)
{
	return Intersections_Shapes<EIK>::DoIntersect(ray, box);
}

/*****************************************************
*                                                    *
*            void* DoIntersect Functions         *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentPoint(void* segment, void* point)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentLine(void* segment, void* line)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentRay(void* segment, void* ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentSegment(void* segment, void* segment2)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, segment2);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentTriangle(void* segment, void* triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_SegmentBox(void* segment, void* box)
{
	return Intersections_Shapes<EIK>::DoIntersect(segment, box);
}

/*****************************************************
*                                                    *
*            void* DoIntersect Functions        *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_TrianglePoint(void* triangle, void* point)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleLine(void* triangle, void* line)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleRay(void* triangle, void* ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleSegment(void* triangle, void* segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleTriangle(void* triangle, void* triangle2)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, triangle2);
}

BOOL Intersections_Geometry_EIK_DoIntersect_TriangleBox(void* triangle, void* box)
{
	return Intersections_Shapes<EIK>::DoIntersect(triangle, box);
}

/*****************************************************
*                                                    *
*            void* DoIntersect Functions             *
*                                                    *
******************************************************/

BOOL Intersections_Geometry_EIK_DoIntersect_BoxPoint(void* box, void* point)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, point);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxLine(void* box, void* line)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, line);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxRay(void* box, void* ray)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, ray);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxSegment(void* box, void* segment)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, segment);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxTriangle(void* box, void* triangle)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, triangle);
}

BOOL Intersections_Geometry_EIK_DoIntersect_BoxBox(void* box, void* box2)
{
	return Intersections_Shapes<EIK>::DoIntersect(box, box2);
}

/*****************************************************
*                                                    *
*            void* Intersection Functions          *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointLine(void* point, void* line)
{
	return Intersections_Shapes<EIK>::Intersection(point, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointRay(void* point, void* ray)
{
	return Intersections_Shapes<EIK>::Intersection(point, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointSegment(void* point, void* segment)
{
	return Intersections_Shapes<EIK>::Intersection(point, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointTriangle(void* point, void* triangle)
{
	return Intersections_Shapes<EIK>::Intersection(point, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_PointBox(void* point, void* box)
{
	return Intersections_Shapes<EIK>::Intersection(point, box);
}

/*****************************************************
*                                                    *
*            void* Intersection Functions           *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LinePoint(void* line, void* point)
{
	return Intersections_Shapes<EIK>::Intersection(point, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineLine(void* line, void* line2)
{
	return Intersections_Shapes<EIK>::Intersection(line, line2);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineRay(void* line, void* ray)
{
	return Intersections_Shapes<EIK>::Intersection(line, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineSegment(void* line, void* segment)
{
	return Intersections_Shapes<EIK>::Intersection(line, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineTriangle(void* line, void* triangle)
{
	return Intersections_Shapes<EIK>::Intersection(line, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_LineBox(void* line, void* box)
{
	return Intersections_Shapes<EIK>::Intersection(line, box);
}

/*****************************************************
*                                                    *
*            void* Intersection Functions            *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayPoint(void* ray, void* point)
{
	return Intersections_Shapes<EIK>::Intersection(ray, point);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayLine(void* ray, void* line)
{
	return Intersections_Shapes<EIK>::Intersection(ray, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayRay(void* ray, void* ray2)
{
	return Intersections_Shapes<EIK>::Intersection(ray, ray2);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RaySegment(void* ray, void* segment)
{
	return Intersections_Shapes<EIK>::Intersection(ray, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayTriangle(void* ray, void* triangle)
{
	return Intersections_Shapes<EIK>::Intersection(ray, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_RayBox(void* ray, void* box)
{
	return Intersections_Shapes<EIK>::Intersection(ray, box);
}

/*****************************************************
*                                                    *
*            void* Intersection Functions        *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentPoint(void* segment, void* point)
{
	return Intersections_Shapes<EIK>::Intersection(segment, point);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentLine(void* segment, void* line)
{
	return Intersections_Shapes<EIK>::Intersection(segment, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentRay(void* segment, void* ray)
{
	return Intersections_Shapes<EIK>::Intersection(segment, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentSegment(void* segment, void* segment2)
{
	return Intersections_Shapes<EIK>::Intersection(segment, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentTriangle(void* segment, void* triangle)
{
	return Intersections_Shapes<EIK>::Intersection(segment, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_SegmentBox(void* segment, void* box)
{
	return Intersections_Shapes<EIK>::Intersection(segment, box);
}

/*****************************************************
*                                                    *
*            void* Intersection Functions       *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TrianglePoint(void* triangle, void* point)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, point);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleLine(void* triangle, void* line)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleRay(void* triangle, void* ray)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleSegment(void* triangle, void* segment)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleTriangle(void* triangle, void* triangle2)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, triangle2);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_TriangleBox(void* triangle, void* box)
{
	return Intersections_Shapes<EIK>::Intersection(triangle, box);
}

/*****************************************************
*                                                    *
*            void* Intersection Functions            *
*                                                    *
******************************************************/

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxPoint(void* box, void* point)
{
	return Intersections_Shapes<EIK>::Intersection(box, point);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxLine(void* box, void* line)
{
	return Intersections_Shapes<EIK>::Intersection(box, line);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxRay(void* box, void* ray)
{
	return Intersections_Shapes<EIK>::Intersection(box, ray);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxSegment(void* box, void* segment)
{
	return Intersections_Shapes<EIK>::Intersection(box, segment);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxTriangle(void* box, void* triangle)
{
	return Intersections_Shapes<EIK>::Intersection(box, triangle);
}

IntersectionResult2d Intersections_Geometry_EIK_Intersection_BoxBox(void* box, void* box2)
{
	return Intersections_Shapes<EIK>::Intersection(box, box2);
}

/*****************************************************
*                                                    *
*            void* SqrDistance Functions           *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_PointPoint(void* point, void* point2)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, point2);
}

double Intersections_Geometry_EIK_SqrDistance_PointLine(void* point, void* line)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, line);
}

double Intersections_Geometry_EIK_SqrDistance_PointRay(void* point, void* ray)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, ray);
}

double Intersections_Geometry_EIK_SqrDistance_PointSegment(void* point, void* segment)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, segment);
}

double Intersections_Geometry_EIK_SqrDistance_PointTriangle(void* point, void* triangle)
{
	return Intersections_Shapes<EIK>::SqrDistance(point, triangle);
}

/*****************************************************
*                                                    *
*            void* SqrDistance Functions            *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_LinePoint(void* line, void* point)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, point);
}

double Intersections_Geometry_EIK_SqrDistance_LineLine(void* line, void* line2)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, line2);
}

double Intersections_Geometry_EIK_SqrDistance_LineRay(void* line, void* ray)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, ray);
}

double Intersections_Geometry_EIK_SqrDistance_LineSegment(void* line, void* segment)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, segment);
}

double Intersections_Geometry_EIK_SqrDistance_LineTriangle(void* line, void* triangle)
{
	return Intersections_Shapes<EIK>::SqrDistance(line, triangle);
}

/*****************************************************
*                                                    *
*            void* SqrDistance Functions             *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_RayPoint(void* ray, void* point)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, point);
}

double Intersections_Geometry_EIK_SqrDistance_RayLine(void* ray, void* line)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, line);
}

double Intersections_Geometry_EIK_SqrDistance_RayRay(void* ray, void* ray2)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, ray2);
}

double Intersections_Geometry_EIK_SqrDistance_RaySegment(void* ray, void* segment)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, segment);
}

double Intersections_Geometry_EIK_SqrDistance_RayTriangle(void* ray, void* triangle)
{
	return Intersections_Shapes<EIK>::SqrDistance(ray, triangle);
}

/*****************************************************
*                                                    *
*            void* SqrDistance Functions         *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_SegmentPoint(void* segment, void* point)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, point);
}

double Intersections_Geometry_EIK_SqrDistance_SegmentLine(void* segment, void* line)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, line);
}

double Intersections_Geometry_EIK_SqrDistance_SegmentRay(void* segment, void* ray)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, ray);
}

double Intersections_Geometry_EIK_SqrDistance_SegmentSegment(void* segment, void* segment2)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, segment2);
}

double Intersections_Geometry_EIK_SqrDistance_SegmentTriangle(void* segment, void* triangle)
{
	return Intersections_Shapes<EIK>::SqrDistance(segment, triangle);
}

/*****************************************************
*                                                    *
*            void* SqrDistance Functions        *
*                                                    *
******************************************************/

double Intersections_Geometry_EIK_SqrDistance_TrianglePoint(void* triangle, void* point)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, point);
}

double Intersections_Geometry_EIK_SqrDistance_TriangleLine(void* triangle, void* line)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, line);
}

double Intersections_Geometry_EIK_SqrDistance_TriangleRay(void* triangle, void* ray)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, ray);
}

double Intersections_Geometry_EIK_SqrDistance_TriangleSegment(void* triangle, void* segment)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, segment);
}

double Intersections_Geometry_EIK_SqrDistance_TriangleTriangle(void* triangle, void* triangle2)
{
	return Intersections_Shapes<EIK>::SqrDistance(triangle, triangle2);
}


