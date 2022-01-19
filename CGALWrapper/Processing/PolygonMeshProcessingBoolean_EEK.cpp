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

BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronUnion(void* polyPtr1, void* polyPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::PolyhedronUnion(polyPtr1, polyPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronDifference(void* polyPtr1, void* polyPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::PolyhedronDifference(polyPtr1, polyPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronIntersection(void* polyPtr1, void* polyPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::PolyhedronIntersection(polyPtr1, polyPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronClip(void* polyPtr1, void* polyPtr2, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::PolyhedronClip(polyPtr1, polyPtr2, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_PlaneClip(void* polyPtr1, Plane3d plane, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::PlaneClip(polyPtr1, plane, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_BoxClip(void* polyPtr1, Box3d box, void** resultPtr)
{
	return PolygonMeshProcessingBoolean<EEK>::BoxClip(polyPtr1, box, resultPtr);
}

BOOL PolygonMeshProcessingBoolean_EEK_PolyhedronSurfaceIntersection(void* polyPtr1, void* polyPtr2)
{
	return PolygonMeshProcessingBoolean<EEK>::PolyhedronSurfaceIntersection(polyPtr1, polyPtr2);
}

