#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "Polygon2.h"
#include "PolygonWithHoles2.h"
#include "IndexMap.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>

struct TriVertex2
{
	Point2d Point;
	int Degree;
	int Index;
	int FaceIndex;
};

struct TriFace2
{
	int Index;
	int VertexIndices[3];
};

template<class K>
class Triangulation2
{

public:

	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K> Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;

	typedef CGAL::Triangulation_2<K, Tds> Triangulation_2;
	typedef typename Triangulation_2::Point Point_2;

	typedef typename Triangulation_2::Finite_faces_iterator Finite_faces;
	typedef typename Triangulation_2::Finite_vertices_iterator Finite_vertices;
	typedef typename Triangulation_2::Face_handle Face;
	typedef typename Triangulation_2::Vertex_handle Vertex;


private:

	Triangulation_2 model;

	IndexMap<Vertex> vertexMap;

	IndexMap<Face> faceMap;

public:

	Triangulation2()
	{

	}

	~Triangulation2()
	{

	}

	inline static Triangulation2* CastToTriangulation2(void* ptr)
	{
		return static_cast<Triangulation2*>(ptr);
	}

	void SetVertexIndices()
	{
		if (vertexMap.indicesSet)
			return;

		vertexMap.Clear();

		for (auto& vert : model.finite_vertex_handles())
			vert->info() = vertexMap.NextIndex();

		vertexMap.indicesSet = true;
	}

	void BuildVertexMap()
	{
		if (vertexMap.mapBuilt)
			return;

		vertexMap.ClearMap();

		for (auto& vert : model.finite_vertex_handles())
			vertexMap.Insert(vert->info(), vert);

		vertexMap.mapBuilt = true;
	}

	void SetFaceIndices()
	{
		if (faceMap.indicesSet)
			return;

		faceMap.Clear();

		for (auto& face : model.finite_face_handles())
			face->info() = faceMap.NextIndex();

		faceMap.indicesSet = true;
	}

	void BuildFaceMap()
	{
		if (faceMap.mapBuilt) 
			return;

		faceMap.ClearMap();

		for (auto& face : model.finite_face_handles())
			faceMap.Insert(face->info(), face);

		faceMap.mapBuilt = true;
	}

	void BuildMaps()
	{
		BuildVertexMap();
		BuildFaceMap();
	}

	void ClearMaps()
	{
		vertexMap.Clear();
		faceMap.Clear();
	}

	void OnModelChanged()
	{
		ClearMaps();
	}

	static void Clear(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->model.clear();
		tri->ClearMaps();
	}

	static void* Copy(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);

		auto copy = new Triangulation2<K>();
		copy->model = tri->model;

		return copy;
	}

	static BOOL IsValid(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return tri->model.is_valid();
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
		tri->model.insert(point.To<K>());
		tri->OnModelChanged();
	}

	static void InsertPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto tri = CastToTriangulation2(ptr);

		std::vector<Point_2> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[startIndex + i].To<K>();

		tri->model.insert(list.begin(), list.end());
		tri->OnModelChanged();
	}

	static void InsertPolygon(void* triPtr, void* polyPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto polygon = Polygon2<K>::CastToPolygon2(polyPtr);
		tri->model.insert(polygon->vertices_begin(), polygon->vertices_end());
		tri->OnModelChanged();
	}

	static void InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if(!pwh->is_unbounded())
			tri->model.insert(pwh->outer_boundary().vertices_begin(), pwh->outer_boundary().vertices_end());

		for (auto& hole : pwh->holes())
			tri->model.insert(hole.vertices_begin(), hole.vertices_end());

		tri->OnModelChanged();
	}

	static void GetPoints(void* ptr, Point2d* points, int startIndex, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = startIndex;

		for (const auto& vert : tri->model.finite_vertex_handles())
			points[i++].From<K>(vert->point());
	}

	static void GetIndices(void* ptr, int* indices, int startIndex, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int index = startIndex;

		tri->SetVertexIndices();

		for (auto& face : tri->model.finite_face_handles())
		{
			indices[index * 3 + 0] = face->vertex(0)->info();
			indices[index * 3 + 1] = face->vertex(1)->info();
			indices[index * 3 + 2] = face->vertex(2)->info();

			index++;
		}
	}

	static void GetVertices(void* ptr, TriVertex2* vertices, int startIndex, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = startIndex;

		tri->SetVertexIndices();

		for (const auto& vert : tri->model.finite_vertex_handles())
		{
			vertices[i].Point.From<K>(vert->point());
			vertices[i].Degree = vert->degree();
			vertices[i].Index = vert->info();
			vertices[i].FaceIndex = vert->face()->info();

			i++;
		}
			
	}

};
