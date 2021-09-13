#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/enum.h> 
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/Polyline_simplification_2/simplify.h>
#include <CGAL/Polyline_simplification_2/Hybrid_squared_distance_cost.h>

template<class K>
class PolygonSimplification2
{

public:

	PolygonSimplification2() {}

	typedef CGAL::Polygon_2<K> Polygon_2;
	typedef CGAL::Polygon_with_holes_2<K> Pwh_2;
	typedef CGAL::Polyline_simplification_2::Stop_below_count_ratio_threshold stop_below_ratio;
	typedef CGAL::Polyline_simplification_2::Stop_below_count_threshold stop_below_threshold;
	typedef CGAL::Polyline_simplification_2::Stop_above_cost_threshold stop_above_threshold;

	typedef CGAL::Polyline_simplification_2::Squared_distance_cost            sq_dist_cost;
	typedef CGAL::Polyline_simplification_2::Hybrid_squared_distance_cost<K>  hsq_dist_cost;
	typedef CGAL::Polyline_simplification_2::Scaled_squared_distance_cost     ssq_dist_cost;

	inline static PolygonSimplification2* NewPolygonSimplification2()
	{
		return new PolygonSimplification2();
	}

	inline static void DeletePolygonSimplification2(void* ptr)
	{
		auto obj = static_cast<PolygonSimplification2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonSimplification2* CastToPolygonSimplification2(void* ptr)
	{
		return static_cast<PolygonSimplification2*>(ptr);
	}

	inline static Polygon_2* CastToPolygon2(void* ptr)
	{
		return static_cast<Polygon_2*>(ptr);
	}

	inline static Pwh_2* CastToPolygonWithHoles2(void* ptr)
	{
		return static_cast<Pwh_2*>(ptr);
	}

	static void* Simplify(void* polyPtr, COST_FUNC costFunc, STOP_FUNC stopFunc, double theshold)
	{
		auto poly = CastToPolygon2(polyPtr);

		size_t intThreshold = (size_t)std::round(theshold);

		Polygon_2 result;

		switch (costFunc)
		{

		case COST_FUNC::SQUARE_DIST:
			switch (stopFunc)
			{
			case STOP_FUNC::ABOVE_THRESHOLD:
				result = CGAL::Polyline_simplification_2::simplify(*poly, sq_dist_cost(), stop_above_threshold(theshold));
				break;
			case STOP_FUNC::BELOW_THRESHOLD:
				result = CGAL::Polyline_simplification_2::simplify(*poly, sq_dist_cost(), stop_below_threshold(intThreshold));
				break;
			case STOP_FUNC::BELOW_RATIO:
				result = CGAL::Polyline_simplification_2::simplify(*poly, sq_dist_cost(), stop_below_ratio(theshold));
				break;
			}
			break;

		case COST_FUNC::SCALED_SQ_DIST:
			switch (stopFunc)
			{
			case STOP_FUNC::ABOVE_THRESHOLD:
				result = CGAL::Polyline_simplification_2::simplify(*poly, ssq_dist_cost(), stop_above_threshold(theshold));
				break;
			case STOP_FUNC::BELOW_THRESHOLD:
				result = CGAL::Polyline_simplification_2::simplify(*poly, ssq_dist_cost(), stop_below_threshold(intThreshold));
				break;
			case STOP_FUNC::BELOW_RATIO:
				result = CGAL::Polyline_simplification_2::simplify(*poly, ssq_dist_cost(), stop_below_ratio(theshold));
				break;
			}
			break;
		}

		return new Polygon_2(result);
	}

	static void* SimplifyPolygonWithHoles(void* pwhPtr, double theshold)
	{
		typedef CGAL::Polygon_with_holes_2<EEK> Pwh_2;

		auto pwh = PolygonSimplification2<EEK>::CastToPolygonWithHoles2(pwhPtr);

		sq_dist_cost cost;
		stop_below_ratio stop(theshold);

		Pwh_2* p = nullptr;

		if (!pwh->is_unbounded())
		{
			auto boundary = CGAL::Polyline_simplification_2::simplify(pwh->outer_boundary(), cost, stop);
			p = new Pwh_2(boundary);
		}
		else
		{
			p = new Pwh_2();
		}

		for (auto hole : pwh->holes())
		{
			auto h = CGAL::Polyline_simplification_2::simplify(hole, cost, stop);
			p->add_hole(h);
		}

		return p;
	}

};





