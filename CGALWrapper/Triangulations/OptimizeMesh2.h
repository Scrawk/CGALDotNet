#pragma once

#include <CGAL/Exact_predicates_exact_constructions_kernel.h>
#include <CGAL/Exact_predicates_inexact_constructions_kernel.h>
#include <CGAL/Constrained_Delaunay_triangulation_2.h>
#include <CGAL/Delaunay_mesher_2.h>
#include <CGAL/Delaunay_mesh_face_base_2.h>
#include <CGAL/Delaunay_mesh_size_criteria_2.h>
#include <iostream>
#include <CGAL/Triangulation_conformer_2.h>

/*
namespace OptimizedMesh2
{

	typedef CGAL::Exact_predicates_exact_constructions_kernel K;
	typedef CGAL::Triangulation_vertex_base_2<K> Vb;
	typedef CGAL::Delaunay_mesh_face_base_2<K> Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;
	typedef CGAL::Constrained_Delaunay_triangulation_2<K, Tds> CDT;
	typedef CGAL::Delaunay_mesh_size_criteria_2<CDT> Criteria;
	typedef CDT::Vertex_handle Vertex_handle;
	typedef CDT::Point Point;

	CDT cdt;

	void Insert(std::vector<Point>& points)
	{
		cdt.insert(points.begin(), points.end());

		//std::cout << "Inserting: " << cdt.number_of_vertices() << std::endl;
	}

	void OptimizedMesh(int iterations, double angleBounds, double lengthBounds)
	{
		//std::cout << "Number of vertices: " << cdt.number_of_vertices() << std::endl;
		//std::cout << "Meshing the triangulation..." << std::endl;

		CGAL::refine_Delaunay_mesh_2(cdt, Criteria(angleBounds, lengthBounds));

		//std::cout << "Number of vertices: " << cdt.number_of_vertices() << std::endl;
	}

	void GetPoints(std::vector<Point>& points)
	{
		for (auto vert = cdt.finite_vertices_begin(); vert != cdt.finite_vertices_end(); ++vert)
		{
			points.push_back(vert->point());
		}

		//std::cout << "Get points: " << points.size() << std::endl;
	}

	void Clear()
	{
		//cdt.clear();
	}
	
}
*/

/*
namespace CGAL_Example_ConformingDelaunay
{
	
	typedef CGAL::Exact_predicates_exact_constructions_kernel K;
	typedef CGAL::Constrained_Delaunay_triangulation_2<K> CDT;
	typedef CDT::Point Point;
	typedef CDT::Vertex_handle Vertex_handle;
	
	void MakeConformingDelaunay(const std::vector<Point>& points, const std::vector<std::pair<Point, Point>>& constraints)
	{

		for (auto iter = points.begin(); iter != points.end(); iter++)
		{
			//double x = CGAL::to_double(iter->x());
			//double y = CGAL::to_double(iter->y());
			//std::cout << "Points (x,y) " << x << " " << y << std::endl;
		}
		
		CDT cdt;

		//std::vector< Vertex_handle> handles;

		for (auto iter = points.begin(); iter != points.end(); iter++)
		{
			//auto handle = cdt.insert(*iter);
			//handles.push_back(handle);
		}

		int numPoints = (int)points.size();
		for (auto iter = constraints.begin(); iter != constraints.end(); iter++)
		{
			//auto p1 = iter->first;
			//auto p2 = iter->second;

			//cdt.insert_constraint(p1, p2);
		}
		
		for (auto vert = cdt.finite_vertices_begin(); vert != cdt.finite_vertices_end(); ++vert)
		{
			//auto p = vert->point();

			//double x = CGAL::to_double(p.x());
			//double y = CGAL::to_double(p.y());
			//std::cout << "CDT Point (x,y) " << x << " " << y << std::endl;
		}
		

		//cdt.insert(points.begin(), points.end());

		//std::cout << "Number point " << points.size() << std::endl;
		//std::cout << "Number constriants " << constraints.size() << std::endl;

		//std::cout << "Number of vertices before: " << cdt.number_of_vertices() << std::endl;

		// make it conforming Delaunay
		//CGAL::make_conforming_Delaunay_2(cdt);

		//std::cout << "Number of vertices after make_conforming_Delaunay_2: " << cdt.number_of_vertices() << std::endl;

		// then make it conforming Gabriel
		//CGAL::make_conforming_Gabriel_2(cdt);

		//std::cout << "Number of vertices after make_conforming_Gabriel_2: " << cdt.number_of_vertices() << std::endl;

			
	}
}

*/
