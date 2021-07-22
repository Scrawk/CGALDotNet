#pragma once

#include "CGALWrapper.h"
#include "CGAL/Point_2.h"
#include "CGAL/Vector_2.h"

struct Point2d
{
    double x;
    double y;

    template<class K>
    CGAL::Point_2<K> ToCGAL()
    {
        return CGAL::Point_2<K>(x, y);
    }

    template<class K>
    static Point2d FromCGAL(CGAL::Point_2<K> p)
    {
        double x = CGAL::to_double(p.x());
        double y = CGAL::to_double(p.y());
        return { x, y };
    }

    template<class K>
    CGAL::Vector_2<K> ToVector()
    {
        return CGAL::Vector_2<K>(x, y);
    }

};

struct Segment2d
{
    Point2d a;
    Point2d b;

    template<class K, class SEG>
    SEG ToCGAL()
    {
        return { a.ToCGAL<K>(), b.ToCGAL<K>() };
    }

    template<class K>
    static Segment2d FromCGAL(CGAL::Point_2<K> a, CGAL::Point_2<K> b)
    {
        auto c = Point2d::FromCGAL<K>(a);
        auto d = Point2d::FromCGAL<K>(b);
        return { c, d };
    }

};

struct Triangle2d
{
    Point2d a;
    Point2d b;
    Point2d c;
};

struct Circle2d
{
    Point2d center;
    double radius;
};

