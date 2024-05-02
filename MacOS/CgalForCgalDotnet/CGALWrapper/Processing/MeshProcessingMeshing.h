#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"
#include "../Geometry/Index.h"
#include "../Geometry/Geometry3.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>
#include <CGAL/Polygon_mesh_processing/extrude.h>
#include <CGAL/Polygon_mesh_processing/fair.h>
#include <CGAL/Polygon_mesh_processing/refine.h>
#include <CGAL/Polygon_mesh_processing/remesh.h>
#include <CGAL/Polygon_mesh_processing/random_perturbation.h>
#include <CGAL/Polygon_mesh_processing/smooth_mesh.h>
#include <CGAL/Polygon_mesh_processing/smooth_shape.h>
#include <CGAL/Polygon_mesh_processing/detect_features.h>
#include <CGAL/Polygon_mesh_processing/triangulate_faces.h>

template<class K>
class MeshProcessingMeshing
{

public:

	typedef typename K::Point_3 Point_3;
	typedef typename K::Vector_3 Vector_3;

	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::edge_descriptor PEdge_Des;
	typedef typename boost::graph_traits<Polyhedron>::halfedge_descriptor PHalfedge_Des;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor PFace_Des;
	typedef typename Polyhedron::Vertex_handle PVertex_Handle;

	typedef typename CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Face_index SFace;
	typedef typename boost::graph_traits<SurfaceMesh>::edge_descriptor SEdge_Des;
	typedef typename boost::graph_traits<SurfaceMesh>::halfedge_descriptor SHalfedge_Des;
	typedef typename boost::graph_traits<SurfaceMesh>::face_descriptor SFace_Des;
	typedef typename SurfaceMesh::Vertex_index SVertex_Index;

	inline static MeshProcessingMeshing* NewMeshProcessingMeshing()
	{
		return new MeshProcessingMeshing();
	}

	inline static void DeleteMeshProcessingMeshing(void* ptr)
	{
		auto obj = static_cast<MeshProcessingMeshing*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static MeshProcessingMeshing* CastToMeshProcessingMeshing(void* ptr)
	{
		return static_cast<MeshProcessingMeshing*>(ptr);
	}

	//Polyhedron

	struct HalfedgeToEdge_PM
	{
		HalfedgeToEdge_PM(const Polyhedron& m, std::vector<PEdge_Des>& edges)
			: m_mesh(m), m_edges(edges)
		{}

		void operator()(const PHalfedge_Des& h) const
		{
			m_edges.push_back(edge(h, m_mesh));
		}

		const Polyhedron& m_mesh;
		std::vector<PEdge_Des>& m_edges;
	};

	// extract vertices which are at most k (inclusive)
	// far from vertex v in the graph of edges
	static void ExtractKRing_PH(PVertex_Handle v, int k, std::vector<PVertex_Handle>& qv)
	{
		std::map<PVertex_Handle, int>  D;
		qv.push_back(v);
		D[v] = 0;
		std::size_t current_index = 0;
		int dist_v;
		while (current_index < qv.size() && (dist_v = D[qv[current_index]]) < k)
		{
			v = qv[current_index++];
			auto e(v->vertex_begin()), e_end(e);

			do 
			{
				PVertex_Handle new_v = e->opposite()->vertex();

				if (D.insert(std::make_pair(new_v, dist_v + 1)).second)
					qv.push_back(new_v);
			} 
			while (++e != e_end);
		}
	}

	static void* Extrude_PH(void* meshPtr, Vector3d dir)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		
		auto extruded = Polyhedron3<K>::NewPolyhedron();
		CGAL::Polygon_mesh_processing::extrude_mesh(mesh->model, extruded->model, dir.ToCGAL<K>());

		return extruded;
	}

	static Index2 Fair_PH(void* meshPtr, int index, int k_ring)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		int count = (int)mesh->model.size_of_facets();
		if (k_ring <= 0 || index < 0 || index >= count)
			return { FALSE, 0 };

		auto v = mesh->model.vertices_begin();
		std::advance(v, index);
		std::vector<PVertex_Handle> region;

		ExtractKRing_PH(v, k_ring, region);

		//If whole mesh is select result will be degenerate.
		//All vertices will collapse to origin.
		if(region.size() >= (int)mesh->model.size_of_vertices())
			return { FALSE, (int)region.size() };

		BOOL successful = CGAL::Polygon_mesh_processing::fair(mesh->model, region);

		if(successful)
			mesh->OnModelChanged();

		return { successful, (int)region.size() };
	}

	static Index2 Refine_PH(void* meshPtr, double density_control_factor)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

        std::vector<typename Polyhedron::Facet_handle>  new_facets;
        std::vector<typename Polyhedron::Vertex_handle> new_vertices;

		auto param = CGAL::parameters::density_control_factor(density_control_factor);

		CGAL::Polygon_mesh_processing::refine(mesh->model, faces(mesh->model),
			std::back_inserter(new_facets),
			std::back_inserter(new_vertices),
			param);

		mesh->OnModelChanged();

		return { (int)new_vertices.size(), (int)new_facets.size() };
	}

	static int IsotropicRemeshing_PH(void* meshPtr, int iterations, double target_edge_length)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		int count_before = (int)mesh->model.size_of_vertices();

		std::vector<PEdge_Des> border;
		auto it = boost::make_function_output_iterator(HalfedgeToEdge_PM(mesh->model, border));
		CGAL::Polygon_mesh_processing::border_halfedges(faces(mesh->model), mesh->model, it);
		CGAL::Polygon_mesh_processing::split_long_edges(border, target_edge_length, mesh->model);

		auto param = CGAL::Polygon_mesh_processing::parameters::
			number_of_iterations(iterations)
			.protect_constraints(true);

		CGAL::Polygon_mesh_processing::isotropic_remeshing(faces(mesh->model), target_edge_length, mesh->model, param);

		mesh->OnModelChanged();

		return (int)mesh->model.size_of_vertices() - count_before;
	}

	static void RandomPerturbation_PH(void* meshPtr, double perturbation_max_size)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		CGAL::Polygon_mesh_processing::random_perturbation(vertices(mesh->model), mesh->model, perturbation_max_size);
		mesh->OnModelChanged();
	}

	static void SmoothMesh_PH(void* meshPtr, double featureAngle, int iterations)
	{
		/*
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		typedef boost::property_map<Polyhedron, CGAL::edge_is_feature_t>::type FeatureMap;
		FeatureMap map = get(CGAL::edge_is_feature, mesh->model);

		CGAL::Polygon_mesh_processing::detect_sharp_edges(mesh->model, featureAngle, map);

		auto param = CGAL::Polygon_mesh_processing::parameters::number_of_iterations(iterations).
			use_safety_constraints(false).
			edge_is_constrained_map(map);

		CGAL::Polygon_mesh_processing::smooth_mesh(faces(mesh->model), mesh->model, param);

		mesh->OnModelChanged();
		*/
	}

	static void SmoothShape_PH(void* meshPtr, double timeStep, int iterations)
	{
		/*
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		std::set<Polyhedron::Vertex_handle> constrained_vertices;

		for (auto v : vertices(mesh->model))
		{
			if (is_border(v, mesh->model))
				constrained_vertices.insert(v);
		}

		CGAL::Boolean_property_map<std::set<Polyhedron::Vertex_handle> > map(constrained_vertices);

		auto param = CGAL::Polygon_mesh_processing::parameters::
			number_of_iterations(iterations)
			.vertex_is_constrained_map(map);

		CGAL::Polygon_mesh_processing::smooth_shape(mesh->model, timeStep, param);

		mesh->OnModelChanged();
		*/
	}

	static int SplitLongEdges_PH(void* meshPtr, double target_edge_length)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		int count_before = (int)mesh->model.size_of_halfedges();

		//std::vector<PEdge_Des> border;
		//CGAL::Polygon_mesh_processing::border_halfedges(faces(mesh->model), mesh->model,
		//	boost::make_function_output_iterator(HalfedgeToEdge_PM(mesh->model, border)));
		//CGAL::Polygon_mesh_processing::split_long_edges(border, target_edge_length, mesh->model);

		CGAL::Polygon_mesh_processing::split_long_edges(edges(mesh->model), target_edge_length, mesh->model);

		return (int)mesh->model.size_of_halfedges() - count_before;
	}

	static BOOL TriangulateFace_PH(void* meshPtr, int index)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		auto face = mesh->FindFaceIter(index);

		if (face != nullptr)
		{
			std::vector<PFace_Des> faces;
			faces.push_back(*face);
			return CGAL::Polygon_mesh_processing::triangulate_faces(faces, mesh->model);
		}
		else
		{
			return FALSE;
		}

	}

	static BOOL TriangulateFaces_PH(void* meshPtr, int* faces, int count)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		std::vector<PFace_Des> _faces;
		for (int i = 0; i < count; i++)
		{
			auto face = mesh->FindFaceIter(faces[i]);
			if (face != nullptr)
				_faces.push_back(*face);
		}

		if (_faces.size() == 0)
			return FALSE;

		return CGAL::Polygon_mesh_processing::triangulate_faces(_faces, mesh->model);
	}

	//Surface Mesh

	struct HalfedgeToEdge_SM
	{
		HalfedgeToEdge_SM(const SurfaceMesh& m, std::vector<SEdge_Des>& edges)
			: m_mesh(m), m_edges(edges)
		{}

		void operator()(const SHalfedge_Des& h) const
		{
			m_edges.push_back(edge(h, m_mesh));
		}

		const SurfaceMesh& m_mesh;
		std::vector<SEdge_Des>& m_edges;
	};

	// extract vertices which are at most k (inclusive)
	// far from vertex v in the graph of edges
	static void ExtractKRing_SM(SVertex_Index v, int k, std::vector<SVertex_Index>& qv)
	{
		std::map<SVertex_Index, int>  D;
		qv.push_back(v);
		/*
		D[v] = 0;
		std::size_t current_index = 0;
		int dist_v;
		while (current_index < qv.size() && (dist_v = D[qv[current_index]]) < k)
		{
			v = qv[current_index++];
			auto e(v->vertex_begin()), e_end(e);

			do
			{
				PVertex_Handle new_v = e->opposite()->vertex();

				if (D.insert(std::make_pair(new_v, dist_v + 1)).second)
					qv.push_back(new_v);
			} while (++e != e_end);
		}
		*/
	}

	static void* Extrude_SM(void* meshPtr, Vector3d dir)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		auto extruded = SurfaceMesh3<K>::NewSurfaceMesh();
		CGAL::Polygon_mesh_processing::extrude_mesh(mesh->model, extruded->model, dir.ToCGAL<K>());

		return extruded;
	}

	static Index2 Fair_SM(void* meshPtr, int index, int k_ring)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		int count = (int)mesh->model.number_of_faces();
		if (k_ring <= 0 || index < 0 || index >= count)
			return { FALSE, 0 };

		std::vector<SVertex_Index> region;
		ExtractKRing_SM(SVertex_Index(index), k_ring, region);

		//If whole mesh is select result will be degenerate.
		//All vertices will collapse to origin.
		if (region.size() >= (int)mesh->model.number_of_vertices())
			return { FALSE, (int)region.size() };

		BOOL successful = CGAL::Polygon_mesh_processing::fair(mesh->model, region);

		if (successful)
			mesh->OnModelChanged();

		return { successful, (int)region.size() };
	}

	static Index2 Refine_SM(void* meshPtr, double density_control_factor)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

        std::vector<typename SurfaceMesh::Face_index>  new_facets;
        std::vector<typename SurfaceMesh::Vertex_index> new_vertices;

		auto param = CGAL::parameters::density_control_factor(density_control_factor);

		CGAL::Polygon_mesh_processing::refine(mesh->model, faces(mesh->model),
			std::back_inserter(new_facets),
			std::back_inserter(new_vertices),
			param);

		mesh->OnModelChanged();

		return { (int)new_vertices.size(), (int)new_facets.size() };
	}

	static int IsotropicRemeshing_SM(void* meshPtr, int iterations, double target_edge_length)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		int count_before = (int)mesh->model.number_of_vertices();

		std::vector<SEdge_Des> border;
		auto it = boost::make_function_output_iterator(HalfedgeToEdge_SM(mesh->model, border));
		CGAL::Polygon_mesh_processing::border_halfedges(faces(mesh->model), mesh->model, it);
		CGAL::Polygon_mesh_processing::split_long_edges(border, target_edge_length, mesh->model);

		auto param = CGAL::Polygon_mesh_processing::parameters::
			number_of_iterations(iterations)
			.protect_constraints(true);

		CGAL::Polygon_mesh_processing::isotropic_remeshing(faces(mesh->model), target_edge_length, mesh->model, param);

		mesh->OnModelChanged();

		return (int)mesh->model.number_of_vertices() - count_before;
	}

	static void RandomPerturbation_SM(void* meshPtr, double perturbation_max_size)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		CGAL::Polygon_mesh_processing::random_perturbation(vertices(mesh->model), mesh->model, perturbation_max_size);
		mesh->OnModelChanged();
		
	}

	static void SmoothMesh_SM(void* meshPtr, double featureAngle, int iterations)
	{
		
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

        typedef typename boost::property_map<SurfaceMesh, CGAL::edge_is_feature_t>::type FeatureMap;
		FeatureMap map = get(CGAL::edge_is_feature, mesh->model);

		CGAL::Polygon_mesh_processing::detect_sharp_edges(mesh->model, featureAngle, map);

		auto param = CGAL::Polygon_mesh_processing::parameters::
			number_of_iterations(iterations).
			use_safety_constraints(false).
			edge_is_constrained_map(map);

		CGAL::Polygon_mesh_processing::smooth_mesh(faces(mesh->model), mesh->model, param);

		mesh->OnModelChanged();
	}

	static void SmoothShape_SM(void* meshPtr, double timeStep, int iterations)
	{
		/*
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		std::set<SVertex_Index> constrained_vertices;

		for (auto v : vertices(mesh->model))
		{
			if (is_border(v, mesh->model))
				constrained_vertices.insert(v);
		}

		CGAL::Boolean_property_map<std::set<SVertex_Index>> map(constrained_vertices);

		auto param = CGAL::Polygon_mesh_processing::parameters::
			number_of_iterations(iterations)
			.vertex_is_constrained_map(map);

		CGAL::Polygon_mesh_processing::smooth_shape(mesh->model, timeStep, param);

		mesh->OnModelChanged();
		*/
	}

	static int SplitLongEdges_SM(void* meshPtr, double target_edge_length)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		int count_before = (int)mesh->model.number_of_halfedges();

		//std::vector<SEdge_Des> border;
		//auto it = boost::make_function_output_iterator(HalfedgeToEdge_SM(mesh->model, border));
		//CGAL::Polygon_mesh_processing::border_halfedges(faces(mesh->model), mesh->model, it);
		//CGAL::Polygon_mesh_processing::split_long_edges(border, target_edge_length, mesh->model);

		CGAL::Polygon_mesh_processing::split_long_edges(edges(mesh->model),  target_edge_length, mesh->model);

		return (int)mesh->model.number_of_halfedges() - count_before;
	}

	static BOOL TriangulateFace_SM(void* meshPtr, int index)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		auto face = mesh->FindFace(index);

		if (face != SurfaceMesh3<K>::NullFace())
		{
			std::vector<SFace> faces;
			faces.push_back(face);
			return CGAL::Polygon_mesh_processing::triangulate_faces(faces, mesh->model);
		}
		else
		{
			return FALSE;
		}

	}

	static BOOL TriangulateFaces_SM(void* meshPtr, int* faces, int count)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		std::vector<SFace> _faces;
		for (int i = 0; i < count; i++)
		{
			auto face = mesh->FindFace(faces[i]);
			if (face != SurfaceMesh3<K>::NullFace())
				_faces.push_back(face);
		}

		if (_faces.size() == 0)
			return FALSE;

		return CGAL::Polygon_mesh_processing::triangulate_faces(_faces, mesh->model);
	}
};
