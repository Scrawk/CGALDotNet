#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "../Geometry/MinMax.h"
#include "PolygonalCount.h"
#include "MeshVertex3.h"
#include "MeshFace3.h"
#include "MeshHalfedge3.h"

#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API void* Polyhedron3_EIK_Create();

	CGALWRAPPER_API void Polyhedron3_EIK_Release(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_Clear(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges);

	CGALWRAPPER_API void Polyhedron3_EIK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces);

	CGALWRAPPER_API void Polyhedron3_EIK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL force);

	CGALWRAPPER_API int Polyhedron3_EIK_GetBuildStamp(void* ptr);

	CGALWRAPPER_API void* Polyhedron3_EIK_Copy(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_VertexCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_FaceCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_BorderEdgeCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_BorderHalfEdgeCount(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsValid(void* ptr, int level);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsClosed(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsPureBivalent(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsPureTrivalent(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsPureTriangle(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_IsPureQuad(void* ptr);

	CGALWRAPPER_API Box3d Polyhedron3_EIK_GetBoundingBox(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EIK_MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

	CGALWRAPPER_API int Polyhedron3_EIK_MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3);

	CGALWRAPPER_API Point3d Polyhedron3_EIK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void Polyhedron3_EIK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_SetPoint(void* ptr, int index, const Point3d& point);

	CGALWRAPPER_API void Polyhedron3_EIK_SetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_GetSegment(void* ptr, int index, Segment3d& segment);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_GetTriangle(void* ptr, int index, Triangle3d& tri);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_GetVertex(void* ptr, int index, MeshVertex3& vert);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_GetFace(void* ptr, int index, MeshFace3& face);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_GetHalfedge(void* ptr, int index, MeshHalfedge3& edge);

	CGALWRAPPER_API void Polyhedron3_EIK_GetSegments(void* ptr, Segment3d* segments, int count);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_GetTriangle(void* ptr, int index, Triangle3d& tri);

	CGALWRAPPER_API void Polyhedron3_EIK_GetTriangles(void* ptr, Triangle3d* triangles, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_GetVertices(void* ptr, MeshVertex3* vertices, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_GetFaces(void* ptr, MeshFace3* faces, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_GetHalfedges(void* ptr, MeshHalfedge3* edges, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_Transform(void* ptr, Matrix4x4d matrix);

	CGALWRAPPER_API void Polyhedron3_EIK_InsideOut(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_Triangulate(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_NormalizeBorder(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_NormalizedBorderIsValid(void* ptr);

	CGALWRAPPER_API CGAL::Bounded_side Polyhedron3_EIK_SideOfTriangleMesh(void* ptr, const Point3d& point);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_DoesSelfIntersect(void* ptr);

	CGALWRAPPER_API double Polyhedron3_EIK_Area(void* ptr);

	CGALWRAPPER_API Point3d Polyhedron3_EIK_Centroid(void* ptr);

	CGALWRAPPER_API double Polyhedron3_EIK_Volume(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_DoesBoundAVolume(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_BuildAABBTree(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_ReleaseAABBTree(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides);

	CGALWRAPPER_API void Polyhedron3_EIK_ReadOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void Polyhedron3_EIK_WriteOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void Polyhedron3_EIK_GetCentroids(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_ComputeVertexNormals(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_ComputeFaceNormals(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_GetVertexNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_GetFaceNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API void Polyhedron3_EIK_CreatePolygonMesh(void* ptr, Point2d* points, int pointsCount, BOOL xz);

	CGALWRAPPER_API PolygonalCount Polyhedron3_EIK_GetPolygonalCount(void* ptr);

	CGALWRAPPER_API PolygonalCount Polyhedron3_EIK_GetDualPolygonalCount(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EIK_CreatePolygonalMesh(void* ptr,
		Point3d* points, int pointsCount,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API void Polyhedron3_EIK_GetPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API void Polyhedron3_EIK_GetDualPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API int Polyhedron3_EIK_AddFacetToBorder(void* ptr, int h, int g);

	CGALWRAPPER_API int Polyhedron3_EIK_AddVertexAndFacetToBorder(void* ptr, int h, int g);

	CGALWRAPPER_API int Polyhedron3_EIK_CreateCenterVertex(void* ptr, int h);

	CGALWRAPPER_API int Polyhedron3_EIK_EraseCenterVertex(void* ptr, int h);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_EraseConnectedComponent(void* ptr, int h);

	CGALWRAPPER_API BOOL Polyhedron3_EIK_EraseFacet(void* ptr, int h);

	CGALWRAPPER_API int Polyhedron3_EIK_FillHole(void* ptr, int h);

	CGALWRAPPER_API int Polyhedron3_EIK_FlipEdge(void* ptr, int h);

	CGALWRAPPER_API int Polyhedron3_EIK_JoinFacet(void* ptr, int h);

	CGALWRAPPER_API int Polyhedron3_EIK_JoinLoop(void* ptr, int h, int g);

	CGALWRAPPER_API int Polyhedron3_EIK_JoinVertex(void* ptr, int h);

	CGALWRAPPER_API int Polyhedron3_EIK_MakeHole(void* ptr, int h);

	CGALWRAPPER_API int Polyhedron3_EIK_SplitEdge(void* ptr, int h);

	CGALWRAPPER_API int Polyhedron3_EIK_SplitFacet(void* ptr, int h, int g);

	CGALWRAPPER_API int Polyhedron3_EIK_SplitLoop(void* ptr, int h, int g, int k);

	CGALWRAPPER_API int Polyhedron3_EIK_SplitVertex(void* ptr, int h, int g);
}