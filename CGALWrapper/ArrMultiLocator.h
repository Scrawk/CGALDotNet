#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

#include "CGAL/Point_2.h"
#include <CGAL/Arr_point_location_result.h>
#include <CGAL/Arr_naive_point_location.h>
#include <CGAL/Arr_walk_along_line_point_location.h>
#include <CGAL/Arr_landmarks_point_location.h>
#include <CGAL/Arr_trapezoid_ric_point_location.h>

enum class ARR_LOCATOR : int
{
	NONE = -1,
	NAIVE = 0,
	WALK = 1,
	LANDMARKS = 2,
	TRAPEZOID = 3
};

template<class Arrangement>
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

	ARR_LOCATOR current_locator;

	Naive_Locator* naive_locator;

	Walk_Locator* walk_locator;

	Landmarks_Locator* landmark_locator;

	Trapezoid_Locator* trapezoid_locator;

public:

	ArrMultiLocator()
	{
		current_locator = ARR_LOCATOR::NONE;
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
		if (current_locator == type)
			return;

		ReleaseLocator();
		current_locator = type;

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
		switch (current_locator)
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

		current_locator = ARR_LOCATOR::NONE;
	}

	template<class K>
	Locator_Result_Type Locate(Point2d point, const Arrangement& arr)
	{
		switch (current_locator)
		{
		case ARR_LOCATOR::NAIVE:
			return naive_locator->locate(point.To<K>());

		case ARR_LOCATOR::WALK:
			return walk_locator->locate(point.To<K>());

		case ARR_LOCATOR::LANDMARKS:
			return landmark_locator->locate(point.To<K>());

		case ARR_LOCATOR::TRAPEZOID:
			return trapezoid_locator->locate(point.To<K>());

		default:
			Naive_Locator locator;
			locator.attach(arr);
			return locator.locate(point.To<K>());
		}

	}

};

