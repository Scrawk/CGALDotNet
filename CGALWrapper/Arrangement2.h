#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

#include "CGAL/Point_2.h"
#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>
#include <CGAL/Arr_extended_dcel.h>

enum class ARRANGEMENT2_ELEMENT : int
{
	VERTEX,
	FACE,
	HALF_EDGE
};

enum class ARRANGEMENT2_ELEMENT_EXT : int
{
	EDGE,
	ISOLATED_VERTEX,
	VERTEX_AT_INFINITY,
	UNBOUNDED_FACE
};

struct ArrVertex2
{
	Point2d Point;
	int Degree;
	bool IsIsolated;
	int Index;
	int FaceIndex;
	int HalfEdgeIndex;
};

template<class K>
class Arrangement2
{

private:

	Arrangement2() {}

public:

	typedef CGAL::Arr_segment_traits_2<EEK> Traits_2;
	typedef Traits_2::Point_2 Point_2;
	typedef Traits_2::X_monotone_curve_2 Segment_2;
	typedef CGAL::Arr_extended_dcel<Traits_2, int, int, int> Dcel;
	typedef CGAL::Arrangement_2<Traits_2, Dcel> Arrangement_2;

	static void* CreateFromSegments(Segment2d* segments, int startIndex, int count)
	{
		auto arr = new Arrangement_2();

		for (auto i = startIndex; i < count; i++)
		{
			auto seg = segments[i].To<K, Segment_2>();
			CGAL::insert(*arr, seg);
		}

		return arr;
	}

	static int VertexCount(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		return (int)arr->number_of_vertices();
	}

	static int VerticesAtInfinityCount(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		return (int)arr->number_of_vertices_at_infinity();
	}

	static int IsolatedVerticesCount(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		return (int)arr->number_of_isolated_vertices();
	}

	static int HalfEdgeCount(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		return (int)arr->number_of_halfedges();
	}

	static int FaceCount(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		return (int)arr->number_of_faces();
	}

	static int EdgeCount(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		return (int)arr->number_of_edges();
	}

	static int UnboundedFaceCount(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		return (int)arr->number_of_unbounded_faces();
	}

	static void GetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto arr = (Arrangement_2*)ptr;
		int i = startIndex;

		for (auto iter = arr->vertices_begin(); iter != arr->vertices_end(); ++iter, ++i)
		{
			points[i].From<K>(iter->point());
		}
	}

	static void GetSegments(void* ptr, Segment2d* segments, int startIndex, int count)
	{
		auto arr = (Arrangement_2*)ptr;
		int i = startIndex;

		for (auto iter = arr->edges_begin(); iter != arr->edges_end(); ++iter, ++i)
		{
			auto a = iter->curve().source();
			auto b = iter->curve().target();

			segments[i].From<K>(a, b);
		}
	}

	static void SetVertexIndices(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		int index = 0;

		for (auto iter = arr->vertices_begin(); iter != arr->vertices_end(); ++iter)
			iter->set_data(index++);
	}

	static void SetHalfEdgeIndices(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		int index = 0;

		for (auto iter = arr->halfedges_begin(); iter != arr->halfedges_end(); ++iter)
			iter->set_data(index++);
	}

	static void SetFaceIndices(void* ptr)
	{
		auto arr = (Arrangement_2*)ptr;
		int index = 0;

		for (auto iter = arr->faces_begin(); iter != arr->faces_end(); ++iter)
			iter->set_data(index++);
	}

	static void GetVertices(void* ptr, ArrVertex2* vertices, int startIndex, int count)
	{
		auto arr = (Arrangement_2*)ptr;
		int i = startIndex;

		for (auto iter = arr->vertices_begin(); iter != arr->vertices_end(); ++iter, ++i)
		{
			vertices[i].Point.From<K>(iter->point());
			vertices[i].Degree = (int)iter->degree();
			vertices[i].IsIsolated = iter->is_isolated();
			vertices[i].Index = iter->data();

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

	/*
	void print_neighboring_vertices(Arrangement_2::Vertex_const_handle v)
	{
		if (v->is_isolated()) {
			std::cout << "The vertex (" << v->point() << ") is isolated" << std::endl;
			return;
		}

		Arrangement_2::Halfedge_around_vertex_const_circulator first, curr;
		first = curr = v->incident_halfedges();

		std::cout << "The neighbors of the vertex (" << v->point() << ") are:";

		do 
		{
			// Note that the current halfedge is directed from u to v:
			Arrangement_2::Vertex_const_handle u = curr->source();
			std::cout << " (" << u->point() << ")";
		} 
		while (++curr != first);

		std::cout << std::endl;
	}

	void print_ccb(Arrangement_2::Ccb_halfedge_const_circulator circ)
	{
		Ccb_halfedge_const_circulator curr = circ;

		std::cout << "(" << curr->source()->point() << ")";

		do 
		{
			Arrangement_2::Halfedge_const_handle he = curr->handle();

			std::cout << " [" << he->curve() << "] "
				<< "(" << he->target()->point() << ")";
		}
		while (++curr != circ);

		std::cout << std::endl;
	}

	void print_face(Arrangement_2::Face_const_handle f)
	{
		// Print the outer boundary.
		if (f->is_unbounded())
			std::cout << "Unbounded face. " << std::endl;
		else 
		{
			std::cout << "Outer boundary: ";
			print_ccb(f->outer_ccb());
		}

		// Print the boundary of each of the holes.
		Arrangement_2::Hole_const_iterator hi;
		int index = 1;
		for (hi = f->holes_begin(); hi != f->holes_end(); ++hi, ++index) {
			std::cout << " Hole #" << index << ": ";
			print_ccb(*hi);
		}

		// Print the isolated vertices.
		Arrangement_2::Isolated_vertex_const_iterator iv;

		for (iv = f->isolated_vertices_begin(), index = 1;
			iv != f->isolated_vertices_end(); ++iv, ++index) {
			std::cout << " Isolated vertex #" << index << ": "
				<< "(" << iv->point() << ")" << std::endl;
		}
	}

	void print_arrangement(const Arrangement_2& arr)
	{
		// Print the arrangement vertices.
		Vertex_const_iterator vit;

		std::cout << arr.number_of_vertices() << " vertices:" << std::endl;

		for (vit = arr.vertices_begin(); vit != arr.vertices_end(); ++vit) 
		{
			std::cout << "(" << vit->point() << ")";
			if (vit->is_isolated())
				std::cout << " - Isolated." << std::endl;
			else
				std::cout << " - degree " << vit->degree() << std::endl;
		}

		// Print the arrangement edges.
		Edge_const_iterator eit;
		std::cout << arr.number_of_edges() << " edges:" << std::endl;
		for (eit = arr.edges_begin(); eit != arr.edges_end(); ++eit)
			std::cout << "[" << eit->curve() << "]" << std::endl;

		// Print the arrangement faces.
		Face_const_iterator fit;
		std::cout << arr.number_of_faces() << " faces:" << std::endl;
		for (fit = arr.faces_begin(); fit != arr.faces_end(); ++fit)
			print_face(fit);
	}
	*/

};

