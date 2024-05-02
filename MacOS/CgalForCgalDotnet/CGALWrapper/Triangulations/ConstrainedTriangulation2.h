#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"
#include "../Polygons/PolygonWithHoles2.h"
#include "BaseTriangulation2.h"

#include "CGAL/Segment_2.h"
#include "CGAL/Point_2.h"
#include <CGAL/Constrained_triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>
#include <CGAL/Constrained_triangulation_face_base_2.h>
#include <CGAL/Constrained_triangulation_plus_2.h>

template<class K, class TRI, class VERT, class FACE>
class ConstrainedTriangulation2 : public BaseTriangulation2<K, TRI, VERT, FACE>
{

public:

	typedef typename K::Point_2 Point_2;
	typedef CGAL::No_constraint_intersection_tag Tag1;
	typedef CGAL::No_constraint_intersection_requiring_constructions_tag Tag2;
	typedef CGAL::Exact_predicates_tag Tag3;
	typedef CGAL::Exact_intersections_tag Tag4;

	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb;
	typedef CGAL::Constrained_triangulation_face_base_2<K> CFb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K, CFb> Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;
	typedef CGAL::Constrained_triangulation_2<K, Tds, Tag4> Triangulation_2;
	
	typedef typename Triangulation_2::Face_handle Face;
	typedef typename Triangulation_2::Vertex_handle Vertex;
	typedef typename Triangulation_2::Edge Edge;

public:


	inline static ConstrainedTriangulation2* NewTriangulation2()
	{
		return new ConstrainedTriangulation2();
	}

	inline static void DeleteTriangulation2(void* ptr)
	{
		auto obj = static_cast<ConstrainedTriangulation2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static ConstrainedTriangulation2* CastToTriangulation2(void* ptr)
	{
		return static_cast<ConstrainedTriangulation2*>(ptr);
	}

	void* Copy()
	{
		auto copy = NewTriangulation2();
		copy->model = this->model;

		return copy;
	}

	template<class K2>
	static void* Convert(void* ptr)
	{
		typedef CGAL::Cartesian_converter<K, K2> Converter;
		Converter convert;

		auto tri = NewTriangulation2();
		auto tri2 = new ConstrainedTriangulation2<K2, Triangulation_2, Vertex, Face>();

		for (const auto& vert : tri->model.finite_vertex_handles())
		{
			auto p = convert(vert->point());
			//tri2->model.insert(p);
		}

		return tri2;
	}

	BOOL MoveVertex(int index, Point2d point, BOOL ifNoCollision, TriVertex2& triVert)
	{
		auto vert = this->map.FindVertex(this->model, index);
		if (vert != nullptr)
		{
			Vertex v;

			//if (ifNoCollision)
			//	v = this->model.move(*vert, point.ToCGAL<K>());
			//else
				v = this->model.move_if_no_collision(*vert, point.ToCGAL<K>());

			if (v != *vert)
				this->map.OnModelChanged();

			int degree = TriUtil::Degree2(this->model, v);
			triVert = TriVertex2::FromVertex<K>(this->model, v, degree);
			return TRUE;
		}
		else
		{
			triVert = TriVertex2::NullVertex();
			return FALSE;
		}
	}

	//Constrained only

	int ConstrainedEdgesCount()
	{
		int count = 0;
		for (auto edge = this->model.constrained_edges_begin(); edge != this->model.constrained_edges_end(); ++edge)
			++count;

		return count;
	}

	BOOL HasIncidentConstraints(int index)
	{
		auto vert = this->map.FindVertex(this->model, index);

		if (vert != nullptr)
			return this->model.are_there_incident_constraints(*vert);
		else
			return FALSE;
	}

	int IncidentConstraintCount(int index)
	{
		int count = 0;
		auto vert = this->map.FindVertex(this->model, index);
		if (vert != nullptr)
		{
			auto edge = (*vert)->incident_edges(), end(edge);
			if (edge != nullptr)
			{
				do
				{
					if (this->model.is_constrained(*edge))
						++count;

				} while (++edge != end);
			}
		}

		return count;
	}

	void InsertSegmentConstraint(Point2d a, Point2d b)
	{
		if (a == b) return;

		this->model.insert_constraint(a.ToCGAL<K>(), b.ToCGAL<K>());
		this->map.OnModelChanged();
	}

	void InsertSegmentConstraint(int vertIndex1, int vertIndex2)
	{
		auto vert1 = this->map.FindVertex(this->model, vertIndex1);
		auto vert2 = this->map.FindVertex(this->model, vertIndex2);

		if (vert1 != nullptr && vert2 != nullptr)
		{
			this->model.insert_constraint(*vert1, *vert2);
			this->map.OnModelChanged();
		}

	}

	void InsertSegmentConstraints(Segment2d* segments, int count)
	{
		for (int i = 0; i < count; i++)
		{
			if (segments[i].a == segments[i].b)
				continue;

			auto a = segments[i].a.ToCGAL<K>();
			auto b = segments[i].b.ToCGAL<K>();

			this->model.insert_constraint(a, b);
		}
		
		this->map.OnModelChanged();
	}

	void InsertPolygonConstraint(void* polyPtr)
	{
		auto polygon = Polygon2<K>::CastToPolygon2(polyPtr);
		this->model.insert_constraint(polygon->vertices_begin(), polygon->vertices_end(), true);
		this->map.OnModelChanged();
	}

	void InsertPolygonWithHolesConstraint(void* pwhPtr)
	{
		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
			this->model.insert_constraint(pwh->outer_boundary().vertices_begin(), pwh->outer_boundary().vertices_end(), true);

		for (auto& hole : pwh->holes())
			this->model.insert_constraint(hole.vertices_begin(), hole.vertices_end(), true);

		this->map.OnModelChanged();
	}

	void GetConstraints(TriEdge2* constraints, int count)
	{
		this->map.SetIndices(this->model);

		int i = 0;
		for (auto edge = this->model.constrained_edges_begin(); edge != this->model.constrained_edges_end(); ++edge)
		{
			if (!this->model.is_infinite(edge->first))
			{
				constraints[i].FaceIndex = edge->first->info();
				constraints[i].NeighbourIndex = edge->second;
			}
			else
			{
				auto neighbour = edge->first->neighbor(edge->second);
				auto n = neighbour->index(edge->first);

				if (!this->model.is_infinite(neighbour))
					constraints[i].FaceIndex = neighbour->info();
				else
					constraints[i].FaceIndex = NULL_INDEX;

				constraints[i].NeighbourIndex = n;
			}

			if (i++ >= count) return;
		}
	}

	void GetConstraints(Segment2d* constraints, int count)
	{
		this->map.SetIndices(this->model);

		int i = 0;
		for (auto edge = this->model.constrained_edges_begin(); edge != this->model.constrained_edges_end(); ++edge)
		{
			auto seg = this->model.segment(edge->first, edge->second);
			constraints[i] = Segment2d::FromCGAL<K>(seg[0], seg[1]);

			if (i++ >= count) return;
		}
	}

	void GetIncidentConstraints(int vertexIndex,  TriEdge2* constraints, int count)
	{
		int i = 0;
		auto vert = this->map.FindVertex(this->model, vertexIndex);
		if (vert != nullptr)
		{
			this->map.SetVertexIndices(this->model);
			this->map.SetFaceIndices(this->model);

			auto edge = (*vert)->incident_edges(), end(edge);
			if (edge != nullptr)
			{
				do
				{
					if (this->model.is_constrained(*edge))
					{
						if (!this->model.is_infinite(edge->first))
						{
							constraints[i].FaceIndex = edge->first->info();
							constraints[i].NeighbourIndex = edge->second;
						}
						else
						{
							auto neighbour = edge->first->neighbor(edge->second);
							auto n = neighbour->index(edge->first);

							if (!this->model.is_infinite(neighbour))
								constraints[i].FaceIndex = neighbour->info();
							else
								constraints[i].FaceIndex = NULL_INDEX;

							constraints[i].NeighbourIndex = n;
						}

						if (i++ >= count) return;
					}

				} while (++edge != end);
			}
			
		}
	}

	void RemoveConstraint(int faceIndex, int neighbourIndex)
	{
		if (neighbourIndex < 0 || neighbourIndex > 2)
			return;

		auto face = this->map.FindFace(this->model, faceIndex);
		if (face != nullptr)
		{
			this->model.remove_constraint(*face, neighbourIndex);
		}
	}

	void RemoveIncidentConstraints(int vertexIndex)
	{
		auto vert = this->map.FindVertex(this->model, vertexIndex);
		if (vert != nullptr)
		{
			this->model.remove_incident_constraints(*vert);
		}
	}

	int MarkDomains(int* indices, int count)
	{
		

		this->map.SetVertexIndices(this->model);

		//Need each face to store its nesting level.
		//Use the faces info value and then reset after.
		this->map.ForceSetFaceIndices(this->model, 0);
		this->MarkDomains(this->model);

		int num = 0;
		int index = 0;

		for (Face face : this->model.finite_face_handles())
		{
			if (face->info() % 2 == 1)
			{
				indices[index * 3 + 0] = face->vertex(0)->info();
				indices[index * 3 + 1] = face->vertex(1)->info();
				indices[index * 3 + 2] = face->vertex(2)->info();

				index++;
				num++;
			}
		}

		//Restore faces index value.
		//Face indices may have changed so 
		//increment buildd stamp as well.
		this->map.SetFaceIndices(this->model);
		this->map.IncrementBuildStamp();

		return num * 3;
	}

	private:

	void MarkDomains(Triangulation_2& ct, Face start, int index, std::list<Edge>& border)
	{
		if (start->info() != -1)
			return;

		std::list<Face> queue;
		queue.push_back(start);

		while (!queue.empty())
		{
			Face fh = queue.front();
			queue.pop_front();

			if (fh->info() == -1)
			{
				fh->info() = index;

				for (int i = 0; i < 3; i++)
				{
					Edge e(fh, i);
					Face n = fh->neighbor(i);

					if (n->info() == -1)
					{
						if (ct.is_constrained(e))
							border.push_back(e);
						else
							queue.push_back(n);
					}
				}
			}
		}
	}

	/// <summary>
	/// explore set of facets connected with non constrained edges,
	/// and attribute to each such set a nesting level.
	/// We start from facets incident to the infinite vertex, with a nesting
	/// level of 0. Then we recursively consider the non-explored facets incident
	/// to constrained edges bounding the former set and increase the nesting level by 1.
	/// Facets in the domain are those with an odd nesting level.
	/// </summary>
	/// <param name="cdt"></param>
	void MarkDomains(Triangulation_2& cdt)
	{
		for (Face f : cdt.all_face_handles())
			f->info() = -1;

		std::list<Edge> border;
		MarkDomains(cdt, cdt.infinite_face(), 0, border);

		while (!border.empty())
		{
			Edge e = border.front();
			border.pop_front();
			Face n = e.first->neighbor(e.second);

			if (n->info() == -1)
			{
				MarkDomains(cdt, n, e.first->info() + 1, border);
			}
		}
	}

};
