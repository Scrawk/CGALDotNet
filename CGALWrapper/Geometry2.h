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
    static Point2d FromCGAL(CGAL::Vector_2<K> v)
    {
        double x = CGAL::to_double(v.x());
        double y = CGAL::to_double(v.y());
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

struct Line2d
{
    double a, b, c;

    template<class K, class LINE>
    LINE ToCGAL()
    {
        return { a, b, c };
    }

    template<class K>
    static Line2d FromCGAL(K a, K b, K c)
    {
        double A = CGAL::to_double(a);
        double B = CGAL::to_double(b);
        double C = CGAL::to_double(c);
        return { A, B, C };
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
    static Ray2d FromCGAL(CGAL::Point_2<K> pos, CGAL::Vector_2<K> dir)
    {
        auto Pos = Point2d::FromCGAL<K>(pos);
        auto Dir = Vector2d::FromCGAL<K>(dir);
        return { Pos, Dir };
    }
};

struct Box2d
{
    Point2d min;
    Point2d max;

    template<class K, class BOX>
    BOX ToCGAL()
    {
        return { min.ToCGAL<K>(), max.ToCGAL<K>() };
    }

    template<class K>
    static Box2d FromCGAL(CGAL::Point_2<K> min, CGAL::Point_2<K> max)
    {
        auto Min = Point2d::FromCGAL<K>(min);
        auto Max = Point2d::FromCGAL<K>(max);
        return { Min, Max };
    }
};

struct Circle2d
{
    Point2d center;
    double radius;
};

