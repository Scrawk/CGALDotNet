#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "ArrMultiLocator.h"

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

	typedef typename Arrangement_2::Vertex_const_handle Vertex_const_handle;
	typedef typename Arrangement_2::Halfedge_const_handle Halfedge_const_handle;
	typedef typename Arrangement_2::Face_const_handle Face_const_handle;

	typedef typename Arrangement_2::Vertex_handle Vertex_handle;
	typedef typename Arrangement_2::Halfedge_handle Halfedge_handle;
	typedef typename Arrangement_2::Face_handle Face_handle;

	typedef typename Arrangement_2::Halfedge_around_vertex_const_circulator Vertex_const_circulator;

private:

	Arrangement_2 model;

	Locator locator;

public:

	Arrangement2()
	{
	
	}

	~Arrangement2()
	{

	}

	static void* CreateFromSegments(Segment2d* segments, int startIndex, int count)
	{
		auto arr = new Arrangement2();

		for (auto i = startIndex; i < count; i++)
		{
			auto seg = segments[i].To<K, Segment_2>();
			CGAL::insert(arr->model, seg);
		}

		return arr;
	}

	static BOOL IsValid(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return arr->model.is_valid();
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
			points[i].From<K>(iter->point());
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

			segments[i].From<K>(a, b);
		}
	}

	static void SetVertexIndices(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		int index = 0;

		for (auto iter = arr->model.vertices_begin(); iter != arr->model.vertices_end(); ++iter)
			iter->set_data(index++);
	}

	static void SetHalfEdgeIndices(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		int index = 0;

		for (auto iter = arr->model.halfedges_begin(); iter != arr->model.halfedges_end(); ++iter)
			iter->set_data(index++);
	}

	static void SetFaceIndices(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		int index = 0;

		for (auto iter = arr->model.faces_begin(); iter != arr->model.faces_end(); ++iter)
			iter->set_data(index++);
	}

	static void GetVertices(void* ptr, ArrVertex2* vertices, int startIndex, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = startIndex;

		for (auto iter = arr->model.vertices_begin(); iter != arr->model.vertices_end(); ++iter, ++i)
		{
			vertices[i].Index = iter->data();
			vertices[i].Point.From<K>(iter->point());
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
		return HandleQuery(q, result);
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
			if (HandleQuery(it->second, r[i]))
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
			return HandleQuery(q, result);
		}
		else
		{
			auto q = arr->locator.RayShootDown(arr->model, point);
			return HandleQuery(q, result);
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
	}

	static void InsertSegment(void* ptr, Segment2d segment, BOOL nonItersecting)
	{
		auto arr = CastToArrangement(ptr);

		if(nonItersecting)
			arr->locator.InsertSegment<Segment_2>(arr->model, segment);
		else
			arr->locator.InsertNonIntersectingSegment<Segment_2>(arr->model, segment);
	}

	static BOOL RemoveVertex(void* ptr, int index)
	{
		auto arr = CastToArrangement(ptr);
		
		Vertex_handle v;
		if (arr->FindVertex(index, v))
			return remove_vertex(arr->model, v);
		else
			return FALSE;
	}

	static BOOL RemoveVertex(void* ptr, Point2d point)
	{
		auto arr = CastToArrangement(ptr);

		auto q = arr->locator.Locate(arr->model, point);

		const Vertex_const_handle* vert;
		if (vert = boost::get<Vertex_const_handle>(&q))
		{
			auto v = arr->model.non_const_handle(*vert);
			return remove_vertex(arr->model, v);
		}
		else
			return FALSE;
	}

	static BOOL RemoveEdge(void* ptr, int index)
	{
		auto arr = CastToArrangement(ptr);

		Halfedge_handle e;
		if (arr->FindEdge(index, e))
		{
			remove_edge(arr->model, e);
			return TRUE;
		}
		else
			return FALSE;
	}

	static BOOL RemoveEdge(void* ptr, Segment2d segment)
	{
		auto arr = CastToArrangement(ptr);

		auto q1 = arr->locator.Locate(arr->model, segment.a);

		const Vertex_const_handle* vert1;
		if (vert1 = boost::get<Vertex_const_handle>(&q1))
		{
			if ((*vert1)->is_isolated())
				return FALSE;

			auto q2 = arr->locator.Locate(arr->model, segment.b);

			const Vertex_const_handle* vert2;
			if (vert2 = boost::get<Vertex_const_handle>(&q2))
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
						return TRUE;
					}
				} 
				while (++curr != first);

			}
			else
				return FALSE;
		}
		else
			return FALSE;
	}

private:

	inline static Arrangement2* CastToArrangement(void* ptr)
	{
		return static_cast<Arrangement2*>(ptr);
	}

	static BOOL HandleQuery(Locator_Result_Type query, ArrQuery& result)
	{
		const Vertex_const_handle* vert;
		const Halfedge_const_handle* edge;
		const Face_const_handle* face;

		if (face = boost::get<Face_const_handle>(&query))
		{
			result.Element = ARR_ELEMENT_HIT::FACE;
			result.Index = (*face)->data();
			return TRUE;
		}

		else if (edge = boost::get<Halfedge_const_handle>(&query))
		{
			result.Element = ARR_ELEMENT_HIT::HALF_EDGE;
			result.Index = (*edge)->data();
			return TRUE;
		}

		else if (vert = boost::get<Vertex_const_handle>(&query))
		{
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
			list.push_back(points[i].To<K>());

		return list;
	}

	BOOL FindVertex(int index, Vertex_handle& vert)
	{
		int count = (int)model.number_of_vertices();

		if (index < 0 || index >= count)
			return FALSE;

		if (index / 2 < count)
		{
			for (auto iter = model.vertices_begin(); iter != model.vertices_end(); ++iter)
			{
				if (iter->data() == index)
				{
					vert = iter;
					return TRUE;
				}
			}
		}
		else
		{
			for (auto iter = model.vertices_end(); iter != model.vertices_begin(); --iter)
			{
				if (iter->data() == index)
				{
					vert = iter;
					return TRUE;
				}
			}
		}
			
		return FALSE;
	}

	BOOL FindEdge(int index, Halfedge_handle& edge)
	{
		int count = (int)model.number_of_halfedges();

		if (index < 0 || index >= count)
			return FALSE;

		if (index / 2 < count)
		{
			for (auto iter = model.halfedges_begin(); iter != model.halfedges_end(); ++iter)
			{
				if (iter->data() == index)
				{
					edge = iter;
					return TRUE;
				}
			}
		}
		else
		{
			for (auto iter = model.halfedges_end(); iter != model.halfedges_begin(); --iter)
			{
				if (iter->data() == index)
				{
					edge = iter;
					return TRUE;
				}
			}
		}

		return FALSE;
	}

};

