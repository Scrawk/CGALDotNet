#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "Polygon2.h"
#include "PolygonWithHoles2.h"

#include <CGAL/enum.h> 
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/minkowski_sum_2.h>
#include <CGAL/Small_side_angle_bisector_decomposition_2.h>
#include <CGAL/Polygon_convex_decomposition_2.h>
#include <CGAL/Polygon_vertical_decomposition_2.h>
#include <CGAL/Polygon_triangulation_decomposition_2.h>
#include <CGAL/approximated_offset_2.h>

template<class K>
class PolygonMinkowski
{
public:

	PolygonMinkowski()
	{

	}

	inline static PolygonMinkowski* NewPolygonMinkowski()
	{
		return new PolygonMinkowski();
	}

	inline static void DeletePolygonMinkowski(void* ptr)
	{
		auto obj = static_cast<PolygonMinkowski*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMinkowski* CastToPolygonMinkowski(void* ptr)
	{
		return static_cast<PolygonMinkowski*>(ptr);
	}

	static void* MinkowskiSum(void* polyPtr1, void* polyPtr2)
	{
		auto poly1 = Polygon2<K>::CastToPolygon2(polyPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSumPWH(void* pwhPtr1, void* polyPtr2)
	{
		auto poly1 = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSum_SSAB(void* polyPtr1, void* polyPtr2)
	{
		auto poly1 = Polygon2<K>::CastToPolygon2(polyPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Small_side_angle_bisector_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSum_OptimalConvex(void* polyPtr1, void* polyPtr2)
	{
		auto poly1 = Polygon2<K>::CastToPolygon2(polyPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Optimal_convex_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSum_HertelMehlhorn(void* polyPtr1, void* polyPtr2)
	{
		auto poly1 = Polygon2<K>::CastToPolygon2(polyPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Hertel_Mehlhorn_convex_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSum_GreeneConvex(void* polyPtr1, void* polyPtr2)
	{
		auto poly1 = Polygon2<K>::CastToPolygon2(polyPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Greene_convex_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSum_Vertical(void* polyPtr1, void* polyPtr2)
	{
		auto poly1 = Polygon2<K>::CastToPolygon2(polyPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Polygon_vertical_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSumPWH_Vertical(void* pwhPtr1, void* polyPtr2)
	{
		auto poly1 = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Polygon_vertical_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSum_Triangle(void* polyPtr1, void* polyPtr2)
	{
		auto poly1 = Polygon2<K>::CastToPolygon2(polyPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Polygon_triangulation_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSumPWH_Triangle(void* pwhPtr1, void* polyPtr2)
	{
		auto poly1 = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Polygon_triangulation_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}



};
