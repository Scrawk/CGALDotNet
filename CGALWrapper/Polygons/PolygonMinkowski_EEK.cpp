#include "PolygonMinkowski_EEK.h"
#include "PolygonMinkowski.h"

#include "Polygon2.h"
#include "PolygonWithHoles2.h"

#include <CGAL/enum.h> 
#include <CGAL/Polygon_2.h>
#include <CGAL/minkowski_sum_2.h>
#include <CGAL/Small_side_angle_bisector_decomposition_2.h>
#include <CGAL/Polygon_convex_decomposition_2.h>
#include <CGAL/Polygon_vertical_decomposition_2.h>
#include <CGAL/Polygon_triangulation_decomposition_2.h>
#include <CGAL/approximated_offset_2.h>

void* PolygonMinkowski_EEK_Create()
{
	return PolygonMinkowski<EEK>::NewPolygonMinkowski();
}

void PolygonMinkowski_EEK_Release(void* ptr)
{
	PolygonMinkowski<EEK>::DeletePolygonMinkowski(ptr);
}

void* PolygonMinkowski_EEK_MinkowskiSum(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSum(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSumDecomp(void* polyPtr1, void* polyPtr2, int decomp)
{
	return PolygonMinkowski<EEK>::MinkowskiSum(polyPtr1, polyPtr2, decomp);
}

