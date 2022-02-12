#include "SurfaceMesh3_EIK.h"
#include "SurfaceMesh3.h"

#include <string>

void* SurfaceMesh3_EIK_Create()
{
	return SurfaceMesh3<EIK>::NewSurfaceMesh();
}

void SurfaceMesh3_EIK_Release(void* ptr)
{
	SurfaceMesh3<EIK>::DeleteSurfaceMesh(ptr);
}

int SurfaceMesh3_EIK_GetBuildStamp(void* ptr)
{
	return SurfaceMesh3<EIK>::GetBuildStamp(ptr);
}

void SurfaceMesh3_EIK_Clear(void* ptr)
{
	SurfaceMesh3<EIK>::Clear(ptr);
}

void SurfaceMesh3_EIK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges)
{
	SurfaceMesh3<EIK>::ClearIndexMaps(ptr, vertices, faces, edges, halfedges);
}

void SurfaceMesh3_EIK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces)
{
	SurfaceMesh3<EIK>::ClearNormalMaps(ptr, vertices, faces);
}

void SurfaceMesh3_EIK_ClearProperyMaps(void* ptr)
{
	SurfaceMesh3<EIK>::ClearProperyMaps(ptr);
}

void SurfaceMesh3_EIK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force)
{
	SurfaceMesh3<EIK>::BuildIndices(ptr, vertices, faces, edges, halfedges, force);
}

void SurfaceMesh3_EIK_PrintIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force)
{
	SurfaceMesh3<EIK>::PrintIndices(ptr, vertices, faces, edges, halfedges, force);
}

void* SurfaceMesh3_EIK_Copy(void* ptr)
{
	return SurfaceMesh3<EIK>::Copy(ptr);
}

BOOL SurfaceMesh3_EIK_IsValid(void* ptr)
{
	return SurfaceMesh3<EIK>::IsValid(ptr);
}

int SurfaceMesh3_EIK_VertexCount(void* ptr)
{
	return SurfaceMesh3<EIK>::VertexCount(ptr);
}

int SurfaceMesh3_EIK_HalfedgeCount(void* ptr)
{
	return SurfaceMesh3<EIK>::HalfedgeCount(ptr);
}

int SurfaceMesh3_EIK_EdgeCount(void* ptr)
{
	return SurfaceMesh3<EIK>::EdgeCount(ptr);
}

int SurfaceMesh3_EIK_FaceCount(void* ptr)
{
	return SurfaceMesh3<EIK>::FaceCount(ptr);
}

int SurfaceMesh3_EIK_RemovedVertexCount(void* ptr)
{
	return SurfaceMesh3<EIK>::RemovedVertexCount(ptr);
}

int SurfaceMesh3_EIK_RemovedHalfedgeCount(void* ptr)
{
	return SurfaceMesh3<EIK>::RemovedHalfedgeCount(ptr);
}

int SurfaceMesh3_EIK_RemovedEdgeCount(void* ptr)
{
	return SurfaceMesh3<EIK>::RemovedEdgeCount(ptr);
}

int SurfaceMesh3_EIK_RemovedFaceCount(void* ptr)
{
	return SurfaceMesh3<EIK>::RemovedFaceCount(ptr);
}

BOOL SurfaceMesh3_EIK_IsVertexRemoved(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsVertexRemoved(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsFaceRemoved(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsFaceRemoved(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsHalfedgeRemoved(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsHalfedgeRemoved(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsEdgeRemoved(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsEdgeRemoved(ptr, index);
}

int SurfaceMesh3_EIK_AddVertex(void* ptr, Point3d point)
{
	return SurfaceMesh3<EIK>::AddVertex(ptr, point);
}

int SurfaceMesh3_EIK_AddEdge(void* ptr, int v0, int v1)
{
	return SurfaceMesh3<EIK>::AddEdge(ptr, v0, v1);
}

int SurfaceMesh3_EIK_AddTriangle(void* ptr, int v0, int v1, int v2)
{
	return SurfaceMesh3<EIK>::AddTriangle(ptr, v0, v1, v2);
}

int SurfaceMesh3_EIK_AddQuad(void* ptr, int v0, int v1, int v2, int v3)
{
	return SurfaceMesh3<EIK>::AddQuad(ptr, v0, v1, v2, v3);
}

int SurfaceMesh3_EIK_AddPentagon(void* ptr, int v0, int v1, int v2, int v3, int v4)
{
	return SurfaceMesh3<EIK>::AddPentagon(ptr, v0, v1, v2, v3, v4);
}

int SurfaceMesh3_EIK_AddHexagon(void* ptr, int v0, int v1, int v2, int v3, int v4, int v5)
{
	return SurfaceMesh3<EIK>::AddHexagon(ptr, v0, v1, v2, v3, v4, v5);
}

int SurfaceMesh3_EIK_AddFace(void* ptr, int* indices, int count)
{
	return SurfaceMesh3<EIK>::AddFace(ptr, indices, count);
}

BOOL SurfaceMesh3_EIK_HasGarbage(void* ptr)
{
	return SurfaceMesh3<EIK>::HasGarbage(ptr);
}

void SurfaceMesh3_EIK_CollectGarbage(void* ptr)
{
	SurfaceMesh3<EIK>::CollectGarbage(ptr);
}

void SurfaceMesh3_EIK_SetRecycleGarbage(void* ptr, BOOL collect)
{
	SurfaceMesh3<EIK>::SetRecycleGarbage(ptr, collect);
}

BOOL SurfaceMesh3_EIK_DoesRecycleGarbage(void* ptr)
{
	return SurfaceMesh3<EIK>::DoesRecycleGarbage(ptr);
}

int SurfaceMesh3_EIK_VertexDegree(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::VertexDegree(ptr, index);
}

int SurfaceMesh3_EIK_FaceDegree(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::FaceDegree(ptr, index);
}

BOOL SurfaceMesh3_EIK_VertexIsIsolated(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::VertexIsIsolated(ptr, index);
}

BOOL SurfaceMesh3_EIK_VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
{
	return SurfaceMesh3<EIK>::VertexIsBorder(ptr, index, check_all_incident_halfedges);
}

BOOL SurfaceMesh3_EIK_EdgeIsBorder(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::EdgeIsBorder(ptr, index);
}

int SurfaceMesh3_EIK_NextHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::NextHalfedge(ptr, index);
}

int SurfaceMesh3_EIK_PreviousHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::PreviousHalfedge(ptr, index);
}

int SurfaceMesh3_EIK_OppositeHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::OppositeHalfedge(ptr, index);
}

int SurfaceMesh3_EIK_SourceVertex(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::SourceVertex(ptr, index);
}

int SurfaceMesh3_EIK_TargetVertex(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::TargetVertex(ptr, index);
}

int SurfaceMesh3_EIK_NextAroundSource(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::NextAroundSource(ptr, index);
}

int SurfaceMesh3_EIK_NextAroundTarget(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::NextAroundTarget(ptr, index);
}

int SurfaceMesh3_EIK_PreviousAroundSource(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::PreviousAroundSource(ptr, index);
}

int SurfaceMesh3_EIK_PreviousAroundTarget(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::PreviousAroundTarget(ptr, index);
}

int SurfaceMesh3_EIK_EdgesHalfedge(void* ptr, int edgeIndex, int halfedgeIndex)
{
	return SurfaceMesh3<EIK>::EdgesHalfedge(ptr, edgeIndex, halfedgeIndex);
}

int SurfaceMesh3_EIK_HalfedgesEdge(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::HalfedgesEdge(ptr, index);
}

BOOL SurfaceMesh3_EIK_RemoveVertex(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::RemoveVertex(ptr, index);
}

BOOL SurfaceMesh3_EIK_RemoveEdge(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::RemoveEdge(ptr, index);
}

BOOL SurfaceMesh3_EIK_RemoveFace(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::RemoveFace(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsVertexValid(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsVertexValid(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsEdgeValid(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsEdgeValid(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsHalfedgeValid(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsHalfedgeValid(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsFaceValid(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsFaceValid(ptr, index);
}

Point3d SurfaceMesh3_EIK_GetPoint(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::GetPoint(ptr, index);
}

void SurfaceMesh3_EIK_GetPoints(void* ptr, Point3d* points, int count)
{
	SurfaceMesh3<EIK>::GetPoints(ptr, points, count);
}

void SurfaceMesh3_EIK_SetPoint(void* ptr, int index, const Point3d& point)
{
	SurfaceMesh3<EIK>::SetPoint(ptr, index, point);
}

void SurfaceMesh3_EIK_SetPoints(void* ptr, Point3d* points, int count)
{
	SurfaceMesh3<EIK>::SetPoints(ptr, points, count);
}

BOOL SurfaceMesh3_EIK_GetSegment(void* ptr, int index, Segment3d& segment)
{
	return SurfaceMesh3<EIK>::GetSegment(ptr, index, segment);
}

void SurfaceMesh3_EIK_GetSegments(void* ptr, Segment3d* segments, int count)
{
	SurfaceMesh3<EIK>::GetSegments(ptr, segments, count);
}

BOOL SurfaceMesh3_EIK_GetTriangle(void* ptr, int index, Triangle3d& tri)
{
	return SurfaceMesh3<EIK>::GetTriangle(ptr, index, tri);
}

void SurfaceMesh3_EIK_GetTriangles(void* ptr, Triangle3d* triangles, int count)
{
	SurfaceMesh3<EIK>::GetTriangles(ptr, triangles, count);
}

BOOL SurfaceMesh3_EIK_GetVertex(void* ptr, int index, MeshVertex3& vert)
{
	return SurfaceMesh3<EIK>::GetVertex(ptr, index, vert);
}

void SurfaceMesh3_EIK_GetVertices(void* ptr, MeshVertex3* vertexArray, int count)
{
	SurfaceMesh3<EIK>::GetVertices(ptr, vertexArray, count);
}

BOOL SurfaceMesh3_EIK_GetFace(void* ptr, int index, MeshFace3& face)
{
	return SurfaceMesh3<EIK>::GetFace(ptr, index, face);
}

void SurfaceMesh3_EIK_GetFaces(void* ptr, MeshFace3* faceArray, int count)
{
	SurfaceMesh3<EIK>::GetFaces(ptr, faceArray, count);
}

BOOL SurfaceMesh3_EIK_GetHalfedge(void* ptr, int index, MeshHalfedge3& edge)
{
	return SurfaceMesh3<EIK>::GetHalfedge(ptr, index, edge);
}

void SurfaceMesh3_EIK_GetHalfedges(void* ptr, MeshHalfedge3* edgeArray, int count)
{
	SurfaceMesh3<EIK>::GetHalfedges(ptr, edgeArray, count);
}

void SurfaceMesh3_EIK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	SurfaceMesh3<EIK>::Transform(ptr, matrix);
}

BOOL SurfaceMesh3_EIK_IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
{
	return SurfaceMesh3<EIK>::IsVertexBorder(ptr, index, check_all_incident_halfedges);
}

BOOL SurfaceMesh3_EIK_IsHalfedgeBorder(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsHalfedgeBorder(ptr, index);
}

BOOL SurfaceMesh3_EIK_IsEdgeBorder(void* ptr, int index)
{
	return SurfaceMesh3<EIK>::IsEdgeBorder(ptr, index);
}

int SurfaceMesh3_EIK_BorderEdgeCount(void* ptr)
{
	return SurfaceMesh3<EIK>::BorderEdgeCount(ptr);
}

BOOL SurfaceMesh3_EIK_IsClosed(void* ptr)
{
	return SurfaceMesh3<EIK>::IsClosed(ptr);
}

void SurfaceMesh3_EIK_Join(void* ptr, void* otherPtr)
{
	SurfaceMesh3<EIK>::Join(ptr, otherPtr);
}

void SurfaceMesh3_EIK_BuildAABBTree(void* ptr)
{
	SurfaceMesh3<EIK>::BuildAABBTree(ptr);
}

void SurfaceMesh3_EIK_ReleaseAABBTree(void* ptr)
{
	SurfaceMesh3<EIK>::ReleaseAABBTree(ptr);
}

Box3d SurfaceMesh3_EIK_GetBoundingBox(void* ptr)
{
	return SurfaceMesh3<EIK>::GetBoundingBox(ptr);
}

void SurfaceMesh3_EIK_ReadOFF(void* ptr, const char* filename)
{
	SurfaceMesh3<EIK>::ReadOFF(ptr, filename);
}

void SurfaceMesh3_EIK_WriteOFF(void* ptr, const char* filename)
{
	SurfaceMesh3<EIK>::WriteOFF(ptr, filename);
}

void SurfaceMesh3_EIK_Triangulate(void* ptr)
{
	SurfaceMesh3<EIK>::Triangulate(ptr);
}

BOOL SurfaceMesh3_EIK_DoesSelfIntersect(void* ptr)
{
	return SurfaceMesh3<EIK>::DoesSelfIntersect(ptr);
}

double SurfaceMesh3_EIK_Area(void* ptr)
{
	return SurfaceMesh3<EIK>::Area(ptr);
}

Point3d SurfaceMesh3_EIK_Centroid(void* ptr)
{
	return SurfaceMesh3<EIK>::Centroid(ptr);
}

double SurfaceMesh3_EIK_Volume(void* ptr)
{
	return SurfaceMesh3<EIK>::Volume(ptr);
}

BOOL SurfaceMesh3_EIK_DoesBoundAVolume(void* ptr)
{
	return SurfaceMesh3<EIK>::DoesBoundAVolume(ptr);
}

CGAL::Bounded_side SurfaceMesh3_EIK_SideOfTriangleMesh(void* ptr, const Point3d& point)
{
	return SurfaceMesh3<EIK>::SideOfTriangleMesh(ptr, point);
}

BOOL SurfaceMesh3_EIK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides)
{
	return SurfaceMesh3<EIK>::DoIntersects(ptr, otherPtr, test_bounded_sides);
}

void SurfaceMesh3_EIK_GetCentroids(void* ptr, Point3d* points, int count)
{
	SurfaceMesh3<EIK>::GetCentroids(ptr, points, count);
}

int SurfaceMesh3_EIK_PropertyMapCount(void* ptr)
{
	return SurfaceMesh3<EIK>::PropertyMapCount(ptr);
}

void SurfaceMesh3_EIK_ComputeVertexNormals(void* ptr)
{
	SurfaceMesh3<EIK>::ComputeVertexNormals(ptr);
}

void SurfaceMesh3_EIK_ComputeFaceNormals(void* ptr)
{
	SurfaceMesh3<EIK>::ComputeFaceNormals(ptr);
}

void SurfaceMesh3_EIK_GetVertexNormals(void* ptr, Vector3d* normals, int count)
{
	SurfaceMesh3<EIK>::GetVertexNormals(ptr, normals, count);
}

void SurfaceMesh3_EIK_GetFaceNormals(void* ptr, Vector3d* normals, int count)
{
	SurfaceMesh3<EIK>::GetFaceNormals(ptr, normals, count);
}

BOOL SurfaceMesh3_EIK_CheckFaceVertexCount(void* ptr, int count)
{
	return SurfaceMesh3<EIK>::CheckFaceVertexCount(ptr, count);
}

PolygonalCount SurfaceMesh3_EIK_GetPolygonalCount(void* ptr)
{
	return SurfaceMesh3<EIK>::GetPolygonalCount(ptr);
}

PolygonalCount SurfaceMesh3_EIK_GetDualPolygonalCount(void* ptr)
{
	return SurfaceMesh3<EIK>::GetDualPolygonalCount(ptr);
}

void SurfaceMesh3_EIK_CreatePolygonMesh(void* ptr, Point2d* points, int count, BOOL xz)
{
	SurfaceMesh3<EIK>::CreatePolygonMesh(ptr, points, count, xz);
}

void SurfaceMesh3_EIK_CreatePolygonalMesh(void* ptr,
	Point3d* points, int pointsCount,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	SurfaceMesh3<EIK>::CreatePolygonalMesh(ptr,
		points, pointsCount,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

void SurfaceMesh3_EIK_GetPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	SurfaceMesh3<EIK>::GetPolygonalIndices(ptr,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

void SurfaceMesh3_EIK_GetDualPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	SurfaceMesh3<EIK>::GetDualPolygonalIndices(ptr,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}







