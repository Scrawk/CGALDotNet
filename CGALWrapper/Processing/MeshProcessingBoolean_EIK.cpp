#include "MeshProcessingBoolean_EIK.h"
#include "MeshProcessingBoolean.h"

void* MeshProcessingBoolean_EIK_Create()
{
	return MeshProcessingBoolean<EIK>::NewMeshProcessingBoolean();
}

void MeshProcessingBoolean_EIK_Release(void* ptr)
{
	MeshProcessingBoolean<EIK>::DeleteMeshProcessingBoolean(ptr);
}

//Polyhedron

BOOL MeshProcessingBoolean_EIK_Union_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::Union_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_Difference_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::Difference_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_Intersection_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::Intersection_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_Clip_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::Clip_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_PlaneClip_PH(void* meshPtr1, Plane3d plane, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::PlaneClip_PH(meshPtr1, plane, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_BoxClip_PH(void* meshPtr1, Box3d box, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::BoxClip_PH(meshPtr1, box, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_SurfaceIntersection_PH(void* meshPtr1, void* meshPtr2)
{
	return MeshProcessingBoolean<EIK>::SurfaceIntersection_PH(meshPtr1, meshPtr2);
}

//Surface Mesh

BOOL MeshProcessingBoolean_EIK_Union_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::Union_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_Difference_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::Difference_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_Intersection_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::Intersection_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_Clip_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::Clip_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_PlaneClip_SM(void* meshPtr1, Plane3d plane, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::PlaneClip_SM(meshPtr1, plane, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_BoxClip_SM(void* meshPtr1, Box3d box, void** resultPtr)
{
	return MeshProcessingBoolean<EIK>::BoxClip_SM(meshPtr1, box, resultPtr);
}

BOOL MeshProcessingBoolean_EIK_SurfaceIntersection_SM(void* meshPtr1, void* meshPtr2)
{
	return MeshProcessingBoolean<EIK>::SurfaceIntersection_SM(meshPtr1, meshPtr2);
}

