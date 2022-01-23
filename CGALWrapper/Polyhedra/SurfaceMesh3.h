#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "FaceVertexCount.h"

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

	static BOOL IsVertexValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid(Vertex(index));
	}

	static BOOL IsFaceValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid(Face(index));
	}

	static BOOL IsHalfedgeValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid(Halfedge(index));
	}

	static BOOL IsEdgeValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_valid(Edge(index));
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

	static void RemoveProperyMaps(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->remove_all_property_maps();
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

	static BOOL IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_border(Vertex(index), check_all_incident_halfedges);
	}

	static BOOL IsHalfedgeBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_border(Halfedge(index));
	}

	static BOOL IsEdgeBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->is_border(Edge(index));
	}

	static int BorderEdgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int count = 0;
		for (auto edge : mesh->edges())
		{
			if (mesh->is_removed(edge)) continue;
			if (mesh->is_border(edge)) count++;
		}

		return count;
	}

	static BOOL IsClosed(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		for (auto edge : mesh->edges())
		{
			if (mesh->is_removed(edge)) continue;
			if (mesh->is_border(edge)) return TRUE;
		}

		return TRUE;
	}

	static BOOL CheckFaceVertexCount(void* ptr, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		for (auto face : mesh->faces())
		{
			if (mesh->is_removed(face)) continue;

			int i = mesh->degree(face);

			if (i != count) return FALSE;
		}

		return TRUE;
	}

	static FaceVertexCount GetFaceVertexCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int degenerate = 0;
		int three = 0;
		int four = 0;
		int five = 0;
		int six = 0;
		int greater = 0;

		for (auto face : mesh->faces())
		{
			if (mesh->is_removed(face)) continue;

			int count = mesh->degree(face);

			switch (count)
			{
			case 0:
			case 1:
			case 2:
				degenerate++;
				break;

			case 3:
				three++;
				break;

			case 4:
				four++;
				break;

			case 5:
				five++;
				break;

			case 6:
				six++;
				break;

			default:
				greater++;
				break;
			}
		}

		return { degenerate, three, four, five, six, greater };
	}

	static void CreateTriangleQuadMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int trianglesCount, int* quads, int quadsCount)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		mesh->clear();
		mesh->collect_garbage();

		for (int i = 0; i < pointsCount; i++)
			mesh->add_vertex(points[i].ToCGAL<K>());

		if (trianglesCount > 0)
		{
			for (int i = 0; i < trianglesCount / 3; i++)
			{
				int i0 = triangles[i * 3 + 0];
				int i1 = triangles[i * 3 + 1];
				int i2 = triangles[i * 3 + 2];

				mesh->add_face(Vertex(i0), Vertex(i1), Vertex(i2));
			}
		}

		if (quadsCount > 0)
		{
			for (int i = 0; i < quadsCount / 4; i++)
			{
				int i0 = quads[i * 4 + 0];
				int i1 = quads[i * 4 + 1];
				int i2 = quads[i * 4 + 2];
				int i3 = quads[i * 4 + 3];

				mesh->add_face(Vertex(i0), Vertex(i1), Vertex(i2), Vertex(i3));
			}
		}
	}

	static void GetTriangleQuadIndices(void* ptr, int* triangles, int trianglesCount, int* quads, int quadsCount)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int triangleIndex = 0;
		int quadIndex = 0;

		for (auto face : mesh->faces())
		{
			if (mesh->is_removed(face)) continue;

			int count = mesh->degree(face);
			auto hedge0 = mesh->halfedge(face);

			if (count == 3 && triangleIndex < trianglesCount)
			{
				auto hedge1 = mesh->next(hedge0);
				auto hedge2 = mesh->next(hedge1);

				triangles[triangleIndex * 3 + 0] = mesh->source(hedge0).idx();
				triangles[triangleIndex * 3 + 1] = mesh->source(hedge1).idx();
				triangles[triangleIndex * 3 + 2] = mesh->source(hedge2).idx();
				triangleIndex++;
			}
			else if (count == 4 && quadIndex < quadsCount)
			{
				auto hedge1 = mesh->next(hedge0);
				auto hedge2 = mesh->next(hedge1);
				auto hedge3 = mesh->next(hedge2);

				quads[quadIndex * 4 + 0] = mesh->source(hedge0).idx();
				quads[quadIndex * 4 + 1] = mesh->source(hedge1).idx();
				quads[quadIndex * 4 + 2] = mesh->source(hedge2).idx();
				quads[quadIndex * 4 + 3] = mesh->source(hedge3).idx();
				quadIndex++;
			}
		}
	}

private:

	static int FaceVertexCount(const SurfaceMesh& mesh, Face face)
	{
		int count = 0;
		for (auto vert : mesh.vertices_around_face(mesh.halfedge(face))) {
			count++;
		}

		return count;
	}

};
