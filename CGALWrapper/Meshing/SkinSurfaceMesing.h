#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

#include <list>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Skin_surface_3.h>
#include <CGAL/mesh_skin_surface_3.h>
#include <CGAL/subdivide_skin_surface_mesh_3.h>

template<class K>
class SkinSurfaceMeshing
{

public:

	typedef typename K::Point_3                                          Point;
	typedef typename K::Weighted_point_3                                 WPoint;
	typedef typename CGAL::Polyhedron_3<K>								 Polyhedron;

	inline static SkinSurfaceMeshing* NewSkinSurfaceMeshing()
	{
		return new SkinSurfaceMeshing();
	}

	inline static void DeleteSkinSurfaceMeshing(void* ptr)
	{
		auto obj = static_cast<SkinSurfaceMeshing*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static SkinSurfaceMeshing* CastToSkinSurfaceMeshing(void* ptr)
	{
		return static_cast<SkinSurfaceMeshing*>(ptr);
	}

	/*
	void* MakeSkinSurface(double shrinkfactor)
	{
		std::list<WPoint> l;

		l.push_front(WPoint(Point(1, -1, -1), 1.25));
		l.push_front(WPoint(Point(1, 1, 1), 1.25));
		l.push_front(WPoint(Point(-1, 1, -1), 1.25));
		l.push_front(WPoint(Point(-1, -1, 1), 1.25));

		auto p = new Polyhedron();
		CGAL::make_skin_surface_mesh_3(*p, l.begin(), l.end(), shrinkfactor);

		return p;
	}
	*/

};
