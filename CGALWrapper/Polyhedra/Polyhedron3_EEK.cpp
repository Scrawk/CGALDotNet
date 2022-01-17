#include "Polyhedron3_EEK.h"

#include "Polyhedron3.h"

void* Polyhedron3_EEK_Create()
{
	return Polyhedron3<EEK>::NewPolyhedron();
}

void Polyhedron3_EEK_Release(void* ptr)
{
	Polyhedron3<EEK>::DeletePolyhedron(ptr);
}

void Polyhedron3_EEK_Clear(void* ptr)
{
	Polyhedron3<EEK>::Clear(ptr);
}

void* Polyhedron3_EEK_Copy(void* ptr)
{
	return Polyhedron3<EEK>::Copy(ptr);
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

int Polyhedron3_EEK_IsPureTriangle(void* ptr)
{
	return Polyhedron3<EEK>::IsPureTriangle(ptr);
}

int Polyhedron3_EEK_IsPureQuad(void* ptr)
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

void Polyhedron3_EEK_CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount)
{
	Polyhedron3<EEK>::CreateTriangleMesh(ptr, points, pointsCount, triangles, triangleCount);
}

void Polyhedron3_EEK_CreateQuadMesh(void* ptr, Point3d* points, int pointsCount, int* quads, int quadCount)
{
	Polyhedron3<EEK>::CreateQuadMesh(ptr, points, pointsCount, quads, quadCount);
}

void Polyhedron3_EEK_CreateTriangleQuadMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount, int* quads, int quadCount)
{
	Polyhedron3<EEK>::CreateTriangleQuadMesh(ptr, points, pointsCount, triangles, triangleCount, quads, quadCount);
}

void Polyhedron3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	Polyhedron3<EEK>::GetPoints(ptr, points, count);
}

PrimativeCount Polyhedron3_EEK_GetPrimativeCount(void* ptr)
{
	return Polyhedron3<EEK>::GetPrimativeCount(ptr);
}

void Polyhedron3_EEK_GetTriangleIndices(void* ptr, int* indices, int count)
{
	Polyhedron3<EEK>::GetTriangleIndices(ptr, indices, count);
}

void Polyhedron3_EEK_GetQuadIndices(void* ptr, int* indices, int count)
{
	Polyhedron3<EEK>::GetQuadIndices(ptr, indices, count);
}

void Polyhedron3_EEK_Transform(void* ptr, Matrix4x4d matrix)
{
	Polyhedron3<EEK>::Transform(ptr, matrix);
}

void Polyhedron3_EEK_InsideOut(void* ptr)
{
	Polyhedron3<EEK>::InsideOut(ptr);
}

void Polyhedron3_EEK_Triangulate(void* ptr)
{
	Polyhedron3<EEK>::Triangulate(ptr);
}

void Polyhedron3_EEK_NormalizeBorder(void* ptr)
{
	Polyhedron3<EEK>::NormalizeBorder(ptr);
}

BOOL Polyhedron3_EEK_NormalizedBorderIsValid(void* ptr)
{
	return Polyhedron3<EEK>::NormalizedBorderIsValid(ptr);
}

CGAL::Bounded_side Polyhedron3_EEK_SideOfTriangleMesh(void* ptr, const Point3d& point)
{
	return Polyhedron3<EEK>::SideOfTriangleMesh(ptr, point);
}

BOOL Polyhedron3_EEK_DoesSelfIntersect(void* ptr)
{
	return Polyhedron3<EEK>::DoesSelfIntersect(ptr);
}

double Polyhedron3_EEK_Area(void* ptr)
{
	return Polyhedron3<EEK>::Area(ptr);
}

Point3d Polyhedron3_EEK_Centroid(void* ptr)
{
	return Polyhedron3<EEK>::Centroid(ptr);
}

double Polyhedron3_EEK_Volume(void* ptr)
{
	return Polyhedron3<EEK>::Volume(ptr);
}

BOOL Polyhedron3_EEK_DoesBoundAVolume(void* ptr)
{
	return Polyhedron3<EEK>::DoesBoundAVolume(ptr);
}

void Polyhedron3_EEK_BuildAABBTree(void* ptr)
{
	Polyhedron3<EEK>::BuildAABBTree(ptr);
}

void Polyhedron3_EEK_ReleaseAABBTree(void* ptr)
{
	Polyhedron3<EEK>::ReleaseAABBTree(ptr);
}

BOOL Polyhedron3_EEK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides)
{
	return Polyhedron3<EEK>::DoIntersects(ptr, otherPtr, test_bounded_sides);
}

void Polyhedron3_EEK_ReadOFF(void* ptr, const char* filename)
{
	Polyhedron3<EEK>::ReadOFF(ptr, filename);
}

void Polyhedron3_EEK_WriteOFF(void* ptr, const char* filename)
{
	Polyhedron3<EEK>::WriteOFF(ptr, filename);
}

MinMaxAvg Polyhedron3_EEK_MinMaxEdgeLength(void* ptr)
{
	return Polyhedron3<EEK>::MinMaxEdgeLength(ptr);
}

void Polyhedron3_EEK_GetCentroids(void* ptr, Point3d* points, int count)
{
	Polyhedron3<EEK>::GetCentroids(ptr, points, count);
}
