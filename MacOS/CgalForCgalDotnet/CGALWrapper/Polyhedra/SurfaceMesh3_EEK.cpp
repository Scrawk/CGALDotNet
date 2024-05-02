#include "SurfaceMesh3_EEK.h"
#include "SurfaceMesh3.h"

#include <string>


void* SurfaceMesh3_EEK_Create()
{
	return SurfaceMesh3<EEK>::NewSurfaceMesh();
}

void SurfaceMesh3_EEK_Release(void* ptr)
{
	SurfaceMesh3<EEK>::DeleteSurfaceMesh(ptr);
}

int SurfaceMesh3_EEK_GetBuildStamp(void* ptr)
{
	return SurfaceMesh3<EEK>::GetBuildStamp(ptr);
}

void SurfaceMesh3_EEK_Clear(void* ptr)
{
	SurfaceMesh3<EEK>::Clear(ptr);
}

void SurfaceMesh3_EEK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges)
{
	SurfaceMesh3<EEK>::ClearIndexMaps(ptr, vertices, faces, edges, halfedges);
}

void SurfaceMesh3_EEK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces)
{
	SurfaceMesh3<EEK>::ClearNormalMaps(ptr, vertices, faces);
}

void SurfaceMesh3_EEK_ClearProperyMaps(void* ptr)
{
	SurfaceMesh3<EEK>::ClearProperyMaps(ptr);
}

void SurfaceMesh3_EEK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force)
{
	SurfaceMesh3<EEK>::BuildIndices(ptr, vertices, faces, edges, halfedges, force);
}

void SurfaceMesh3_EEK_PrintIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL halfedges, BOOL force)
{
	SurfaceMesh3<EEK>::PrintIndices(ptr, vertices, faces, edges, halfedges, force);
}

void* SurfaceMesh3_EEK_Copy(void* ptr)
{
	return SurfaceMesh3<EEK>::Copy(ptr);
}

BOOL SurfaceMesh3_EEK_IsValid(void* ptr)
{
	return SurfaceMesh3<EEK>::IsValid(ptr);
}

int SurfaceMesh3_EEK_VertexCount(void* ptr)
{
	return SurfaceMesh3<EEK>::VertexCount(ptr);
}

int SurfaceMesh3_EEK_HalfedgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::HalfedgeCount(ptr);
}

int SurfaceMesh3_EEK_EdgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::EdgeCount(ptr);
}

int SurfaceMesh3_EEK_FaceCount(void* ptr)
{
	return SurfaceMesh3<EEK>::FaceCount(ptr);
}

int SurfaceMesh3_EEK_RemovedVertexCount(void* ptr)
{
	return SurfaceMesh3<EEK>::RemovedVertexCount(ptr);
}

int SurfaceMesh3_EEK_RemovedHalfedgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::RemovedHalfedgeCount(ptr);
}

int SurfaceMesh3_EEK_RemovedEdgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::RemovedEdgeCount(ptr);
}

int SurfaceMesh3_EEK_RemovedFaceCount(void* ptr)
{
	return SurfaceMesh3<EEK>::RemovedFaceCount(ptr);
}

BOOL SurfaceMesh3_EEK_IsVertexRemoved(void* ptr, int index) 
{
	return SurfaceMesh3<EEK>::IsVertexRemoved(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsFaceRemoved(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsFaceRemoved(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsHalfedgeRemoved(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsHalfedgeRemoved(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsEdgeRemoved(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsEdgeRemoved(ptr, index);
}

int SurfaceMesh3_EEK_AddVertex(void* ptr, Point3d point)
{
	return SurfaceMesh3<EEK>::AddVertex(ptr, point);
}

int SurfaceMesh3_EEK_AddEdge(void* ptr, int v0, int v1)
{
	return SurfaceMesh3<EEK>::AddEdge(ptr, v0, v1);
}

int SurfaceMesh3_EEK_AddTriangle(void* ptr, int v0, int v1, int v2)
{
	return SurfaceMesh3<EEK>::AddTriangle(ptr, v0, v1, v2);
}

int SurfaceMesh3_EEK_AddQuad(void* ptr, int v0, int v1, int v2, int v3)
{
	return SurfaceMesh3<EEK>::AddQuad(ptr, v0, v1, v2, v3);
}

int SurfaceMesh3_EEK_AddPentagon(void* ptr, int v0, int v1, int v2, int v3, int v4)
{
	return SurfaceMesh3<EEK>::AddPentagon(ptr, v0, v1, v2, v3, v4);
}

int SurfaceMesh3_EEK_AddHexagon(void* ptr, int v0, int v1, int v2, int v3, int v4, int v5)
{
	return SurfaceMesh3<EEK>::AddHexagon(ptr, v0, v1, v2, v3, v4, v5);
}

int SurfaceMesh3_EEK_AddFace(void* ptr, int* indices, int count)
{
	return SurfaceMesh3<EEK>::AddFace(ptr, indices, count);
}

BOOL SurfaceMesh3_EEK_HasGarbage(void* ptr)
{
	return SurfaceMesh3<EEK>::HasGarbage(ptr);
}

void SurfaceMesh3_EEK_CollectGarbage(void* ptr)
{
	SurfaceMesh3<EEK>::CollectGarbage(ptr);
}

void SurfaceMesh3_EEK_SetRecycleGarbage(void* ptr, BOOL collect)
{
	SurfaceMesh3<EEK>::SetRecycleGarbage(ptr, collect);
}

BOOL SurfaceMesh3_EEK_DoesRecycleGarbage(void* ptr)
{
	return SurfaceMesh3<EEK>::DoesRecycleGarbage(ptr);
}

int SurfaceMesh3_EEK_VertexDegree(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::VertexDegree(ptr, index);
}

int SurfaceMesh3_EEK_FaceDegree(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::FaceDegree(ptr, index);
}

BOOL SurfaceMesh3_EEK_VertexIsIsolated(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::VertexIsIsolated(ptr, index);
}

BOOL SurfaceMesh3_EEK_VertexIsBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
{
	return SurfaceMesh3<EEK>::VertexIsBorder(ptr, index, check_all_incident_halfedges);
}

BOOL SurfaceMesh3_EEK_EdgeIsBorder(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::EdgeIsBorder(ptr, index);
}

int SurfaceMesh3_EEK_NextHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::NextHalfedge(ptr, index);
}

int SurfaceMesh3_EEK_PreviousHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::PreviousHalfedge(ptr, index);
}

int SurfaceMesh3_EEK_OppositeHalfedge(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::OppositeHalfedge(ptr, index);
}

int SurfaceMesh3_EEK_SourceVertex(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::SourceVertex(ptr, index);
}

int SurfaceMesh3_EEK_TargetVertex(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::TargetVertex(ptr, index);
}

int SurfaceMesh3_EEK_NextAroundSource(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::NextAroundSource(ptr, index);
}

int SurfaceMesh3_EEK_NextAroundTarget(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::NextAroundTarget(ptr, index);
}

int SurfaceMesh3_EEK_PreviousAroundSource(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::PreviousAroundSource(ptr, index);
}

int SurfaceMesh3_EEK_PreviousAroundTarget(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::PreviousAroundTarget(ptr, index);
}

int SurfaceMesh3_EEK_EdgesHalfedge(void* ptr, int edgeIndex, int halfedgeIndex)
{
	return SurfaceMesh3<EEK>::EdgesHalfedge(ptr, edgeIndex, halfedgeIndex);
}

int SurfaceMesh3_EEK_HalfedgesEdge(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::HalfedgesEdge(ptr, index);
}

BOOL SurfaceMesh3_EEK_RemoveVertex(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::RemoveVertex(ptr, index);
}

BOOL SurfaceMesh3_EEK_RemoveEdge(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::RemoveEdge(ptr, index);
}

BOOL SurfaceMesh3_EEK_RemoveFace(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::RemoveFace(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsVertexValid(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsVertexValid(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsEdgeValid(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsEdgeValid(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsHalfedgeValid(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsHalfedgeValid(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsFaceValid(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsFaceValid(ptr, index);
}

Point3d SurfaceMesh3_EEK_GetPoint(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::GetPoint(ptr, index);
}

void SurfaceMesh3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	SurfaceMesh3<EEK>::GetPoints(ptr, points, count);
}

void SurfaceMesh3_EEK_SetPoint(void* ptr, int index, const Point3d& point)
{
	SurfaceMesh3<EEK>::SetPoint(ptr, index, point);
}

void SurfaceMesh3_EEK_SetPoints(void* ptr, Point3d* points, int count)
{
	SurfaceMesh3<EEK>::SetPoints(ptr, points, count);
}

BOOL SurfaceMesh3_EEK_GetSegment(void* ptr, int index, Segment3d& segment)
{
	return SurfaceMesh3<EEK>::GetSegment(ptr,index, segment);
}

void SurfaceMesh3_EEK_GetSegments(void* ptr, Segment3d* segments, int count)
{
	SurfaceMesh3<EEK>::GetSegments(ptr, segments, count);
}

BOOL SurfaceMesh3_EEK_GetTriangle(void* ptr, int index, Triangle3d& tri)
{
	return SurfaceMesh3<EEK>::GetTriangle(ptr, index, tri);
}

void SurfaceMesh3_EEK_GetTriangles(void* ptr, Triangle3d* triangles, int count)
{
	SurfaceMesh3<EEK>::GetTriangles(ptr, triangles, count);
}

BOOL SurfaceMesh3_EEK_GetVertex(void* ptr, int index, MeshVertex3& vert)
{
	return SurfaceMesh3<EEK>::GetVertex(ptr, index, vert);
}

void SurfaceMesh3_EEK_GetVertices(void* ptr, MeshVertex3* vertexArray, int count)
{
	SurfaceMesh3<EEK>::GetVertices(ptr, vertexArray, count);
}

BOOL SurfaceMesh3_EEK_GetFace(void* ptr, int index, MeshFace3& face)
{
	return SurfaceMesh3<EEK>::GetFace(ptr, index, face);
}

void SurfaceMesh3_EEK_GetFaces(void* ptr, MeshFace3* faceArray, int count)
{
	SurfaceMesh3<EEK>::GetFaces(ptr, faceArray, count);
}

BOOL SurfaceMesh3_EEK_GetHalfedge(void* ptr, int index, MeshHalfedge3& edge)
{
	return SurfaceMesh3<EEK>::GetHalfedge(ptr, index, edge);
}

void SurfaceMesh3_EEK_GetHalfedges(void* ptr, MeshHalfedge3* edgeArray, int count)
{
	SurfaceMesh3<EEK>::GetHalfedges(ptr, edgeArray, count);
}

void SurfaceMesh3_EEK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	SurfaceMesh3<EEK>::Transform(ptr, matrix);
}

BOOL SurfaceMesh3_EEK_IsVertexBorder(void* ptr, int index, BOOL check_all_incident_halfedges)
{
	return SurfaceMesh3<EEK>::IsVertexBorder(ptr, index, check_all_incident_halfedges);
}

BOOL SurfaceMesh3_EEK_IsHalfedgeBorder(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsHalfedgeBorder(ptr, index);
}

BOOL SurfaceMesh3_EEK_IsEdgeBorder(void* ptr, int index)
{
	return SurfaceMesh3<EEK>::IsEdgeBorder(ptr, index);
}

int SurfaceMesh3_EEK_BorderEdgeCount(void* ptr)
{
	return SurfaceMesh3<EEK>::BorderEdgeCount(ptr);
}

BOOL SurfaceMesh3_EEK_IsClosed(void* ptr)
{
	return SurfaceMesh3<EEK>::IsClosed(ptr);
}

void SurfaceMesh3_EEK_Join(void* ptr, void* otherPtr)
{
	SurfaceMesh3<EEK>::Join(ptr, otherPtr);
}

void SurfaceMesh3_EEK_BuildAABBTree(void* ptr)
{
	SurfaceMesh3<EEK>::BuildAABBTree(ptr);
}

void SurfaceMesh3_EEK_ReleaseAABBTree(void* ptr)
{
	SurfaceMesh3<EEK>::ReleaseAABBTree(ptr);
}

Box3d SurfaceMesh3_EEK_GetBoundingBox(void* ptr)
{
	return SurfaceMesh3<EEK>::GetBoundingBox(ptr);
}

void SurfaceMesh3_EEK_ReadOFF(void* ptr, const char* filename)
{
	SurfaceMesh3<EEK>::ReadOFF(ptr, filename);
}

void SurfaceMesh3_EEK_WriteOFF(void* ptr, const char* filename)
{
	SurfaceMesh3<EEK>::WriteOFF(ptr, filename);
}

void SurfaceMesh3_EEK_Triangulate(void* ptr)
{
	SurfaceMesh3<EEK>::Triangulate(ptr);
}

BOOL SurfaceMesh3_EEK_DoesSelfIntersect(void* ptr)
{
	return SurfaceMesh3<EEK>::DoesSelfIntersect(ptr);
}

double SurfaceMesh3_EEK_Area(void* ptr)
{
	return SurfaceMesh3<EEK>::Area(ptr);
}

Point3d SurfaceMesh3_EEK_Centroid(void* ptr)
{
	return SurfaceMesh3<EEK>::Centroid(ptr);
}

double SurfaceMesh3_EEK_Volume(void* ptr)
{
	return SurfaceMesh3<EEK>::Volume(ptr);
}

BOOL SurfaceMesh3_EEK_DoesBoundAVolume(void* ptr)
{
	return SurfaceMesh3<EEK>::DoesBoundAVolume(ptr);
}

CGAL::Bounded_side SurfaceMesh3_EEK_SideOfTriangleMesh(void* ptr, const Point3d& point)
{
	return SurfaceMesh3<EEK>::SideOfTriangleMesh(ptr, point);
}

BOOL SurfaceMesh3_EEK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides)
{
	return SurfaceMesh3<EEK>::DoIntersects(ptr, otherPtr, test_bounded_sides);
 }

void SurfaceMesh3_EEK_GetCentroids(void* ptr, Point3d* points, int count)
{
	SurfaceMesh3<EEK>::GetCentroids(ptr, points, count);
}

int SurfaceMesh3_EEK_PropertyMapCount(void* ptr)
{
	return SurfaceMesh3<EEK>::PropertyMapCount(ptr);
}

void SurfaceMesh3_EEK_ComputeVertexNormals(void* ptr)
{
	SurfaceMesh3<EEK>::ComputeVertexNormals(ptr);
}

void SurfaceMesh3_EEK_ComputeFaceNormals(void* ptr)
{
	SurfaceMesh3<EEK>::ComputeFaceNormals(ptr);
}

void SurfaceMesh3_EEK_GetVertexNormals(void* ptr, Vector3d* normals, int count)
{
	SurfaceMesh3<EEK>::GetVertexNormals(ptr, normals, count);
}

void SurfaceMesh3_EEK_GetFaceNormals(void* ptr, Vector3d* normals, int count)
{
	SurfaceMesh3<EEK>::GetFaceNormals(ptr, normals, count);
}

BOOL SurfaceMesh3_EEK_CheckFaceVertexCount(void* ptr, int count)
{
	return SurfaceMesh3<EEK>::CheckFaceVertexCount(ptr, count);
}

PolygonalCount SurfaceMesh3_EEK_GetPolygonalCount(void* ptr)
{
	return SurfaceMesh3<EEK>::GetPolygonalCount(ptr);
}

PolygonalCount SurfaceMesh3_EEK_GetDualPolygonalCount(void* ptr)
{
	return SurfaceMesh3<EEK>::GetDualPolygonalCount(ptr);
}

void SurfaceMesh3_EEK_CreatePolygonMesh(void* ptr, Point2d* points, int count, BOOL xz)
{
	SurfaceMesh3<EEK>::CreatePolygonMesh(ptr, points, count, xz);
}

void SurfaceMesh3_EEK_CreatePolygonalMesh(void* ptr,
	Point3d* points, int pointsCount,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	SurfaceMesh3<EEK>::CreatePolygonalMesh(ptr,
		points, pointsCount,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

void SurfaceMesh3_EEK_GetPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	SurfaceMesh3<EEK>::GetPolygonalIndices(ptr,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

void SurfaceMesh3_EEK_GetDualPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	SurfaceMesh3<EEK>::GetDualPolygonalIndices(ptr,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

static void GetDualPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{

	typedef typename EEK::FT FT;
	typedef typename EEK::Point_3 Point_3;
	typedef typename CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Edge_index Edge;
	typedef typename SurfaceMesh::Halfedge_index Halfedge;
	typedef typename SurfaceMesh::Vertex_index Vertex;
	typedef typename SurfaceMesh::Face_index Face;

	auto mesh = SurfaceMesh3<EEK>::CastToSurfaceMesh(ptr);
	mesh->BuildModel();

	int triangleIndex = 0;
	int quadIndex = 0;
	int pentagonIndex = 0;
	int hexagonIndex = 0;
	int indices[6];

	ArrayUtil::FillWithNull(triangles, triangleCount);
	ArrayUtil::FillWithNull(quads, quadCount);
	ArrayUtil::FillWithNull(pentagons, pentagonCount);
	ArrayUtil::FillWithNull(hexagons, hexagonCount);


	for (auto face : mesh->model.faces())
	{

		int count = mesh->model.degree(face);

		if (count < 3 || count > 6) continue;

		auto hedge = mesh->model.halfedge(face);
		for (int i = 0; i < count; i++)
		{
			auto face = mesh->model.face(hedge);
			indices[i] = mesh->FindFaceIndex(face);
			hedge = mesh->model.next_around_source(hedge);
		}

		if (count == 3 && triangleIndex < triangleCount)
		{
			triangles[triangleIndex * 3 + 0] = indices[0];
			triangles[triangleIndex * 3 + 1] = indices[1];
			triangles[triangleIndex * 3 + 2] = indices[2];
			triangleIndex++;
		}
		else if (count == 4 && quadIndex < quadCount)
		{
			quads[quadIndex * 4 + 0] = indices[0];
			quads[quadIndex * 4 + 1] = indices[1];
			quads[quadIndex * 4 + 2] = indices[2];
			quads[quadIndex * 4 + 3] = indices[3];
			quadIndex++;
		}
		else if (count == 5 && pentagonIndex < pentagonCount)
		{
			pentagons[pentagonIndex * 5 + 0] = indices[0];
			pentagons[pentagonIndex * 5 + 1] = indices[1];
			pentagons[pentagonIndex * 5 + 2] = indices[2];
			pentagons[pentagonIndex * 5 + 3] = indices[3];
			pentagons[pentagonIndex * 5 + 4] = indices[4];
			pentagonIndex++;
		}
		else if (count == 6 && hexagonIndex < hexagonCount)
		{
			hexagons[hexagonIndex * 6 + 0] = indices[0];
			hexagons[hexagonIndex * 6 + 1] = indices[1];
			hexagons[hexagonIndex * 6 + 2] = indices[2];
			hexagons[hexagonIndex * 6 + 3] = indices[3];
			hexagons[hexagonIndex * 6 + 4] = indices[4];
			hexagons[hexagonIndex * 6 + 5] = indices[5];
			hexagonIndex++;
		}

	}

}







