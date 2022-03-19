#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>
#include <CGAL/Surface_mesh_simplification/edge_collapse.h>
#include <CGAL/Surface_mesh_simplification/Policies/Edge_collapse/Count_ratio_stop_predicate.h>

template<class K>
class SurfaceSimplification
{

public:

	typedef typename K::Point_3 Point;

	typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;

	typedef typename CGAL::Surface_mesh<Point> SurfaceMesh;

	inline static SurfaceSimplification* NewSimplification()
	{
		return new SurfaceSimplification();
	}

	inline static void DeleteSurfaceSimplification(void* ptr)
	{
		auto obj = static_cast<SurfaceSimplification*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static SurfaceSimplification* CastToSimplification(void* ptr)
	{
		return static_cast<SurfaceSimplification*>(ptr);
	}


	static void Simplify_PH(void* polyPtr, double stop_ratio)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		CGAL::Surface_mesh_simplification::Count_ratio_stop_predicate<Polyhedron> stop(stop_ratio);
		CGAL::Surface_mesh_simplification::edge_collapse(mesh->model, stop);
		mesh->OnModelChanged();
	}

	static void Simplify_SM(void* polyPtr, double stop_ratio)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(polyPtr);

		CGAL::Surface_mesh_simplification::Count_ratio_stop_predicate<SurfaceMesh> stop(stop_ratio);
		CGAL::Surface_mesh_simplification::edge_collapse(mesh->model, stop);
		mesh->OnModelChanged();
	}

};
