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

void* PolygonMinkowski_EEK_MinkowskiSumPWH(void* pwhPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSumPWH(pwhPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSum_SSAB(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSum_SSAB(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSum_OptimalConvex(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSum_OptimalConvex(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSum_HertelMehlhorn(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSum_HertelMehlhorn(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSum_GreeneConvex(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSum_GreeneConvex(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSum_Vertical(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSum_Vertical(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSumPWH_Vertical(void* pwhPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSumPWH_Vertical(pwhPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSum_Triangle(void* polyPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSum_Triangle(polyPtr1, polyPtr2);
}

void* PolygonMinkowski_EEK_MinkowskiSumPWH_Triangle(void* pwhPtr1, void* polyPtr2)
{
	return PolygonMinkowski<EEK>::MinkowskiSumPWH_Triangle(pwhPtr1, polyPtr2);
}


