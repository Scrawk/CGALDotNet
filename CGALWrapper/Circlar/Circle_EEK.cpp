#pragma once

#include "Circle_EEK.h"
#include "Circle.h"

#include <CGAL/Exact_circular_kernel_2.h>
#include <CGAL/Circular_kernel_2.h>
#include <CGAL/Algebraic_kernel_for_circles_2_2.h>
#include <CGAL/Gps_circle_segment_traits_2.h>
#include <CGAL/Arr_Bezier_curve_traits_2.h>

void* Circle2_EEK_Create(Point2d center, double sq_radius, CGAL::Orientation orientation)
{
	return Circle2<EEK>::NewCircle2(center, sq_radius, orientation);
}

void Circle2_EEK_Release(void* ptr)
{
	Circle2<EEK>::DeleteCircle2(ptr);
}

void Test()
{
	typedef CGAL::Exact_predicates_exact_constructions_kernel Kernel;
	typedef Kernel::Point_2                                   Point_2;
	typedef Kernel::Circle_2                                  Circle_2;
	typedef CGAL::Gps_circle_segment_traits_2<Kernel>         Traits_2;

	typedef Traits_2::Curve_2                                 Curve_2;
	typedef Traits_2::X_monotone_curve_2                      X_monotone_curve_2;

	Circle_2 cir;

	X_monotone_curve_2 crv;

}