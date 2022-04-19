#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"
#include "../Polylines/Polyline3.h"

#include <vector>
#include <list>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>
#include <CGAL/Polygon_mesh_slicer.h>
#include <CGAL/AABB_halfedge_graph_segment_primitive.h>
#include <CGAL/AABB_tree.h>
#include <CGAL/AABB_traits.h>

template<class K>
class MeshProcessingSlicer
{

public:

	typedef typename K::FT FT;
	typedef typename K::Point_3 Point;
	typedef typename K::Vector_3 Vector;
	typedef typename K::Plane_3 Plane;
	typedef typename std::vector<Point> PointList;
	typedef typename std::vector<PointList> PolylineList;

	typedef CGAL::Polyhedron_3<K> Polyhedron;

	typedef CGAL::AABB_halfedge_graph_segment_primitive<Polyhedron> PHGSP;
	typedef CGAL::AABB_traits<K, PHGSP> PAABB_traits;
	typedef CGAL::AABB_tree<PAABB_traits> PAABB_tree;

	typedef typename CGAL::Surface_mesh<Point> SurfaceMesh;

	typedef CGAL::AABB_halfedge_graph_segment_primitive<SurfaceMesh> SHGSP;
	typedef CGAL::AABB_traits<K, SHGSP> SAABB_traits;
	typedef CGAL::AABB_tree<SAABB_traits> SAABB_tree;

private:

	PolylineList lines;

public:

	inline static MeshProcessingSlicer* NewMeshProcessingSlicer()
	{
		return new MeshProcessingSlicer();
	}

	inline static void DeleteMeshProcessingSlicer(void* ptr)
	{
		auto obj = static_cast<MeshProcessingSlicer*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static MeshProcessingSlicer* CastToMeshProcessingSlicer(void* ptr)
	{
		return static_cast<MeshProcessingSlicer*>(ptr);
	}

	static void GetLines(void* slicerPtr, void** lines, int count)
	{
		auto slicer = CastToMeshProcessingSlicer(slicerPtr);

		auto size = slicer->lines.size();
		if (size == 0) return;

		for (int i = 0; i < count; i++)
		{
			lines[i] = Polyline3<K>::NewPolyline3(slicer->lines[i]);
		
			if (i >= size) break;
		}

		slicer->lines.clear();
	}

	//Polyhedron

	static int Polyhedron_Slice_PH(void* slicerPtr, void* meshPtr, const Plane3d& plane, BOOL useTree)
	{
		auto scr = CastToMeshProcessingSlicer(slicerPtr);
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		scr->lines.clear();

		if (useTree)
		{
			PAABB_tree tree(edges(mesh->model).first, edges(mesh->model).second, mesh->model);
			CGAL::Polygon_mesh_slicer<Polyhedron, K> slicer_aabb(mesh->model, tree);
			slicer_aabb(plane.ToCGAL<K, Plane>(), std::back_inserter(scr->lines));
		}
		else
		{
			CGAL::Polygon_mesh_slicer<Polyhedron, K> slicer(mesh->model);
			slicer(plane.ToCGAL<K, Plane>(), std::back_inserter(scr->lines));
		}

		return (int)scr->lines.size();
	}

	static int Polyhedron_Slice_PH(void* slicerPtr, void* meshPtr, const Point3d& start, const Point3d& end, double increment)
	{
		if (increment <= 0)
			return 0;

		auto scr = CastToMeshProcessingSlicer(slicerPtr);
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		scr->lines.clear();

		auto s = start.ToCGAL<K>();
		auto e = end.ToCGAL<K>();

		auto sq = CGAL::squared_distance(s, e);
		if (sq == FT(0)) return 0;

		auto len = CGAL::approximate_sqrt(sq);
		auto inc = FT(increment);

		auto dir = (e - s) / len;
		auto current = FT(0);

		PAABB_tree tree(edges(mesh->model).first, edges(mesh->model).second, mesh->model);
		CGAL::Polygon_mesh_slicer<Polyhedron, K> slicer_aabb(mesh->model, tree);

		while (current < len)
		{
			Point p = s + dir * current;
			auto plane = Plane(p, dir);

			slicer_aabb(plane, std::back_inserter(scr->lines));

			current += inc;
		}

		return (int)scr->lines.size();
	}

	//SurfaceMesh

	static int Polyhedron_Slice_SM(void* slicerPtr, void* meshPtr, const Plane3d& plane, BOOL useTree)
	{
		auto scr = CastToMeshProcessingSlicer(slicerPtr);
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		scr->lines.clear();

		if (useTree)
		{
			SAABB_tree tree(edges(mesh->model).first, edges(mesh->model).second, mesh->model);
			CGAL::Polygon_mesh_slicer<SurfaceMesh, K> slicer_aabb(mesh->model, tree);
			slicer_aabb(plane.ToCGAL<K, Plane>(), std::back_inserter(scr->lines));
		}
		else
		{
			CGAL::Polygon_mesh_slicer<SurfaceMesh, K> slicer(mesh->model);
			slicer(plane.ToCGAL<K, Plane>(), std::back_inserter(scr->lines));
		}

		return (int)scr->lines.size();
	}

	static int Polyhedron_Slice_SM(void* slicerPtr, void* meshPtr, const Point3d& start, const Point3d& end, double increment)
	{
		if (increment <= 0)
			return 0;

		auto scr = CastToMeshProcessingSlicer(slicerPtr);
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		scr->lines.clear();

		auto s = start.ToCGAL<K>();
		auto e = end.ToCGAL<K>();

		auto sq = CGAL::squared_distance(s, e);
		if (sq == FT(0)) return 0;

		auto len = CGAL::approximate_sqrt(sq);
		auto inc = FT(increment);

		auto dir = (e - s) / len;
		auto current = FT(0);

		SAABB_tree tree(edges(mesh->model).first, edges(mesh->model).second, mesh->model);
		CGAL::Polygon_mesh_slicer<SurfaceMesh, K> slicer_aabb(mesh->model, tree);

		while (current < len)
		{
			Point p = s + dir * current;
			auto plane = Plane(p, dir);

			slicer_aabb(plane, std::back_inserter(scr->lines));

			current += inc;
		}

		return (int)scr->lines.size();
	}

};
