#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
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
	static int NeighbourIndex(FACE face, FACE neighbour)
	{
		for (int i = 0; i < 3; i++)
		{
			if (face->neighbor(i) == neighbour)
				return i;
		}

		return NULL_INDEX;
	}

	template<class TRI, class VERT>
	int Degree(TRI& tri, VERT vert)
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

}
