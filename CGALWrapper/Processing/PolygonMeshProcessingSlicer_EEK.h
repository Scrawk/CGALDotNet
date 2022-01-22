#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonMeshProcessingSlicer_EEK_Create();

	CGALWRAPPER_API void PolygonMeshProcessingSlicer_EEK_Release(void* ptr);

	CGALWRAPPER_API void PolygonMeshProcessingSlicer_EEK_GetLines(void* slicerPtr, void** lines, int count);

	CGALWRAPPER_API int  PolygonMeshProcessingSlicer_EEK_Polyhedron_Slice(void* slicerPtr, void* polyPtr, const Plane3d& plane, BOOL useTree);

}

