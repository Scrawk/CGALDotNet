#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

#include "CGAL/Point_2.h"

struct TriVertex2
{
	Point2d Point;

	BOOL IsInfinite;

	int Degree;

	int Index;

	int FaceIndex;

	static TriVertex2 NullVertex()
	{
		TriVertex2 v;
		v.Point = { 0, 0};
		v.IsInfinite = false;
		v.Degree = 0;
		v.Index = NULL_INDEX;
		v.FaceIndex = NULL_INDEX;
		return v;
	}

	template<class K, class TRI, class VERT>
	static TriVertex2 FromVertex(const TRI& tri, VERT vert, int degree)
	{
		TriVertex2 triVertex;
		triVertex.Point = Point2d::FromCGAL<K>(vert->point());
		triVertex.IsInfinite = tri.is_infinite(vert);
		triVertex.Degree = degree;
		triVertex.Index = vert->info();

		auto face = vert->face();

		if (tri.is_infinite(face) || tri.number_of_faces() == 0)
			triVertex.FaceIndex = NULL_INDEX;
		else
			triVertex.FaceIndex = face->info();

		return triVertex;
	}
};

