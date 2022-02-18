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
class Intersections_Shapes
{

    typedef CGAL::Point_2<K> Point2;
    typedef CGAL::Line_2<K> Line2;
    typedef CGAL::Ray_2<K> Ray2;
    typedef CGAL::Segment_2<K> Segment2;
    typedef CGAL::Triangle_2<K> Triangle2;
    typedef CGAL::Iso_rectangle_2<K> Box2;
    typedef std::vector<Point2> Polygon2;

public:

    /*****************************************************
    *                                                    *
    *            Point2d DoIntersect Functions           *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect(Point2d point, Line2d line)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::do_intersect(p, l);
    }

    static BOOL DoIntersect(Point2d point, Ray2d ray)
    {
        auto p = point.ToCGAL<K>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::do_intersect(p, r);
    }

    static BOOL DoIntersect(Point2d point, Segment2d segment)
    {
        auto p = point.ToCGAL<K>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::do_intersect(p, s);
    }

    static BOOL DoIntersect(Point2d point, Triangle2d triangle)
    {
        auto p = point.ToCGAL<K>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::do_intersect(p, t);
    }

    static BOOL DoIntersect(Point2d point, Box2d box)
    {
        auto p = point.ToCGAL<K>();
        auto b = box.ToCGAL<K, Box2>();
        return CGAL::do_intersect(p, b);
    }

    /*****************************************************
    *                                                    *
    *            Line2d DoIntersect Functions            *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect(Line2d line, Point2d point)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::do_intersect(p, l);
    }

    static BOOL DoIntersect(Line2d line, Line2d line2)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto l2 = line2.ToCGAL<K, Line2>();
        return CGAL::do_intersect(l, l2);
    }

    static BOOL DoIntersect(Line2d line, Ray2d ray)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::do_intersect(l, r);
    }

    static BOOL DoIntersect(Line2d line, Segment2d segment)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::do_intersect(l, s);
    }

    static BOOL DoIntersect(Line2d line, Triangle2d triangle)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::do_intersect(l, t);
    }

    static BOOL DoIntersect(Line2d line, Box2d box)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto b = box.ToCGAL<K, Box2>();
        return CGAL::do_intersect(l, b);
    }

    /*****************************************************
    *                                                    *
    *            Ray2d DoIntersect Functions             *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect(Ray2d ray, Point2d point)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto p = point.ToCGAL<K>();
        return CGAL::do_intersect(r, p);
    }

    static BOOL DoIntersect(Ray2d ray, Line2d line)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::do_intersect(r, l);
    }

    static BOOL DoIntersect(Ray2d ray, Ray2d ray2)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto r2 = ray2.ToCGAL<K, Ray2>();
        return CGAL::do_intersect(r, r2);
    }

    static BOOL DoIntersect(Ray2d ray, Segment2d segment)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::do_intersect(r, s);
    }

    static BOOL DoIntersect(Ray2d ray, Triangle2d triangle)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::do_intersect(r, t);
    }

    static BOOL DoIntersect(Ray2d ray, Box2d box)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto b = box.ToCGAL<K, Box2>();
        return CGAL::do_intersect(r, b);
    }

    /*****************************************************
    *                                                    *
    *            Segment2d DoIntersect Functions         *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect(Segment2d segment, Point2d point)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto p = point.ToCGAL<K>();
        return CGAL::do_intersect(s, p);
    }

    static BOOL DoIntersect(Segment2d segment, Line2d line)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::do_intersect(s, l);
    }

    static BOOL DoIntersect(Segment2d segment, Ray2d ray)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::do_intersect(s, r);
    }

    static BOOL DoIntersect(Segment2d segment, Segment2d segment2)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto s2 = segment2.ToCGAL<K, Segment2>();
        return CGAL::do_intersect(s, s2);
    }

    static BOOL DoIntersect(Segment2d segment, Triangle2d triangle)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::do_intersect(s, t);
    }

    static BOOL DoIntersect(Segment2d segment, Box2d box)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto b = box.ToCGAL<K, Box2>();
        return CGAL::do_intersect(s, b);
    }

    /*****************************************************
    *                                                    *
    *            Triangle2d DoIntersect Functions        *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect(Triangle2d triangle, Point2d point)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto p = point.ToCGAL<K>();
        return CGAL::do_intersect(t, p);
    }

    static BOOL DoIntersect(Triangle2d triangle, Line2d line)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::do_intersect(t, l);
    }

    static BOOL DoIntersect(Triangle2d triangle, Ray2d ray)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::do_intersect(t, r);
    }

    static BOOL DoIntersect(Triangle2d triangle, Segment2d segment)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::do_intersect(t, s);
    }

    static BOOL DoIntersect(Triangle2d triangle, Triangle2d triangle2)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto t2 = triangle2.ToCGAL<K, Triangle2>();
        return CGAL::do_intersect(t, t2);
    }

    static BOOL DoIntersect(Triangle2d triangle, Box2d box)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto b = box.ToCGAL<K, Box2>();
        return CGAL::do_intersect(t, b);
    }

    /*****************************************************
    *                                                    *
    *            Box2d DoIntersect Functions             *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect(Box2d box, Point2d point)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto p = point.ToCGAL<K>();
        return CGAL::do_intersect(b, p);
    }

    static BOOL DoIntersect(Box2d box, Line2d line)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::do_intersect(b, l);
    }

    static BOOL DoIntersect(Box2d box, Ray2d ray)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::do_intersect(b, r);
    }

    static BOOL DoIntersect(Box2d box, Segment2d segment)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::do_intersect(b, s);
    }

    static BOOL DoIntersect(Box2d box, Triangle2d triangle)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::do_intersect(b, t);
    }

    static BOOL DoIntersect(Box2d box, Box2d box2)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto b2 = box2.ToCGAL<K, Box2>();
        return CGAL::do_intersect(b, b2);
    }

    /*****************************************************
    *                                                    *
    *            Point2d Intersection Functions          *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection(Point2d point, Line2d line)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(p, l));
    }

    static IntersectionResult2d Intersection(Point2d point, Ray2d ray)
    {
        auto p = point.ToCGAL<K>();
        auto r = ray.ToCGAL<K, Ray2>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(p, r));
    }

    static IntersectionResult2d Intersection(Point2d point, Segment2d segment)
    {
        auto p = point.ToCGAL<K>();
        auto s = segment.ToCGAL<K, Segment2>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(p, s));
    }

    static IntersectionResult2d Intersection(Point2d point, Triangle2d triangle)
    {
        auto p = point.ToCGAL<K>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(p, t));
    }

    static IntersectionResult2d Intersection(Point2d point, Box2d box)
    {
        auto p = point.ToCGAL<K>();
        auto b = box.ToCGAL<K, Box2>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(p, b));
    }

    /*****************************************************
    *                                                    *
    *            Line2d Intersection Functions           *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection(Line2d line, Point2d point)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(p, l));
    }

    static IntersectionResult2d Intersection(Line2d line, Line2d line2)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto l2 = line2.ToCGAL<K, Line2>();

        return IntersectionResult<K>::ToPointOrLine(CGAL::intersection(l, l2));
    }

    static IntersectionResult2d Intersection(Line2d line, Ray2d ray)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto r = ray.ToCGAL<K, Ray2>();

        return IntersectionResult<K>::ToPointOrRay(CGAL::intersection(l, r));
 
    }

    static IntersectionResult2d Intersection(Line2d line, Segment2d segment)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto s = segment.ToCGAL<K, Segment2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(l, s));
    }

    static IntersectionResult2d Intersection(Line2d line, Triangle2d triangle)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(l, t));
    }

    static IntersectionResult2d Intersection(Line2d line, Box2d box)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto b = box.ToCGAL<K, Box2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(l, b));
    }

    /*****************************************************
    *                                                    *
    *            Ray2d Intersection Functions            * 
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection(Ray2d ray, Point2d point)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto p = point.ToCGAL<K>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(r, p));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Line2d line)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto l = line.ToCGAL<K, Line2>();

        return IntersectionResult<K>::ToPointOrRay(CGAL::intersection(r, l));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Ray2d ray2)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto r2 = ray2.ToCGAL<K, Ray2>();

        return IntersectionResult<K>::ToPointSegmentOrRay(CGAL::intersection(r, r2));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Segment2d segment)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto s = segment.ToCGAL<K, Segment2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(r, s));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Triangle2d triangle)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(r, t));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Box2d box)
    {
        auto r = ray.ToCGAL<K, Ray2>();;
        auto b = box.ToCGAL<K, Box2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(r, b));
    }

    /*****************************************************
    *                                                    *
    *            Segment2d Intersection Functions        *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection(Segment2d segment, Point2d point)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto p = point.ToCGAL<K>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(s, p));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Line2d line)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto l = line.ToCGAL<K, Line2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(s, l));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Ray2d ray)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto r = ray.ToCGAL<K, Ray2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(s, r));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Segment2d segment2)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto s2 = segment2.ToCGAL<K, Segment2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(s, s2));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Triangle2d triangle)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(s, t));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Box2d box)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto b = box.ToCGAL<K, Box2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(s, b));
    }

    /*****************************************************
    *                                                    *
    *            Triangle2d Intersection Functions       *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection(Triangle2d triangle, Point2d point)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto p = point.ToCGAL<K>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(t, p));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Line2d line)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto l = line.ToCGAL<K, Line2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(t, l));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Ray2d ray)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto r = ray.ToCGAL<K, Ray2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(t, r));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Segment2d segment)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto s = segment.ToCGAL<K, Segment2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(t, s));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Triangle2d triangle2)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto t2 = triangle2.ToCGAL<K, Triangle2>();

        return IntersectionResult<K>::ToPointSegmentTriangleOrPolygon(CGAL::intersection(t, t2));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Box2d box)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto b = box.ToCGAL<K, Box2>();

        return IntersectionResult<K>::ToPointSegmentTriangleOrPolygon(CGAL::intersection(t, b));
    }

    /*****************************************************
    *                                                    *
    *            Box2d Intersection Functions            *
    *                                                    *
    ******************************************************/

    static IntersectionResult2d Intersection(Box2d box, Point2d point)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto p = point.ToCGAL<K>();

        return IntersectionResult<K>::ToPoint(CGAL::intersection(b, p));
    }

    static IntersectionResult2d Intersection(Box2d box, Line2d line)
    {
        auto b = box.ToCGAL<K, Box2>();;
        auto l = line.ToCGAL<K, Line2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(b, l));
    }

    static IntersectionResult2d Intersection(Box2d box, Ray2d ray)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto r = ray.ToCGAL<K, Ray2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(b, r));
    }

    static IntersectionResult2d Intersection(Box2d box, Segment2d segment)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto s = segment.ToCGAL<K, Segment2>();

        return IntersectionResult<K>::ToPointOrSegment(CGAL::intersection(b, s));
    }

    static IntersectionResult2d Intersection(Box2d box, Triangle2d triangle)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return IntersectionResult<K>::ToPointSegmentTriangleOrPolygon(CGAL::intersection(b, t));
    }

    static IntersectionResult2d Intersection(Box2d box, Box2d box2)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto b2 = box2.ToCGAL<K, Box2>();

        return IntersectionResult<K>::ToBox(CGAL::intersection(b, b2));
    }

    /*****************************************************
    *                                                    *
    *            Point2d SqrDistance Functions           *
    *                                                    *
    ******************************************************/

    static double SqrDistance(Point2d point, Point2d point2)
    {
        auto p = point.ToCGAL<K>();
        auto p2 = point2.ToCGAL<K>();
        return CGAL::to_double(CGAL::squared_distance(p, p2));
    }

    static double SqrDistance(Point2d point, Line2d line)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::to_double(CGAL::squared_distance(p, l));
    }

    static double SqrDistance(Point2d point, Ray2d ray)
    {
        auto p = point.ToCGAL<K>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::to_double(CGAL::squared_distance(p, r));
    }

    static double SqrDistance(Point2d point, Segment2d segment)
    {
        auto p = point.ToCGAL<K>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::to_double(CGAL::squared_distance(p, s));
    }

    static double SqrDistance(Point2d point, Triangle2d triangle)
    {
        auto p = point.ToCGAL<K>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::to_double(CGAL::squared_distance(p, t));
    }


    /*****************************************************
    *                                                    *
    *            Line2d SqrDistance Functions            *
    *                                                    *
    ******************************************************/

    static double SqrDistance(Line2d line, Point2d point)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::to_double(CGAL::squared_distance(p, l));
    }

    static double SqrDistance(Line2d line, Line2d line2)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto l2 = line2.ToCGAL<K, Line2>();
        return CGAL::to_double(CGAL::squared_distance(l, l2));
    }

    static double SqrDistance(Line2d line, Ray2d ray)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::to_double(CGAL::squared_distance(l, r));
    }

    static double SqrDistance(Line2d line, Segment2d segment)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::to_double(CGAL::squared_distance(l, s));
    }

    static double SqrDistance(Line2d line, Triangle2d triangle)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::to_double(CGAL::squared_distance(l, t));
    }

    /*****************************************************
    *                                                    *
    *            Ray2d SqrDistance Functions             *
    *                                                    *
    ******************************************************/

    static double SqrDistance(Ray2d ray, Point2d point)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto p = point.ToCGAL<K>();
        return CGAL::to_double(CGAL::squared_distance(r, p));
    }

    static double SqrDistance(Ray2d ray, Line2d line)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::to_double(CGAL::squared_distance(r, l));
    }

    static double SqrDistance(Ray2d ray, Ray2d ray2)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto r2 = ray2.ToCGAL<K, Ray2>();
        return CGAL::to_double(CGAL::squared_distance(r, r2));
    }

    static double SqrDistance(Ray2d ray, Segment2d segment)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::to_double(CGAL::squared_distance(r, s));
    }

    static double SqrDistance(Ray2d ray, Triangle2d triangle)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::to_double(CGAL::squared_distance(r, t));
    }

    /*****************************************************
    *                                                    *
    *            Segment2d SqrDistance Functions         *
    *                                                    *
    ******************************************************/

    static double SqrDistance(Segment2d segment, Point2d point)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto p = point.ToCGAL<K>();
        return CGAL::to_double(CGAL::squared_distance(s, p));
    }

    static double SqrDistance(Segment2d segment, Line2d line)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::to_double(CGAL::squared_distance(s, l));
    }

    static double SqrDistance(Segment2d segment, Ray2d ray)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::to_double(CGAL::squared_distance(s, r));
    }

    static double SqrDistance(Segment2d segment, Segment2d segment2)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto s2 = segment2.ToCGAL<K, Segment2>();
        return CGAL::to_double(CGAL::squared_distance(s, s2));
    }

    static double SqrDistance(Segment2d segment, Triangle2d triangle)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto t = triangle.ToCGAL<K, Triangle2>();
        return CGAL::to_double(CGAL::squared_distance(s, t));
    }

    /*****************************************************
    *                                                    *
    *            Triangle2d SqrDistance Functions        *
    *                                                    *
    ******************************************************/

    static double SqrDistance(Triangle2d triangle, Point2d point)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto p = point.ToCGAL<K>();
        return CGAL::to_double(CGAL::squared_distance(t, p));
    }

    static double SqrDistance(Triangle2d triangle, Line2d line)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto l = line.ToCGAL<K, Line2>();
        return CGAL::to_double(CGAL::squared_distance(t, l));
    }

    static double SqrDistance(Triangle2d triangle, Ray2d ray)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto r = ray.ToCGAL<K, Ray2>();
        return CGAL::to_double(CGAL::squared_distance(t, r));
    }

    static double SqrDistance(Triangle2d triangle, Segment2d segment)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto s = segment.ToCGAL<K, Segment2>();
        return CGAL::to_double(CGAL::squared_distance(t, s));
    }

    static double SqrDistance(Triangle2d triangle, Triangle2d triangle2)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto t2 = triangle2.ToCGAL<K, Triangle2>();
        return CGAL::to_double(CGAL::squared_distance(t, t2));
    }

};
