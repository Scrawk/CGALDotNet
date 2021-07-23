#pragma once

#include "CGALWrapper.h"
#include "CGAL/Point_2.h"
#include "CGAL/Vector_2.h"
#include "CGAL/Segment_2.h"

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

struct Vector2d
{
    double x;
    double y;

    template<class K>
    CGAL::Vector_2<K> ToCGAL()
    {
        return CGAL::Vector_2<K>(x, y);
    }

    template<class K>
    static Vector2d FromCGAL(CGAL::Vector_2<K> p)
    {
        double x = CGAL::to_double(p.x());
        double y = CGAL::to_double(p.y());
        return { x, y };
    }

    template<class K>
    CGAL::Point_2<K> ToPoint()
    {
        return CGAL::Point_2<K>(x, y);
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
        auto A = Point2d::FromCGAL<K>(a);
        auto B = Point2d::FromCGAL<K>(b);
        return { A, B };
    }
};

struct Triangle2d
{
    Point2d a;
    Point2d b;
    Point2d c;

    template<class K, class TRI>
    TRI ToCGAL()
    {
        return { a.ToCGAL<K>(), b.ToCGAL<K>(), c.ToCGAL<K>() };
    }

    template<class K>
    static Triangle2d FromCGAL(CGAL::Point_2<K> a, CGAL::Point_2<K> b, CGAL::Point_2<K> c)
    {
        auto A = Point2d::FromCGAL<K>(a);
        auto B = Point2d::FromCGAL<K>(b);
        auto C = Point2d::FromCGAL<K>(c);
        return { A, B, C };
    }
};

struct Ray2d
{
    Point2d pos;
    Vector2d dir;

    template<class K, class RAY>
    RAY ToCGAL()
    {
        return { pos.ToCGAL<K>(), dir.ToCGAL<K>() };
    }

    template<class K>
    static Ray2d FromCGAL(CGAL::Point_2<K> pos, CGAL::Point_2<K> dir)
    {
        auto Pos = Point2d::FromCGAL<K>(pos);
        auto Dir = Point2d::FromCGAL<K>(dir);
        return { Pos, Dir };
    }
};

struct Circle2d
{
    Point2d center;
    double radius;
};

