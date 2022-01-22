#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/enum.h> 
#include <CGAL/Exact_circular_kernel_2.h>

template<class K>
class Circle2
{

public:

	typedef CGAL::Point_2<K> Point_2;
	typedef CGAL::Circle_2<K> Circle_2;

	static Circle_2* CastToCircle(void* ptr)
	{
		return static_cast<Circle_2*>(ptr);
	}

	static Circle_2* NewCircle2(Point2d center, double sq_radius, CGAL::Orientation orientation)
	{
		auto p = center.ToCGAL<K>();
		return new Circle_2(p, sq_radius, orientation);
	}

	static void DeleteCircle2(void* ptr)
	{
		auto obj = static_cast<Circle_2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

};
