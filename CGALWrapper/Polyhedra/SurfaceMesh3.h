#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"

#include <CGAL/Surface_mesh.h>
#include <CGAL/Aff_transformation_3.h>
#include <unordered_set>

template<class K>
class SurfaceMesh3
{

public:

	typedef typename K::Point_3 Point_3;
	typedef CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Edge_index Edge;
	typedef typename SurfaceMesh::Halfedge_index Halfedge;
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

	static SurfaceMesh* Copy(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return new SurfaceMesh(*mesh);
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

	static int AddTriangle(void* ptr, int v0, int v1, int v2)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->add_face(Vertex(v0), Vertex(v1), Vertex(v2));
	}

	static int AddQuad(void* ptr, int v0, int v1, int v2, int v3)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->add_face(Vertex(v0), Vertex(v1), Vertex(v2), Vertex(v3));
	}

	static BOOL HasGarbage(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->has_garbage();
	}

	static void CollectGarbage(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->collect_garbage();
	}

	static void SetRecycleGarbage(void* ptr, BOOL collect)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->set_recycle_garbage(collect);
	}

	static BOOL DoesRecycleGarbage(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->does_recycle_garbage();
	}

	static int VertexDegree(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->degree(Vertex(index));
	}

	static int FaceDegree(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->degree(Face(index));
	}

	static BOOL VertexIsIsolated(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_isolated(Vertex(index));
	}

	static BOOL VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_border(Vertex(index), check_all_incident_halfedges);
	}

	static BOOL EdgeIsBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_border(Edge(index));
	}

	static int NextHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->next(Halfedge(index));
	}

	static int PreviousHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->prev(Halfedge(index));
	}

	static int OppositeHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->opposite(Halfedge(index));
	}

	static int SourceVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->source(Halfedge(index));
	}

	static int TargetVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->target(Halfedge(index));
	}

	static void RemoveVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->remove_vertex(Vertex(index));
	}

	static void RemoveEdge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->remove_edge(Edge(index));
	}

	static void RemoveFace(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->remove_face(Face(index));
	}

	static BOOL IsVertexValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid(Vertex(index));
	}

	static BOOL IsEdgeValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid(Edge(index));
	}

	static BOOL IsHalfedgeValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid(Halfedge(index));
	}

	static BOOL IsFaceValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid(Face(index));
	}

	static Point3d GetPoint(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto point = mesh->point(Vertex(index));
		return Point3d::FromCGAL<K>(point);
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		int index = 0;
		for (auto point = mesh->points().begin(); point != mesh->points().end(); ++point)
		{
			points[index] = Point3d::FromCGAL<K>(*point);

			index++;
			if (index >= count)
				return;
		}

	}

	static void Transform(void* ptr, const Matrix4x4d& matrix)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto m = matrix.ToCGAL<K>();

		std::transform(mesh->points().begin(), mesh->points().end(), mesh->points().begin(), m);
	}

	static void CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* indices, int indicesCount)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		mesh->clear();
		mesh->collect_garbage();

		for (int i = 0; i < pointsCount; i++)
			mesh->add_vertex(points[i].ToCGAL<K>());

		for (int i = 0; i < indicesCount / 3; i++)
		{
			int i0 = indices[i * 3 + 0];
			int i1 = indices[i * 3 + 1];
			int i2 = indices[i * 3 + 2];

			mesh->add_face(Vertex(i0), Vertex(i1), Vertex(i2));
		}

	}

	//following code not working.

	/*
	static BOOL CheckFaceVertices(void* ptr, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		std::unordered_set<int> set;

		for (auto edge = mesh->halfedges().begin(); edge != mesh->halfedges().end(); ++edge)
		{
			//halfe edge has already been checked if in set.
			if (set.find(edge->idx()) == set.end()) continue;
			//Add halfedge to set.
			set.insert(edge->idx());

			//Get the edges face if not null.
			auto face = mesh->face(*edge);
			//if (face == mesh->null_face()) continue;

			//Count the number of vertices in face.
			int faceVertices = 0;
			for (auto vertex : mesh->vertices_around_face(mesh->halfedge(face)))
			{
				if (faceVertices >= count)
					return FALSE;

				faceVertices++;
			}
		}

		return TRUE;
	}

	static int MaxFaceVertices(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		std::unordered_set<int> set;

		int max_value = -1;

		for (auto edge = mesh->halfedges().begin(); edge != mesh->halfedges().end(); ++edge)
		{
			//halfe edge has already been checked if in set.
			if (set.find(edge->idx()) == set.end()) continue;
			//Add halfedge to set.
			set.insert(edge->idx());

			//Get the edges face if not null.
			auto face = mesh->face(*edge);
			//if (face == mesh->null_face()) continue;

			//Count the number of vertices in face.
			int faceVertices = 0;
			for (auto vertex : mesh->vertices_around_face(mesh->halfedge(face)))
			{
				faceVertices++;
			}

			if (faceVertices > max_value)
				max_value = faceVertices;
		}

		return max_value;
	}

	static void GetTriangleIndices(void* ptr, int* indices, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		std::unordered_set<int> set;

		int arr[3] = { 0, 0, 0 };

		int index = 0;
		for (auto edge = mesh->halfedges().begin(); edge != mesh->halfedges().end(); ++edge)
		{
			//halfe edge has already been checked if in set.
			if (set.find(edge->idx()) == set.end()) continue;
			//Add halfedge to set.
			set.insert(edge->idx());

			//Get the edges face if not null.
			auto face = mesh->face(*edge);
			//if (face == mesh->null_face()) continue;

			//Count the number of vertices in face.
			int faceVertices = 0;
			for (auto vertex : mesh->vertices_around_face(mesh->halfedge(face)))
			{
				arr[faceVertices] = vertex.idx();
				faceVertices++;

				if (faceVertices >= 3) break;
			}

			//If this is a triangle mesh then add the indices.
			if (faceVertices < 3)
			{
				indices[index * 3 + 0] = arr[0];
				indices[index * 3 + 1] = arr[1];
				indices[index * 3 + 2] = arr[2];
				index++;

				if (index * 3 >= count) return;
			}

		}
	}
	*/
	

};
