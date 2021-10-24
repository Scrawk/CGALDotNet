#include "SurfaceMesh3_EEK.h"
#include "SurfaceMesh3.h"

void* SurfaceMesh3_EEK_Create()
{
	return SurfaceMesh3<EEK>::NewSurfaceMesh();
}

void SurfaceMesh3_EEK_Release(void* ptr)
{
	SurfaceMesh3<EEK>::DeleteSurfaceMesh(ptr);
}

void SurfaceMesh3_EEK_Clear(void* ptr)
{
	SurfaceMesh3<EEK>::Clear(ptr);
}

BOOL SurfaceMesh3_EEK_IsValid(void* ptr)
{
	return SurfaceMesh3<EEK>::IsValid(ptr);
}

int SurfaceMesh3_EEK_VertexCount(void* ptr)
{
	return SurfaceMesh3<EEK>::VertexCount(ptr);
}

int SurfaceMesh3_EEK_HalfEdgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::HalfEdgeCount(ptr);
}

int SurfaceMesh3_EEK_EdgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::EdgeCount(ptr);
}

int SurfaceMesh3_EEK_FaceCount(void* ptr)
{
	return SurfaceMesh3<EEK>::FaceCount(ptr);
}

int SurfaceMesh3_EEK_AddVertex(void* ptr, Point3d point)
{
	return SurfaceMesh3<EEK>::AddVertex(ptr, point);
}

int SurfaceMesh3_EEK_AddEdge(void* ptr, int v0, int v1)
{
	return SurfaceMesh3<EEK>::AddEdge(ptr, v0, v1);
}

int SurfaceMesh3_EEK_AddFace(void* ptr, int v0, int v1, int v2)
{
	return SurfaceMesh3<EEK>::AddFace(ptr, v0, v1, v2);
}