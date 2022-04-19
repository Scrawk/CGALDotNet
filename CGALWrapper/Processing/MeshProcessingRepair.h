#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>
#include <CGAL/Polygon_mesh_processing/repair.h>
#include <CGAL/Polygon_mesh_processing/shape_predicates.h>
#include <CGAL/Polygon_mesh_processing/manifoldness.h>
#include <CGAL/Polygon_mesh_processing/repair_polygon_soup.h>
#include <CGAL/Polygon_mesh_processing/orient_polygon_soup.h>
#include <CGAL/Polygon_mesh_processing/polygon_soup_to_polygon_mesh.h>
#include <CGAL/Polygon_mesh_processing/polygon_mesh_to_polygon_soup.h>
#include <CGAL/Polygon_mesh_processing/stitch_borders.h>
#include <CGAL/Polygon_mesh_processing/merge_border_vertices.h>

namespace PMP = CGAL::Polygon_mesh_processing;
namespace NP = CGAL::parameters;

template<class K>
class MeshProcessingRepair
{

public:

	typedef typename K::FT FT;
	typedef typename K::Point_3 Point;

	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor PFace_Des;

	typedef typename CGAL::Surface_mesh<Point> SurfaceMesh;
	typedef typename boost::graph_traits<SurfaceMesh>::face_descriptor SFace_Des;

	typedef typename std::vector<std::size_t> PolygonIndex;


	inline static MeshProcessingRepair* NewMeshProcessingRepair()
	{
		return new MeshProcessingRepair();
	}

	inline static void DeleteMeshProcessingRepair(void* ptr)
	{
		auto obj = static_cast<MeshProcessingRepair*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static MeshProcessingRepair* CastToMeshProcessingRepair(void* ptr)
	{
		return static_cast<MeshProcessingRepair*>(ptr);
	}

	//Polyhedron

	static int DegenerateEdgeCount_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		//int count = 0;
		//for (auto edge = mesh->model.edges_begin(); edge != mesh->model.edges_end(); ++edge)
		//{
		//	if (PMP::is_degenerate_edge(edge, mesh->model))
		//		count++;
		//}

		return 0;
	}

	static int DegenerateTriangleCount_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		int count = 0;
		for (auto face = mesh->model.facets_begin(); face != mesh->model.facets_end(); ++face)
		{
			if (PMP::is_degenerate_triangle_face(face, mesh->model))
				count++;
		}

		return count;
	}

	static int NeedleTriangleCount_PH(void* ptr, double threshold)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		int count = 0;
		for (auto face = mesh->model.facets_begin(); face != mesh->model.facets_end(); ++face)
		{
			if (PMP::is_needle_triangle_face(face, mesh->model, threshold) != nullptr)
				count++;
		}

		return count;
	}

	static int NonManifoldVertexCount_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		int count = 0;
		for (auto vert = mesh->model.vertices_begin(); vert != mesh->model.vertices_end(); ++vert)
		{
			if (PMP::is_non_manifold_vertex(vert, mesh->model))
				count++;
		}

		return count;
	}

	static void RepairPolygonSoup_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		std::vector<Point> points;
		std::vector<PolygonIndex> polygons;

		PMP::polygon_mesh_to_polygon_soup(mesh->model, points, polygons);

		PMP::repair_polygon_soup(points, polygons);

		mesh->model.clear();
		mesh->OnModelChanged();
		PMP::polygon_soup_to_polygon_mesh(points, polygons, mesh->model);
	}

	static int StitchBoundaryCycles_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		mesh->OnModelChanged();
		return (int)PMP::stitch_boundary_cycles(mesh->model);
	}

	static int StitchBorders_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		mesh->OnModelChanged();
		return (int)PMP::stitch_borders(mesh->model);
	}

	static int MergeDuplicatedVerticesInBoundaryCycle_PH(void* ptr, int index)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);
		mesh->OnModelChanged();

		int before = (int)mesh->model.size_of_halfedges();

		auto hedge = mesh->FindHalfedgeIter(index);
		if(hedge != nullptr)
			PMP::merge_duplicated_vertices_in_boundary_cycle(*hedge, mesh->model);

		return before - (int)mesh->model.size_of_halfedges();
	}

	static int MergeDuplicatedVerticesInBoundaryCycles_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);
		mesh->OnModelChanged();

		int before = (int)mesh->model.size_of_halfedges();

		PMP::merge_duplicated_vertices_in_boundary_cycles(mesh->model);

		return before - (int)mesh->model.size_of_halfedges();
	}

	static int RemoveIsolatedVertices_PH(void* ptr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(ptr);

		mesh->OnModelChanged();
		return (int)PMP::remove_isolated_vertices(mesh->model);
	}

	//Surface Mesh

	static int DegenerateEdgeCount_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		int count = 0;
		for (const auto edge : mesh->model.edges())
		{
			if (PMP::is_degenerate_edge(edge, mesh->model))
				count++;
		}

		return count;
	}

	static int DegenerateTriangleCount_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		int count = 0;
		for (const auto& face : mesh->model.faces())
		{
			if (PMP::is_degenerate_triangle_face(face, mesh->model))
				count++;
		}

		return count;
	}

	static int NeedleTriangleCount_SM(void* ptr, double threshold)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		auto null_edge = SurfaceMesh3<K>::NullHalfedge();

		int count = 0;
		for (const auto& face : mesh->model.faces())
		{
			if (PMP::is_needle_triangle_face(face, mesh->model, threshold) != null_edge)
				count++;
		}

		return count;
	}

	static int NonManifoldVertexCount_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		int count = 0;
		for (const auto& vert : mesh->model.vertices())
		{
			if (PMP::is_non_manifold_vertex(vert, mesh->model))
				count++;
		}

		return count;
	}

	static void RepairPolygonSoup_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		std::vector<Point> points;
		std::vector<PolygonIndex> polygons;

		PMP::polygon_mesh_to_polygon_soup(mesh->model, points, polygons);

		PMP::repair_polygon_soup(points, polygons);

		mesh->model.clear();
		mesh->OnModelChanged();
		PMP::polygon_soup_to_polygon_mesh(points, polygons, mesh->model);
	}

	static int StitchBoundaryCycles_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		mesh->OnModelChanged();
		return (int)PMP::stitch_boundary_cycles(mesh->model);
	}

	static int StitchBorders_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		mesh->OnModelChanged();
		return (int)PMP::stitch_borders(mesh->model);
	}

	static int MergeDuplicatedVerticesInBoundaryCycle_SM(void* ptr, int index)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);
		mesh->OnModelChanged();

		int before = (int)mesh->model.number_of_halfedges();

		auto hedge = mesh->FindHalfedge(index);
		if (hedge != SurfaceMesh3<K>::NullHalfedge())
			PMP::merge_duplicated_vertices_in_boundary_cycle(hedge, mesh->model);

		return before - (int)mesh->model.number_of_halfedges();
	}

	static int MergeDuplicatedVerticesInBoundaryCycles_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);
		mesh->OnModelChanged();

		int before = (int)mesh->model.number_of_halfedges();

		PMP::merge_duplicated_vertices_in_boundary_cycles(mesh->model);

		return before - (int)mesh->model.number_of_halfedges();
	}

	static int RemoveIsolatedVertices_SM(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		mesh->OnModelChanged();
		return (int)PMP::remove_isolated_vertices(mesh->model);
	}

};
