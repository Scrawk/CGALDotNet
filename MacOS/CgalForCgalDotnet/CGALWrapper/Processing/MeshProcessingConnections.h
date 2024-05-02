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
class MeshProcessingConnections
{

public:

	typedef typename K::Point_3 Point_3;

	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor PFace_Des;
	typedef typename boost::graph_traits<Polyhedron>::faces_size_type PFaces_Size;

	typedef typename CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Face_index SFace;
	typedef typename boost::graph_traits<SurfaceMesh>::face_descriptor SFace_Des;
	typedef typename boost::graph_traits<SurfaceMesh>::faces_size_type SFaces_Size;

	//CGAL::Polygon_mesh_processing::parameters::all_default()
	
	std::vector<Polyhedron> polyhedron_buffer;

	std::vector<SurfaceMesh> surface_mesh_buffer;

	std::vector<PFace_Des> polyhedron_face_buffer;

	std::vector<SFace_Des> surface_face_buffer;

public:

	inline static MeshProcessingConnections* NewMeshProcessingConnections()
	{
		return new MeshProcessingConnections();
	}

	inline static void DeleteMeshProcessingConnections(void* ptr)
	{
		auto obj = static_cast<MeshProcessingConnections*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static MeshProcessingConnections* CastToMeshProcessingConnections(void* ptr)
	{
		return static_cast<MeshProcessingConnections*>(ptr);
	}

	//Polyhedron

	static int ConnectedComponents_PH(void* meshPtr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		//auto fccmap = mesh->model.add_property_map<PFace_Des, std::size_t>("f:CC").first;
		//std::size_t num = CGAL::Polygon_mesh_processing::connected_components(mesh->model, fccmap);

		return 0;
	}

	static int ConnectedComponent_PH(void* ptr, void* meshPtr, int index)
	{
		auto con = CastToMeshProcessingConnections(ptr);
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		auto face = mesh->FindFaceIter(index);
		if (face != nullptr)
		{
			con->polyhedron_face_buffer.clear();
			auto ins = std::back_inserter(con->polyhedron_face_buffer);
			CGAL::Polygon_mesh_processing::connected_component(*face, mesh->model, ins);

			return (int)con->polyhedron_face_buffer.size();
		}
		else
			return 0;
	}

	static void GetConnectedComponentFaceIndex_PH(void* ptr, void* meshPtr, int* indices, int count)
	{
		auto con = CastToMeshProcessingConnections(ptr);
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		int size = (int)con->polyhedron_face_buffer.size();

		for (int i = 0; i < count; i++)
		{
			auto face = con->polyhedron_face_buffer[i];
			int index = mesh->FindFaceIndex(face);
			indices[i] = index;
			
			if (i >= size) break;
		}

		con->polyhedron_face_buffer.clear();
	}

	static int SplitConnectedComponents_PH(void* ptr, void* meshPtr)
	{
		auto con = CastToMeshProcessingConnections(ptr);
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		con->polyhedron_buffer.clear();
		CGAL::Polygon_mesh_processing::split_connected_components(mesh->model, con->polyhedron_buffer);

		return (int)con->polyhedron_buffer.size();
	}

	static void GetSplitConnectedComponents_PH(void* ptr, void** meshPtrs, int count)
	{
		auto con = CastToMeshProcessingConnections(ptr);
		int size = (int)con->polyhedron_buffer.size();

		for (int i = 0; i < count; i++)
		{
			auto mesh = Polyhedron3<K>::NewPolyhedron();
			mesh->model = con->polyhedron_buffer[i];
			meshPtrs[i] = mesh;

			if (i >= size) break;
		}

		con->polyhedron_buffer.clear();
	}

	static int KeepLargeConnectedComponents_PH(void* meshPtr, int threshold_value)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		return (int)CGAL::Polygon_mesh_processing::keep_large_connected_components(mesh->model, threshold_value);
	}

	static int KeepLargestConnectedComponents_PH(void* meshPtr, int nb_components_to_keep)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		return (int)CGAL::Polygon_mesh_processing::keep_largest_connected_components(mesh->model, nb_components_to_keep);;
	}

	//Surface Mesh

	static int ConnectedComponents_SM(void* meshPtr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		//auto pair = mesh->model.property_map<SFace_Des, std::size_t>("f:CC");
		//auto map = pair.first;

        auto map = mesh->model.template add_property_map<SFace_Des, std::size_t>("f:CC").first;
		auto num = CGAL::Polygon_mesh_processing::connected_components(mesh->model, map);
		mesh->model.remove_property_map(map);
		
		return (int)num;
	}

	static int ConnectedComponent_SM(void* ptr, void* meshPtr, int index)
	{
		auto con = CastToMeshProcessingConnections(ptr);
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		auto face = mesh->FindFace(index);
		if (face != SurfaceMesh3<K>::NullFace())
		{
			con->surface_face_buffer.clear();
			auto ins = std::back_inserter(con->surface_face_buffer);
			CGAL::Polygon_mesh_processing::connected_component(face, mesh->model, ins);

			return (int)con->surface_face_buffer.size();
		}
		else
			return 0;
	}

	static void GetConnectedComponentFaceIndex_SM(void* ptr, void* meshPtr, int* indices, int count)
	{
		auto con = CastToMeshProcessingConnections(ptr);
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		int size = (int)con->surface_face_buffer.size();

		for (int i = 0; i < count; i++)
		{
			auto face = con->surface_face_buffer[i];
			indices[i] = face;

			if (i >= size) break;
		}

		con->surface_face_buffer.clear();
	}

	static int SplitConnectedComponents_SM(void* ptr, void* meshPtr)
	{
		auto con = CastToMeshProcessingConnections(ptr);
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		con->surface_mesh_buffer.clear();
		CGAL::Polygon_mesh_processing::split_connected_components(mesh->model, con->surface_mesh_buffer);

		return (int)con->surface_mesh_buffer.size();
	}

	static void GetSplitConnectedComponents_SM(void* ptr, void** meshPtrs, int count)
	{
		auto con = CastToMeshProcessingConnections(ptr);
		int size = (int)con->surface_mesh_buffer.size();

		for (int i = 0; i < count; i++)
		{
			auto mesh = SurfaceMesh3<K>::NewSurfaceMesh();
			mesh->model = con->surface_mesh_buffer[i];
			meshPtrs[i] = mesh;

			if (i >= size) break;
		}

		con->surface_mesh_buffer.clear();
	}

	static int KeepLargeConnectedComponents_SM(void* meshPtr, int threshold_value)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		mesh->OnModelChanged();
		return (int)CGAL::Polygon_mesh_processing::keep_large_connected_components(mesh->model, threshold_value);
	}

	static int KeepLargestConnectedComponents_SM(void* meshPtr, int nb_components_to_keep)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		mesh->OnModelChanged();
		return (int)CGAL::Polygon_mesh_processing::keep_largest_connected_components(mesh->model, nb_components_to_keep);
	}

};
