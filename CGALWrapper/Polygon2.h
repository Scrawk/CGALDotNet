#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

#include <CGAL/enum.h> 
#include <CGAL/Polygon_2.h>
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Vector_2.h>
#include <CGAL/Direction_2.h>

template<class K>
class Polygon2
{

private:

	Polygon2() {}

public:

	typedef CGAL::Polygon_2<K> Polygon_2;
	typedef CGAL::Aff_transformation_2<K> Transformation_2;

	inline static Polygon_2* CastToPolygon2(void* ptr)
	{
		return static_cast<Polygon_2*>(ptr);
	}

	inline static Polygon_2* CreatePolygon2()
	{
		return new Polygon_2();
	}

	inline static Polygon_2* CreatePolygon2(const Polygon_2& poly)
	{
		return new Polygon_2(poly);
	}

	static int Count(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return (int)polygon->size();
	}

	static void* Copy(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return new Polygon_2(*polygon);
	}

	static void Clear(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		polygon->clear();
	}

	static void* CreateFromPoints(Point2d* points, int startIndex, int count)
	{
		auto polygon = new Polygon_2();

		for (auto i = startIndex; i < count; i++)
			polygon->push_back(points[i].To<K>());

		return polygon;
	}

	static Point2d GetPoint(void* ptr, int index)
	{
		auto polygon = CastToPolygon2(ptr);
		auto point = polygon->vertex(index);

		return { CGAL::to_double(point.x()), CGAL::to_double(point.y()) };
	}

	static void GetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto polygon = CastToPolygon2(ptr);

		for (auto i = 0; i < count; i++)
		{
			auto point = polygon->vertex(i);
			points[startIndex + i].x = CGAL::to_double(point.x());
			points[startIndex + i].y = CGAL::to_double(point.y());
		}
	}

	static void SetPoint(void* ptr, int index, Point2d point)
	{
		auto polygon = CastToPolygon2(ptr);
		(*polygon)[index] = CGAL::Point_2<K>(point.x, point.y);
	}

	static void SetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto polygon = CastToPolygon2(ptr);
		auto size = polygon->size();

		for (auto i = 0; i < count; i++)
		{
			int index = startIndex + i;

			if (index < size)
				(*polygon)[i] = points[index].To<K>();
			else
				polygon->push_back(points[index].To<K>());
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

	static CGAL::Oriented_side OrientedSide(void* ptr, Point2d point)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->oriented_side(point.To<K>());
	}

	static double SignedArea(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return CGAL::to_double(polygon->area());
	}

	static void Translate(void* ptr, Point2d translation)
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

	static void Transform(void* ptr, Point2d translation, double rotation, double scale)
	{
		auto polygon = CastToPolygon2(ptr);

		Transformation_2 T(CGAL::TRANSLATION, translation.ToVector<K>());
		Transformation_2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
		Transformation_2 S(CGAL::SCALING, scale);

		(*polygon) = CGAL::transform(T * R * S, *polygon);
	}

	static BOOL ContainsPoint(void* ptr, Point2d point, CGAL::Orientation orientation, BOOL inculdeBoundary)
	{
		auto polygon = CastToPolygon2(ptr);

		auto side = polygon->oriented_side(point.To<K>());

		if (inculdeBoundary && side == CGAL::Oriented_side::ON_ORIENTED_BOUNDARY)
			return true;

		return side == orientation;
	}

};





