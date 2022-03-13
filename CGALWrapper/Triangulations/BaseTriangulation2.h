#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"
#include "../Polygons/PolygonWithHoles2.h"
#include "TriUtil.h"
#include "TriVertex2.h"
#include "TriFace2.h"
#include "TriEdge2.h"
#include "TriangulationMap2.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Aff_transformation_2.h>
#include <CGAL/Cartesian_converter.h>

template<class K, class TRI, class VERT, class FACE>
class BaseTriangulation2
{

public:

	typedef typename K::Point_2 Point_2;
	typedef CGAL::Aff_transformation_2<K> Transformation_2;

	TRI model;

	TriangulationMap2<K, VERT, FACE> map;

	void Clear()
	{
		model.clear();
		map.ClearMaps();
		map.OnModelChanged();
	}

	void SetIndices()
	{
		map.OnModelChanged();
		map.SetIndices(model);
	}

	int BuildStamp()
	{
		return map.BuildStamp();
	}

	BOOL IsValid(int level)
	{
		return model.is_valid(level);
	}

	int VertexCount()
	{
		return (int)model.number_of_vertices();
	}

	int FaceCount()
	{
		return (int)model.number_of_faces();
	}

	void InsertPoint(Point2d point)
	{
		model.insert(point.ToCGAL<K>());
		map.OnModelChanged();
	}

	void InsertPoints(Point2d* points, int count)
	{
		std::vector<Point_2> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();

		model.insert(list.begin(), list.end());
		map.OnModelChanged();
	}

	void InsertPolygon(void* polyPtr)
	{
		auto polygon = Polygon2<K>::CastToPolygon2(polyPtr);
		model.insert(polygon->vertices_begin(), polygon->vertices_end());
		map.OnModelChanged();
	}

	void InsertPolygonWithHoles(void* pwhPtr)
	{
		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
			model.insert(pwh->outer_boundary().vertices_begin(), pwh->outer_boundary().vertices_end());

		for (auto& hole : pwh->holes())
			model.insert(hole.vertices_begin(), hole.vertices_end());

		map.OnModelChanged();
	}

	void InsertPoints(std::vector<Point_2>& points)
	{
		for (auto iter = points.begin(); iter != points.end(); ++iter)
			model.insert(*iter);

		map.OnModelChanged();
	}

	void GetPoints(std::vector<Point_2>& points)
	{
		for (const auto& vert : model.finite_vertex_handles())
			points.push_back(vert->point());
	}

	void GetPoints(Point2d* points, int count)
	{
		int i = 0;
		for (const auto& vert : model.finite_vertex_handles())
			points[i++] = Point2d::FromCGAL<K>(vert->point());
	}

	void GetIndices(int* indices, int count)
	{
		int index = 0;
		map.SetVertexIndices(model);

		for (auto& face : model.finite_face_handles())
		{
			indices[index * 3 + 0] = face->vertex(0)->info();
			indices[index * 3 + 1] = face->vertex(1)->info();
			indices[index * 3 + 2] = face->vertex(2)->info();

			index++;
		}
	}

	BOOL GetVertex(int index, TriVertex2& triVert)
	{
		map.SetIndices(model);

		auto vert = map.FindVertex(model, index);
		if (vert != nullptr)
		{
			int degree = TriUtil::Degree2(model, *vert);
			triVert = TriVertex2::FromVertex<K>(model, *vert, degree);
			return TRUE;
		}
		else
		{
			triVert = TriVertex2::NullVertex();
			return FALSE;
		}
	}

	void GetVertices(TriVertex2* vertices, int count)
	{
		int i = 0;

		map.SetIndices(model);

		for (const auto& vert : model.finite_vertex_handles())
		{
			int degree = TriUtil::Degree2(model, vert);
			vertices[i++] = TriVertex2::FromVertex<K>(model, vert, degree);
		}
	}

	BOOL GetFace(int index, TriFace2& triFace)
	{
		map.SetIndices(model);

		auto face = map.FindFace(model, index);
		if (face != nullptr)
		{
			triFace = TriFace2::FromFace(model, *face);
			return TRUE;
		}
		else
		{
			triFace = TriFace2::NullFace();
			return FALSE;
		}
	}

	void GetFaces(TriFace2* faces, int count)
	{
		int i = 0;

		map.SetIndices(model);

		for (const auto& face : model.finite_face_handles())
			faces[i++] = TriFace2::FromFace(model, face);
	}

	BOOL GetSegment(int faceIndex, int neighbourIndex, Segment2d& segment)
	{
		if (neighbourIndex < 0 || neighbourIndex > 2)
			return FALSE;

		auto face = map.FindFace(model, faceIndex);
		if (face != nullptr)
		{
			if (model.is_infinite(*face))
				return FALSE;

			auto seg = model.segment(*face, neighbourIndex);
			segment = Segment2d::FromCGAL<K>(seg[0], seg[1]);

			return TRUE;
		}
		else
		{
			segment = {};
			return FALSE;
		}
	}

	BOOL GetTriangle(int faceIndex, Triangle2d& triangle)
	{
		auto face = map.FindFace(model, faceIndex);
		if (face != nullptr)
		{
			if (model.is_infinite(*face))
				return FALSE;

			auto t = model.triangle(*face);
			triangle = Triangle2d::FromCGAL<K>(t[0], t[1], t[2]);

			return TRUE;
		}
		else
		{
			triangle = {};
			return FALSE;
		}
	}

	void GetTriangles(Triangle2d* triangles, int count)
	{
		int i = 0;
		for (const auto& face : model.finite_face_handles())
		{
			auto t = model.triangle(face);
			triangles[i++] = Triangle2d::FromCGAL<K>(t[0], t[1], t[2]);
		}
	}

	BOOL GetCircumcenter(int faceIndex, Point2d& circumcenter)
	{
		auto face = map.FindFace(model, faceIndex);
		if (face != nullptr)
		{
			if (model.is_infinite(*face))
				return FALSE;

			auto c = model.circumcenter(*face);
			circumcenter = Point2d::FromCGAL<K>(c);

			return TRUE;
		}
		else
		{
			circumcenter = { 0, 0 };
			return FALSE;
		}
	}

	void GetCircumcenters(Point2d* circumcenters, int count)
	{
		int i = 0;
		for (const auto& face : model.finite_face_handles())
		{
			auto c = model.circumcenter(face);
			circumcenters[i++] = Point2d::FromCGAL<K>(c);
		}
	}

	int NeighbourIndex(int faceIndex, int index)
	{
		if (index < 0 || index > 2)
			return -1;

		 map.SetFaceIndices( model);

		auto face =  map.FindFace( model, faceIndex);
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

	BOOL LocateFace(Point2d point, TriFace2& triFace)
	{
		 map.SetIndices( model);

		auto face =  model.locate(point.ToCGAL<K>());
		if (face != nullptr)
		{
			triFace = TriFace2::FromFace( model, face);
			return TRUE;
		}
		else
		{
			triFace = TriFace2::NullFace();
			return FALSE;
		}
	}

	BOOL MoveVertex(int index, Point2d point, BOOL ifNoCollision, TriVertex2& triVert)
	{
		auto vert =  map.FindVertex( model, index);
		if (vert != nullptr)
		{
			VERT v;

			if (ifNoCollision)
				v =  model.move(*vert, point.ToCGAL<K>());
			else
				v =  model.move_if_no_collision(*vert, point.ToCGAL<K>());

			if (v != *vert)
				 map.OnModelChanged();

			int degree = TriUtil::Degree2( model, v);
			triVert = TriVertex2::FromVertex<K>( model, v, degree);
			return TRUE;
		}
		else
		{
			triVert = TriVertex2::NullVertex();
			return FALSE;
		}
	}

	BOOL RemoveVertex(int index)
	{
		auto vert =  map.FindVertex( model, index);
		if (vert != nullptr)
		{
			 model.remove(*vert);
			 map.OnModelChanged();
			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	BOOL FlipEdge(int faceIndex, int neighbourIndex)
	{
		if (neighbourIndex < 0 || neighbourIndex > 2)
			return FALSE;

		auto face =  map.FindFace( model, faceIndex);
		if (face != nullptr)
		{
			if ( model.is_infinite(*face))
				return FALSE;

			 model.flip(*face, neighbourIndex);
			 map.OnModelChanged();
			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	void Transform(Point2d translation, double rotation, double scale)
	{
		Transformation_2 T(CGAL::TRANSLATION, translation.ToVector<K>());
		Transformation_2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
		Transformation_2 S(CGAL::SCALING, scale);

		auto M = T * R * S;
		for (auto& vert :  model.finite_vertex_handles())
			vert->point() = M(vert->point());
	}


};
