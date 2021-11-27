#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
 
#include <map>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_incremental_builder_3.h>

template <class HDS, class K>
class BuildPolyhedronMesh : public CGAL::Modifier_base<HDS> 
{
public:

	Point3d* vertices;

	int verticesCount;

	int* indices;

	int indicesCount;

	void operator()(HDS& hds)
	{
		typedef typename HDS::Vertex   Vertex;
		typedef typename Vertex::Point Point;

		CGAL::Polyhedron_incremental_builder_3<HDS> B(hds);

		int triangles = indicesCount / 3;
		int edges = triangles * 6;

		B.begin_surface(verticesCount, triangles, edges, B.ABSOLUTE_INDEXING);

		for (int i = 0; i < verticesCount; i++)
		{
			auto p = vertices[i].ToCGAL<K>();
			B.add_vertex(p);
		}

		for (int i = 0; i < indicesCount/3; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(indices[i * 3 + 0]);
			B.add_vertex_to_facet(indices[i * 3 + 1]);
			B.add_vertex_to_facet(indices[i * 3 + 2]);
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

	static BOOL IsPureTriangle(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->is_pure_triangle();
	}

	static BOOL IsPureQuad(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->is_pure_quad();
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

	static void CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* indices, int indicesCount)
	{
		auto poly = Polyhedron3<EEK>::CastToPolyhedron(ptr);

		BuildPolyhedronMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.indices = indices;
		builder.indicesCount = indicesCount;

		poly->delegate(builder);
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto poly = Polyhedron3<EEK>::CastToPolyhedron(ptr);
		int i = 0;

		for (auto point = poly->points_begin(); point != poly->points_end(); ++point)
		{
			points[i++] = Point3d::FromCGAL<K>(*point);

			if (i >= count) return;
		}
	}

	static void GetTriangleIndices(void* ptr, int* indices, int count)
	{
		auto poly = Polyhedron3<EEK>::CastToPolyhedron(ptr);
		int index = 0;

		std::map<Point, int> map;

		for (auto point = poly->points_begin(); point != poly->points_end(); ++point)
		{
			map.insert(std::pair<Point, int>(*point, index++));
		}

		index = 0;
		for (auto face = poly->facets_begin(); face != poly->facets_end(); ++face)
		{
			
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


};
