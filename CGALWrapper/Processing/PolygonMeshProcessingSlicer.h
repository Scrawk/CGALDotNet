#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"
#include "../Polylines/Polyline3.h"

#include <vector>
#include <list>
#include <CGAL/Polygon_mesh_slicer.h>
#include <CGAL/AABB_halfedge_graph_segment_primitive.h>
#include <CGAL/AABB_tree.h>
#include <CGAL/AABB_traits.h>

template<class K>
class PolygonMeshProcessingSlicer
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;

	typedef typename K::Point_3 Point;
	typedef typename K::Plane_3 Plane;
	typedef typename std::vector<Point> PointList;
	typedef typename std::vector<PointList> PolylineList;

	typedef CGAL::AABB_halfedge_graph_segment_primitive<Polyhedron> HGSP;
	typedef CGAL::AABB_traits<K, HGSP> AABB_traits;
	typedef CGAL::AABB_tree<AABB_traits> AABB_tree;

private:

	PolylineList lines;

public:

	inline static PolygonMeshProcessingSlicer* NewPolygonMeshProcessingSlicer()
	{
		return new PolygonMeshProcessingSlicer();
	}

	inline static void DeletePolygonMeshProcessingSlicer(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingSlicer*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingSlicer* CastToPolygonMeshProcessingSlicer(void* ptr)
	{
		return static_cast<PolygonMeshProcessingSlicer*>(ptr);
	}

	static void GetLines(void* slicerPtr, void** lines, int count)
	{
		auto slicer = CastToPolygonMeshProcessingSlicer(slicerPtr);

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
		auto scr = CastToPolygonMeshProcessingSlicer(slicerPtr);
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

};
