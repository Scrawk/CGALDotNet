#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Polygon_mesh_processing/orientation.h>

template<class K>
class PolygonMeshProcessingOrientation
{

public:

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

	//Polyhedron

	static BOOL DoesBoundAVolume_PH(void* meshPtr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		return CGAL::Polygon_mesh_processing::does_bound_a_volume(mesh->model);
	}

	static BOOL IsOutwardOriented_PH(void* meshPtr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);;
		return CGAL::Polygon_mesh_processing::is_outward_oriented(mesh->model);
	}

	static void Orient_PH(void* meshPtr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		mesh->OnFaceNormalsChanged();
		return CGAL::Polygon_mesh_processing::orient(mesh->model);
	}

	static void OrientToBoundAVolume_PH(void* meshPtr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		mesh->OnFaceNormalsChanged();
		return CGAL::Polygon_mesh_processing::orient_to_bound_a_volume(mesh->model);
	}

	static void ReverseFaceOrientations_PH(void* meshPtr)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		mesh->OnFaceNormalsChanged();
		return CGAL::Polygon_mesh_processing::reverse_face_orientations(mesh->model);
	}

	//Surface Mesh

	static BOOL DoesBoundAVolume_SM(void* meshPtr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		return CGAL::Polygon_mesh_processing::does_bound_a_volume(mesh->model);
	}

	static BOOL IsOutwardOriented_SM(void* meshPtr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		return CGAL::Polygon_mesh_processing::is_outward_oriented(mesh->model);
	}

	static void Orient_SM(void* meshPtr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		mesh->OnFaceNormalsChanged();
		return CGAL::Polygon_mesh_processing::orient(mesh->model);
	}

	static void OrientToBoundAVolume_SM(void* meshPtr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		mesh->OnFaceNormalsChanged();
		return CGAL::Polygon_mesh_processing::orient_to_bound_a_volume(mesh->model);
	}

	static void ReverseFaceOrientations_SM(void* meshPtr)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		mesh->OnFaceNormalsChanged();
		return CGAL::Polygon_mesh_processing::reverse_face_orientations(mesh->model);
	}

};
