
#include "PolygonOffset2_EIK.h"
#include "PolygonOffset2.h"

#include <vector>
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/create_offset_polygons_2.h>
#include <CGAL/create_straight_skeleton_from_polygon_with_holes_2.h>
#include <boost/shared_ptr.hpp>

void* PolygonOffset2_EIK_Create()
{
	return PolygonOffset2<EIK>::NewPolygonOffset2();
}

void PolygonOffset2_EIK_Release(void* ptr)
{
	PolygonOffset2<EIK>::DeletePolygonOffset2(ptr);
}

int PolygonOffset2_EIK_PolygonBufferSize(void* ptr)
{
	return PolygonOffset2<EIK>::PolygonBufferSize(ptr);
}

int PolygonOffset2_EIK_SegmentBufferSize(void* ptr)
{
	return PolygonOffset2<EIK>::SegmentBufferSize(ptr);
}

void PolygonOffset2_EIK_ClearPolygonBuffer(void* ptr)
{
	PolygonOffset2<EIK>::ClearPolygonBuffer(ptr);
}

void PolygonOffset2_EIK_ClearSegmentBuffer(void* ptr)
{
	PolygonOffset2<EIK>::ClearSegmentBuffer(ptr);
}

void* PolygonOffset2_EIK_GetBufferedPolygon(void* ptr, int index)
{
	return PolygonOffset2<EIK>::GetBufferedPolygon(ptr, index);
}

Segment2d PolygonOffset2_EIK_GetSegment(void* ptr, int index)
{
	return PolygonOffset2<EIK>::GetSegment(ptr, index);
}

void PolygonOffset2_EIK_GetSegments(void* ptr, Segment2d* segments, int count)
{
	PolygonOffset2<EIK>::GetSegments(ptr, segments, count);
}

void PolygonOffset2_EIK_CreateInteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EIK>::CreateInteriorOffset(ptr, polyPtr, offset);
}

void PolygonOffset2_EIK_CreateInteriorOffsetPWH(void* ptr, void* pwhPtr, double offset, BOOL boundaryOnly)
{
	PolygonOffset2<EIK>::CreateInteriorOffsetPWH(ptr, pwhPtr, offset, boundaryOnly);
}

void PolygonOffset2_EIK_CreateExteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EIK>::CreateExteriorOffset(ptr, polyPtr, offset);
}

void PolygonOffset2_EIK_CreateExteriorOffsetPWH(void* ptr, void* pwhPtr, double offset, BOOL boundaryOnly)
{
	PolygonOffset2<EIK>::CreateExteriorOffsetPWH(ptr, pwhPtr, offset, boundaryOnly);
}

void PolygonOffset2_EIK_CreateInteriorSkeleton(void* ptr, void* polyPtr, BOOL includeBorder)
{
	PolygonOffset2<EIK>::CreateInteriorSkeleton(ptr, polyPtr, includeBorder);
}

void PolygonOffset2_EIK_CreateInteriorSkeletonPWH(void* ptr, void* pwhPtr, BOOL includeBorder)
{
	PolygonOffset2<EIK>::CreateInteriorSkeletonPWH(ptr, pwhPtr, includeBorder);
}

void PolygonOffset2_EIK_CreateExteriorSkeleton(void* ptr, void* polyPtr, double maxOffset, BOOL includeBorder)
{
	PolygonOffset2<EIK>::CreateExteriorSkeleton(ptr, polyPtr, maxOffset, includeBorder);
}

void PolygonOffset2_EIK_CreateExteriorSkeletonPWH(void* ptr, void* pwhPtr, double maxOffset, BOOL includeBorder)
{
	PolygonOffset2<EIK>::CreateExteriorSkeletonPWH(ptr, pwhPtr, maxOffset, includeBorder);
}


