#pragma once

#include "../CGALWrapper.h"
#include "CGAL/Point_2.h"

struct ArrFace2
{
	BOOL IsFictitious;
	BOOL IsUnbounded;
	BOOL HasOuterEdges;
	int Index;
	int HalfEdgeIndex;

	static ArrFace2 NullFace()
	{
		ArrFace2 f;
		f.IsFictitious = false;
		f.IsUnbounded = false;
		f.Index = NULL_INDEX;
		f.HalfEdgeIndex = NULL_INDEX;
		return f;
	}

	template<class FACE>
	static ArrFace2 FromFace(FACE face)
	{
		ArrFace2 f;
		f.IsFictitious = face->is_fictitious();
		f.IsUnbounded = face->is_unbounded();
		f.HasOuterEdges = face->has_outer_ccb();
		f.Index = face->data();

		if (face->has_outer_ccb())
		{
			auto first = face->outer_ccb();
			f.HalfEdgeIndex = first->data();
		}
		else
		{
			f.HalfEdgeIndex = -1;
		}

		return f;
			
	}
};
