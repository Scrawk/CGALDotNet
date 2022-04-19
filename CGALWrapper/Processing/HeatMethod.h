#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <boost/unordered_map.hpp>
#include <CGAL/Heat_method_3/Surface_mesh_geodesic_distances_3.h>


template<class K>
class HeatMethod
{

public:

	typedef typename K::Point_3 Point3;
	
	typedef typename CGAL::Surface_mesh<Point3>																						SurfaceMesh;
	typedef typename boost::graph_traits<SurfaceMesh>::vertex_descriptor															SVertexDes;
	typedef typename CGAL::Heat_method_3::Surface_mesh_geodesic_distances_3<SurfaceMesh, CGAL::Heat_method_3::Intrinsic_Delaunay>   SHeat_method_idt;
	typedef typename CGAL::Heat_method_3::Surface_mesh_geodesic_distances_3<SurfaceMesh, CGAL::Heat_method_3::Direct>				SHeat_method;

	typedef typename CGAL::Polyhedron_3<K>																							Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::vertex_descriptor																PVertexDes;
	typedef typename CGAL::Heat_method_3::Surface_mesh_geodesic_distances_3<Polyhedron, CGAL::Heat_method_3::Intrinsic_Delaunay>    PHeat_method_idt;
	typedef typename CGAL::Heat_method_3::Surface_mesh_geodesic_distances_3<Polyhedron, CGAL::Heat_method_3::Direct>				PHeat_method;

	std::vector<double> distances;

	inline static HeatMethod* NewHeatMethod()
	{
		return new HeatMethod();
	}

	inline static void DeleteHeatMethod(void* ptr)
	{
		auto obj = static_cast<HeatMethod*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static HeatMethod* CastToHeatMethod(void* ptr)
	{
		return static_cast<HeatMethod*>(ptr);
	}

	static double GetDistance(void* ptr, int index)
	{
		auto method = CastToHeatMethod(ptr);
		return method->distances[index];
	}

	static void ClearDistances(void* ptr)
	{
		auto method = CastToHeatMethod(ptr);
		method->distances.clear();
	}

	static int EstimateGeodesicDistances_SM(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT)
	{
		auto method = CastToHeatMethod(ptr);
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		auto distMap = mesh->AddScalarPropertyMap("v:distance");
		auto source = mesh->FindVertex(vertexIndex);

		if (useIDT)
		{
			SHeat_method_idt hm(mesh->model);
			hm.add_source(source);
			hm.estimate_geodesic_distances(distMap);
		}
		else
		{
			SHeat_method hm(mesh->model);
			hm.add_source(source);
			hm.estimate_geodesic_distances(distMap);
		}

		method->distances.clear();

		for (auto vd : vertices(mesh->model))
		{
			double dist = get(distMap, vd);
			method->distances.push_back(dist);
		}

		mesh->ClearScalarPropertyMap("v:distance");

		return (int)method->distances.size();
	}
	
	static int EstimateGeodesicDistances_PH(void* ptr, void* meshPtr, int vertexIndex, BOOL useIDT)
	{
		auto method = CastToHeatMethod(ptr);
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);

		boost::unordered_map<PVertexDes, double> distMap;
		auto source = mesh->FindVertex(vertexIndex);

		//if (useIDT)
		//{
			CGAL::Heat_method_3::estimate_geodesic_distances(mesh->model,
				boost::make_assoc_property_map(distMap),
				source);

		//}
		//else
		//{
		//	CGAL::Heat_method_3::estimate_geodesic_distances(mesh->model,
		//		boost::make_assoc_property_map(distMap),
		//		source);
		//}

		method->distances.clear();

		for (auto vd : vertices(mesh->model))
		{
			double dist = distMap[vd];
			method->distances.push_back(dist);
		}

		return (int)method->distances.size();
	}
	

};
