#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

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
		v.Point = { 0, 0 };
		v.IsInfinite = false;
		v.Degree = 0;
		v.Index = NULL_INDEX;
		v.FaceIndex = NULL_INDEX;
		return v;
	}
};

