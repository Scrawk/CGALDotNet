#pragma once

#include "Geometry2.h"

#include <CGAL/intersections.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Direction_2.h>
#include <CGAL/Segment_2.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Triangle_2.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Line_2.h>
#include <CGAL/Iso_rectangle_2.h>
#include <CGAL/Ray_2.h>

#ifdef min
#undef min
#endif //min

#ifdef max
#undef max
#endif //min

enum INTERSECTION_RESULT_2D : int
{
    NONE,
    POINT2,
    LINE2,
    RAY2,
    SEGMENT2,
    BOX2,
    TRIANGLE2,
    POLYGON2
};

struct IntersectionResult2d
{
    Point2d points[6];
    int count;
    INTERSECTION_RESULT_2D type;
};

template<class K>
class Intersections
{

    typedef CGAL::Point_2<K> Point2;
    typedef CGAL::Line_2<K> Line2;
    typedef CGAL::Line_2<K> Ray2;
    typedef CGAL::Segment_2<K> Segment2;
    typedef CGAL::Triangle_2<K> Triangle2;
    typedef CGAL::Iso_rectangle_2<K> Box2;
    typedef std::vector<Point2> Polygon2;

    static IntersectionResult2d ToPoint(CGAL::Object obj)
    {
        if (obj.is_empty())
            return {};

        Point2 point;

        if (assign(point, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POINT2;
            result.count = 1;
            result.points[0] = Point2d::FromCGAL(point);
            return result;
        }

        return {};
    }

    static IntersectionResult2d ToBox(CGAL::Object obj)
    {
        if (obj.is_empty())
            return {};

        Box2 box;

        if (assign(box, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::BOX2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(box.min());
            result.points[1] = Point2d::FromCGAL(box.max());
            return result;
        }

        return {};
    }

    static IntersectionResult2d ToPointOrSegment(CGAL::Object obj)
    {
        if (obj.is_empty())
            return {};

        Point2 point;
        Segment2 seg;

        if (assign(point, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POINT2;
            result.count = 1;
            result.points[0] = Point2d::FromCGAL(point);
            return result;
        }
        else if (assign(seg, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::SEGMENT2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(seg.source());
            result.points[1] = Point2d::FromCGAL(seg.target());
            return result;
        }

        return {};
    }

    static IntersectionResult2d ToPointSegmentTriangleOrPolygon(CGAL::Object obj)
    {
        if (obj.is_empty())
            return {};

        Point2 point;
        Segment2 seg;
        Triangle2 tri;
        Polygon2 polygon;

        if (assign(point, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POINT2;
            result.count = 1;
            result.points[0] = Point2d::FromCGAL(point);
            return result;
        }
        else if (assign(seg, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::SEGMENT2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(seg.source());
            result.points[1] = Point2d::FromCGAL(seg.target());
            return result;
        }
        else if (assign(tri, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::TRIANGLE2;
            result.count = 3;
            result.points[0] = Point2d::FromCGAL(tri[0]);
            result.points[1] = Point2d::FromCGAL(tri[1]);
            result.points[2] = Point2d::FromCGAL(tri[2]);
            return result;
        }
        else if (assign(polygon, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POLYGON2;
            result.count = (int)polygon.size();

            for (int i = 0; i < result.count; i++)
                result.points[i] = Point2d::FromCGAL(polygon[i]);

            return result;
        }

        return {};
    }

    static IntersectionResult2d ToPointOrRay(CGAL::Object obj)
    {
        if (obj.is_empty())
            return {};

        Point2 point;
        Ray2 ray;

        if (assign(point, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POINT2;
            result.count = 1;
            result.points[0] = Point2d::FromCGAL(point);
            return result;
        }
        else if (assign(ray, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::RAY2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(ray.point());
            result.points[1] = Point2d::FromCGAL(ray.to_vector());
            return result;
        }

        return {};
    }

    static IntersectionResult2d ToPointOrLine(CGAL::Object obj)
    {
        if (obj.is_empty())
            return {};

        Point2 point;
        Line2 line;

        if (assign(point, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POINT2;
            result.count = 1;
            result.points[0] = Point2d::FromCGAL(point);
            return result;
        }
        else if (assign(line, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::LINE2;
            result.count = 2;
            result.points[0].x = CGAL::to_double(line.a());
            result.points[0].y = CGAL::to_double(line.b());
            result.points[1].x = CGAL::to_double(line.c());
            return result;
        }

        return {};
    }

    static IntersectionResult2d ToPointSegmentOrRay(CGAL::Object obj)
    {
        if (obj.is_empty())
            return {};

        Point2 point;
        Segment2 seg;
        Ray2 ray;

        if (assign(point, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POINT2;
            result.count = 1;
            result.points[0] = Point2d::FromCGAL(point);
            return result;
        }
        else if (assign(seg, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::SEGMENT2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(seg.source());
            result.points[1] = Point2d::FromCGAL(seg.target());
            return result;
        }
        else if (assign(ray, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::RAY2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(ray.point());
            result.points[1] = Point2d::FromCGAL(ray.to_vector());
            return result;
        }

        return {};
    }

    static IntersectionResult2d ToAny(CGAL::Object obj)
    {
        if (obj.is_empty())
            return {};

        Point2 point;
        Segment2 seg;
        Line2 line;
        Ray2 ray;
        Triangle2 tri;
        Box2 box;
        Polygon2 polygon;

        if (assign(point, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POINT2;
            result.count = 1;
            result.points[0] = Point2d::FromCGAL(point);
            return result;
        }
        else if (assign(seg, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::SEGMENT2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(seg.source());
            result.points[1] = Point2d::FromCGAL(seg.target());
            return result;
        }
        else if (assign(line, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::LINE2;
            result.count = 2;
            result.points[0].x = CGAL::to_double(line.a());
            result.points[0].y = CGAL::to_double(line.b());
            result.points[1].x = CGAL::to_double(line.c());
            return result;
        }
        else if (assign(ray, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::RAY2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(ray.point());
            result.points[1] = Point2d::FromCGAL(ray.to_vector());
            return result;
        }
        else if (assign(tri, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::TRIANGLE2;
            result.count = 3;
            result.points[0] = Point2d::FromCGAL(tri[0]);
            result.points[1] = Point2d::FromCGAL(tri[1]);
            result.points[2] = Point2d::FromCGAL(tri[2]);
            return result;
        }
        else if (assign(box, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::BOX2;
            result.count = 2;
            result.points[0] = Point2d::FromCGAL(box.min());
            result.points[1] = Point2d::FromCGAL(box.max());
            return result;
        }
        else if (assign(polygon, obj))
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POLYGON2;
            result.count = (int)polygon.size();

            for(int i = 0; i < result.count; i++)
                result.points[i] = Point2d::FromCGAL(polygon[i]);

            return result;
        }

        return {};
    }

public:

    //point 

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

    //line 

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

    //ray

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

    //segment

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

    //triangle

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

    //box

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

    //Point

    static IntersectionResult2d Intersection(Point2d point, Line2d line)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();

        return ToPoint(CGAL::intersection(p, l));
    }

    static IntersectionResult2d Intersection(Point2d point, Ray2d ray)
    {
        auto p = point.ToCGAL<K>();
        auto r = ray.ToCGAL<K, Ray2>();

        return ToPoint(CGAL::intersection(p, r));
    }

    static IntersectionResult2d Intersection(Point2d point, Segment2d segment)
    {
        auto p = point.ToCGAL<K>();
        auto s = segment.ToCGAL<K, Segment2>();

        return ToPoint(CGAL::intersection(p, s));
    }

    static IntersectionResult2d Intersection(Point2d point, Triangle2d triangle)
    {
        auto p = point.ToCGAL<K>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return ToPoint(CGAL::intersection(p, t));
    }

    static IntersectionResult2d Intersection(Point2d point, Box2d box)
    {
        auto p = point.ToCGAL<K>();
        auto b = box.ToCGAL<K, Box2>();

        return ToPoint(CGAL::intersection(p, b));
    }

    //Line

    static IntersectionResult2d Intersection(Line2d line, Point2d point)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();

        return ToPoint(CGAL::intersection(p, l));
    }

    static IntersectionResult2d Intersection(Line2d line, Line2d line2)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto l2 = line2.ToCGAL<K, Line2>();

        return ToPointOrLine(CGAL::intersection(l, l2));
    }

    static IntersectionResult2d Intersection(Line2d line, Ray2d ray)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto r = ray.ToCGAL<K, Ray2>();

        return ToPointOrRay(CGAL::intersection(l, r));
 
    }

    static IntersectionResult2d Intersection(Line2d line, Segment2d segment)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto s = segment.ToCGAL<K, Segment2>();

        return ToPointOrSegment(CGAL::intersection(l, s));
    }

    static IntersectionResult2d Intersection(Line2d line, Triangle2d triangle)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return ToPointOrSegment(CGAL::intersection(l, t));
    }

    static IntersectionResult2d Intersection(Line2d line, Box2d box)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto b = box.ToCGAL<K, Box2>();

        return ToPointOrSegment(CGAL::intersection(l, b));
    }

    //Ray

    static IntersectionResult2d Intersection(Ray2d ray, Point2d point)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto p = point.ToCGAL<K>();

        return ToPoint(CGAL::intersection(r, p));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Line2d line)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto l = line.ToCGAL<K, Line2>();

        return ToPointOrRay(CGAL::intersection(r, l));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Ray2d ray2)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto r2 = ray2.ToCGAL<K, Ray2>();

        return ToPointSegmentOrRay(CGAL::intersection(r, r2));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Segment2d segment)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto s = segment.ToCGAL<K, Segment2>();

        return ToPointOrSegment(CGAL::intersection(r, s));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Triangle2d triangle)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return ToPointOrSegment(CGAL::intersection(r, t));
    }

    static IntersectionResult2d Intersection(Ray2d ray, Box2d box)
    {
        auto r = ray.ToCGAL<K, Ray2>();;
        auto b = box.ToCGAL<K, Box2>();

        return ToPointOrSegment(CGAL::intersection(r, b));
    }

    //Segment

    static IntersectionResult2d Intersection(Segment2d segment, Point2d point)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto p = point.ToCGAL<K>();

        return ToPoint(CGAL::intersection(s, p));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Line2d line)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto l = line.ToCGAL<K, Line2>();

        return ToPointOrSegment(CGAL::intersection(s, l));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Ray2d ray)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto r = ray.ToCGAL<K, Ray2>();

        return ToPointOrSegment(CGAL::intersection(s, r));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Segment2d segment2)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto s2 = segment2.ToCGAL<K, Segment2>();

        return ToPointOrSegment(CGAL::intersection(s, s2));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Triangle2d triangle)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return ToPointOrSegment(CGAL::intersection(s, t));
    }

    static IntersectionResult2d Intersection(Segment2d segment, Box2d box)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto b = box.ToCGAL<K, Box2>();

        return ToPointOrSegment(CGAL::intersection(s, b));
    }

    //Triangle

    static IntersectionResult2d Intersection(Triangle2d triangle, Point2d point)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto p = point.ToCGAL<K>();

        return ToPoint(CGAL::intersection(t, p));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Line2d line)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto l = line.ToCGAL<K, Line2>();

        return ToPointOrSegment(CGAL::intersection(t, l));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Ray2d ray)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto r = ray.ToCGAL<K, Ray2>();

        return ToPointOrSegment(CGAL::intersection(t, r));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Segment2d segment)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto s = segment.ToCGAL<K, Segment2>();

        return ToPointOrSegment(CGAL::intersection(t, s));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Triangle2d triangle2)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto t2 = triangle2.ToCGAL<K, Triangle2>();

        return ToPointSegmentTriangleOrPolygon(CGAL::intersection(t, t2));
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Box2d box)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto b = box.ToCGAL<K, Box2>();

        return ToPointSegmentTriangleOrPolygon(CGAL::intersection(t, b));
    }

    //Box

    static IntersectionResult2d Intersection(Box2d box, Point2d point)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto p = point.ToCGAL<K>();

        return ToPoint(CGAL::intersection(b, p));
    }

    static IntersectionResult2d Intersection(Box2d box, Line2d line)
    {
        auto b = box.ToCGAL<K, Box2>();;
        auto l = line.ToCGAL<K, Line2>();

        return ToPointOrSegment(CGAL::intersection(b, l));
    }

    static IntersectionResult2d Intersection(Box2d box, Ray2d ray)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto r = ray.ToCGAL<K, Ray2>();

        return ToPointOrSegment(CGAL::intersection(b, r));
    }

    static IntersectionResult2d Intersection(Box2d box, Segment2d segment)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto s = segment.ToCGAL<K, Segment2>();

        return ToPointOrSegment(CGAL::intersection(b, s));
    }

    static IntersectionResult2d Intersection(Box2d box, Triangle2d triangle)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        return ToPointSegmentTriangleOrPolygon(CGAL::intersection(b, t));
    }

    static IntersectionResult2d Intersection(Box2d box, Box2d box2)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto b2 = box2.ToCGAL<K, Box2>();

        return ToBox(CGAL::intersection(b, b2));
    }
    

};
