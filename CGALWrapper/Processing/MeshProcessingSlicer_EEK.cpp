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

//Polyhedron

int MeshProcessingSlicer_EEK_Slice_PH(void* slicerPtr, void* meshPtr, const Plane3d& plane, BOOL useTree)
{
	return MeshProcessingSlicer<EEK>::Polyhedron_Slice_PH(slicerPtr, meshPtr, plane, useTree);
}

int MeshProcessingSlicer_EEK_IncrementalSlice_PH(void* slicerPtr, void* meshPtr, const Point3d& start, const Point3d& end, double increment)
{
	return MeshProcessingSlicer<EEK>::Polyhedron_Slice_PH(slicerPtr, meshPtr, start, end, increment);
}

//SUrfaceMesh

int MeshProcessingSlicer_EEK_Slice_SM(void* slicerPtr, void* meshPtr, const Plane3d& plane, BOOL useTree)
{
	return MeshProcessingSlicer<EEK>::Polyhedron_Slice_SM(slicerPtr, meshPtr, plane, useTree);
}

int MeshProcessingSlicer_EEK_IncrementalSlice_SM(void* slicerPtr, void* meshPtr, const Point3d& start, const Point3d& end, double increment)
{
	return MeshProcessingSlicer<EEK>::Polyhedron_Slice_SM(slicerPtr, meshPtr, start, end, increment);
}
