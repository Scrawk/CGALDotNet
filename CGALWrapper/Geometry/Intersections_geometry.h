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

    static Point2* CastToPoint2(void* ptr)
    {
        return static_cast<Point2*>(ptr);
    }

    static Line2* CastToLine2(void* ptr)
    {
        return static_cast<Line2*>(ptr);
    }

    static Ray2* CastToRay2(void* ptr)
    {
        return static_cast<Ray2*>(ptr);
    }

    static Segment2* CastToSegment2(void* ptr)
    {
        return static_cast<Segment2*>(ptr);
    }

    static Triangle2* CastToTriangle2(void* ptr)
    {
        return static_cast<Triangle2*>(ptr);
    }

    static Box2* CastToBox2(void* ptr)
    {
        return static_cast<Box2*>(ptr);
    }

    /*****************************************************
    *                                                    *
    *            Point2 DoIntersect Functions            *
    *                                                    *
    ******************************************************/

    static BOOL DoIntersect_PointLine(void* pointPtr, void* linePtr)
    {
        auto p = CastToPoint2(pointPtr);
        auto l = CastToLine2(linePtr);
        return CGAL::do_intersect(*p, *l);
    }

    static BOOL DoIntersect_PointRay(void* pointPtr, void* rayPtr)
    {
        auto p = CastToPoint2(pointPtr);
        auto r = CastToRay2(rayPtr);
        return CGAL::do_intersect(*p, *r);
    }

    static BOOL DoIntersect_PointSegment(void* pointPtr, void* segPtr)
    {
        auto p = CastToPoint2(pointPtr);
        auto s = CastToSegment2(segPtr);
        return CGAL::do_intersect(*p, *s);
    }

    static BOOL DoIntersect_PointTriangle(void* pointPtr, void* triPtr)
    {
        auto p = CastToPoint2(pointPtr);
        auto t = CastToTriangle2(triPtr);
        return CGAL::do_intersect(*p, *t);
    }

    static BOOL DoIntersect_PointBox(void* pointPtr, void* boxPtr)
    {
        auto p = CastToPoint2(pointPtr);
        auto b = CastToBox2(boxPtr);
        return CGAL::do_intersect(*p, *b);
    }

};
