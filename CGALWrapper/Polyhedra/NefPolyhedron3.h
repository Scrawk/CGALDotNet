#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "Polyhedron3.h"

#include <CGAL/Nef_polyhedron_3.h>

template<class K>
class NefPolyhedron3
{

public:

	typedef typename K::Point_3 Point_3;
	typedef typename K::Plane_3 Plane_3;
	typedef CGAL::Nef_polyhedron_3<K> NefPolyhedron;

	inline static NefPolyhedron* CreateFromSpace(int space)
	{
		if(space == NefPolyhedron::EMPTY)
			return new NefPolyhedron(NefPolyhedron::EMPTY);
		else
			return new NefPolyhedron(NefPolyhedron::COMPLETE);
	}

	inline static NefPolyhedron* CreateFromPlane(Plane3d plane, int boundary)
	{
		auto p = plane.ToCGAL<EEK, Plane_3>();

		if (boundary == NefPolyhedron::EXCLUDED)
			return new NefPolyhedron(p, NefPolyhedron::EXCLUDED);
		else
			return new NefPolyhedron(p, NefPolyhedron::INCLUDED);
	}

	inline static NefPolyhedron* CreateFromPolyhedron(void* ptr)
	{
		auto p = Polyhedron3<K>::CastToPolyhedron(ptr);
		return new NefPolyhedron(*p);
	}

	inline static void DeleteNefPolyhedron(void* ptr)
	{
		auto obj = static_cast<NefPolyhedron*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static NefPolyhedron* CastToNefPolyhedron(void* ptr)
	{
		return static_cast<NefPolyhedron*>(ptr);
	}

	static void Clear(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		nef->clear();
	}

	static BOOL IsEmpty(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return nef->is_empty();
	}

	static BOOL IsSimple(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return nef->is_simple();
	}

	static BOOL IsSpace(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return nef->is_space();
	}

	static BOOL IsValid(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return nef->is_valid();
	}

	static int EdgeCount(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return (int)nef->number_of_edges();
	}

	static int FacetCount(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return (int)nef->number_of_facets();
	}

	static int HalfEdgeCount(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return (int)nef->number_of_halfedges();
	}

	static int HalfFacetCount(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return (int)nef->number_of_halffacets();
	}

	static int VertexCount(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return (int)nef->number_of_vertices();
	}

	static int VolumeCount(void* ptr)
	{
		auto nef = CastToNefPolyhedron(ptr);
		return (int)nef->number_of_volumes();
	}
		
};