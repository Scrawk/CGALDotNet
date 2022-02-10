#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

struct MeshVertex3
{
    Point3d Point;

    int Degree;

    int Index;

	int Halfedge;

	static MeshVertex3 NullVertex()
	{
		MeshVertex3 v;
		v.Point = { 0, 0, 0 };
		v.Degree = 0;
		v.Index = NULL_INDEX;
		v.Halfedge = NULL_INDEX;
		return v;
	}

};