#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "CGAL/Point_2.h"

struct ArrVertex2
{
	Point2d Point;
	int Degree;
	BOOL IsIsolated;
	int Index;
	int FaceIndex;
	int HalfEdgeIndex;

	static ArrVertex2 NullVertex()
	{
		ArrVertex2 v;
		v.Point = { 0, 0 };
		v.Degree = 0;
		v.IsIsolated = false;
		v.Index = NULL_INDEX;
		v.FaceIndex = NULL_INDEX;
		v.HalfEdgeIndex = NULL_INDEX;
		return v;
	}

	template<class K, class VERT>
	static ArrVertex2 FromVertex(VERT vert)
	{
		ArrVertex2 v;
		
		v.Index = vert->data();
		v.Point = Point2d::FromCGAL<K>(vert->point());
		v.Degree = (int)vert->degree();
		v.IsIsolated = vert->is_isolated();

		if (vert->is_isolated())
		{
			v.FaceIndex = vert->face()->data();
			v.HalfEdgeIndex = -1;
		}
		else
		{
			v.FaceIndex = -1;
			auto first = vert->incident_halfedges();
			v.HalfEdgeIndex = first->data();
		}

		return v;
	}
};
