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

enum MINKOWSKI_DECOMPOSITION : int
{
	SMALL_SIDE_ANGLE_BISECTOR,
	OPTIMAL_CONVEX,
	HERTEL_MEHLHORN_CONVEX,
	GREENE_CONVEX,
	POLYGONAL_VERTICAL,
	POLYGONAL_TRIANGULATION
};

enum MINKOWSKI_OFFSET : int
{
	OFFSET,
	INSET
};

enum MINKOWSKI_APPROX : int
{
	APPROX,
	EXACT
};

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

	static void* MinkowskiSum_Triangle(void* polyPtr1, void* polyPtr2)
	{
		auto poly1 = Polygon2<K>::CastToPolygon2(polyPtr1);
		auto poly2 = Polygon2<K>::CastToPolygon2(polyPtr2);

		CGAL::Polygon_triangulation_decomposition_2<K> decomp;
		auto sum = CGAL::minkowski_sum_2(*poly1, *poly2, decomp);

		return PolygonWithHoles2<K>::NewPolygonWithHoles2(&sum);
	}

	static void* MinkowskiSum(void* polyPtr1, void* polyPtr2, int decomp)
	{
		auto d = (MINKOWSKI_DECOMPOSITION)decomp;

		switch (d)
		{
		case MINKOWSKI_DECOMPOSITION::SMALL_SIDE_ANGLE_BISECTOR:
			return MinkowskiSum_SSAB(polyPtr1, polyPtr2);

		case MINKOWSKI_DECOMPOSITION::OPTIMAL_CONVEX:
			return MinkowskiSum_OptimalConvex(polyPtr1, polyPtr2);

		case MINKOWSKI_DECOMPOSITION::HERTEL_MEHLHORN_CONVEX:
			return MinkowskiSum_HertelMehlhorn(polyPtr1, polyPtr2);

		case MINKOWSKI_DECOMPOSITION::GREENE_CONVEX:
			return MinkowskiSum_GreeneConvex(polyPtr1, polyPtr2);

		case MINKOWSKI_DECOMPOSITION::POLYGONAL_VERTICAL:
			return MinkowskiSum_Vertical(polyPtr1, polyPtr2);

		case MINKOWSKI_DECOMPOSITION::POLYGONAL_TRIANGULATION:
			return MinkowskiSum_Triangle(polyPtr1, polyPtr2);

		default:
			return MinkowskiSum(polyPtr1, polyPtr2);
		}

	}

};
