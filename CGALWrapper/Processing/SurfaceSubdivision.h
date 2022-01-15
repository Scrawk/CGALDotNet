#pragma once

#include "../CGALWrapper.h"
#include "../Polyhedra/Polyhedron3.h"
#include "../Polyhedra/SurfaceMesh3.h"

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

	static void SubdivePolyhedron_CatmullClark(void* polyPtr, int iterations)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::CatmullClark_subdivision(poly->model, param);
	}

	static void SubdivePolyhedron_DooSabin(void* polyPtr, int iterations)
	{
		//auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		//auto param = CGAL::parameters::number_of_iterations(iterations);
		//CGAL::Subdivision_method_3::DooSabin_subdivision(poly->model, param);
	}


	static void SubdivePolyhedron_Loop(void* polyPtr, int iterations)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::Loop_subdivision(poly->model, param);
	}

	static void SubdivePolyhedron_Sqrt3(void* polyPtr, int iterations)
	{
		auto poly = Polyhedron3<K>::CastToPolyhedron(polyPtr);
		auto param = CGAL::parameters::number_of_iterations(iterations);
		CGAL::Subdivision_method_3::Sqrt3_subdivision(poly->model, param);
	}

};
