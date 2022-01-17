#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Polygon_mesh_processing/extrude.h>
#include <CGAL/Polygon_mesh_processing/fair.h>
#include <CGAL/Polygon_mesh_processing/refine.h>
#include <CGAL/Polygon_mesh_processing/remesh.h>
#include <CGAL/Polygon_mesh_processing/random_perturbation.h>
#include <CGAL/Polygon_mesh_processing/smooth_mesh.h>
#include <CGAL/Polygon_mesh_processing/smooth_shape.h>


template<class K>
class PolygonMeshProcessingMeshing
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::halfedge_descriptor        halfedge_descriptor;
	typedef typename boost::graph_traits<Polyhedron>::edge_descriptor            edge_descriptor;

	inline static PolygonMeshProcessingMeshing* NewPolygonMeshProcessingMeshing()
	{
		return new PolygonMeshProcessingMeshing();
	}

	inline static void DeletePolygonMeshProcessingMeshing(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingMeshing*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingMeshing* CastToPolygonMeshProcessingMeshing(void* ptr)
	{
		return static_cast<PolygonMeshProcessingMeshing*>(ptr);
	}

	struct halfedge2edge
	{
		halfedge2edge(const Polyhedron& m, std::vector<edge_descriptor>& edges)
			: m_mesh(m), m_edges(edges)
		{}
		void operator()(const halfedge_descriptor& h) const
		{
			m_edges.push_back(edge(h, m_mesh));
		}
		const Polyhedron& m_mesh;
		std::vector<edge_descriptor>& m_edges;
	};

	static void Extrude(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		
		//auto extruded = Polyhedron3<K>::NewPolyhedron();
		//CGAL::Polygon_mesh_processing::extrude_mesh(poly->model, extruded->model);
		//return extruded;
	}

	static BOOL Fair(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		BOOL successful = CGAL::Polygon_mesh_processing::fair(poly->model, vertices(poly->model));

		if(successful)
			poly->OnModelChanged();

		return successful;
	}

	static int Refine(void* polyPtr, double density_control_factor)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		std::vector<Polyhedron::Facet_handle>  new_facets;
		std::vector<Polyhedron::Vertex_handle> new_vertices;

		auto param = CGAL::parameters::density_control_factor(density_control_factor);

		CGAL::Polygon_mesh_processing::refine(poly->model, faces(poly->model),
			std::back_inserter(new_facets),
			std::back_inserter(new_vertices),
			param);

		poly->OnModelChanged();

		return (int)new_vertices.size();
	}

	static void IsotropicRemeshing(void* polyPtr, int iterations, double target_edge_length)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		std::vector<edge_descriptor> border;
		CGAL::Polygon_mesh_processing::border_halfedges(faces(poly->model), poly->model,
			boost::make_function_output_iterator(halfedge2edge(poly->model, border)));

		CGAL::Polygon_mesh_processing::split_long_edges(border, target_edge_length, poly->model);

		auto param = CGAL::Polygon_mesh_processing::parameters::number_of_iterations(iterations)
			.protect_constraints(true);

		CGAL::Polygon_mesh_processing::isotropic_remeshing(faces(poly->model), target_edge_length, poly->model, param);

		poly->OnModelChanged();
	}

	static void RandomPerturbation(void* polyPtr, double perturbation_max_size)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		CGAL::Polygon_mesh_processing::random_perturbation(vertices(poly->model), poly->model, perturbation_max_size);
		poly->OnModelChanged();
	}

	static void SmoothMesh(void* polyPtr)
	{
		/*
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		typedef boost::property_map<Polyhedron, CGAL::edge_is_feature_t>::type FeatureMap;
		FeatureMap map;

		CGAL::Polygon_mesh_processing::detect_sharp_edges(poly->model, featureAngle, map);

		auto param = CGAL::Polygon_mesh_processing::parameters::number_of_iterations(iterations).
			use_safety_constraints(false).
			edge_is_constrained_map(map);

		CGAL::Polygon_mesh_processing::smooth_mesh(faces(poly->model), poly->model, param);

		poly->OnModelChanged();
		*/
	}

	static void SmoothShape(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		/*
		std::set<Polyhedron::Vertex_handle> constrained_vertices;

		for (auto v : vertices(poly->model))
		{
			if (is_border(v, poly->model))
				constrained_vertices.insert(v);
		}

		CGAL::Boolean_property_map<std::set<Polyhedron::Vertex_handle> > map(constrained_vertices);

		auto param = CGAL::Polygon_mesh_processing::parameters::number_of_iterations(iterations)
			.vertex_is_constrained_map(map);

		CGAL::Polygon_mesh_processing::smooth_shape(poly->model, timeStep, param);

		poly->OnModelChanged();
		*/
	}


	static void SplitLongEdges(void* polyPtr, double target_edge_length)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		std::vector<edge_descriptor> border;
		CGAL::Polygon_mesh_processing::border_halfedges(faces(poly->model), poly->model,
			boost::make_function_output_iterator(halfedge2edge(poly->model, border)));

		CGAL::Polygon_mesh_processing::split_long_edges(border, target_edge_length, poly->model);
	}
};
