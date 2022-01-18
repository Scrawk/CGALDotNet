#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polygon_mesh_processing/repair.h>
#include <CGAL/Polygon_mesh_processing/shape_predicates.h>
#include <CGAL/Polygon_mesh_processing/manifoldness.h>
#include <CGAL/Polygon_mesh_processing/repair_polygon_soup.h>
#include <CGAL/Polygon_mesh_processing/orient_polygon_soup.h>
#include <CGAL/Polygon_mesh_processing/polygon_soup_to_polygon_mesh.h>
#include <CGAL/Polygon_mesh_processing/polygon_mesh_to_polygon_soup.h>
#include <CGAL/Polygon_mesh_processing/stitch_borders.h>
#include <CGAL/Polygon_mesh_processing/merge_border_vertices.h>

template<class K>
class PolygonMeshProcessingRepair
{

public:

	typedef typename K::Point_3 Point;
	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
	typedef typename HalfedgeDS::Vertex Vertex;
	typedef typename HalfedgeDS::Face Face;
	typedef typename Polyhedron::Vertex_handle Vertex_Handle;
	typedef typename Polyhedron::Face_handle Face_Handle;
	typedef typename boost::graph_traits<Polyhedron>::vertex_descriptor	Vertex_Des;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor Face_Des;
	typedef typename  boost::graph_traits<Polyhedron>::edge_descriptor Edge_Des;

	typedef std::vector<std::size_t> PolygonIndex;

	inline static PolygonMeshProcessingRepair* NewPolygonMeshProcessingRepair()
	{
		return new PolygonMeshProcessingRepair();
	}

	inline static void DeletePolygonMeshProcessingRepair(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingRepair*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingRepair* CastToPolygonMeshProcessingRepair(void* ptr)
	{
		return static_cast<PolygonMeshProcessingRepair*>(ptr);
	}

	static int DegenerateHalfEdgeCount(void* ptr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		int count = 0;
		for (auto halfedge = poly->model.edges_begin(); halfedge != poly->model.edges_end(); ++halfedge)
		{
			//if (CGAL::Polygon_mesh_processing::is_degenerate_edge(halfedge, poly->model))
			//	count++;
		}

		return count;
	}

	static int DegenerateTriangleCount(void* ptr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		int count = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (CGAL::Polygon_mesh_processing::is_degenerate_triangle_face(face, poly->model))
				count++;
		}

		return count;
	}

	static int NeedleTriangleCount(void* ptr, double threshold)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		int count = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (CGAL::Polygon_mesh_processing::is_needle_triangle_face(face, poly->model, threshold) != nullptr)
				count++;
		}

		return count;
	}

	static int NonManifoldVertexCount(void* ptr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		int count = 0;
		for (auto vert = poly->model.vertices_begin(); vert != poly->model.vertices_end(); ++vert)
		{
			if (CGAL::Polygon_mesh_processing::is_non_manifold_vertex(vert, poly->model))
				count++;
		}

		return count;
	}

	static void RepairPolygonSoup(void* ptr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		std::vector<Point> points;
		std::vector<PolygonIndex> polygons;

		CGAL::Polygon_mesh_processing::polygon_mesh_to_polygon_soup(poly->model, points, polygons);

		CGAL::Polygon_mesh_processing::repair_polygon_soup(points, polygons);

		poly->model.clear();
		poly->OnModelChanged();
		CGAL::Polygon_mesh_processing::polygon_soup_to_polygon_mesh(points, polygons, poly->model);
	}

	static int StitchBoundaryCycles(void* ptr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		poly->OnModelChanged();
		return (int)CGAL::Polygon_mesh_processing::stitch_boundary_cycles(poly->model);
	}

	static int StitchBorders(void* ptr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		poly->OnModelChanged();
		return (int)CGAL::Polygon_mesh_processing::stitch_borders(poly->model);
	}

	static int MergeDuplicatedVerticesInBoundaryCycle(void* ptr)
	{
		return 0;
		//auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);
		//poly->OnModelChanged();
		//return CGAL::Polygon_mesh_processing::merge_duplicated_vertices_in_boundary_cycle(poly->model);
	}

	static int RemoveIsolatedVertices(void* ptr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		poly->OnModelChanged();
		return (int)CGAL::Polygon_mesh_processing::remove_isolated_vertices(poly->model);
	}

	static void PolygonMeshToPolygonSoup(void* ptr, int* triangles, int triangleCount, int* quads, int quadCount)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);

		std::vector<Point> points;
		std::vector<PolygonIndex> polygons;
		CGAL::Polygon_mesh_processing::polygon_mesh_to_polygon_soup(poly->model, points, polygons);

		int numTri = 0;
		int numQuad = 0;
		for (auto i = 0; i < polygons.size(); i++)
		{
			auto polygonIndex = polygons[i];
			int numVerts = (int)polygonIndex.size();

			if (numVerts == 3)
			{
				triangles[numTri * 3 + 0] = (int)polygonIndex[0];
				triangles[numTri * 3 + 1] = (int)polygonIndex[1];
				triangles[numTri * 3 + 2] = (int)polygonIndex[2];
				numTri++;
			}
			else if (numVerts == 4)
			{
				quads[numTri * 4 + 0] = (int)polygonIndex[0];
				quads[numTri * 4 + 1] = (int)polygonIndex[1];
				quads[numTri * 4 + 2] = (int)polygonIndex[2];
				quads[numTri * 4 + 3] = (int)polygonIndex[3];
				numQuad++;
			}

			if (numTri * 3 >= triangleCount) return;
			if (numQuad * 4 >= quadCount) return;
		}
	}

};
