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
class MeshProcessingBoolean
{

public:

	typedef typename K::Point_3 Point;
	typedef typename CGAL::Iso_cuboid_3<K> IsoCube3;
	typedef typename CGAL::Plane_3<K> Plane3;
	typedef typename std::vector<Point> Polyline;

	inline static MeshProcessingBoolean* NewMeshProcessingBoolean()
	{
		return new MeshProcessingBoolean();
	}

	inline static void DeleteMeshProcessingBoolean(void* ptr)
	{
		auto obj = static_cast<MeshProcessingBoolean*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static MeshProcessingBoolean* CastToMeshProcessingBoolean(void* ptr)
	{
		return static_cast<MeshProcessingBoolean*>(ptr);
	}

	//Polyhedron

	static BOOL Union_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
	{
		auto mesh1 = Polyhedron3<K>::CastToPolyhedron(meshPtr1);
		auto mesh2 = Polyhedron3<K>::CastToPolyhedron(meshPtr2);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_union(mesh1->model, mesh2->model, result->model))
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

	static BOOL Difference_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
	{
		auto mesh1 = Polyhedron3<K>::CastToPolyhedron(meshPtr1);
		auto mesh2 = Polyhedron3<K>::CastToPolyhedron(meshPtr2);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_difference(mesh1->model, mesh2->model, result->model))
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

	static BOOL Intersection_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
	{
		auto mesh1 = Polyhedron3<K>::CastToPolyhedron(meshPtr1);
		auto mesh2 = Polyhedron3<K>::CastToPolyhedron(meshPtr2);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_intersection(mesh1->model, mesh2->model, result->model))
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

	static BOOL Clip_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
	{
		return FALSE;

		/*
		auto mesh1 = Polyhedron3<K>::CastToPolyhedron(meshPtr1);
		auto mesh2 = Polyhedron3<K>::CastToPolyhedron(meshPtr2);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::clip(mesh1->model, mesh2->model, result->model))
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

	static BOOL PlaneClip_PH(void* meshPtr1, Plane3d plane, void** resultPtr)
	{
		return FALSE;
		/*
		auto mesh1 = Polyhedron3<K>::CastToPolyhedron(meshPtr1);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::clip(mesh1->model, plane.ToCGAL<K, Plane3>(), result->model))
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

	static BOOL BoxClip_PH(void* meshPtr1, Box3d box, void** resultPtr)
	{
		return FALSE;
		/*
		auto mesh1 = Polyhedron3<K>::CastToPolyhedron(meshPtr1);
		auto result = Polyhedron3<K>::NewPolyhedron();

		if (CGAL::Polygon_mesh_processing::clip(mesh1->model, box.ToCGAL<K, IsoCube3>(), result->model))
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

	static BOOL SurfaceIntersection_PH(void* meshPtr1, void* meshPtr2)
	{
		return FALSE;
		/*
		auto mesh1 = Polyhedron3<K>::CastToPolyhedron(meshPtr1);
		auto mesh2 = Polyhedron3<K>::CastToPolyhedron(meshPtr2);

		std::vector<Polyline> lines;

		if (CGAL::Polygon_mesh_processing::surface_intersection(mesh1->model, mesh2->model, std::back_inserter(lines)))
		{
			return TRUE;
		}
		else
		{
			return FALSE;
		}
		*/
	}

	//Surface Mesh

	static BOOL Union_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
	{
		auto mesh1 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr1);
		auto mesh2 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr2);
		auto result = SurfaceMesh3<K>::NewSurfaceMesh();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_union(mesh1->model, mesh2->model, result->model))
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

	static BOOL Difference_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
	{
		auto mesh1 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr1);
		auto mesh2 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr2);
		auto result = SurfaceMesh3<K>::NewSurfaceMesh();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_difference(mesh1->model, mesh2->model, result->model))
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

	static BOOL Intersection_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
	{
		auto mesh1 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr1);
		auto mesh2 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr2);
		auto result = SurfaceMesh3<K>::NewSurfaceMesh();

		if (CGAL::Polygon_mesh_processing::corefine_and_compute_intersection(mesh1->model, mesh2->model, result->model))
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

	static BOOL Clip_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
	{
		return FALSE;
		/*
		auto mesh1 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr1);
		auto mesh2 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr2);
		auto result = SurfaceMesh3<K>::NewSurfaceMesh();

		if (CGAL::Polygon_mesh_processing::clip(mesh1->model, mesh2->model, result->model))
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

	static BOOL PlaneClip_SM(void* meshPtr1, Plane3d plane, void** resultPtr)
	{
		return FALSE;
		/*
		auto mesh1 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr1);
		auto result = SurfaceMesh3<K>::NewSurfaceMesh();

		if (CGAL::Polygon_mesh_processing::clip(mesh1->model, plane.ToCGAL<K, Plane3>(), result->model))
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

	static BOOL BoxClip_SM(void* meshPtr1, Box3d box, void** resultPtr)
	{
		return FALSE;
		/*
		auto mesh1 = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr1);
		auto result = SurfaceMesh3<K>::NewSurfaceMesh();

		if (CGAL::Polygon_mesh_processing::clip(mesh1->model, box.ToCGAL<K, IsoCube3>(), result->model))
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

	static BOOL SurfaceIntersection_SM(void* meshPtr1, void* meshPtr2)
	{
		return FALSE;
		/*
		auto mesh1 = Polyhedron3<K>::CastToPolyhedron(meshPtr1);
		auto mesh2 = Polyhedron3<K>::CastToPolyhedron(meshPtr2);

		std::vector<Polyline> lines;

		if (CGAL::Polygon_mesh_processing::surface_intersection(mesh1->model, mesh2->model, std::back_inserter(lines)))
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
