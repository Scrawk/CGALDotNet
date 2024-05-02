#include "MeshProcessingSlicer_EIK.h"
#include "MeshProcessingSlicer.h"

void* MeshProcessingSlicer_EIK_Create()
{
	return MeshProcessingSlicer<EIK>::NewMeshProcessingSlicer();
}

void MeshProcessingSlicer_EIK_Release(void* ptr)
{
	MeshProcessingSlicer<EIK>::DeleteMeshProcessingSlicer(ptr);
}

void MeshProcessingSlicer_EIK_GetLines(void* slicerPtr, void** lines, int count)
{
	MeshProcessingSlicer<EIK>::GetLines(slicerPtr, lines, count);
}

//Polyhedron

int MeshProcessingSlicer_EIK_Slice_PH(void* slicerPtr, void* meshPtr, const Plane3d& plane, BOOL useTree)
{
	return MeshProcessingSlicer<EIK>::Polyhedron_Slice_PH(slicerPtr, meshPtr, plane, useTree);
}

int MeshProcessingSlicer_EIK_IncrementalSlice_PH(void* slicerPtr, void* meshPtr, const Point3d& start, const Point3d& end, double increment)
{
	return MeshProcessingSlicer<EIK>::Polyhedron_Slice_PH(slicerPtr, meshPtr, start, end, increment);
}

//SUrfaceMesh

int MeshProcessingSlicer_EIK_Slice_SM(void* slicerPtr, void* meshPtr, const Plane3d& plane, BOOL useTree)
{
	return MeshProcessingSlicer<EIK>::Polyhedron_Slice_SM(slicerPtr, meshPtr, plane, useTree);
}

int MeshProcessingSlicer_EIK_IncrementalSlice_SM(void* slicerPtr, void* meshPtr, const Point3d& start, const Point3d& end, double increment)
{
	return MeshProcessingSlicer<EIK>::Polyhedron_Slice_SM(slicerPtr, meshPtr, start, end, increment);
}
