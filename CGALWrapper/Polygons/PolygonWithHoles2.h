#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/connect_holes.h>
#include <CGAL/enum.h>

#define BOUNDARY_INDEX -1

template<class K>
class PolygonWithHoles2
{

private:

	PolygonWithHoles2() {}

public:

	typedef CGAL::Polygon_with_holes_2<K> Pwh_2;
	typedef CGAL::Polygon_2<K> Polygon_2;
	typedef CGAL::Point_2<K> Point_2;

	/// <summary>
	/// Create a new polygon object.
	/// </summary>
	/// <returns>The new polygon object.</returns>
	static Pwh_2* NewPolygonWithHoles2()
	{
		return new Pwh_2();
	}

	static Pwh_2* NewPolygonWithHoles2(Pwh_2* pwh)
	{
		return new Pwh_2(*pwh);
	}

	/// <summary>
	/// Delete the polygon object.
	/// </summary>
	/// <param name="ptr">A pointer to the polygon.</param>
	static void DeletePolygonWithHoles2(void* ptr)
	{
		auto obj = static_cast<Pwh_2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	/// <summary>
	/// Cast the pointer to a polygon.
	/// </summary>
	/// <param name="ptr">The pointer to the polygon.</param>
	/// <returns>The polygon.</returns>
	inline static Polygon_2* CastToPolygon2(void* ptr)
	{
		return static_cast<Polygon_2*>(ptr);
	}

	/// <summary>
	/// Cast the pointer to a polygon.
	/// </summary>
	/// <param name="ptr">The pointer to the polygon.</param>
	/// <returns>The polygon.</returns>
	inline static Pwh_2* CastToPolygonWithHoles2(void* ptr)
	{
		return static_cast<Pwh_2*>(ptr);
	}

	/// <summary>
	/// Get a polygon from the polygonWithHoles.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The index of the polygon to get. 
	/// -1 for the boundary polygon and positive index for a hole.</param>
	/// <returns></returns>
	static Polygon_2* GetBoundaryOrHole(void* ptr, int index)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);

		if (index == BOUNDARY_INDEX)
		{
			if (pwh->is_unbounded())
				return nullptr;
			else
				return &pwh->outer_boundary();
		}
		else
		{
			return &pwh->holes().at(index);
		}
	}

	/// <summary>
	/// Return the number of hole polygons.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <returns>Return the number of hole polygons.</returns>
	static int HoleCount(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		return pwh->number_of_holes();
	}

	/// <summary>
	/// Return the number of points in polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <returns>Return the number of points in polygon.</returns>
	static int PointCount(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
			return (int)polygon->size();
		else
			return 0;
	}

	/// <summary>
	/// Copy the polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <returns>A pointer to the copy.</returns>
	static void* Copy(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		return new Pwh_2(*pwh);
	}

	/// <summary>
	/// Copy the polygon.
	/// </summary>
	/// <param name="pwh">a polygon with holes</param>
	/// <returns>The copy</returns>
	static Pwh_2* Copy(Pwh_2& pwh)
	{
		return new Pwh_2(pwh);
	}

	/// <summary>
	/// Clear the polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	static void Clear(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		pwh->clear();
	}

	/// <summary>
	/// Clear the boundary polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	static void ClearBoundary(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		pwh->outer_boundary().clear();
	}

	/// <summary>
	/// Create a new polygonWithHoles from other polygon.
	/// </summary>
	/// <param name="ptr">The other polygon.</param>
	/// <returns>The new polygon.</returns>
	static void* CreateFromPolygon(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return new Pwh_2(*polygon);
	}

	/// <summary>
	/// Create a new polygonWithHoles from points.
	/// </summary>
	/// <param name="points">The points</param>
	/// <param name="count">The number of points in array.</param>
	/// <returns>The new polygon.</returns>
	static void* CreateFromPoints(Point2d* points, int count)
	{
		auto polygon = Polygon_2();

		for (auto i = 0; i < count; i++)
			polygon.push_back(points[i].ToCGAL<K>());

		return new Pwh_2(polygon);
	}

	/// <summary>
	/// Get a point from the polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="polyIndex">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <param name="pointIndex">The index of the point in the polygon.</param>
	/// <returns>The point.</returns>
	static Point2d GetPoint(void* ptr, int polyIndex, int pointIndex)
	{
		auto polygon = GetBoundaryOrHole(ptr, polyIndex);
		if (polygon != nullptr)
		{
			auto point = polygon->vertex(pointIndex);
			return Point2d::FromCGAL<K>(point);
		}
		else
		{
			return { 0, 0 };
		}
	}

	/// <summary>
	/// Get all points from a polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="points">The point array to copy into.</param>
	/// <param name="polyIndex">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <param name="count">The number of points to copy.</param>
	static void GetPoints(void* ptr, Point2d* points, int polyIndex, int count)
	{
		auto polygon = GetBoundaryOrHole(ptr, polyIndex);
		if (polygon != nullptr)
		{
			for (auto i = 0; i < count; i++)
			{
				auto point = polygon->vertex(i);
				points[i] = Point2d::FromCGAL<K>(point);
			}
		}
	}

	/// <summary>
	/// Set a point in the polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="polyIndex">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <param name="pointIndex">The point index to set.</param>
	/// <param name="point">The point.</param>
	static void SetPoint(void* ptr, int polyIndex, int pointIndex, Point2d point)
	{
		auto polygon = GetBoundaryOrHole(ptr, polyIndex);
		if (polygon != nullptr)
		{
			(*polygon)[pointIndex] = Point_2(point.x, point.y);
		}
	}

	/// <summary>
	/// Set the points in a polygon from a array.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="points">The points array.</param>
	/// <param name="polyIndex">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon. </param>
	/// <param name="count">The number of points to add.</param>
	static void SetPoints(void* ptr, Point2d* points, int polyIndex, int count)
	{
		auto polygon = GetBoundaryOrHole(ptr, polyIndex);
		if (polygon != nullptr)
		{
			auto size = polygon->size();

			for (auto i = 0; i < count; i++)
			{
				if (i < size)
					(*polygon)[i] = points[i].ToCGAL<K>();
				else
				{
					//Adding more points than poygon currently contains
					//so push back instead.
					polygon->push_back(points[i].ToCGAL<K>());
				}
					
			}
		}
	}

	/// <summary>
	/// Add a hole polygon.
	/// </summary>
	/// <param name="pwhPtr">Pointer to the polygonWithHoles.</param>
	/// <param name="polygonPtr">Pointer to the hole polygon.</param>
	static void AddHoleFromPolygon(void* pwhPtr, void* polygonPtr)
	{
		auto pwh = (Pwh_2*)pwhPtr;
		auto polygon = (Polygon_2*)polygonPtr;
		pwh->add_hole(*polygon);
	}

	/// <summary>
	/// Remove a hole polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The holes index.</param>
	static void RemoveHole(void* ptr, int index)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		pwh->erase_hole(pwh->holes_begin() + index);
	}

	/// <summary>
	/// Copy the boundary or hole polygon.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <returns>The copy polygon.</returns>
	static void* CopyPolygon(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
			return new Polygon_2(*polygon);
		else
			return nullptr;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	static void ReversePolygon(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
			return polygon->reverse_orientation();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <returns></returns>
	static BOOL IsUnbounded(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		return pwh->is_unbounded();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr"></param>
	/// <param name="index"></param>
	/// <returns></returns>
	static Box2d GetBoundingBox(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
		{
			auto box = polygon->bbox();
			return Box2d::FromCGAL<K>(box);
		}
		else
			return {};
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <returns></returns>
	static BOOL IsSimple(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
			return polygon->is_simple();
		else
			return false;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <returns></returns>
	static BOOL IsConvex(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr && polygon->is_simple())
			return polygon->is_convex();
		else
			return false;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <returns></returns>
	static CGAL::Orientation Orientation(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr && polygon->is_simple())
			return polygon->orientation();
		else
			return CGAL::Orientation::DEGENERATE;
	}

	/// <summary>
	/// Return the oriented side of the point.
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <param name="point">The point.</param>
	/// <returns>Return the oriented side of the point.</returns>
	static CGAL::Oriented_side OrientedSide(void* ptr, int index, Point2d point)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr && polygon->is_simple())
			return polygon->oriented_side(point.ToCGAL<EEK>());
		else
			return CGAL::Oriented_side::DEGENERATE;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <returns></returns>
	static double SignedArea(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr && polygon->is_simple())
			return CGAL::to_double(polygon->area());
		else
			return 0;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <param name="translation"></param>
	static void Translate(void* ptr, int index, Point2d translation)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
		{
			CGAL::Aff_transformation_2<K> transformation(CGAL::TRANSLATION, translation.ToVector<K>());
			(*polygon) = CGAL::transform(transformation, *polygon);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <param name="rotation"></param>
	static void Rotate(void* ptr, int index, double rotation)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
		{
			CGAL::Aff_transformation_2<K> transformation(CGAL::ROTATION, sin(rotation), cos(rotation));
			(*polygon) = CGAL::transform(transformation, *polygon);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <param name="scale"></param>
	static void Scale(void* ptr, int index, double scale)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
		{
			CGAL::Aff_transformation_2<K> transformation(CGAL::SCALING, scale);
			(*polygon) = CGAL::transform(transformation, *polygon);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="index">The poylgon index. -1 for the boundary 
	/// and a positive index for a hole polygon.</param>
	/// <param name="translation"></param>
	/// <param name="rotation"></param>
	/// <param name="scale"></param>
	static void Transform(void* ptr, int index, Point2d translation, double rotation, double scale)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
		{
			CGAL::Aff_transformation_2<K> T(CGAL::TRANSLATION, translation.ToVector<K>());
			CGAL::Aff_transformation_2<K> R(CGAL::ROTATION, sin(rotation), cos(rotation));
			CGAL::Aff_transformation_2<K> S(CGAL::SCALING, scale);

			(*polygon) = CGAL::transform(T * R * S, *polygon);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr">Pointer to the polygonWithHoles.</param>
	/// <param name="point"></param>
	/// <param name="orientation"></param>
	/// <param name="inculdeBoundary"></param>
	/// <returns></returns>
	static BOOL ContainsPoint(void* ptr, Point2d point, CGAL::Orientation orientation, BOOL inculdeBoundary)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		auto& boundary = pwh->outer_boundary();

		if (ContainsPoint(boundary, true, point, orientation, inculdeBoundary))
		{
			for (auto& hole : pwh->holes())
			{
				if (ContainsPoint(hole, false, point, orientation, inculdeBoundary))
					return FALSE;
			}

			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="pwh">Pointer to the polygonWithHoles.</param>
	/// <param name="point"></param>
	/// <param name="orientation"></param>
	/// <param name="inculdeBoundary"></param>
	/// <returns></returns>
	static BOOL ContainsPoint(Pwh_2& pwh, Point2d point, CGAL::Orientation orientation, BOOL inculdeBoundary)
	{
		auto& boundary = pwh.outer_boundary();

		if (ContainsPoint(boundary, true, point, orientation, inculdeBoundary))
		{
			for (auto& hole : pwh.holes())
			{
				if (ContainsPoint(hole, false, point, orientation, inculdeBoundary))
					return FALSE;
			}

			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ptr"></param>
	/// <returns></returns>
	static void* ConnectHoles(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);

		std::list<Point_2> pts;
		CGAL::connect_holes(*pwh, std::back_inserter(pts));

		return new Polygon_2(pts.begin(), pts.end());
	}

private:

	/// <summary>
	/// 
	/// </summary>
	/// <param name="polygon"></param>
	/// <param name="isBoundary"></param>
	/// <param name="point"></param>
	/// <param name="orientation"></param>
	/// <param name="inculdeBoundary"></param>
	/// <returns></returns>
	static BOOL ContainsPoint(Polygon_2& polygon, bool isBoundary, Point2d point, CGAL::Orientation orientation, BOOL inculdeBoundary)
	{
		auto side = polygon.oriented_side(point.ToCGAL<K>());

		if (inculdeBoundary && side == CGAL::Oriented_side::ON_ORIENTED_BOUNDARY)
			return true;

		if(isBoundary)
			return side == orientation;
		else
			return side == (orientation * -1);
	}

};



