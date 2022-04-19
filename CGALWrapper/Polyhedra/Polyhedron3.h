#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "PolygonalCount.h"
#include "MeshBuilders.h"
#include "PolyhedronMap.h"
#include "MeshVertex3.h"
#include "MeshFace3.h"
#include "MeshHalfedge3.h"

#include <limits>
#include <map>
#include <unordered_map>
#include <set>
#include <fstream>
#include <iostream>
#include <CGAL/enum.h>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>
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

	typedef typename K::FT FT;
	typedef typename K::Point_3 Point;
	typedef typename K::Vector_3 Vector;
	//typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;
	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
	typedef typename HalfedgeDS::Vertex Vertex;
	typedef typename HalfedgeDS::Face Face;
	typedef typename HalfedgeDS::Halfedge Halfedge;

	//typedef typename boost::graph_traits<Polyhedron>::vertex_descriptor	Vertex_Des;
	//typedef typename boost::graph_traits<Polyhedron>::face_descriptor Face_Des;
	//typedef typename boost::graph_traits<Polyhedron>::edge_descriptor Edge_Des;
	//typedef typename boost::graph_traits<Polyhedron>::halfedge_descriptor Halfedge_Des;

	typedef typename HalfedgeDS::Vertex_iterator Vertex_Iter;
	typedef typename HalfedgeDS::Face_iterator Face_Iter;
	typedef typename HalfedgeDS::Halfedge_iterator Halfedge_Iter;

	typedef typename CGAL::AABB_face_graph_triangle_primitive<Polyhedron> AABB_face_graph_primitive;
	typedef typename CGAL::AABB_traits<K, AABB_face_graph_primitive> AABB_face_graph_traits;
	typedef typename CGAL::AABB_tree<AABB_face_graph_traits> AABBTree;
	typedef CGAL::Aff_transformation_3<K> Transformation_3;


public:

	PolyhedronMap<K> map;

	std::unordered_map<Vertex_Iter, Vector> vertexNormalMap;
	bool rebuildVertexNormalMap = true;

	std::unordered_map<Face_Iter, Vector> faceNormalMap;
	bool rebuildFaceNormalMap = true;

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

	void OnVertexNormalsChanged()
	{
		vertexNormalMap.clear();
		rebuildVertexNormalMap = true;
	}

	void OnFaceNormalsChanged()
	{
		faceNormalMap.clear();
		rebuildFaceNormalMap = true;
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

	void OnHalfedgesChanged()
	{
		map.OnHalfedgesChanged();
		DeleteTree();
	}

	void OnModelChanged()
	{
		OnVerticesChanged();
		OnFacesChanged();
		OnHalfedgesChanged();
	}

	void BuildModel()
	{
		map.BuildVertexMaps();
		map.BuildFaceMaps();
		map.BuildHalfedgeMaps();
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

	int FindVertexIndex(Vertex_Iter vert)
	{
		map.BuildVertexMaps(model);
		return map.FindVertexIndex(model, vert);
	}

	Vertex_Iter* FindVertexIter(int index)
	{
		map.BuildVertexMaps(model);
		return map.FindVertexIter(model, index);
	}

	Vertex* FindVertex(int index)
	{
		map.BuildVertexMaps(model);
		return map.FindVertex(model, index);
	}

	int FindFaceIndex(Face_Iter face)
	{
		map.BuildFaceMaps(model);
		return map.FindFaceIndex(face);
	}

	Face_Iter* FindFaceIter(int index)
	{
		map.BuildFaceMaps(model);
		return map.FindFaceIter(index);
	}

	int FindHalfedgeIndex(Halfedge_Iter edge)
	{
		map.BuildHalfedgeMaps(model);
		return map.FindHalfedgeIndex(edge);
	}

	Halfedge_Iter* FindHalfedgeIter(int index)
	{
		map.BuildHalfedgeMaps(model);
		return map.FindHalfedgeIter(index);
	}

	Halfedge_Iter GetHalfedgeIter(int index)
	{
		map.BuildHalfedgeMaps(model);
		return map.GetHalfedgeIter(index);
	}

	Vector FindVertexNormal(Vertex_Iter vert)
	{
		auto item = vertexNormalMap.find(vert);
		if (item != vertexNormalMap.end())
			return item->second;
		else
			return { 0,0,0 };
	}

	static int GetBuildStamp(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return poly->map.BuildStamp();
	}

	static void Clear(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.clear();
		poly->OnModelChanged();
	}

	static void ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges)
	{
		auto poly = CastToPolyhedron(ptr);
		if (vertices) poly->map.OnVerticesChanged();
		if (faces) poly->map.OnFacesChanged();
		if (edges) poly->map.OnHalfedgesChanged();
	}

	static void ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces)
	{
		auto poly = CastToPolyhedron(ptr);
		if (vertices) poly->OnVertexNormalsChanged();
		if (faces) poly->OnFaceNormalsChanged();
	}

	static void BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL force)
	{
		auto poly = CastToPolyhedron(ptr);
		if (vertices) poly->map.BuildVertexMaps(poly->model, force);
		if (faces) poly->map.BuildFaceMaps(poly->model, force);
		if (edges) poly->map.BuildHalfedgeMaps(poly->model, force);
	}

	static void* Copy(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		auto copy = NewPolyhedron();
		copy->model = poly->model;
		return copy;
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

	static int MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
	{
		auto poly = CastToPolyhedron(ptr);
		auto e = poly->model.make_tetrahedron(p1.ToCGAL<K>(), p2.ToCGAL<K>(), p3.ToCGAL<K>(), p4.ToCGAL<K>());
		poly->OnModelChanged();

		return poly->FindHalfedgeIndex(e);
	}

	static int MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3)
	{
		auto poly = CastToPolyhedron(ptr);
		auto e = poly->model.make_triangle(p1.ToCGAL<K>(), p2.ToCGAL<K>(), p3.ToCGAL<K>());
		poly->OnModelChanged();

		return poly->FindHalfedgeIndex(e);
	}

	Point3d GetPoint(int index)
	{
		auto vertex = FindVertex(index);
		if (vertex != nullptr)
			return Point3d::FromCGAL(vertex->point());
		else
			return { 0, 0, 0 };
	}

	static Point3d GetPoint(void* ptr, int index)
	{
		auto poly = CastToPolyhedron(ptr);
		return poly->GetPoint(index);
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		int i = 0;

		for (int i = 0; i < count; i++)
		{
			points[i] = poly->GetPoint(i);
		}
	}

	void SetPoint(int index, const Point3d& point)
	{
		auto vertex = FindVertex(index);
		if (vertex != nullptr)
			vertex->point() = point.ToCGAL<K>();
	}

	static void SetPoint(void* ptr, int index, const Point3d& point)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->SetPoint(index, point);
	}

	static void SetPoints(void* ptr, Point3d* points, int count)
	{
		auto poly = CastToPolyhedron(ptr);

		for (int i = 0; i < count; i++)
		{
			poly->SetPoint(i, points[i]);
		}
	}

	static BOOL GetSegment(void* ptr, int index, Segment3d& segment)
	{
		auto poly = CastToPolyhedron(ptr);

		auto edge = poly->FindHalfedgeIter(index);
		if (edge != nullptr)
		{
			auto a = (*edge)->vertex()->point();
			auto b = (*edge)->opposite()->vertex()->point();

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
		auto poly = CastToPolyhedron(ptr);

		int i = 0;
		for (auto edge = poly->model.halfedges_begin(); edge != poly->model.halfedges_end(); ++edge)
		{
			auto a = edge->vertex()->point();
			auto b = edge->opposite()->vertex()->point();

			Segment3d seg;
			seg.a = Point3d::FromCGAL<K>(a);
			seg.b = Point3d::FromCGAL<K>(b);

			segments[i++] = seg;

			if (i >= count) return;
		}
	}

	static BOOL GetTriangle(void* ptr, int index, Triangle3d& tri)
	{
		auto poly = CastToPolyhedron(ptr);

		auto face = poly->FindFaceIter(index);
		if (face != nullptr)
		{
			auto a = (*face)->halfedge()->prev()->vertex()->point();
			auto b = (*face)->halfedge()->vertex()->point();
			auto c = (*face)->halfedge()->next()->vertex()->point();

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
		auto poly = CastToPolyhedron(ptr);

		int i = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;

			auto a = face->halfedge()->prev()->vertex()->point();
			auto b = face->halfedge()->vertex()->point();
			auto c = face->halfedge()->next()->vertex()->point();

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
		auto poly = CastToPolyhedron(ptr);
		vert = MeshVertex3::NullVertex();

		auto v = poly->FindVertexIter(index);
		if (v != nullptr)
		{
			vert.Index = index;
			vert.Halfedge = poly->FindHalfedgeIndex((*v)->halfedge());
			vert.Point = Point3d::FromCGAL<K>((*v)->point());
			vert.Degree = (int)(*v)->degree();

			return TRUE;
		}
		else
		{
			return FALSE;
		}

	}

	static void GetVertices(void* ptr, MeshVertex3* vertices, int count)
	{
		auto poly = CastToPolyhedron(ptr);

		int i = 0;
		for (auto v = poly->model.vertices_begin(); v != poly->model.vertices_end(); ++v)
		{
			MeshVertex3 vert = MeshVertex3::NullVertex();
			vert.Index = i;
			vert.Halfedge = poly->FindHalfedgeIndex(v->halfedge());
			vert.Point = Point3d::FromCGAL<K>(v->point());
			vert.Degree = (int)v->degree();

			vertices[i] = vert;

			i++;
			if (i >= count) return;
		}
	}

	static BOOL GetFace(void* ptr, int index, MeshFace3& face)
	{
		auto poly = CastToPolyhedron(ptr);
		face = MeshFace3::NullFace();

		auto f = poly->FindFaceIter(index);
		if (f != nullptr)
		{
			face.Index = index;
			face.Halfedge = poly->FindHalfedgeIndex((*f)->halfedge());

			return TRUE;
		}
		else
		{
			return FALSE;
		}

	}

	static void GetFaces(void* ptr, MeshFace3* faces, int count)
	{
		auto poly = CastToPolyhedron(ptr);

		int i = 0;
		for (auto f = poly->model.facets_begin(); f != poly->model.facets_end(); ++f)
		{
			MeshFace3 face = MeshFace3::NullFace();
			face.Index = i;

			if (f->halfedge() != nullptr)
				face.Halfedge = poly->FindHalfedgeIndex(f->halfedge());

			faces[i] = face;

			i++;
			if (i >= count) return;
		}
	}

	static BOOL GetHalfedge(void* ptr, int index, MeshHalfedge3& edge)
	{
		auto poly = CastToPolyhedron(ptr);
		edge = MeshHalfedge3::NullHalfedge();

		auto e = poly->FindHalfedgeIter(index);
		if (e != nullptr)
		{
			edge.Index = index;
			edge.Source = poly->FindVertexIndex((*e)->vertex());
			edge.Target = poly->FindVertexIndex((*e)->opposite()->vertex());
			edge.Opposite = poly->FindHalfedgeIndex((*e)->opposite());
			edge.Next = poly->FindHalfedgeIndex((*e)->next());
			edge.Previous = poly->FindHalfedgeIndex((*e)->prev());
			edge.Face = poly->FindFaceIndex((*e)->face());
			edge.IsBorder = (*e)->is_border();

			return TRUE;
		}
		else
		{
			return FALSE;
		}

	}

	static void GetHalfedges(void* ptr, MeshHalfedge3* edges, int count)
	{
		auto poly = CastToPolyhedron(ptr);

		int i = 0;
		for (auto e = poly->model.halfedges_begin(); e != poly->model.halfedges_end(); ++e)
		{
			MeshHalfedge3 edge = MeshHalfedge3::NullHalfedge();
			edge.Index = i;
			edge.Source = poly->FindVertexIndex(e->vertex());
			edge.Target = poly->FindVertexIndex(e->opposite()->vertex());
			edge.Opposite = poly->FindHalfedgeIndex(e->opposite());
			edge.Next = poly->FindHalfedgeIndex(e->next());
			edge.Previous = poly->FindHalfedgeIndex(e->prev());
			edge.Face = poly->FindFaceIndex(e->face());
			edge.IsBorder = e->is_border();

			edges[i] = edge;

			i++;
			if (i >= count) return;
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

	static void GetCentroids(void* ptr, Point3d* points, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		int numFaces = (int)poly->model.size_of_facets();

		int index = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;

			auto c = ComputeCentroid(*face);
			points[index] = Point3d::FromCGAL<K>(c);

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
		poly->map.BuildVertexMaps(poly->model);

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
		poly->map.BuildFaceMaps(poly->model);

		for (auto const& pair : poly->faceNormalMap)
		{
			auto face = pair.first;
			auto vec = pair.second;

			int i = poly->FindFaceIndex(face);

			if (i >= 0 && i < count)
				normals[i] = Vector3d::FromCGAL<K>(vec);
		}
	}

	static Point ComputeCentroid(const Face& face)
	{
		int num = 0;

		FT x = 0;
		FT y = 0;
		FT z = 0;

		auto hedge = face.facet_begin();
		do
		{
			auto p = hedge->vertex()->point();
			x += p.x();
			y += p.y();
			z += p.z();
			num++;
		} while (++hedge != face.facet_begin());

		if (num != 0)
		{
			x /= num;
			y /= num;
			z /= num;
		}

		return { x, y, z };
	}

	static int CountFaceVertices(const Face& face)
	{
		int num = 0;

		auto hedge = face.facet_begin();
		do
		{
			num++;
		} while (++hedge != face.facet_begin());

		return num;
	}

	static void CreatePolygonMesh(void* ptr, Point2d* points, int pointsCount, BOOL xz)
	{
		auto poly = CastToPolyhedron(ptr);

		BuildPolygonMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.xz = xz;

		poly->model.delegate(builder);
		poly->OnModelChanged();
	}

	static PolygonalCount GetPolygonalCount(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);

		int degenerate = 0;
		int three = 0;
		int four = 0;
		int five = 0;
		int six = 0;
		int greater = 0;

		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;

			int count = CountFaceVertices(*face);

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
		auto poly = CastToPolyhedron(ptr);

		int degenerate = 0;
		int three = 0;
		int four = 0;
		int five = 0;
		int six = 0;
		int greater = 0;

		for (auto vert = poly->model.vertices_begin(); vert != poly->model.vertices_end(); ++vert)
		{
			int count = 0;
			auto start = vert->vertex_begin(), end = start;
			CGAL_For_all(start, end)
			{
				count++;
				if (count > 6) break;
			}

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

	static void CreatePolygonalMesh(void* ptr,
		Point3d* points, int pointsCount,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount)
	{
		auto poly = CastToPolyhedron(ptr);

		BuildPolygonalMesh<HalfedgeDS, K> builder;
		builder.vertices = points;
		builder.verticesCount = pointsCount;
		builder.triangles = triangles;
		builder.triangleCount = triangleCount;
		builder.quads = quads;
		builder.quadCount = quadCount;
		builder.pentagons = pentagons;
		builder.pentagonCount = pentagonCount;
		builder.hexagons = hexagons;
		builder.hexagonCount = hexagonCount;

		poly->model.delegate(builder);
		poly->OnModelChanged();
	}

	static void GetPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->map.BuildVertexMaps(poly->model);

		int triangleIndex = 0;
		int quadIndex = 0;
		int pentagonIndex = 0;
		int hexagonIndex = 0;

		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;

			int count = CountFaceVertices(*face);

			if (count == 3 && triangleIndex * 3 < triangleCount)
			{
				auto e0 = face->halfedge();
				auto e1 = e0->next();
				auto e2 = e1->next();

				int i0 = poly->FindVertexIndex(e0->vertex());
				int i1 = poly->FindVertexIndex(e1->vertex());
				int i2 = poly->FindVertexIndex(e2->vertex());

				triangles[triangleIndex * 3 + 0] = i0;
				triangles[triangleIndex * 3 + 1] = i1;
				triangles[triangleIndex * 3 + 2] = i2;

				triangleIndex++;
			}
			else if (count == 4 && quadIndex * 4 < quadCount)
			{
				auto e0 = face->halfedge();
				auto e1 = e0->next();
				auto e2 = e1->next();
				auto e3 = e2->next();

				int i0 = poly->FindVertexIndex(e0->vertex());
				int i1 = poly->FindVertexIndex(e1->vertex());
				int i2 = poly->FindVertexIndex(e2->vertex());
				int i3 = poly->FindVertexIndex(e3->vertex());

				quads[quadIndex * 4 + 0] = i0;
				quads[quadIndex * 4 + 1] = i1;
				quads[quadIndex * 4 + 2] = i2;
				quads[quadIndex * 4 + 3] = i3;

				quadIndex++;
			}
			else if (count == 5 && pentagonIndex * 5 < pentagonCount)
			{
				auto e0 = face->halfedge();
				auto e1 = e0->next();
				auto e2 = e1->next();
				auto e3 = e2->next();
				auto e4 = e3->next();

				int i0 = poly->FindVertexIndex(e0->vertex());
				int i1 = poly->FindVertexIndex(e1->vertex());
				int i2 = poly->FindVertexIndex(e2->vertex());
				int i3 = poly->FindVertexIndex(e3->vertex());
				int i4 = poly->FindVertexIndex(e4->vertex());

				pentagons[pentagonIndex * 5 + 0] = i0;
				pentagons[pentagonIndex * 5 + 1] = i1;
				pentagons[pentagonIndex * 5 + 2] = i2;
				pentagons[pentagonIndex * 5 + 3] = i3;
				pentagons[pentagonIndex * 5 + 4] = i4;

				pentagonIndex++;
			}
			else if (count == 6 && hexagonIndex * 6 < hexagonCount)
			{
				auto e0 = face->halfedge();
				auto e1 = e0->next();
				auto e2 = e1->next();
				auto e3 = e2->next();
				auto e4 = e3->next();
				auto e5 = e4->next();

				int i0 = poly->FindVertexIndex(e0->vertex());
				int i1 = poly->FindVertexIndex(e1->vertex());
				int i2 = poly->FindVertexIndex(e2->vertex());
				int i3 = poly->FindVertexIndex(e3->vertex());
				int i4 = poly->FindVertexIndex(e4->vertex());
				int i5 = poly->FindVertexIndex(e5->vertex());

				hexagons[hexagonIndex * 6 + 0] = i0;
				hexagons[hexagonIndex * 6 + 1] = i1;
				hexagons[hexagonIndex * 6 + 2] = i2;
				hexagons[hexagonIndex * 6 + 3] = i3;
				hexagons[hexagonIndex * 6 + 4] = i4;
				hexagons[hexagonIndex * 6 + 5] = i5;

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
		auto poly = CastToPolyhedron(ptr);
		poly->map.BuildFaceMaps(poly->model);

		int triangleIndex = 0;
		int quadIndex = 0;
		int pentagonIndex = 0;
		int hexagonIndex = 0;
		int indices[6];

		for (auto vert = poly->model.vertices_begin(); vert != poly->model.vertices_end(); ++vert)
		{
			int count = 0;
			auto start = vert->vertex_begin(), end = start;
			CGAL_For_all(start, end)
			{
				auto face = start->face();
				indices[count++] = poly->FindFaceIndex(face);
				if (count >= 6) break;
			}

			if (count == 3 && triangleIndex * 3 < triangleCount)
			{
				triangles[triangleIndex * 3 + 0] = indices[2];
				triangles[triangleIndex * 3 + 1] = indices[1];
				triangles[triangleIndex * 3 + 2] = indices[0];

				triangleIndex++;
			}
			else if (count == 4 && quadIndex * 4 < quadCount)
			{
				quads[quadIndex * 4 + 0] = indices[3];
				quads[quadIndex * 4 + 1] = indices[2];
				quads[quadIndex * 4 + 2] = indices[1];
				quads[quadIndex * 4 + 3] = indices[0];

				quadIndex++;
			}
			else if (count == 5 && pentagonIndex * 5 < pentagonCount)
			{
				pentagons[pentagonIndex * 5 + 0] = indices[4];
				pentagons[pentagonIndex * 5 + 1] = indices[3];
				pentagons[pentagonIndex * 5 + 2] = indices[2];
				pentagons[pentagonIndex * 5 + 3] = indices[1];
				pentagons[pentagonIndex * 5 + 4] = indices[0];

				pentagonIndex++;
			}
			else if (count == 6 && hexagonIndex * 6 < hexagonCount)
			{
				hexagons[hexagonIndex * 6 + 0] = indices[5];
				hexagons[hexagonIndex * 6 + 1] = indices[4];
				hexagons[hexagonIndex * 6 + 2] = indices[3];
				hexagons[hexagonIndex * 6 + 3] = indices[2];
				hexagons[hexagonIndex * 6 + 4] = indices[1];
				hexagons[hexagonIndex * 6 + 5] = indices[0];

				hexagonIndex++;
			}

		}
	}

	static int AddFacetToBorder(void* ptr, int h, int g)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);
		auto eg = poly->FindHalfedgeIter(g);

		if (eh == nullptr || eg == nullptr)
			return NULL_INDEX;

		auto e = poly->model.add_facet_to_border(*eh, *eg);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int AddVertexAndFacetToBorder(void* ptr, int h, int g)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);
		auto eg = poly->FindHalfedgeIter(g);

		if (eh == nullptr || eg == nullptr)
			return NULL_INDEX;

		auto e = poly->model.add_vertex_and_facet_to_border(*eh, *eg);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int CreateCenterVertex(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return NULL_INDEX;

		auto e = poly->model.create_center_vertex(*eh);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int EraseCenterVertex(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return NULL_INDEX;

		auto e = poly->model.erase_center_vertex(*eh);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static BOOL EraseConnectedComponent(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return FALSE;

		poly->model.erase_connected_component(*eh);

		poly->OnModelChanged();

		return TRUE;
	}

	static BOOL EraseFacet(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return FALSE;

		poly->model.erase_facet(*eh);

		poly->OnModelChanged();

		return TRUE;
	}

	static int FillHole(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return NULL_INDEX;

		auto e = poly->model.fill_hole(*eh);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int FlipEdge(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return NULL_INDEX;

		auto e = poly->model.flip_edge(*eh);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int JoinFacet(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return NULL_INDEX;

		auto e = poly->model.join_facet(*eh);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int JoinLoop(void* ptr, int h, int g)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);
		auto eg = poly->FindHalfedgeIter(g);

		if (eh == nullptr || eg == nullptr)
			return NULL_INDEX;

		auto e = poly->model.join_loop(*eh, *eg);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int JoinVertex(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return NULL_INDEX;

		auto e = poly->model.join_vertex(*eh);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int MakeHole(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return NULL_INDEX;

		auto e = poly->model.make_hole(*eh);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int SplitEdge(void* ptr, int h)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);

		if (eh == nullptr)
			return NULL_INDEX;

		auto e = poly->model.split_edge(*eh);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int SplitFacet(void* ptr, int h, int g)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);
		auto eg = poly->FindHalfedgeIter(g);

		if (eh == nullptr || eg == nullptr)
			return NULL_INDEX;

		auto e = poly->model.split_facet(*eh, *eg);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int SplitLoop(void* ptr, int h, int g, int k)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);
		auto eg = poly->FindHalfedgeIter(g);
		auto ek = poly->FindHalfedgeIter(k);

		if (eh == nullptr || eg == nullptr || ek == nullptr)
			return NULL_INDEX;

		auto e = poly->model.split_loop(*eh, *eg, *ek);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

	static int SplitVertex(void* ptr, int h, int g)
	{
		auto poly = CastToPolyhedron(ptr);

		auto eh = poly->FindHalfedgeIter(h);
		auto eg = poly->FindHalfedgeIter(g);

		if (eh == nullptr || eg == nullptr)
			return NULL_INDEX;

		auto e = poly->model.split_vertex(*eh, *eg);

		poly->OnModelChanged();
		poly->map.BuildHalfedgeMaps(poly->model);

		return poly->FindHalfedgeIndex(e);
	}

};
