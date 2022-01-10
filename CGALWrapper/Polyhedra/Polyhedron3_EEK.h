#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"

extern "C"
{
	CGALWRAPPER_API void* Polyhedron3_EEK_Create();

	CGALWRAPPER_API void* Polyhedron3_EEK_CreateFromSize(int vertices, int halfedges, int faces);

	CGALWRAPPER_API void Polyhedron3_EEK_Release(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_Clear(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_FaceCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_BorderEdgeCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_BorderHalfEdgeCount(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsValid(void* ptr, int level);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsClosed(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsPureBivalent(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsPureTrivalent(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsPureTriangle(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsPureQuad(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

	CGALWRAPPER_API void Polyhedron3_EEK_MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3);

	CGALWRAPPER_API void Polyhedron3_EEK_CreateTriangleMesh(void* ptr, Point3d* points, int pointsCount, int* indices, int indicesCount);

	CGALWRAPPER_API void Polyhedron3_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyhedron3_EEK_GetTriangleIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void Polyhedron3_EEK_Transform(void* ptr, Matrix4x4d matrix);

	CGALWRAPPER_API void Polyhedron3_EEK_InsideOut(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_ConvertQuadsToTriangles(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_NormalizeBorder(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_NormalizedBorderIsValid(void* ptr);

}