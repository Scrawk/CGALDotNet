#include "pch.h"
#include "Util.h"
#include "ConvexHull2_EEK.h"
#include "ConvexHull2.h"

void* ConvexHull2_EEK_Create()
{
	return Util::Create<ConvexHull2<EEK>>();
}

void ConvexHull2_EEK_Release(void* ptr)
{
	Util::Release<ConvexHull2<EEK>>(ptr);
}

void* ConvexHull2_EEK_CreateHull(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::CreateHull(points, startIndex, count);
}

void* ConvexHull2_EEK_UpperHull(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::CreateHull(points, startIndex, count);
}

void* ConvexHull2_EEK_LowerHull(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::CreateHull(points, startIndex, count);
}

BOOL ConvexHull2_EEK_IsStronglyConvexCCW(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::IsStronglyConvexCCW(points, startIndex, count);
}

BOOL ConvexHull2_EEK_IsStronglyConvexCW(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::IsStronglyConvexCW(points, startIndex, count);
}
