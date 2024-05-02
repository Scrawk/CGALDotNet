#include "PolygonMinkowski_EIK.h"
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

void* PolygonMinkowski_EIK_Create()
{
	return PolygonMinkowski<EIK>::NewPolygonMinkowski();
}

void PolygonMinkowski_EIK_Release(void* ptr)
{
	PolygonMinkowski<EIK>::DeletePolygonMinkowski(ptr);
}

void* PolygonMinkowski_EIK_MinkowskiSum(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSum(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSumPWH(void* pwhPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSumPWH(pwhPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSum_SSAB(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSum_SSAB(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSum_OptimalConvex(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSum_OptimalConvex(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSum_HertelMehlhorn(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSum_HertelMehlhorn(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSum_GreeneConvex(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSum_GreeneConvex(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSum_Vertical(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSum_Vertical(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSumPWH_Vertical(void* pwhPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSumPWH_Vertical(pwhPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSum_Triangle(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSum_Triangle(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EIK_MinkowskiSumPWH_Triangle(void* pwhPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EIK>::MinkowskiSumPWH_Triangle(pwhPtr1, polyPtr2);
}

