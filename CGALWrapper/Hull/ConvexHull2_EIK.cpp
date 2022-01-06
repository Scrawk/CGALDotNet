
#include "ConvexHull2_EIK.h"
#include "ConvexHull2.h"

void* ConvexHull2_EIK_Create()
{
	return ConvexHull2<EIK>::NewConvexHull2();
}

void ConvexHull2_EIK_Release(void* ptr)
{
	ConvexHull2<EIK>::DeleteConvexHull2(ptr);
}

void* ConvexHull2_EIK_CreateHull(Point2d* points, int count, HULL_METHOD method)
{
	return ConvexHull2<EIK>::CreateHull(points, count, method);
}

void* ConvexHull2_EIK_UpperHull(Point2d* points, int count)
{
	return ConvexHull2<EIK>::UpperHull(points, count);
}

void* ConvexHull2_EIK_LowerHull(Point2d* points, int count)
{
	return ConvexHull2<EIK>::LowerHull(points, count);
}

BOOL ConvexHull2_EIK_IsStronglyConvexCCW(Point2d* points, int count)
{
	return ConvexHull2<EIK>::IsStronglyConvexCCW(points, count);
}

BOOL ConvexHull2_EIK_IsStronglyConvexCW(Point2d* points, int count)
{
	return ConvexHull2<EIK>::IsStronglyConvexCW(points, count);
}
