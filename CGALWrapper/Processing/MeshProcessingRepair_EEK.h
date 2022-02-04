#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingRepair_EEK_Create();

	CGALWRAPPER_API void MeshProcessingRepair_EEK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API int MeshProcessingRepair_EEK_DegenerateEdgeCount_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_DegenerateTriangleCount_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_NeedleTriangleCount_PH(void* ptr, double threshold);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_NonManifoldVertexCount_PH(void* ptr);

	CGALWRAPPER_API void MeshProcessingRepair_EEK_RepairPolygonSoup_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_StitchBoundaryCycles_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_StitchBorders_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle_PH(void* ptr, int index);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycles_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_RemoveIsolatedVertices_PH(void* ptr);

	//SurfaceMesh

	CGALWRAPPER_API int MeshProcessingRepair_EEK_DegenerateEdgeCount_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_DegenerateTriangleCount_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_NeedleTriangleCount_SM(void* ptr, double threshold);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_NonManifoldVertexCount_SM(void* ptr);

	CGALWRAPPER_API void MeshProcessingRepair_EEK_RepairPolygonSoup_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_StitchBoundaryCycles_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_StitchBorders_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle_SM(void* ptr, int index);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycles_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EEK_RemoveIsolatedVertices_SM(void* ptr);

}

