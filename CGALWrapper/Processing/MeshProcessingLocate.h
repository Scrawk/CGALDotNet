#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Index.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

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

	typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;
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

	static Point3d RandomLocationOnMesh_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		auto random_location = PMP::random_location_on_mesh<FT>(mesh->model);
		//auto face = random_location.first;
		//auto coordinates = random_location.second;

		auto point = PMP::construct_point(random_location, mesh->model);

		return Point3d::FromCGAL<K>(point);
	}

	static BOOL RandomLocationOnFace_PH(void* ptr, int index, Point3d& point)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		auto face = mesh->FindFaceDes(index);
		if (face != nullptr)
		{
			//auto random_location = CGAL::Polygon_mesh_processing::random_location_on_face(*face, mesh->model);
			//auto face = random_location.first;
			//auto coordinates = random_location.second;

			//auto p = PMP::construct_point(random_location, mesh->model);
			//point = Point3d::FromCGAL<K>(p);

			return TRUE;
		}
		else
		{
			point = { 0,0,0 };
			return FALSE;
		}
		
	}
	
	int main()
	{
		// Generate a simple 3D triangle mesh that with vertices on the plane xOy
		//Mesh tm;
		//CGAL::make_grid(10, 10, tm);
		//PMP::triangulate_faces(tm);

		/*
		// Basic usage
		Face_location random_location = PMP::random_location_on_mesh<FT>(tm);
		const face_descriptor f = random_location.first;
		const Barycentric_coordinates& coordinates = random_location.second;

		std::cout << "Random location on the mesh: face " << f
			<< " and with coordinates [" << coordinates[0] << "; "
			<< coordinates[1] << "; "
			<< coordinates[2] << "]\n";
		std::cout << "It corresponds to point (" << PMP::construct_point(random_location, tm) << ")\n\n";
		*/

		/*
		// Locate a known 3D point in the mesh
		const Point_3 query(1.2, 7.4, 0);
		Face_location query_location = PMP::locate(query, tm);
		std::cout << "Point (" << query << ") is located in face " << query_location.first
			<< " with barycentric coordinates [" << query_location.second[0] << "; "
			<< query_location.second[1] << "; "
			<< query_location.second[2] << "]\n\n";
			*/

		/*
		// Locate a 3D point in the mesh as the intersection of the mesh and a 3D ray.
		// The AABB tree can be cached in case many queries are performed (otherwise, it is rebuilt
		// on each call, which is expensive).
		typedef CGAL::AABB_face_graph_triangle_primitive<Mesh>                AABB_face_graph_primitive;
		typedef CGAL::AABB_traits<K, AABB_face_graph_primitive>               AABB_face_graph_traits;
		CGAL::AABB_tree<AABB_face_graph_traits> tree;
		PMP::build_AABB_tree(tm, tree);
		const Ray_3 ray_3(Point_3(4.2, 6.8, 2.4), Point_3(7.2, 2.3, -5.8));

		Face_location ray_location = PMP::locate_with_AABB_tree(ray_3, tree, tm);
		std::cout << "Intersection of the 3D ray and the mesh is in face " << ray_location.first
			<< " with barycentric coordinates [" << ray_location.second[0] << " "
			<< ray_location.second[1] << " "
			<< ray_location.second[2] << "]\n";
		std::cout << "It corresponds to point (" << PMP::construct_point(ray_location, tm) << ")\n";
		std::cout << "Is it on the face's border? " << (PMP::is_on_face_border(ray_location, tm) ? "Yes" : "No") << "\n\n";
		*/

		/*
		// -----------------------------------------------------------------------------------------------
		// Now, we artifically project the mesh to the natural 2D dimensional plane, with a little translation
		// via a custom vertex point property map
		typedef CGAL::dynamic_vertex_property_t<Point_2>                      Point_2_property;
		typedef typename boost::property_map<Mesh, Point_2_property>::type    Projection_pmap;
		Projection_pmap projection_pmap = get(Point_2_property(), tm);
		for (vertex_descriptor v : vertices(tm))
		{
			const Point_3& p = tm.point(v);
			put(projection_pmap, v, Point_2(p.x() + 1, p.y())); // simply ignoring the z==0 coordinate and translating along Ox
		}
		// Locate the same 3D point but in a 2D context
		const Point_2 query_2(query.x() + 1, query.y());
		Face_location query_location_2 = PMP::locate(query_2, tm, CP::vertex_point_map(projection_pmap));

		std::cout << "Point (" << query_2 << ") is located in face " << query_location_2.first
			<< " with barycentric coordinates [" << query_location_2.second[0] << "; "
			<< query_location_2.second[1] << "; "
			<< query_location_2.second[2] << "]\n\n";
			*/
		/*
		// Shoot a 2D ray and locate the intersection with the mesh in 2D
		const Ray_2 ray_2(Point_2(-10, -10), Point_2(10, 10));
		Face_location ray_location_2 = PMP::locate(ray_2, tm, CP::vertex_point_map(projection_pmap)); // This rebuilds an AABB tree on each call
		std::cout << "Intersection of the 2D ray and the mesh is in face " << ray_location_2.first
			<< " with barycentric coordinates [" << ray_location_2.second[0] << "; "
			<< ray_location_2.second[1] << "; "
			<< ray_location_2.second[2] << "]\n";
		std::cout << "It corresponds to point (" << PMP::construct_point(ray_location_2, tm, CP::vertex_point_map(projection_pmap)) << ")\n";

		if (PMP::is_on_mesh_border(ray_location_2, tm))
			std::cout << "It is on the border of the mesh!\n" << std::endl;
		*/
		return EXIT_SUCCESS;
	}
	

};
