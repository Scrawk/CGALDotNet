#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <vector>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>
#include <CGAL/Surface_mesh.h>
#include <CGAL/Polygon_mesh_processing/connected_components.h>
#include <CGAL/boost/graph/Face_filtered_graph.h>
#include <boost/property_map/property_map.hpp>
#include <boost/iterator/function_output_iterator.hpp>

template<class K>
class PolygonMeshProcessingConnections
{

public:

	typedef typename K::Point_3 Point_3;

	typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor PFace_Des;
	typedef typename boost::graph_traits<Polyhedron>::faces_size_type PFaces_Size;

	typedef typename CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Face_index SFace;
	typedef typename boost::graph_traits<SurfaceMesh>::face_descriptor SFace_Des;
	typedef typename boost::graph_traits<SurfaceMesh>::faces_size_type SFaces_Size;
	
	std::vector<Polyhedron> polyhedron_buffer;

	std::vector<SurfaceMesh> surface_mesh_buffer;

public:

	inline static PolygonMeshProcessingConnections* NewPolygonMeshProcessingConnections()
	{
		return new PolygonMeshProcessingConnections();
	}

	inline static void DeletePolygonMeshProcessingConnections(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingConnections*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingConnections* CastToPolygonMeshProcessingConnections(void* ptr)
	{
		return static_cast<PolygonMeshProcessingConnections*>(ptr);
	}

	//Polyhedron

	static int ConnectedComponents_PH(void* meshPtr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		//auto fccmap = mesh->model.add_property_map<PFace_Des, std::size_t>("f:CC").first;
		//std::size_t num = CGAL::Polygon_mesh_processing::connected_components(mesh->model, fccmap);

		return 0;
	}

	static int ConnectedComponent_PH(void* meshPtr, int index)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		//std::vector<PFace_Des> cc;
		//TODO - add get face
		//CGAL::Polygon_mesh_processing::connected_component(fd, mesh->model, std::back_inserter(cc));

		return 0;
	}

	static int SplitConnectedComponents_PH(void* ptr, void* meshPtr)
	{
		auto con = CastToPolygonMeshProcessingConnections(ptr);
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		con->polyhedron_buffer.clear();
		CGAL::Polygon_mesh_processing::split_connected_components(mesh->model, con->polyhedron_buffer);

		return (int)con->polyhedron_buffer.size();
	}

	static void GetSplitConnectedComponents_PH(void* ptr, void** meshPtrs, int count)
	{
		auto con = CastToPolygonMeshProcessingConnections(ptr);

		int size = (int)con->polyhedron_buffer.size();
		if (size == 0) return;

		for (int i = 0; i < count; i++)
		{
			auto mesh = Polyhedron3<K>::NewPolyhedron();
			mesh->model = con->polyhedron_buffer[i];
			meshPtrs[i] = mesh;

			if (i >= size) break;
		}

		con->polyhedron_buffer.clear();
	}

	static int KeepLargestConnectedComponents_PH(void* meshPtr, int nb_components_to_keep)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		return (int)CGAL::Polygon_mesh_processing::keep_largest_connected_components(mesh->model, nb_components_to_keep);;
	}

	//Surface Mesh

	static int ConnectedComponents_SM(void* meshPtr)
	{
		auto mesh = SurfaceMesh3<EEK>::CastToSurfaceMesh(meshPtr);

		auto map = mesh->model.add_property_map<SFace_Des, std::size_t>("f:CC").first;
		auto num = CGAL::Polygon_mesh_processing::connected_components(mesh->model, map);

		//auto key = mesh->model.property_map<SFace_Des, std::size_t>("f:CC");
		//mesh->model.remove_property_map(key.first);
		
		return (int)num;
	}

	static int ConnectedComponent_SM(void* meshPtr, int index)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		SFace face = mesh->FindFace(index);
		if (face != SurfaceMesh3<K>::NullFace())
		{
			std::vector<SFace_Des> cc;
			CGAL::Polygon_mesh_processing::connected_component(face, mesh->model, std::back_inserter(cc));

			return (int)cc.size();
		}

		return 0;
	}

	static int SplitConnectedComponents_SM(void* ptr, void* meshPtr)
	{
		auto con = CastToPolygonMeshProcessingConnections(ptr);
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		con->surface_mesh_buffer.clear();
		CGAL::Polygon_mesh_processing::split_connected_components(mesh->model, con->surface_mesh_buffer);

		return (int)con->surface_mesh_buffer.size();
	}

	static void GetSplitConnectedComponents_SM(void* ptr, void** meshPtrs, int count)
	{
		auto con = CastToPolygonMeshProcessingConnections(ptr);

		int size = (int)con->surface_mesh_buffer.size();
		if (size == 0) return;

		for (int i = 0; i < count; i++)
		{
			auto mesh = SurfaceMesh3<K>::NewSurfaceMesh();
			mesh->model = con->surface_mesh_buffer[i];
			meshPtrs[i] = mesh;

			if (i >= size) break;
		}

		con->surface_mesh_buffer.clear();
	}

	static int KeepLargestConnectedComponents_SM(void* meshPtr, int nb_components_to_keep)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		return (int)CGAL::Polygon_mesh_processing::keep_largest_connected_components(mesh->model, nb_components_to_keep);
	}

};
