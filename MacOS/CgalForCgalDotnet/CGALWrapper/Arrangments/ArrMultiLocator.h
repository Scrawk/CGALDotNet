#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include "CGAL/Point_2.h"
#include <CGAL/Arr_point_location_result.h>
#include <CGAL/Arr_batched_point_location.h>
#include <CGAL/Arr_naive_point_location.h>
#include <CGAL/Arr_walk_along_line_point_location.h>
#include <CGAL/Arr_landmarks_point_location.h>
#include <CGAL/Arr_trapezoid_ric_point_location.h>

enum class ARR_LOCATOR : int
{
	NONE,
	NAIVE,
	WALK,
	LANDMARKS,
	TRAPEZOID
};

template<class K, class Arrangement>
class ArrMultiLocator
{

public:

	typedef CGAL::Arr_point_location_result<Arrangement> Locator_Result;
	typedef typename Locator_Result::Type Locator_Result_Type;

	typedef CGAL::Arr_naive_point_location<Arrangement> Naive_Locator;
	typedef CGAL::Arr_walk_along_line_point_location<Arrangement> Walk_Locator;
	typedef CGAL::Arr_landmarks_point_location<Arrangement> Landmarks_Locator;
	typedef CGAL::Arr_trapezoid_ric_point_location<Arrangement> Trapezoid_Locator;

private:

	ARR_LOCATOR current_locator_type;

	Naive_Locator* naive_locator;

	Walk_Locator* walk_locator;

	Landmarks_Locator* landmark_locator;

	Trapezoid_Locator* trapezoid_locator;

public:

	ArrMultiLocator()
	{
		current_locator_type = ARR_LOCATOR::NONE;
		naive_locator = nullptr;
		walk_locator = nullptr;
		landmark_locator = nullptr;
		trapezoid_locator = nullptr;
	}

	~ArrMultiLocator()
	{
		ReleaseLocator();
	}

	void CreateLocator(ARR_LOCATOR type, Arrangement& arr)
	{
		if (current_locator_type == type)
			return;

		ReleaseLocator();
		current_locator_type = type;

		switch (type)
		{
		case ARR_LOCATOR::NAIVE:
			naive_locator = new Naive_Locator();
			naive_locator->attach(arr);
			break;

		case ARR_LOCATOR::WALK:
			walk_locator = new Walk_Locator();
			walk_locator->attach(arr);
			break;

		case ARR_LOCATOR::LANDMARKS:
			landmark_locator = new Landmarks_Locator();
			landmark_locator->attach(arr);
			break;

		case ARR_LOCATOR::TRAPEZOID:
			trapezoid_locator = new Trapezoid_Locator();
			trapezoid_locator->attach(arr);
			break;
		}
	}

	void ReleaseLocator()
	{
		switch (current_locator_type)
		{
		case ARR_LOCATOR::NAIVE:
			naive_locator->detach();
			delete naive_locator;
			naive_locator = nullptr;
			break;

		case ARR_LOCATOR::WALK:
			walk_locator->detach();
			delete walk_locator;
			walk_locator = nullptr;
			break;

		case ARR_LOCATOR::LANDMARKS:
			landmark_locator->detach();
			delete landmark_locator;
			landmark_locator = nullptr;
			break;

		case ARR_LOCATOR::TRAPEZOID:
			trapezoid_locator->detach();
			delete trapezoid_locator;
			trapezoid_locator = nullptr;
			break;
		}

		current_locator_type = ARR_LOCATOR::NONE;
	}

	Locator_Result_Type Locate(const Arrangement& arr, Point2d point)
	{
		switch (current_locator_type)
		{
		case ARR_LOCATOR::NAIVE:
			return naive_locator->locate(point.ToCGAL<K>());

		case ARR_LOCATOR::WALK:
			return walk_locator->locate(point.ToCGAL<K>());

		case ARR_LOCATOR::LANDMARKS:
			return landmark_locator->locate(point.ToCGAL<K>());

		case ARR_LOCATOR::TRAPEZOID:
			return trapezoid_locator->locate(point.ToCGAL<K>());

		default:
			Walk_Locator locator;
			locator.attach(arr);
			return locator.locate(point.ToCGAL<K>());
		}
	}

	Locator_Result_Type RayShootUp(const Arrangement& arr, Point2d point)
	{
		switch (current_locator_type)
		{
		case ARR_LOCATOR::WALK:
			return walk_locator->ray_shoot_up(point.ToCGAL<K>());

		case ARR_LOCATOR::TRAPEZOID:
			return trapezoid_locator->ray_shoot_up(point.ToCGAL<K>());

		default:
			Walk_Locator locator;
			locator.attach(arr);
			return locator.ray_shoot_up(point.ToCGAL<K>());
		}
	}

	Locator_Result_Type RayShootDown(const Arrangement& arr, Point2d point)
	{
		switch (current_locator_type)
		{
		case ARR_LOCATOR::WALK:
			return walk_locator->ray_shoot_down(point.ToCGAL<K>());

		case ARR_LOCATOR::TRAPEZOID:
			return trapezoid_locator->ray_shoot_down(point.ToCGAL<K>());

		default:
			Walk_Locator locator;
			locator.attach(arr);
			return locator.ray_shoot_down(point.ToCGAL<K>());
		}
	}

	template<class SEGMENT>
	BOOL Intersects(Arrangement& arr, Segment2d segment)
	{
		auto seg = segment.ToCGAL<K, SEGMENT>();

		switch (current_locator_type)
		{
		case ARR_LOCATOR::WALK:
			return do_intersect(arr, seg, *walk_locator);

		case ARR_LOCATOR::TRAPEZOID:
			return do_intersect(arr, seg, *trapezoid_locator);

		default:
			Walk_Locator locator;
			locator.attach(arr);
			return do_intersect(arr, seg, locator);
		}
	}

	void InsertPoint(Arrangement& arr, Point2d point)
	{
		switch (current_locator_type)
		{
		case ARR_LOCATOR::WALK:
			insert_point(arr, point.ToCGAL<K>(), *walk_locator);
			break;

		case ARR_LOCATOR::TRAPEZOID:
			insert_point(arr, point.ToCGAL<K>(), *trapezoid_locator);
			break;

		default:
			Walk_Locator locator;
			locator.attach(arr);
			insert_point(arr, point.ToCGAL<K>(), locator);
			break;
		}
	}

	template<class SEGMENT>
	void InsertSegment(Arrangement& arr, Segment2d segment)
	{
		auto seg = segment.ToCGAL<K, SEGMENT>();

		switch (current_locator_type)
		{
		case ARR_LOCATOR::WALK:
			insert(arr, seg, *walk_locator);
			break;

		case ARR_LOCATOR::TRAPEZOID:
			insert(arr, seg, *trapezoid_locator);
			break;

		default:
			Walk_Locator locator;
			locator.attach(arr);
			insert(arr, seg, locator);
			break;
		}
	}

	template<class SEGMENT>
	void InsertNonIntersectingSegment(Arrangement& arr, Segment2d segment)
	{
		auto seg = segment.ToCGAL<K, SEGMENT>();

		switch (current_locator_type)
		{
		case ARR_LOCATOR::WALK:
			insert_non_intersecting_curve(arr, seg, *walk_locator);
			break;

		case ARR_LOCATOR::TRAPEZOID:
			insert_non_intersecting_curve(arr, seg, *trapezoid_locator);
			break;

		default:
			Walk_Locator locator;
			locator.attach(arr);
			insert_non_intersecting_curve(arr, seg, locator);
			break;
		}
	}

};

