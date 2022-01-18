#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonMeshProcessingRepair_EEK_Create();

	CGALWRAPPER_API void PolygonMeshProcessingRepair_EEK_Release(void* ptr);

	CGALWRAPPER_API int PolygonMeshProcessingRepair_EEK_DegenerateHalfEdgeCount(void* ptr);

	CGALWRAPPER_API int PolygonMeshProcessingRepair_EEK_DegenerateTriangleCount(void* ptr);

	CGALWRAPPER_API int PolygonMeshProcessingRepair_EEK_NeedleTriangleCount(void* ptr, double threshold);

	CGALWRAPPER_API int PolygonMeshProcessingRepair_EEK_NonManifoldVertexCount(void* ptr);

	CGALWRAPPER_API void PolygonMeshProcessingRepair_EEK_RepairPolygonSoup(void* ptr);

	CGALWRAPPER_API int PolygonMeshProcessingRepair_EEK_StitchBoundaryCycles(void* ptr);

	CGALWRAPPER_API int PolygonMeshProcessingRepair_EEK_StitchBorders(void* ptr);

	CGALWRAPPER_API int PolygonMeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle(void* ptr);

	CGALWRAPPER_API int PolygonMeshProcessingRepair_EEK_RemoveIsolatedVertices(void* ptr);

	CGALWRAPPER_API void PolygonMeshProcessingRepair_EEK_PolygonMeshToPolygonSoup(void* ptr, int* triangles, int triangleCount, int* quads, int quadCount);

}

