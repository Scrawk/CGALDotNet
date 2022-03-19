#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>
#include <CGAL/Subdivision_method_3/subdivision_methods_3.h>

template<class K>
class SurfaceSubdivision
{

public:

	inline static SurfaceSubdivision* NewSurfaceSubdivision()
	{
		return new SurfaceSubdivision();
	}

	inline static void DeleteSurfaceSubdivision(void* ptr)
	{
		auto obj = static_cast<SurfaceSubdivision*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static SurfaceSubdivision* CastToSurfaceSubdivision(void* ptr)
	{
		return static_cast<SurfaceSubdivision*>(ptr);
	}

	//Polyhedron

	static void Subdive_CatmullClark_PH(void* meshPtr, int iterations)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::CatmullClark_subdivision(mesh->model, param);
		mesh->OnModelChanged();
	}

	static void Subdive_DooSabin_PH(void* meshPtr, int iterations)
	{
		//auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		//auto param = CGAL::parameters::number_of_iterations(iterations);
		//CGAL::Subdivision_method_3::DooSabin_subdivision(mesh->model, param);
		//mesh->OnModelChanged();
	}

	static void Subdive_Loop_PH(void* meshPtr, int iterations)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::Loop_subdivision(mesh->model, param);
		mesh->OnModelChanged();
	}

	static void Subdive_Sqrt3_PH(void* meshPtr, int iterations)
	{
		auto mesh = Polyhedron3<K>::CastToPolyhedron(meshPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::Sqrt3_subdivision(mesh->model, param);
		mesh->OnModelChanged();
	}

	//Surface mesh

	static void Subdive_CatmullClark_SM(void* meshPtr, int iterations)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::CatmullClark_subdivision(mesh->model, param);
		mesh->OnModelChanged();
	}

	static void Subdive_DooSabin_SM(void* meshPtr, int iterations)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::DooSabin_subdivision(mesh->model, param);
		mesh->OnModelChanged();
	}

	static void Subdive_Loop_SM(void* meshPtr, int iterations)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::Loop_subdivision(mesh->model, param);
		mesh->OnModelChanged();
	}

	static void Subdive_Sqrt3_SM(void* meshPtr, int iterations)
	{
		auto mesh = SurfaceMesh3<K>::CastToSurfaceMesh(meshPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::Sqrt3_subdivision(mesh->model, param);
		mesh->OnModelChanged();
	}

};
