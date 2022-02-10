#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

struct MeshFace3
{
	int Index;

	int Halfedge;

	static MeshFace3 NullFace()
	{
		MeshFace3 f;
		f.Index = NULL_INDEX;
		f.Halfedge = NULL_INDEX;
		return f;
	}

};