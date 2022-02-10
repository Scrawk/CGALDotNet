#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

struct MeshHalfedge3
{
	BOOL IsBorder;

	int Index;

	int Vertex;

	int Opposite;

	int Next;

	int Previous;

	static MeshHalfedge3 NullHalfedge()
	{
		MeshHalfedge3 e;
		e.Index = NULL_INDEX;
		e.Vertex = NULL_INDEX;
		e.Opposite = NULL_INDEX;
		e.Next = NULL_INDEX;
		e.Previous = NULL_INDEX;
		return e;
	}

	template<class K, class EDGE>
	static MeshHalfedge3 FromHalfedge(EDGE edge)
	{
		MeshHalfedge3 e;

		e.Index = NULL_INDEX;
		e.Vertex = NULL_INDEX;
		e.Opposite = NULL_INDEX;
		e.Next = NULL_INDEX;
		e.Previous = NULL_INDEX;
		e.IsBorder = edge->is_border();

		return e;
	}
};
