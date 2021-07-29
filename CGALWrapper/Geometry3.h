#pragma once

#include "CGALWrapper.h"
#include "CGAL/Point_3.h"
#include "CGAL/Vector_3.h"

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






