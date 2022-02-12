
#include "ConvexHull3_EIK.h"
#include "ConvexHull3.h"

void* ConvexHull3_EIK_Create()
{
	return ConvexHull3<EIK>::NewConvexHull3();
}

void ConvexHull3_EIK_Release(void* ptr)
{
	ConvexHull3<EIK>::DeleteConvexHull3(ptr);
}

void* ConvexHull3_EIK_CreateHullAsPolyhedronFromPoints(Point3d* points, int count)
{
	return ConvexHull3<EIK>::CreateHullAsPolyhedronFromPoints(points, count);
}

void* ConvexHull3_EIK_CreateHullAsSurfaceMeshFromPoints(Point3d* points, int count)
{
	return ConvexHull3<EIK>::CreateHullAsSurfaceMeshFromPoints(points, count);
}

void* ConvexHull3_EIK_CreateHullAsPolyhedronFromPlanes(Plane3d* planes, int count)
{
	return ConvexHull3<EIK>::CreateHullAsPolyhedronFromPlanes(planes, count);
}

void* ConvexHull3_EIK_CreateHullAsSurfaceMeshFromPlanes(Plane3d* planes, int count)
{
	return ConvexHull3<EIK>::CreateHullAsSurfaceMeshFromPlanes(planes, count);
}

BOOL ConvexHull3_EIK_IsPolyhedronStronglyConvex(void* ptr)
{
	return ConvexHull3<EIK>::IsPolyhedronStronglyConvex(ptr);
}

BOOL ConvexHull3_EIK_IsSurfaceMeshStronglyConvex(void* ptr)
{
	return ConvexHull3<EIK>::IsSurfaceMeshStronglyConvex(ptr);
}

