#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Polygon_mesh_processing/orientation.h>

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

	static BOOL DoesBoundAVolume(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		poly->OnModelChanged();
		return CGAL::Polygon_mesh_processing::does_bound_a_volume(poly->model);
	}

	static BOOL IsOutwardOriented(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		poly->OnModelChanged();
		return CGAL::Polygon_mesh_processing::is_outward_oriented(poly->model);
	}

	static void Orient(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		poly->OnModelChanged();
		return CGAL::Polygon_mesh_processing::orient(poly->model);
	}

	static void OrientToBoundAVolume(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		poly->OnModelChanged();
		return CGAL::Polygon_mesh_processing::orient_to_bound_a_volume(poly->model);
	}

	static void ReverseFaceOrientations(void* polyPtr)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		poly->OnModelChanged();
		return CGAL::Polygon_mesh_processing::reverse_face_orientations(poly->model);
	}


};
