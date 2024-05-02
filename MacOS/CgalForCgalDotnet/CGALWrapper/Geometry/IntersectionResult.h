#pragma once

#include "../CGALWrapper.h"
#include "Geometry2.h"

#include <CGAL/intersections.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Direction_2.h>
#include <CGAL/Segment_2.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Triangle_2.h>
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
    TRIANGLE2,
    POLYGON2
};

struct IntersectionResult2d
{
    Point2d points[6];
    int count;
    INTERSECTION_RESULT_2D type;
};

#ifdef min
#undef min
#endif //min

#ifdef max
#undef max
#endif //max

template<class K>
class IntersectionResult
{

    typedef CGAL::Point_2<K> Point2;
    typedef CGAL::Line_2<K> Line2;
    typedef CGAL::Ray_2<K> Ray2;
    typedef CGAL::Segment_2<K> Segment2;
    typedef CGAL::Triangle_2<K> Triangle2;
    typedef CGAL::Iso_rectangle_2<K> Box2;
    typedef std::vector<Point2> Polygon2;

public:

    static IntersectionResult2d ToPoint(CGAL::Object obj)
    {
        if (obj == nullptr || obj.is_empty())
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
        if (obj == nullptr || obj.is_empty())
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
        if (obj == nullptr || obj.is_empty())
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
        if (obj == nullptr || obj.is_empty())
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
        if (obj == nullptr || obj.is_empty())
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
            result.points[0] = Point2d::FromCGAL(ray.source());
            result.points[1] = Point2d::FromCGAL(ray.to_vector());
            return result;
        }

        return {};
    }

    static IntersectionResult2d ToPointOrLine(CGAL::Object obj)
    {
        if (obj == nullptr || obj.is_empty())
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
        if (obj == nullptr || obj.is_empty())
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
            result.points[0] = Point2d::FromCGAL(ray.source());
            result.points[1] = Point2d::FromCGAL(ray.to_vector());
            return result;
        }

        return {};
    }

    static IntersectionResult2d ToAny(CGAL::Object obj)
    {
        if (obj == nullptr || obj.is_empty())
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
            result.points[0] = Point2d::FromCGAL(ray.source());
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

            for (int i = 0; i < result.count; i++)
                result.points[i] = Point2d::FromCGAL(polygon[i]);

            return result;
        }

        return {};
    }

};

