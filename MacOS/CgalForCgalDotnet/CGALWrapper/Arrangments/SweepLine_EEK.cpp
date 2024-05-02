
#include "SweepLine_EEK.h"
#include "SweepLine.h"

void* SweepLine2_EEK_Create()
{
	return SweepLine<EEK>::NewSweepLine();
}

void SweepLine2_EEK_Release(void* ptr)
{
	SweepLine<EEK>::DeleteSweepLine(ptr);
}

void SweepLine2_EEK_ClearPointBuffer(void* ptr)
{
	SweepLine<EEK>::ClearPointBuffer(ptr);
}

void SweepLine2_EEK_ClearSegmentBuffer(void* ptr)
{
	SweepLine<EEK>::ClearSegmentBuffer(ptr);
}

int SweepLine2_EEK_PointBufferSize(void* ptr)
{
	return SweepLine<EEK>::PointBufferSize(ptr);
}

int SweepLine2_EEK_SegmentBufferSize(void* ptr)
{
	return SweepLine<EEK>::SegmentBufferSize(ptr);
}

BOOL SweepLine2_EEK_DoIntersect(void* ptr, Segment2d* segments, int count)
{
	return SweepLine<EEK>::DoIntersect(ptr, segments, count);
}

int SweepLine2_EEK_ComputeSubcurves(void* ptr, Segment2d* segments, int count)
{
	return SweepLine<EEK>::ComputeSubcurves(ptr, segments, count);
}

int SweepLine2_EEK_ComputeIntersectionPoints(void* ptr, Segment2d* segments, int count)
{
	return SweepLine<EEK>::ComputeIntersectionPoints(ptr, segments, count);
}

void SweepLine2_EEK_GetPoints(void* ptr, Point2d* points, int count)
{
	SweepLine<EEK>::GetPoints(ptr, points, count);
}

void SweepLine2_EEK_GetSegments(void* ptr, Segment2d* segments, int count)
{
	SweepLine<EEK>::GetSegments(ptr, segments, count);
}