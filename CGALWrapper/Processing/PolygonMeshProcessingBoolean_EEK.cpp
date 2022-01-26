#include "PolygonMeshProcessingBoolean_EEK.h"
#include "PolygonMeshProcessingBoolean.h"

void* PolygonMeshProcessingBoolean_EEK_Create()
{
	return PolygonMeshProcessingBoolean<EEK>::NewPolygonMeshProcessingBoolean();
}

void PolygonMeshProcessingBoolean_EEK_Release(void* ptr)
{
	PolygonMeshProcessingBoolean<EEK>::DeletePolygonMeshProcessingBoolean(ptr);
}

//Polyhedron

BOOL PolygonMeshProcessingBoolean_EEK_Union_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::Union_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_Difference_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::Difference_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_Intersection_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::Intersection_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_Clip_PH(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::Clip_PH(meshPtr1, meshPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_PlaneClip_PH(void* meshPtr1, Plane3d plane, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::PlaneClip_PH(meshPtr1, plane, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_BoxClip_PH(void* meshPtr1, Box3d box, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::BoxClip_PH(meshPtr1, box, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_SurfaceIntersection_PH(void* meshPtr1, void* meshPtr2)
{
	return PolygonMeshProcessingBoolean<EEK>::SurfaceIntersection_PH(meshPtr1, meshPtr2);
}

//Surface Mesh

BOOL PolygonMeshProcessingBoolean_EEK_Union_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::Union_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_Difference_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::Difference_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_Intersection_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::Intersection_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_Clip_SM(void* meshPtr1, void* meshPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::Clip_SM(meshPtr1, meshPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_PlaneClip_SM(void* meshPtr1, Plane3d plane, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::PlaneClip_SM(meshPtr1, plane, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_BoxClip_SM(void* meshPtr1, Box3d box, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::BoxClip_SM(meshPtr1, box, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_SurfaceIntersection_SM(void* meshPtr1, void* meshPtr2)
{
	return PolygonMeshProcessingBoolean<EEK>::SurfaceIntersection_SM(meshPtr1, meshPtr2);
}

