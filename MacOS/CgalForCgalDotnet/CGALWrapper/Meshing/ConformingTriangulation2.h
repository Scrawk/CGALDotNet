#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"
#include "../Polygons/PolygonWithHoles2.h"

#include <map>
#include <CGAL/Constrained_Delaunay_triangulation_2.h>
#include <CGAL/Delaunay_mesher_2.h>
#include <CGAL/Delaunay_mesh_face_base_2.h>
#include <CGAL/Delaunay_mesh_size_criteria_2.h>
#include <CGAL/Triangulation_conformer_2.h>
#include <CGAL/Delaunay_mesh_face_base_2.h>
#include <CGAL/Delaunay_mesh_vertex_base_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>
#include <CGAL/lloyd_optimize_mesh_2.h>
#include <CGAL/Aff_transformation_2.h>

template<class K>
class ConformingTriangulation2
{

public:

	typedef CGAL::Delaunay_mesh_vertex_base_2<K>                Vb;
	typedef CGAL::Delaunay_mesh_face_base_2<K>                  Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb>        Tds;
	typedef CGAL::Constrained_Delaunay_triangulation_2<K, Tds>  CDT;
	typedef CGAL::Delaunay_mesh_size_criteria_2<CDT>            Criteria;
	typedef CGAL::Delaunay_mesher_2<CDT, Criteria>              Mesher;
	typedef typename CDT::Vertex_handle Vertex;
	typedef typename CDT::Point Point;

	typedef CGAL::Aff_transformation_2<K> Transformation_2;

	CDT model;

	ConformingTriangulation2()
	{

	}

	~ConformingTriangulation2()
	{

	}

	inline static ConformingTriangulation2* NewTriangulation2()
	{
		return new ConformingTriangulation2();
	}

	inline static void DeleteTriangulation2(void* ptr)
	{
		auto obj = static_cast<ConformingTriangulation2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static ConformingTriangulation2* CastToTriangulation2(void* ptr)
	{
		return static_cast<ConformingTriangulation2*>(ptr);
	}

	static void Clear(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->model.clear();
	}

	static void* Copy(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		auto copy = NewTriangulation2();
		copy->model = tri->model;
		return copy;
	}

	static int VertexCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return (int)tri->model.number_of_vertices();
	}

	static int FaceCount(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		return (int)tri->model.number_of_faces();
	}

	static void InsertPoint(void* ptr, Point2d point)
	{
		auto tri = CastToTriangulation2(ptr);
		tri->model.insert(point.ToCGAL<K>());
	}

	static void InsertPoints(void* ptr, Point2d* points, int count)
	{
		auto tri = CastToTriangulation2(ptr);

		std::vector<Point> list(count);
		for (int i = 0; i < count; i++)
			list[i] = points[i].ToCGAL<K>();

		tri->model.insert(list.begin(), list.end());
	}

	static void InsertPolygon(void* triPtr, void* polyPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto polygon = Polygon2<K>::CastToPolygon2(polyPtr);
		tri->model.insert(polygon->vertices_begin(), polygon->vertices_end());
	}

	static void InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
			tri->model.insert(pwh->outer_boundary().vertices_begin(), pwh->outer_boundary().vertices_end());

		for (auto& hole : pwh->holes())
			tri->model.insert(hole.vertices_begin(), hole.vertices_end());
	}

	static void GetPoints(void* ptr, Point2d* points, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int i = 0;

		for (auto vert = tri->model.finite_vertices_begin(); vert != tri->model.finite_vertices_end(); ++vert)
		{
			points[i++] = Point2d::FromCGAL<K>(vert->point());

			if (i >= count) return;
		}
			
	}

	static void GetIndices(void* ptr, int* indices, int count)
	{
		auto tri = CastToTriangulation2(ptr);
		int index = 0;

		std::map<Vertex, int> map;

		for (auto vert = tri->model.finite_vertices_begin(); vert != tri->model.finite_vertices_end(); ++vert)
		{
			map.insert(std::pair<Vertex, int>(vert, index++));
		}

		index = 0;
		for (auto face = tri->model.finite_faces_begin(); face != tri->model.finite_faces_end(); ++face)
		{
			auto i0 = map.find(face->vertex(0));
			auto i1 = map.find(face->vertex(1));
			auto i2 = map.find(face->vertex(2));

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

	static void Transform(void* ptr, Point2d translation, double rotation, double scale)
	{
		auto tri = CastToTriangulation2(ptr);

		Transformation_2 T(CGAL::TRANSLATION, translation.ToVector<K>());
		Transformation_2 R(CGAL::ROTATION, sin(rotation), cos(rotation));
		Transformation_2 S(CGAL::SCALING, scale);

		auto M = T * R * S;
		for (auto& vert : tri->model.finite_vertex_handles())
			vert->point() = M(vert->point());
	}

	static void InsertSegmentConstraint(void* ptr, Point2d a, Point2d b)
	{
		if (a == b) return;

		auto tri = CastToTriangulation2(ptr);
		tri->model.insert_constraint(a.ToCGAL<K>(), b.ToCGAL<K>());
	}

	static void InsertSegmentConstraints(void* ptr, Segment2d* segments, int count)
	{
		auto tri = CastToTriangulation2(ptr);

		for (int i = 0; i < count; i++)
		{
			if (segments[i].a == segments[i].b)
				continue;

			auto a = segments[i].a.ToCGAL<K>();
			auto b = segments[i].b.ToCGAL<K>();

			tri->model.insert_constraint(a, b);
		}

	}

	static void InsertPolygonConstraint(void* triPtr, void* polyPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto polygon = Polygon2<K>::CastToPolygon2(polyPtr);
		tri->model.insert_constraint(polygon->vertices_begin(), polygon->vertices_end(), true);
	}

	static void InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr)
	{
		auto tri = CastToTriangulation2(triPtr);

		auto pwh = PolygonWithHoles2<K>::CastToPolygonWithHoles2(pwhPtr);

		if (!pwh->is_unbounded())
			tri->model.insert_constraint(pwh->outer_boundary().vertices_begin(), pwh->outer_boundary().vertices_end(), true);

		for (auto& hole : pwh->holes())
			tri->model.insert_constraint(hole.vertices_begin(), hole.vertices_end(), true);
	}

	static void MakeConformingDelaunay(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		CGAL::make_conforming_Delaunay_2(tri->model);
	}

	static void MakeConformingGabriel(void* ptr)
	{
		auto tri = CastToTriangulation2(ptr);
		CGAL::make_conforming_Gabriel_2(tri->model);
	}

	void RefineAndOptimize(int iterations, double angleBounds, double lengthBounds, std::vector<Point>& seeds)
	{
		if (angleBounds > 0.125)
			angleBounds = 0.125;

		Mesher mesher(model);

		int numSeeds = (int)seeds.size();

		if (numSeeds > 0)
			mesher.set_seeds(seeds.begin(), seeds.end());

		mesher.set_criteria(Criteria(angleBounds, lengthBounds));
		mesher.refine_mesh();

		//auto code =  CGAL::lloyd_optimize_mesh_2(model);
	}

	static void RefineAndOptimize(void* ptr, int iterations, double angleBounds, double lengthBounds)
	{
		auto tri = CastToTriangulation2(ptr);
		std::vector<Point> points;
		tri->RefineAndOptimize(iterations, angleBounds, lengthBounds, points);
	}

	static void RefineAndOptimize(void* ptr, int iterations, double angleBounds, double lengthBounds, Point2d* seeds, int count)
	{
		auto tri = CastToTriangulation2(ptr);

		std::vector<Point> points;
		for (int i = 0; i < count; i++)
			points.push_back(seeds[i].ToCGAL<K>());

		tri->RefineAndOptimize(iterations, angleBounds, lengthBounds, points);
	}

};


