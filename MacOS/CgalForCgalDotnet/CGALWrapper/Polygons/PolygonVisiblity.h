#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "Polygon2.h"
#include "PolygonWithHoles2.h"

#include <CGAL/Exact_predicates_exact_constructions_kernel.h>
#include <CGAL/Simple_polygon_visibility_2.h>
#include <CGAL/Triangular_expansion_visibility_2.h>
#include <CGAL/Rotational_sweep_visibility_2.h>
#include <CGAL/Arrangement_2.h>
#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arr_naive_point_location.h>
#include <istream>
#include <vector>

template<class K>
class PolygonVisibility
{
public:

	//typedef CGAL::Exact_predicates_exact_constructions_kernel       Kernel;
	typedef CGAL::Polygon_2<K>                                        Point_2;
	typedef CGAL::Segment_2<K>                                      Segment_2;
	typedef CGAL::Arr_segment_traits_2<K>                      Traits_2;
	typedef CGAL::Arrangement_2<Traits_2>                           Arrangement_2;

	typedef CGAL::Triangular_expansion_visibility_2<Arrangement_2>  TEV;
	typedef CGAL::Rotational_sweep_visibility_2<Arrangement_2> RSV;

	typedef CGAL::Arr_walk_along_line_point_location<Arrangement_2> Locator;

	typedef typename Polygon2<K>::Polygon_2 Polygon;
	typedef typename PolygonWithHoles2<K>::Pwh_2 Pwh;

	inline static PolygonVisibility* NewPolygonVisibility()
	{
		return new PolygonVisibility();
	}

	inline static void DeletePolygonVisibility(void* ptr)
	{
		auto obj = static_cast<PolygonVisibility*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonVisibility* CastToPolygonVisibility(void* ptr)
	{
		return static_cast<PolygonVisibility>(ptr);
	}

	static void GetSegments(std::vector<Segment_2>& segments, const Polygon& poly)
	{
		int count = (int)poly.size();
		for (int i = 0; i < count; i++)
		{
			if (i != count - 1)
			{
				auto p1 = poly.vertex(i);
				auto p2 = poly.vertex(i + 1);
				segments.push_back(Segment_2(p1, p2));
			}
			else
			{
				auto p1 = poly.vertex(i);
				auto p2 = poly.vertex(0);
				segments.push_back(Segment_2(p1, p2));
			}
		}
	}

	static void GetSegments(std::vector<Segment_2>& segments, const Pwh& pwh)
	{
		int count = (int)pwh.outer_boundary().size();
		for (int i = 0; i < count; i++)
		{
			if (i != count - 1)
			{
				auto p1 = pwh.outer_boundary().vertex(i);
				auto p2 = pwh.outer_boundary().vertex(i + 1);
				segments.push_back(Segment_2(p1, p2));
			}
			else
			{
				auto p1 = pwh.outer_boundary().vertex(i);
				auto p2 = pwh.outer_boundary().vertex(0);
				segments.push_back(Segment_2(p1, p2));
			}
		}

		int holes = (int)pwh.number_of_holes();
		for (int j = 0; j < holes; j++)
		{
			auto& hole = pwh.holes().at(j);
			count = (int)hole.size();
			for (int i = 0; i < count; i++)
			{
				if (i != count - 1)
				{
					auto p1 = hole.vertex(i);
					auto p2 = hole.vertex(i + 1);
					segments.push_back(Segment_2(p1, p2));
				}
				else
				{
					auto p1 = hole.vertex(i);
					auto p2 = hole.vertex(0);
					segments.push_back(Segment_2(p1, p2));
				}
			}
		}
	}

	static void* ComputeVisibilitySimple(const Point2d& point, void* polyPtr)
	{

		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		std::vector<Segment_2> segments;
		GetSegments(segments, *poly);

		Arrangement_2 env;
		CGAL::insert_non_intersecting_curves(env, segments.begin(), segments.end());

		Locator pl(env);

		auto q = point.ToCGAL<K>();
		auto obj = pl.locate(q);
		auto face = boost::get<typename Arrangement_2::Face_const_handle>(&obj);

		typedef CGAL::Simple_polygon_visibility_2<Arrangement_2, CGAL::Tag_true> RSPV;

		Arrangement_2 regular_output;
		RSPV regular_visibility(env);
		regular_visibility.compute_visibility(q, *face, regular_output);

		auto result = Polygon2<K>::NewPolygon2();
		auto start = regular_output.edges_begin()->next();
		auto eit = start;

		do
		{
			auto p = eit->source()->point();
			result->push_back(p);
			eit = eit->next();

		} while (eit != start);

		return result;
	}

	static void* ComputeVisibilityTEV(const Point2d& point, void* pwhPtr)
	{
		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		std::vector<Segment_2> segments;
		GetSegments(segments, *pwh);

		Arrangement_2 env;
		CGAL::insert_non_intersecting_curves(env, segments.begin(), segments.end());

		Locator pl(env);

		auto q = point.ToCGAL<K>();
		auto obj = pl.locate(q);
		auto face = boost::get<typename Arrangement_2::Face_const_handle>(&obj);

		Arrangement_2 output_arr;
		TEV tev(env);
		auto fh = tev.compute_visibility(q, *face, output_arr);

		auto result = PolygonWithHoles2<K>::NewPolygonWithHoles2();
		auto curr = fh->outer_ccb();

		result->outer_boundary().push_back(curr->source()->point());

		while (++curr != fh->outer_ccb())
		{
			result->outer_boundary().push_back(curr->source()->point());
		}
			
		return result;
	}

	static void* ComputeVisibilityRSV(const Point2d& point, void* pwhPtr)
	{
		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		std::vector<Segment_2> segments;
		GetSegments(segments, *pwh);

		Arrangement_2 env;
		CGAL::insert_non_intersecting_curves(env, segments.begin(), segments.end());

		Locator pl(env);

		auto q = point.ToCGAL<K>();
		auto obj = pl.locate(q);
		auto face = boost::get<typename Arrangement_2::Face_const_handle>(&obj);

		Arrangement_2 output_arr;
		RSV rsv(env);
		auto fh = rsv.compute_visibility(q, *face, output_arr);

		auto result = PolygonWithHoles2<K>::NewPolygonWithHoles2();
		auto curr = fh->outer_ccb();

		result->outer_boundary().push_back(curr->source()->point());

		while (++curr != fh->outer_ccb())
		{
			result->outer_boundary().push_back(curr->source()->point());
		}

		return result;
	}

};
