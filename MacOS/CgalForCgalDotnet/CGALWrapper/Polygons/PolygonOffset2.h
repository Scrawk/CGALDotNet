#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "Polygon2.h"
#include "PolygonWithHoles2.h"

#include <vector>
#include <unordered_set>
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/create_offset_polygons_2.h>
#include <CGAL/create_straight_skeleton_from_polygon_with_holes_2.h>
#include <boost/shared_ptr.hpp>

template<class K>
class PolygonOffset2
{

private:

	typedef typename K::Point_2						Point;
	typedef typename CGAL::Polygon_2<K>				Polygon_2;
	typedef typename CGAL::Polygon_2<EIK>		    Polygon_2_EIK;
	typedef CGAL::Polygon_with_holes_2<K>			Polygon_with_holes;

	typedef CGAL::Straight_skeleton_2<EIK>			Ss;
	typedef boost::shared_ptr<Ss>					SsPtr;
	typedef typename Ss::Vertex_handle				Vertex;
	typedef typename Ss::Halfedge_handle			HalfEdge;

	typedef boost::shared_ptr<Polygon_2_EIK>		PolygonPtr;
	typedef std::vector<PolygonPtr>					PolygonPtrVector;

	std::vector<Polygon_2*>  polygonBuffer;

	std::vector<Segment2d> segmentBuffer;

public:

	inline static PolygonOffset2* NewPolygonOffset2()
	{
		return new PolygonOffset2();
	}

	inline static void DeletePolygonOffset2(void* ptr)
	{
		auto obj = static_cast<PolygonOffset2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonOffset2* CastToPolygonOffset2(void* ptr)
	{
		return static_cast<PolygonOffset2*>(ptr);
	}

	static int PolygonBufferSize(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return (int)offset->polygonBuffer.size();
	}

	static int SegmentBufferSize(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return (int)offset->segmentBuffer.size();
	}

	static void ClearPolygonBuffer(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		offset->polygonBuffer.clear();
	}

	static void ClearSegmentBuffer(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		offset->segmentBuffer.clear();
	}

	static void* GetBufferedPolygon(void* ptr, int index)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return offset->polygonBuffer[index];
	}

	static Segment2d GetSegment(void* ptr, int index)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return offset->segmentBuffer[index];
	}

	static void GetSegments(void* ptr, Segment2d* segments, int count)
	{
		auto offset = CastToPolygonOffset2(ptr);

		for (int i = 0; i < count; i++)
			segments[i] = offset->segmentBuffer[i];
	}

	static void CreateInteriorOffset(void* ptr, void* polyPtr, double amount)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		auto polygons = CGAL::create_interior_skeleton_and_offset_polygons_2(amount, *poly);
		offset->CopyToBuffer(polygons);
	}

	static void CreateInteriorOffsetPWH(void* ptr, void* pwhPtr, double amount, BOOL boundaryOnly)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
		{
			auto boundary = CGAL::create_interior_skeleton_and_offset_polygons_2(amount, pwh->outer_boundary());
			offset->CopyToBuffer(boundary);
		}

		/*
		if (!boundaryOnly)
		{
			for (auto& hole : pwh->holes())
			{
				auto polygons = CGAL::create_interior_skeleton_and_offset_polygons_2(amount, hole);
				offset->CopyToBuffer(polygons);
			}
		}
		*/
	}

	static void CreateExteriorOffset(void* ptr, void* polyPtr, double maxOffset)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		auto polygons = CGAL::create_exterior_skeleton_and_offset_polygons_2(maxOffset, *poly);
		offset->CopyToBuffer(polygons);
	}

	static void CreateExteriorOffsetPWH(void* ptr, void* pwhPtr, double amount, BOOL boundaryOnly)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
		{
			auto boundary = CGAL::create_exterior_skeleton_and_offset_polygons_2(amount, pwh->outer_boundary());
			offset->CopyToBuffer(boundary);
		}
	}

	void CopyToBuffer(const PolygonPtrVector& polygons)
	{
		for (auto iter = polygons.begin(); iter != polygons.end(); ++iter)
		{
			auto p = new Polygon_2();

			for (auto v = (*iter)->vertices_begin(); v != (*iter)->vertices_end(); ++v)
			{
				Point point(v->x(), v->y());
				p->push_back(point);
			}

			polygonBuffer.push_back(p);
		}
	}

	void CreateSegments(SsPtr iss, BOOL includeBorder)
	{
		std::unordered_set<int> set;

		segmentBuffer.clear();

		for (HalfEdge edge = iss->halfedges_begin(); edge != iss->halfedges_end(); ++edge)
		{
			bool isBorder = edge->is_border() || edge->opposite()->is_border();

			if ((includeBorder && isBorder) || !isBorder)
			{
				
				if (set.find(edge->id()) == set.end())
				{
					auto a = Point2d::FromCGAL<EIK>(edge->vertex()->point());
					auto b = Point2d::FromCGAL<EIK>(edge->opposite()->vertex()->point());

					segmentBuffer.push_back({ a, b });

					set.insert(edge->id());
					set.insert(edge->opposite()->id());
				}

			}

		}
		
	}

	static void CreateInteriorSkeleton(void* ptr, void* polyPtr, BOOL includeBorder)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		SsPtr iss = CGAL::create_interior_straight_skeleton_2(*poly);
		offset->CreateSegments(iss, includeBorder);
	}

	static void CreateInteriorSkeletonPWH(void* ptr, void* pwhPtr, BOOL includeBorder)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto pwh = Polygon2<K>::CastToPolygon2(pwhPtr);

		SsPtr iss = CGAL::create_interior_straight_skeleton_2(*pwh);
		offset->CreateSegments(iss, includeBorder);
	}

	static void CreateExteriorSkeleton(void* ptr, void* polyPtr, double maxOffset, BOOL includeBorder)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);
		
		SsPtr iss = CGAL::create_exterior_straight_skeleton_2(maxOffset, *poly);
		offset->CreateSegments(iss, includeBorder);
	}

	static void CreateExteriorSkeletonPWH(void* ptr, void* pwhPtr, double maxOffset, BOOL includeBorder)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto pwh = Polygon2<K>::CastToPolygon2(pwhPtr);

		SsPtr iss = CGAL::create_exterior_straight_skeleton_2(maxOffset, *pwh);
		offset->CreateSegments(iss, includeBorder);
	}

};

