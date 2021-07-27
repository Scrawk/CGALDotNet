#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "Polygon2.h"

#include <vector>
#include <CGAL/convex_hull_2.h>
#include <CGAL/Convex_hull_traits_adapter_2.h>

template<class K>
class ConvexHull2
{
private:

	typedef std::vector<CGAL::Point_2<K>> PointList;
	typedef CGAL::Polygon_2<K> Polygon_2;

public:

	ConvexHull2()
	{

	}

	~ConvexHull2()
	{

	}

	inline static ConvexHull2* CastToConvexHull2(void* ptr)
	{
		return static_cast<ConvexHull2*>(ptr);
	}

	static PointList ConvertPoints(Point2d* points, int startIndex, int count)
	{
		PointList list(count);

		for (auto i = 0; i < count; i++)
			list[i] = points[startIndex + i].ToCGAL<K>();
		
		return list;
	}

	static void* CreateHull(Point2d* points, int startIndex, int count)
	{
		PointList list = ConvertPoints(points, startIndex, count);
		PointList out;

		CGAL::convex_hull_2(list.begin(), list.end(), std::back_inserter(out));

		return new Polygon_2(out.begin(), out.end());
	}

	static void* LowerHull(Point2d* points, int startIndex, int count)
	{
		PointList list = ConvertPoints(points, startIndex, count);
		PointList out;

		CGAL::lower_hull_points_2(list.begin(), list.end(), std::back_inserter(out));

		return new Polygon_2(out.begin(), out.end());
	}

	static void* UpperHull(Point2d* points, int startIndex, int count)
	{
		PointList list = ConvertPoints(points, startIndex, count);
		PointList out;

		CGAL::upper_hull_points_2(list.begin(), list.end(), std::back_inserter(out));

		return new Polygon_2(out.begin(), out.end());
	}

	static BOOL IsStronglyConvexCCW(Point2d* points, int startIndex, int count)
	{
		PointList list = ConvertPoints(points, startIndex, count);
		return CGAL::is_ccw_strongly_convex_2(list.begin(), list.end());
	}

	static BOOL IsStronglyConvexCW(Point2d* points, int startIndex, int count)
	{
		PointList list = ConvertPoints(points, startIndex, count);
		return CGAL::is_cw_strongly_convex_2(list.begin(), list.end());
	}

};
