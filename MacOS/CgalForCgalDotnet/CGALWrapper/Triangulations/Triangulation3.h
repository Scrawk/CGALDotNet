#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "TriUtil.h"
#include "../Geometry/Matrices.h"
#include "BaseTriangulation3.h"

#include <vector>
#include "CGAL/Point_3.h"
#include <CGAL/Triangulation_3.h>
#include <CGAL/Triangulation_cell_base_with_info_3.h>
#include <CGAL/Triangulation_vertex_base_with_info_3.h>
#include <CGAL/Aff_transformation_3.h>

template<class K, class TRI, class VERT, class FACE>
class Triangulation3 : public BaseTriangulation3<K, TRI, VERT, FACE>
{

public:

	typedef CGAL::Triangulation_vertex_base_with_info_3<int, K> Vb;
	typedef CGAL::Triangulation_cell_base_with_info_3<int, K>	Cb;
	typedef CGAL::Triangulation_data_structure_3<Vb, Cb>        Tds;

	typedef CGAL::Triangulation_3<K, Tds>						Triangulation_3;

	typedef typename Triangulation_3::Point						Point_3;
	typedef typename Triangulation_3::Cell_handle				Cell;
	typedef typename Triangulation_3::Vertex_handle				Vertex;

public:

	Triangulation3()
	{

	}

	~Triangulation3()
	{

	}

	inline static Triangulation3* NewTriangulation3()
	{
		return new Triangulation3();
	}

	inline static void DeleteTriangulation3(void* ptr)
	{
		auto obj = static_cast<Triangulation3*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static Triangulation3* CastToTriangulation3(void* ptr)
	{
		return static_cast<Triangulation3*>(ptr);
	}

	void* Copy()
	{
		auto copy = NewTriangulation3();
		copy->model = this->model;
		return copy;
	}

};