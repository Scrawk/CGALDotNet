#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingSlicer_EIK_Create();

	CGALWRAPPER_API void MeshProcessingSlicer_EIK_Release(void* ptr);

	CGALWRAPPER_API void MeshProcessingSlicer_EIK_GetLines(void* slicerPtr, void** lines, int count);

	//Polyhedron

	CGALWRAPPER_API int MeshProcessingSlicer_EIK_Slice_PH(void* slicerPtr, void* meshPtr, const Plane3d& plane, BOOL useTree);

	CGALWRAPPER_API int MeshProcessingSlicer_EIK_IncrementalSlice_PH(void* slicerPtr, void* meshPtr, const Point3d& start, const Point3d& end, double increment);

	//Surface Mesh

	CGALWRAPPER_API int MeshProcessingSlicer_EIK_Slice_SM(void* slicerPtr, void* meshPtr, const Plane3d& plane, BOOL useTree);

	CGALWRAPPER_API int MeshProcessingSlicer_EIK_IncrementalSlice_SM(void* slicerPtr, void* meshPtr, const Point3d& start, const Point3d& end, double increment);
}

