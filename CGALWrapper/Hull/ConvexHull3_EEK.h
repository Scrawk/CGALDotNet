#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* ConvexHull3_EEK_Create();

	CGALWRAPPER_API void ConvexHull3_EEK_Release(void* ptr);

	CGALWRAPPER_API void* ConvexHull3_EEK_CreateHullAsPolyhedronFromPoints(Point3d* points, int count);

	CGALWRAPPER_API void* ConvexHull3_EEK_CreateHullAsSurfaceMeshFromPoints(Point3d* points, int count);

	CGALWRAPPER_API void* ConvexHull3_EEK_CreateHullAsPolyhedronFromPlanes(Plane3d* planes, int count);

	CGALWRAPPER_API void* ConvexHull3_EEK_CreateHullAsSurfaceMeshFromPlanes(Plane3d* planes, int count);

	CGALWRAPPER_API BOOL ConvexHull3_EEK_IsPolyhedronStronglyConvex(void* ptr);

	CGALWRAPPER_API BOOL ConvexHull3_EEK_IsSurfaceMeshStronglyConvex(void* ptr);

}