#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/enum.h> 
#include <CGAL/Exact_circular_kernel_2.h>

template<class K>
class Circle2
{

public:

	typedef CGAL::Point_2<EEK> Point_2;
	typedef CGAL::Circle_2<K> Circle_2;

	/// <summary>
	/// Cast pointer to circle.
	/// </summary>
	/// <param name="ptr">The circle pointer.</param>
	/// <returns>The circle.</returns>
	static Circle_2* CastToCircle(void* ptr)
	{
		return static_cast<Circle_2*>(ptr);
	}

	/// <summary>
	/// Create a new circle object.
	/// </summary>
	/// <returns>The new circle object.</returns>
	static Circle_2* NewCircle2(Point2d center, double sq_radius, CGAL::Orientation orientation)
	{
		auto p = center.ToCGAL<K>();
		return new Circle_2(p, sq_radius, orientation);
	}

	/// <summary>
	/// Delete the circle object.
	/// </summary>
	/// <param name="ptr">A pointer to the circle.</param>
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
