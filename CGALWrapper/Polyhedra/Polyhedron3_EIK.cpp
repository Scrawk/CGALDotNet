#include "Polyhedron3_EIK.h"

#include "Polyhedron3.h"

void* Polyhedron3_EIK_Create()
{
	return Polyhedron3<EIK>::NewPolyhedron();
}

void* Polyhedron3_EIK_CreateFromSize(int vertices, int halfedges, int faces)
{
	return Polyhedron3<EIK>::NewPolyhedron(vertices, halfedges, faces);
}

void Polyhedron3_EIK_Release(void* ptr)
{
	Polyhedron3<EIK>::DeletePolyhedron(ptr);
}

void Polyhedron3_EIK_Clear(void* ptr)
{
	Polyhedron3<EIK>::Clear(ptr);
}

int Polyhedron3_EIK_VertexCount(void* ptr)
{
	return Polyhedron3<EIK>::VertexCount(ptr);
}

int Polyhedron3_EIK_FaceCount(void* ptr)
{
	return Polyhedron3<EIK>::FaceCount(ptr);
}

int Polyhedron3_EIK_HalfEdgeCount(void* ptr)
{
	return Polyhedron3<EIK>::HalfEdgeCount(ptr);
}

int Polyhedron3_EIK_BorderEdgeCount(void* ptr)
{
	return Polyhedron3<EIK>::BorderEdgeCount(ptr);
}

int Polyhedron3_EIK_BorderHalfEdgeCount(void* ptr)
{
	return Polyhedron3<EIK>::BorderHalfEdgeCount(ptr);
}

BOOL Polyhedron3_EIK_IsValid(void* ptr, int level)
{
	return Polyhedron3<EIK>::IsValid(ptr, level);
}

BOOL Polyhedron3_EIK_IsClosed(void* ptr)
{
	return Polyhedron3<EIK>::IsClosed(ptr);
}

BOOL Polyhedron3_EIK_IsPureBivalent(void* ptr)
{
	return Polyhedron3<EIK>::IsPureBivalent(ptr);
}

BOOL Polyhedron3_EIK_IsPureTrivalent(void* ptr)
{
	return Polyhedron3<EIK>::IsPureTrivalent(ptr);
}

int Polyhedron3_EIK_IsPureTriangle(void* ptr)
{
	return Polyhedron3<EIK>::IsPureTriangle(ptr);
}

int Polyhedron3_EIK_IsPureQuad(void* ptr)
{
	return Polyhedron3<EIK>::IsPureQuad(ptr);
}

void Polyhedron3_EIK_MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
{
	Polyhedron3<EIK>::MakeTetrahedron(ptr, p1, p2, p3, p4);
}

void Polyhedron3_EIK_MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3)
{
	Polyhedron3<EIK>::MakeTriangle(ptr, p1, p2, p3);
}

void Polyhedron3_EIK_CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount)
{
	Polyhedron3<EIK>::CreateTriangleMesh(ptr, points, pointsCount, triangles, triangleCount);
}

void Polyhedron3_EIK_CreateQuadMesh(void* ptr, Point3d* points, int pointsCount, int* quads, int quadCount)
{
	Polyhedron3<EIK>::CreateQuadMesh(ptr, points, pointsCount, quads, quadCount);
}

void Polyhedron3_EIK_CreateTriangleQuadMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount, int* quads, int quadCount)
{
	Polyhedron3<EIK>::CreateTriangleQuadMesh(ptr, points, pointsCount, triangles, triangleCount, quads, quadCount);
}

void Polyhedron3_EIK_GetPoints(void* ptr, Point3d* points, int count)
{
	Polyhedron3<EIK>::GetPoints(ptr, points, count);
}

void Polyhedron3_EIK_GetTriangleIndices(void* ptr, int* indices, int count)
{
	Polyhedron3<EIK>::GetTriangleIndices(ptr, indices, count);
}

void Polyhedron3_EIK_Transform(void* ptr, Matrix4x4d matrix)
{
	Polyhedron3<EIK>::Transform(ptr, matrix);
}

void Polyhedron3_EIK_InsideOut(void* ptr)
{
	Polyhedron3<EIK>::InsideOut(ptr);
}

void Polyhedron3_EIK_Triangulate(void* ptr)
{
	Polyhedron3<EIK>::Triangulate(ptr);
}

void Polyhedron3_EIK_NormalizeBorder(void* ptr)
{
	Polyhedron3<EIK>::NormalizeBorder(ptr);
}

BOOL Polyhedron3_EIK_NormalizedBorderIsValid(void* ptr)
{
	return Polyhedron3<EIK>::NormalizedBorderIsValid(ptr);
}