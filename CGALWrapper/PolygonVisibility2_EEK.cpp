#include "pch.h"
#include "PolygonVisibility2_EEK.h"
#include "PolygonVisibility2.h"
#include "Util.h"

void* PolygonVisibility2_EEK_Create()
{
	return Util::Create<PolygonVisibility2<EEK>>();
}

void PolygonVisibility2_EEK_Release(void* ptr)
{
	Util::Release<PolygonVisibility2<EEK>>(ptr);
}

void PolygonVisibility2_EEK_ComputeVisibility(void* ptr, Point2d point, Segment2d* segments, int startIndex, int count)
{
	PolygonVisibility2<EEK>::ComputeVisibility(ptr, point, segments, startIndex, count);
}
