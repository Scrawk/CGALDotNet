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

    static int Wrap(int v, int count)
    {
        int r = v % count;
        return r < 0 ? r + count : r;
    }

    static void MakeConforming(Point2d* points, int startIndex, int count)
    {
        CDT cdt;

        for (int i = 0; i < count - 1; i++)
        {
            int i0 = Wrap(i + 0, count);
            int i1 = Wrap(i + 1, count);

            Point pa = points[i0].ToCGAL<K>();
            Point pb = points[i1].ToCGAL<K>();

            Vertex_handle va = cdt.insert(pa);
            Vertex_handle vb = cdt.insert(pb);

            cdt.insert_constraint(va, vb);
        }

        

        std::cout << "Number of vertices before: " << cdt.number_of_vertices() << std::endl;

        // make it conforming Delaunay
        CGAL::make_conforming_Delaunay_2(cdt);
        std::cout << "Number of vertices after make_conforming_Delaunay_2: " << cdt.number_of_vertices() << std::endl;

        // then make it conforming Gabriel
        CGAL::make_conforming_Gabriel_2(cdt);

        std::cout << "Number of vertices after make_conforming_Gabriel_2: " << cdt.number_of_vertices() << std::endl;
    }
};
