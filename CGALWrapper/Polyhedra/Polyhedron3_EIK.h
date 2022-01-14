#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"

extern "C"
{
	CGALWRAPPER_API void* Polyhedron3_EIK_Create();

	CGALWRAPPER_API void* Polyhedron3_EIK_CreateFromSize(int vertices, int halfedges, int faces);

	CGALWRAPPER_API void Polyhedron3_EIK_Release(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_Clear(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_VertexCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_FaceCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_BorderEdgeCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_BorderHalfEdgeCount(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsValid(void* ptr, int level);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsClosed(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsPureBivalent(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsPureTrivalent(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_IsPureTriangle(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_IsPureQuad(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

	CGALWRAPPER_API void Polyhedron3_EIK_MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3);

	CGALWRAPPER_API void Polyhedron3_EIK_CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount);

	CGALWRAPPER_API void Polyhedron3_EIK_CreateQuadMesh(void* ptr, Point3d* points, int pointsCount, int* quads, int quadCount);

	CGALWRAPPER_API void Polyhedron3_EIK_CreateTriangleQuadMesh(void* ptr, Point3d* points, int pointsCount, int* triangles, int triangleCount, int* quads, int quadCount);

	CGALWRAPPER_API void Polyhedron3_EIK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_GetTriangleIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_Transform(void* ptr, Matrix4x4d matrix);

	CGALWRAPPER_API void Polyhedron3_EIK_InsideOut(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_Triangulate(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_NormalizeBorder(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_NormalizedBorderIsValid(void* ptr);

}