#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "TriFace2.h"
#include "TriVertex2.h"

#include "CGAL/Point_2.h"
#include <CGAL/Triangulation_2.h>
#include <CGAL/Delaunay_triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>

namespace TriUtil
{

	template<class FACE>
	int NeighbourIndex(FACE face, FACE neighbour)
	{
		for (int i = 0; i < 3; i++)
		{
			if (face->neighbor(i) == neighbour)
				return i;
		}

		return NULL_INDEX;
	}

	template<class TRI, class VERT>
	int Degree2(TRI& tri, VERT vert)
	{
		auto face = vert->face();
		auto start = vert->incident_faces(face), end(start);

		int count = 0;

		if (!start.is_empty())
		{
			do
			{
				if (!tri.is_infinite(start))
					++count;

			} while (++start != end);
		}

		return count;
	}

	//template<class TRI, class VERT, class CELL>
	//int Degree3(TRI& tri, VERT vert)
	//{
	//	std::vector<CELL> cells;
	//	tri.finite_incident_cells(vert, std::back_inserter(cells));
	//	return cells.size();
	//}

	template<class POINT, class FACE>
	POINT CenterPoint(FACE face)
	{
		POINT p0 = face->vertex(0)->point();
		POINT p1 = face->vertex(1)->point();
		POINT p2 = face->vertex(2)->point();

		auto x = (p0.x() + p1.x() + p2.x()) / 3;
		auto y = (p0.y() + p1.y() + p2.y()) / 3;

		return POINT(x, y);
	}

}
