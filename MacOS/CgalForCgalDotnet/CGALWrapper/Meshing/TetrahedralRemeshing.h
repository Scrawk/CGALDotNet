#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

#include <CGAL/Tetrahedral_remeshing/Remeshing_triangulation_3.h>
#include <CGAL/tetrahedral_remeshing.h>
#include <CGAL/Mesh_triangulation_3.h>
#include <CGAL/Mesh_complex_3_in_triangulation_3.h>
#include <CGAL/Mesh_criteria_3.h>
#include <CGAL/Polyhedral_mesh_domain_with_features_3.h>
#include <CGAL/make_mesh_3.h>
#include <vector>

template<class K>
class TetrahedralRemeshing
{

private:

	std::vector<Point3d> buffer;

public:

	typedef typename CGAL::Tetrahedral_remeshing::Remeshing_triangulation_3<K> Remeshing_triangulation;
	typedef typename Remeshing_triangulation::Point Point;

	inline static TetrahedralRemeshing* NewTetrahedralRemeshing()
	{
		return new TetrahedralRemeshing();
	}

	inline static void DeleteTetrahedralRemeshing(void* ptr)
	{
		auto obj = static_cast<TetrahedralRemeshing*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static TetrahedralRemeshing* CastToTetrahedralRemeshing(void* ptr)
	{
		return static_cast<TetrahedralRemeshing*>(ptr);
	}

	static std::vector<Point> PointList(Point3d* points, int count)
	{
		std::vector<Point> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();

		return list;
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto mesher = CastToTetrahedralRemeshing(ptr);

		for (int i = 0; i < count; i++)
		{
			points[i] = mesher->buffer[i];

			if (i >= mesher->buffer.size())
				break;
		}
		
		mesher->buffer.clear();
	}

	static int Remesh(void* ptr, double targetLength, int iterations, Point3d* points, int count)
	{
		auto mesher = CastToTetrahedralRemeshing(ptr);

		auto list = PointList(points, count);
		auto tr = Remeshing_triangulation(list.begin(), list.end());

		CGAL::tetrahedral_isotropic_remeshing(tr, targetLength, CGAL::parameters::number_of_iterations(iterations));

		mesher->buffer.clear();
		for (auto v = tr.vertices_begin(); v != tr.vertices_end(); ++v)
		{
			auto p = v->point();
			mesher->buffer.push_back(Point3d::FromCGAL<EIK>(p));
		}

		return (int)mesher->buffer.size();
	}

};
