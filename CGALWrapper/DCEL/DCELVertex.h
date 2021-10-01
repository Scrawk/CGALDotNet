#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "CGAL/Point_2.h"

struct DCELVertex
{
    Point2d Point;

    int Index;

    int FaceIndex;

    int HalfEdgeIndex;

	static DCELVertex NullVertex()
	{
		DCELVertex v;
		v.Point = { 0, 0 };
		v.Index = NULL_INDEX;
		v.FaceIndex = NULL_INDEX;
		v.HalfEdgeIndex = NULL_INDEX;
		return v;
	}
};
