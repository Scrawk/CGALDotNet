#include "PolygonMeshProcessingSlicer_EEK.h"
#include "PolygonMeshProcessingSlicer.h"

void* PolygonMeshProcessingSlicer_EEK_Create()
{
	return PolygonMeshProcessingSlicer<EEK>::NewPolygonMeshProcessingSlicer();
}

void PolygonMeshProcessingSlicer_EEK_Release(void* ptr)
{
	PolygonMeshProcessingSlicer<EEK>::DeletePolygonMeshProcessingSlicer(ptr);
}

void PolygonMeshProcessingSlicer_EEK_GetLines(void* slicerPtr, void** lines, int count)
{
	PolygonMeshProcessingSlicer<EEK>::GetLines(slicerPtr, lines, count);
}

int PolygonMeshProcessingSlicer_EEK_Polyhedron_Slice(void* slicerPtr, void* polyPtr, const Plane3d& plane, BOOL useTree)
{
	return PolygonMeshProcessingSlicer<EEK>::Polyhedron_Slice(slicerPtr, polyPtr, plane, useTree);
}
