#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "ArrMultiLocator.h"

#include "CGAL/Point_2.h"
#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>
#include <CGAL/Arr_extended_dcel.h>

enum class ARR_ELEMENT : int
{
	VERTEX,
	HALF_EDGE,
	FACE
};

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

struct ArrPointQueryResult
{
	ARR_ELEMENT Element;
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
	typedef ArrMultiLocator<Arrangement_2> Locator;

	typedef typename Arrangement_2::Vertex_const_handle   Vertex_const_handle;
	typedef typename Arrangement_2::Halfedge_const_handle Halfedge_const_handle;
	typedef typename Arrangement_2::Face_const_handle     Face_const_handle;

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

	static BOOL PointQuery(void* ptr, Point2d point, ArrPointQueryResult& result)
	{
		auto arr = CastToArrangement(ptr);

		auto q = arr->locator.Locate<K>(point, arr->model);

		const Vertex_const_handle* v;
		const Halfedge_const_handle* e;
		const Face_const_handle* f;

		if (f = boost::get<Face_const_handle>(&q))
		{
			result.Element = ARR_ELEMENT::FACE;
			result.Index = (*f)->data();
			return TRUE;
		}
			
		else if (e = boost::get<Halfedge_const_handle>(&q))
		{
			result.Element = ARR_ELEMENT::HALF_EDGE;
			result.Index = (*e)->data();
			return TRUE;
		}
			
		else if (v = boost::get<Vertex_const_handle>(&q))
		{
			result.Element = ARR_ELEMENT::VERTEX;
			result.Index = (*v)->data();
			return TRUE;
		}
		else
		{
			result.Index = -1;
			return FALSE;
		}
	}

	private:

		inline static Arrangement2* CastToArrangement(void* ptr)
		{
			return static_cast<Arrangement2*>(ptr);
		}

};

