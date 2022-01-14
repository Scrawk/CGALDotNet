#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "PrimativeCount.h"
 
#include <map>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_incremental_builder_3.h>
#include <CGAL/Polygon_mesh_processing/transform.h>
#include <CGAL/Aff_transformation_3.h>

#include <CGAL/Polygon_mesh_processing/triangulate_faces.h>


template <class HDS, class K>
class BuildTriangleMesh : public CGAL::Modifier_base<HDS> 
{
public:

	Point3d* vertices;

	int verticesCount;

	int* triangles;

	int triangleCount;

	void operator()(HDS& hds)
	{
		typedef typename HDS::Vertex   Vertex;
		typedef typename Vertex::Point Point;

		CGAL::Polyhedron_incremental_builder_3<HDS> B(hds);

		int numTriangles = triangleCount / 3;
		int edges = numTriangles * 6;

		B.begin_surface(verticesCount, numTriangles, edges, B.ABSOLUTE_INDEXING);

		for (int i = 0; i < verticesCount; i++)
		{
			auto p = vertices[i].ToCGAL<K>();
			B.add_vertex(p);
		}

		for (int i = 0; i < numTriangles; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(triangles[i * 3 + 0]);
			B.add_vertex_to_facet(triangles[i * 3 + 1]);
			B.add_vertex_to_facet(triangles[i * 3 + 2]);
			B.end_facet();
		}

		B.end_surface();
	}
};

template <class HDS, class K>
class BuildQuadMesh : public CGAL::Modifier_base<HDS>
{
public:

	Point3d* vertices;

	int verticesCount;

	int* quads;

	int quadCount;

	void operator()(HDS& hds)
	{
		typedef typename HDS::Vertex   Vertex;
		typedef typename Vertex::Point Point;

		CGAL::Polyhedron_incremental_builder_3<HDS> B(hds);

		int numQuads = quadCount / 4;
		int edges = numQuads * 8;

		B.begin_surface(verticesCount, numQuads, edges, B.ABSOLUTE_INDEXING);

		for (int i = 0; i < verticesCount; i++)
		{
			auto p = vertices[i].ToCGAL<K>();
			B.add_vertex(p);
		}

		for (int i = 0; i < numQuads; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(quads[i * 4 + 0]);
			B.add_vertex_to_facet(quads[i * 4 + 1]);
			B.add_vertex_to_facet(quads[i * 4 + 2]);
			B.add_vertex_to_facet(quads[i * 4 + 3]);
			B.end_facet();
		}

		B.end_surface();
	}
};

template <class HDS, class K>
class BuildTriangleQuadMesh : public CGAL::Modifier_base<HDS>
{
public:

	Point3d* vertices;

	int verticesCount;

	int* triangles;

	int triangleCount;

	int* quads;

	int quadCount;

	void operator()(HDS& hds)
	{
		typedef typename HDS::Vertex   Vertex;
		typedef typename Vertex::Point Point;

		CGAL::Polyhedron_incremental_builder_3<HDS> B(hds);

		int numTriangles = triangleCount / 3;
		int numQuads = quadCount / 4;
		int edges = numTriangles * 6 + numQuads * 8;

		B.begin_surface(verticesCount, 0, 0, B.ABSOLUTE_INDEXING);

		for (int i = 0; i < verticesCount; i++)
		{
			auto p = vertices[i].ToCGAL<K>();
			B.add_vertex(p);
		}

		for (int i = 0; i < numTriangles; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(triangles[i * 3 + 0]);
			B.add_vertex_to_facet(triangles[i * 3 + 1]);
			B.add_vertex_to_facet(triangles[i * 3 + 2]);
			B.end_facet();
		}

		for (int i = 0; i < numQuads; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(quads[i * 4 + 0]);
			B.add_vertex_to_facet(quads[i * 4 + 1]);
			B.add_vertex_to_facet(quads[i * 4 + 2]);
			B.add_vertex_to_facet(quads[i * 4 + 3]);
			B.end_facet();
		}

		B.end_surface();
	}
};

template<class K>
class Polyhedron3
{

public:

	typedef typename K::Point_3 Point;
	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
	typedef typename HalfedgeDS::Vertex Vertex;
	typedef typename HalfedgeDS::Face Face;
	typedef CGAL::Aff_transformation_3<K> Transformation_3;

	Polyhedron3() {}

	inline static Polyhedron* NewPolyhedron()
	{
		return new Polyhedron();
	}

	inline static Polyhedron* NewPolyhedron(int vertices, int halfedges, int faces)
	{
		return new Polyhedron((size_t)vertices, (size_t)halfedges, (size_t)faces);
	}

	inline static void DeletePolyhedron(void* ptr)
	{
		auto obj = static_cast<Polyhedron*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static Polyhedron* CastToPolyhedron(void* ptr)
	{
		return static_cast<Polyhedron*>(ptr);
	}

	static void Clear(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->clear();
	}

	static int VertexCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->size_of_vertices();
	}

	static int FaceCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->size_of_facets();
	}

	static int HalfEdgeCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->size_of_halfedges();
	}

	static int BorderEdgeCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->size_of_border_edges();
	}

	static int BorderHalfEdgeCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->size_of_border_halfedges();
	}

	static BOOL IsValid(void* ptr, int level)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->is_valid(level);
	}

	static BOOL IsClosed(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->is_closed();
	}

	static BOOL IsPureBivalent(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->is_pure_bivalent();
	}

	static BOOL IsPureTrivalent(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->is_pure_trivalent();
	}

	static int IsPureTriangle(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		//return (int)poly->is_pure_triangle();

		//for (auto vert = poly->vertices_begin(); vert != poly->vertices_end(); ++vert)
		//{
		//	if (vert->halfedge() == nullptr) return 1;
		//	if (vert->halfedge()->face() == nullptr) return 2;
		//}

		for (auto face = poly->facets_begin(); face != poly->facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) return 3;
			//if (face->halfedge()->vertex() == nullptr) return 4;
			//if (face->halfedge()->next() == nullptr) return 5;
			//if (face->halfedge()->prev() == nullptr) return 6;
			if (!face->is_triangle()) return 7;
		}
			
		return 0;
	}

	static int IsPureQuad(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		//return (int)poly->is_pure_quad();

		//for (auto vert = poly->vertices_begin(); vert != poly->vertices_end(); ++vert)
		//{
		//	if (vert->halfedge() == nullptr) return 1;
		//	if (vert->halfedge()->face() == nullptr) return 2;
		//}

		for (auto face = poly->facets_begin(); face != poly->facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) return 3;
			//if (face->halfedge()->vertex() == nullptr) return 4;
			//if (face->halfedge()->next() == nullptr) return 5;
			//if (face->halfedge()->prev() == nullptr) return 6;
			if (!face->is_quad()) return 7;
		}

		return 0;
	}

	static void MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->make_tetrahedron(p1.ToCGAL<K>(), p2.ToCGAL<K>(), p3.ToCGAL<K>(), p4.ToCGAL<K>());
	}

	static void MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->make_triangle(p1.ToCGAL<K>(), p2.ToCGAL<K>(), p3.ToCGAL<K>());
	}

	static void CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount)
	{
		auto poly = CastToPolyhedron(ptr);

		BuildTriangleMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.triangles = triangles;
		builder.triangleCount = triangleCount;

		poly->delegate(builder);
	}

	static void CreateQuadMesh(void* ptr, Point3d* points, int pointsCount, int* quads, int quadCount)
	{
		auto poly = CastToPolyhedron(ptr);

		BuildQuadMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.quads = quads;
		builder.quadCount = quadCount;

		poly->delegate(builder);
	}

	static void CreateTriangleQuadMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount, int* quads, int quadCount)
	{
		auto poly = CastToPolyhedron(ptr);

		BuildTriangleQuadMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.triangles = triangles;
		builder.triangleCount = triangleCount;
		builder.quads = quads;
		builder.quadCount = quadCount;

		poly->delegate(builder);
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		int i = 0;

		for (auto point = poly->points_begin(); point != poly->points_end(); ++point)
		{
			points[i++] = Point3d::FromCGAL<K>(*point);

			if (i >= count) return;
		}
	}

	static PrimativeCount GetPrimativeCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);

		int triangleCount = 0;
		int quadCount = 0;
		int polygonCount = 0;

		for (auto face = poly->facets_begin(); face != poly->facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;

			if (face->is_triangle())
				triangleCount++;
			else if (face->is_quad())
				quadCount++;
			else
				polygonCount++;
		}

		return { triangleCount, quadCount, polygonCount };
	}

	static void GetTriangleIndices(void* ptr, int* indices, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		int index = 0;

		std::map<Point, int> map;

		for (auto point = poly->points_begin(); point != poly->points_end(); ++point)
		{
			map.insert(std::pair<Point, int>(*point, index++));
		}

		index = 0;
		for (auto face = poly->facets_begin(); face != poly->facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;
			if (!face->is_triangle()) continue;
			
			auto i0 = map.find(face->halfedge()->prev()->vertex()->point());
			auto i1 = map.find(face->halfedge()->vertex()->point());
			auto i2 = map.find(face->halfedge()->next()->vertex()->point());

			if (i0 == map.end() || i1 == map.end() || i2 == map.end())
			{
				indices[index * 3 + 0] = NULL_INDEX;
				indices[index * 3 + 1] = NULL_INDEX;
				indices[index * 3 + 2] = NULL_INDEX;
			}
			else
			{
				indices[index * 3 + 0] = i0->second;
				indices[index * 3 + 1] = i1->second;
				indices[index * 3 + 2] = i2->second;
			}

			index++;

			if (index * 3 >= count) return;
		}
	}

	static void GetQuadIndices(void* ptr, int* indices, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		int index = 0;

		std::map<Point, int> map;

		for (auto point = poly->points_begin(); point != poly->points_end(); ++point)
		{
			map.insert(std::pair<Point, int>(*point, index++));
		}

		index = 0;
		for (auto face = poly->facets_begin(); face != poly->facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;
			if (!face->is_quad()) continue;

			auto i0 = map.find(face->halfedge()->prev()->vertex()->point());
			auto i1 = map.find(face->halfedge()->vertex()->point());
			auto i2 = map.find(face->halfedge()->next()->vertex()->point());
			auto i3 = map.find(face->halfedge()->next()->next()->vertex()->point());

			if (i0 == map.end() || i1 == map.end() || i2 == map.end() || i3 == map.end())
			{
				indices[index * 4 + 0] = NULL_INDEX;
				indices[index * 4 + 1] = NULL_INDEX;
				indices[index * 4 + 2] = NULL_INDEX;
				indices[index * 4 + 3] = NULL_INDEX;
			}
			else
			{
				indices[index * 4 + 0] = i0->second;
				indices[index * 4 + 1] = i1->second;
				indices[index * 4 + 2] = i2->second;
				indices[index * 4 + 3] = i3->second;
			}

			index++;

			if (index * 4 >= count) return;
		}
	}

	static void Transform(void* ptr, const Matrix4x4d& matrix)
	{
		auto poly = CastToPolyhedron(ptr);
		auto m = matrix.ToCGAL<K>();

		std::transform(poly->points_begin(), poly->points_end(), poly->points_begin(), m);
	}

	static void InsideOut(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->inside_out();
	}

	static void Triangulate(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		CGAL::Polygon_mesh_processing::triangulate_faces(*poly);
	}

	static void NormalizeBorder(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->normalize_border();
	}

	static BOOL NormalizedBorderIsValid(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return poly->normalized_border_is_valid();
	}


};
