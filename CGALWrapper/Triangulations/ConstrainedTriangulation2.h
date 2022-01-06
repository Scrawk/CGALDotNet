#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"
#include "../Polygons/PolygonWithHoles2.h"
#include "TriUtil.h"
#include "TriVertex2.h"
#include "TriFace2.h"
#include "TriEdge2.h"
#include "TriangulationMap.h"

#include "CGAL/Segment_2.h"

#include <vector>
#include <list>
#include "CGAL/Point_2.h"
#include <CGAL/Constrained_triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>

#include <CGAL/Constrained_triangulation_face_base_2.h>
#include <CGAL/Constrained_triangulation_plus_2.h>
#include <CGAL/Aff_transformation_2.h>


template<class K>
class ConstrainedTriangulation2
{

public:

	typedef CGAL::No_constraint_intersection_tag Tag1;
	typedef CGAL::No_constraint_intersection_requiring_constructions_tag Tag2;
	typedef CGAL::Exact_predicates_tag Tag3;
	typedef CGAL::Exact_intersections_tag Tag4;

	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb;
	typedef CGAL::Constrained_triangulation_face_base_2<K> CFb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K, CFb> Fb;

	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;

	typedef CGAL::Constrained_triangulation_2<K, Tds, Tag4> Triangulation_2;
	typedef typename Triangulation_2::Point Point_2;

	typedef typename Triangulation_2::Finite_faces_iterator Finite_faces;
	typedef typename Triangulation_2::Finite_vertices_iterator Finite_vertices;

	typedef typename Triangulation_2::Face_circulator Face_circulator;
	typedef typename Triangulation_2::Edge_circulator Edge_circulator;
	typedef typename Triangulation_2::Vertex_circulator Vertex_circulator;

	typedef typename Triangulation_2::Face_handle Face;
	typedef typename Triangulation_2::Vertex_handle Vertex;
	typedef typename Tds::Edge Edge;

	typedef CGAL::Aff_transformation_2<K> Transformation_2;

	Triangulation_2 model;

	TriangulationMap<K, Vertex, Face> map;

	ConstrainedTriangulation2()
	{
		map.OnModelChanged();
	}

	~ConstrainedTriangulation2()
	{

	}

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

	static void Clear(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->model.clear();
		tri->map.ClearMaps();
	}

	void Clear()
	{
		model.clear();
		map.ClearMaps();
	}

	static void* Copy(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);

		auto copy = new ConstrainedTriangulation2<K>();
		copy->model = tri->model;

		return copy;
	}

	static void SetIndices(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->map.OnModelChanged();
		tri->map.SetIndices(tri->model);
	}

	static int BuildStamp(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return tri->map.BuildStamp();
	}

	static BOOL IsValid(void* ptr, int level)
	{
		auto tri = CastToTriangulation2(ptr);
		return tri->model.is_valid(level);
	}

	static int VertexCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return (int)tri->model.number_of_vertices();
	}

	static int FaceCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return (int)tri->model.number_of_faces();
	}

	static void InsertPoint(void* ptr, Point2d point)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->model.insert(point.ToCGAL<K>());
		tri->map.OnModelChanged();
	}

	void InsertPoints(const std::vector<Point_2>& points)
	{
		model.insert(points.begin(), points.end());
		map.OnModelChanged();
	}

	static void InsertPoints(void* ptr, Point2d* points, int count)
	{
		auto tri = CastToTriangulation2(ptr);

		std::vector<Point_2> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();

		tri->model.insert(list.begin(), list.end());
		tri->map.OnModelChanged();
	}

	static void InsertPolygon(void* triPtr, void* polyPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto polygon = Polygon2<K>::CastToPolygon2(polyPtr);
		tri->model.insert(polygon->vertices_begin(), polygon->vertices_end());
		tri->map.OnModelChanged();
	}

	static void InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
			tri->model.insert(pwh->outer_boundary().vertices_begin(), pwh->outer_boundary().vertices_end());

		for (auto& hole : pwh->holes())
			tri->model.insert(hole.vertices_begin(), hole.vertices_end());

		tri->map.OnModelChanged();
	}

	static void GetPoints(void* ptr, Point2d* points, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		for (const auto& vert : tri->model.finite_vertex_handles())
			points[i++] = Point2d::FromCGAL<K>(vert->point());
	}

	void GetPoints(std::vector<Point_2>& points)
	{
		for (const auto& vert : model.finite_vertex_handles())
			points.push_back(vert->point());
	}

	static void GetIndices(void* ptr, int* indices, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int index = 0;

		tri->map.SetVertexIndices(tri->model);

		for (auto& face : tri->model.finite_face_handles())
		{
			indices[index * 3 + 0] = face->vertex(0)->info();
			indices[index * 3 + 1] = face->vertex(1)->info();
			indices[index * 3 + 2] = face->vertex(2)->info();

			index++;
		}
	}

	static BOOL GetVertex(void* ptr, int index, TriVertex2& triVert)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->map.SetIndices(tri->model);

		auto vert = tri->map.FindVertex(tri->model, index);
		if (vert != nullptr)
		{
			int degree = TriUtil::Degree(tri->model, *vert);
			triVert = TriVertex2::FromVertex<K>(tri->model, *vert, degree);
			return TRUE;
		}
		else
		{
			triVert = TriVertex2::NullVertex();
			return FALSE;
		}
	}

	static void GetVertices(void* ptr, TriVertex2* vertices, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		tri->map.SetIndices(tri->model);

		for (const auto& vert : tri->model.finite_vertex_handles())
		{
			int degree = TriUtil::Degree(tri->model, vert);
			vertices[i++] = TriVertex2::FromVertex<K>(tri->model, vert, degree);
		}
	}

	static BOOL GetFace(void* ptr, int index, TriFace2& triFace)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->map.SetIndices(tri->model);

		auto face = tri->map.FindFace(tri->model, index);
		if (face != nullptr)
		{
			triFace = TriFace2::FromFace(tri->model, *face);
			return TRUE;
		}
		else
		{
			triFace = TriFace2::NullFace();
			return FALSE;
		}
	}

	static void GetFaces(void* ptr, TriFace2* faces, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		tri->map.SetIndices(tri->model);

		for (const auto& face : tri->model.finite_face_handles())
			faces[i++] = TriFace2::FromFace(tri->model, face);
	}

	static BOOL GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
	{
		if (neighbourIndex < 0 || neighbourIndex > 2)
			return FALSE;

		auto tri = CastToTriangulation2(ptr);

		auto face = tri->map.FindFace(tri->model, faceIndex);
		if (face != nullptr)
		{
			if (tri->model.is_infinite(*face))
				return FALSE;

			auto seg = tri->model.segment(*face, neighbourIndex);
			segment = Segment2d::FromCGAL<K>(seg[0], seg[1]);

			return TRUE;
		}
		else
		{
			segment = {};
			return FALSE;
		}
	}

	static BOOL GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
	{
		auto tri = CastToTriangulation2(ptr);

		auto face = tri->map.FindFace(tri->model, faceIndex);
		if (face != nullptr)
		{
			if (tri->model.is_infinite(*face))
				return FALSE;

			auto t = tri->model.triangle(*face);
			triangle = Triangle2d::FromCGAL<K>(t[0], t[1], t[2]);

			return TRUE;
		}
		else
		{
			triangle = {};
			return FALSE;
		}
	}

	static void GetTriangles(void* ptr, Triangle2d* triangles, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		for (const auto& face : tri->model.finite_face_handles())
		{
			auto t = tri->model.triangle(face);
			triangles[i++] = Triangle2d::FromCGAL<K>(t[0], t[1], t[2]);
		}
	}

	static BOOL GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
	{
		auto tri = CastToTriangulation2(ptr);

		auto face = tri->map.FindFace(tri->model, faceIndex);

		if (face != nullptr)
		{
			if (tri->model.is_infinite(*face))
				return FALSE;

			auto c = tri->model.circumcenter(*face);
			circumcenter = Point2d::FromCGAL<K>(c);

			return TRUE;
		}
		else
		{
			circumcenter = { 0, 0 };
			return FALSE;
		}
	}

	static void GetCircumcenters(void* ptr, Point2d* circumcenters, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		for (const auto& face : tri->model.finite_face_handles())
		{
			auto c = tri->model.circumcenter(face);
			circumcenters[i++] = Point2d::FromCGAL<K>(c);
		}
	}

	static int NeighbourIndex(void* ptr, int faceIndex, int index)
	{
		if (index < 0 || index > 2)
			return -1;

		auto tri = CastToTriangulation2(ptr);
		tri->map.SetFaceIndices(tri->model);

		auto face = tri->map.FindFace(tri->model, faceIndex);
		if (face != nullptr)
		{
			auto neighbour = (*face)->neighbor(index);

			if (neighbour != nullptr)
				return neighbour->info();
			else
				return -1;
		}
		else
		{
			return -1;
		}
	}

	static BOOL LocateFace(void* ptr, Point2d point, TriFace2& triFace)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->map.SetIndices(tri->model);

		auto face = tri->model.locate(point.ToCGAL<K>());
		if (face != nullptr)
		{
			triFace = TriFace2::FromFace(tri->model, face);
			return TRUE;
		}
		else
		{
			triFace = TriFace2::NullFace();
			return FALSE;
		}
	}

	static BOOL MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& triVert)
	{
		auto tri = CastToTriangulation2(ptr);

		auto vert = tri->map.FindVertex(tri->model, index);
		if (vert != nullptr)
		{
			Vertex v;

			//if (ifNoCollision)
			//	v = tri->model.move(*vert, point.ToCGAL<K>());
			//else
				v = tri->model.move_if_no_collision(*vert, point.ToCGAL<K>());

			if (v != *vert)
				tri->map.OnModelChanged();

			int degree = TriUtil::Degree(tri->model, v);
			triVert = TriVertex2::FromVertex<K>(tri->model, v, degree);
			return TRUE;
		}
		else
		{
			triVert = TriVertex2::NullVertex();
			return FALSE;
		}
	}

	static BOOL RemoveVertex(void* ptr, int index)
	{
		auto tri = CastToTriangulation2(ptr);

		auto vert = tri->map.FindVertex(tri->model, index);
		if (vert != nullptr)
		{
			tri->model.remove(*vert);
			tri->map.OnModelChanged();
			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	static BOOL FlipEdge(void* ptr, int faceIndex, int neighbourIndex)
	{
		if (neighbourIndex < 0 || neighbourIndex > 2)
			return FALSE;

		auto tri = CastToTriangulation2(ptr);

		auto face = tri->map.FindFace(tri->model, faceIndex);
		if (face != nullptr)
		{
			if (tri->model.is_infinite(*face))
				return FALSE;

			tri->model.flip(*face, neighbourIndex);
			tri->map.OnModelChanged();
			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	static void Transform(void* ptr, Point2d translation, double rotation, double scale)
	{
		auto tri = CastToTriangulation2(ptr);

		Transformation_2 T(CGAL::TRANSLATION, translation.ToVector<K>());
		Transformation_2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
		Transformation_2 S(CGAL::SCALING, scale);

		auto M = T * R * S;
		for (auto& vert : tri->model.finite_vertex_handles())
			vert->point() = M(vert->point());
	}

	//Constrained only

	static int ConstrainedEdgesCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);

		int count = 0;
		for (auto edge = tri->model.constrained_edges_begin(); edge != tri->model.constrained_edges_end(); ++edge)
			++count;

		return count;
	}

	static BOOL HasIncidentConstraints(void* ptr, int index)
	{
		auto tri = CastToTriangulation2(ptr);

		auto vert = tri->map.FindVertex(tri->model, index);

		if (vert != nullptr)
			return tri->model.are_there_incident_constraints(*vert);
		else
			return FALSE;
	}

	static int IncidentConstraintCount(void* ptr, int index)
	{
		auto tri = CastToTriangulation2(ptr);

		int count = 0;

		auto vert = tri->map.FindVertex(tri->model, index);
		if (vert != nullptr)
		{
			auto edge = (*vert)->incident_edges(), end(edge);
			if (edge != nullptr)
			{
				do
				{
					if (tri->model.is_constrained(*edge))
						++count;

				} while (++edge != end);
			}
		}

		return count;
	}

	static void InsertSegmentConstraint(void* ptr, Point2d a, Point2d b)
	{
		if (a == b) return;

		auto tri = CastToTriangulation2(ptr);

		tri->model.insert_constraint(a.ToCGAL<K>(), b.ToCGAL<K>());
		tri->map.OnModelChanged();
	}

	static void InsertSegmentConstraint(void* ptr, int vertIndex1, int vertIndex2)
	{
		auto tri = CastToTriangulation2(ptr);

		auto vert1 = tri->map.FindVertex(tri->model, vertIndex1);
		auto vert2 = tri->map.FindVertex(tri->model, vertIndex2);

		if (vert1 != nullptr && vert2 != nullptr)
		{
			tri->model.insert_constraint(*vert1, *vert2);
			tri->map.OnModelChanged();
		}

	}

	static void InsertSegmentConstraints(void* ptr, Segment2d* segments, int count)
	{
		auto tri = CastToTriangulation2(ptr);

		for (int i = 0; i < count; i++)
		{
			if (segments[i].a == segments[i].b)
				continue;

			auto a = segments[i].a.ToCGAL<K>();
			auto b = segments[i].b.ToCGAL<K>();

			tri->model.insert_constraint(a, b);
		}
		
		tri->map.OnModelChanged();
	}

	static void InsertPolygonConstraint(void* triPtr, void* polyPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto polygon = Polygon2<K>::CastToPolygon2(polyPtr);
		tri->model.insert_constraint(polygon->vertices_begin(), polygon->vertices_end(), true);
		tri->map.OnModelChanged();
	}

	static void InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
			tri->model.insert_constraint(pwh->outer_boundary().vertices_begin(), pwh->outer_boundary().vertices_end(), true);

		for (auto& hole : pwh->holes())
			tri->model.insert_constraint(hole.vertices_begin(), hole.vertices_end(), true);

		tri->map.OnModelChanged();
	}

	static void GetConstraints(void* ptr, TriEdge2* constraints, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		tri->map.SetIndices(tri->model);

		for (auto edge = tri->model.constrained_edges_begin(); edge != tri->model.constrained_edges_end(); ++edge)
		{
			if (!tri->model.is_infinite(edge->first))
			{
				constraints[i].FaceIndex = edge->first->info();
				constraints[i].NeighbourIndex = edge->second;
			}
			else
			{
				auto neighbour = edge->first->neighbor(edge->second);
				auto n = neighbour->index(edge->first);

				if (!tri->model.is_infinite(neighbour))
					constraints[i].FaceIndex = neighbour->info();
				else
					constraints[i].FaceIndex = NULL_INDEX;

				constraints[i].NeighbourIndex = n;
			}

			if (i++ >= count) return;
		}
	}

	static void GetConstraints(void* ptr, Segment2d* constraints, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		tri->map.SetIndices(tri->model);

		for (auto edge = tri->model.constrained_edges_begin(); edge != tri->model.constrained_edges_end(); ++edge)
		{
			auto seg = tri->model.segment(edge->first, edge->second);
			constraints[i] = Segment2d::FromCGAL<K>(seg[0], seg[1]);

			if (i++ >= count) return;
		}
	}

	static void GetIncidentConstraints(void* ptr, int vertexIndex,  TriEdge2* constraints, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		auto vert = tri->map.FindVertex(tri->model, vertexIndex);
		if (vert != nullptr)
		{
			tri->map.SetVertexIndices(tri->model);
			tri->map.SetFaceIndices(tri->model);

			auto edge = (*vert)->incident_edges(), end(edge);
			if (edge != nullptr)
			{
				do
				{
					if (tri->model.is_constrained(*edge))
					{
						if (!tri->model.is_infinite(edge->first))
						{
							constraints[i].FaceIndex = edge->first->info();
							constraints[i].NeighbourIndex = edge->second;
						}
						else
						{
							auto neighbour = edge->first->neighbor(edge->second);
							auto n = neighbour->index(edge->first);

							if (!tri->model.is_infinite(neighbour))
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

	static void RemoveConstraint(void* ptr, int faceIndex, int neighbourIndex)
	{
		if (neighbourIndex < 0 || neighbourIndex > 2)
			return;

		auto tri = CastToTriangulation2(ptr);

		auto face = tri->map.FindFace(tri->model, faceIndex);
		if (face != nullptr)
		{
			tri->model.remove_constraint(*face, neighbourIndex);
		}
	}

	static void RemoveIncidentConstraints(void* ptr, int vertexIndex)
	{
		auto tri = CastToTriangulation2(ptr);

		auto vert = tri->map.FindVertex(tri->model, vertexIndex);
		if (vert != nullptr)
		{
			tri->model.remove_incident_constraints(*vert);
		}
	}

	static int MarkDomains(void* ptr, int* indices, int count)
	{
		auto tri = CastToTriangulation2(ptr);

		tri->map.SetVertexIndices(tri->model);

		//Need each face to store its nesting level.
		//Use the faces info value and then reset after.
		tri->map.ForceSetFaceIndices(tri->model, 0);
		tri->MarkDomains(tri->model);

		int num = 0;
		int index = 0;

		for (Face face : tri->model.finite_face_handles())
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
		tri->map.SetFaceIndices(tri->model);
		tri->map.IncrementBuildStamp();

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
