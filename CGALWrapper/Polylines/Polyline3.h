#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"

#include <vector>
#include <algorithm>
#include <CGAL/enum.h> 
#include <CGAL/Aff_transformation_3.h>
#include <CGAL/Cartesian_converter.h>

template<class K>
class Polyline3
{

public:

	typedef CGAL::Point_3<K> Point_3;
	typedef CGAL::Segment_3<K> Segment_3;

	Polyline3()
	{

	}

	Polyline3(int count)
	{
		points.resize(count);
	}

	Polyline3(const std::vector<Point_3>& points)
	{
		this->points = points;
	}

	std::vector<Point_3> points;

	inline static Polyline3* NewPolyline3()
	{
		return new Polyline3();

	}

	inline static Polyline3* NewPolyline3(int count)
	{
		return new Polyline3(count);
	}

	inline static Polyline3* NewPolyline3(const std::vector<Point_3>& points)
	{
		return new Polyline3(points);
	}

	inline static void DeletePolyline3(void* ptr)
	{
		auto obj = static_cast<Polyline3*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static Polyline3* CastToPolyline3(void* ptr)
	{
		return static_cast<Polyline3*>(ptr);
	}

	inline bool OutOfRange(int index)
	{
		if (index < 0 || index >= points.size())
			return true;
		else
			return false;
	}

	static void* Copy(void* ptr)
	{
		auto polyline = CastToPolyline3(ptr);
		auto copy = new Polyline3();
		copy->points = polyline->points;
		return copy;
	}

	template<class K2>
	static void* Convert(void* ptr)
	{
		typedef CGAL::Cartesian_converter<K, K2> Converter;
		Converter convert;

		auto polyline = CastToPolyline3(ptr);
		auto count = polyline->points.size();

		auto polyline2 = new Polyline3<K2>();

		for (auto i = 0; i < count; i++)
		{
			auto p = convert(polyline->points[i]);
			polyline2->points.push_back(p);
		}

		return polyline2;
	}

	static void Clear(void* ptr)
	{
		auto polyline = CastToPolyline3(ptr);
		polyline->points.clear();
	}

	static int Count(void* ptr)
	{
		auto polyline = CastToPolyline3(ptr);
		return (int)polyline->points.size();
	}

	static int Capacity(void* ptr)
	{
		auto polyline = CastToPolyline3(ptr);
		return (int)polyline->points.capacity();
	}

	static void Resize(void* ptr, int count)
	{
		auto polyline = CastToPolyline3(ptr);
		polyline->points.resize(count);
	}

	static void Reverse(void* ptr)
	{
		auto polyline = CastToPolyline3(ptr);
		std::reverse(polyline->points.begin(), polyline->points.end());
	}

	static void ShrinkToFit(void* ptr)
	{
		auto polyline = CastToPolyline3(ptr);
		polyline->points.shrink_to_fit();
	}

	static void Erase(void* ptr, int index)
	{
		auto polyline = CastToPolyline3(ptr);

		if (polyline->OutOfRange(index))
			return;

		polyline->points.erase(polyline->points.begin() + index);
	}

	static void Erase(void* ptr, int start, int count)
	{
		auto polyline = CastToPolyline3(ptr);

		if (polyline->OutOfRange(start) ||
			polyline->OutOfRange(start + count))
			return;

		polyline->points.erase(polyline->points.begin() + start, polyline->points.begin() + count);
	}

	static void Insert(void* ptr, int index, Point3d point)
	{
		auto polyline = CastToPolyline3(ptr);

		if (polyline->OutOfRange(index))
			return;

		polyline->points.insert(polyline->points.begin() + index, point.ToCGAL<K>());
	}

	static void Insert(void* ptr, int start, int count, Point3d* points)
	{
		auto polyline = CastToPolyline3(ptr);

		if (polyline->OutOfRange(start))
			return;

		std::vector<Point_3> tmp(count);
		for (int i = 0; i < count; i++)
			tmp.push_back(points[i].ToCGAL<K>());

		polyline->points.insert(polyline->points.begin() + start, tmp.begin(), tmp.end());
	}

	static BOOL IsClosed(void* ptr, double threshold)
	{
		auto polyline = CastToPolyline3(ptr);

		auto size = polyline->points.size();
		if (size < 2)
			return false;

		auto start = polyline->points[0];
		auto end = polyline->points[size - 1];

		auto sqdist = CGAL::to_double(CGAL::squared_distance(start, end));
		auto sqthreshold = threshold * threshold;

		return sqdist <= sqthreshold;
	}

	static double SqLength(void* ptr)
	{
		auto polyline = CastToPolyline3(ptr);

		auto count = polyline->points.size();
		if (count < 2) return 0;

		auto sum = CGAL::squared_distance(polyline->points[0], polyline->points[1]);

		for (auto i = 1; i < count - 1; i++)
			sum += CGAL::squared_distance(polyline->points[i], polyline->points[i + 1]);

		return CGAL::to_double(sum);
	}

	static Point3d GetPoint(void* ptr, int index)
	{
		auto polyline = CastToPolyline3(ptr);

		if (polyline->OutOfRange(index))
			return { 0, 0 };

		auto point = polyline->points[index];
		return Point3d::FromCGAL<K>(point);
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto polyline = CastToPolyline3(ptr);

		auto size = polyline->points.size();
		if (size == 0) return;

		for (auto i = 0; i < count; i++)
		{
			auto point = polyline->points[i];
			points[i] = Point3d::FromCGAL<K>(point);

			if (i >= size) return;
		}
	}

	static void GetPoints(Polyline3* polyline, std::vector<Point3d>& points)
	{
		int count = (int)polyline->points.size();
		for (auto i = 0; i < count; i++)
		{
			auto point = polyline->points[i];
			points.push_back(Point3d::FromCGAL<K>(point));
		}
	}

	static void GetSegments(void* ptr, Segment3d* segments, int count)
	{
		auto polyline = CastToPolyline3(ptr);
		auto size = polyline->points.size();
		if (size == 0) return;

		for (auto i = 0; i < count - 1; i++)
		{
			auto v0 = polyline->points[i];
			auto v1 = polyline->points[i + 1];

			segments[i].a = Point3d::FromCGAL<K>(v0);
			segments[i].b = Point3d::FromCGAL<K>(v1);

			if (i >= size) return;
		}
	}

	static void SetPoint(void* ptr, int index, const Point3d& point)
	{
		auto polyline = CastToPolyline3(ptr);

		if (polyline->OutOfRange(index))
			return;

		polyline->points[index] = point.ToCGAL<K>();
	}

	static void SetPoints(void* ptr, Point3d* points, int count)
	{
		auto polyline = CastToPolyline3(ptr);
		auto size = polyline->points.size();

		for (int i = 0; i < count; i++)
		{
			if (i < size)
				polyline->points[i] = points[i].ToCGAL<K>();
			else
			{
				//Adding more points than polyline currently contains
				//so push back instead.
				polyline->points.push_back(points[i].ToCGAL<K>());
			}
		}
	}

	static void Transform(void* ptr, const Matrix4x4d& matrix)
	{
		auto polyline = CastToPolyline3(ptr);
		auto m = matrix.ToCGAL<K>();

		std::transform(polyline->points.begin(), polyline->points.end(), polyline->points.begin(), m);
	}

};





