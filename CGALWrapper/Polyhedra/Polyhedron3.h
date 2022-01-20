#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "PrimativeCount.h"
#include "MeshBuilders.h"

#include <limits>
#include <map>
#include <set>
#include <fstream>
#include <iostream>
#include <CGAL/enum.h>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_incremental_builder_3.h>
#include <CGAL/Polygon_mesh_processing/transform.h>
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
class Polyhedron3
{

public:

	typedef typename K::Point_3 Point;
	typedef typename K::Vector_3 Vector;
	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
	typedef typename HalfedgeDS::Vertex Vertex;
	typedef typename HalfedgeDS::Face Face;
	typedef typename Polyhedron::Vertex_handle Vertex_Handle;
	typedef typename Polyhedron::Face_handle Face_Handle;
	typedef typename boost::graph_traits<Polyhedron>::vertex_descriptor	Vertex_Des;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor Face_Des;
	typedef CGAL::Aff_transformation_3<K> Transformation_3;

	typedef typename CGAL::AABB_face_graph_triangle_primitive<Polyhedron> AABB_face_graph_primitive;
	typedef typename CGAL::AABB_traits<K, AABB_face_graph_primitive> AABB_face_graph_traits;
	typedef typename CGAL::AABB_tree<AABB_face_graph_traits> AABBTree;

private:

	std::map<Vertex_Handle, int> vertexIndexMap;
	bool rebuildVertexIndexMap = true;

	std::map<Face_Handle, int> faceIndexMap;
	bool rebuildFaceIndexMap = true;

	std::map<Vertex_Des, Vector> vertexNormalMap;
	bool rebuildVertexNormalMap = true;

	std::map<Face_Des, Vector> faceNormalMap;
	bool rebuildFaceNormalMap = true;

public:

	Polyhedron3() 
	{

	}

	~Polyhedron3()
	{
		DeleteTree();
	}

	Polyhedron model;

	AABBTree* tree = nullptr;

	inline static Polyhedron3* NewPolyhedron()
	{
		return new Polyhedron3();
	}

	inline static void DeletePolyhedron(void* ptr)
	{
		auto obj = static_cast<Polyhedron3*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static Polyhedron3* CastToPolyhedron(void* ptr)
	{
		return static_cast<Polyhedron3*>(ptr);
	}

	void OnModelChanged()
	{
		OnVerticesChanged();
		OnFacesChanged();
	}

	void OnVerticesChanged()
	{
		vertexIndexMap.clear();
		vertexNormalMap.clear();
		rebuildVertexIndexMap = true;
		rebuildVertexNormalMap = true;
		DeleteTree();
	}

	void OnFacesChanged()
	{
		faceIndexMap.clear();
		faceNormalMap.clear();
		rebuildFaceIndexMap = true;
		rebuildFaceNormalMap = true;
		DeleteTree();
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

	void BuildVertexIndexMap(bool force = false)
	{
		if (!force && !rebuildVertexIndexMap) return;
		rebuildVertexIndexMap = false;

		vertexIndexMap.clear();

		int index = 0;
		for (auto vert = model.vertices_begin(); vert != model.vertices_end(); ++vert)
		{
			vertexIndexMap.insert(std::pair<Vertex_Handle, int>(vert, index++));
		}
	}

	void BuildFaceIndexMap(bool force = false)
	{
		if (!force && !rebuildFaceIndexMap) return;
		rebuildFaceIndexMap = false;

		faceIndexMap.clear();

		int index = 0;
		for (auto face = model.facets_begin(); face != model.facets_end(); ++face)
		{
			faceIndexMap.insert(std::pair<Face_Handle, int>(face, index++));
		}
	}

	int FindVertexIndex(Vertex_Handle vert)
	{
		auto item = vertexIndexMap.find(vert);
		if (item != vertexIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	int FindFaceIndex(Face_Handle vert)
	{
		auto item = faceIndexMap.find(vert);
		if (item != faceIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Vector FindVertexNormal(Vertex_Des vert)
	{
		auto item = vertexNormalMap.find(vert);
		if (item != vertexNormalMap.end())
			return item->second;
		else
			return {0,0,0 };
	}
	
	static void Clear(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.clear();
		poly->OnModelChanged();
	}

	static void ClearIndexMaps(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->vertexIndexMap.clear();
		poly->rebuildVertexIndexMap = true;
		poly->faceIndexMap.clear();
		poly->rebuildFaceIndexMap = true;
	}

	static void ClearNormalMaps(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->vertexNormalMap.clear();
		poly->rebuildVertexNormalMap = true;
		poly->faceNormalMap.clear();
		poly->rebuildFaceNormalMap = true;
	}

	static void* Copy(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		auto copy = NewPolyhedron();
		copy->model = poly->model;
		return copy;
	}

	static void BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL force)
	{
		auto poly = CastToPolyhedron(ptr);
		if(vertices) poly->BuildVertexIndexMap(force);
		if(faces) poly->BuildFaceIndexMap(force);
	}

	static int VertexCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.size_of_vertices();
	}

	static int FaceCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.size_of_facets();
	}

	static int HalfEdgeCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.size_of_halfedges();
	}

	static int BorderEdgeCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.size_of_border_edges();
	}

	static int BorderHalfEdgeCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.size_of_border_halfedges();
	}

	static BOOL IsValid(void* ptr, int level)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.is_valid(level);
	}

	static BOOL IsClosed(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.is_closed();
	}

	static BOOL IsPureBivalent(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.is_pure_bivalent();
	}

	static BOOL IsPureTrivalent(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return (int)poly->model.is_pure_trivalent();
	}

	static BOOL IsPureTriangle(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		//return (int)poly->model.is_pure_triangle();

		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) return FALSE;
			if (!face->is_triangle()) return FALSE;
		}
			
		return TRUE;
	}

	static BOOL IsPureQuad(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		//return (int)poly->model.is_pure_quad();

		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) return FALSE;
			if (!face->is_quad()) return FALSE;
		}

		return TRUE;
	}

	static Box3d GetBoundingBox(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		if (poly->tree != nullptr)
		{
			auto box = poly->tree->root_node()->bbox();
			return Box3d::FromCGAL<K>(box);
		}
		else
		{
			auto box = CGAL::Polygon_mesh_processing::bbox(poly->model);
			return Box3d::FromCGAL<K>(box);
		}
	}

	static void MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.make_tetrahedron(p1.ToCGAL<K>(), p2.ToCGAL<K>(), p3.ToCGAL<K>(), p4.ToCGAL<K>());
		poly->OnModelChanged();
	}

	static void MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.make_triangle(p1.ToCGAL<K>(), p2.ToCGAL<K>(), p3.ToCGAL<K>());
	}

	static void CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount)
	{
		auto poly = CastToPolyhedron(ptr);

		BuildTriangleMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.triangles = triangles;
		builder.triangleCount = triangleCount;

		poly->model.delegate(builder);
		poly->OnModelChanged();
	}

	static void CreateQuadMesh(void* ptr, Point3d* points, int pointsCount, int* quads, int quadCount)
	{
		auto poly = CastToPolyhedron(ptr);

		BuildQuadMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.quads = quads;
		builder.quadCount = quadCount;

		poly->model.delegate(builder);
		poly->OnModelChanged();
	}

	static void CreateTriangleQuadMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount, int* quads, int quadCount)
	{
		auto poly = CastToPolyhedron(ptr);

		BuildTriangleQuadMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.triangles = triangles;
		builder.triangleCount = triangleCount;
		builder.quads = quads;
		builder.quadCount = quadCount;

		poly->model.delegate(builder);
		poly->OnModelChanged();
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		int i = 0;

		for (auto point = poly->model.points_begin(); point != poly->model.points_end(); ++point)
		{
			points[i++] = Point3d::FromCGAL<K>(*point);

			if (i >= count) return;
		}
	}

	static PrimativeCount GetPrimativeCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);

		int triangleCount = 0;
		int quadCount = 0;
		int polygonCount = 0;

		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;

			if (face->is_triangle())
				triangleCount++;
			else if (face->is_quad())
				quadCount++;
			else
				polygonCount++;
		}

		return { triangleCount, quadCount, polygonCount };
	}

	static void GetTriangleIndices(void* ptr, int* indices, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->BuildVertexIndexMap();

		int index = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;
			if (!face->is_triangle()) continue;
			
			int i0 = poly->FindVertexIndex(face->halfedge()->prev()->vertex());
			int i1 = poly->FindVertexIndex(face->halfedge()->vertex());
			int i2 = poly->FindVertexIndex(face->halfedge()->next()->vertex());

			indices[index * 3 + 0] = i0;
			indices[index * 3 + 1] = i1;
			indices[index * 3 + 2] = i2;
			
			index++;
			if (index * 3 >= count) return;
		}
	}

	static void GetQuadIndices(void* ptr, int* indices, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->BuildVertexIndexMap();

		int index = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;
			if (!face->is_quad()) continue;

			int i0 = poly->FindVertexIndex(face->halfedge()->prev()->vertex());
			int i1 = poly->FindVertexIndex(face->halfedge()->vertex());
			int i2 = poly->FindVertexIndex(face->halfedge()->next()->vertex());
			int i3 = poly->FindVertexIndex(face->halfedge()->next()->next()->vertex());

			indices[index * 4 + 0] = i0;
			indices[index * 4 + 1] = i1;
			indices[index * 4 + 2] = i2;
			indices[index * 4 + 3] = i3;
			
			index++;

			if (index * 4 >= count) return;
		}
	}

	static void Transform(void* ptr, const Matrix4x4d& matrix)
	{
		auto poly = CastToPolyhedron(ptr);
		auto m = matrix.ToCGAL<K>();

		std::transform(poly->model.points_begin(), poly->model.points_end(), poly->model.points_begin(), m);
		poly->OnModelChanged();
	}

	static void InsideOut(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.inside_out();
		poly->OnModelChanged();
	}

	static void Triangulate(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		CGAL::Polygon_mesh_processing::triangulate_faces(poly->model);
		poly->OnModelChanged();
	}

	static void NormalizeBorder(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.normalize_border();
		poly->OnModelChanged();
	}

	static BOOL NormalizedBorderIsValid(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return poly->model.normalized_border_is_valid();
	}

	static BOOL DoesSelfIntersect(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return CGAL::Polygon_mesh_processing::does_self_intersect(poly->model);
	}

	static double Area(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return CGAL::to_double(CGAL::Polygon_mesh_processing::area(poly->model));
	}

	static Point3d Centroid(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		auto p = CGAL::Polygon_mesh_processing::centroid(poly->model);
		return Point3d::FromCGAL<K>(p);
	}

	static double Volume(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return CGAL::to_double(CGAL::Polygon_mesh_processing::volume(poly->model));
	}

	static BOOL DoesBoundAVolume(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return CGAL::Polygon_mesh_processing::does_bound_a_volume(poly->model);
	}

	static void BuildAABBTree(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->BuildAABBTree();
	}

	static void ReleaseAABBTree(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->DeleteTree();
	}

	static CGAL::Bounded_side SideOfTriangleMesh(void* ptr, const Point3d& point)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->BuildAABBTree();
		CGAL::Side_of_triangle_mesh<Polyhedron, K> inside(*poly->tree);
		return inside(point.ToCGAL<K>());
	}

	static BOOL DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides)
	{
		auto poly = CastToPolyhedron(ptr);
		auto other = CastToPolyhedron(otherPtr);
		auto param = CGAL::parameters::do_overlap_test_of_bounded_sides(test_bounded_sides);

		return CGAL::Polygon_mesh_processing::do_intersect(poly->model, other->model, param, param);
	}

	static void ReadOFF(void* ptr, const char* filename)
	{
		auto poly = CastToPolyhedron(ptr);
		std::ifstream i(filename);
		i >> poly->model;
		poly->OnModelChanged();
	}

	static void WriteOFF(void* ptr, const char* filename)
	{
		auto poly = CastToPolyhedron(ptr);
		std::ofstream o(filename);
		o << poly->model;
	}

	static MinMaxAvg MinMaxEdgeLength(void* ptr)
	{
		auto poly = Polyhedron3<EEK>::CastToPolyhedron(ptr);

		constexpr double MAX = std::numeric_limits<double>::max();

		MinMaxAvg m;
		m.min = MAX;
		m.max = 0;
		m.avg = 0;

		int count = 0;
		for (auto halfedge = poly->model.halfedges_begin(); halfedge != poly->model.halfedges_end(); ++halfedge)
		{
			auto ft = CGAL::Polygon_mesh_processing::edge_length(halfedge, poly->model);
			double len = CGAL::to_double(ft);

			count++;
			m.avg += len;

			if (len < m.min) m.min = len;
			if (len > m.max) m.max = len;
		}

		if (m.min == MAX)
			m.min = 0;

		if (count != 0)
			m.avg /= count;

		return m;
	}

	static void GetCentroids(void* ptr, Point3d* points, int count)
	{
		auto poly = Polyhedron3<EEK>::CastToPolyhedron(ptr);
		int numFaces = (int)poly->model.size_of_facets();

		int index = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;

			int num = 0;
			Point3d centroid = { 0, 0, 0 };

			auto hedge = face->facet_begin();
			do
			{
				auto p = Point3d::FromCGAL<K>(hedge->vertex()->point());
				centroid = centroid + p;
				num++;
			} 
			while (++hedge != face->facet_begin());

			if (num != 0)
				centroid = centroid / num;

			points[index] = centroid;

			index++;

			if (index >= numFaces || index >= count)
				return;
		}
	}

	static void ComputeVertexNormals(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);

		if (!poly->rebuildVertexNormalMap) return;
		poly->rebuildVertexNormalMap = false;
;
		CGAL::Polygon_mesh_processing::compute_vertex_normals(poly->model, 
			boost::make_assoc_property_map(poly->vertexNormalMap));
	}

	static void ComputeFaceNormals(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);

		if (!poly->rebuildFaceNormalMap) return;
		poly->rebuildFaceNormalMap = false;

		CGAL::Polygon_mesh_processing::compute_face_normals(poly->model, 
			boost::make_assoc_property_map(poly->faceNormalMap));
	}

	static void GetVertexNormals(void* ptr, Vector3d* normals, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		ComputeVertexNormals(ptr);
		poly->BuildVertexIndexMap();

		for (auto const& pair : poly->vertexNormalMap)
		{
			auto vert = pair.first;
			auto vec = pair.second;

			int i = poly->FindVertexIndex(vert);

			if (i >= 0 && i < count)
				normals[i] = Vector3d::FromCGAL<K>(vec);
		}
	}

	static void GetFaceNormals(void* ptr, Vector3d* normals, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		ComputeFaceNormals(ptr);
		poly->BuildFaceIndexMap();

		for (auto const& pair : poly->faceNormalMap)
		{
			auto face = pair.first;
			auto vec = pair.second;

			int i = poly->FindFaceIndex(face);

			if (i >= 0 && i < count)
				normals[i] = Vector3d::FromCGAL<K>(vec);
		}
	}

};
