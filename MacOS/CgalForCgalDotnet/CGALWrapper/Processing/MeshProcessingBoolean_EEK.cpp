#include "MeshProcessingBoolean_EEK.h"
#include "MeshProcessingBoolean.h"

void* MeshProcessingBoolean_EEK_Create()
{
	return MeshProcessingBoolean<EEK>::NewMeshProcessingBoolean();
}

void MeshProcessingBoolean_EEK_Release(void* ptr)
{
	MeshProcessingBoolean<EEK>::DeleteMeshProcessingBoolean(ptr);
}

//Polyhedron

BOOL MeshProcessingBoolean_EEK_Union_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::Union_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_Difference_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::Difference_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_Intersection_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::Intersection_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_Clip_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::Clip_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_PlaneClip_PH(void* meshPtr1, Plane3d plane, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::PlaneClip_PH(meshPtr1, plane, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_BoxClip_PH(void* meshPtr1, Box3d box, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::BoxClip_PH(meshPtr1, box, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_SurfaceIntersection_PH(void* meshPtr1, void* meshPtr2)
{
	return MeshProcessingBoolean<EEK>::SurfaceIntersection_PH(meshPtr1, meshPtr2);
}

//Surface Mesh

BOOL MeshProcessingBoolean_EEK_Union_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::Union_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_Difference_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::Difference_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_Intersection_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::Intersection_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_Clip_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::Clip_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_PlaneClip_SM(void* meshPtr1, Plane3d plane, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::PlaneClip_SM(meshPtr1, plane, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_BoxClip_SM(void* meshPtr1, Box3d box, void** resultPtr)
{
	return MeshProcessingBoolean<EEK>::BoxClip_SM(meshPtr1, box, resultPtr);
}

BOOL MeshProcessingBoolean_EEK_SurfaceIntersection_SM(void* meshPtr1, void* meshPtr2)
{
	return MeshProcessingBoolean<EEK>::SurfaceIntersection_SM(meshPtr1, meshPtr2);
}

