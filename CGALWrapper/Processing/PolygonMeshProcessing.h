#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"


template<class K>
class PolygonMeshProcessing
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;

	inline static PolygonMeshProcessing* NewPolygonMeshProcessing()
	{
		return new PolygonMeshProcessing();
	}

	inline static void DeletePolygonMeshProcessing(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessing*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessing* CastToPolygonMeshProcessing(void* ptr)
	{
		return static_cast<PolygonMeshProcessing*>(ptr);
	}


};
