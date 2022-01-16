#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"


template<class K>
class PolygonMeshProcessingMeshing
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;

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


};
