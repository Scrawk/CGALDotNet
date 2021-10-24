#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* SurfaceMesh3_EEK_Create();

	CGALWRAPPER_API void SurfaceMesh3_EEK_Release(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Clear(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsValid(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_EdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_FaceCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddVertex(void* ptr, Point3d point);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddEdge(void* ptr, int v0, int v1);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddFace(void* ptr, int v0, int v1, int v2);

}