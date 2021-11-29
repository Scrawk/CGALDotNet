#include "Polyhedron3_EEK.h"

#include "Polyhedron3.h"

void* Polyhedron3_EEK_Create()
{
	return Polyhedron3<EEK>::NewPolyhedron();
}

void* Polyhedron3_EEK_CreateFromSize(int vertices, int halfedges, int faces)
{
	return Polyhedron3<EEK>::NewPolyhedron(vertices, halfedges, faces);
}

void Polyhedron3_EEK_Release(void* ptr)
{
	Polyhedron3<EEK>::DeletePolyhedron(ptr);
}

void Polyhedron3_EEK_Clear(void* ptr)
{
	Polyhedron3<EEK>::Clear(ptr);
}

int Polyhedron3_EEK_VertexCount(void* ptr)
{
	return Polyhedron3<EEK>::VertexCount(ptr);
}

int Polyhedron3_EEK_FaceCount(void* ptr)
{
	return Polyhedron3<EEK>::FaceCount(ptr);
}

int Polyhedron3_EEK_HalfEdgeCount(void* ptr)
{
	return Polyhedron3<EEK>::HalfEdgeCount(ptr);
}

int Polyhedron3_EEK_BorderEdgeCount(void* ptr)
{
	return Polyhedron3<EEK>::BorderEdgeCount(ptr);
}

int Polyhedron3_EEK_BorderHalfEdgeCount(void* ptr)
{
	return Polyhedron3<EEK>::BorderHalfEdgeCount(ptr);
}

BOOL Polyhedron3_EEK_IsValid(void* ptr, int level)
{
	return Polyhedron3<EEK>::IsValid(ptr, level);
}

BOOL Polyhedron3_EEK_IsClosed(void* ptr)
{
	return Polyhedron3<EEK>::IsClosed(ptr);
}

BOOL Polyhedron3_EEK_IsPureBivalent(void* ptr)
{
	return Polyhedron3<EEK>::IsPureBivalent(ptr);
}

BOOL Polyhedron3_EEK_IsPureTrivalent(void* ptr)
{
	return Polyhedron3<EEK>::IsPureTrivalent(ptr);
}

BOOL Polyhedron3_EEK_IsPureTriangle(void* ptr)
{
	return Polyhedron3<EEK>::IsPureTriangle(ptr);
}

BOOL Polyhedron3_EEK_IsPureQuad(void* ptr)
{
	return Polyhedron3<EEK>::IsPureQuad(ptr);
}

void Polyhedron3_EEK_MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
{
	Polyhedron3<EEK>::MakeTetrahedron(ptr, p1, p2, p3, p4);
}

void Polyhedron3_EEK_MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3)
{
	Polyhedron3<EEK>::MakeTriangle(ptr, p1, p2, p3);
}

void Polyhedron3_EEK_CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* indices, int indicesCount)
{
	Polyhedron3<EEK>::CreateTriangleMesh(ptr, points, pointsCount, indices, indicesCount);
}

void Polyhedron3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	Polyhedron3<EEK>::GetPoints(ptr, points, count);
}

void Polyhedron3_EEK_GetTriangleIndices(void* ptr, int* indices, int count)
{
	Polyhedron3<EEK>::GetTriangleIndices(ptr, indices, count);
}

void Polyhedron3_EEK_Transform(void* ptr, Matrix4x4d matrix)
{
	Polyhedron3<EEK>::Transform(ptr, matrix);
}