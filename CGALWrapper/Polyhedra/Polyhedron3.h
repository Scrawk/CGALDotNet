#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/enum.h> 
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Aff_transformation_2.h>

template<class K>
class Polyhedron3
{

public:

	typedef typename K::Point_3 Point_3;
	typedef CGAL::Polyhedron_3<K> Polyhedron;

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


};
