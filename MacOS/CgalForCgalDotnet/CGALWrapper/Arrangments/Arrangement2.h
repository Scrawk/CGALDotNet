#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"
#include "../Polygons/PolygonWithHoles2.h"
#include "ArrMultiLocator.h"
#include "ArrangementMap.h"

#include "ArrVertex2.h"
#include "ArrHalfEdge2.h"
#include "ArrFace2.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>
#include <CGAL/Arr_extended_dcel.h>
#include <CGAL/Arr_batched_point_location.h>
#include <CGAL/Arr_overlay_2.h>

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

	typedef typename Arrangement_2::Halfedge_around_vertex_circulator Vertex_circulator;

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

	inline static Arrangement2* NewArrangement2()
	{
		return new Arrangement2();
	}

	inline static void DeleteArrangement2(void* ptr)
	{
		auto obj = static_cast<Arrangement2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
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

	static int BuildStamp(void* ptr)
	{
		auto arr = CastToArrangement(ptr);
		return arr->map.BuildStamp();
	}

	static void Assign(void* ptr, void* ptrOther)
	{
		auto arr = CastToArrangement(ptr);
		auto other = CastToArrangement(ptrOther);
		arr->model.assign(other->model);
	}

	static void* Overlay(void* ptr, void* ptrOther)
	{
		auto arr = CastToArrangement(ptr);
		auto other = CastToArrangement(ptrOther);
		auto result = new Arrangement2();
		overlay(arr->model, other->model, result->model);
		return result;
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

	static void GetPoints(void* ptr, Point2d* points, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = 0;

		for (auto iter = arr->model.vertices_begin(); iter != arr->model.vertices_end(); ++iter, ++i)
		{
			points[i] = Point2d::FromCGAL<K>(iter->point());
		}
	}

	static void GetSegments(void* ptr, Segment2d* segments, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = 0;

		for (auto iter = arr->model.edges_begin(); iter != arr->model.edges_end(); ++iter, ++i)
		{
			auto a = iter->curve().source();
			auto b = iter->curve().target();

			segments[i] = Segment2d::FromCGAL<K>(a, b);
		}
	}

	static void GetVertices(void* ptr, ArrVertex2* vertices, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = 0;

		arr->map.SetIndices(arr->model);

		for (auto vert = arr->model.vertices_begin(); vert != arr->model.vertices_end(); ++vert, ++i)
		{
			vertices[i] = ArrVertex2::FromVertex<K>(vert);
		}
	}

	static BOOL GetVertex(void* ptr, int index, ArrVertex2& arrVert)
	{
		auto arr = CastToArrangement(ptr);
		arr->map.SetIndices(arr->model);

		auto vert = arr->map.FindVertex(arr->model, index);
		if (vert != nullptr)
		{
			arrVert = ArrVertex2::FromVertex<K>(*vert);
			return TRUE;
		}
		else
		{
			arrVert = ArrVertex2::NullVertex();
			return FALSE;
		}
	}

	static void GetHalfEdges(void* ptr, ArrHalfEdge2* edges, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = 0;

		arr->map.SetIndices(arr->model);

		for (auto edge = arr->model.halfedges_begin(); edge != arr->model.halfedges_end(); ++edge, ++i)
		{
			edges[i] = ArrHalfEdge2::FromHalfEdge(edge);
		}
	}

	static BOOL GetHalfEdge(void* ptr, int index, ArrHalfEdge2& arrEdge)
	{
		auto arr = CastToArrangement(ptr);
		arr->map.SetIndices(arr->model);

		auto edge = arr->map.FindEdge(arr->model, index);
		if (edge != nullptr)
		{
			arrEdge = ArrHalfEdge2::FromHalfEdge(*edge);
			return TRUE;
		}
		else
		{
			arrEdge = ArrHalfEdge2::NullEdge();
			return FALSE;
		}
	}

	static void GetFaces(void* ptr, ArrFace2* faces, int count)
	{
		auto arr = CastToArrangement(ptr);
		int i = 0;

		arr->map.SetIndices(arr->model);

		for (auto face = arr->model.faces_begin(); face != arr->model.faces_end(); ++face)
		{
			if (!face->is_unbounded())
				faces[i++] = ArrFace2::FromFace(face);
		}
	}

	static BOOL GetFace(void* ptr, int index, ArrFace2& arrFace)
	{
		auto arr = CastToArrangement(ptr);
		arr->map.SetIndices(arr->model);

		auto face = arr->map.FindFace(arr->model, index);
		if (face != nullptr)
		{
			if (!(*face)->is_unbounded())
			{
				arrFace = ArrFace2::FromFace(*face);
				return TRUE;
			}
			else
			{
				arrFace = ArrFace2::NullFace();
				return FALSE;
			}
		}
		else
		{
			arrFace = ArrFace2::NullFace();
			return FALSE;
		}
	}

	static int GetFaceHoleCount(void* ptr, int index)
	{
		auto arr = CastToArrangement(ptr);
		arr->map.SetIndices(arr->model);

		auto face = arr->map.FindFace(arr->model, index);
		if (face != nullptr)
		{
			return CountHoles(*face);
		}
		else
		{
			return NULL_INDEX;
		}
	}

	static int GetHoleVertexCount(void* ptr, int faceIndex, int holeIndex)
	{
		auto arr = CastToArrangement(ptr);
		arr->map.SetIndices(arr->model);

		auto face = arr->map.FindFace(arr->model, faceIndex);
		if (face != nullptr)
		{
			return CountHoleVertices(*face, holeIndex);
		}
		else
		{
			return NULL_INDEX;
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
		arr->map.SetIndices(arr->model);

		auto q = arr->locator.Locate(arr->model, point);
		return HandleQuery(arr, q, result);
	}

	static BOOL BatchedPointQuery(void* ptr, Point2d* p, ArrQuery* r, int count)
	{
		auto arr = CastToArrangement(ptr);
		arr->map.SetIndices(arr->model);

		auto list = ToList(p, count);
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
		arr->map.SetIndices(arr->model);

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
        return arr->locator.template Intersects<Segment_2>(arr->model, segment);
	}

	static void InsertPoint(void* ptr, Point2d point)
	{
		auto arr = CastToArrangement(ptr);
		arr->locator.InsertPoint(arr->model, point);
		arr->map.OnModelChanged();
	}

	static void InsertPolygon(void* ptr, void* polyPtr, BOOL nonItersecting)
	{
		auto arr = CastToArrangement(ptr);;
		auto polygon = Polygon2<EEK>::CastToPolygon2(polyPtr);

		int count = (int)polygon->container().size();
		for (int i = 0; i < count; i++)
		{
			int i0 = i;
			int i1 = i + 1;

			if (i == count - 1)
				i1 = 0;

			auto a = polygon->vertex(i0);
			auto b = polygon->vertex(i1);

			auto segment = Segment2d::FromCGAL(a, b);

			if (segment.a == segment.b) continue;

			if (nonItersecting)
                arr->locator.template InsertNonIntersectingSegment<Segment_2>(arr->model, segment);
			else
                arr->locator.template InsertSegment<Segment_2>(arr->model, segment);
		}

		arr->map.OnModelChanged();
	}

	static void InsertPolygon(Arrangement2* arr, Polygon2<K>* polygon, BOOL nonItersecting)
	{
		int count = (int)polygon->container().size();
		for (int i = 0; i < count; i++)
		{
			int i0 = i;
			int i1 = i + 1;

			if (i == count - 1)
				i1 = 0;

			auto a = polygon->vertex(i0);
			auto b = polygon->vertex(i1);

			auto segment = Segment2d::FromCGAL(a, b);

			if (segment.a == segment.b) continue;

			if (nonItersecting)
                arr->locator.template InsertNonIntersectingSegment<Segment_2>(arr->model, segment);
			else
                arr->locator.template InsertSegment<Segment_2>(arr->model, segment);
		}

		arr->map.OnModelChanged();
	}

	static void InsertPolygonWithHoles(void* ptr, void* pwhPtr, BOOL nonItersecting)
	{
		auto arr = CastToArrangement(ptr);
		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
			InsertPolygon(&arr, &pwh->outer_boundary(), nonItersecting);
			
		for (auto& hole : pwh->holes())
			InsertPolygon(&arr, &hole, nonItersecting);
			
		arr->map.OnModelChanged();
	}

	static void InsertSegment(void* ptr, Segment2d segment, BOOL nonItersecting)
	{
		if (segment.a == segment.b) return;

		auto arr = CastToArrangement(ptr);

		if(nonItersecting)
            arr->locator.template InsertNonIntersectingSegment<Segment_2>(arr->model, segment);
		else
            arr->locator.template InsertSegment<Segment_2>(arr->model, segment);

		arr->map.OnModelChanged();
	}

	static void InsertSegments(void* ptr, Segment2d* segments, int count, BOOL nonItersecting)
	{
		auto arr = CastToArrangement(ptr);

		for (auto i = 0; i < count; i++)
		{
			if (segments[i].a == segments[i].b) continue;

			if (nonItersecting)
                arr->locator.template InsertNonIntersectingSegment<Segment_2>(arr->model, segments[i]);
			else
                arr->locator.template InsertSegment<Segment_2>(arr->model, segments[i]);
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
			arr->map.SetIndices(arr->model);
			result.Element = ARR_ELEMENT_HIT::FACE;
			result.Index = (*face)->data();
			return TRUE;
		}

		else if (edge = boost::get<Halfedge_const>(&query))
		{
			arr->map.SetIndices(arr->model);
			result.Element = ARR_ELEMENT_HIT::HALF_EDGE;
			result.Index = (*edge)->data();
			return TRUE;
		}

		else if (vert = boost::get<Vertex_const>(&query))
		{
			arr->map.SetIndices(arr->model);
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

	static std::vector<Point_2> ToList(Point2d* points, int count)
	{
		auto list = std::vector<Point_2>(count);

		for (int i = 0; i < count; i++)
			list.push_back(points[i].ToCGAL<K>());

		return list;
	}

	static int CountHoles(Face face)
	{
		int count = 0;
		for (auto hole = face->holes_begin(); hole != face->holes_end(); ++hole)
		{
			count++;
		}

		return count;
	}

	static int CountHoleVertices(Face face, int index)
	{
		int holeCount = 0;
		for (auto hole = face->holes_begin(); hole != face->holes_end(); ++hole)
		{
			if (holeCount == index)
			{
				auto curr = (*hole)->next();
				auto first = curr;

				int vertCount = 0;

				do
				{
					vertCount++;
					curr = curr->next();
				} while (curr != first);

				return vertCount;
			}

			holeCount++;
		}

		return NULL_INDEX;
	}
	
};

