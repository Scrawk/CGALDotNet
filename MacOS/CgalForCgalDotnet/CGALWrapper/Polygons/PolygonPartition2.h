#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "Polygon2.h"
#include "PolygonWithHoles2.h"

#include <vector>
#include <CGAL/Partition_traits_2.h>
#include <CGAL/partition_2.h>

template<class K>
class PolygonPartition2
{

public:

	typedef CGAL::Partition_traits_2<K> Traits;
	typedef typename Traits::Point_2 Point_2;
	typedef typename Traits::Polygon_2 Polygon_2;
	typedef typename std::vector<Polygon_2> Polygon_List;

private:

	Polygon_List buffer;

public:

	PolygonPartition2()
	{

	}

	~PolygonPartition2()
	{

	}

	inline static PolygonPartition2* NewPolygonPartition2()
	{
		return new PolygonPartition2();
	}

	inline static void DeletePolygonPartition2(void* ptr)
	{
		auto obj = static_cast<PolygonPartition2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonPartition2* CastToPolygonPartition2(void* ptr)
	{
		return static_cast<PolygonPartition2*>(ptr);
	}

	static void ClearBuffer(void* ptr)
	{
		auto par = CastToPolygonPartition2(ptr);
		par->buffer.clear();
	}

	static int BufferCount(void* ptr)
	{
		auto par = CastToPolygonPartition2(ptr);
		return (int)par->buffer.size();
	}

	static void* CopyBufferItem(void* ptr, int index)
	{
		auto par = CastToPolygonPartition2(ptr);

		auto copy = Polygon2<K>::NewPolygon2();

		for (const Point_2& p : par->buffer[index])
			copy->push_back(p);

		return copy;
	}

	static BOOL Is_Y_Monotone(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		return CGAL::is_y_monotone_2(poly->vertices_begin(), poly->vertices_end());
	}

	static BOOL Is_Y_MonotonePWH(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = PolygonWithHoles2<K>::CastToPolygonWithHoles2(polyPtr);

		return CGAL::is_y_monotone_2(poly->outer_boundary().vertices_begin(), poly->outer_boundary().vertices_end());
	}

	static BOOL PartionIsValid(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		return CGAL::partition_is_valid_2(poly->vertices_begin(), poly->vertices_end(), par->buffer.begin(), par->buffer.end());
	}

	static BOOL ConvexPartionIsValid(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		return CGAL::convex_partition_is_valid_2(poly->vertices_begin(), poly->vertices_end(), par->buffer.begin(), par->buffer.end());
	}

	static BOOL Y_MonotonePartionIsValid(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		return CGAL::y_monotone_partition_is_valid_2(poly->vertices_begin(), poly->vertices_end(), par->buffer.begin(), par->buffer.end());
	}

	static int Y_MonotonePartition(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		par->buffer.clear();
		CGAL::y_monotone_partition_2(poly->vertices_begin(), poly->vertices_end(), std::back_inserter(par->buffer));

		return (int)par->buffer.size();
	}

	static int Y_MonotonePartitionPWH(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = PolygonWithHoles2<K>::CastToPolygonWithHoles2(polyPtr);

		par->buffer.clear();
		CGAL::y_monotone_partition_2(poly->outer_boundary().vertices_begin(), poly->outer_boundary().vertices_end(), std::back_inserter(par->buffer));

		return (int)par->buffer.size();
	}

	static int ApproxConvexPartition(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		par->buffer.clear();
		CGAL::approx_convex_partition_2(poly->vertices_begin(), poly->vertices_end(), std::back_inserter(par->buffer));

		return (int)par->buffer.size();
	}

	static int ApproxConvexPartitionPWH(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = PolygonWithHoles2<K>::CastToPolygonWithHoles2(polyPtr);

		par->buffer.clear();
		CGAL::approx_convex_partition_2(poly->outer_boundary().vertices_begin(), poly->outer_boundary().vertices_end(), std::back_inserter(par->buffer));

		return (int)par->buffer.size();
	}

	static int GreeneApproxConvexPartition(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		par->buffer.clear();
		CGAL::greene_approx_convex_partition_2(poly->vertices_begin(), poly->vertices_end(), std::back_inserter(par->buffer));

		return (int)par->buffer.size();
	}

	static int GreeneApproxConvexPartitionPWH(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = PolygonWithHoles2<K>::CastToPolygonWithHoles2(polyPtr);

		par->buffer.clear();
		CGAL::greene_approx_convex_partition_2(poly->outer_boundary().vertices_begin(), poly->outer_boundary().vertices_end(), std::back_inserter(par->buffer));

		return (int)par->buffer.size();
	}

	static int OptimalConvexPartition(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		par->buffer.clear();
		CGAL::optimal_convex_partition_2(poly->vertices_begin(), poly->vertices_end(), std::back_inserter(par->buffer));

		return (int)par->buffer.size();
	}

	static int OptimalConvexPartitionPWH(void* ptr, void* polyPtr)
	{
		auto par = CastToPolygonPartition2(ptr);
		auto poly = PolygonWithHoles2<K>::CastToPolygonWithHoles2(polyPtr);

		par->buffer.clear();
		CGAL::optimal_convex_partition_2(poly->outer_boundary().vertices_begin(), poly->outer_boundary().vertices_end(), std::back_inserter(par->buffer));

		return (int)par->buffer.size();
	}


};
