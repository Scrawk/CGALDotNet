#pragma once

#include <CGAL/Constrained_Delaunay_triangulation_2.h>
#include <CGAL/Triangulation_conformer_2.h>
#include <iostream>

template<class K>
class ConformingTriangulation2
{
public:

    typedef typename CGAL::Constrained_Delaunay_triangulation_2<K> CDT;
    typedef typename CDT::Point Point;
    typedef typename CDT::Vertex_handle Vertex_handle;

    static void MakeConforming(Point2d* points, int startIndex, int count)
    {

    }
};
