#pragma once

//#define CGAL_MESH_2_OPTIMIZER_VERBOSE
//#define CGAL_MESH_2_OPTIMIZERS_DEBUG
//#define CGAL_MESH_2_SIZING_FIELD_USE_BARYCENTRIC_COORDINATES

#include <CGAL/Exact_predicates_exact_constructions_kernel.h>
#include <CGAL/Exact_predicates_inexact_constructions_kernel.h>
#include <CGAL/Constrained_Delaunay_triangulation_2.h>
#include <CGAL/Delaunay_mesher_2.h>
#include <CGAL/Delaunay_mesh_face_base_2.h>
#include <CGAL/Delaunay_mesh_vertex_base_2.h>
#include <CGAL/Delaunay_mesh_size_criteria_2.h>
#include <CGAL/lloyd_optimize_mesh_2.h>
#include <iostream>
#include <vector>


namespace OptimizedMesh2
{

	typedef CGAL::Exact_predicates_exact_constructions_kernel K;
	typedef CGAL::Delaunay_mesh_vertex_base_2<K>                Vb;
	typedef CGAL::Delaunay_mesh_face_base_2<K>                  Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb>        Tds;
	typedef CGAL::Constrained_Delaunay_triangulation_2<K, Tds>  CDT;
	typedef CGAL::Delaunay_mesh_size_criteria_2<CDT>            Criteria;
	typedef CGAL::Delaunay_mesher_2<CDT, Criteria>              Mesher;
	typedef CDT::Vertex_handle Vertex_handle;
	typedef CDT::Point Point;

	CDT cdt;

	void Insert(const std::vector<Point>& points)
	{
		cdt.insert(points.begin(), points.end());
	}

	void Insert(const std::vector<std::pair<Point, Point>>& constraints)
	{
		for (auto iter = constraints.begin(); iter != constraints.end(); iter++)
		{
			auto p1 = iter->first;
			auto p2 = iter->second;

			cdt.insert_constraint(p1, p2);
		}
	}

	void GetPoints(std::vector<Point>& points)
	{
		for (auto vert = cdt.finite_vertices_begin(); vert != cdt.finite_vertices_end(); ++vert)
		{
			points.push_back(vert->point());
		}
	}

	void GetPoints(std::vector<Point>& points, Point2d* seeds, int start, int count)
	{
		for (int i = start; i < count; i++)
		{
			points.push_back(seeds->ToCGAL<K>());
		}
	}

	void RefineAndOptimize(int iterations, double angleBounds, double lengthBounds, std::vector<Point>& seeds)
	{

		if (angleBounds > 0.125)
			angleBounds = 0.125;

		Mesher mesher(cdt);

		int numSeeds = (int)seeds.size();

		if(numSeeds > 0)
			mesher.set_seeds(seeds.begin(), seeds.end());

		mesher.set_criteria(Criteria(angleBounds, lengthBounds));
		mesher.refine_mesh();

		//Compile error
		//auto code =  CGAL::lloyd_optimize_mesh_2(cdt, CGAL::parameters::max_iteration_number = 10);
		//return code;
	}

	void RefineAndOptimizeNoSeeds(int iterations, double angleBounds, double lengthBounds)
	{
		std::vector<Point> points;
		RefineAndOptimize(iterations, angleBounds, lengthBounds, points);
	}

	void RefineAndOptimizeWithSeeds(int iterations, double angleBounds, double lengthBounds, Point2d* seeds, int seedsStart, int seedsCount)
	{
		std::vector<Point> points;
		GetPoints(points, seeds, seedsStart, seedsCount);
		RefineAndOptimize(iterations, angleBounds, lengthBounds, points);
	}

	void Clear()
	{
		cdt.clear();
	}
	
}

