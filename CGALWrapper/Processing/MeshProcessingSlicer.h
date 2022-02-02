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

	typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;

	typedef typename K::FT FT;
	typedef typename K::Point_3 Point;
	typedef typename K::Vector_3 Vector;
	typedef typename K::Plane_3 Plane;
	typedef typename std::vector<Point> PointList;
	typedef typename std::vector<PointList> PolylineList;

	typedef CGAL::AABB_halfedge_graph_segment_primitive<Polyhedron> HGSP;
	typedef CGAL::AABB_traits<K, HGSP> AABB_traits;
	typedef CGAL::AABB_tree<AABB_traits> AABB_tree;

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

	static int Polyhedron_Slice(void* slicerPtr, void* polyPtr, const Plane3d& plane, BOOL useTree)
	{
		auto scr = CastToMeshProcessingSlicer(slicerPtr);
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		scr->lines.clear();

		if (useTree)
		{
			AABB_tree tree(edges(poly->model).first, edges(poly->model).second, poly->model);
			CGAL::Polygon_mesh_slicer<Polyhedron, K> slicer_aabb(poly->model, tree);
			slicer_aabb(plane.ToCGAL<K, Plane>(), std::back_inserter(scr->lines));
		}
		else
		{
			CGAL::Polygon_mesh_slicer<Polyhedron, K> slicer(poly->model);
			slicer(plane.ToCGAL<K, Plane>(), std::back_inserter(scr->lines));
		}

		return (int)scr->lines.size();
	}

	static int Polyhedron_Slice(void* slicerPtr, void* polyPtr, const Point3d& start, const Point3d& end, double increment)
	{
		if (increment <= 0)
			return 0;

		auto scr = CastToMeshProcessingSlicer(slicerPtr);
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		scr->lines.clear();

		auto s = start.ToCGAL<K>();
		auto e = end.ToCGAL<K>();

		auto sq = CGAL::squared_distance(s, e);
		if (sq == FT(0)) return 0;

		auto len = CGAL::approximate_sqrt(sq);
		auto inc = FT(increment);

		auto dir = (e - s) / len;
		auto current = FT(0);

		AABB_tree tree(edges(poly->model).first, edges(poly->model).second, poly->model);
		CGAL::Polygon_mesh_slicer<Polyhedron, K> slicer_aabb(poly->model, tree);

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
