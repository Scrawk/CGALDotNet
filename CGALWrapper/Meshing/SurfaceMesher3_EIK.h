#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
    CGALWRAPPER_API int SurfaceMesher3_EIK_VertexCount();

    CGALWRAPPER_API int SurfaceMesher3_EIK_TriangleCount();

    CGALWRAPPER_API void SurfaceMesher3_EIK_ClearMesh();

    CGALWRAPPER_API Point3d SurfaceMesher3_EIK_GetPoint(int i);

    CGALWRAPPER_API TriangleIndex SurfaceMesher3_EIK_GetTriangle(int i);

	CGALWRAPPER_API void SurfaceMesher3_EIK_Generate();
}