#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "FaceVertexCount.h"
#include "MeshBuilders.h"
#include "PolyhedronMap.h"

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
	typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;
	typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
	typedef typename HalfedgeDS::Vertex Vertex;
	typedef typename HalfedgeDS::Face Face;
	typedef typename HalfedgeDS::Halfedge Halfedge;
	typedef typename Polyhedron::Vertex_handle Vertex_Handle;
	typedef typename Polyhedron::Face_handle Face_Handle;
	typedef typename Polyhedron::Halfedge_handle Halfedge_Handle;
	typedef typename boost::graph_traits<Polyhedron>::vertex_descriptor	Vertex_Des;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor Face_Des;
	typedef typename boost::graph_traits<Polyhedron>::edge_descriptor Edge_Des;
	typedef typename boost::graph_traits<Polyhedron>::halfedge_descriptor Halfedge_Des;
	typedef CGAL::Aff_transformation_3<K> Transformation_3;

	typedef typename CGAL::AABB_face_graph_triangle_primitive<Polyhedron> AABB_face_graph_primitive;
	typedef typename CGAL::AABB_traits<K, AABB_face_graph_primitive> AABB_face_graph_traits;
	typedef typename CGAL::AABB_tree<AABB_face_graph_traits> AABBTree;

private:

	PolyhedronMap<K> map;

	std::unordered_map<Vertex_Des, Vector> vertexNormalMap;
	bool rebuildVertexNormalMap = true;

	std::unordered_map<Face_Des, Vector> faceNormalMap;
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

	int FindVertexIndex(Vertex_Des vert)
	{
		map.BuildVertexMaps(model);
		return map.FindVertexIndex(vert);
	}

	Vertex_Des* FindVertexDes(int index)
	{
		map.BuildVertexMaps(model);
		return map.FindVertexDes(index);
	}

	Vertex* FindVertex(int index)
	{
		map.BuildVertexMaps(model);
		return map.FindVertex(index);
	}

	Vertex* GetVertex(int index)
	{
		map.BuildVertexMaps(model);
		return map.GetVertex(index);
	}

	int FindFaceIndex(Face_Des face)
	{
		map.BuildFaceMaps(model);
		return map.FindFaceIndex(face);
	}

	Face_Des* FindFaceDes(int index)
	{
		map.BuildFaceMaps(model);
		return map.FindFaceDes(index);
	}

	int FindHalfedgeIndex(Halfedge_Des edge)
	{
		map.BuildHalfedgeMaps(model);
		return map.FindHalfedgeIndex(edge);
	}

	Edge_Des* FindHalfdgeDes(int index)
	{
		map.BuildEdgeMaps(model);
		return map.FindHalfedgeDes(index);
	}

	Vector FindVertexNormal(Vertex_Des vert)
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

	static Point3d GetPoint(void* ptr, int index)
	{
		auto poly = CastToPolyhedron(ptr);

		auto vertex = poly->FindVertex(index);
		if (vertex != nullptr)
			return Point3d::FromCGAL(vertex->point());
		else
			return { 0, 0, 0 };
	}

	static void GetPoints(void* ptr, Point3d* points, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		int i = 0;

		for (const auto point : poly->model.points())
		{
			points[i++] = Point3d::FromCGAL<K>(point);
			if (i >= count) return;
		}
	}

	static void SetPoint(void* ptr, int index, const Point3d& point)
	{
		auto poly = CastToPolyhedron(ptr);

		auto vertex = poly->FindVertex(index);
		if (vertex != nullptr)
			vertex->point() = point.ToCGAL<K>();
	}

	static void SetPoints(void* ptr, Point3d* points, int count)
	{
		auto poly = CastToPolyhedron(ptr);

		for (int i = 0; i < count; i++)
		{
			auto vertex = poly->GetVertex(i);
			vertex->point() = points[i].ToCGAL<K>();
		}

		//int i = 0;
		//for (auto& point : poly->model.points())
		//{
		//	point = points[i++].ToCGAL<K>();
		//	if (i >= count) return;
		//}
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

		FT min = MAX;
		FT max = 0;
		FT avg = 0;

		int count = 0;
		for (auto halfedge = poly->model.halfedges_begin(); halfedge != poly->model.halfedges_end(); ++halfedge)
		{
			auto len = CGAL::Polygon_mesh_processing::edge_length(halfedge, poly->model);

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
		auto poly = Polyhedron3<EEK>::CastToPolyhedron(ptr);
		int numFaces = (int)poly->model.size_of_facets();

		int index = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;

			points[index] = Point3d::FromCGAL<K>(ComputeCentroid(*face));

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

	static FaceVertexCount GetFaceVertexCount(void* ptr)
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

	static FaceVertexCount GetDualFaceVertexCount(void* ptr)
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
		auto poly = Polyhedron3<EEK>::CastToPolyhedron(ptr);
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

};
