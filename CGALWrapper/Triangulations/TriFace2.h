#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

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

	template<class TRI, class FACE>
	static TriFace2 FromFace(const TRI& tri, FACE face)
	{
		TriFace2 triFace;
		triFace.IsInfinite = tri.is_infinite(face);

		if(triFace.IsInfinite)
			triFace.Index = NULL_INDEX;
		else
			triFace.Index = face->info();

		for (int j = 0; j < 3; j++)
		{
			auto vert = face->vertex(j);

			if (tri.is_infinite(vert))
				triFace.VertexIndices[j] = NULL_INDEX;
			else
				triFace.VertexIndices[j] = vert->info();
		}

		return triFace;
	}
};
