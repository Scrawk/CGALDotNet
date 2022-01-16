#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"


template<class K>
class PolygonMeshProcessingRepair
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;

	inline static PolygonMeshProcessingRepair* NewPolygonMeshProcessingRepair()
	{
		return new PolygonMeshProcessingRepair();
	}

	inline static void DeletePolygonMeshProcessingRepair(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingRepair*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingRepair* CastToPolygonMeshProcessingRepair(void* ptr)
	{
		return static_cast<PolygonMeshProcessingRepair*>(ptr);
	}


};
