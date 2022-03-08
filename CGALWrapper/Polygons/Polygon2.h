#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/enum.h> 
#include <CGAL/Polygon_2.h>
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Direction_2.h>
#include <CGAL/Cartesian_converter.h>

template<class K>
class Polygon2
{

public:

	Polygon2() {}

	typedef CGAL::Point_2<K> Point_2;
	typedef CGAL::Segment_2<K> Segment_2;
	typedef CGAL::Polygon_2<K> Polygon_2;
	typedef CGAL::Aff_transformation_2<K> Transformation_2;
	
	inline static Polygon_2* NewPolygon2()
	{
		return new Polygon_2();
	}

	inline static void DeletePolygon2(void* ptr)
	{
		auto obj = static_cast<Polygon_2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static Polygon_2* CastToPolygon2(void* ptr)
	{
		return static_cast<Polygon_2*>(ptr);
	}

	inline static Polygon_2* CreatePolygon2(const Polygon_2& poly)
	{
		return new Polygon_2(poly);
	}

	inline static bool OutOfRange(Polygon_2* poly, int index)
	{
		if (index < 0 || index >= poly->size())
			return true;
		else
			return false;
	}

	static int Count(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return (int)polygon->size();
	}

	static Box2d GetBoundingBox(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		auto box = polygon->bbox();
		return Box2d::FromCGAL<K>(box);
	}

	static void* Copy(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return new Polygon_2(*polygon);
	}

	template<class K2>
	static void* Convert(void* ptr)
	{
		typedef CGAL::Cartesian_converter<K, K2> Converter;
		Converter convert;

		auto polygon = CastToPolygon2(ptr);
		auto count = polygon->size();

		auto poly2 = new CGAL::Polygon_2<K2>();

		for (auto i = 0; i < count; i++)
		{
			auto p = convert(polygon->vertex(i));
			poly2->push_back(p);
		}

		return poly2;
	}

	static void Clear(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		polygon->clear();
	}

	static int Capacity(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return (int)polygon->container().capacity();
	}

	static void Resize(void* ptr, int count)
	{
		auto polygon = CastToPolygon2(ptr);
		polygon->container().resize(count);
	}

	static void ShrinkToFit(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		polygon->container().shrink_to_fit();
	}

	static void Erase(void* ptr, int index)
	{
		auto polygon = CastToPolygon2(ptr);

		if (OutOfRange(polygon, index))
			return;

		polygon->container().erase(polygon->container().begin() + index);
	}

	static void Erase(void* ptr, int start, int count)
	{
		auto polygon = CastToPolygon2(ptr);

		if (OutOfRange(polygon, start) ||
			OutOfRange(polygon, start + count))
			return;

		polygon->container().erase(polygon->container().begin() + start, polygon->container().begin() + count);
	}

	static void Insert(void* ptr, int index, Point2d point)
	{
		auto polygon = CastToPolygon2(ptr);

		if (OutOfRange(polygon, index))
			return;

		polygon->container().insert(polygon->container().begin() + index, point.ToCGAL<K>());
	}

	static void Insert(void* ptr, int start, int count, Point2d* points)
	{
		auto polygon = CastToPolygon2(ptr);

		if (OutOfRange(polygon, start))
			return;

		std::vector<Point_2> tmp(count);
		for (int i = 0; i < count; i++)
			tmp.push_back(points[i].ToCGAL<K>());

		polygon->container().insert(polygon->container().begin() + start, tmp.begin(), tmp.end());
	}

	static double SqPerimeter(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);

		auto count = polygon->container().size();
		if (count < 2) return 0;

		auto sum = CGAL::squared_distance(polygon->vertex(0), polygon->vertex(1));

		for (auto i = 1; i < count - 1; i++)
			sum += CGAL::squared_distance(polygon->vertex(i), polygon->vertex(i + 1));

		return CGAL::to_double(sum);
	}

	static Point2d GetPoint(void* ptr, int index)
	{
		auto polygon = CastToPolygon2(ptr);
		if (OutOfRange(polygon, index)) 
			return { 0, 0};

		auto point = polygon->vertex(index);

		return Point2d::FromCGAL<K>(point);
	}

	static void GetPoints(void* ptr, Point2d* points, int count)
	{
		auto polygon = CastToPolygon2(ptr);

		auto size = polygon->size();
		if (size == 0) return;

		for (auto i = 0; i < count; i++)
		{
			auto point = polygon->vertex(i);
			points[i] = Point2d::FromCGAL<K>(point);

			if (i >= size) return;
		}
	}

	static void GetPoints(Polygon_2* polygon, std::vector<Point2d>& points)
	{
		int count = (int)polygon->size();
		for (auto i = 0; i < count; i++)
		{
			auto point = polygon->vertex(i);
			points.push_back(Point2d::FromCGAL<K>(point));
		}
	}

	inline static int Wrap(int v, int count)
	{
		int r = v % count;
		return r < 0 ? r + count : r;
	}

	static void GetSegments(void* ptr, Segment2d* segments, int count)
	{
		auto polygon = CastToPolygon2(ptr);

		auto size = polygon->size();
		if (size == 0) return;

		for (auto i = 0; i < count; i++)
		{
			int i0 = Wrap(i + 0, count);
			int i1 = Wrap(i + 1, count);

			auto v0 = polygon->vertex(i0);
			auto v1 = polygon->vertex(i1);

			segments[i].a = Point2d::FromCGAL<K>(v0);
			segments[i].b = Point2d::FromCGAL<K>(v1);

			if (i >= size) return;
		}
	}

	static void SetPoint(void* ptr, int index, const Point2d& point)
	{
		auto polygon = CastToPolygon2(ptr);
		if (OutOfRange(polygon, index)) return;

		(*polygon)[index] = point.ToCGAL<K>();
	}

	static void SetPoints(void* ptr, Point2d* points, int count)
	{
		auto polygon = CastToPolygon2(ptr);
		auto size = polygon->size();

		for (int i = 0; i < count; i++)
		{
			if (i < size)
				(*polygon)[i] = points[i].ToCGAL<K>();
			else
			{
				//Adding more points than polygon currently contains
				//so push back instead.
				polygon->push_back(points[i].ToCGAL<K>());
			}
		}
	}

	static void Reverse(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		polygon->reverse_orientation();
	}

	static BOOL IsSimple(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->is_simple();
	}

	static BOOL IsConvex(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->is_convex();
	}

	static CGAL::Orientation Orientation(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->orientation();
	}

	static CGAL::Oriented_side OrientedSide(void* ptr, const Point2d& point)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->oriented_side(point.ToCGAL<K>());
	}

	static CGAL::Bounded_side BoundedSide(void* ptr, const Point2d& point)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->bounded_side(point.ToCGAL<K>());
	}

	static double SignedArea(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return CGAL::to_double(polygon->area());
	}

	static void Translate(void* ptr, const Point2d& translation)
	{
		auto polygon = CastToPolygon2(ptr);
		Transformation_2 transformation(CGAL::TRANSLATION, translation.ToVector<K>());
		(*polygon) = CGAL::transform(transformation, *polygon);
	}

	static void Rotate(void* ptr, double rotation)
	{
		auto polygon = CastToPolygon2(ptr);
		Transformation_2 transformation(CGAL::ROTATION, sin(rotation), cos(rotation));
		(*polygon) = CGAL::transform(transformation, *polygon);
	}

	static void Scale(void* ptr, double scale)
	{
		auto polygon = CastToPolygon2(ptr);
		Transformation_2 transformation(CGAL::SCALING, scale);
		(*polygon) = CGAL::transform(transformation, *polygon);
	}

	static void Transform(void* ptr, const Point2d& translation, double rotation, double scale)
	{
		auto polygon = CastToPolygon2(ptr);

		Transformation_2 T(CGAL::TRANSLATION, translation.ToVector<K>());
		Transformation_2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
		Transformation_2 S(CGAL::SCALING, scale);

		(*polygon) = CGAL::transform(T * R * S, *polygon);
	}

	static BOOL ContainsPoint(void* ptr, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary)
	{
		auto polygon = CastToPolygon2(ptr);

		auto side = polygon->oriented_side(point.ToCGAL<K>());

		if (inculdeBoundary && side == CGAL::Oriented_side::ON_ORIENTED_BOUNDARY)
			return true;

		return side == orientation;
	}

};





