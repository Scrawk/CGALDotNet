#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <vector>
#include <CGAL/convex_hull_3.h>
#include <CGAL/Convex_hull_3/dual/halfspace_intersection_3.h>

template<class K>
class ConvexHull3
{
private:

	typedef CGAL::Point_3<K>     Point_3;
	typedef CGAL::Plane_3<K>     Plane_3;
	typedef std::vector<Point_3> PointList;
	typedef std::vector<Plane_3> PlaneList;

public:

	inline static ConvexHull3* NewConvexHull3()
	{
		return new ConvexHull3();
	}

	inline static void DeleteConvexHull3(void* ptr)
	{
		auto obj = static_cast<ConvexHull3*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static ConvexHull3* CastToConvexHull3(void* ptr)
	{
		return static_cast<ConvexHull3*>(ptr);
	}

	static PointList ConvertPoints(Point3d* points, int count)
	{
		PointList list(count);

		for (auto i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();

		return list;
	}

	static PlaneList ConvertPlanes(Plane3d* planes, int count)
	{
		PlaneList list(count);

		for (auto i = 0; i < count; i++)
			list[i] = planes[i].ToCGAL<K, Plane_3>();

		return list;
	}

	static void* CreateHullAsPolyhedronFromPoints(Point3d* points, int count)
	{
		auto list = ConvertPoints(points, count);
		auto poly = Polyhedron3<K>::NewPolyhedron();

		CGAL::convex_hull_3(list.begin(), list.end(), poly->model);

		return poly;
	}

	static void* CreateHullAsSurfaceMeshFromPoints(Point3d* points, int count)
	{
		auto list = ConvertPoints(points, count);
		auto mesh = SurfaceMesh3<K>::NewSurfaceMesh();

		CGAL::convex_hull_3(list.begin(), list.end(), mesh->model);

		return mesh;
	}

	static void* CreateHullAsPolyhedronFromPlanes(Plane3d* planes, int count)
	{
		auto list = ConvertPlanes(planes, count);
		auto poly = Polyhedron3<K>::NewPolyhedron();

		CGAL::halfspace_intersection_3(list.begin(), list.end(), poly->model);

		return poly;
	}

	static void* CreateHullAsSurfaceMeshFromPlanes(Plane3d* planes, int count)
	{
		auto list = ConvertPlanes(planes, count);
		auto mesh = SurfaceMesh3<K>::NewSurfaceMesh();

		CGAL::halfspace_intersection_3(list.begin(), list.end(), mesh->model);

		return mesh;
	}

	static BOOL IsPolyhedronStronglyConvex(void* ptr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(ptr);
		return CGAL::is_strongly_convex_3(poly->model);
	}

	static BOOL IsSurfaceMeshStronglyConvex(void* ptr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);
		return CGAL::is_strongly_convex_3(mesh->model);
	}

};
