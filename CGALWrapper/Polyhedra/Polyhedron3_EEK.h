#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "FaceVertexCount.h"

#include <CGAL/enum.h>

extern "C"
{
	
	CGALWRAPPER_API void* Polyhedron3_EEK_Create();

	CGALWRAPPER_API void Polyhedron3_EEK_Release(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_Clear(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges);

	CGALWRAPPER_API void Polyhedron3_EEK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces);

	CGALWRAPPER_API void Polyhedron3_EEK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL force);

	CGALWRAPPER_API int Polyhedron3_EEK_GetBuildStamp(void* ptr);

	CGALWRAPPER_API void* Polyhedron3_EEK_Copy(void* ptr);
	
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

	CGALWRAPPER_API Box3d Polyhedron3_EEK_GetBoundingBox(void* ptr);
	
	CGALWRAPPER_API void Polyhedron3_EEK_MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

	CGALWRAPPER_API void Polyhedron3_EEK_MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3);

	CGALWRAPPER_API void Polyhedron3_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyhedron3_EEK_Transform(void* ptr, Matrix4x4d matrix);

	CGALWRAPPER_API void Polyhedron3_EEK_InsideOut(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_Triangulate(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_NormalizeBorder(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_NormalizedBorderIsValid(void* ptr);

	CGALWRAPPER_API CGAL::Bounded_side Polyhedron3_EEK_SideOfTriangleMesh(void* ptr, const Point3d& point);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_DoesSelfIntersect(void* ptr);

	CGALWRAPPER_API double Polyhedron3_EEK_Area(void* ptr);

	CGALWRAPPER_API Point3d Polyhedron3_EEK_Centroid(void* ptr);

	CGALWRAPPER_API double Polyhedron3_EEK_Volume(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_DoesBoundAVolume(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_BuildAABBTree(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_ReleaseAABBTree(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides);

	CGALWRAPPER_API void Polyhedron3_EEK_ReadOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void Polyhedron3_EEK_WriteOFF(void* ptr, const char* filename);

	CGALWRAPPER_API MinMaxAvg Polyhedron3_EEK_MinMaxEdgeLength(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_GetCentroids(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyhedron3_EEK_ComputeVertexNormals(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_ComputeFaceNormals(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_GetVertexNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API void Polyhedron3_EEK_GetFaceNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API void Polyhedron3_EEK_CreatePolygonMesh(void* ptr, Point2d* points, int pointsCount, BOOL xz);

	CGALWRAPPER_API FaceVertexCount Polyhedron3_EEK_GetFaceVertexCount(void* ptr);

	CGALWRAPPER_API FaceVertexCount Polyhedron3_EEK_GetDualFaceVertexCount(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_CreatePolygonalMesh(void* ptr,
		Point3d* points, int pointsCount,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API void Polyhedron3_EEK_GetPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API void Polyhedron3_EEK_GetDualPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);
}