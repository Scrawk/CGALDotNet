#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "Triangulation2.h"

extern "C"
{
	CGALWRAPPER_API void* Triangulation2_EEK_Create();

	CGALWRAPPER_API void Triangulation2_EEK_Release(void* ptr);

	CGALWRAPPER_API void* Triangulation2_EEK_CreateFromPoints(Point2d* points, int startIndex, int count);

	CGALWRAPPER_API void* Triangulation2_EEK_CreateFromPolygon(void* ptr);

	CGALWRAPPER_API void Triangulation2_EEK_Clear(void* ptr);

	CGALWRAPPER_API BOOL Triangulation2_EEK_IsValid(void* ptr);

	CGALWRAPPER_API int Triangulation2_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int Triangulation2_EEK_FaceCount(void* ptr);

	CGALWRAPPER_API void Triangulation2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count);
}

