#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "../Utility/ArrayUtil.h"
#include "FaceVertexCount.h"

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

private:

	int buildStamp = 1;

	AABBTree* tree = nullptr;

	std::unordered_map<Vertex, int> vertexIndexMap;
	std::vector<Vertex> vertexMap;
	bool rebuildVertexIndexMap = true;

	std::unordered_map<Face, int> faceIndexMap;
	std::vector<Face> faceMap;
	bool rebuildFaceIndexMap = true;

	std::unordered_map<Edge, int> edgeIndexMap;
	std::vector<Edge> edgeMap;
	bool rebuildEdgeIndexMap = true;

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

	void OnVertexIndicesChanged()
	{
		vertexMap.clear();
		vertexMap.reserve(0);
		vertexIndexMap.clear();
		vertexIndexMap.reserve(0);
		rebuildVertexIndexMap = true;
		buildStamp++;
	}

	void OnFaceIndicesChanged()
	{
		faceMap.clear();
		faceMap.reserve(0);
		faceIndexMap.clear();
		faceIndexMap.reserve(0);
		rebuildFaceIndexMap = true;
		buildStamp++;
	}

	void OnEdgeIndicesChanged()
	{
		edgeMap.clear();
		edgeMap.reserve(0);
		edgeIndexMap.clear();
		edgeIndexMap.reserve(0);
		rebuildEdgeIndexMap = true;
		buildStamp++;
	}

	void OnVerticesChanged()
	{
		OnVertexNormalsChanged();
		OnVertexIndicesChanged();
		DeleteTree();
	}

	void OnFacesChanged()
	{
		OnFaceNormalsChanged();
		OnFaceIndicesChanged();
		DeleteTree();
	}

	void OnEdgesChanged()
	{
		OnEdgeIndicesChanged();
		DeleteTree();
	}

	void OnModelChanged()
	{
		OnVerticesChanged();
		OnFacesChanged();
		OnEdgesChanged();
		DeleteTree();
	}

	void BuildModel()
	{
		BuildVertexMaps();
		BuildFaceMaps();
		BuildEdgeMaps();
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
		typedef K::Vector_3 Vector;
		typedef boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::vertex_descriptor VertexDes;

		auto pair = model.property_map<VertexDes, Vector>(VERTEX_NORMAL_MAP_NAME);
		model.remove_property_map(pair.first);
		vertexNormalsComputed = false;
	}

	void ClearFaceNormalMap()
	{
		typedef K::Vector_3 Vector;
		typedef boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::face_descriptor FaceDes;

		auto pair = model.property_map<FaceDes, Vector>(FACE_NORMAL_MAP_NAME);
		model.remove_property_map(pair.first);
		faceNormalsComputed = false;
	}

	void BuildVertexMaps(bool force = false)
	{
		if (!force && !rebuildVertexIndexMap) return;
		rebuildVertexIndexMap = false;

		vertexMap.clear();
		vertexMap.reserve(model.number_of_vertices());
		vertexIndexMap.clear();

		int index = 0;
		for (auto vertex : model.vertices())
		{
			//std::cout << "Vetex = " << vertex<< " Index " << index << std::endl;
			vertexMap.push_back(vertex);
			vertexIndexMap.insert(std::pair<Vertex, int>(vertex, index));
			index++;
		}
	}

	void BuildFaceMaps(bool force = false)
	{
		if (!force && !rebuildFaceIndexMap) return;
		rebuildFaceIndexMap = false;

		faceMap.clear();
		faceMap.reserve(model.number_of_faces());
		faceIndexMap.clear();

		int index = 0;
		for (auto face : model.faces())
		{
			//std::cout << "Face = " << face << " Index " << index << std::endl;
			faceMap.push_back(face);
			faceIndexMap.insert(std::pair<Face, int>(face, index));
			index++;
		}
	}

	void BuildEdgeMaps(bool force = false)
	{
		if (!force && !rebuildEdgeIndexMap) return;
		rebuildEdgeIndexMap = false;

		edgeMap.clear();
		edgeMap.reserve(model.number_of_edges());
		edgeIndexMap.clear();

		int index = 0;
		for (auto edge : model.edges())
		{
			//std::cout << "Edge = " << edge << " Index " << index << std::endl;
			edgeMap.push_back(edge);
			edgeIndexMap.insert(std::pair<Edge, int>(edge, index));
			index++;
		}
	}

	int FindVertexIndex(Vertex vertex)
	{
		BuildVertexMaps();

		auto item = vertexIndexMap.find(vertex);
		if (item != vertexIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Vertex FindVertex(int index)
	{
		BuildVertexMaps();
		int count = (int)vertexMap.size();

		if (index < 0 || index >= count)
			return NullVertex();

		return Vertex(vertexMap[index]);
	}

	int FindFaceIndex(int index)
	{
		BuildFaceMaps();

		auto item = faceIndexMap.find(Face(index));
		if (item != faceIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Face FindFace(int index)
	{
		BuildFaceMaps();
		int count = (int)faceMap.size();

		if (index < 0 || index >= count)
			return NullFace();

		return Face(faceMap[index]);
	}

	int FindEdgeIndex(int index)
	{
		BuildEdgeMaps();

		auto item = edgeIndexMap.find(Edge(index));
		if (item != edgeIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Edge FindEdge(int index)
	{
		BuildEdgeMaps();
		int count = (int)edgeMap.size();

		if (index < 0 || index >= count)
			return NullEdge();

		return Edge(edgeMap[index]);
	}

	static int GetBuildStamp(void* ptr)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->buildStamp;
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

	static void ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		if (vertices) mesh->OnVertexIndicesChanged();
		if (faces) mesh->OnFaceIndicesChanged();
		if (edges) mesh->OnEdgeIndicesChanged();
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

	static void BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL force)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		if (vertices) mesh->BuildVertexMaps(force);
		if (faces) mesh->BuildFaceMaps(force);
		if (edges) mesh->BuildEdgeMaps(force);
	}

	static void PrintIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL build)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		if (build)
			BuildIndices(ptr, vertices, faces, edges, build);

		if (vertices)
		{
			std::cout << "Vertex indices" << std::endl;
			for (auto vertex : mesh->model.vertices())
			{
				int index = mesh->FindVertexIndex(vertex);
				Point_3 point;

				if (index == NULL_INDEX)
					point = SurfaceMesh3::NullPoint().ToCGAL<K>();
				else
				{
					point = mesh->model.point(vertex);

					std::cout << "Vertex = " << vertex
						<< ", Index = " << index
						<< ", Point = " << point << std::endl;
				}
			}
		}

		if (faces)
		{
			std::cout << "Face indices" << std::endl;
			for (auto face : mesh->model.faces())
			{
				std::cout << "Face = " << face
					<< ", Index = " << mesh->FindFaceIndex(face) << std::endl;
			}
		}

		if (edges)
		{
			std::cout << "Edges indices" << std::endl;
			for (auto edge : mesh->model.edges())
			{
				std::cout << "Edge = " << edge
					<< ", Index = " << mesh->FindEdgeIndex(edge) << std::endl;

			}
		}

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
		return mesh->model.is_removed(Vertex(index));
	}

	static BOOL IsFaceRemoved(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_removed(Face(index));
	}

	static BOOL IsHalfedgeRemoved(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_removed(Halfedge(index));
	}

	static BOOL IsEdgeRemoved(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		return mesh->model.is_removed(Edge(index));
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
		mesh->OnModelChanged();
		return mesh->model.add_edge(Vertex(v0), Vertex(v1));
	}

	static int AddTriangle(void* ptr, int v0, int v1, int v2)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->OnModelChanged();
		return mesh->model.add_face(Vertex(v0), Vertex(v1), Vertex(v2));
	}

	static int AddQuad(void* ptr, int v0, int v1, int v2, int v3)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->OnModelChanged();
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

	static BOOL RemoveVertex(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildVertexMaps();

		Vertex vertex = mesh->FindVertex(index);
		if (vertex == NullVertex()) return FALSE;

		mesh->model.remove_vertex(vertex);
		mesh->OnModelChanged();
		return TRUE;
	}

	static BOOL RemoveEdge(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildEdgeMaps();

		Edge edge = mesh->FindEdge(index);
		if (edge == NullEdge()) return FALSE;

		mesh->model.remove_edge(edge);
		mesh->OnModelChanged();
		return TRUE;
	}

	static BOOL RemoveFace(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildFaceMaps();

		Face face = mesh->FindFace(index);
		if (face == NullFace()) return FALSE;

		mesh->model.remove_face(face);
		mesh->OnModelChanged();
		return TRUE;
	}

	static Point3d GetPoint(void* ptr, int index)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildVertexMaps();

		if (index < 0 || index >= (int)mesh->vertexMap.size())
			return SurfaceMesh3::NullPoint();

		Vertex v = mesh->vertexMap[index];
		if( v == NullVertex())
			return SurfaceMesh3::NullPoint();

		auto point = mesh->model.point(v);
		return Point3d::FromCGAL<K>(point);
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		mesh->BuildVertexMaps();
		int num_vertices = (int)mesh->vertexMap.size();
		if (num_vertices == 0) return;
		if (num_vertices != count) return;

		/*
		for (auto vertex : mesh->model.vertices())
		{
			auto index = mesh->FindVertexIndex(vertex);

			if (index < 0 || index >= num_vertices)
				continue;

			auto p = mesh->model.point(vertex);
			points[index] = Point3d::FromCGAL<K>(p);
		}
		*/

		for (int i = 0; i < num_vertices; i++)
		{
			auto vertex = mesh->vertexMap[i];
			if (vertex == SurfaceMesh3::NullVertex())
				points[i] = SurfaceMesh3::NullPoint();
			else
			{
				auto p = mesh->model.point(vertex);
				points[i] = Point3d::FromCGAL<K>(p);
			}
		}
	}

	static void SetPoint(void* ptr, int index, Point3d point)
	{
		auto mesh = CastToSurfaceMesh(ptr);

		mesh->BuildVertexMaps();
		if (index < 0 || index >= (int)mesh->vertexMap.size())
			return;

		auto vertex = mesh->vertexMap[index];
		auto point_map = mesh->model.points();
		point_map[vertex] = point.ToCGAL<EEK>();

		mesh->OnModelChanged();
	}

	static void SetPoints(void* ptr, Point3d* points, int count)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(ptr);

		mesh->BuildVertexMaps();
		int num_vertices = (int)mesh->vertexMap.size();
		if (num_vertices == 0) return;
		if (num_vertices != count) return;

		auto point_map = mesh->model.points();

		for (int i = 0; i < num_vertices; i++)
		{
			auto vertex = mesh->vertexMap[i];

			if(vertex != SurfaceMesh3::NullVertex())
				point_map[vertex] = points[i].ToCGAL<K>();
		}

		mesh->OnModelChanged();
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

		mesh->Clear();
		mesh->OnModelChanged();

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

	static void GetTriangleQuadIndices(void* ptr, int* triangles, int triangleCount, int* quads, int quadCount)
	{
		auto mesh = CastToSurfaceMesh(ptr);
		mesh->BuildModel();

		int triangleIndex = 0;
		int quadIndex = 0;

		auto null_vertex = SurfaceMesh3::NullVertex();
		ArrayUtil::FillWithNull(triangles, triangleCount);
		ArrayUtil::FillWithNull(quads, quadCount);

		for (auto face : mesh->model.faces())
		{
			int count = mesh->model.degree(face);
			auto hedge0 = mesh->model.halfedge(face);

			if (count == 3 && triangleIndex < triangleCount)
			{
				auto hedge1 = mesh->model.next(hedge0);
				auto hedge2 = mesh->model.next(hedge1);

				auto vertex0 = mesh->model.source(hedge0);
				auto vertex1 = mesh->model.source(hedge1);
				auto vertex2 = mesh->model.source(hedge2);

				triangles[triangleIndex * 3 + 0] = vertex0 != null_vertex ? mesh->FindVertexIndex(vertex0) : NULL_INDEX;
				triangles[triangleIndex * 3 + 1] = vertex1 != null_vertex ? mesh->FindVertexIndex(vertex1) : NULL_INDEX;
				triangles[triangleIndex * 3 + 2] = vertex2 != null_vertex ? mesh->FindVertexIndex(vertex2) : NULL_INDEX;
				triangleIndex++;
			}
			else if (count == 4 && quadIndex < quadCount)
			{
				auto hedge1 = mesh->model.next(hedge0);
				auto hedge2 = mesh->model.next(hedge1);
				auto hedge3 = mesh->model.next(hedge2);

				auto vertex0 = mesh->model.source(hedge0);
				auto vertex1 = mesh->model.source(hedge1);
				auto vertex2 = mesh->model.source(hedge2);
				auto vertex3 = mesh->model.source(hedge3);

				quads[quadIndex * 4 + 0] = vertex0 != null_vertex ? mesh->FindVertexIndex(vertex0) : NULL_INDEX;
				quads[quadIndex * 4 + 1] = vertex1 != null_vertex ? mesh->FindVertexIndex(vertex1) : NULL_INDEX;
				quads[quadIndex * 4 + 2] = vertex2 != null_vertex ? mesh->FindVertexIndex(vertex2) : NULL_INDEX;
				quads[quadIndex * 4 + 3] = vertex3 != null_vertex ? mesh->FindVertexIndex(vertex3) : NULL_INDEX;
				quadIndex++;
			}
		}

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
		typedef K::Vector_3 Vector;
		typedef boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::vertex_descriptor VertexDes;

		auto mesh = CastToSurfaceMesh(ptr);

		if (mesh->vertexNormalsComputed) return;
		mesh->vertexNormalsComputed = true;

		std::string key = VERTEX_NORMAL_MAP_NAME;
		auto normals = mesh->model.add_property_map<VertexDes, Vector>(key, CGAL::NULL_VECTOR).first;
		CGAL::Polygon_mesh_processing::compute_vertex_normals(mesh->model, normals);
	}

	static void ComputeFaceNormals(void* ptr)
	{
		typedef K::Vector_3 Vector;
		typedef boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::face_descriptor FaceDes;

		auto mesh = CastToSurfaceMesh(ptr);

		if (mesh->faceNormalsComputed) return;
		mesh->faceNormalsComputed = true;

		std::string key = FACE_NORMAL_MAP_NAME;
		auto normals = mesh->model.add_property_map<FaceDes, Vector>(key, CGAL::NULL_VECTOR).first;
		CGAL::Polygon_mesh_processing::compute_face_normals(mesh->model, normals);
	}

	static void GetVertexNormals(void* ptr, Vector3d* normals, int count)
	{
		typedef K::Vector_3 Vector;
		typedef boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::vertex_descriptor VertexDes;

		auto mesh = CastToSurfaceMesh(ptr);
		ComputeVertexNormals(ptr);

		auto pair = mesh->model.property_map<VertexDes, Vector>(VERTEX_NORMAL_MAP_NAME);
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
		typedef K::Vector_3 Vector;
		typedef boost::graph_traits<SurfaceMesh3<K>::SurfaceMesh>::face_descriptor FaceDes;

		auto mesh = CastToSurfaceMesh(ptr);
		ComputeFaceNormals(ptr);

		auto pair = mesh->model.property_map<FaceDes, Vector>(FACE_NORMAL_MAP_NAME);
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
