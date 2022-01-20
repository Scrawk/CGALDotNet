#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Polygon_mesh_processing/connected_components.h>
#include <CGAL/boost/graph/Face_filtered_graph.h>
#include <boost/property_map/property_map.hpp>
#include <boost/iterator/function_output_iterator.hpp>

template<class K>
class PolygonMeshProcessingConnections
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor Face_Des;
	typedef typename boost::graph_traits<Polyhedron>::faces_size_type Faces_Size;

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

	static void PolyhedronConnectedComponents(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		//std::vector<Face_Des> cc;
		//auto fd = *faces(poly->model).first;
		//auto num = CGAL::Polygon_mesh_processing::connected_component(fd, poly->model, std::back_inserter(cc));
		//std::cout << "Connected components without edge constraints" << std::endl;
		//std::cout << cc.size() << " faces in the CC of " << std::endl;
	}

	static int PolyhedronSplitConnectedComponents(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		std::vector<Polyhedron> list;
		CGAL::Polygon_mesh_processing::split_connected_components(poly->model, list);

		return (int)list.size();
	}

	static int PolyhedronKeepLargestConnectedComponents(void* polyPtr, int nb_components_to_keep)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		return CGAL::Polygon_mesh_processing::keep_largest_connected_components(poly->model, nb_components_to_keep);
	}

};
