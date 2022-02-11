#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

struct MeshHalfedge3
{
	BOOL IsBorder;

	int Index;

	int Source;

	int Target;

	int Opposite;

	int Next;

	int Previous;

	int Face;

	static MeshHalfedge3 NullHalfedge()
	{
		MeshHalfedge3 e;
		e.Index = NULL_INDEX;
		e.Source = NULL_INDEX;
		e.Target = NULL_INDEX;
		e.Opposite = NULL_INDEX;
		e.Next = NULL_INDEX;
		e.Previous = NULL_INDEX;
		e.Face = NULL_INDEX;
		return e;
	}

};
