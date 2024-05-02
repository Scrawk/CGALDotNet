#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingRepair_EIK_Create();

	CGALWRAPPER_API void MeshProcessingRepair_EIK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API int MeshProcessingRepair_EIK_DegenerateEdgeCount_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_DegenerateTriangleCount_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_NeedleTriangleCount_PH(void* ptr, double threshold);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_NonManifoldVertexCount_PH(void* ptr);

	CGALWRAPPER_API void MeshProcessingRepair_EIK_RepairPolygonSoup_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_StitchBoundaryCycles_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_StitchBorders_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_MergeDuplicatedVerticesInBoundaryCycle_PH(void* ptr, int index);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_MergeDuplicatedVerticesInBoundaryCycles_PH(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_RemoveIsolatedVertices_PH(void* ptr);

	//SurfaceMesh

	CGALWRAPPER_API int MeshProcessingRepair_EIK_DegenerateEdgeCount_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_DegenerateTriangleCount_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_NeedleTriangleCount_SM(void* ptr, double threshold);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_NonManifoldVertexCount_SM(void* ptr);

	CGALWRAPPER_API void MeshProcessingRepair_EIK_RepairPolygonSoup_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_StitchBoundaryCycles_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_StitchBorders_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_MergeDuplicatedVerticesInBoundaryCycle_SM(void* ptr, int index);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_MergeDuplicatedVerticesInBoundaryCycles_SM(void* ptr);

	CGALWRAPPER_API int MeshProcessingRepair_EIK_RemoveIsolatedVertices_SM(void* ptr);

}

