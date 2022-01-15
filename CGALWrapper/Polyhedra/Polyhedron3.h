#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "PrimativeCount.h"
#include "MeshBuilders.h"
 
#include <map>
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
#include <CGAL/Polygon_mesh_processing/repair_polygon_soup.h>

template<class K>
class Polyhedron3
{

public:

	typedef typename K::Point_3 Point;
	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
	typedef typename HalfedgeDS::Vertex Vertex;
	typedef typename HalfedgeDS::Face Face;
	typedef CGAL::Aff_transformation_3<K> Transformation_3;

	Polyhedron3() 
	{

	}

	~Polyhedron3()
	{

	}

	Polyhedron model;

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
	
	static void Clear(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.clear();
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

	static int IsPureTriangle(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		//return (int)poly->model.is_pure_triangle();

		//for (auto vert = poly->vertices_begin(); vert != poly->vertices_end(); ++vert)
		//{
		//	if (vert->halfedge() == nullptr) return 1;
		//	if (vert->halfedge()->face() == nullptr) return 2;
		//}

		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) return 3;
			//if (face->halfedge()->vertex() == nullptr) return 4;
			//if (face->halfedge()->next() == nullptr) return 5;
			//if (face->halfedge()->prev() == nullptr) return 6;
			if (!face->is_triangle()) return 7;
		}
			
		return 0;
	}

	static int IsPureQuad(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		//return (int)poly->model.is_pure_quad();

		//for (auto vert = poly->vertices_begin(); vert != poly->vertices_end(); ++vert)
		//{
		//	if (vert->halfedge() == nullptr) return 1;
		//	if (vert->halfedge()->face() == nullptr) return 2;
		//}

		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) return 3;
			//if (face->halfedge()->vertex() == nullptr) return 4;
			//if (face->halfedge()->next() == nullptr) return 5;
			//if (face->halfedge()->prev() == nullptr) return 6;
			if (!face->is_quad()) return 7;
		}

		return 0;
	}

	static void MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.make_tetrahedron(p1.ToCGAL<K>(), p2.ToCGAL<K>(), p3.ToCGAL<K>(), p4.ToCGAL<K>());
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
		int index = 0;

		std::map<Point, int> map;

		for (auto point = poly->model.points_begin(); point != poly->model.points_end(); ++point)
		{
			map.insert(std::pair<Point, int>(*point, index++));
		}

		index = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;
			if (!face->is_triangle()) continue;
			
			auto i0 = map.find(face->halfedge()->prev()->vertex()->point());
			auto i1 = map.find(face->halfedge()->vertex()->point());
			auto i2 = map.find(face->halfedge()->next()->vertex()->point());

			if (i0 == map.end() || i1 == map.end() || i2 == map.end())
			{
				indices[index * 3 + 0] = NULL_INDEX;
				indices[index * 3 + 1] = NULL_INDEX;
				indices[index * 3 + 2] = NULL_INDEX;
			}
			else
			{
				indices[index * 3 + 0] = i0->second;
				indices[index * 3 + 1] = i1->second;
				indices[index * 3 + 2] = i2->second;
			}

			index++;

			if (index * 3 >= count) return;
		}
	}

	static void GetQuadIndices(void* ptr, int* indices, int count)
	{
		auto poly = CastToPolyhedron(ptr);
		int index = 0;

		std::map<Point, int> map;

		for (auto point = poly->model.points_begin(); point != poly->model.points_end(); ++point)
		{
			map.insert(std::pair<Point, int>(*point, index++));
		}

		index = 0;
		for (auto face = poly->model.facets_begin(); face != poly->model.facets_end(); ++face)
		{
			if (face->halfedge() == nullptr) continue;
			if (!face->is_quad()) continue;

			auto i0 = map.find(face->halfedge()->prev()->vertex()->point());
			auto i1 = map.find(face->halfedge()->vertex()->point());
			auto i2 = map.find(face->halfedge()->next()->vertex()->point());
			auto i3 = map.find(face->halfedge()->next()->next()->vertex()->point());

			if (i0 == map.end() || i1 == map.end() || i2 == map.end() || i3 == map.end())
			{
				indices[index * 4 + 0] = NULL_INDEX;
				indices[index * 4 + 1] = NULL_INDEX;
				indices[index * 4 + 2] = NULL_INDEX;
				indices[index * 4 + 3] = NULL_INDEX;
			}
			else
			{
				indices[index * 4 + 0] = i0->second;
				indices[index * 4 + 1] = i1->second;
				indices[index * 4 + 2] = i2->second;
				indices[index * 4 + 3] = i3->second;
			}

			index++;

			if (index * 4 >= count) return;
		}
	}

	static void Transform(void* ptr, const Matrix4x4d& matrix)
	{
		auto poly = CastToPolyhedron(ptr);
		auto m = matrix.ToCGAL<K>();

		std::transform(poly->model.points_begin(), poly->model.points_end(), poly->model.points_begin(), m);
	}

	static void InsideOut(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.inside_out();
	}

	static void Triangulate(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		CGAL::Polygon_mesh_processing::triangulate_faces(poly->model);
	}

	static void NormalizeBorder(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		poly->model.normalize_border();
	}

	static BOOL NormalizedBorderIsValid(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return poly->model.normalized_border_is_valid();
	}

	static CGAL::Bounded_side SideOfTriangleMesh(void* ptr, const Point3d& point)
	{
		auto poly = CastToPolyhedron(ptr);
		CGAL::Side_of_triangle_mesh<Polyhedron, K> inside(poly->model);
		return inside(point.ToCGAL<K>());
	}

	static void Orient(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		CGAL::Polygon_mesh_processing::orient(poly->model);
	}

	static void OrientToBoundingVolume(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		CGAL::Polygon_mesh_processing::orient_to_bound_a_volume(poly->model);
	}

	static void ReverseFaceOrientations(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		CGAL::Polygon_mesh_processing::reverse_face_orientations(poly->model);
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

	static BOOL IsOutwardOriented(void* ptr)
	{
		auto poly = CastToPolyhedron(ptr);
		return CGAL::Polygon_mesh_processing::is_outward_oriented(poly->model);
	}

};
