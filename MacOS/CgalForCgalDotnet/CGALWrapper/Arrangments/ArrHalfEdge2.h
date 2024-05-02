#pragma once

#include "../CGALWrapper.h"

struct ArrHalfEdge2
{
	BOOL IsFictitious;
	int Index;
	int SourceIndex;
	int TargetIndex;
	int FaceIndex;
	int NextIndex;
	int PreviousIndex;
	int TwinIndex;

	static ArrHalfEdge2 NullEdge()
	{
		ArrHalfEdge2 e;
		e.IsFictitious = false;
		e.Index = NULL_INDEX;
		e.SourceIndex = NULL_INDEX;
		e.TargetIndex = NULL_INDEX;
		e.FaceIndex = NULL_INDEX;
		e.NextIndex = NULL_INDEX;
		e.PreviousIndex = NULL_INDEX;
		e.TwinIndex = NULL_INDEX;
		return e;
	}

	template<class EDGE>
	static ArrHalfEdge2 FromHalfEdge(EDGE edge)
	{
		ArrHalfEdge2 e;
		e.IsFictitious = edge->is_fictitious();
		e.Index = edge->data();
		e.SourceIndex = edge->source()->data();
		e.TargetIndex = edge->target()->data();
		e.FaceIndex = edge->face()->data();
		e.NextIndex = edge->next()->data();
		e.PreviousIndex = edge->prev()->data();
		e.TwinIndex = edge->twin()->data();

		return e;
	}
};
