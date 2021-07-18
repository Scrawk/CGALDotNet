#pragma once

#include "CGALWrapper.h"
#include "CGAL/Point_2.h"
#include "CGAL/Vector_2.h"

struct Point2d
{
    double x;
    double y;

    template<class K>
    CGAL::Point_2<K> To()
    {
        return CGAL::Point_2<K>(x, y);
    }

    template<class K>
    void From(CGAL::Point_2<K> p)
    {
        x = CGAL::to_double(p.x());
        y = CGAL::to_double(p.y());
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
    SEG To()
    {
        return { a.To<K>(), b.To<K>() };
    }

    template<class K>
    void From(CGAL::Point_2<K> a, CGAL::Point_2<K> b)
    {
        this->a.From<K>(a);
        this->b.From<K>(b);
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

