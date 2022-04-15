#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Heat_method_3/Surface_mesh_geodesic_distances_3.h>


template<class K>
class HeatMethod
{

public:

	typedef typename K::Point_3																Point3;
	typedef typename CGAL::Surface_mesh<Point3>												SurfaceMesh;
	typedef typename boost::graph_traits<SurfaceMesh>::vertex_descriptor					VertexDes;
	typedef typename CGAL::Heat_method_3::Surface_mesh_geodesic_distances_3<SurfaceMesh>	Heat_method;

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

	static int EstimateGeodesicDistances_SM(void* ptr, void* meshPtr, int vertexIndex)
	{
		auto method = CastToHeatMethod(ptr);
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);

		auto distMap = mesh->AddScalarPropertyMap("v:distance");
		Heat_method hm(mesh->model);

		auto source = mesh->FindVertex(vertexIndex);

		hm.add_source(source);
		hm.estimate_geodesic_distances(distMap);

		method->distances.clear();

		for (VertexDes vd : vertices(mesh->model))
		{
			double dist = get(distMap, vd);
			method->distances.push_back(dist);
		}

		mesh->ClearScalarPropertyMap("v:distance");

		return method->distances.size();
	}

};
