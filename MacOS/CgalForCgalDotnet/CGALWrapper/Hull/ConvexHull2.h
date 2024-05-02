#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"

#include <vector>
#include <CGAL/convex_hull_2.h>
#include <CGAL/ch_eddy.h>
#include <CGAL/ch_jarvis.h>
#include <CGAL/ch_melkman.h>
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

	inline static ConvexHull2* NewConvexHull2()
	{
		return new ConvexHull2();
	}

	inline static void DeleteConvexHull2(void* ptr)
	{
		auto obj = static_cast<ConvexHull2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static ConvexHull2* CastToConvexHull2(void* ptr)
	{
		return static_cast<ConvexHull2*>(ptr);
	}

	static PointList ConvertPoints(Point2d* points, int count)
	{
		PointList list(count);

		for (auto i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();
		
		return list;
	}

	static void* CreateHull(Point2d* points, int count, HULL_METHOD method)
	{
		PointList list = ConvertPoints(points, count);
		PointList out;

		switch(method)
		{
		case HULL_METHOD::DEFAULT:
			CGAL::convex_hull_2(list.begin(), list.end(), std::back_inserter(out));
			break;

		case HULL_METHOD::AKL_TOUSSAINT:
			CGAL::ch_akl_toussaint(list.begin(), list.end(), std::back_inserter(out));
			break;

		case HULL_METHOD::BYKAT:
			CGAL::ch_bykat(list.begin(), list.end(), std::back_inserter(out));
			break;

		case HULL_METHOD::EDDY:
			CGAL::ch_eddy(list.begin(), list.end(), std::back_inserter(out));
			break;

		case HULL_METHOD::GRAHAM_ANDREW:
			CGAL::ch_graham_andrew(list.begin(), list.end(), std::back_inserter(out));
			break;
		case HULL_METHOD::JARVIS:
			CGAL::ch_jarvis(list.begin(), list.end(), std::back_inserter(out));
			break;

		default:
			CGAL::convex_hull_2(list.begin(), list.end(), std::back_inserter(out));
			break;
		}

		return new Polygon_2(out.begin(), out.end());
	}

	static void* LowerHull(Point2d* points, int count)
	{
		PointList list = ConvertPoints(points, count);
		PointList out;

		CGAL::lower_hull_points_2(list.begin(), list.end(), std::back_inserter(out));

		return new Polygon_2(out.begin(), out.end());
	}

	static void* UpperHull(Point2d* points, int count)
	{
		PointList list = ConvertPoints(points, count);
		PointList out;

		CGAL::upper_hull_points_2(list.begin(), list.end(), std::back_inserter(out));

		return new Polygon_2(out.begin(), out.end());
	}

	static BOOL IsStronglyConvexCCW(Point2d* points, int count)
	{
		PointList list = ConvertPoints(points, count);
		return CGAL::is_ccw_strongly_convex_2(list.begin(), list.end());
	}

	static BOOL IsStronglyConvexCW(Point2d* points, int count)
	{
		PointList list = ConvertPoints(points, count);
		return CGAL::is_cw_strongly_convex_2(list.begin(), list.end());
	}

};
