#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"


template<class K>
class PolygonMeshProcessingConnected
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;

	inline static PolygonMeshProcessingConnected* NewPolygonMeshProcessingConnected()
	{
		return new PolygonMeshProcessingConnected();
	}

	inline static void DeletePolygonMeshProcessingConnected(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingConnected*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingConnected* CastToPolygonMeshProcessingConnected(void* ptr)
	{
		return static_cast<PolygonMeshProcessingConnected*>(ptr);
	}


};
