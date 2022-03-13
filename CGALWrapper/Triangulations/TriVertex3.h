#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

#include "CGAL/Point_3.h"

struct TriVertex3
{
	Point3d Point;

	BOOL IsInfinite;

	int Degree;

	int Index;

	int CellIndex;

	static TriVertex3 NullVertex()
	{
		TriVertex3 v;
		v.Point = { 0, 0 };
		v.IsInfinite = false;
		v.Degree = 0;
		v.Index = NULL_INDEX;
		v.CellIndex = NULL_INDEX;
		return v;
	}

};

