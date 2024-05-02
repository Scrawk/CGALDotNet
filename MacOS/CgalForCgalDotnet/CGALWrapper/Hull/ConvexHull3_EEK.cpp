
#include "ConvexHull3_EEK.h"
#include "ConvexHull3.h"

void* ConvexHull3_EEK_Create()
{
	return ConvexHull3<EEK>::NewConvexHull3();
}

void ConvexHull3_EEK_Release(void* ptr)
{
	ConvexHull3<EEK>::DeleteConvexHull3(ptr);
}

void* ConvexHull3_EEK_CreateHullAsPolyhedronFromPoints(Point3d* points, int count)
{
	return ConvexHull3<EEK>::CreateHullAsPolyhedronFromPoints(points, count);
}

void* ConvexHull3_EEK_CreateHullAsSurfaceMeshFromPoints(Point3d* points, int count)
{
	return ConvexHull3<EEK>::CreateHullAsSurfaceMeshFromPoints(points, count);
}

void* ConvexHull3_EEK_CreateHullAsPolyhedronFromPlanes(Plane3d* planes, int count)
{
	return ConvexHull3<EEK>::CreateHullAsPolyhedronFromPlanes(planes, count);
}

void* ConvexHull3_EEK_CreateHullAsSurfaceMeshFromPlanes(Plane3d* planes, int count)
{
	return ConvexHull3<EEK>::CreateHullAsSurfaceMeshFromPlanes(planes, count);
}

BOOL ConvexHull3_EEK_IsPolyhedronStronglyConvex(void* ptr)
{
	return ConvexHull3<EEK>::IsPolyhedronStronglyConvex(ptr);
}

BOOL ConvexHull3_EEK_IsSurfaceMeshStronglyConvex(void* ptr)
{
	return ConvexHull3<EEK>::IsSurfaceMeshStronglyConvex(ptr);
}

