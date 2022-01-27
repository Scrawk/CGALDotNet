#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"
#include "../Polylines/Polyline3.h"

#include <CGAL/Polygon_mesh_processing/detect_features.h>

template<class K>
class PolygonMeshProcessingFeatures
{

public:

	typedef typename K::Point_3 Point;
	typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;
	

	typedef typename boost::graph_traits<Polyhedron>::edge_descriptor edge_descriptor;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor face_descriptor;
	

	inline static PolygonMeshProcessingFeatures* NewPolygonMeshProcessingFeatures()
	{
		return new PolygonMeshProcessingFeatures();
	}

	inline static void DeletePolygonMeshProcessingFeatures(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingFeatures*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingFeatures* CastToPolygonMeshProcessingFeatures(void* ptr)
	{
		return static_cast<PolygonMeshProcessingFeatures*>(ptr);
	}

	static int DetectSharpEdges_PH(void* feaPtr, void* polyPtr, double feature_angle)
	{
		auto fea = CastToPolygonMeshProcessingFeatures(feaPtr);
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);

		std::unordered_map<edge_descriptor, bool> map;

		CGAL::Polygon_mesh_processing::detect_sharp_edges(poly->model, feature_angle, boost::make_assoc_property_map(map));

		return (int)map.size();
	}

	static int SharpEdgesSegmentation_PH(void* feaPtr, void* polyPtr, double feature_angle)
	{
		return 0;
	}

};
