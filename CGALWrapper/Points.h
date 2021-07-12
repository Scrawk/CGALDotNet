#pragma once

#include "CGALWrapper.h"
#include "CGAL/Point_2.h"

struct Point2f
{
    float x;
    float y;

    template<class K>
    CGAL::Point_2<K> To()
    {
        return CGAL::Point_2<K>(x, y);
    }
};

struct Point2d
{
    double x;
    double y;

    template<class K>
    CGAL::Point_2<K> To()
    {
        return CGAL::Point_2<K>(x, y);
    }
};

