#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/Surface_mesh.h>

template<class K>
class SurfaceMesh3
{

public:

	typedef typename K::Point_3 Point_3;
	typedef CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Vertex_index Vertex;
	typedef typename SurfaceMesh::Face_index Face;

	SurfaceMesh3() {}

	inline static SurfaceMesh* NewSurfaceMesh()
	{
		return new SurfaceMesh();
	}

	inline static void DeleteSurfaceMesh(void* ptr)
	{
		auto obj = static_cast<SurfaceMesh*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static SurfaceMesh* CastToSurfaceMesh(void* ptr)
	{
		return static_cast<SurfaceMesh*>(ptr);
	}

	static void Clear(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->clear();
	}

	static BOOL IsValid(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid();
	}

	static int VertexCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->number_of_vertices();
	}

	static int HalfEdgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->number_of_halfedges();
	}

	static int EdgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->number_of_edges();
	}

	static int FaceCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->number_of_faces();
	}

	static int AddVertex(void* ptr, Point3d point)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->add_vertex(point.ToCGAL<K>());
	}

	static int AddEdge(void* ptr, int v0, int v1)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->add_edge(Vertex(v0), Vertex(v1));
	}

	static int AddFace(void* ptr, int v0, int v1, int v2)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->add_face(Vertex(v0), Vertex(v1), Vertex(v2));
	}

};
