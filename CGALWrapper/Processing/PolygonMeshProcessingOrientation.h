#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"


template<class K>
class PolygonMeshProcessingOrientation
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;

	inline static PolygonMeshProcessingOrientation* NewPolygonMeshProcessingOrientation()
	{
		return new PolygonMeshProcessingOrientation();
	}

	inline static void DeletePolygonMeshProcessingOrientation(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingOrientation*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingOrientation* CastToPolygonMeshProcessingOrientation(void* ptr)
	{
		return static_cast<PolygonMeshProcessingOrientation*>(ptr);
	}


};
