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

enum INTERSECTION_RESULT_2D : int
{
    NONE,
    POINT2,
    LINE2,
    RAY2,
    SEGMENT2,
    BOX2,
    TRIANGLE2
};

struct IntersectionResult2d
{
    INTERSECTION_RESULT_2D type;
    Point2d a, b, c;
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

    struct Intersection_visitor 
    {
        IntersectionResult2d operator()(const Point2& p) const
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::POINT2;
            result.a = Point2d::FromCGAL(p);
            return result;
        }

        IntersectionResult2d operator()(const Line2& l) const
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::LINE2;
            result.a.x = CGAL::to_double(l.a());
            result.a.y = CGAL::to_double(l.b());
            result.b.x = CGAL::to_double(l.c());
            return result;
        }

        IntersectionResult2d operator()(const Ray2& r)
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::RAY2;
            result.a = Point2d::FromCGAL(r.point());
            result.b = Point2d::FromCGAL(r.to_vector());
            return result;
        }

        IntersectionResult2d operator()(const Segment2& s) const
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::SEGMENT2;
            result.a = Point2d::FromCGAL(s.source());
            result.b = Point2d::FromCGAL(s.target());
            return result;
        }

        IntersectionResult2d operator()(const Triangle2& t) const
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::TRIANGLE2;
            result.a = Point2d::FromCGAL(t[0]);
            result.b = Point2d::FromCGAL(t[1]);
            result.c = Point2d::FromCGAL(t[2]);
            return result;
        }

        IntersectionResult2d operator()(const Box2& b) const
        {
            IntersectionResult2d result = {};
            result.type = INTERSECTION_RESULT_2D::BOX2;
            result.a = Point2d::FromCGAL(b.min);
            result.b = Point2d::FromCGAL(b.max);
            return result;
        }

    };


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

        const auto result = CGAL::intersection(p, l);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Point2d point, Ray2d ray)
    {
        auto p = point.ToCGAL<K>();
        auto r = ray.ToCGAL<K, Ray2>();

        const auto result = CGAL::intersection(p, r);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Point2d point, Segment2d segment)
    {
        auto p = point.ToCGAL<K>();
        auto s = segment.ToCGAL<K, Segment2>();

        const auto result = CGAL::intersection(p, s);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Point2d point, Triangle2d triangle)
    {
        auto p = point.ToCGAL<K>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        const auto result = CGAL::intersection(p, t);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Point2d point, Box2d box)
    {
        auto p = point.ToCGAL<K>();
        auto b = box.ToCGAL<K, Box2>();

        const auto result = CGAL::intersection(p, b);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    //Line

    static IntersectionResult2d Intersection(Line2d line, Point2d point)
    {
        auto p = point.ToCGAL<K>();
        auto l = line.ToCGAL<K, Line2>();

        const auto result = CGAL::intersection(p, l);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Line2d line, Line2d line2)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto l2 = line2.ToCGAL<K, Line2>();

        const auto result = CGAL::intersection(l, l2);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Line2d line, Ray2d ray)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto r = ray.ToCGAL<K, Ray2>();

        const auto result = CGAL::intersection(l, r);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Line2d line, Segment2d segment)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto s = segment.ToCGAL<K, Segment2>();

        const auto result = CGAL::intersection(l, s);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Line2d line, Triangle2d triangle)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        const auto result = CGAL::intersection(l, t);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Line2d line, Box2d box)
    {
        auto l = line.ToCGAL<K, Line2>();
        auto b = box.ToCGAL<K, Box2>();

        const auto result = CGAL::intersection(l, b);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    //Ray

    static IntersectionResult2d Intersection(Ray2d ray, Point2d point)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto p = point.ToCGAL<K>();

        const auto result = CGAL::intersection(r, p);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Ray2d ray, Line2d line)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto l = line.ToCGAL<K, Line2>();

        const auto result = CGAL::intersection(r, l);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Ray2d ray, Ray2d ray2)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto r2 = ray2.ToCGAL<K, Ray2>();

        const auto result = CGAL::intersection(r, r2);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Ray2d ray, Segment2d segment)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto s = segment.ToCGAL<K, Segment2>();

        const auto result = CGAL::intersection(r, s);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Ray2d ray, Triangle2d triangle)
    {
        auto r = ray.ToCGAL<K, Ray2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        const auto result = CGAL::intersection(r, t);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Ray2d ray, Box2d box)
    {
        auto r = ray.ToCGAL<K, Ray2>();;
        auto b = box.ToCGAL<K, Box2>();

        const auto result = CGAL::intersection(r, b);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    //Segment

    static IntersectionResult2d Intersection(Segment2d segment, Point2d point)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto p = point.ToCGAL<K>();

        const auto result = CGAL::intersection(s, p);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Segment2d segment, Line2d line)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto l = line.ToCGAL<K, Line2>();

        const auto result = CGAL::intersection(s, l);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Segment2d segment, Ray2d ray)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto r = ray.ToCGAL<K, Ray2>();

        const auto result = CGAL::intersection(s, r);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Segment2d segment, Segment2d segment2)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto s2 = segment2.ToCGAL<K, Segment2>();

        const auto result = CGAL::intersection(s, s2);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Segment2d segment, Triangle2d triangle)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        const auto result = CGAL::intersection(s, t);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Segment2d segment, Box2d box)
    {
        auto s = segment.ToCGAL<K, Segment2>();
        auto b = box.ToCGAL<K, Box2>();

        const auto result = CGAL::intersection(s, b);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    //Triangle

    static IntersectionResult2d Intersection(Triangle2d triangle, Point2d point)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto p = point.ToCGAL<K>();

        const auto result = CGAL::intersection(t, p);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Line2d line)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto l = line.ToCGAL<K, Line2>();

        const auto result = CGAL::intersection(t, l);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Ray2d ray)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto r = ray.ToCGAL<K, Ray2>();

        const auto result = CGAL::intersection(t, r);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Segment2d segment)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto s = segment.ToCGAL<K, Segment2>();

        const auto result = CGAL::intersection(t, s);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Triangle2d triangle2)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto t2 = triangle2.ToCGAL<K, Triangle2>();

        const auto result = CGAL::intersection(t, t2);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Triangle2d triangle, Box2d box)
    {
        auto t = triangle.ToCGAL<K, Triangle2>();
        auto b = box.ToCGAL<K, Box2>();

        const auto result = CGAL::intersection(t, b);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    //Box

    static IntersectionResult2d Intersection(Box2d box, Point2d point)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto p = point.ToCGAL<K>();

        const auto result = CGAL::intersection(b, p);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Box2d box, Line2d line)
    {
        auto b = box.ToCGAL<K, Box2>();;
        auto l = line.ToCGAL<K, Line2>();

        const auto result = CGAL::intersection(b, l);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Box2d box, Ray2d ray)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto r = ray.ToCGAL<K, Ray2>();

        const auto result = CGAL::intersection(b, r);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Box2d box, Segment2d segment)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto s = segment.ToCGAL<K, Segment2>();

        const auto result = CGAL::intersection(b, s);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Box2d box, Triangle2d triangle)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto t = triangle.ToCGAL<K, Triangle2>();

        const auto result = CGAL::intersection(b, t);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

    static IntersectionResult2d Intersection(Box2d box, Box2d box2)
    {
        auto b = box.ToCGAL<K, Box2>();
        auto b2 = box2.ToCGAL<K, Box2>();

        const auto result = CGAL::intersection(b, b2);
        if (result)
            return boost::apply_visitor(Intersection_visitor(), *result);
        else
            return {};
    }

};
