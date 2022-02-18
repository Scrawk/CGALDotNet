#pragma once

#include "../CGALWrapper.h"
#include "CGAL/Point_2.h"
#include "CGAL/Point_3.h"
#include "CGAL/Vector_2.h"
#include "CGAL/Segment_2.h"

#include <iostream>

/*
* Structs to pass data from C# and c++.
* Must be c style layout.
* 
* A standard-layout class is a class that:
*
* Has no non-static data members of type non-standard-layout class (or array of such types) or reference,
* Has no virtual functions and no virtual base classes,
* Has the same access control for all non-static data members,
* Has no non-standard-layout base classes,
* Either has no non-static data members in the most derived class and at most one base class with non-static data members, 
* or has no base classes with non-static data members, and
* Has no base classes of the same type as the first non-static data member.
*
*/

struct Point2d
{

    double x;
    double y;

    template<class K>
    CGAL::Point_2<K> ToCGAL() const
    {
        return CGAL::Point_2<K>(x, y);
    }

    template<class K>
    CGAL::Point_3<K> ToCGAL3() const
    {
        return CGAL::Point_3<K>(x, y, 0);
    }

    template<class K>
    CGAL::Point_3<K> ToCGAL3XZ() const
    {
        return CGAL::Point_3<K>(x, 0, y);
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
    CGAL::Vector_2<K> ToVector() const
    {
        return CGAL::Vector_2<K>(x, y);
    }

    bool operator==(const Point2d& rhs) const
    {
        return x == rhs.x && y == rhs.y;
    }

    bool operator!=(const Point2d& rhs) const
    {
        return !operator==(rhs);
    }

    Point2d operator+(const Point2d& rhs) const
    {
        return { x + rhs.x , y + rhs.y};
    }

    Point2d operator-(const Point2d& rhs) const
    {
        return { x - rhs.x , y - rhs.y };
    }

    Point2d operator/(double rhs) const
    {
        return { x / rhs , y / rhs };
    }

    Point2d operator*(double rhs) const
    {
        return { x * rhs , y * rhs };
    }

    friend std::ostream& operator<<(std::ostream& output, const Point2d& rhs) {
        output << "(" << rhs.x << ", " << rhs.y << ")";
        return output;
    }

};

//used to represent a weighted or homogenous point.
struct HPoint2d
{
    double hx;
    double hy;
    double hw;

    template<class K>
    CGAL::Weighted_point_2<K> ToCGALWeightedPoint() const
    {
        return CGAL::Weighted_point_2<K>(CGAL::Point_2<K>(hx, hy), hw);
    }

    template<class K>
    static HPoint2d FromCGAL(CGAL::Weighted_point_2<K> p)
    {
        double x = CGAL::to_double(p.hx());
        double y = CGAL::to_double(p.hy());
        double w = CGAL::to_double(p.hw());
        return { x, y, w };
    }

    bool operator==(const HPoint2d& rhs) const
    {
        return hx == rhs.hx && hy == rhs.hy && hw == rhs.hw;
    }

    bool operator!=(const HPoint2d& rhs) const
    {
        return !operator==(rhs);
    }

    HPoint2d operator+(const HPoint2d& rhs) const
    {
        return { hx + rhs.hx , hy + rhs.hy, hw + rhs.hw };
    }

    HPoint2d operator-(const HPoint2d& rhs) const
    {
        return { hx - rhs.hx , hy - rhs.hy, hw - rhs.hw };
    }

    HPoint2d operator/(double rhs) const
    {
        return { hx / rhs , hy / rhs, hw / rhs };
    }

    HPoint2d operator*(double rhs) const
    {
        return { hx * rhs , hy * rhs, hw * rhs };
    }

    friend std::ostream& operator<<(std::ostream& output, const HPoint2d& rhs) {
        output << "(" << rhs.hx << ", " << rhs.hy << ", " << rhs.hw << ")";
        return output;
    }

};

struct Vector2d
{
    double x;
    double y;

    template<class K>
    CGAL::Vector_2<K> ToCGAL() const
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
    CGAL::Point_2<K> ToPoint() const
    {
        return CGAL::Point_2<K>(x, y);
    }

    bool operator==(const Vector2d& rhs) const
    {
        return x == rhs.x && y == rhs.y;
    }

    bool operator!=(const Vector2d& rhs) const
    {
        return !operator==(rhs);
    }

    friend std::ostream& operator<<(std::ostream& output, const Vector2d& rhs) {
        output << "(" << rhs.x << ", " << rhs.y << ")";
        return output;
    }

};

struct Segment2d
{
    Point2d a;
    Point2d b;

    template<class K, class SEG>
    SEG ToCGAL() const
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

    template<class K>
    static Segment2d FromCGAL(CGAL::Segment_2<K> seg)
    {
        auto A = Point2d::FromCGAL<K>(seg.source());
        auto B = Point2d::FromCGAL<K>(seg.target());
        return { A, B };
    }

};

struct Line2d
{
    double a, b, c;

    template<class K, class LINE>
    LINE ToCGAL() const
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
    TRI ToCGAL() const
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
    RAY ToCGAL() const
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
    BOX ToCGAL() const
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

    template<class K>
    static Box2d FromCGAL(CGAL::Bbox_2 box)
    {
        double xmin = CGAL::to_double(box.xmin());
        double ymin = CGAL::to_double(box.ymin());

        double xmax = CGAL::to_double(box.xmax());
        double ymax = CGAL::to_double(box.ymax());

        Point2d min = { xmin, ymin };
        Point2d max = { xmax, ymax };

        return { min, max };
    }
};

struct Circle2d
{
    Point2d center;
    double radius;
};

