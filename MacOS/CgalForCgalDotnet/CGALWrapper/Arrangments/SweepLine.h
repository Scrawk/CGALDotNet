#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <vector>
#include <list>
#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Surface_sweep_2_algorithms.h>

template<class K>
class SweepLine
{

private:

	typedef CGAL::Arr_segment_traits_2<K> Traits;
	typedef typename  K::Point_2 Point_2;
	typedef typename  Traits::Curve_2 Segment_2;

	std::list<Point_2> pointBuffer;

	std::list<Segment_2> segmentBuffer;

public:

	inline static SweepLine* NewSweepLine()
	{
		return new SweepLine();
	}

	inline static void DeleteSweepLine(void* ptr)
	{
		auto obj = static_cast<SweepLine*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static SweepLine* CastToSweepLine(void* ptr)
	{
		return static_cast<SweepLine*>(ptr);
	}

	static void ClearPointBuffer(void* ptr)
	{
		auto sweep = CastToSweepLine(ptr);
		sweep->pointBuffer.clear();
	}

	static void ClearSegmentBuffer(void* ptr)
	{
		auto sweep = CastToSweepLine(ptr);
		sweep->segmentBuffer.clear();
	}

	static int PointBufferSize(void* ptr)
	{
		auto sweep = CastToSweepLine(ptr);
		return (int)sweep->pointBuffer.size();
	}

	static int SegmentBufferSize(void* ptr)
	{
		auto sweep = CastToSweepLine(ptr);
		return (int)sweep->segmentBuffer.size();
	}

	static BOOL DoIntersect(void* ptr, Segment2d* segments, int count)
	{
		auto sweep = CastToSweepLine(ptr);
		auto list = ToList(segments, count);

		return CGAL::do_curves_intersect(list.begin(), list.end());
	}

	static int ComputeSubcurves(void* ptr, Segment2d* segments, int count)
	{
		auto sweep = CastToSweepLine(ptr);
		auto list = ToList(segments, count);

		sweep->segmentBuffer.clear();
		CGAL::compute_subcurves(list.begin(), list.end(), std::back_inserter(sweep->segmentBuffer));

		return (int)sweep->segmentBuffer.size();
	}

	static int ComputeIntersectionPoints(void* ptr, Segment2d* segments, int count)
	{
		auto sweep = CastToSweepLine(ptr);
		auto list = ToList(segments, count);

		sweep->pointBuffer.clear();
		CGAL::compute_intersection_points(list.begin(), list.end(), std::back_inserter(sweep->pointBuffer));

		return (int)sweep->pointBuffer.size();
	}

	static void GetPoints(void* ptr, Point2d* points, int count)
	{
		auto sweep = CastToSweepLine(ptr);
		int i = 0;

		for (auto point = sweep->pointBuffer.begin(); point != sweep->pointBuffer.end(); ++point, ++i)
			points[i] = Point2d::FromCGAL<K>(*point);
			
	}

	static void GetSegments(void* ptr, Segment2d* segments, int count)
	{
		auto sweep = CastToSweepLine(ptr);
		int i = 0;

		for (auto seg = sweep->segmentBuffer.begin(); seg != sweep->segmentBuffer.end(); ++seg, ++i)
		{
			auto a = seg->source();
			auto b = seg->target();
			segments[i] = Segment2d::FromCGAL<K>(a, b);
		}
	}

	static std::vector<Segment_2> ToList(Segment2d* segments, int count)
	{
		auto list = std::vector<Segment_2>();

		for (int i = 0; i < count; i++)
			list.push_back(segments[i].ToCGAL<K, Segment_2>());

		return list;
	}

	static Segment_2* ToArray(Segment2d* segments, int count)
	{
		auto arr = new Segment_2[count];

		for (int i = 0; i < count; i++)
			arr[i] = segments[i].ToCGAL<K, Segment_2>();

		return arr;
	}

};
