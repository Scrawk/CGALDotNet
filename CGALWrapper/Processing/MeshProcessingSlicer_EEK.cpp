#include "MeshProcessingSlicer_EEK.h"
#include "MeshProcessingSlicer.h"

void* MeshProcessingSlicer_EEK_Create()
{
	return MeshProcessingSlicer<EEK>::NewMeshProcessingSlicer();
}

void MeshProcessingSlicer_EEK_Release(void* ptr)
{
	MeshProcessingSlicer<EEK>::DeleteMeshProcessingSlicer(ptr);
}

void MeshProcessingSlicer_EEK_GetLines(void* slicerPtr, void** lines, int count)
{
	MeshProcessingSlicer<EEK>::GetLines(slicerPtr, lines, count);
}

int MeshProcessingSlicer_EEK_Polyhedron_Slice(void* slicerPtr, void* polyPtr, const Plane3d& plane, BOOL useTree)
{
	return MeshProcessingSlicer<EEK>::Polyhedron_Slice(slicerPtr, polyPtr, plane, useTree);
}

int MeshProcessingSlicer_EEK_Polyhedron_IncrementalSlice(void* slicerPtr, void* polyPtr, const Point3d& start, const Point3d& end, double increment)
{
	return MeshProcessingSlicer<EEK>::Polyhedron_Slice(slicerPtr, polyPtr, start, end, increment);
}
