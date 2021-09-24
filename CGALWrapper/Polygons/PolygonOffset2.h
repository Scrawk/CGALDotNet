#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "Polygon2.h"
#include "PolygonWithHoles2.h"

#include <vector>
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/create_offset_polygons_2.h>
#include <CGAL/create_straight_skeleton_from_polygon_with_holes_2.h>
#include <boost/shared_ptr.hpp>

template<class K>
class PolygonOffset2
{

private:

	typedef typename K::Point_2                   Point;
	typedef typename CGAL::Polygon_2<K>			  Polygon_2;
	typedef CGAL::Polygon_with_holes_2<K>         Polygon_with_holes;
	typedef CGAL::Straight_skeleton_2<K>		  Ss;
	typedef boost::shared_ptr<Ss>			      SsPtr;
	typedef boost::shared_ptr<Polygon_2>          PolygonPtr;
	typedef std::vector<PolygonPtr>               PolygonPtrVector;

	std::vector<Polygon_2*>  buffer;

public:

	inline static PolygonOffset2* NewPolygonOffset2()
	{
		return new PolygonOffset2();
	}

	inline static void DeletePolygonOffset2(void* ptr)
	{
		auto obj = static_cast<PolygonOffset2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonOffset2* CastToPolygonOffset2(void* ptr)
	{
		return static_cast<PolygonOffset2*>(ptr);
	}

	static int PolygonBufferSize(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return (int)offset->buffer.size();
	}

	static void ClearPolygonBuffer(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		offset->buffer.clear();
	}

	static void* GetBufferedPolygon(void* ptr, int index)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return offset->buffer[index];
	}

	static void CreateInteriorOffset(void* ptr, void* polyPtr, double amount)
	{
		auto offset = CastToPolygonOffset2(ptr);

		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);
		auto polygons = CGAL::create_interior_skeleton_and_offset_polygons_2(amount, *poly);

		for (auto iter = polygons.begin(); iter != polygons.end(); ++iter)
		{
			auto p = new Polygon_2();

			for (auto v = (*iter)->vertices_begin(); v != (*iter)->vertices_end(); ++v)
			{
				Point point(v->x(), v->y());
				p->push_back(point);
			}

			offset->buffer.push_back(p);
		}
	}

	static void CreateExteriorOffset(void* ptr, void* polyPtr, double amount)
	{
		auto offset = CastToPolygonOffset2(ptr);

		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);
		auto polygons = CGAL::create_exterior_skeleton_and_offset_polygons_2(amount, *poly);

		for (auto iter = polygons.begin(); iter != polygons.end(); ++iter)
		{
			auto p = new Polygon_2();

			for (auto v = (*iter)->vertices_begin(); v != (*iter)->vertices_end(); ++v)
			{
				Point point(v->x(), v->y());
				p->push_back(point);
			}

			offset->buffer.push_back(p);
		}
	}

};

/*
namespace PolygonOffset
{

	#include <CGAL/Exact_predicates_inexact_constructions_kernel.h>
	#include <CGAL/Exact_predicates_exact_constructions_kernel.h>
	#include <CGAL/Polygon_2.h>
	#include <CGAL/create_offset_polygons_2.h>
	#include <boost/shared_ptr.hpp>
	#include <vector>

	typedef CGAL::Exact_predicates_inexact_constructions_kernel K;
	typedef K::Point_2                   Point;
	typedef CGAL::Polygon_2<K>           Polygon_2;
	typedef CGAL::Straight_skeleton_2<K> Ss;
	typedef boost::shared_ptr<Polygon_2> PolygonPtr;
	typedef boost::shared_ptr<Ss> SsPtr;
	typedef std::vector<PolygonPtr> PolygonPtrVector;

	std::vector<Point> points;
	std::vector<PolygonPtr> polygons;

	void CreateOffsetPolygons(std::vector<Point2d> points)
	{
		std::vector<Point> points_IEK;
		for (int i = 0; i < points.size(); i++)
		{
			auto p = points[i].ToCGAL<K>();
			points_IEK.push_back(p);
		}

		SsPtr ss = CGAL::create_interior_straight_skeleton_2(points_IEK.begin(), points_IEK.end());

		double lOffset = 1;
		PolygonPtrVector offset_polygons = CGAL::create_offset_polygons_2<Polygon_2>(lOffset, *ss);
	}

	void CreateStraightSkeleton()
	{
		Polygon_2 poly;

		// You can pass the polygon via an iterator pair
		SsPtr iss = CGAL::create_interior_straight_skeleton_2(poly.vertices_begin(), poly.vertices_end());

		// Or you can pass the polygon directly, as below.
		// To create an exterior straight skeleton you need to specify a maximum offset.
		double lMaxOffset = 5;
		SsPtr oss = CGAL::create_exterior_straight_skeleton_2(lMaxOffset, poly);
	}

}
*/
