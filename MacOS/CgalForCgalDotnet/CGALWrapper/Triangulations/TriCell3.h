#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "CGAL/Point_3.h"

struct TriCell3
{
	BOOL IsInfinite;

	int Index;

	int VertexIndices[4];

	int NeighborIndices[4];

	static TriCell3 NullCell()
	{
		TriCell3 c;
		c.IsInfinite = false;
		c.Index = NULL_INDEX;
		c.VertexIndices[0] = NULL_INDEX;
		c.VertexIndices[1] = NULL_INDEX;
		c.VertexIndices[2] = NULL_INDEX;
		c.VertexIndices[3] = NULL_INDEX;
		c.NeighborIndices[0] = NULL_INDEX;
		c.NeighborIndices[1] = NULL_INDEX;
		c.NeighborIndices[2] = NULL_INDEX;
		c.NeighborIndices[3] = NULL_INDEX;
		return c;
	}

};

