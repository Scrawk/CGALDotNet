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

extern "C"
{
	CGALWRAPPER_API void* SurfaceMesh3_EIK_Create();

	CGALWRAPPER_API void SurfaceMesh3_EIK_Release(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_GetBuildStamp(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_Clear(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges);

	CGALWRAPPER_API void SurfaceMesh3_EIK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces);

	CGALWRAPPER_API	void SurfaceMesh3_EIK_ClearProperyMaps(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force);

	CGALWRAPPER_API void SurfaceMesh3_EIK_PrintIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force);

	CGALWRAPPER_API void* SurfaceMesh3_EIK_Copy(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsValid(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsVertexValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsFaceValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsHalfedgeValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsEdgeValid(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_VertexCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_HalfedgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_EdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_FaceCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_RemovedVertexCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_RemovedHalfedgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_RemovedEdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_RemovedFaceCount(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsVertexRemoved(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsFaceRemoved(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsHalfedgeRemoved(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsEdgeRemoved(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddVertex(void* ptr, Point3d point);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddEdge(void* ptr, int v0, int v1);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddTriangle(void* ptr, int v0, int v1, int v2);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddQuad(void* ptr, int v0, int v1, int v2, int v3);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddPentagon(void* ptr, int v0, int v1, int v2, int v3, int v4);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddHexagon(void* ptr, int v0, int v1, int v2, int v3, int v4, int v5);

	CGALWRAPPER_API int SurfaceMesh3_EIK_AddFace(void* ptr, int* indices, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_HasGarbage(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_CollectGarbage(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_SetRecycleGarbage(void* ptr, BOOL collect);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_DoesRecycleGarbage(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_VertexDegree(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_FaceDegree(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_VertexIsIsolated(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_EdgeIsBorder(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_NextHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_PreviousHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_OppositeHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_SourceVertex(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_TargetVertex(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_NextAroundSource(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_NextAroundTarget(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_PreviousAroundSource(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_PreviousAroundTarget(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_EdgesHalfedge(void* ptr, int edgeIndex, int halfedgeIndex);

	CGALWRAPPER_API int SurfaceMesh3_EIK_HalfedgesEdge(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_RemoveVertex(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_RemoveEdge(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_RemoveFace(void* ptr, int index);

	CGALWRAPPER_API Point3d SurfaceMesh3_EIK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void SurfaceMesh3_EIK_SetPoint(void* ptr, int index, const Point3d& point);

	CGALWRAPPER_API void SurfaceMesh3_EIK_SetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_GetSegment(void* ptr, int index, Segment3d& segment);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetSegments(void* ptr, Segment3d* segments, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_GetTriangle(void* ptr, int index, Triangle3d& tri);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetTriangles(void* ptr, Triangle3d* triangles, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_GetVertex(void* ptr, int index, MeshVertex3& vert);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetVertices(void* ptr, MeshVertex3* vertexArray, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_GetFace(void* ptr, int index, MeshFace3& face);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetFaces(void* ptr, MeshFace3* faceArray, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_GetHalfedge(void* ptr, int index, MeshHalfedge3& edge);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetHalfedges(void* ptr, MeshHalfedge3* edgeArray, int count);

	CGALWRAPPER_API void SurfaceMesh3_EIK_Transform(void* ptr, const Matrix4x4d& matrix);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsHalfedgeBorder(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_IsEdgeBorder(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EIK_BorderEdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EIK_IsClosed(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_CheckFaceVertexCount(void* ptr, int count);

	CGALWRAPPER_API void SurfaceMesh3_EIK_Join(void* ptr, void* otherPtr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_BuildAABBTree(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_ReleaseAABBTree(void* ptr);

	CGALWRAPPER_API Box3d SurfaceMesh3_EIK_GetBoundingBox(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_ReadOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void SurfaceMesh3_EIK_WriteOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void SurfaceMesh3_EIK_Triangulate(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_DoesSelfIntersect(void* ptr);

	CGALWRAPPER_API double SurfaceMesh3_EIK_Area(void* ptr);

	CGALWRAPPER_API Point3d SurfaceMesh3_EIK_Centroid(void* ptr);

	CGALWRAPPER_API double SurfaceMesh3_EIK_Volume(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_DoesBoundAVolume(void* ptr);

	CGALWRAPPER_API CGAL::Bounded_side SurfaceMesh3_EIK_SideOfTriangleMesh(void* ptr, const Point3d& point);

	CGALWRAPPER_API BOOL SurfaceMesh3_EIK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetCentroids(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API int SurfaceMesh3_EIK_PropertyMapCount(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_ComputeVertexNormals(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_ComputeFaceNormals(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetVertexNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetFaceNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API PolygonalCount SurfaceMesh3_EIK_GetPolygonalCount(void* ptr);

	CGALWRAPPER_API PolygonalCount SurfaceMesh3_EIK_GetDualPolygonalCount(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EIK_CreatePolygonMesh(void* ptr, Point2d* points, int count, BOOL xz);

	CGALWRAPPER_API void SurfaceMesh3_EIK_CreatePolygonalMesh(void* ptr,
		Point3d* points, int pointsCount,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API void SurfaceMesh3_EIK_GetDualPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);


}