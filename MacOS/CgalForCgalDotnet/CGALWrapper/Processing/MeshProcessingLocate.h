#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Index.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"
#include "../Polyhedra/MeshHitResult.h"

#include <CGAL/Polygon_mesh_processing/locate.h>
#include <CGAL/Polygon_mesh_processing/triangulate_faces.h>
#include <CGAL/AABB_face_graph_triangle_primitive.h>
#include <CGAL/AABB_tree.h>
#include <CGAL/AABB_traits.h>
#include <CGAL/boost/graph/helpers.h>
#include <CGAL/Dynamic_property_map.h>

namespace CP = CGAL::parameters;
namespace PMP = CGAL::Polygon_mesh_processing;

template<class K>
class MeshProcessingLocate
{

public:

	typedef typename K::FT			FT;
	typedef typename K::Point_2     Point_2;
	typedef typename K::Ray_2       Ray_2;
	typedef typename K::Point_3     Point_3;
	typedef typename K::Ray_3       Ray_3;

	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::edge_descriptor PEdge_Des;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor PFace_Des;

	typedef typename CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Face_index SFace;
	typedef typename boost::graph_traits<SurfaceMesh>::edge_descriptor SEdge_Des;
	typedef typename boost::graph_traits<SurfaceMesh>::face_descriptor SFace_Des;

	typedef PMP::Barycentric_coordinates<FT>		Barycentric_coordinates;
	typedef PMP::Face_location<Polyhedron, FT>		PFace_location;
	typedef PMP::Face_location<SurfaceMesh, FT>		SFace_location;

	inline static MeshProcessingLocate* NewMeshProcessingLocate()
	{
		return new MeshProcessingLocate();
	}

	inline static void DeleteMeshProcessingLocate(void* ptr)
	{
		auto obj = static_cast<MeshProcessingLocate*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static MeshProcessingLocate* CastToMeshProcessingLocate(void* ptr)
	{
		return static_cast<MeshProcessingLocate*>(ptr);
	}

	static Point3d ToPoint3d(const Barycentric_coordinates& coord)
	{
		double x = CGAL::to_double(coord[0]);
		double y = CGAL::to_double(coord[1]);
		double z = CGAL::to_double(coord[2]);
		return { x, y, z };
	}

	//Polyhedron

	static Point3d RandomLocationOnMesh_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		auto location = PMP::random_location_on_mesh<FT>(mesh->model);
		//auto face = location.first;
		//auto coordinates = location.second;

		auto point = PMP::construct_point(location, mesh->model);

		return Point3d::FromCGAL<K>(point);
	}

	static MeshHitResult LocateFace_PH(void* ptr, const Ray3d& ray)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);
		mesh->BuildAABBTree();

		auto pos = ray.position.ToCGAL<K>();
		auto dir = ray.direction.ToCGAL<K>();
		Ray_3 r(pos, dir);

		auto location = PMP::locate_with_AABB_tree(r, *mesh->tree, mesh->model);
		auto face = location.first;
		auto coord = location.second;

		MeshHitResult result;
		result.face = mesh->FindFaceIndex(face);

		if (result.face != NULL_INDEX)
		{
			result.point = Point3d::FromCGAL(PMP::construct_point(location, mesh->model));
			result.coord = ToPoint3d(coord);
		}
		else
		{
			result.point = { 0,0,0 };
			result.coord = { 0,0,0 };
		}

		return result;
	}

	static MeshHitResult LocateFace_PH(void* ptr, const Point3d& point)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);
		mesh->BuildAABBTree();

		auto location = PMP::locate_with_AABB_tree(point.ToCGAL<K>(), *mesh->tree, mesh->model);
		auto face = location.first;
		auto coord = location.second;

		MeshHitResult result;
		result.face = mesh->FindFaceIndex(face);

		if (result.face != NULL_INDEX)
		{
			result.point = Point3d::FromCGAL(PMP::construct_point(location, mesh->model));
			result.coord = ToPoint3d(coord);
		}
		else
		{
			result.point = { 0,0,0 };
			result.coord = { 0,0,0 };
		}

		return result;
	}

	//SurfaceMesh

	static Point3d RandomLocationOnMesh_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		auto location = PMP::random_location_on_mesh<FT>(mesh->model);
		//auto face = location.first;
		//auto coordinates = location.second;

		auto point = PMP::construct_point(location, mesh->model);

		return Point3d::FromCGAL<K>(point);
	}

	static MeshHitResult LocateFace_SM(void* ptr, const Ray3d& ray)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);
		mesh->BuildAABBTree();

		auto pos = ray.position.ToCGAL<K>();
		auto dir = ray.direction.ToCGAL<K>();
		Ray_3 r(pos, dir);

		auto location = PMP::locate_with_AABB_tree(r, *mesh->tree, mesh->model);
		auto face = location.first;
		auto coord = location.second;

		MeshHitResult result;
		result.face = mesh->FindFaceIndex(face);

		if (result.face != NULL_INDEX)
		{
			result.point = Point3d::FromCGAL(PMP::construct_point(location, mesh->model));
			result.coord = ToPoint3d(coord);
		}
		else
		{
			result.point = { 0,0,0 };
			result.coord = { 0,0,0 };
		}

		return result;
	}

	static MeshHitResult LocateFace_SM(void* ptr, const Point3d& point)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);
		mesh->BuildAABBTree();

		auto location = PMP::locate_with_AABB_tree(point.ToCGAL<K>(), *mesh->tree, mesh->model);
		auto face = location.first;
		auto coord = location.second;

		MeshHitResult result;
		result.face = mesh->FindFaceIndex(face);

		if (result.face != NULL_INDEX)
		{
			result.point = Point3d::FromCGAL(PMP::construct_point(location, mesh->model));
			result.coord = ToPoint3d(coord);
		}
		else
		{
			result.point = { 0,0,0 };
			result.coord = { 0,0,0 };
		}

		return result;
	}

};
