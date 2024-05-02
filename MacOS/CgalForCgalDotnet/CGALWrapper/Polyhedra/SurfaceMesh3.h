#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "../Utility/ArrayUtil.h"
#include "PolygonalCount.h"
#include "SurfaceMeshMap.h"
#include "MeshVertex3.h"
#include "MeshFace3.h"
#include "MeshHalfedge3.h"

#include <limits>
#include <fstream>
#include <iostream>
#include <unordered_set>
#include <unordered_map>

#include <CGAL/Surface_mesh.h>
#include <CGAL/Aff_transformation_3.h>
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

	static constexpr const char* VERTEX_NORMAL_MAP_NAME = "v:normal";
	static constexpr const char* FACE_NORMAL_MAP_NAME = "f:normal";

	typedef typename K::FT FT;
	typedef typename K::Point_3 Point_3;
	typedef typename K::Vector_3 Vector_3;
	typedef typename CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Edge_index Edge;
	typedef typename SurfaceMesh::Halfedge_index Halfedge;
	typedef typename SurfaceMesh::Vertex_index Vertex;
	typedef typename SurfaceMesh::Face_index Face;

	typedef typename CGAL::AABB_face_graph_triangle_primitive<SurfaceMesh> AABB_face_graph_primitive;
	typedef typename CGAL::AABB_traits<K, AABB_face_graph_primitive> AABB_face_graph_traits;
	typedef typename CGAL::AABB_tree<AABB_face_graph_traits> AABBTree;

	typedef typename boost::graph_traits<SurfaceMesh>::vertex_descriptor VertexDes;
	typedef typename boost::graph_traits<SurfaceMesh>::face_descriptor FaceDes;

	~SurfaceMesh3()
	{
		DeleteTree();
	}

	SurfaceMesh model;

	AABBTree* tree = nullptr;

	SurfaceMeshMap<K> map;

private:

	bool vertexNormalsComputed = false;

	bool faceNormalsComputed = false;

public:

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

	inline static Point3d NullPoint()
	{
		return { 0, 0, 0 };
	}

	inline static Vertex NullVertex()
	{
		return SurfaceMesh::null_vertex();
	}

	inline static Face NullFace()
	{
		return SurfaceMesh::null_face();
	}

	inline static Edge NullEdge()
	{
		return SurfaceMesh::null_edge();
	}

	inline static Halfedge NullHalfedge()
	{
		return SurfaceMesh::null_halfedge();
	}

	void OnVertexNormalsChanged()
	{
		ClearVertexNormalMap();
		vertexNormalsComputed = false;
	}

	void OnFaceNormalsChanged()
	{
		ClearFaceNormalMap();
		faceNormalsComputed = false;
	}

	void OnVerticesChanged()
	{
		OnVertexNormalsChanged();
		map.OnVerticesChanged();
		DeleteTree();
	}

	void OnFacesChanged()
	{
		OnFaceNormalsChanged();
		map.OnFacesChanged();
		DeleteTree();
	}

	void OnEdgesChanged()
	{
		map.OnEdgesChanged();
		DeleteTree();
	}

	void OnHalfedgesChanged()
	{
		map.OnHalfedgesChanged();
		DeleteTree();
	}

	void OnModelChanged()
	{
		OnVerticesChanged();
		OnFacesChanged();
		OnEdgesChanged();
		OnHalfedgesChanged();
		DeleteTree();
	}

	void BuildModel()
	{
		map.BuildVertexMaps(model);
		map.BuildFaceMaps(model);
		map.BuildEdgeMaps(model);
		map.BuildHalfedgeMaps(model);
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

	void ClearVertexNormalMap()
	{
        auto pair = model.template property_map<VertexDes, Vector_3>(VERTEX_NORMAL_MAP_NAME);
		model.remove_property_map(pair.first);
		vertexNormalsComputed = false;
	}

	void ClearFaceNormalMap()
	{
        auto pair = model.template property_map<FaceDes, Vector_3>(FACE_NORMAL_MAP_NAME);
		model.remove_property_map(pair.first);
		faceNormalsComputed = false;
	}

	auto AddScalarPropertyMap(const char* name)
	{
        return model.template add_property_map<VertexDes, double>(name, 0).first;
	}

	void ClearScalarPropertyMap(const char* name)
	{
        auto pair = model.template property_map<VertexDes, double>(name);
		model.remove_property_map(pair.first);
	}

	int FindVertexIndex(Vertex vertex)
	{
		map.BuildVertexMaps(model);
		return map.FindVertexIndex(vertex);
	}

	Vertex FindVertex(int index)
	{
		map.BuildVertexMaps(model);
		return map.FindVertex(index);
	}

	int FindFaceIndex(Face face)
	{
		map.BuildFaceMaps(model);
		return map.FindFaceIndex(face);
	}

	Face FindFace(int index)
	{
		map.BuildFaceMaps(model);
		return map.FindFace(index);
	}

	int FindEdgeIndex(Edge edge)
	{
		map.BuildEdgeMaps(model);
		return map.FindEdgeIndex(edge);
	}

	Edge FindEdge(int index)
	{
		map.BuildEdgeMaps(model);
		return map.FindEdge(index);
	}

	int FindHalfedgeIndex(Halfedge edge)
	{
		map.BuildHalfedgeMaps(model);
		return map.FindHalfedgeIndex(edge);
	}

	Halfedge FindHalfedge(int index)
	{
		map.BuildHalfedgeMaps(model);
		return map.FindHalfedge(index);
	}

	static int GetBuildStamp(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->map.BuildStamp();
	}

	void Clear()
	{
		model.clear();
		model.collect_garbage();
		OnModelChanged();
	}

	static void Clear(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->Clear();
	}

	static void ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		if (vertices) mesh->map.OnVerticesChanged();
		if (faces) mesh->map.OnFacesChanged();
		if (edges) mesh->map.OnEdgesChanged();
		if (halfedges) mesh->map.OnEdgesChanged();
	}

	static void ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		if (vertices) mesh->OnVertexNormalsChanged();
		if (faces) mesh->OnFaceNormalsChanged();
	}

	static void ClearProperyMaps(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->ClearVertexNormalMap();
		mesh->ClearFaceNormalMap();
		mesh->model.remove_all_property_maps();
	}

	static void BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		if (vertices) mesh->map.BuildVertexMaps(mesh->model, force);
		if (faces) mesh->map.BuildFaceMaps(mesh->model, force);
		if (edges) mesh->map.BuildEdgeMaps(mesh->model, force);
		if (halfedges) mesh->map.BuildHalfedgeMaps(mesh->model, force);
	}

	static void PrintIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		BuildIndices(ptr, vertices, faces, edges, halfedges, force);

		if (vertices) mesh->map.PrintVertices(mesh->model);
		if (faces) mesh->map.PrintFaces(mesh->model);
		if (edges) mesh->map.PrintEdges(mesh->model);
		if (halfedges) mesh->map.PrintHalfedges(mesh->model);
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
		return mesh->model.is_valid(false);
	}

	static BOOL IsVertexValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto vertex = mesh->FindVertex(index);
		if (vertex == NullVertex()) return FALSE;
		return mesh->model.is_valid(vertex);
	}

	static BOOL IsFaceValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto face = mesh->FindFace(index);
		if (face == NullFace()) return FALSE;
		return mesh->model.is_valid(face);
	}

	static BOOL IsHalfedgeValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return FALSE;
		return mesh->model.is_valid(hedge);
	}

	static BOOL IsEdgeValid(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto edge = mesh->FindEdge(index);
		if (edge == NullEdge()) return FALSE;
		return mesh->model.is_valid(edge);
	}

	static int VertexCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_vertices();
	}

	static int HalfedgeCount(void* ptr)
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

	static int RemovedVertexCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_removed_vertices();
	}

	static int RemovedHalfedgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_removed_halfedges();
	}

	static int RemovedEdgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_removed_edges();
	}

	static int RemovedFaceCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return (int)mesh->model.number_of_removed_faces();
	}

	static BOOL IsVertexRemoved(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto vertex = mesh->map.FindVertex(index);
		if (vertex == NullVertex()) return FALSE;
		return mesh->model.is_removed(vertex);
	}

	static BOOL IsFaceRemoved(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto face = mesh->FindFace(index);
		if (face == NullFace()) return FALSE;
		return mesh->model.is_removed(face);
	}

	static BOOL IsHalfedgeRemoved(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return FALSE;
		return mesh->model.is_removed(hedge);
	}

	static BOOL IsEdgeRemoved(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto edge = mesh->FindEdge(index);
		if (edge == NullEdge()) return FALSE;
		return mesh->model.is_removed(edge);
	}

	static int AddVertex(void* ptr, Point3d point)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->OnModelChanged();
		return mesh->model.add_vertex(point.ToCGAL<K>());
	}

	static int AddEdge(void* ptr, int v0, int v1)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		auto vertex0 = mesh->FindVertex(v0);
		auto vertex1 = mesh->FindVertex(v1);
		if (vertex0 == NullVertex()) return NULL_INDEX;
		if (vertex1 == NullVertex()) return NULL_INDEX;

		mesh->OnModelChanged();
		return mesh->model.add_edge(vertex0, vertex1);
	}

	static int AddTriangle(void* ptr, int v0, int v1, int v2)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		auto vertex0 = mesh->FindVertex(v0);
		auto vertex1 = mesh->FindVertex(v1);
		auto vertex2 = mesh->FindVertex(v2);
		if (vertex0 == NullVertex()) return NULL_INDEX;
		if (vertex1 == NullVertex()) return NULL_INDEX;
		if (vertex2 == NullVertex()) return NULL_INDEX;

		mesh->OnModelChanged();
		return mesh->model.add_face(vertex0, vertex1, vertex2);
	}

	static int AddQuad(void* ptr, int v0, int v1, int v2, int v3)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		auto vertex0 = mesh->FindVertex(v0);
		auto vertex1 = mesh->FindVertex(v1);
		auto vertex2 = mesh->FindVertex(v2);
		auto vertex3 = mesh->FindVertex(v3);
		if (vertex0 == NullVertex()) return NULL_INDEX;
		if (vertex1 == NullVertex()) return NULL_INDEX;
		if (vertex2 == NullVertex()) return NULL_INDEX;
		if (vertex3 == NullVertex()) return NULL_INDEX;

		mesh->OnModelChanged();
		return mesh->model.add_face(vertex0, vertex1, vertex2, vertex3);
	}

	static int AddPentagon(void* ptr, int v0, int v1, int v2, int v3, int v4)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->OnModelChanged();

		std::vector<Vertex> face(6);
		face[0] = mesh->FindVertex(v0); face[1] = mesh->FindVertex(v1);
		face[2] = mesh->FindVertex(v2); face[3] = mesh->FindVertex(v3);
		face[4] = mesh->FindVertex(v4);

		for (auto v : face)
			if (v == NullVertex()) return NULL_INDEX;

		return mesh->model.add_face(face);
	}

	static int AddHexagon(void* ptr, int v0, int v1, int v2, int v3, int v4, int v5)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->OnModelChanged();

		std::vector<Vertex> face(6);
		face[0] = mesh->FindVertex(v0); face[1] = mesh->FindVertex(v1);
		face[2] = mesh->FindVertex(v2); face[3] = mesh->FindVertex(v3);
		face[4] = mesh->FindVertex(v4); face[5] = mesh->FindVertex(v5);

		for (auto v : face)
			if (v == NullVertex()) return NULL_INDEX;

		return mesh->model.add_face(face);
	}

	static int AddFace(void* ptr, int* indices, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->OnModelChanged();

		std::vector<Vertex> face(count);
		for (int i = 0; i < count; i++)
		{
			auto vertex = mesh->FindVertex(indices[i]);
			if (vertex == NullVertex()) return NULL_INDEX;
			face[i] = vertex;
		}
			
		return mesh->model.add_face(face);
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
		mesh->OnModelChanged();
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
		auto vertex = mesh->FindVertex(index);
		if (vertex == NullVertex()) return NULL_INDEX;
		return mesh->model.degree(vertex);
	}

	static int FaceDegree(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto face = mesh->FindFace(index);
		if (face == NullFace()) return FALSE;
		return mesh->model.degree(face);
	}

	static BOOL VertexIsIsolated(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto vertex = mesh->FindVertex(index);
		if (vertex == NullVertex()) return FALSE;
		return mesh->model.is_isolated(vertex);
	}

	static BOOL VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto vertex = mesh->FindVertex(index);
		if (vertex == NullVertex()) return FALSE;
		return mesh->model.is_border(vertex, check_all_incident_halfedges);
	}

	static BOOL EdgeIsBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto edge = mesh->FindEdge(index);
		if (edge == NullEdge()) return FALSE;
		return mesh->model.is_border(edge);
	}

	static int NextHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.next(hedge);
	}

	static int PreviousHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.prev(hedge);
	}

	static int OppositeHalfedge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.opposite(hedge);
	}

	static int SourceVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.source(hedge);
	}

	static int TargetVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.target(hedge);
	}

	static int NextAroundSource(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.next_around_source(hedge);
	}

	static int NextAroundTarget(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.next_around_target(hedge);
	}

	static int PreviousAroundSource(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.prev_around_source(hedge);
	}

	static int PreviousAroundTarget(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.prev_around_target(hedge);
	}

	static int EdgesHalfedge(void* ptr, int edgeIndex, int halfedgeIndex)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		if (halfedgeIndex < 0) halfedgeIndex = 0;
		if (halfedgeIndex > 1) halfedgeIndex = 1;

		auto edge = mesh->FindEdge(edgeIndex);
		if (edge == NullEdge()) return FALSE;

		return mesh->model.halfedge(edge, halfedgeIndex);
	}

	static int HalfedgesEdge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.edge(hedge);
	}

	static BOOL RemoveVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->map.BuildVertexMaps(mesh->model);

		Vertex vertex = mesh->FindVertex(index);
		if (vertex == NullVertex()) return FALSE;

		mesh->model.remove_vertex(vertex);
		mesh->OnModelChanged();
		return TRUE;
	}

	static BOOL RemoveEdge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->map.BuildEdgeMaps(mesh->model);

		Edge edge = mesh->map.FindEdge(index);
		if (edge == NullEdge()) return FALSE;

		mesh->model.remove_edge(edge);
		mesh->OnModelChanged();
		return TRUE;
	}

	static BOOL RemoveFace(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->map.BuildFaceMaps(mesh->model);

		Face face = mesh->map.FindFace(index);
		if (face == NullFace()) return FALSE;

		mesh->model.remove_face(face);
		mesh->OnModelChanged();
		return TRUE;
	}

	static Point3d GetPoint(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->map.BuildVertexMaps(mesh->model);

		if (index < 0 || index >= mesh->map.VertexCount())
			return NullPoint();

		Vertex v = mesh->map.GetVertex(index);
		if( v == NullVertex())
			return NullPoint();

		auto point = mesh->model.point(v);
		return Point3d::FromCGAL<K>(point);
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		mesh->map.BuildVertexMaps(mesh->model);
		int num_vertices = mesh->map.VertexCount();
		if (num_vertices == 0) return;
		if (num_vertices != count) return;

		for (int i = 0; i < num_vertices; i++)
		{
			auto vertex = mesh->map.GetVertex(i);
			if (vertex == NullVertex())
				points[i] = NullPoint();
			else
			{
				auto p = mesh->model.point(vertex);
				points[i] = Point3d::FromCGAL<K>(p);
			}
		}
	}

	static void SetPoint(void* ptr, int index, const Point3d& point)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		mesh->map.BuildVertexMaps(mesh->model);
		if (index < 0 || index >= mesh->map.VertexCount())
			return;

		auto vertex = mesh->map.GetVertex(index);
		auto point_map = mesh->model.points();
		point_map[vertex] = point.ToCGAL<K>();

		mesh->OnModelChanged();
	}

	static void SetPoints(void* ptr, Point3d* points, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		mesh->map.BuildVertexMaps(mesh->model);
		int num_vertices = mesh->map.VertexCount();
		if (num_vertices == 0) return;
		if (num_vertices != count) return;

		auto point_map = mesh->model.points();

		for (int i = 0; i < num_vertices; i++)
		{
			auto vertex = mesh->map.GetVertex(i);

			if(vertex != NullVertex())
				point_map[vertex] = points[i].ToCGAL<K>();
		}

		mesh->OnModelChanged();
	}

	static BOOL GetSegment(void* ptr, int index, Segment3d& segment)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		auto edge = mesh->FindHalfedge(index);
		if (edge != NullHalfedge())
		{
			auto a = mesh->model.point(mesh->model.source(edge));
			auto b = mesh->model.point(mesh->model.target(edge));

			segment.a = Point3d::FromCGAL<K>(a);
			segment.b = Point3d::FromCGAL<K>(b);
			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	static void GetSegments(void* ptr, Segment3d* segments, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int i = 0;
		for (auto edge : halfedges(mesh->model))
		{
			auto a = mesh->model.point(mesh->model.source(edge));
			auto b = mesh->model.point(mesh->model.target(edge));

			Segment3d seg;
			seg.a = Point3d::FromCGAL<K>(a);
			seg.b = Point3d::FromCGAL<K>(b);

			segments[i++] = seg;

			if (i >= count) return;
		}
	}

	static BOOL GetTriangle(void* ptr, int index, Triangle3d& tri)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		auto face = mesh->FindFace(index);
		if (face != NullFace())
		{
			auto edge = mesh->model.halfedge(face);
			auto prev = mesh->model.prev(edge);
			auto next = mesh->model.next(edge);

			auto a = mesh->model.point(mesh->model.source(prev));
			auto b = mesh->model.point(mesh->model.source(edge));
			auto c = mesh->model.point(mesh->model.source(next));

			tri.a = Point3d::FromCGAL<K>(a);
			tri.b = Point3d::FromCGAL<K>(b);
			tri.c = Point3d::FromCGAL<K>(c);
			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	static void GetTriangles(void* ptr, Triangle3d* triangles, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int i = 0;
		for (auto face : faces(mesh->model))
		{
			auto edge = mesh->model.halfedge(face);
			auto prev = mesh->model.prev(edge);
			auto next = mesh->model.next(edge);

			auto a = mesh->model.point(mesh->model.source(prev));
			auto b = mesh->model.point(mesh->model.source(edge));
			auto c = mesh->model.point(mesh->model.source(next));

			Triangle3d tri;
			tri.a = Point3d::FromCGAL<K>(a);
			tri.b = Point3d::FromCGAL<K>(b);
			tri.c = Point3d::FromCGAL<K>(c);

			triangles[i++] = tri;

			if (i >= count) return;
		}
	}

	static BOOL GetVertex(void* ptr, int index, MeshVertex3& vert)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		vert = MeshVertex3::NullVertex();

		auto v = mesh->FindVertex(index);
		if (v != NullVertex())
		{
			vert.Index = v;
			vert.Point = Point3d::FromCGAL<K>(mesh->model.point(v));
			vert.Halfedge = mesh->FindHalfedgeIndex(mesh->model.halfedge(v));
			vert.Degree = mesh->model.degree(v);
			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}

	static void GetVertices(void* ptr, MeshVertex3* vertexArray, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int i = 0;
		for (auto v : vertices(mesh->model))
		{
			MeshVertex3 vert = MeshVertex3::NullVertex();
			vert.Index = v;
			vert.Point = Point3d::FromCGAL<K>(mesh->model.point(v));
			vert.Halfedge = mesh->FindHalfedgeIndex(mesh->model.halfedge(v));
			vert.Degree = mesh->model.degree(v);

			vertexArray[i++] = vert;

			if (i >= count) return;
		}
	}

	static BOOL GetFace(void* ptr, int index, MeshFace3& face)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		face = MeshFace3::NullFace();

		auto f = mesh->FindFace(index);
		if (f != SurfaceMesh3<K>::NullFace())
		{
			face.Index = index;
			face.Halfedge = mesh->FindHalfedgeIndex(mesh->model.halfedge(f));

			return TRUE;
		}
		else
		{
			return FALSE;
		}

	}

	static void GetFaces(void* ptr, MeshFace3* faceArray, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int i = 0;
		for (auto f : faces(mesh->model))
		{
			MeshFace3 face = MeshFace3::NullFace();
			face.Index = i;
			face.Halfedge = mesh->FindHalfedgeIndex(mesh->model.halfedge(f));

			faceArray[i++] = face;

			if (i >= count) return;
		}
	}

	static BOOL GetHalfedge(void* ptr, int index, MeshHalfedge3& edge)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		edge = MeshHalfedge3::NullHalfedge();

		auto e = mesh->FindHalfedge(index);
		if (e != NullHalfedge())
		{
			edge.Index = index;
			edge.Source = mesh->FindVertexIndex(mesh->model.source(e));
			edge.Target = mesh->FindVertexIndex(mesh->model.target(e));
			edge.Opposite = mesh->FindHalfedgeIndex(mesh->model.opposite(e));
			edge.Next = mesh->FindHalfedgeIndex(mesh->model.next(e));
			edge.Previous = mesh->FindHalfedgeIndex(mesh->model.prev(e));
			edge.Face = mesh->FindFaceIndex(mesh->model.face(e));
			edge.IsBorder = mesh->model.is_border(e);

			return TRUE;
		}
		else
		{
			return FALSE;
		}

	}

	static void GetHalfedges(void* ptr, MeshHalfedge3* edgeArray, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int i = 0;
		for (auto e : halfedges(mesh->model))
		{
			MeshHalfedge3 edge = MeshHalfedge3::NullHalfedge();
			edge.Index = i;
			edge.Source = mesh->FindVertexIndex(mesh->model.source(e));
			edge.Target = mesh->FindVertexIndex(mesh->model.target(e));
			edge.Opposite = mesh->FindHalfedgeIndex(mesh->model.opposite(e));
			edge.Next = mesh->FindHalfedgeIndex(mesh->model.next(e));
			edge.Previous = mesh->FindHalfedgeIndex(mesh->model.prev(e));
			edge.Face = mesh->FindFaceIndex(mesh->model.face(e));
			edge.IsBorder = mesh->model.is_border(e);

			edgeArray[i++] = edge;

			if (i >= count) return;
		}
	}

	static void Transform(void* ptr, const Matrix4x4d& matrix)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto m = matrix.ToCGAL<K>();

		mesh->OnModelChanged();
		std::transform(mesh->model.points().begin(), mesh->model.points().end(), mesh->model.points().begin(), m);
	}

	static BOOL IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto vertex = mesh->FindVertex(index);
		if (vertex == NullVertex()) return FALSE;
		return mesh->model.is_border(vertex, check_all_incident_halfedges);
	}

	static BOOL IsHalfedgeBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto hedge = mesh->FindHalfedge(index);
		if (hedge == NullHalfedge()) return NULL_INDEX;
		return mesh->model.is_border(hedge);
	}

	static BOOL IsEdgeBorder(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto edge = mesh->FindEdge(index);
		if (edge == NullEdge()) return FALSE;
		return mesh->model.is_border(edge);
	}

	static int BorderEdgeCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int count = 0;
		for (auto edge : mesh->model.edges())
		{
			if (mesh->model.is_border(edge)) count++;
		}

		return count;
	}

	static BOOL IsClosed(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		for (auto edge : mesh->model.edges())
		{
			if (mesh->model.is_border(edge)) return FALSE;
		}

		return TRUE;
	}

	static BOOL CheckFaceVertexCount(void* ptr, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		for (auto face : mesh->model.faces())
		{
			int i = mesh->model.degree(face);
			if (i != count) return FALSE;
		}

		return TRUE;
	}

	static void Join(void* ptr, void* otherPtr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		auto other = CastToSurfaceMesh(otherPtr);
		mesh->model.join(other->model);
		mesh->OnModelChanged();
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
		mesh->OnModelChanged();
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

	static void GetCentroids(void* ptr, Point3d* points, int count)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		int numFaces = (int)mesh->model.number_of_faces();

		int index = 0;
		for (auto face : mesh->model.faces())
		{
			points[index] = Point3d::FromCGAL<K>(ComputeCentroid(mesh->model, face));

			index++;

			if (index >= numFaces || index >= count)
				return;
		}
	}

	static int PropertyMapCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return 0;
		//return (int)mesh->model.properties<SurfaceMesh>().size();
	}

	static void ComputeVertexNormals(void* ptr)
	{
        typedef typename K::Vector_3 Vector;
        typedef typename boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::vertex_descriptor VertexDes;

		auto mesh = CastToSurfaceMesh(ptr);

		if (mesh->vertexNormalsComputed) return;
		mesh->vertexNormalsComputed = true;

		std::string key = VERTEX_NORMAL_MAP_NAME;
        auto normals = mesh->model.template add_property_map<VertexDes, Vector>(key, CGAL::NULL_VECTOR).first;
		CGAL::Polygon_mesh_processing::compute_vertex_normals(mesh->model, normals);
	}

	static void ComputeFaceNormals(void* ptr)
	{
        typedef typename K::Vector_3 Vector;
        typedef typename boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::face_descriptor FaceDes;

		auto mesh = CastToSurfaceMesh(ptr);

		if (mesh->faceNormalsComputed) return;
		mesh->faceNormalsComputed = true;

		std::string key = FACE_NORMAL_MAP_NAME;
        auto normals = mesh->model.template add_property_map<FaceDes, Vector>(key, CGAL::NULL_VECTOR).first;
		CGAL::Polygon_mesh_processing::compute_face_normals(mesh->model, normals);
	}

	static void GetVertexNormals(void* ptr, Vector3d* normals, int count)
	{
        typedef typename K::Vector_3 Vector;
        typedef typename boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::vertex_descriptor VertexDes;

		auto mesh = CastToSurfaceMesh(ptr);
		ComputeVertexNormals(ptr);

        auto pair = mesh->model.template property_map<VertexDes, Vector>(VERTEX_NORMAL_MAP_NAME);
		if (!pair.second) return;

		for (auto vd : vertices(mesh->model))
		{
			int index = vd;

			if (index < count)
			{
				auto n = pair.first[vd];
				normals[index] = Vector3d::FromCGAL<K>(n);
			}
		}
	}

	static void GetFaceNormals(void* ptr, Vector3d* normals, int count)
	{
        typedef typename K::Vector_3 Vector;
        typedef typename boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::face_descriptor FaceDes;

		auto mesh = CastToSurfaceMesh(ptr);
		ComputeFaceNormals(ptr);

        auto pair = mesh->model.template property_map<FaceDes, Vector>(FACE_NORMAL_MAP_NAME);
		if (!pair.second) return;

		for (auto fd : faces(mesh->model))
		{
			int index = fd;

			if (index < count)
			{
				auto n = pair.first[fd];
				normals[index] = Vector3d::FromCGAL<K>(n);
			}
		}
	}

	static PolygonalCount GetPolygonalCount(void* ptr)
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

	static PolygonalCount GetDualPolygonalCount(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		int degenerate = 0;
		int three = 0;
		int four = 0;
		int five = 0;
		int six = 0;
		int greater = 0;

		for (auto vert : mesh->model.vertices())
		{
			int count = mesh->model.degree(vert);

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

	static void CreatePolygonMesh(void* ptr, Point2d* points, int count, BOOL xz)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		std::vector<Vertex> face(count);
		for (int i = 0; i < count; i++)
		{
			if (xz)
			{
				auto p = points[i].ToCGAL3XZ<K>();
				face[i] = mesh->model.add_vertex(p);
			}
			else
			{
				auto p = points[i].ToCGAL3<K>();
				face[i] = mesh->model.add_vertex(p);
			}
		}

		mesh->model.add_face(face);
	}

	static void CreatePolygonalMesh(void* ptr,
		Point3d* points, int pointsCount,
		int* triangles, int trianglesCount, 
		int* quads, int quadsCount,
		int* pentagons, int pentagonsCount,
		int* hexagons, int hexagonsCount)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		mesh->Clear();
		mesh->OnModelChanged();

		ArrayUtil::MakeOutOfBoundsNull(triangles, trianglesCount, pointsCount);
		ArrayUtil::MakeOutOfBoundsNull(quads, quadsCount, pointsCount);
		ArrayUtil::MakeOutOfBoundsNull(pentagons, pentagonsCount, pointsCount);
		ArrayUtil::MakeOutOfBoundsNull(hexagons, hexagonsCount, pointsCount);

		std::vector<Vertex> list;

		for (int i = 0; i < pointsCount; i++)
			mesh->model.add_vertex(points[i].ToCGAL<K>());

		if (trianglesCount > 0)
		{
			for (int i = 0; i < trianglesCount / 3; i++)
			{
				int i0 = triangles[i * 3 + 0];
				int i1 = triangles[i * 3 + 1];
				int i2 = triangles[i * 3 + 2];

				if (i0 == NULL_INDEX || i1 == NULL_INDEX || i2 == NULL_INDEX)
					continue;

				list.clear();
				list.push_back(Vertex(i0));
				list.push_back(Vertex(i1));
				list.push_back(Vertex(i2));
				mesh->model.add_face(list);
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

				if (i0 == NULL_INDEX || i1 == NULL_INDEX || i2 == NULL_INDEX || 
					i3 == NULL_INDEX)
					continue;

				list.clear();
				list.push_back(Vertex(i0));
				list.push_back(Vertex(i1));
				list.push_back(Vertex(i2));
				list.push_back(Vertex(i3));
				mesh->model.add_face(list);
			}
		}

		if (pentagonsCount > 0)
		{
			for (int i = 0; i < pentagonsCount / 5; i++)
			{
				int i0 = pentagons[i * 5 + 0];
				int i1 = pentagons[i * 5 + 1];
				int i2 = pentagons[i * 5 + 2];
				int i3 = pentagons[i * 5 + 3];
				int i4 = pentagons[i * 5 + 4];

				if (i0 == NULL_INDEX || i1 == NULL_INDEX || i2 == NULL_INDEX ||
					i3 == NULL_INDEX || i4 == NULL_INDEX)
					continue;

				list.clear();
				list.push_back(Vertex(pentagons[i * 5 + 0]));
				list.push_back(Vertex(pentagons[i * 5 + 1]));
				list.push_back(Vertex(pentagons[i * 5 + 2]));
				list.push_back(Vertex(pentagons[i * 5 + 3]));
				list.push_back(Vertex(pentagons[i * 5 + 4]));
				mesh->model.add_face(list);
			}
		}

		if (hexagonsCount > 0)
		{
			for (int i = 0; i < hexagonsCount / 6; i++)
			{
				int i0 = hexagons[i * 6 + 0];
				int i1 = hexagons[i * 6 + 1];
				int i2 = hexagons[i * 6 + 2];
				int i3 = hexagons[i * 6 + 3];
				int i4 = hexagons[i * 6 + 4];
				int i5 = hexagons[i * 6 + 5];

				if (i0 == NULL_INDEX || i1 == NULL_INDEX || i2 == NULL_INDEX ||
					i3 == NULL_INDEX || i4 == NULL_INDEX || i5 == NULL_INDEX)
					continue;

				list.clear();
				list.push_back(Vertex(hexagons[i * 6 + 0]));
				list.push_back(Vertex(hexagons[i * 6 + 1]));
				list.push_back(Vertex(hexagons[i * 6 + 2]));
				list.push_back(Vertex(hexagons[i * 6 + 3]));
				list.push_back(Vertex(hexagons[i * 6 + 4]));
				list.push_back(Vertex(hexagons[i * 6 + 6]));
				mesh->model.add_face(list);
			}
		}

	}

	static void GetPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildModel();

		int triangleIndex = 0;
		int quadIndex = 0;
		int pentagonIndex = 0;
		int hexagonIndex = 0;
		int indices[6];

		ArrayUtil::FillWithNull(triangles, triangleCount);
		ArrayUtil::FillWithNull(quads, quadCount);
		ArrayUtil::FillWithNull(pentagons, pentagonCount);
		ArrayUtil::FillWithNull(hexagons, hexagonCount);

		for (auto face : mesh->model.faces())
		{
			int count = mesh->model.degree(face);
			if (count < 3 || count > 6) continue;

			auto hedge = mesh->model.halfedge(face);
			for (int i = 0; i < count; i++)
			{
				auto vertex = mesh->model.source(hedge);
				indices[i] = mesh->FindVertexIndex(vertex);
				hedge = mesh->model.next(hedge);
			}

			if (count == 3 && triangleIndex < triangleCount)
			{
				triangles[triangleIndex * 3 + 0] = indices[0];
				triangles[triangleIndex * 3 + 1] = indices[1];
				triangles[triangleIndex * 3 + 2] = indices[2];
				triangleIndex++;
			}
			else if (count == 4 && quadIndex < quadCount)
			{
				quads[quadIndex * 4 + 0] = indices[0];
				quads[quadIndex * 4 + 1] = indices[1];
				quads[quadIndex * 4 + 2] = indices[2];
				quads[quadIndex * 4 + 3] = indices[3];
				quadIndex++;
			}
			else if (count == 5 && pentagonIndex < pentagonCount)
			{
				pentagons[pentagonIndex * 5 + 0] = indices[0];
				pentagons[pentagonIndex * 5 + 1] = indices[1];
				pentagons[pentagonIndex * 5 + 2] = indices[2];
				pentagons[pentagonIndex * 5 + 3] = indices[3];
				pentagons[pentagonIndex * 5 + 4] = indices[4];
				pentagonIndex++;
			}
			else if (count == 6 && hexagonIndex < hexagonCount)
			{
				hexagons[hexagonIndex * 6 + 0] = indices[0];
				hexagons[hexagonIndex * 6 + 1] = indices[1];
				hexagons[hexagonIndex * 6 + 2] = indices[2];
				hexagons[hexagonIndex * 6 + 3] = indices[3];
				hexagons[hexagonIndex * 6 + 4] = indices[4];
				hexagons[hexagonIndex * 6 + 5] = indices[5];
				hexagonIndex++;
			}
		}
	}

	static void GetDualPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount)
	{

		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildModel();

		int triangleIndex = 0;
		int quadIndex = 0;
		int pentagonIndex = 0;
		int hexagonIndex = 0;
		int indices[6];

		ArrayUtil::FillWithNull(triangles, triangleCount);
		ArrayUtil::FillWithNull(quads, quadCount);
		ArrayUtil::FillWithNull(pentagons, pentagonCount);
		ArrayUtil::FillWithNull(hexagons, hexagonCount);

		//Not workinng

		for (auto vert : mesh->model.vertices())
		{
			int count = mesh->model.degree(vert);
			if (count < 3 || count > 6) continue;

			auto hedge = mesh->model.halfedge(vert);
			for (int i = 0; i < count; i++)
			{
				auto face = mesh->model.face(hedge);
				indices[i] = mesh->FindFaceIndex(face);
				hedge = mesh->model.next_around_source(hedge);
			}

			if (count == 3 && triangleIndex < triangleCount)
			{
				triangles[triangleIndex * 3 + 0] = indices[0];
				triangles[triangleIndex * 3 + 1] = indices[1];
				triangles[triangleIndex * 3 + 2] = indices[2];
				triangleIndex++;
			}
			else if (count == 4 && quadIndex < quadCount)
			{
				quads[quadIndex * 4 + 0] = indices[0];
				quads[quadIndex * 4 + 1] = indices[1];
				quads[quadIndex * 4 + 2] = indices[2];
				quads[quadIndex * 4 + 3] = indices[3];
				quadIndex++;
			}
			else if (count == 5 && pentagonIndex < pentagonCount)
			{
				pentagons[pentagonIndex * 5 + 0] = indices[0];
				pentagons[pentagonIndex * 5 + 1] = indices[1];
				pentagons[pentagonIndex * 5 + 2] = indices[2];
				pentagons[pentagonIndex * 5 + 3] = indices[3];
				pentagons[pentagonIndex * 5 + 4] = indices[4];
				pentagonIndex++;
			}
			else if (count == 6 && hexagonIndex < hexagonCount)
			{
				hexagons[hexagonIndex * 6 + 0] = indices[0];
				hexagons[hexagonIndex * 6 + 1] = indices[1];
				hexagons[hexagonIndex * 6 + 2] = indices[2];
				hexagons[hexagonIndex * 6 + 3] = indices[3];
				hexagons[hexagonIndex * 6 + 4] = indices[4];
				hexagons[hexagonIndex * 6 + 5] = indices[5];
				hexagonIndex++;
			}

		}
		
	}

private:

	static Point_3 ComputeCentroid(const SurfaceMesh& mesh, const Face& face)
	{
		int num = 0;
		
		FT x = 0;
		FT y = 0;
		FT z = 0;

		for (auto vert : mesh.vertices_around_face(mesh.halfedge(face)))
		{
			auto p = mesh.point(vert);
			x += p.x();
			y += p.y();
			z += p.z();
			num++;
		}

		if (num != 0)
		{
			x /= num;
			y /= num;
			z /= num;
		}

		return { x, y, z };
	}

};
