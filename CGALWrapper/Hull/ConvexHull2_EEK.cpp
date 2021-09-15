
#include "ConvexHull2_EEK.h"
#include "ConvexHull2.h"

void* ConvexHull2_EEK_Create()
{
	return ConvexHull2<EEK>::NewConvexHull2();
}

void ConvexHull2_EEK_Release(void* ptr)
{
	ConvexHull2<EEK>::DeleteConvexHull2(ptr);
}

void* ConvexHull2_EEK_CreateHull(Point2d* points, int startIndex, int count, HULL_METHOD method)
{
	return ConvexHull2<EEK>::CreateHull(points, startIndex, count, method);
}

void* ConvexHull2_EEK_UpperHull(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::UpperHull(points, startIndex, count);
}

void* ConvexHull2_EEK_LowerHull(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::LowerHull(points, startIndex, count);
}

BOOL ConvexHull2_EEK_IsStronglyConvexCCW(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::IsStronglyConvexCCW(points, startIndex, count);
}

BOOL ConvexHull2_EEK_IsStronglyConvexCW(Point2d* points, int startIndex, int count)
{
	return ConvexHull2<EEK>::IsStronglyConvexCW(points, startIndex, count);
}
