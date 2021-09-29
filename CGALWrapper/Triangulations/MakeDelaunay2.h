#pragma once

#include <CGAL/Exact_predicates_exact_constructions_kernel.h>
#include <CGAL/Exact_predicates_inexact_constructions_kernel.h>
#include <CGAL/Constrained_Delaunay_triangulation_2.h>
#include <CGAL/Delaunay_mesher_2.h>
#include <CGAL/Delaunay_mesh_face_base_2.h>
#include <CGAL/Delaunay_mesh_size_criteria_2.h>
#include <CGAL/Triangulation_conformer_2.h>
#include <vector>

namespace MakeDelaunay2
{
	
	typedef CGAL::Exact_predicates_exact_constructions_kernel K;
	typedef CGAL::Constrained_Delaunay_triangulation_2<K> CDT;
	typedef CDT::Point Point;
	typedef CDT::Vertex_handle Vertex_handle;

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

	void MakeConformingDelaunay()
	{
		CGAL::make_conforming_Delaunay_2(cdt);
	}

	void GetPoints(std::vector<Point>& points)
	{
		for (auto vert = cdt.finite_vertices_begin(); vert != cdt.finite_vertices_end(); ++vert)
		{
			points.push_back(vert->point());
		}
	}

	void Clear()
	{
		cdt.clear();
	}
	

};
