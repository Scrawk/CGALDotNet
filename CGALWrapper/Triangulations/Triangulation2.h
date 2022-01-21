#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Polygons/Polygon2.h"
#include "../Polygons/PolygonWithHoles2.h"
#include "BaseTriangulation2.h"

#include "CGAL/Point_2.h"
#include <CGAL/Triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>

template<class K, class TRI, class VERT, class FACE>
class Triangulation2 : public BaseTriangulation2<K, TRI, VERT, FACE>
{

public:

	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K> Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;
	typedef CGAL::Triangulation_2<K, Tds> Triangulation_2;
	typedef typename Triangulation_2::Face_handle Face;
	typedef typename Triangulation_2::Vertex_handle Vertex;

public:

	inline static Triangulation2* NewTriangulation2()
	{
		return new Triangulation2();
	}

	inline static void DeleteTriangulation2(void* ptr)
	{
		auto obj = static_cast<Triangulation2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static Triangulation2* CastToTriangulation2(void* ptr)
	{
		return static_cast<Triangulation2*>(ptr);
	}

	void* Copy()
	{
		auto copy = new Triangulation2();
		copy->model = this->model;
		return copy;
	}

};
