#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

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
	typedef CGAL::Segment_2<K> Segment_2;

	/// <summary>
	/// Create a new polygon object.
	/// </summary>
	/// <returns>The new polygon object.</returns>
	inline static Polygon_2* NewPolygon2()
	{
		return new Polygon_2();
	}

	/// <summary>
	/// Delete the polygon object.
	/// </summary>
	/// <param name="ptr">A pointer to the polygon.</param>
	inline static void DeletePolygon2(void* ptr)
	{
		auto obj = static_cast<Polygon_2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	/// <summary>
	/// Cast pointer to polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <returns>The polygon.</returns>
	inline static Polygon_2* CastToPolygon2(void* ptr)
	{
		return static_cast<Polygon_2*>(ptr);
	}

	/// <summary>
	/// Create a new polygon from a copy of 
	/// a existing polygon.
	/// </summary>
	/// <param name="poly">The polygon to copy.</param>
	/// <returns>The new polygon object.</returns>
	inline static Polygon_2* CreatePolygon2(const Polygon_2& poly)
	{
		return new Polygon_2(poly);
	}

	/// <summary>
	/// Return the number of points in the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <returns>The number of points in the polygon.</returns>
	static int Count(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return (int)polygon->size();
	}

	/// <summary>
	/// Get the polygons bounding box.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <returns>The bounding box.</returns>
	static Box2d GetBoundingBox(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		auto box = polygon->bbox();
		return Box2d::FromCGAL<K>(box);
	}

	/// <summary>
	/// Create a deep copy of the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer to copy.</param>
	/// <returns>The pointer to the new polygon.</returns>
	static void* Copy(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return new Polygon_2(*polygon);
	}

	/// <summary>
	/// Clear the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	static void Clear(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		polygon->clear();
	}

	/// <summary>
	/// Get a point from the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="index">The points index.</param>
	/// <returns>The point.</returns>
	static Point2d GetPoint(void* ptr, int index)
	{
		auto polygon = CastToPolygon2(ptr);
		auto point = polygon->vertex(index);

		return Point2d::FromCGAL<K>(point);
	}

	/// <summary>
	/// Copy all the points in the polygon into the array.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="points">The points array pointer.</param>
	/// <param name="startIndex">The index in the array to start at.</param>
	/// <param name="count">The number of points to copy.</param>
	static void GetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto polygon = CastToPolygon2(ptr);

		for (auto i = 0; i < count; i++)
		{
			auto point = polygon->vertex(i);
			points[startIndex + i] = Point2d::FromCGAL<K>(point);
		}
	}

	inline static int Wrap(int v, int count)
	{
		int r = v % count;
		return r < 0 ? r + count : r;
	}

	/// <summary>
	/// Copy all the points as segments in the poylgon onto the array.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="segments">The segment array.</param>
	/// <param name="startIndex">The index in the array to start at.</param>
	/// <param name="count">The number of points to copy.</param>
	static void GetSegments(void* ptr, Segment2d* segments, int startIndex, int count)
	{
		auto polygon = CastToPolygon2(ptr);

		for (auto i = 0; i < count; i++)
		{
			int i0 = Wrap(i + 0, count);
			int i1 = Wrap(i + 1, count);

			auto v0 = polygon->vertex(i0);
			auto v1 = polygon->vertex(i1);

			segments[startIndex + i].a = Point2d::FromCGAL<K>(v0);
			segments[startIndex + i].b = Point2d::FromCGAL<K>(v1);
		}
	}

	/// <summary>
	/// Set a point in the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="index">The points index.</param>
	/// <param name="point">The points value.</param>
	static void SetPoint(void* ptr, int index, Point2d point)
	{
		auto polygon = CastToPolygon2(ptr);
		(*polygon)[index] = point.ToCGAL<K>();
	}

	/// <summary>
	/// Set the points in a polygon from a array.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="points">The point array.</param>
	/// <param name="startIndex">The index in the array to start at.</param>
	/// <param name="count">The number of points to copy.</param>
	static void SetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto polygon = CastToPolygon2(ptr);
		auto size = polygon->size();

		for (auto i = 0; i < count; i++)
		{
			int index = startIndex + i;

			if (index < size)
				(*polygon)[i] = points[index].ToCGAL<K>();
			else
			{
				//Adding more points than poygon currently contains
				//so push back instead.
				polygon->push_back(points[index].ToCGAL<K>());
			}
		}
	}

	/// <summary>
	/// Reverse the order of the points in the poylgon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	static void Reverse(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		polygon->reverse_orientation();
	}

	/// <summary>
	/// Is this a simple polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <returns>true if simple.</returns>
	static BOOL IsSimple(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->is_simple();
	}

	/// <summary>
	/// Is this a convex polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <returns>True if convex.</returns>
	static BOOL IsConvex(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->is_convex();
	}

	/// <summary>
	/// The orientation of the polygon.
	/// Same as the polygons clock direction.
	/// Positive == CCW
	/// Negative == CW
	/// Zero == Degenerate
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <returns>The orientation of the polygon.</returns>
	static CGAL::Orientation Orientation(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->orientation();
	}

	/// <summary>
	/// Determine what side the point is on the polygons side.
	/// Used in Contains point.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="point">The point.</param>
	/// <returns>Orientated side of point.</returns>
	static CGAL::Oriented_side OrientedSide(void* ptr, Point2d point)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->oriented_side(point.ToCGAL<K>());
	}

	/// <summary>
	/// Determine what side the point is on the polygons side.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="point">The point.</param>
	/// <returns>Bounded side of point.</returns>
	static CGAL::Bounded_side BoundedSide(void* ptr, Point2d point)
	{
		auto polygon = CastToPolygon2(ptr);
		return polygon->bounded_side(point.ToCGAL<K>());
	}

	/// <summary>
	/// The signed area of the polygon.
	/// Positive area for CCW polygons and negative for CW.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <returns>The signed area of the polygon.</returns>
	static double SignedArea(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return CGAL::to_double(polygon->area());
	}

	/// <summary>
	/// Translate the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="translation">The amount to translate.</param>
	static void Translate(void* ptr, Point2d translation)
	{
		auto polygon = CastToPolygon2(ptr);
		Transformation_2 transformation(CGAL::TRANSLATION, translation.ToVector<K>());
		(*polygon) = CGAL::transform(transformation, *polygon);
	}

	/// <summary>
	/// Rotate the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="rotation">The amount to rotate in radians.</param>
	static void Rotate(void* ptr, double rotation)
	{
		auto polygon = CastToPolygon2(ptr);
		Transformation_2 transformation(CGAL::ROTATION, sin(rotation), cos(rotation));
		(*polygon) = CGAL::transform(transformation, *polygon);
	}

	/// <summary>
	/// Scale the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="scale">The amount to scale.</param>
	static void Scale(void* ptr, double scale)
	{
		auto polygon = CastToPolygon2(ptr);
		Transformation_2 transformation(CGAL::SCALING, scale);
		(*polygon) = CGAL::transform(transformation, *polygon);
	}

	/// <summary>
	/// Translate, rotate and scale the poylgon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="translation">The amount to translate.</param>
	/// <param name="rotation">The amount to rotate in radians.</param>
	/// <param name="scale">The amount to scale.</param>
	static void Transform(void* ptr, Point2d translation, double rotation, double scale)
	{
		auto polygon = CastToPolygon2(ptr);

		Transformation_2 T(CGAL::TRANSLATION, translation.ToVector<K>());
		Transformation_2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
		Transformation_2 S(CGAL::SCALING, scale);

		(*polygon) = CGAL::transform(T * R * S, *polygon);
	}

	/// <summary>
	/// Determine if the point is contained inside the polygon.
	/// </summary>
	/// <param name="ptr">The polygon pointer.</param>
	/// <param name="point">The point.</param>
	/// <param name="orientation">The orientation of the polygon.</param>
	/// <param name="inculdeBoundary">If the point is on the boundary does this count as being contained.</param>
	/// <returns>Does the polygon contain the point.</returns>
	static BOOL ContainsPoint(void* ptr, Point2d point, CGAL::Orientation orientation, BOOL inculdeBoundary)
	{
		auto polygon = CastToPolygon2(ptr);

		auto side = polygon->oriented_side(point.ToCGAL<K>());

		if (inculdeBoundary && side == CGAL::Oriented_side::ON_ORIENTED_BOUNDARY)
			return true;

		return side == orientation;
	}

};





