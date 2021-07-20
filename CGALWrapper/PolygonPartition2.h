#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "Polygon2.h"

#include <list>
#include <CGAL/Partition_traits_2.h>
#include <CGAL/partition_2.h>

template<class K>
class PolygonPartition2
{

public:

	typedef CGAL::Polygon_2<K> Polygon_2;

	PolygonPartition2()
	{

	}

	~PolygonPartition2()
	{

	}

	inline static PolygonPartition2* CastToPolygonPartition2(void* ptr)
	{
		return static_cast<PolygonPartition2*>(ptr);
	}

	static BOOL Is_Y_Monotone(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		return CGAL::is_y_monotone_2(poly->vertices_begin(), poly->vertices_end());
	}

	static BOOL PartionIsValid(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		return CGAL::partition_is_valid_2(poly->vertices_begin(), poly->vertices_end(), par->begin(), par->end());
	}

	static BOOL Y_MonotonePartionIsValid(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		return CGAL::y_monotone_partition_is_valid_2(poly->vertices_begin(), poly->vertices_end(), par->begin(), par->end());
	}

	static void Y_MonotonePartition2(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		std::list<Polygon_2> list;

		//CGAL::y_monotone_partition_2(poly->vertices_begin(), poly->vertices_end(), std::back_inserter(list));
	}


};
