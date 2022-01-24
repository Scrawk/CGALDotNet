#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "FaceVertexCount.h"

#include <limits>
#include <fstream>
#include <iostream>
#include <CGAL/Surface_mesh.h>
#include <CGAL/Aff_transformation_3.h>
#include <unordered_set>

#include <CGAL/Polygon_mesh_processing/triangulate_faces.h>
#include <CGAL/Side_of_triangle_mesh.h>
#include <CGAL/Polygon_mesh_processing/orientation.h>
#include <CGAL/Polygon_mesh_processing/self_intersections.h>
#include <CGAL/Polygon_mesh_processing/measure.h>
#include <CGAL/AABB_tree.h>
#include <CGAL/AABB_traits.h>
#include <CGAL/Polygon_mesh_processing/locate.h>
#include <CGAL/Polygon_mesh_processing/intersection.h>
#include <CGAL/Polygon_mesh_processing/bbox.h>
#include <CGAL/Bbox_3.h>

template<class K>
class SurfaceMesh3
{

public:

	typedef typename K::FT FT;
	typedef typename K::Point_3 Point_3;
	typedef typename CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Edge_index Edge;
	typedef typename SurfaceMesh::Halfedge_index Halfedge;
	typedef typename SurfaceMesh::Vertex_index Vertex;
	typedef typename SurfaceMesh::Face_index Face;

	typedef typename CGAL::AABB_face_graph_triangle_primitive<SurfaceMesh> AABB_face_graph_primitive;
	typedef typename CGAL::AABB_traits<K, AABB_face_graph_primitive> AABB_face_graph_traits;
	typedef typename CGAL::AABB_tree<AABB_face_graph_traits> AABBTree;

	~SurfaceMesh3()
	{
		DeleteTree();
	}

	SurfaceMesh model;

	AABBTree* tree = nullptr;

	inline static SurfaceMesh3* NewSurfaceMesh()
	{
		return new SurfaceMesh3();
	}

	inline static void DeleteSurfaceMesh(void* ptr)
	{
		auto obj = static_cast<SurfaceMesh3*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static SurfaceMesh3* CastToSurfaceMesh(void* ptr)
	{
		return static_cast<SurfaceMesh3*>(ptr);
	}

	void DeleteTree()
	{
		if (tree != nullptr)
		{
			delete tree;
			tree = nullptr;
		}
	}

	void BuildAABBTree()
	{
		if (tree == nullptr)
		{
			tree = new AABBTree();
			CGAL::Polygon_mesh_processing::build_AABB_tree(model, *tree);
		}
	}

	static void Clear(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.clear();
	}

	static void* Copy(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto copy = new SurfaceMesh3();
		copy->model = mesh->model;
		return copy;
	}

	static BOOL IsValid(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_valid();
	}

	static BOOL IsVertexValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_valid(Vertex(index));
	}

	static BOOL IsFaceValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_valid(Face(index));
	}

	static BOOL IsHalfedgeValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_valid(Halfedge(index));
	}

	static BOOL IsEdgeValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_valid(Edge(index));
	}

	static int VertexCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_vertices();
	}

	static int HalfEdgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_halfedges();
	}

	static int EdgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_edges();
	}

	static int FaceCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_faces();
	}

	static int AddVertex(void* ptr, Point3d point)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.add_vertex(point.ToCGAL<K>());
	}

	static int AddEdge(void* ptr, int v0, int v1)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.add_edge(Vertex(v0), Vertex(v1));
	}

	static int AddTriangle(void* ptr, int v0, int v1, int v2)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.add_face(Vertex(v0), Vertex(v1), Vertex(v2));
	}

	static int AddQuad(void* ptr, int v0, int v1, int v2, int v3)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.add_face(Vertex(v0), Vertex(v1), Vertex(v2), Vertex(v3));
	}

	static BOOL HasGarbage(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.has_garbage();
	}

	static void CollectGarbage(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->model.collect_garbage();
	}

	static void SetRecycleGarbage(void* ptr, BOOL collect)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->model.set_recycle_garbage(collect);
	}

	static BOOL DoesRecycleGarbage(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.does_recycle_garbage();
	}

	static int VertexDegree(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.degree(Vertex(index));
	}

	static int FaceDegree(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.degree(Face(index));
	}

	static BOOL VertexIsIsolated(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_isolated(Vertex(index));
	}

	static BOOL VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_border(Vertex(index), check_all_incident_halfedges);
	}

	static BOOL EdgeIsBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_border(Edge(index));
	}

	static int NextHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.next(Halfedge(index));
	}

	static int PreviousHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.prev(Halfedge(index));
	}

	static int OppositeHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.opposite(Halfedge(index));
	}

	static int SourceVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.source(Halfedge(index));
	}

	static int TargetVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.target(Halfedge(index));
	}

	static void RemoveVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->model.remove_vertex(Vertex(index));
	}

	static void RemoveEdge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->model.remove_edge(Edge(index));
	}

	static void RemoveFace(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->model.remove_face(Face(index));
	}

	static void RemoveProperyMaps(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->model.remove_all_property_maps();
	}

	static Point3d GetPoint(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto point = mesh->model.point(Vertex(index));
		return Point3d::FromCGAL<K>(point);
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		int index = 0;
		for (auto point = mesh->model.points().begin(); point != mesh->model.points().end(); ++point)
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

		std::transform(mesh->model.points().begin(), mesh->model.points().end(), mesh->model.points().begin(), m);
	}

	static BOOL IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_border(Vertex(index), check_all_incident_halfedges);
	}

	static BOOL IsHalfedgeBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_border(Halfedge(index));
	}

	static BOOL IsEdgeBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_border(Edge(index));
	}

	static int BorderEdgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int count = 0;
		for (auto edge : mesh->model.edges())
		{
			//if (mesh->model.is_removed(edge)) continue;
			if (mesh->model.is_border(edge)) count++;
		}

		return count;
	}

	static BOOL IsClosed(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		for (auto edge : mesh->model.edges())
		{
			//if (mesh->model.is_removed(edge)) continue;
			if (mesh->model.is_border(edge)) return FALSE;
		}

		return TRUE;
	}

	static BOOL CheckFaceVertexCount(void* ptr, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		for (auto face : mesh->model.faces())
		{
			if (mesh->model.is_removed(face)) continue;

			int i = mesh->model.degree(face);

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

		for (auto face : mesh->model.faces())
		{
			//if (mesh->model.is_removed(face)) continue;

			int count = mesh->model.degree(face);

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

		mesh->model.clear();
		mesh->model.collect_garbage();

		for (int i = 0; i < pointsCount; i++)
			mesh->model.add_vertex(points[i].ToCGAL<K>());

		if (trianglesCount > 0)
		{
			for (int i = 0; i < trianglesCount / 3; i++)
			{
				int i0 = triangles[i * 3 + 0];
				int i1 = triangles[i * 3 + 1];
				int i2 = triangles[i * 3 + 2];

				mesh->model.add_face(Vertex(i0), Vertex(i1), Vertex(i2));
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

				mesh->model.add_face(Vertex(i0), Vertex(i1), Vertex(i2), Vertex(i3));
			}
		}
	}

	static void GetTriangleQuadIndices(void* ptr, int* triangles, int trianglesCount, int* quads, int quadsCount)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int triangleIndex = 0;
		int quadIndex = 0;
		
		for (auto face : mesh->model.faces())
		{
			//if (mesh->model.is_removed(face)) continue;

			int count = mesh->model.degree(face);
			auto hedge0 = mesh->model.halfedge(face);

			if (count == 3 && triangleIndex < trianglesCount)
			{
				auto hedge1 = mesh->model.next(hedge0);
				auto hedge2 = mesh->model.next(hedge1);

				triangles[triangleIndex * 3 + 0] = mesh->model.source(hedge0).idx();
				triangles[triangleIndex * 3 + 1] = mesh->model.source(hedge1).idx();
				triangles[triangleIndex * 3 + 2] = mesh->model.source(hedge2).idx();
				triangleIndex++;
			}
			else if (count == 4 && quadIndex < quadsCount)
			{
				auto hedge1 = mesh->model.next(hedge0);
				auto hedge2 = mesh->model.next(hedge1);
				auto hedge3 = mesh->model.next(hedge2);

				quads[quadIndex * 4 + 0] = mesh->model.source(hedge0).idx();
				quads[quadIndex * 4 + 1] = mesh->model.source(hedge1).idx();
				quads[quadIndex * 4 + 2] = mesh->model.source(hedge2).idx();
				quads[quadIndex * 4 + 3] = mesh->model.source(hedge3).idx();
				quadIndex++;
			}
		}
		
	}

	static void Join(void* ptr, void* otherPtr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto other = CastToSurfaceMesh(otherPtr);
		mesh->model.join(other->model);
	}

	static void BuildAABBTree(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildAABBTree();
	}

	static void ReleaseAABBTree(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->DeleteTree();
	}

	static Box3d GetBoundingBox(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		if (mesh->tree != nullptr)
		{
			auto box = mesh->tree->root_node()->bbox();
			return Box3d::FromCGAL<K>(box);
		}
		else
		{
			auto box = CGAL::Polygon_mesh_processing::bbox(mesh->model);
			return Box3d::FromCGAL<K>(box);
		}
	}

	static void ReadOFF(void* ptr, const char* filename)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		std::ifstream i(filename);
		i >> mesh->model;
	}

	static void WriteOFF(void* ptr, const char* filename)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		std::ofstream o(filename);
		o << mesh->model;
	}

	static void Triangulate(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		CGAL::Polygon_mesh_processing::triangulate_faces(mesh->model);
	}

	static BOOL DoesSelfIntersect(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return CGAL::Polygon_mesh_processing::does_self_intersect(mesh->model);
	}

	static double Area(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return CGAL::to_double(CGAL::Polygon_mesh_processing::area(mesh->model));
	}

	static Point3d Centroid(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto p = CGAL::Polygon_mesh_processing::centroid(mesh->model);
		return Point3d::FromCGAL<K>(p);
	}

	static double Volume(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return CGAL::to_double(CGAL::Polygon_mesh_processing::volume(mesh->model));
	}

	static BOOL DoesBoundAVolume(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return CGAL::Polygon_mesh_processing::does_bound_a_volume(mesh->model);
	}

	static CGAL::Bounded_side SideOfTriangleMesh(void* ptr, const Point3d& point)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildAABBTree();
		CGAL::Side_of_triangle_mesh<SurfaceMesh, K> inside(*mesh->tree);
		return inside(point.ToCGAL<K>());
	}

	static BOOL DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto other = CastToSurfaceMesh(otherPtr);
		auto param = CGAL::parameters::do_overlap_test_of_bounded_sides(test_bounded_sides);

		return CGAL::Polygon_mesh_processing::do_intersect(mesh->model, other->model, param, param);
	}

	static MinMaxAvg MinMaxEdgeLength(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		constexpr double MAX = std::numeric_limits<double>::max();

		FT min = MAX;
		FT max = 0;
		FT avg = 0;

		int count = 0;
		for (auto edge : mesh->model.edges())
		{
			//if (mesh->model.is_removed(edge)) continue;

			auto len = CGAL::Polygon_mesh_processing::edge_length(edge, mesh->model);
	
			count++;
			avg += len;

			if (len < min) min = len;
			if (len > max) max = len;
		}

		if (min == MAX)
			min = 0;

		if (count != 0)
			avg /= count;

		MinMaxAvg m;
		m.min = CGAL::to_double(min);
		m.max = CGAL::to_double(max);
		m.avg = CGAL::to_double(avg);

		return m;
	}

	static void GetCentroids(void* ptr, Point3d* points, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		int numFaces = (int)mesh->model.number_of_faces();

		int index = 0;
		for (auto face : mesh->model.faces())
		{
			//if (mesh->model.is_removed(face)) continue;

			points[index] = Point3d::FromCGAL<K>(ComputeCentroid(mesh->model, face));

			index++;

			if (index >= numFaces || index >= count)
				return;
		}
	}

private:

	static int FaceVertexCount(const SurfaceMesh& mesh, const Face& face)
	{
		int count = 0;
		for (auto vert : mesh.vertices_around_face(mesh.halfedge(face))) {
			count++;
		}

		return count;
	}

	static Point_3 ComputeCentroid(const SurfaceMesh& mesh, const Face& face)
	{
		int num = 0;
		Point_3 centroid = { 0, 0, 0 };

		for (auto vert : mesh.vertices_around_face(mesh.halfedge(face))) 
		{
			auto p = mesh.point(vert);
			centroid.x() = centroid.x() + p.x();
			centroid.y() = centroid.y() + p.y();
			centroid.z() = centroid.z() + p.z();
			num++;
		}

		if (num != 0)
		{
			centroid.x() = centroid.x() / num;
			centroid.y() = centroid.y() / num;
			centroid.z() = centroid.z() / num;
		}

		return centroid;
	}

};
