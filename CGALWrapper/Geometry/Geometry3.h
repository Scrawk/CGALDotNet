#pragma once

#include "../CGALWrapper.h"
#include "CGAL/Point_3.h"
#include "CGAL/Vector_3.h"

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
    CGAL::Point_3<K> ToCGAL()
    {
        return CGAL::Point_3<K>(x, y, z);
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
    CGAL::Vector_3<K> ToVector()
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

};

struct Vector3d
{
    double x;
    double y;
    double z;

    template<class K>
    CGAL::Vector_3<K> ToCGAL()
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
    CGAL::Point_3<K> ToPoint()
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

};

struct Line3d
{
    Point3d position;
    Vector3d direction;

    template<class K, class LINE>
    LINE ToCGAL()
    {
        return { position.ToCGAL(), direction.ToCGAL() };
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






