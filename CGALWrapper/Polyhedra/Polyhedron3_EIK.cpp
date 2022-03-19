#include "Polyhedron3_EIK.h"

#include "Polyhedron3.h"

void* Polyhedron3_EIK_Create()
{
	return Polyhedron3<EIK>::NewPolyhedron();
}

void Polyhedron3_EIK_Release(void* ptr)
{
	Polyhedron3<EIK>::DeletePolyhedron(ptr);
}

int Polyhedron3_EIK_GetBuildStamp(void* ptr)
{
	return Polyhedron3<EIK>::GetBuildStamp(ptr);
}

void Polyhedron3_EIK_Clear(void* ptr)
{
	Polyhedron3<EIK>::Clear(ptr);
}

void Polyhedron3_EIK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges)
{
	Polyhedron3<EIK>::ClearIndexMaps(ptr, vertices, faces, edges);
}

void Polyhedron3_EIK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces)
{
	Polyhedron3<EIK>::ClearNormalMaps(ptr, vertices, faces);
}

void Polyhedron3_EIK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL force)
{
	Polyhedron3<EIK>::BuildIndices(ptr, vertices, faces, edges, force);
}

void* Polyhedron3_EIK_Copy(void* ptr)
{
	return Polyhedron3<EIK>::Copy(ptr);
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

BOOL Polyhedron3_EIK_IsPureTriangle(void* ptr)
{
	return Polyhedron3<EIK>::IsPureTriangle(ptr);
}

BOOL Polyhedron3_EIK_IsPureQuad(void* ptr)
{
	return Polyhedron3<EIK>::IsPureQuad(ptr);
}

Box3d Polyhedron3_EIK_GetBoundingBox(void* ptr)
{
	return Polyhedron3<EIK>::GetBoundingBox(ptr);
}

int Polyhedron3_EIK_MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
{
	return Polyhedron3<EIK>::MakeTetrahedron(ptr, p1, p2, p3, p4);
}

int Polyhedron3_EIK_MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3)
{
	return Polyhedron3<EIK>::MakeTriangle(ptr, p1, p2, p3);
}

Point3d Polyhedron3_EIK_GetPoint(void* ptr, int index)
{
	return Polyhedron3<EIK>::GetPoint(ptr, index);
}

void Polyhedron3_EIK_GetPoints(void* ptr, Point3d* points, int count)
{
	return Polyhedron3<EIK>::GetPoints(ptr, points, count);
}

void Polyhedron3_EIK_SetPoint(void* ptr, int index, const Point3d& point)
{
	Polyhedron3<EIK>::SetPoint(ptr, index, point);
}

void Polyhedron3_EIK_SetPoints(void* ptr, Point3d* points, int count)
{
	Polyhedron3<EIK>::SetPoints(ptr, points, count);
}

BOOL Polyhedron3_EIK_GetSegment(void* ptr, int index, Segment3d& segment)
{
	return Polyhedron3<EIK>::GetSegment(ptr, index, segment);
}

BOOL Polyhedron3_EIK_GetTriangle(void* ptr, int index, Triangle3d& tri)
{
	return Polyhedron3<EIK>::GetTriangle(ptr, index, tri);
}

BOOL Polyhedron3_EIK_GetVertex(void* ptr, int index, MeshVertex3& vert)
{
	return Polyhedron3<EIK>::GetVertex(ptr, index, vert);
}

BOOL Polyhedron3_EIK_GetFace(void* ptr, int index, MeshFace3& face)
{
	return Polyhedron3<EIK>::GetFace(ptr, index, face);
}

BOOL Polyhedron3_EIK_GetHalfedge(void* ptr, int index, MeshHalfedge3& edge)
{
	return Polyhedron3<EIK>::GetHalfedge(ptr, index, edge);
}


void Polyhedron3_EIK_GetSegments(void* ptr, Segment3d* segments, int count)
{
	Polyhedron3<EIK>::GetSegments(ptr, segments, count);
}

void Polyhedron3_EIK_GetTriangles(void* ptr, Triangle3d* triangles, int count)
{
	Polyhedron3<EIK>::GetTriangles(ptr, triangles, count);
}

void Polyhedron3_EIK_GetVertices(void* ptr, MeshVertex3* vertices, int count)
{
	Polyhedron3<EIK>::GetVertices(ptr, vertices, count);
}

void Polyhedron3_EIK_GetFaces(void* ptr, MeshFace3* faces, int count)
{
	Polyhedron3<EIK>::GetFaces(ptr, faces, count);
}

void Polyhedron3_EIK_GetHalfedges(void* ptr, MeshHalfedge3* edges, int count)
{
	Polyhedron3<EIK>::GetHalfedges(ptr, edges, count);
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

CGAL::Bounded_side Polyhedron3_EIK_SideOfTriangleMesh(void* ptr, const Point3d& point)
{
	return Polyhedron3<EIK>::SideOfTriangleMesh(ptr, point);
}

BOOL Polyhedron3_EIK_DoesSelfIntersect(void* ptr)
{
	return Polyhedron3<EIK>::DoesSelfIntersect(ptr);
}

double Polyhedron3_EIK_Area(void* ptr)
{
	return Polyhedron3<EIK>::Area(ptr);
}

Point3d Polyhedron3_EIK_Centroid(void* ptr)
{
	return Polyhedron3<EIK>::Centroid(ptr);
}

double Polyhedron3_EIK_Volume(void* ptr)
{
	return Polyhedron3<EIK>::Volume(ptr);
}

BOOL Polyhedron3_EIK_DoesBoundAVolume(void* ptr)
{
	return Polyhedron3<EIK>::DoesBoundAVolume(ptr);
}

void Polyhedron3_EIK_BuildAABBTree(void* ptr)
{
	Polyhedron3<EIK>::BuildAABBTree(ptr);
}

void Polyhedron3_EIK_ReleaseAABBTree(void* ptr)
{
	Polyhedron3<EIK>::ReleaseAABBTree(ptr);
}

BOOL Polyhedron3_EIK_DoIntersects(void* ptr, void* otherPtr, BOOL test_bounded_sides)
{
	return Polyhedron3<EIK>::DoIntersects(ptr, otherPtr, test_bounded_sides);
}

void Polyhedron3_EIK_ReadOFF(void* ptr, const char* filename)
{
	Polyhedron3<EIK>::ReadOFF(ptr, filename);
}

void Polyhedron3_EIK_WriteOFF(void* ptr, const char* filename)
{
	Polyhedron3<EIK>::WriteOFF(ptr, filename);
}

void Polyhedron3_EIK_GetCentroids(void* ptr, Point3d* points, int count)
{
	Polyhedron3<EIK>::GetCentroids(ptr, points, count);
}

void Polyhedron3_EIK_ComputeVertexNormals(void* ptr)
{
	Polyhedron3<EIK>::ComputeVertexNormals(ptr);
}

void Polyhedron3_EIK_ComputeFaceNormals(void* ptr)
{
	Polyhedron3<EIK>::ComputeFaceNormals(ptr);
}

void Polyhedron3_EIK_GetVertexNormals(void* ptr, Vector3d* normals, int count)
{
	Polyhedron3<EIK>::GetVertexNormals(ptr, normals, count);
}

void Polyhedron3_EIK_GetFaceNormals(void* ptr, Vector3d* normals, int count)
{
	Polyhedron3<EIK>::GetFaceNormals(ptr, normals, count);
}

void Polyhedron3_EIK_CreatePolygonMesh(void* ptr, Point2d* points, int pointsCount, BOOL xz)
{
	Polyhedron3<EIK>::CreatePolygonMesh(ptr, points, pointsCount, xz);
}

PolygonalCount Polyhedron3_EIK_GetPolygonalCount(void* ptr)
{
	return Polyhedron3<EIK>::GetPolygonalCount(ptr);
}

PolygonalCount Polyhedron3_EIK_GetDualPolygonalCount(void* ptr)
{
	return Polyhedron3<EIK>::GetDualPolygonalCount(ptr);
}

void Polyhedron3_EIK_CreatePolygonalMesh(void* ptr,
	Point3d* points, int pointsCount,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	Polyhedron3<EIK>::CreatePolygonalMesh(ptr,
		points, pointsCount,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

void Polyhedron3_EIK_GetPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	Polyhedron3<EIK>::GetPolygonalIndices(ptr,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

void Polyhedron3_EIK_GetDualPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	Polyhedron3<EIK>::GetDualPolygonalIndices(ptr,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

int Polyhedron3_EIK_AddFacetToBorder(void* ptr, int h, int g)
{
	return Polyhedron3<EIK>::AddFacetToBorder(ptr, h, g);
}

int Polyhedron3_EIK_AddVertexAndFacetToBorder(void* ptr, int h, int g)
{
	return Polyhedron3<EIK>::AddVertexAndFacetToBorder(ptr, h, g);
}

int Polyhedron3_EIK_CreateCenterVertex(void* ptr, int h)
{
	return Polyhedron3<EIK>::CreateCenterVertex(ptr, h);
}

int Polyhedron3_EIK_EraseCenterVertex(void* ptr, int h)
{
	return Polyhedron3<EIK>::EraseCenterVertex(ptr, h);
}

BOOL Polyhedron3_EIK_EraseConnectedComponent(void* ptr, int h)
{
	return Polyhedron3<EIK>::EraseConnectedComponent(ptr, h);
}

BOOL Polyhedron3_EIK_EraseFacet(void* ptr, int h)
{
	return Polyhedron3<EIK>::EraseFacet(ptr, h);
}

int Polyhedron3_EIK_FillHole(void* ptr, int h)
{
	return Polyhedron3<EIK>::FillHole(ptr, h);
}

int Polyhedron3_EIK_FlipEdge(void* ptr, int h)
{
	return Polyhedron3<EIK>::FlipEdge(ptr, h);
}

int Polyhedron3_EIK_JoinFacet(void* ptr, int h)
{
	return Polyhedron3<EIK>::JoinFacet(ptr, h);
}

int Polyhedron3_EIK_JoinLoop(void* ptr, int h, int g)
{
	return Polyhedron3<EIK>::JoinLoop(ptr, h, g);
}

int Polyhedron3_EIK_JoinVertex(void* ptr, int h)
{
	return Polyhedron3<EIK>::JoinVertex(ptr, h);
}

int Polyhedron3_EIK_MakeHole(void* ptr, int h)
{
	return Polyhedron3<EIK>::MakeHole(ptr, h);
}

int Polyhedron3_EIK_SplitEdge(void* ptr, int h)
{
	return Polyhedron3<EIK>::SplitEdge(ptr, h);
}

int Polyhedron3_EIK_SplitFacet(void* ptr, int h, int g)
{
	return Polyhedron3<EIK>::SplitFacet(ptr, h, g);
}

int Polyhedron3_EIK_SplitLoop(void* ptr, int h, int g, int k)
{
	return Polyhedron3<EIK>::SplitLoop(ptr, h, g, k);
}

int Polyhedron3_EIK_SplitVertex(void* ptr, int h, int g)
{
	return Polyhedron3<EIK>::SplitVertex(ptr, h, g);
}














