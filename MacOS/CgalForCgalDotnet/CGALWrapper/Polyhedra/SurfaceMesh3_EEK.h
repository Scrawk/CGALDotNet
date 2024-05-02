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
	CGALWRAPPER_API void* SurfaceMesh3_EEK_Create();

	CGALWRAPPER_API void SurfaceMesh3_EEK_Release(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_GetBuildStamp(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Clear(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces);

	CGALWRAPPER_API	void SurfaceMesh3_EEK_ClearProperyMaps(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force);

	CGALWRAPPER_API void SurfaceMesh3_EEK_PrintIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force);

	CGALWRAPPER_API void* SurfaceMesh3_EEK_Copy(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsValid(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsVertexValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsFaceValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsHalfedgeValid(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsEdgeValid(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_HalfedgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_EdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_FaceCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_RemovedVertexCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_RemovedHalfedgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_RemovedEdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_RemovedFaceCount(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsVertexRemoved(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsFaceRemoved(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsHalfedgeRemoved(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsEdgeRemoved(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddVertex(void* ptr, Point3d point);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddEdge(void* ptr, int v0, int v1);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddTriangle(void* ptr, int v0, int v1, int v2);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddQuad(void* ptr, int v0, int v1, int v2, int v3);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddPentagon(void* ptr, int v0, int v1, int v2, int v3, int v4);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddHexagon(void* ptr, int v0, int v1, int v2, int v3, int v4, int v5);

	CGALWRAPPER_API int SurfaceMesh3_EEK_AddFace(void* ptr, int* indices, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_HasGarbage(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_CollectGarbage(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_SetRecycleGarbage(void* ptr, BOOL collect);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_DoesRecycleGarbage(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_VertexDegree(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_FaceDegree(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_VertexIsIsolated(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_EdgeIsBorder(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_NextHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_PreviousHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_OppositeHalfedge(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_SourceVertex(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_TargetVertex(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_NextAroundSource(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_NextAroundTarget(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_PreviousAroundSource(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_PreviousAroundTarget(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_EdgesHalfedge(void* ptr, int edgeIndex, int halfedgeIndex);

	CGALWRAPPER_API int SurfaceMesh3_EEK_HalfedgesEdge(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_RemoveVertex(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_RemoveEdge(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_RemoveFace(void* ptr, int index);

	CGALWRAPPER_API Point3d SurfaceMesh3_EEK_GetPoint(void* ptr, int index);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void SurfaceMesh3_EEK_SetPoint(void* ptr, int index, const Point3d& point);

	CGALWRAPPER_API void SurfaceMesh3_EEK_SetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_GetSegment(void* ptr, int index, Segment3d& segment);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetSegments(void* ptr, Segment3d* segments, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_GetTriangle(void* ptr, int index, Triangle3d& tri);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetTriangles(void* ptr, Triangle3d* triangles, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_GetVertex(void* ptr, int index, MeshVertex3& vert);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetVertices(void* ptr, MeshVertex3* vertexArray, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_GetFace(void* ptr, int index, MeshFace3& face);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetFaces(void* ptr, MeshFace3* faceArray, int count);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_GetHalfedge(void* ptr, int index, MeshHalfedge3& edge);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetHalfedges(void* ptr, MeshHalfedge3* edgeArray, int count);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Transform(void* ptr, const Matrix4x4d& matrix);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsHalfedgeBorder(void* ptr, int index);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_IsEdgeBorder(void* ptr, int index);

	CGALWRAPPER_API int SurfaceMesh3_EEK_BorderEdgeCount(void* ptr);

	CGALWRAPPER_API int SurfaceMesh3_EEK_IsClosed(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_CheckFaceVertexCount(void* ptr, int count);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Join(void* ptr, void* otherPtr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_BuildAABBTree(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ReleaseAABBTree(void* ptr);

	CGALWRAPPER_API Box3d SurfaceMesh3_EEK_GetBoundingBox(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ReadOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void SurfaceMesh3_EEK_WriteOFF(void* ptr, const char* filename);

	CGALWRAPPER_API void SurfaceMesh3_EEK_Triangulate(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_DoesSelfIntersect(void* ptr);

	CGALWRAPPER_API double SurfaceMesh3_EEK_Area(void* ptr);

	CGALWRAPPER_API Point3d SurfaceMesh3_EEK_Centroid(void* ptr);

	CGALWRAPPER_API double SurfaceMesh3_EEK_Volume(void* ptr);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_DoesBoundAVolume(void* ptr);

	CGALWRAPPER_API CGAL::Bounded_side SurfaceMesh3_EEK_SideOfTriangleMesh(void* ptr, const Point3d& point);

	CGALWRAPPER_API BOOL SurfaceMesh3_EEK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetCentroids(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API int SurfaceMesh3_EEK_PropertyMapCount(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ComputeVertexNormals(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_ComputeFaceNormals(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetVertexNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetFaceNormals(void* ptr, Vector3d* normals, int count);

	CGALWRAPPER_API PolygonalCount SurfaceMesh3_EEK_GetPolygonalCount(void* ptr);

	CGALWRAPPER_API PolygonalCount SurfaceMesh3_EEK_GetDualPolygonalCount(void* ptr);

	CGALWRAPPER_API void SurfaceMesh3_EEK_CreatePolygonMesh(void* ptr, Point2d* points, int count, BOOL xz);

	CGALWRAPPER_API void SurfaceMesh3_EEK_CreatePolygonalMesh(void* ptr,
		Point3d* points, int pointsCount,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);

	CGALWRAPPER_API void SurfaceMesh3_EEK_GetDualPolygonalIndices(void* ptr,
		int* triangles, int triangleCount,
		int* quads, int quadCount,
		int* pentagons, int pentagonCount,
		int* hexagons, int hexagonCount);


}