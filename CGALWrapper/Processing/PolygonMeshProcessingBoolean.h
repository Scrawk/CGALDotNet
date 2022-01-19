#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <vector>
#include <CGAL/Plane_3.h>
#include <CGAL/Iso_cuboid_3.h>
#include <CGAL/Polygon_mesh_processing/corefinement.h>
#include <CGAL/Polygon_mesh_processing/clip.h>
#include <CGAL/Polygon_mesh_processing/intersection.h>

template<class K>
class PolygonMeshProcessingBoolean
{

public:

	typedef typename K::Point_3 Point;
	typedef typename CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename CGAL::Iso_cuboid_3<K> IsoCube3;
	typedef typename CGAL::Plane_3<K> Plane3;
	typedef typename std::vector<Point> Polyline;

	inline static PolygonMeshProcessingBoolean* NewPolygonMeshProcessingBoolean()
	{
		return new PolygonMeshProcessingBoolean();
	}

	inline static void DeletePolygonMeshProcessingBoolean(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingBoolean*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingBoolean* CastToPolygonMeshProcessingBoolean(void* ptr)
	{
		return static_cast<PolygonMeshProcessingBoolean*>(ptr);
	}

	static BOOL PolyhedronUnion(void* polyPtr1, void* polyPtr2, void** resultPtr)
	{
		auto poly1 = Polyhedron3<K>::CastToPolyhedron(polyPtr1);
		auto poly2 = Polyhedron3<K>::CastToPolyhedron(polyPtr2);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_union(poly1->model, poly2->model, result->model))
		{
			*resultPtr = result;
			return TRUE;
		}
		else
		{
			delete result;
			return FALSE;
		}
	}

	static BOOL PolyhedronDifference(void* polyPtr1, void* polyPtr2, void** resultPtr)
	{
		auto poly1 = Polyhedron3<K>::CastToPolyhedron(polyPtr1);
		auto poly2 = Polyhedron3<K>::CastToPolyhedron(polyPtr2);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_difference(poly1->model, poly2->model, result->model))
		{
			*resultPtr = result;
			return TRUE;
		}
		else
		{
			delete result;
			return FALSE;
		}
	}

	static BOOL PolyhedronIntersection(void* polyPtr1, void* polyPtr2, void** resultPtr)
	{
		auto poly1 = Polyhedron3<K>::CastToPolyhedron(polyPtr1);
		auto poly2 = Polyhedron3<K>::CastToPolyhedron(polyPtr2);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_intersection(poly1->model, poly2->model, result->model))
		{
			*resultPtr = result;
			return TRUE;
		}
		else
		{
			delete result;
			return FALSE;
		}
	}

	static BOOL PolyhedronClip(void* polyPtr1, void* polyPtr2, void** resultPtr)
	{
		return FALSE;
		/*
		auto poly1 = Polyhedron3<K>::CastToPolyhedron(polyPtr1);
		auto poly2 = Polyhedron3<K>::CastToPolyhedron(polyPtr2);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::clip(poly1->model, poly2->model, result->model))
		{
			*resultPtr = result;
			return TRUE;
		}
		else
		{
			delete result;
			return FALSE;
		}
		*/
	}

	static BOOL PlaneClip(void* polyPtr1, Plane3d plane, void** resultPtr)
	{
		return FALSE;
		/*
		auto poly1 = Polyhedron3<K>::CastToPolyhedron(polyPtr1);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::clip(poly1->model, plane.ToCGAL<K, Plane3>(), result->model))
		{
			*resultPtr = result;
			return TRUE;
		}
		else
		{
			delete result;
			return FALSE;
		}
		*/
	}

	static BOOL BoxClip(void* polyPtr1, Box3d box, void** resultPtr)
	{
		return FALSE;
		/*
		auto poly1 = Polyhedron3<K>::CastToPolyhedron(polyPtr1);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::clip(poly1->model, box.ToCGAL<K, IsoCube3>(), result->model))
		{
			*resultPtr = result;
			return true;
		}
		else
		{
			delete result;
			return FALSE;
		}
		*/
	}

	static BOOL PolyhedronSurfaceIntersection(void* polyPtr1, void* polyPtr2)
	{
		return FALSE;
		/*
		auto poly1 = Polyhedron3<K>::CastToPolyhedron(polyPtr1);
		auto poly2 = Polyhedron3<K>::CastToPolyhedron(polyPtr2);

		std::vector<Polyline> lines;

		if (CGAL::Polygon_mesh_processing::surface_intersection(poly1->model, poly2->model, std::back_inserter(lines)))
		{
			return TRUE;
		}
		else
		{
			return FALSE;
		}
		*/
	}


};
