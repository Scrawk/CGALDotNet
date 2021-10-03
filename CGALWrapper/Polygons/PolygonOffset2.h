#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "Polygon2.h"
#include "PolygonWithHoles2.h"

#include <vector>
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/create_offset_polygons_2.h>
#include <CGAL/create_straight_skeleton_from_polygon_with_holes_2.h>
#include <boost/shared_ptr.hpp>

template<class K>
class PolygonOffset2
{

private:

	typedef typename K::Point_2                   Point;
	typedef typename CGAL::Polygon_2<K>			  Polygon_2;
	typedef CGAL::Polygon_with_holes_2<K>         Polygon_with_holes;
	typedef CGAL::Straight_skeleton_2<K>		  Ss;
	typedef boost::shared_ptr<Ss>			      SsPtr;
	typedef boost::shared_ptr<Polygon_2>          PolygonPtr;
	typedef std::vector<PolygonPtr>               PolygonPtrVector;

	typedef CGAL::Straight_skeleton_2<K> Ss;
	typedef typename Ss::Vertex_handle Vertex;
	typedef typename Ss::Halfedge_handle HalfEdge;

	std::vector<Polygon_2*>  buffer;

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
		return (int)offset->buffer.size();
	}

	static void ClearPolygonBuffer(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		offset->buffer.clear();
	}

	static void* GetBufferedPolygon(void* ptr, int index)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return offset->buffer[index];
	}

	/*
	inline static int VertexBufferSize(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return (int)offset->vertices.size();
	}

	inline static int EdgeBufferSize(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		return (int)offset->edges.size();
	}

	
	inline static void ClearEdgeAndVertexBuffers(void* ptr)
	{
		auto offset = CastToPolygonOffset2(ptr);
		offset->vertices.clear();
		offset->edges.clear();
	}

	
	inline static void GetVertices(void* ptr, DCELVertex* _vertices, int start, int count)
	{
		auto offset = CastToPolygonOffset2(ptr);
		
		int index = start;
		for (int i = 0; i < count; i++)
			_vertices[index++] = offset->vertices[i];
	}

	inline static void GetEdges(void* ptr, DCELHalfEdge* _edges, int start, int count)
	{
		auto offset = CastToPolygonOffset2(ptr);

		int index = start;
		for (int i = 0; i < count; i++)
			_edges[index++] = offset->edges[i];
	}
	*/

	static void CreateInteriorOffset(void* ptr, void* polyPtr, double amount)
	{
		auto offset = CastToPolygonOffset2(ptr);

		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);
		auto polygons = CGAL::create_interior_skeleton_and_offset_polygons_2(amount, *poly);

		for (auto iter = polygons.begin(); iter != polygons.end(); ++iter)
		{
			auto p = new Polygon_2();

			for (auto v = (*iter)->vertices_begin(); v != (*iter)->vertices_end(); ++v)
			{
				Point point(v->x(), v->y());
				p->push_back(point);
			}

			offset->buffer.push_back(p);
		}
	}

	static void CreateExteriorOffset(void* ptr, void* polyPtr, double maxOffset)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		auto polygons = CGAL::create_exterior_skeleton_and_offset_polygons_2(maxOffset, *poly);

		for (auto iter = polygons.begin(); iter != polygons.end(); ++iter)
		{
			auto p = new Polygon_2();

			for (auto v = (*iter)->vertices_begin(); v != (*iter)->vertices_end(); ++v)
			{
				Point point(v->x(), v->y());
				p->push_back(point);
			}

			offset->buffer.push_back(p);
		}
	}

	void ConvertFromHalfEdge(SsPtr iss, BOOL includeBorder)
	{
		/*
		vertices.clear();
		edges.clear();

		int index = 0;
		for (Vertex vert = iss->vertices_begin(); vert != iss->vertices_end(); ++vert)
		{
			vert->id() = index;
		
			auto v = DCELVertex::NullVertex();
			v.Point = Point2d::FromCGAL<K>(vert->point());
			vertices.push_back(v);
		}

		index = 0;
		for (HalfEdge edge = iss->halfedges_begin(); edge != iss->halfedges_end(); ++edge)
		{
			if ((includeBorder && edge->is_border()) || !edge->is_border())
			{
				edge.id() = index++;

				auto e = DCELHalfEdge::NullEdge();
				edges.push_back(e);
			}
			else
				edge.id() = NULL_INDEX;
			
		}

		for (HalfEdge edge = iss->halfedges_begin(); edge != iss->halfedges_end(); ++edge)
		{
			if (edge->info() == NULL_INDEX) continue;
		
			HalfEdge opp = edge->opposite();
			Vertex v0 = edge->vertex();
			Vertex v1 = opp->vertex();

			auto e = edges[edge.info()];
			e.TwinIndex = opp->info();
			e.SourceIndex = v0.info();
			e.TargetIndex = v1.info();
			e.FaceIndex = edge->face()->id();
			e.NextIndex = edge->next()->id();
			e.PreviousIndex = edge->previous()->id();
		}
		*/
	}

	static void CreateInteriorSkeleton(void* ptr, void* polyPtr, BOOL includeBorder)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);

		//SsPtr iss = CGAL::create_interior_straight_skeleton_2(*poly);
		//offset->ConvertFromHalfEdge(iss, includeBorder);
	}

	static void CreateExteriorSkeleton(void* ptr, void* polyPtr, double maxOffset, BOOL includeBorder)
	{
		auto offset = CastToPolygonOffset2(ptr);
		auto poly = Polygon2<K>::CastToPolygon2(polyPtr);
		
		//SsPtr iss = CGAL::create_exterior_straight_skeleton_2(maxOffset, *poly);
		//offset->ConvertFromHalfEdge(iss, includeBorder);
	}

};

