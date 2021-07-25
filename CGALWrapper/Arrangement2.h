#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "ArrMultiLocator.h"
#include "ArrangementMap.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>
#include <CGAL/Arr_extended_dcel.h>
#include <CGAL/Arr_batched_point_location.h>

struct ArrVertex2
{
	Point2d Point;
	int Degree;
	BOOL IsIsolated;
	int Index;
	int FaceIndex;
	int HalfEdgeIndex;
};

struct ArrHalfEdge2
{
	BOOL IsFictitious;
	int Index;
	int SourceIndex;
	int TargetIndex;
	int FaceIndex;
	int NextIndex;
	int PreviousIndex;
	int TwinIndex;
};

struct ArrFace2
{
	BOOL IsFictitious;
	BOOL IsUnbounded;
	BOOL HasOuterEdges;
	int Index;
	int HalfEdgeIndex;
};

enum class ARR_ELEMENT_HIT : int
{
	NONE,
	VERTEX,
	HALF_EDGE,
	FACE
};

struct ArrQuery
{
	ARR_ELEMENT_HIT Element;
	int Index;
};

template<class K>
class Arrangement2
{

public:

	typedef CGAL::Arr_segment_traits_2<EEK> Traits_2;
	typedef Traits_2::Point_2 Point_2;
	typedef Traits_2::X_monotone_curve_2 Segment_2;
	typedef CGAL::Arr_extended_dcel<Traits_2, int, int, int> Dcel;
	typedef CGAL::Arrangement_2<Traits_2, Dcel> Arrangement_2;
	typedef ArrMultiLocator<K, Arrangement_2> Locator;
	typedef typename Locator::Walk_Locator Walk_Locator;

	typedef typename Locator::Locator_Result_Type Locator_Result_Type;
	typedef std::pair<Point_2, Locator_Result_Type> Batch_Query_Result;

	typedef typename Arrangement_2::Vertex_const_handle Vertex_const;
	typedef typename Arrangement_2::Halfedge_const_handle Halfedge_const;
	typedef typename Arrangement_2::Face_const_handle Face_const;

	typedef typename Arrangement_2::Vertex_handle Vertex;
	typedef typename Arrangement_2::Halfedge_handle Halfedge;
	typedef typename Arrangement_2::Face_handle Face;

	typedef typename Arrangement_2::Halfedge_around_vertex_const_circulator Vertex_const_circulator;

private:

	Arrangement_2 model;

	Locator locator;

	ArrangementMap<K, Vertex, Face, Halfedge> map;

public:

	Arrangement2()
	{
	
	}

	~Arrangement2()
	{

	}

	inline static Arrangement2* CastToArrangement(void* ptr)
	{
		return static_cast<Arrangement2*>(ptr);
	}

	static BOOL IsValid(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return arr->model.is_valid();
	}

	static void Clear(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		arr->model.clear();
		arr->map.ClearMaps();
	}

	static BOOL IsEmpty(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return arr->model.is_empty();
	}

	static void Assign(void* ptr, void* ptrOther)
	{
		auto arr = CastToArrangement(ptr);
		auto other = CastToArrangement(ptrOther);
		arr->model.assign(other->model);
	}

	static int VertexCount(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return (int)arr->model.number_of_vertices();
	}

	static int VerticesAtInfinityCount(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return (int)arr->model.number_of_vertices_at_infinity();
	}

	static int IsolatedVerticesCount(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return (int)arr->model.number_of_isolated_vertices();
	}

	static int HalfEdgeCount(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return (int)arr->model.number_of_halfedges();
	}

	static int FaceCount(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return (int)arr->model.number_of_faces();
	}

	static int EdgeCount(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return (int)arr->model.number_of_edges();
	}

	static int UnboundedFaceCount(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return (int)arr->model.number_of_unbounded_faces();
	}

	static void GetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = startIndex;

		for (auto iter = arr->model.vertices_begin(); iter != arr->model.vertices_end(); ++iter, ++i)
		{
			points[i] = Point2d::FromCGAL<K>(iter->point());
		}
	}

	static void GetSegments(void* ptr, Segment2d* segments, int startIndex, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = startIndex;

		for (auto iter = arr->model.edges_begin(); iter != arr->model.edges_end(); ++iter, ++i)
		{
			auto a = iter->curve().source();
			auto b = iter->curve().target();

			segments[i] = Segment2d::FromCGAL<K>(a, b);
		}
	}

	static void GetVertices(void* ptr, ArrVertex2* vertices, int startIndex, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = startIndex;

		arr->map.SetIndices(arr->model);

		for (auto iter = arr->model.vertices_begin(); iter != arr->model.vertices_end(); ++iter, ++i)
		{
			vertices[i].Index = iter->data();
			vertices[i].Point = Point2d::FromCGAL<K>(iter->point());
			vertices[i].Degree = (int)iter->degree();
			vertices[i].IsIsolated = iter->is_isolated();

			if (iter->is_isolated())
			{
				vertices[i].FaceIndex = iter->face()->data();
				vertices[i].HalfEdgeIndex = -1;
			}
			else
			{
				vertices[i].FaceIndex = -1;
				auto first = iter->incident_halfedges();
				vertices[i].HalfEdgeIndex = first->data();
			}
		}
	}

	static void GetHalfEdges(void* ptr, ArrHalfEdge2* edges, int startIndex, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = startIndex;

		arr->map.SetIndices(arr->model);

		for (auto iter = arr->model.halfedges_begin(); iter != arr->model.halfedges_end(); ++iter, ++i)
		{
			edges[i].IsFictitious = iter->is_fictitious();
			edges[i].Index = iter->data();
			edges[i].SourceIndex = iter->source()->data();
			edges[i].TargetIndex = iter->target()->data();
			edges[i].FaceIndex = iter->face()->data();
			edges[i].NextIndex = iter->next()->data();
			edges[i].PreviousIndex = iter->prev()->data();
			edges[i].TwinIndex = iter->twin()->data();
		}
	}

	static void GetFaces(void* ptr, ArrFace2* faces, int startIndex, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = startIndex;

		arr->map.SetIndices(arr->model);

		for (auto iter = arr->model.faces_begin(); iter != arr->model.faces_end(); ++iter, ++i)
		{
			faces[i].IsFictitious = iter->is_fictitious();
			faces[i].IsUnbounded = iter->is_unbounded();
			faces[i].HasOuterEdges = iter->has_outer_ccb();
			faces[i].Index = iter->data();

			if (iter->has_outer_ccb())
			{
				auto first = iter->outer_ccb();
				faces[i].HalfEdgeIndex = first->data();
			}
			else
			{
				faces[i].HalfEdgeIndex = -1;
			}
		}
	}

	static void CreateLocator(void* ptr, ARR_LOCATOR type)
	{
		auto arr = CastToArrangement(ptr);
		arr->locator.CreateLocator(type, arr->model);
	}

	static void ReleaseLocator(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		arr->locator.ReleaseLocator();
	}

	static BOOL PointQuery(void* ptr, Point2d point, ArrQuery& result)
	{
		auto arr = CastToArrangement(ptr);
		auto q = arr->locator.Locate(arr->model, point);
		return HandleQuery(arr, q, result);
	}

	static BOOL BatchedPointQuery(void* ptr, Point2d* p, ArrQuery* r, int startIndex, int count)
	{
		auto arr = CastToArrangement(ptr);

		auto list = ToList(p, startIndex, count);
		std::vector<Batch_Query_Result> results;

		locate(arr->model, list.begin(), list.end(), std::back_inserter(results));

		BOOL hit = FALSE;
		int i = 0;

		for (auto it = results.begin(); it != results.end(); ++it, ++i) 
		{
			if (HandleQuery(arr, it->second, r[i]))
				hit = TRUE;
		}

		return hit;
	}

	static BOOL RayQuery(void* ptr, Point2d point, BOOL up, ArrQuery& result)
	{
		auto arr = CastToArrangement(ptr);

		if (up)
		{
			auto q = arr->locator.RayShootUp(arr->model, point);
			return HandleQuery(arr, q, result);
		}
		else
		{
			auto q = arr->locator.RayShootDown(arr->model, point);
			return HandleQuery(arr, q, result);
		}
	}

	static BOOL IntersectsSegment(void* ptr, Segment2d segment)
	{
		auto arr = CastToArrangement(ptr);
		return arr->locator.Intersects<Segment_2>(arr->model, segment);
	}

	static void InsertPoint(void* ptr, Point2d point)
	{
		auto arr = CastToArrangement(ptr);
		arr->locator.InsertPoint(arr->model, point);
		arr->map.OnModelChanged();
	}

	static void InsertSegment(void* ptr, Segment2d segment, BOOL nonItersecting)
	{
		auto arr = CastToArrangement(ptr);

		if(nonItersecting)
			arr->locator.InsertSegment<Segment_2>(arr->model, segment);
		else
			arr->locator.InsertNonIntersectingSegment<Segment_2>(arr->model, segment);

		arr->map.OnModelChanged();
	}

	static void InsertSegments(void* ptr, Segment2d* segments, int startIndex, int count)
	{
		auto arr = CastToArrangement(ptr);

		for (auto i = startIndex; i < count; i++)
		{
			auto seg = segments[i].ToCGAL<K, Segment_2>();
			CGAL::insert(arr->model, seg);
		}

		arr->map.OnModelChanged();
	}

	static BOOL RemoveVertex(void* ptr, int index)
	{
		auto arr = CastToArrangement(ptr);
		
		auto v = arr->map.FindVertex(arr->model, index);
		if (v != nullptr)
		{
			if (remove_vertex(arr->model, *v))
			{
				arr->map.OnModelChanged();
				return TRUE;
			}
		}

		return FALSE;
	}

	static BOOL RemoveVertex(void* ptr, Point2d point)
	{
		auto arr = CastToArrangement(ptr);

		auto q = arr->locator.Locate(arr->model, point);

		const Vertex_const* vert;
		if (vert = boost::get<Vertex_const>(&q))
		{
			auto v = arr->model.non_const_handle(*vert);
			if (remove_vertex(arr->model, v))
			{
				arr->map.OnModelChanged();
				return TRUE;
			}
		}

		return FALSE;
	}

	static BOOL RemoveEdge(void* ptr, int index)
	{
		auto arr = CastToArrangement(ptr);

		auto e = arr->map.FindEdge(arr->model, index);
		if (e != nullptr)
		{
			remove_edge(arr->model, *e);
			arr->map.OnModelChanged();
			return TRUE;
		}

		return FALSE;
	}

	static BOOL RemoveEdge(void* ptr, Segment2d segment)
	{
		auto arr = CastToArrangement(ptr);

		auto q1 = arr->locator.Locate(arr->model, segment.a);

		const Vertex_const* vert1;
		if (vert1 = boost::get<Vertex_const>(&q1))
		{
			if ((*vert1)->is_isolated())
				return FALSE;

			auto q2 = arr->locator.Locate(arr->model, segment.b);

			const Vertex_const* vert2;
			if (vert2 = boost::get<Vertex_const>(&q2))
			{
				if ((*vert2)->is_isolated())
					return FALSE;

				auto first = (*vert1)->incident_halfedges();
				auto curr = first;
				auto next = first;

				do 
				{
					++next;
					if ((next->source() == (*vert2) || next->target() == (*vert2)))
					{
						auto e = arr->model.non_const_handle(next);
						remove_edge(arr->model, e);
						arr->map.OnModelChanged();
						return TRUE;
					}
				} 
				while (++curr != first);

			}

		}
		
		return FALSE;
	}

private:

	static BOOL HandleQuery(Arrangement2* arr, Locator_Result_Type query, ArrQuery& result)
	{
		const Vertex_const* vert;
		const Halfedge_const* edge;
		const Face_const* face;

		if (face = boost::get<Face_const>(&query))
		{
			arr->map.SetFaceIndices(arr->model);
			result.Element = ARR_ELEMENT_HIT::FACE;
			result.Index = (*face)->data();
			return TRUE;
		}

		else if (edge = boost::get<Halfedge_const>(&query))
		{
			arr->map.SetEdgeIndices(arr->model);
			result.Element = ARR_ELEMENT_HIT::HALF_EDGE;
			result.Index = (*edge)->data();
			return TRUE;
		}

		else if (vert = boost::get<Vertex_const>(&query))
		{
			arr->map.SetVertexIndices(arr->model);
			result.Element = ARR_ELEMENT_HIT::VERTEX;
			result.Index = (*vert)->data();
			return TRUE;
		}
		else
		{
			result.Element = ARR_ELEMENT_HIT::NONE;
			result.Index = -1;
			return FALSE;
		}
	}

	static std::vector<Point_2> ToList(Point2d* points, int startIndex, int count)
	{
		auto list = std::vector<Point_2>(count);

		for (int i = startIndex; i < count; i++)
			list.push_back(points[i].ToCGAL<K>());

		return list;
	}

};

