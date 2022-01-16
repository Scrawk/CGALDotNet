#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"


template<class K>
class PolygonMeshProcessingNormals
{

public:

	typedef CGAL::Polyhedron_3<K> Polyhedron;

	inline static PolygonMeshProcessingNormals* NewPolygonMeshProcessingNormals()
	{
		return new PolygonMeshProcessingNormals();
	}

	inline static void DeletePolygonMeshProcessingNormals(void* ptr)
	{
		auto obj = static_cast<PolygonMeshProcessingNormals*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonMeshProcessingNormals* CastToPolygonMeshProcessingNormals(void* ptr)
	{
		return static_cast<PolygonMeshProcessingNormals*>(ptr);
	}


};
