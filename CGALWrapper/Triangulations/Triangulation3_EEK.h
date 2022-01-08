#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* Triangulation3_EEK_Create();

	CGALWRAPPER_API void Triangulation3_EEK_Release(void* ptr);

	CGALWRAPPER_API void* Triangulation3_EEK_Copy(void* ptr);

	CGALWRAPPER_API void Triangulation3_EEK_SetIndices(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_BuildStamp(void* ptr);

	CGALWRAPPER_API BOOL Triangulation3_EEK_IsValid(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_CellCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_FiniteCellCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_EdgeCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_FiniteEdgeCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_FacetCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_FiniteFacetCount(void* ptr);

	CGALWRAPPER_API void Triangulation3_EEK_InsertPoint(void* ptr, const Point3d& point);

	CGALWRAPPER_API void Triangulation3_EEK_InsertPoints(void* ptr, Point3d* points, int count);
}