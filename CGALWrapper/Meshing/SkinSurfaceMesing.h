#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Polyhedra//Polyhedron3.h"

#include <CGAL/Skin_surface_3.h>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/mesh_skin_surface_3.h>
#include <CGAL/subdivide_skin_surface_mesh_3.h>
#include <list>
#include <vector>

template<class K>
class SkinSurfaceMeshing
{

public:

	typedef typename K::Point_3                                          Point;
	typedef typename K::Weighted_point_3                                 WPoint;
	typedef typename CGAL::Polyhedron_3<K>								 Polyhedron;

	typedef typename CGAL::Skin_surface_traits_3<K>                      Traits;
	typedef typename CGAL::Skin_surface_3<Traits>                        Skin_surface_3;

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

	static std::vector<WPoint> PointList(HPoint3d* points, int count)
	{
		std::vector< WPoint> list(count);
		for (int i = 0; i < count; i++)
		{
			list[i] = points[i].ToCGALWeightedPoint<K>();
		}

		return list;
	}

	static std::vector<WPoint> PointList(Point3d* points, int count)
	{
		std::vector< WPoint> list(count);
		for (int i = 0; i < count; i++)
		{
			list[i] = points[i].ToCGALWeightedPoint<K>();
		}

		return list;
	}

	static void* MakeSkinSurface(double shrinkfactor, BOOL subdivide, Point3d* points, int count)
	{
		auto list = PointList(points, count);
		auto poly = Polyhedron3<K>::NewPolyhedron();

		Skin_surface_3 skin_surface(list.begin(), list.end(), shrinkfactor);
		CGAL::mesh_skin_surface_3(skin_surface, poly->model);

		if (subdivide)
			CGAL::subdivide_skin_surface_mesh_3(skin_surface, poly->model);

		poly->OnModelChanged();
		return poly;
	}
	
	static void* MakeSkinSurface(double shrinkfactor, BOOL subdivide, HPoint3d* points, int count)
	{
		auto list = PointList(points, count);
		auto poly = Polyhedron3<K>::NewPolyhedron();

		Skin_surface_3 skin_surface(list.begin(), list.end(), shrinkfactor);
		CGAL::mesh_skin_surface_3(skin_surface, poly->model);

		if(subdivide)
			CGAL::subdivide_skin_surface_mesh_3(skin_surface, poly->model);

		poly->OnModelChanged();
		return poly;
	}
	

};
