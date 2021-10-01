#pragma once

#include "../CGALWrapper.h"

struct DCELHalfEdge
{
	int Index;
	int SourceIndex;
	int TargetIndex;
	int FaceIndex;
	int NextIndex;
	int PreviousIndex;
	int TwinIndex;

	static DCELHalfEdge NullEdge()
	{
		DCELHalfEdge e;
		e.Index = NULL_INDEX;
		e.SourceIndex = NULL_INDEX;
		e.TargetIndex = NULL_INDEX;
		e.FaceIndex = NULL_INDEX;
		e.NextIndex = NULL_INDEX;
		e.PreviousIndex = NULL_INDEX;
		e.TwinIndex = NULL_INDEX;
		return e;
	}

};
