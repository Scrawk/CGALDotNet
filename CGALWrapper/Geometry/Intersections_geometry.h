#pragma once

#include "../CGALWrapper.h"
#include "Geometry2.h"
#include "IntersectionResult.h"

#include <CGAL/intersections.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Direction_2.h>
#include <CGAL/Segment_2.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Triangle_2.h>
#include <CGAL/Line_2.h>
#include <CGAL/Iso_rectangle_2.h>
#include <CGAL/Ray_2.h>

template<class K>
class Intersections_Geometry
{

public:

    typedef CGAL::Point_2<K> Point2;
    typedef CGAL::Line_2<K> Line2;
    typedef CGAL::Ray_2<K> Ray2;
    typedef CGAL::Segment_2<K> Segment2;
    typedef CGAL::Triangle_2<K> Triangle2;
    typedef CGAL::Iso_rectangle_2<K> Box2;
    typedef std::vector<Point2> Polygon2;

    /*****************************************************
    *                                                    *
    *            Geometry Casting Functions              *
    *                                                    *
    ******************************************************/

    inline static Point2* CastToPoint2(void* ptr)
    {
        return static_cast<Point2*>(ptr);
    }

    inline static Line2* CastToLine2(void* ptr)
    {
        return static_cast<Line2*>(ptr);
    }

    inline static Ray2* CastToRay2(void* ptr)
    {
        return static_cast<Ray2*>(ptr);
    }

    inline static Segment2* CastToSegment2(void* ptr)
    {
        return static_cast<Segment2*>(ptr);
    }

    inline static Triangle2* CastToTriangle2(void* ptr)
    {
        return static_cast<Triangle2*>(ptr);
    }

    inline static Box2* CastToBox2(void* ptr)
    {
        return static_cast<Box2*>(ptr);
    }

    /*****************************************************
    *                                                    *
    *            Point2 DoIntersect Functions            *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect_PointLine(void* point, void* line)
    {
        auto p = CastToPoint2(point);
        auto l = CastToLine2(line);
        return CGAL::do_intersect(*p, *l);
    }

    static BOOL DoIntersect_PointRay(void* point, void* ray)
    {
        auto p = CastToPoint2(point);
        auto r = CastToRay2(ray);
        return CGAL::do_intersect(*p, *r);
    }

    static BOOL DoIntersect_PointSegment(void* point, void* seg)
    {
        auto p = CastToPoint2(point);
        auto s = CastToSegment2(seg);
        return CGAL::do_intersect(*p, *s);
    }

    static BOOL DoIntersect_PointTriangle(void* point, void* tri)
    {
        auto p = CastToPoint2(point);
        auto t = CastToTriangle2(tri);
        return CGAL::do_intersect(*p, *t);
    }

    static BOOL DoIntersect_PointBox(void* point, void* box)
    {
        auto p = CastToPoint2(point);
        auto b = CastToBox2(box);
        return CGAL::do_intersect(*p, *b);
    }

    /*****************************************************
    *                                                    *
    *            Line2 DoIntersect Functions             *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect_LinePoint(void* line, void* point)
    {
        auto p = CastToPoint2(point);
        auto l = CastToLine2(line);
        return CGAL::do_intersect(*p, *l);
    }

    static BOOL DoIntersect_LineLine(void* line, void* line2)
    {
        auto l = CastToLine2(line);
        auto l2 = CastToLine2(line2);
        return CGAL::do_intersect(*l, *l2);
    }

    static BOOL DoIntersect_LineRay(void* line, void* ray)
    {
        auto l = CastToLine2(line);
        auto r = CastToRay2(ray);
        return CGAL::do_intersect(*l, *r);
    }

    static BOOL DoIntersect_LineSegment(void* line, void* segment)
    {
        auto l = CastToLine2(line);
        auto s = CastToSegment2(segment);
        return CGAL::do_intersect(*l, *s);
    }

    static BOOL DoIntersect_LineTriangle(void* line, void* triangle)
    {
        auto l = CastToLine2(line);
        auto t = CastToTriangle2(triangle);
        return CGAL::do_intersect(*l, *t);
    }

    static BOOL DoIntersect_LineBox(void* line, void* box)
    {
        auto l = CastToLine2(line);
        auto b = CastToBox2(box);
        return CGAL::do_intersect(*l, *b);
    }

    /*****************************************************
    *                                                    *
    *            Ray2 DoIntersect Functions              *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect_RayPoint(void* ray, void* point)
    {
        auto r = CastToRay2(ray);
        auto p = CastToPoint2(point);
        return CGAL::do_intersect(*r, *p);
    }

    static BOOL DoIntersect_RayLine(void* ray, void* line)
    {
        auto r = CastToRay2(ray);
        auto l = CastToLine2(line);
        return CGAL::do_intersect(*r, *l);
    }

    static BOOL DoIntersect_RayRay(void* ray, void* ray2)
    {
        auto r = CastToRay2(ray);
        auto r2 = CastToRay2(ray2);
        return CGAL::do_intersect(*r, *r2);
    }

    static BOOL DoIntersect_RaySegment(void* ray, void* segment)
    {
        auto r = CastToRay2(ray);
        auto s = CastToSegment2(segment);
        return CGAL::do_intersect(*r, *s);
    }

    static BOOL DoIntersect_RayTriangle(void* ray, void* triangle)
    {
        auto r = CastToRay2(ray);
        auto t = CastToTriangle2(triangle);
        return CGAL::do_intersect(*r, *t);
    }

    static BOOL DoIntersect_RayBox(void* ray, void* box)
    {
        auto r = CastToRay2(ray);
        auto b = CastToBox2(box);
        return CGAL::do_intersect(*r, *b);
    }

    /*****************************************************
    *                                                    *
    *            Segment2  DoIntersect Functions         *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect_SegmentPoint(void* segment, void* point)
    {
        auto s = CastToSegment2(segment);
        auto p = CastToPoint2(point);
        return CGAL::do_intersect(*s, *p);
    }

    static BOOL DoIntersect_SegmentLine(void* segment, void* line)
    {
        auto s = CastToSegment2(segment);
        auto l = CastToLine2(line);
        return CGAL::do_intersect(*s, *l);
    }

    static BOOL DoIntersect_SegmentRay(void* segment, void* ray)
    {
        auto s = CastToSegment2(segment);
        auto r = CastToRay2(ray);
        return CGAL::do_intersect(*s, *r);
    }

    static BOOL DoIntersect_SegmentSegment(void* segment, void* segment2)
    {
        auto s = CastToSegment2(segment);
        auto s2 = CastToSegment2(segment2);
        return CGAL::do_intersect(*s, *s2);
    }

    static BOOL DoIntersect_SegmentTriangle(void* segment, void* triangle)
    {
        auto s = CastToSegment2(segment);
        auto t = CastToTriangle2(triangle);
        return CGAL::do_intersect(*s, *t);
    }

    static BOOL DoIntersect_SegmentBox(void* segment, void* box)
    {
        auto s = CastToSegment2(segment);
        auto b = CastToBox2(box);
        return CGAL::do_intersect(*s, *b);
    }

    /*****************************************************
    *                                                    *
    *            Triangle2  DoIntersect Functions        *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect_TrianglePoint(void* triangle, void* point)
    {
        auto t = CastToTriangle2(triangle);
        auto p = CastToPoint2(point);
        return CGAL::do_intersect(*t, *p);
    }

    static BOOL DoIntersect_TriangleLine(void* triangle, void* line)
    {
        auto t = CastToTriangle2(triangle);
        auto l = CastToLine2(line);
        return CGAL::do_intersect(*t, *l);
    }

    static BOOL DoIntersect_TriangleRay(void* triangle, void* ray)
    {
        auto t = CastToTriangle2(triangle);
        auto r = CastToRay2(ray);
        return CGAL::do_intersect(*t, *r);
    }

    static BOOL DoIntersect_TriangleSegment(void* triangle, void* segment)
    {
        auto t = CastToTriangle2(triangle);
        auto s = CastToSegment2(segment);
        return CGAL::do_intersect(*t, *s);
    }

    static BOOL DoIntersect_TriangleTriangle(void* triangle, void* triangle2)
    {
        auto t = CastToTriangle2(triangle);
        auto t2 = CastToTriangle2(triangle2);
        return CGAL::do_intersect(*t, *t2);
    }

    static BOOL DoIntersect_TriangleBox(void* triangle, void* box)
    {
        auto t = CastToTriangle2(triangle);
        auto b = CastToBox2(box);
        return CGAL::do_intersect(*t, *b);
    }

    /*****************************************************
    *                                                    *
    *            Box2  DoIntersect Functions             *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect_BoxPoint(void* box, void* point)
    {
        auto b = CastToBox2(box);
        auto p = CastToPoint2(point);
        return CGAL::do_intersect(*b, *p);
    }

    static BOOL DoIntersect_BoxLine(void* box, void* line)
    {
        auto b = CastToBox2(box);
        auto l = CastToLine2(line);
        return CGAL::do_intersect(*b, *l);
    }

    static BOOL DoIntersect_BoxRay(void* box, void* ray)
    {
        auto b = CastToBox2(box);
        auto r = CastToRay2(ray);
        return CGAL::do_intersect(*b, *r);
    }

    static BOOL DoIntersect_BoxSegment(void* box, void* segment)
    {
        auto b = CastToBox2(box);
        auto s = CastToSegment2(segment);
        return CGAL::do_intersect(*b, *s);
    }

    static BOOL DoIntersect_BoxTriangle(void* box, void* triangle)
    {
        auto b = CastToBox2(box);
        auto t = CastToTriangle2(triangle);
        return CGAL::do_intersect(*b, *t);
    }

    static BOOL DoIntersect_BoxBox(void* box, void* box2)
    {
        auto b = CastToBox2(box);
        auto b2 = CastToBox2(box2);
        return CGAL::do_intersect(*b, *b2);
    }

    /*****************************************************
    *                                                    *
    *            Point2 Intersection Functions           *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection_PointLine(void* point, void* line)
    {
        auto p = CastToPoint2(point);
        auto l = CastToLine2(line);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*p, *l));
    }

    static IntersectionResult2d Intersection_PointRay(void* point, void* ray)
    {
        auto p = CastToPoint2(point);
        auto r = CastToRay2(ray);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*p, *r));
    }

    static IntersectionResult2d Intersection_PointSegment(void* point, void* segment)
    {
        auto p = CastToPoint2(point);
        auto s = CastToSegment2(segment);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*p, *s));
    }

    static IntersectionResult2d Intersection_PointTriangle(void* point, void* triangle)
    {
        auto p = CastToPoint2(point);
        auto t = CastToTriangle2(triangle);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*p, *t));
    }

    static IntersectionResult2d Intersection_PointBox(void* point, void* box)
    {
        auto p = CastToPoint2(point);
        auto b = CastToBox2(box);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*p, *b));
    }

    /*****************************************************
    *                                                    *
    *            Line2 Intersection Functions           *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection_LinePoint(void* line, void* point)
    {
        auto p = CastToPoint2(point);
        auto l = CastToLine2(line);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*p, *l));
    }

    static IntersectionResult2d Intersection_LineLine(void* line, void* line2)
    {
        auto l = CastToLine2(line);
        auto l2 = CastToLine2(line2);
        return IntersectionResult<K>::ToPointOrLine(CGAL::intersection(*l, *l2));
    }

    static IntersectionResult2d Intersection_LineRay(void* line, void* ray)
    {
        auto l = CastToLine2(line);
        auto r = CastToRay2(ray);
        return IntersectionResult<K>::ToPointOrRay(CGAL::intersection(*l, *r));
    }

    static IntersectionResult2d Intersection_LineSegment(void* line, void* segment)
    {
        auto l = CastToLine2(line);
        auto s = CastToSegment2(segment);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*l, *s));
    }

    static IntersectionResult2d Intersection_LineTriangle(void* line, void* triangle)
    {
        auto l = CastToLine2(line);
        auto t = CastToTriangle2(triangle);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*l, *t));
    }

    static IntersectionResult2d Intersection_LineBox(void* line, void* box)
    {
        auto l = CastToLine2(line);
        auto b = CastToBox2(box);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*l, *b));
    }

    /*****************************************************
    *                                                    *
    *            Ray2 Intersection Functions             *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection_RayPoint(void* ray, void* point)
    {
        auto r = CastToRay2(ray);
        auto p = CastToPoint2(point);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*r, *p));
    }

    static IntersectionResult2d Intersection_RayLine(void* ray, void* line)
    {
        auto r = CastToRay2(ray);
        auto l = CastToLine2(line);
        return IntersectionResult<K>::ToPointOrRay(CGAL::intersection(*r, *l));
    }

    static IntersectionResult2d Intersection_RayRay(void* ray, void* ray2)
    {
        auto r = CastToRay2(ray);
        auto r2 = CastToRay2(ray2);
        return IntersectionResult<K>::ToPointSegmentOrRay(CGAL::intersection(*r, *r2));
    }

    static IntersectionResult2d Intersection_RaySegment(void* ray, void* segment)
    {
        auto r = CastToRay2(ray);
        auto s = CastToSegment2(segment);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*r, *s));
    }

    static IntersectionResult2d Intersection_RayTriangle(void* ray, void* triangle)
    {
        auto r = CastToRay2(ray);
        auto t = CastToTriangle2(triangle);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*r, *t));
    }

    static IntersectionResult2d Intersection_RayBox(void* ray, void* box)
    {
        auto r = CastToRay2(ray);
        auto b = CastToBox2(box);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*r, *b));
    }

    /*****************************************************
    *                                                    *
    *            Segment2 Intersection Functions         *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection_SegmentPoint(void* segment, void* point)
    {
        auto s = CastToSegment2(segment);
        auto p = CastToPoint2(point);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*s, *p));
    }

    static IntersectionResult2d Intersection_SegmentLine(void* segment, void* line)
    {
        auto s = CastToSegment2(segment);
        auto l = CastToLine2(line);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*s, *l));
    }

    static IntersectionResult2d Intersection_SegmentRay(void* segment, void* ray)
    {
        auto s = CastToSegment2(segment);
        auto r = CastToRay2(ray);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*s, *r));
    }

    static IntersectionResult2d Intersection_SegmentSegment(void* segment, void* segment2)
    {
        auto s = CastToSegment2(segment);
        auto s2 = CastToSegment2(segment2);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*s, *s2));
    }

    static IntersectionResult2d Intersection_SegmentTriangle(void* segment, void* triangle)
    {
        auto s = CastToSegment2(segment);
        auto t = CastToTriangle2(triangle);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*s, *t));
    }

    static IntersectionResult2d Intersection_SegmentBox(void* segment, void* box)
    {
        auto s = CastToSegment2(segment);
        auto b = CastToBox2(box);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*s, *b));
    }

    /*****************************************************
    *                                                    *
    *            Triangle2 Intersection Functions        *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection_TrianglePoint(void* triangle, void* point)
    {
        auto t = CastToTriangle2(triangle);
        auto p = CastToPoint2(point);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*t, *p));
    }

    static IntersectionResult2d Intersection_TriangleLine(void* triangle, void* line)
    {
        auto t = CastToTriangle2(triangle);
        auto l = CastToLine2(line);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*t, *l));
    }

    static IntersectionResult2d Intersection_TriangleRay(void* triangle, void* ray)
    {
        auto t = CastToTriangle2(triangle);
        auto r = CastToRay2(ray);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*t, *r));
    }

    static IntersectionResult2d Intersection_TriangleSegment(void* triangle, void* segment)
    {
        auto t = CastToTriangle2(triangle);
        auto s = CastToSegment2(segment);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*t, *s));
    }

    static IntersectionResult2d Intersection_TriangleTriangle(void* triangle, void* triangle2)
    {
        auto t = CastToTriangle2(triangle);
        auto t2 = CastToTriangle2(triangle2);
        return IntersectionResult<K>::ToPointSegmentTriangleOrPolygon(CGAL::intersection(*t, *t2));
    }

    static IntersectionResult2d Intersection_TriangleBox(void* triangle, void* box)
    {
        auto t = CastToTriangle2(triangle);
        auto b = CastToBox2(box);
        return IntersectionResult<K>::ToPointSegmentTriangleOrPolygon(CGAL::intersection(*t, *b));
    }

    /*****************************************************
    *                                                    *
    *            Box2 Intersection Functions             *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection_BoxPoint(void* box, void* point)
    {
        auto b = CastToBox2(box);
        auto p = CastToPoint2(point);
        return IntersectionResult<K>::ToPoint(CGAL::intersection(*b, *p));
    }

    static IntersectionResult2d Intersection_BoxLine(void* box, void* line)
    {
        auto b = CastToBox2(box);;
        auto l = CastToLine2(line);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*b, *l));
    }

    static IntersectionResult2d Intersection_BoxRay(void* box, void* ray)
    {
        auto b = CastToBox2(box);
        auto r = CastToRay2(ray);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*b, *r));
    }

    static IntersectionResult2d Intersection_BoxSegment(void* box, void* segment)
    {
        auto b = CastToBox2(box);
        auto s = CastToSegment2(segment);
        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(*b, *s));
    }

    static IntersectionResult2d Intersection_BoxTriangle(void* box, void* triangle)
    {
        auto b = CastToBox2(box);
        auto t = CastToTriangle2(triangle);
        return IntersectionResult<K>::ToPointSegmentTriangleOrPolygon(CGAL::intersection(*b, *t));
    }

    static IntersectionResult2d Intersection_BoxBox(void* box, void* box2)
    {
        auto b = CastToBox2(box);
        auto b2 = CastToBox2(box2);
        return IntersectionResult<K>::ToBox(CGAL::intersection(*b, *b2));
    }

    /*****************************************************
    *                                                    *
    *            Point2 SqrDistance Functions            *
    *                                                    *
    ******************************************************/

    static double SqrDistance_PointPoint(void* point, void* point2)
    {
        auto p = CastToPoint2(point);
        auto p2 = CastToPoint2(point2);
        return CGAL::to_double(CGAL::squared_distance(*p, *p2));
    }

    static double SqrDistance_PointLine(void* point, void* line)
    {
        auto p = CastToPoint2(point);
        auto l = CastToLine2(line);
        return CGAL::to_double(CGAL::squared_distance(*p, *l));
    }

    static double SqrDistance_PointRay(void* point, void* ray)
    {
        auto p = CastToPoint2(point);
        auto r = CastToRay2(ray);
        return CGAL::to_double(CGAL::squared_distance(*p, *r));
    }

    static double SqrDistance_PointSegment(void* point, void* segment)
    {
        auto p = CastToPoint2(point);
        auto s = CastToSegment2(segment);
        return CGAL::to_double(CGAL::squared_distance(*p, *s));
    }

    static double SqrDistance_PointTriangle(void* point, void* triangle)
    {
        auto p = CastToPoint2(point);
        auto t = CastToTriangle2(triangle);
        return CGAL::to_double(CGAL::squared_distance(*p, *t));
    }


    /*****************************************************
    *                                                    *
    *            Line2 SqrDistance Functions             *
    *                                                    *
    ******************************************************/

    static double SqrDistance_LinePoint(void* line, void* point)
    {
        auto p = CastToPoint2(point);
        auto l = CastToLine2(line);
        return CGAL::to_double(CGAL::squared_distance(*p, *l));
    }

    static double SqrDistance_LineLine(void* line, void* line2)
    {
        auto l = CastToLine2(line);
        auto l2 = CastToLine2(line2);
        return CGAL::to_double(CGAL::squared_distance(*l, *l2));
    }

    static double SqrDistance_LineRay(void* line, void* ray)
    {
        auto l = CastToLine2(line);
        auto r = CastToRay2(ray);
        return CGAL::to_double(CGAL::squared_distance(*l, *r));
    }

    static double SqrDistance_LineSegment(void* line, void* segment)
    {
        auto l = CastToLine2(line);
        auto s = CastToSegment2(segment);
        return CGAL::to_double(CGAL::squared_distance(*l, *s));
    }

    static double SqrDistance_LineTriangle(void* line, void* triangle)
    {
        auto l = CastToLine2(line);
        auto t = CastToTriangle2(triangle);
        return CGAL::to_double(CGAL::squared_distance(*l, *t));
    }

    /*****************************************************
    *                                                    *
    *            Ray2 SqrDistance Functions              *
    *                                                    *
    ******************************************************/

    static double SqrDistance_RayPoint(void* ray, void* point)
    {
        auto r = CastToRay2(ray);
        auto p = CastToPoint2(point);
        return CGAL::to_double(CGAL::squared_distance(*r, *p));
    }

    static double SqrDistance_RayLine(void* ray, void* line)
    {
        auto r = CastToRay2(ray);
        auto l = CastToLine2(line);
        return CGAL::to_double(CGAL::squared_distance(*r, *l));
    }

    static double SqrDistance_RayRay(void* ray, void* ray2)
    {
        auto r = CastToRay2(ray);
        auto r2 = CastToRay2(ray2);
        return CGAL::to_double(CGAL::squared_distance(*r, *r2));
    }

    static double SqrDistance_RaySegment(void* ray, void* segment)
    {
        auto r = CastToRay2(ray);
        auto s = CastToSegment2(segment);
        return CGAL::to_double(CGAL::squared_distance(*r, *s));
    }

    static double SqrDistance_RayTriangle(void* ray, void* triangle)
    {
        auto r = CastToRay2(ray);
        auto t = CastToTriangle2(triangle);
        return CGAL::to_double(CGAL::squared_distance(*r, *t));
    }

    /*****************************************************
    *                                                    *
    *            Segment2 SqrDistance Functions          *
    *                                                    *
    ******************************************************/

    static double SqrDistance_SegmentPoint(void* segment, void* point)
    {
        auto s = CastToSegment2(segment);
        auto p = CastToPoint2(point);
        return CGAL::to_double(CGAL::squared_distance(*s, *p));
    }

    static double SqrDistance_SegmentLine(void* segment, void* line)
    {
        auto s = CastToSegment2(segment);
        auto l = CastToLine2(line);
        return CGAL::to_double(CGAL::squared_distance(*s, *l));
    }

    static double SqrDistance_SegmentRay(void* segment, void* ray)
    {
        auto s = CastToSegment2(segment);
        auto r = CastToRay2(ray);
        return CGAL::to_double(CGAL::squared_distance(*s, *r));
    }

    static double SqrDistance_SegmentSegment(void* segment, void* segment2)
    {
        auto s = CastToSegment2(segment);
        auto s2 = CastToSegment2(segment2);
        return CGAL::to_double(CGAL::squared_distance(*s, *s2));
    }

    static double SqrDistance_SegmentTriangle(void* segment, void* triangle)
    {
        auto s = CastToSegment2(segment);
        auto t = CastToTriangle2(triangle);
        return CGAL::to_double(CGAL::squared_distance(*s, *t));
    }

    /*****************************************************
    *                                                    *
    *            Triangle2 SqrDistance Functions         *
    *                                                    *
    ******************************************************/

    static double SqrDistance_TrianglePoint(void* triangle, void* point)
    {
        auto t = CastToTriangle2(triangle);
        auto p = CastToPoint2(point);
        return CGAL::to_double(CGAL::squared_distance(*t, *p));
    }

    static double SqrDistance_TriangleLine(void* triangle, void* line)
    {
        auto t = CastToTriangle2(triangle);
        auto l = CastToLine2(line);
        return CGAL::to_double(CGAL::squared_distance(*t, *l));
    }

    static double SqrDistance_TriangleRay(void* triangle, void* ray)
    {
        auto t = CastToTriangle2(triangle);
        auto r = CastToRay2(ray);
        return CGAL::to_double(CGAL::squared_distance(*t, *r));
    }

    static double SqrDistance_TriangleSegment(void* triangle, void* segment)
    {
        auto t = CastToTriangle2(triangle);
        auto s = CastToSegment2(segment);
        return CGAL::to_double(CGAL::squared_distance(*t, *s));
    }

    static double SqrDistance_TriangleTriangle(void* triangle, void* triangle2)
    {
        auto t = CastToTriangle2(triangle);
        auto t2 = CastToTriangle2(triangle2);
        return CGAL::to_double(CGAL::squared_distance(*t, *t2));
    }
    

};
