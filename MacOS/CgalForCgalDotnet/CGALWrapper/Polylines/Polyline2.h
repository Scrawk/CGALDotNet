#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <vector>
#include <algorithm>
#include <CGAL/enum.h> 
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Cartesian_converter.h>

template<class K>
class Polyline2
{

public:

	Polyline2()
	{

	}

	Polyline2(int count)
	{
		points.resize(count);
	}

	typedef CGAL::Point_2<K> Point_2;
	typedef CGAL::Segment_2<K> Segment_2;
	typedef CGAL::Aff_transformation_2<K> Transformation_2;
	
	std::vector<Point_2> points;

	inline static Polyline2* NewPolyline2()
	{
		return new Polyline2();

	}

	inline static Polyline2* NewPolyline2(int count)
	{
		return new Polyline2(count);
	}

	inline static void DeletePolyline2(void* ptr)
	{
		auto obj = static_cast<Polyline2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static Polyline2* CastToPolyline2(void* ptr)
	{
		return static_cast<Polyline2*>(ptr);
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
		auto polyline = CastToPolyline2(ptr);
		auto copy = new Polyline2();
		copy->points = polyline->points;
		return copy;
	}

	template<class K2>
	static void* Convert(void* ptr)
	{
		typedef CGAL::Cartesian_converter<K, K2> Converter;
		Converter convert;

		auto polyline = CastToPolyline2(ptr);
		auto count = polyline->points.size();

		auto polyline2 = new Polyline2<K2>();

		for (auto i = 0; i < count; i++)
		{
			auto p = convert(polyline->points[i]);
			polyline2->points.push_back(p);
		}

		return polyline2;
	}

	static void Clear(void* ptr)
	{
		auto polyline = CastToPolyline2(ptr);
		polyline->points.clear();
	}

	static int Count(void* ptr)
	{
		auto polyline = CastToPolyline2(ptr);
		return (int)polyline->points.size();
	}

	static int Capacity(void* ptr)
	{
		auto polyline = CastToPolyline2(ptr);
		return (int)polyline->points.capacity();
	}

	static void Resize(void* ptr, int count)
	{
		auto polyline = CastToPolyline2(ptr);
		polyline->points.resize(count);
	}

	static void Reverse(void* ptr)
	{
		auto polyline = CastToPolyline2(ptr);
		std::reverse(polyline->points.begin(), polyline->points.end());
	}

	static void ShrinkToFit(void* ptr)
	{
		auto polyline = CastToPolyline2(ptr);
		polyline->points.shrink_to_fit();
	}

	static void Erase(void* ptr, int index)
	{
		auto polyline = CastToPolyline2(ptr);

		if (polyline->OutOfRange(index))
			return;

		polyline->points.erase(polyline->points.begin() + index);
	}

	static void Erase(void* ptr, int start, int count)
	{
		auto polyline = CastToPolyline2(ptr);

		if (polyline->OutOfRange(start) ||
			polyline->OutOfRange(start + count))
			return;

		polyline->points.erase(polyline->points.begin() + start, polyline->points.begin() + count);
	}

	static void Insert(void* ptr, int index, Point2d point)
	{
		auto polyline = CastToPolyline2(ptr);

		if (polyline->OutOfRange(index))
			return;

		polyline->points.insert(polyline->points.begin() + index, point.ToCGAL<K>());
	}

	static void Insert(void* ptr, int start, int count, Point2d* points)
	{
		auto polyline = CastToPolyline2(ptr);

		if (polyline->OutOfRange(start))
			return;

		std::vector<Point_2> tmp(count);
		for (int i = 0; i < count; i++)
			tmp.push_back(points[i].ToCGAL<K>());

		polyline->points.insert(polyline->points.begin() + start, tmp.begin(), tmp.end());
	}

	static BOOL IsClosed(void* ptr, double threshold)
	{
		auto polyline = CastToPolyline2(ptr);
		
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
		auto polyline = CastToPolyline2(ptr);

		auto count = polyline->points.size();
		if (count < 2) return 0;

		auto sum = CGAL::squared_distance(polyline->points[0], polyline->points[1]);
	
		for (auto i = 1; i < count - 1; i++)
			sum += CGAL::squared_distance(polyline->points[i], polyline->points[i + 1]);

		return CGAL::to_double(sum);
	}

	static Point2d GetPoint(void* ptr, int index)
	{
		auto polyline = CastToPolyline2(ptr);

		if (polyline->OutOfRange(index))
			return { 0, 0 };

		auto point = polyline->points[index];
		return Point2d::FromCGAL<K>(point);
	}

	static void GetPoints(void* ptr, Point2d* points, int count)
	{
		auto polyline = CastToPolyline2(ptr);

		auto size = polyline->points.size();
		if (size == 0) return;

		for (auto i = 0; i < count; i++)
		{
			auto point = polyline->points[i];
			points[i] = Point2d::FromCGAL<K>(point);

			if (i >= size) return;
		}
	}

	static void GetPoints(Polyline2* polyline, std::vector<Point2d>& points)
	{
		int count = (int)polyline->points.size();
		for (auto i = 0; i < count; i++)
		{
			auto point = polyline->points[i];
			points.push_back(Point2d::FromCGAL<K>(point));
		}
	}

	static void GetSegments(void* ptr, Segment2d* segments, int count)
	{
		auto polyline = CastToPolyline2(ptr);
		auto size = polyline->points.size();
		if (size == 0) return;

		for (auto i = 0; i < count-1; i++)
		{
			auto v0 = polyline->points[i];
			auto v1 = polyline->points[i+1];

			segments[i].a = Point2d::FromCGAL<K>(v0);
			segments[i].b = Point2d::FromCGAL<K>(v1);

			if (i >= size) return;
		}
	}

	static void SetPoint(void* ptr, int index, const Point2d& point)
	{
		auto polyline = CastToPolyline2(ptr);

		if (polyline->OutOfRange(index))
			return;

		polyline->points[index] = point.ToCGAL<K>();
	}

	static void SetPoints(void* ptr, Point2d* points, int count)
	{
		auto polyline = CastToPolyline2(ptr);
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

	static void Translate(void* ptr, const Point2d& translation)
	{
		auto polyline = CastToPolyline2(ptr);
		Transformation_2 transformation(CGAL::TRANSLATION, translation.ToVector<K>());

		for(int i = 0; i < polyline->points.size(); i++)
			polyline->points[i] = transformation(polyline->points[i]);
	}

	static void Rotate(void* ptr, double rotation)
	{
		auto polyline = CastToPolyline2(ptr);
		Transformation_2 transformation(CGAL::ROTATION, sin(rotation), cos(rotation));
		
		for (int i = 0; i < polyline->points.size(); i++)
			polyline->points[i] = transformation(polyline->points[i]);
	}

	static void Scale(void* ptr, double scale)
	{
		auto polyline = CastToPolyline2(ptr);
		Transformation_2 transformation(CGAL::SCALING, scale);
		
		for (int i = 0; i < polyline->points.size(); i++)
			polyline->points[i] = transformation(polyline->points[i]);
	}

	static void Transform(void* ptr, const Point2d& translation, double rotation, double scale)
	{
		auto polyline = CastToPolyline2(ptr);

		Transformation_2 T(CGAL::TRANSLATION, translation.ToVector<K>());
		Transformation_2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
		Transformation_2 S(CGAL::SCALING, scale);
		Transformation_2 transformation = T * R * S;

		for (int i = 0; i < polyline->points.size(); i++)
			polyline->points[i] = transformation(polyline->points[i]);
	}

};





