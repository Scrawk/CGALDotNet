#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* ConvexHull3_EIK_Create();

	CGALWRAPPER_API void ConvexHull3_EIK_Release(void* ptr);

	CGALWRAPPER_API void* ConvexHull3_EIK_CreateHullAsPolyhedronFromPoints(Point3d* points, int count);

	CGALWRAPPER_API void* ConvexHull3_EIK_CreateHullAsSurfaceMeshFromPoints(Point3d* points, int count);

	CGALWRAPPER_API void* ConvexHull3_EIK_CreateHullAsPolyhedronFromPlanes(Plane3d* planes, int count);

	CGALWRAPPER_API void* ConvexHull3_EIK_CreateHullAsSurfaceMeshFromPlanes(Plane3d* planes, int count);

	CGALWRAPPER_API BOOL ConvexHull3_EIK_IsPolyhedronStronglyConvex(void* ptr);

	CGALWRAPPER_API BOOL ConvexHull3_EIK_IsSurfaceMeshStronglyConvex(void* ptr);

}