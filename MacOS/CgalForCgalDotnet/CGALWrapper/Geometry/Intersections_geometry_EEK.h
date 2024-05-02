#pragma once
#include "../CGALWrapper.h"
#include "Geometry2.h"
#include "Intersections_geometry.h"

#include <CGAL/Intersections.h>
#include <CGAL/enum.h>

extern "C"
{
	/*****************************************************
	*                                                    *
	*            void* DoIntersect Functions           *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_PointLine(void* point, void* line);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_PointRay(void* point, void* ray);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_PointSegment(void* point, void* segment);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_PointTriangle(void* point, void* triangle);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_PointBox(void* point, void* box);

	/*****************************************************
	*                                                    *
	*            void* DoIntersect Functions            *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_LinePoint(void* line, void* point);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_LineLine(void* line, void* line2);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_LineRay(void* line, void* ray);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_LineSegment(void* line, void* segment);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_LineTriangle(void* line, void* triangle);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_LineBox(void* line, void* box);

	/*****************************************************
	*                                                    *
	*            void* DoIntersect Functions			 *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_RayPoint(void* ray, void* point);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_RayLine(void* ray, void* line);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_RayRay(void* ray, void* ray2);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_RaySegment(void* ray, void* segment);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_RayTriangle(void* ray, void* triangle);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_RayBox(void* ray, void* box);

	/*****************************************************
	*                                                    *
	*            void* DoIntersect Functions         *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_SegmentPoint(void* segment, void* point);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_SegmentLine(void* segment, void* line);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_SegmentRay(void* segment, void* ray);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_SegmentSegment(void* segment, void* segment2);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_SegmentTriangle(void* segment, void* triangle);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_SegmentBox(void* segment, void* box);

	/*****************************************************
	*                                                    *
	*            void* DoIntersect Functions        *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_TrianglePoint(void* triangle, void* point);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_TriangleLine(void* triangle, void* line);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_TriangleRay(void* triangle, void* ray);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_TriangleSegment(void* triangle, void* segment);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_TriangleTriangle(void* triangle, void* triangle2);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_TriangleBox(void* triangle, void* box);

	/*****************************************************
	*                                                    *
	*            void* DoIntersect Functions		     *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_BoxPoint(void* box, void* point);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_BoxLine(void* box, void* line);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_BoxRay(void* box, void* ray);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_BoxSegment(void* box, void* segment);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_BoxTriangle(void* box, void* triangle);

	CGALWRAPPER_API BOOL Intersections_Geometry_EEK_DoIntersect_BoxBox(void* box, void* box2);

	/*****************************************************
	*                                                    *
	*            void* Intersection Functions          *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointLine(void* point, void* line);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointRay(void* point, void* ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointSegment(void* point, void* segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointTriangle(void* point, void* triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointBox(void* point, void* box);

	/*****************************************************
	*                                                    *
	*            void* Intersection Functions           *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_LinePoint(void* line, void* point);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineLine(void* line, void* line2);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineRay(void* line, void* ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineSegment(void* line, void* segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineTriangle(void* line, void* triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineBox(void* line, void* box);

	/*****************************************************
	*                                                    *
	*            void* Intersection Functions            *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayPoint(void* ray, void* point);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayLine(void* ray, void* line);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayRay(void* ray, void* ray2);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_RaySegment(void* ray, void* segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayTriangle(void* ray, void* triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayBox(void* ray, void* box);

	/*****************************************************
	*                                                    *
	*            void* Intersection Functions        *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentPoint(void* segment, void* point);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentLine(void* segment, void* line);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentRay(void* segment, void* ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentSegment(void* segment, void* segment2);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentTriangle(void* segment, void* triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentBox(void* segment, void* box);

	/*****************************************************
	*                                                    *
	*            void* Intersection Functions       *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_TrianglePoint(void* triangle, void* point);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleLine(void* triangle, void* line);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleRay(void* triangle, void* ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleSegment(void* triangle, void* segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleTriangle(void* triangle, void* triangle2);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleBox(void* triangle, void* box);

	/*****************************************************
	*                                                    *
	*            void* Intersection Functions            *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxPoint(void* box, void* point);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxLine(void* box, void* line);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxRay(void* box, void* ray);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxSegment(void* box, void* segment);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxTriangle(void* box, void* triangle);

	CGALWRAPPER_API IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxBox(void* box, void* box2);

	/*****************************************************
	*                                                    *
	*            void* SqrDistance Functions           *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_PointPoint(void* point, void* point2);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_PointLine(void* point, void* line);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_PointRay(void* point, void* ray);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_PointSegment(void* point, void* segment);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_PointTriangle(void* point, void* triangle);

	/*****************************************************
	*                                                    *
	*            void* SqrDistance Functions            *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_LinePoint(void* line, void* point);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_LineLine(void* line, void* line2);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_LineRay(void* line, void* ray);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_LineSegment(void* line, void* segment);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_LineTriangle(void* line, void* triangle);

	/*****************************************************
	*                                                    *
	*            void* SqrDistance Functions             *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_RayPoint(void* ray, void* point);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_RayLine(void* ray, void* line);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_RayRay(void* ray, void* ray2);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_RaySegment(void* ray, void* segment);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_RayTriangle(void* ray, void* triangle);

	/*****************************************************
	*                                                    *
	*            void* SqrDistance Functions         *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_SegmentPoint(void* segment, void* point);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_SegmentLine(void* segment, void* line);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_SegmentRay(void* segment, void* ray);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_SegmentSegment(void* segment, void* segment2);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_SegmentTriangle(void* segment, void* triangle);

	/*****************************************************
	*                                                    *
	*            void* SqrDistance Functions        *
	*                                                    *
	******************************************************/

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_TrianglePoint(void* triangle, void* point);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_TriangleLine(void* triangle, void* line);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_TriangleRay(void* triangle, void* ray);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_TriangleSegment(void* triangle, void* segment);

	CGALWRAPPER_API double Intersections_Geometry_EEK_SqrDistance_TriangleTriangle(void* triangle, void* triangle2);

};

