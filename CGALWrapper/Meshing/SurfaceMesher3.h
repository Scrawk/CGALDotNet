#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

#include <CGAL/Surface_mesh_default_triangulation_3.h>
#include <CGAL/Complex_2_in_triangulation_3.h>
#include <CGAL/make_surface_mesh.h>
#include <CGAL/Implicit_surface_3.h>
#include <CGAL/IO/facets_in_complex_2_to_triangle_mesh.h>
#include <CGAL/Surface_mesh.h>
#include <fstream>

namespace SurfaceMesher3
{

    typedef CGAL::Surface_mesher::Surface_mesh_default_triangulation_3_generator<EIK>::Type Surface_triangulation_3;

    typedef Surface_triangulation_3 Tr;
    typedef CGAL::Complex_2_in_triangulation_3<Tr> C2t3;

    typedef Tr::Geom_traits GT;
    typedef GT::Sphere_3 Sphere_3;
    typedef GT::Point_3 Point_3;
    typedef GT::FT FT;

    typedef FT(*Function)(Point_3);
    typedef CGAL::Implicit_surface_3<GT, Function> Surface_3;
    typedef CGAL::Surface_mesh<Point_3> Surface_mesh;
    typedef Surface_mesh::Vertex_index vertex_index;
    typedef Surface_mesh::Face_index face_index;
    typedef Surface_mesh::Halfedge_index edge_index;

    Surface_mesh mesh;

    FT sphere_function(Point_3 p)
    {
        const FT x2 = p.x() * p.x(), y2 = p.y() * p.y(), z2 = p.z() * p.z();
        return x2 + y2 + z2 - 1;
    }

    int VertexCount()
    {
        return (int)mesh.number_of_vertices();
    }

    int TriangleCount()
    {
        return (int)mesh.number_of_faces();
    }

    void ClearMesh()
    {
        mesh.clear();
    }

    Point3d GetPoint(int i)
    {
        Point_3 p = mesh.point(vertex_index(i));
        return Point3d::FromCGAL(p);
    }

    TriangleIndex GetTriangle(int i)
    {
        auto iter = mesh.halfedge(face_index(i));

        TriangleIndex tri;

        int i = 0;
        for (auto v : vertices_around_face(iter, mesh))
        {
            if (i == 0)
                tri.a = v;
            else if (i == 1)
                tri.b = v;
            else if (i == 2)
                tri.c = v;
            else
                break;

            i++;
        }

        return tri;
    }

    void Generate()
    {
        Tr tr;        
        C2t3 c2t3(tr);  

        // Note that "2." above is the *squared* radius of the bounding sphere!
        Surface_3 surface(sphere_function, Sphere_3(CGAL::ORIGIN, 2.0)); 

        CGAL::Surface_mesh_default_criteria_3<Tr> criteria(
            30.0,  // angular bound
            0.1,  // radius bound
            0.1); // distance bound

        CGAL::make_surface_mesh(c2t3, surface, criteria, CGAL::Non_manifold_tag());

        mesh.clear();
        CGAL::facets_in_complex_2_to_triangle_mesh(c2t3, mesh);
        
    }

}
