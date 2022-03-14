#pragma once

#include "../CGALWrapper.h"
#include "CGAL/Point_3.h"
#include "CGAL/Vector_3.h"
#include <CGAL/Plane_3.h>
#include <CGAL/Bbox_3.h>
#include <CGAL/Ray_3.h>
#include <CGAL/Triangle_3.h>
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

struct Point3d
{
    double x;
    double y;
    double z;

    template<class K>
    CGAL::Point_3<K> ToCGAL() const
    {
        return CGAL::Point_3<K>(x, y, z);
    }

    template<class K>
    CGAL::Weighted_point_3<K> ToCGALWeightedPoint() const
    {
        return CGAL::Weighted_point_3<K>(CGAL::Point_3<K>(x, y, z), 1);
    }

    template<class K>
    static Point3d FromCGAL(CGAL::Point_3<K> p)
    {
        double x = CGAL::to_double(p.x());
        double y = CGAL::to_double(p.y());
        double z = CGAL::to_double(p.z());
        return { x, y, z };
    }

    template<class K>
    static Point3d FromCGAL(CGAL::Point_2<K> p)
    {
        double x = CGAL::to_double(p.x());
        double y = CGAL::to_double(p.y());
        double z = 0;
        return { x, y, z };
    }

    template<class K>
    static Point3d FromCGAL(CGAL::Vector_3<K> v)
    {
        double x = CGAL::to_double(v.x());
        double y = CGAL::to_double(v.y());
        double z = CGAL::to_double(v.z());
        return { x, y, z };
    }

    template<class K>
    CGAL::Vector_3<K> ToVector() const
    {
        return CGAL::Vector_3<K>(x, y, z);
    }

    bool operator==(const Point3d& rhs) const
    {
        return x == rhs.x && y == rhs.y && z == rhs.z;
    }

    bool operator!=(const Point3d& rhs) const
    {
        return !operator==(rhs);
    }

    Point3d operator+(const Point3d& rhs) const
    {
        return { x + rhs.x , y + rhs.y, z + rhs.z };
    }

    Point3d operator-(const Point3d& rhs) const
    {
        return { x - rhs.x , y - rhs.y, z - rhs.z };
    }

    Point3d operator/(double rhs) const
    {
        return { x / rhs , y / rhs, z / rhs };
    }

    Point3d operator*(double rhs) const
    {
        return { x * rhs , y * rhs, z * rhs };
    }

    friend std::ostream& operator<<(std::ostream& output, const Point3d& rhs) {
        output << "(" << rhs.x << ", " << rhs.y << ", " << rhs.z << ")";
        return output;
    }

};

//used to represent a weighted or homogenous point.
struct HPoint3d
{
    double hx;
    double hy;
    double hz;
    double hw;

    template<class K>
    CGAL::Weighted_point_3<K> ToCGALWeightedPoint() const
    {
        return CGAL::Weighted_point_3<K>(CGAL::Point_3<K>(hx, hy, hz), hw);
    }

    template<class K>
    static HPoint3d FromCGAL(CGAL::Weighted_point_3<K> p)
    {
        double hx = CGAL::to_double(p.hx());
        double hy = CGAL::to_double(p.hy());
        double hz = CGAL::to_double(p.hz());
        double hw = CGAL::to_double(p.hw());
        return { hx, hy, hz, hw };
    }

    bool operator==(const HPoint3d& rhs) const
    {
        return hx == rhs.hx && hy == rhs.hy && hz == rhs.hz && hw == rhs.hw;
    }

    bool operator!=(const HPoint3d& rhs) const
    {
        return !operator==(rhs);
    }

    HPoint3d operator+(const HPoint3d& rhs) const
    {
        return { hx + rhs.hx , hy + rhs.hy, hz + rhs.hz, hw + rhs.hw };
    }

    HPoint3d operator-(const HPoint3d& rhs) const
    {
        return { hx - rhs.hx , hy - rhs.hy, hz - rhs.hz, hw - rhs.hw };
    }

    HPoint3d operator/(double rhs) const
    {
        return { hx / rhs , hy / rhs, hz / rhs, hw / rhs };
    }

    HPoint3d operator*(double rhs) const
    {
        return { hx * rhs , hy * rhs, hz * rhs, hw * rhs };
    }

    friend std::ostream& operator<<(std::ostream& output, const HPoint3d& rhs) {
        output << "(" << rhs.hx << ", " << rhs.hy << ", " << rhs.hz << ", " << rhs.hw << ")";
        return output;
    }

};

struct Vector3d
{
    double x;
    double y;
    double z;

    template<class K>
    CGAL::Vector_3<K> ToCGAL() const
    {
        return CGAL::Vector_3<K>(x, y, z);
    }

    template<class K>
    static Vector3d FromCGAL(CGAL::Vector_3<K> p)
    {
        double x = CGAL::to_double(p.x());
        double y = CGAL::to_double(p.y());
        double z = CGAL::to_double(p.z());
        return { x, y, z };
    }

    template<class K>
    CGAL::Point_3<K> ToPoint() const
    {
        return CGAL::Point_3<K>(x, y, z);
    }

    bool operator==(const Vector3d& rhs) const
    {
        return x == rhs.x && y == rhs.y && z == rhs.z;
    }

    bool operator!=(const Vector3d& rhs) const
    {
        return !operator==(rhs);
    }

    friend std::ostream& operator<<(std::ostream& output, const Vector3d& rhs) {
        output << "(" << rhs.x << ", " << rhs.y << ", " << rhs.z << ")";
        return output;
    }

};

struct Segment3d
{
    Point3d a;
    Point3d b;

    template<class K, class SEG>
    SEG ToCGAL() const
    {
        return { a.ToCGAL<K>(), b.ToCGAL<K>() };
    }

    template<class K>
    static Segment3d FromCGAL(CGAL::Point_3<K> a, CGAL::Point_3<K> b)
    {
        auto A = Point3d::FromCGAL<K>(a);
        auto B = Point3d::FromCGAL<K>(b);
        return { A, B };
    }

    template<class K>
    static Segment3d FromCGAL(CGAL::Segment_3<K> seg)
    {
        auto A = Point3d::FromCGAL<K>(seg.source());
        auto B = Point3d::FromCGAL<K>(seg.target());
        return { A, B };
    }

};

struct Line3d
{
    Point3d position;
    Vector3d direction;

    template<class K, class LINE>
    LINE ToCGAL() const
    {
        return { position.ToCGAL<K>(), direction.ToCGAL<K>() };
    }

    template<class K>
    static Line3d FromCGAL(CGAL::Point_3<K> pos, CGAL::Vector_3<K> dir)
    {
        return { Point3d::FromCGAL(pos), Vector3d::FromCGAL(dir) };
    }
};

struct TriangleIndex
{
    int a, b, c;
};

struct  Plane3d
{
    Point3d position;
    Vector3d direction;

    template<class K, class PLANE>
    PLANE ToCGAL() const
    {
        return { position.ToCGAL<K>(), direction.ToCGAL<K>() };
    }

    template<class K>
    static Plane3d FromCGAL(CGAL::Point_3<K> pos, CGAL::Vector_3<K> dir)
    {
        return { Point3d::FromCGAL(pos), Vector3d::FromCGAL(dir) };
    }
};

struct Box3d
{
    Point3d min;
    Point3d max;

    template<class K, class BOX>
    BOX ToCGAL() const
    {
        return { min.ToCGAL<K>(), max.ToCGAL<K>() };
    }

    template<class K>
    static Box3d FromCGAL(CGAL::Point_3<K> min, CGAL::Point_3<K> max)
    {
        auto Min = Point3d::FromCGAL<K>(min);
        auto Max = Point3d::FromCGAL<K>(max);
        return { Min, Max };
    }

    template<class K>
    static Box3d FromCGAL(CGAL::Bbox_3 box)
    {
        double xmin = CGAL::to_double(box.xmin());
        double ymin = CGAL::to_double(box.ymin());
        double zmin = CGAL::to_double(box.zmin());

        double xmax = CGAL::to_double(box.xmax());
        double ymax = CGAL::to_double(box.ymax());
        double zmax = CGAL::to_double(box.zmax());

        Point3d min = { xmin, ymin, zmin };
        Point3d max = { xmax, ymax, zmax };

        return { min, max };
    }
};

struct  Ray3d
{
    Point3d position;
    Vector3d direction;

    template<class K, class RAY>
    RAY ToCGAL() const
    {
        return { position.ToCGAL<K>(), direction.ToCGAL<K>() };
    }

    template<class K>
    static Ray3d FromCGAL(CGAL::Point_3<K> pos, CGAL::Vector_3<K> dir)
    {
        return { Point3d::FromCGAL(pos), Vector3d::FromCGAL(dir) };
    }
};

struct Triangle3d
{
    Point3d a;
    Point3d b;
    Point3d c;

    template<class K, class TRI>
    TRI ToCGAL() const
    {
        return { a.ToCGAL<K>(), b.ToCGAL<K>(), c.ToCGAL<K>() };
    }

    template<class K>
    static Triangle3d FromCGAL(CGAL::Point_3<K> a, CGAL::Point_3<K> b, CGAL::Point_3<K> c)
    {
        auto A = Point3d::FromCGAL<K>(a);
        auto B = Point3d::FromCGAL<K>(b);
        auto C = Point3d::FromCGAL<K>(c);
        return { A, B, C };
    }

    template<class K>
    static Triangle3d FromCGAL(CGAL::Triangle_3<K> tri)
    {
        auto A = Point3d::FromCGAL<K>(tri[0]);
        auto B = Point3d::FromCGAL<K>(tri[1]);
        auto C = Point3d::FromCGAL<K>(tri[2]);
        return { A, B, C };
    }

};

struct Tetahedron3d
{
    Point3d a;
    Point3d b;
    Point3d c;
    Point3d d;

    template<class K>
    static Tetahedron3d FromCGAL(CGAL::Point_3<K> a, CGAL::Point_3<K> b, CGAL::Point_3<K> c, CGAL::Point_3<K> d)
    {
        auto A = Point3d::FromCGAL<K>(a);
        auto B = Point3d::FromCGAL<K>(b);
        auto C = Point3d::FromCGAL<K>(c);
        auto D = Point3d::FromCGAL<K>(d);
        return { A, B, C, D };
    }

};






