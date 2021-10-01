#pragma once

#include "../CGALWrapper.h"
#include "CGAL/Point_2.h"

struct DCELFace
{
	int Index;
	int HalfEdgeIndex;

	static DCELFace NullFace()
	{
		DCELFace f;
		f.Index = NULL_INDEX;
		f.HalfEdgeIndex = NULL_INDEX;
		return f;
	}

};
