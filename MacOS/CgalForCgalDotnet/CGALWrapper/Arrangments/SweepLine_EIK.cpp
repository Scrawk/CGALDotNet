
#include "SweepLine_EIK.h"
#include "SweepLine.h"

void* SweepLine2_EIK_Create()
{
	return SweepLine<EIK>::NewSweepLine();
}

void SweepLine2_EIK_Release(void* ptr)
{
	SweepLine<EIK>::DeleteSweepLine(ptr);
}

void SweepLine2_EIK_ClearPointBuffer(void* ptr)
{
	SweepLine<EIK>::ClearPointBuffer(ptr);
}

void SweepLine2_EIK_ClearSegmentBuffer(void* ptr)
{
	SweepLine<EIK>::ClearSegmentBuffer(ptr);
}

int SweepLine2_EIK_PointBufferSize(void* ptr)
{
	return SweepLine<EIK>::PointBufferSize(ptr);
}

int SweepLine2_EIK_SegmentBufferSize(void* ptr)
{
	return SweepLine<EIK>::SegmentBufferSize(ptr);
}

BOOL SweepLine2_EIK_DoIntersect(void* ptr, Segment2d* segments, int count)
{
	return SweepLine<EIK>::DoIntersect(ptr, segments, count);
}

int SweepLine2_EIK_ComputeSubcurves(void* ptr, Segment2d* segments, int count)
{
	return SweepLine<EIK>::ComputeSubcurves(ptr, segments, count);
}

int SweepLine2_EIK_ComputeIntersectionPoints(void* ptr, Segment2d* segments, int count)
{
	return SweepLine<EIK>::ComputeIntersectionPoints(ptr, segments, count);
}

void SweepLine2_EIK_GetPoints(void* ptr, Point2d* points, int count)
{
	SweepLine<EIK>::GetPoints(ptr, points, count);
}

void SweepLine2_EIK_GetSegments(void* ptr, Segment2d* segments, int count)
{
	SweepLine<EIK>::GetSegments(ptr, segments, count);
}