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
    CGAL::Vector_2<K> ToVector()
    {
        return CGAL::Vector_2<K>(x, y);
    }

};

