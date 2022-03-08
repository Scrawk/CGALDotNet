#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/connect_holes.h>
#include <CGAL/enum.h>
#include <CGAL/Cartesian_converter.h>

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

	static Pwh_2* NewPolygonWithHoles2()
	{
		return new Pwh_2();
	}

	static Pwh_2* NewPolygonWithHoles2(Pwh_2* pwh)
	{
		return new Pwh_2(*pwh);
	}

	static void DeletePolygonWithHoles2(void* ptr)
	{
		auto obj = static_cast<Pwh_2*>(ptr);

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

	inline static Pwh_2* CastToPolygonWithHoles2(void* ptr)
	{
		return static_cast<Pwh_2*>(ptr);
	}

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

	static int HoleCount(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		return pwh->number_of_holes();
	}

	static int PointCount(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
			return (int)polygon->size();
		else
			return 0;
	}

	static void* Copy(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		return new Pwh_2(*pwh);
	}

	static Pwh_2* Copy(Pwh_2& pwh)
	{
		return new Pwh_2(pwh);
	}

	template<class K2>
	static void* Convert(void* ptr)
	{
		typedef CGAL::Cartesian_converter<K, K2> Converter;
		Converter convert;

		auto pwh = CastToPolygonWithHoles2(ptr);

		auto pwh2 = new CGAL::Polygon_with_holes_2<K2>();

		if (!pwh->is_unbounded())
		{
			auto count = pwh->outer_boundary().size();
			for (auto i = 0; i < count; i++)
			{
				auto p = convert(pwh->outer_boundary().vertex(i));
				pwh2->outer_boundary().push_back(p);
			}
		}

		for (auto& hole : pwh->holes())
		{
			auto count = hole.size();
			auto hole2 = CGAL::Polygon_2<K2>();

			for (auto i = 0; i < count; i++)
			{
				auto p = convert(hole.vertex(i));
				hole2.push_back(p);
			}

			pwh2->add_hole(hole2);
		}

		return pwh2;
	}

	static void Clear(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		pwh->clear();
	}

	static void ClearBoundary(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		pwh->outer_boundary().clear();
	}

	static void ClearHoles(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		pwh->holes().clear();
	}

	static void* CreateFromPolygon(void* ptr)
	{
		auto polygon = CastToPolygon2(ptr);
		return new Pwh_2(*polygon);
	}

	static void* CreateFromPoints(Point2d* points, int count)
	{
		auto polygon = Polygon_2();

		for (auto i = 0; i < count; i++)
			polygon.push_back(points[i].ToCGAL<K>());

		return new Pwh_2(polygon);
	}

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

	static void SetPoint(void* ptr, int polyIndex, int pointIndex, const Point2d& point)
	{
		auto polygon = GetBoundaryOrHole(ptr, polyIndex);
		if (polygon != nullptr)
		{
			auto size = polygon->size();
			if (pointIndex < 0 || pointIndex >= size)
				return;

			(*polygon)[pointIndex] = Point_2(point.x, point.y);
		}
	}

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

	static void AddHoleFromPolygon(void* pwhPtr, void* polygonPtr)
	{
		auto pwh = (Pwh_2*)pwhPtr;
		auto polygon = (Polygon_2*)polygonPtr;
		pwh->add_hole(*polygon);
	}

	static void AddHoleFromPoints(void* ptr, Point2d* points, int count)
	{
		auto pwh = (Pwh_2*)ptr;
		auto polygon = Polygon_2();

		for (int i = 0; i < count; i++)
			polygon.push_back(points[i].ToCGAL<K>());

		pwh->add_hole(polygon);
	}

	static void RemoveHole(void* ptr, int index)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		pwh->erase_hole(pwh->holes_begin() + index);
	}

	static void* CopyPolygon(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
			return new Polygon_2(*polygon);
		else
			return nullptr;
	}

	static void ReversePolygon(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
			return polygon->reverse_orientation();
	}

	static BOOL IsUnbounded(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);
		return pwh->is_unbounded();
	}

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

	static BOOL IsSimple(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
			return polygon->is_simple();
		else
			return false;
	}

	static BOOL IsConvex(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr && polygon->is_simple())
			return polygon->is_convex();
		else
			return false;
	}

	static CGAL::Orientation Orientation(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr && polygon->is_simple())
			return polygon->orientation();
		else
			return CGAL::Orientation::DEGENERATE;
	}

	static CGAL::Oriented_side OrientedSide(void* ptr, int index, const Point2d& point)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr && polygon->is_simple())
			return polygon->oriented_side(point.ToCGAL<K>());
		else
			return CGAL::Oriented_side::DEGENERATE;
	}

	static double SignedArea(void* ptr, int index)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr && polygon->is_simple())
			return CGAL::to_double(polygon->area());
		else
			return 0;
	}

	static void Translate(void* ptr, int index, const Point2d& translation)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
		{
			CGAL::Aff_transformation_2<K> transformation(CGAL::TRANSLATION, translation.ToVector<K>());
			(*polygon) = CGAL::transform(transformation, *polygon);
		}
	}

	static void Rotate(void* ptr, int index, double rotation)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
		{
			CGAL::Aff_transformation_2<K> transformation(CGAL::ROTATION, sin(rotation), cos(rotation));
			(*polygon) = CGAL::transform(transformation, *polygon);
		}
	}

	static void Scale(void* ptr, int index, double scale)
	{
		auto polygon = GetBoundaryOrHole(ptr, index);
		if (polygon != nullptr)
		{
			CGAL::Aff_transformation_2<K> transformation(CGAL::SCALING, scale);
			(*polygon) = CGAL::transform(transformation, *polygon);
		}
	}

	static void Transform(void* ptr, int index, const Point2d& translation, double rotation, double scale)
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

	static BOOL ContainsPoint(void* ptr, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary)
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

	static BOOL ContainsPoint(Pwh_2& pwh, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary)
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

	static void* ConnectHoles(void* ptr)
	{
		auto pwh = CastToPolygonWithHoles2(ptr);

		std::list<Point_2> pts;
		CGAL::connect_holes(*pwh, std::back_inserter(pts));

		return new Polygon_2(pts.begin(), pts.end());
	}

private:

	static BOOL ContainsPoint(Polygon_2& polygon, bool isBoundary, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary)
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



