#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"

#include "CGAL/Point_2.h"

struct TriFace2
{
	BOOL IsInfinite;
	int Index;
	int VertexIndices[3];

	static TriFace2 NullFace()
	{
		TriFace2 f;
		f.IsInfinite = false;
		f.Index = NULL_INDEX;
		f.VertexIndices[0] = NULL_INDEX;
		f.VertexIndices[1] = NULL_INDEX;
		f.VertexIndices[2] = NULL_INDEX;
		return f;
	}
};
