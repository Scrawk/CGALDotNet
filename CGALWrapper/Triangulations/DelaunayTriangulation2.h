#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"
#include "../Polygons/PolygonWithHoles2.h"
#include "TriUtil.h"
#include "TriVertex2.h"
#include "TriFace2.h"
#include "TriangulationMap.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Delaunay_triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>
#include <CGAL/Delaunay_mesh_face_base_2.h>
#include <CGAL/Delaunay_mesh_vertex_base_2.h>
#include <CGAL/Aff_transformation_2.h>

template<class K>
class DelaunayTriangulation2
{

public:

	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K> Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;

	typedef CGAL::Delaunay_triangulation_2<K, Tds> Triangulation_2;
	typedef typename Triangulation_2::Point Point_2;

	typedef typename Triangulation_2::Finite_faces_iterator Finite_faces;
	typedef typename Triangulation_2::Finite_vertices_iterator Finite_vertices;
	typedef typename Triangulation_2::Face_handle Face;
	typedef typename Triangulation_2::Vertex_handle Vertex;

	typedef CGAL::Aff_transformation_2<K> Transformation_2;

private:

	Triangulation_2 model;

	TriangulationMap<K, Vertex, Face> map;

public:

	DelaunayTriangulation2()
	{
		map.OnModelChanged();
	}

	~DelaunayTriangulation2()
	{

	}

	inline static DelaunayTriangulation2* NewTriangulation2()
	{
		return new DelaunayTriangulation2();
	}

	inline static void DeleteTriangulation2(void* ptr)
	{
		auto obj = static_cast<DelaunayTriangulation2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static DelaunayTriangulation2* CastToTriangulation2(void* ptr)
	{
		return static_cast<DelaunayTriangulation2*>(ptr);
	}

	static void Clear(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->model.clear();
		tri->map.ClearMaps();
	}

	static void* Copy(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);

		auto copy = new DelaunayTriangulation2<K>();
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

	static void GetFaces(void* ptr, TriFace2* faces,int count)
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

			if (ifNoCollision)
				v = tri->model.move(*vert, point.ToCGAL<K>());
			else
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

		Transformation_2 T(CGAL::TRANSLATION, translation.ToVector<EEK>());
		Transformation_2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
		Transformation_2 S(CGAL::SCALING, scale);

		auto M = T * R * S;
		for (auto& vert : tri->model.finite_vertex_handles())
			vert->point() = M(vert->point());
	}

	static void VoronoiCount(void* ptr, int& numSegments, int& numRays)
	{
		auto tri = CastToTriangulation2(ptr);
		
		numSegments = 0;
		numRays = 0;

		for (auto eit = tri->model.edges_begin(); eit != tri->model.edges_end(); ++eit)
		{
			CGAL::Object o = tri->model.dual(eit);
			if (CGAL::object_cast<K::Segment_2>(&o))
				numSegments++;
			else if (CGAL::object_cast<K::Ray_2>(&o))
				numRays++;
		}
	}

	static int VoronoiSegmentCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		int count = 0;

		for (auto eit = tri->model.edges_begin(); eit != tri->model.edges_end(); ++eit)
		{
			CGAL::Object o = tri->model.dual(eit);
			if (CGAL::object_cast<K::Segment_2>(&o)) 
				++count;
		}

		return count;
	}

	static int VoronoiRayCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		int count = 0;

		for (auto eit = tri->model.edges_begin(); eit != tri->model.edges_end(); ++eit)
		{
			CGAL::Object o = tri->model.dual(eit);
			if (CGAL::object_cast<K::Ray_2>(&o))
				++count;
		}

		return count;
	}

	static void GetVoronoiSegments(void* ptr, Segment2d* segments, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		for (auto eit = tri->model.edges_begin(); eit != tri->model.edges_end(); ++eit)
		{
			if (i >= count) return;

			CGAL::Object o = tri->model.dual(eit);
			if (auto seg = CGAL::object_cast<K::Segment_2>(&o))
				segments[i++] = Segment2d::FromCGAL<K>(seg->source(), seg->target());
		}
	}

	static void GetVoronoiRays(void* ptr, Ray2d* rays, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		for (auto eit = tri->model.edges_begin(); eit != tri->model.edges_end(); ++eit)
		{
			if (i >= count) return;

			CGAL::Object o = tri->model.dual(eit);
			if (auto ray = CGAL::object_cast<K::Ray_2>(&o))
				rays[i++] = Ray2d::FromCGAL<K>(ray->source(), ray->to_vector());
		}
	}


};
