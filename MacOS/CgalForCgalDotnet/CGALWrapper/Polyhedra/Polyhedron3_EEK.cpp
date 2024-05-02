#include "Polyhedron3_EEK.h"

#include "Polyhedron3.h"
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>

void* Polyhedron3_EEK_Create()
{
	return Polyhedron3<EEK>::NewPolyhedron();
}

void Polyhedron3_EEK_Release(void* ptr)
{
	Polyhedron3<EEK>::DeletePolyhedron(ptr);
}

int Polyhedron3_EEK_GetBuildStamp(void* ptr)
{
	return Polyhedron3<EEK>::GetBuildStamp(ptr);
}

void Polyhedron3_EEK_Clear(void* ptr)
{
	Polyhedron3<EEK>::Clear(ptr);
}

void Polyhedron3_EEK_ClearIndexMaps(void* ptr, BOOL vertices, BOOL faces, BOOL edges)
{
	Polyhedron3<EEK>::ClearIndexMaps(ptr, vertices, faces, edges);
}

void Polyhedron3_EEK_ClearNormalMaps(void* ptr, BOOL vertices, BOOL faces)
{
	Polyhedron3<EEK>::ClearNormalMaps(ptr, vertices, faces);
}

void Polyhedron3_EEK_BuildIndices(void* ptr, BOOL vertices, BOOL faces, BOOL edges, BOOL force)
{
	Polyhedron3<EEK>::BuildIndices(ptr, vertices, faces, edges, force);
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

BOOL Polyhedron3_EEK_IsPureTriangle(void* ptr)
{
	return Polyhedron3<EEK>::IsPureTriangle(ptr);
}

BOOL Polyhedron3_EEK_IsPureQuad(void* ptr)
{
	return Polyhedron3<EEK>::IsPureQuad(ptr);
}

Box3d Polyhedron3_EEK_GetBoundingBox(void* ptr)
{
	return Polyhedron3<EEK>::GetBoundingBox(ptr);
}

int Polyhedron3_EEK_MakeTetrahedron(void* ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
{
	return Polyhedron3<EEK>::MakeTetrahedron(ptr, p1, p2, p3, p4);
}

int Polyhedron3_EEK_MakeTriangle(void* ptr, Point3d p1, Point3d p2, Point3d p3)
{
	return Polyhedron3<EEK>::MakeTriangle(ptr, p1, p2, p3);
}

Point3d Polyhedron3_EEK_GetPoint(void* ptr, int index)
{
	return Polyhedron3<EEK>::GetPoint(ptr, index);
}

void Polyhedron3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	return Polyhedron3<EEK>::GetPoints(ptr, points, count);
}

void Polyhedron3_EEK_SetPoint(void* ptr, int index, const Point3d& point)
{
	Polyhedron3<EEK>::SetPoint(ptr, index, point);
}

void Polyhedron3_EEK_SetPoints(void* ptr, Point3d* points, int count)
{
	Polyhedron3<EEK>::SetPoints(ptr, points, count);
}

BOOL Polyhedron3_EEK_GetSegment(void* ptr, int index, Segment3d& segment)
{
	return Polyhedron3<EEK>::GetSegment(ptr, index, segment);
}

BOOL Polyhedron3_EEK_GetTriangle(void* ptr, int index, Triangle3d& tri)
{
	return Polyhedron3<EEK>::GetTriangle(ptr, index, tri);
}

BOOL Polyhedron3_EEK_GetVertex(void* ptr, int index, MeshVertex3& vert)
{
	return Polyhedron3<EEK>::GetVertex(ptr, index, vert);
}

BOOL Polyhedron3_EEK_GetFace(void* ptr, int index, MeshFace3& face)
{
	return Polyhedron3<EEK>::GetFace(ptr, index, face);
}

BOOL Polyhedron3_EEK_GetHalfedge(void* ptr, int index, MeshHalfedge3& edge)
{
	return Polyhedron3<EEK>::GetHalfedge(ptr, index, edge);
}


void Polyhedron3_EEK_GetSegments(void* ptr, Segment3d* segments, int count)
{
	Polyhedron3<EEK>::GetSegments(ptr, segments, count);
}

void Polyhedron3_EEK_GetTriangles(void* ptr, Triangle3d* triangles, int count)
{
	Polyhedron3<EEK>::GetTriangles(ptr, triangles, count);
}

void Polyhedron3_EEK_GetVertices(void* ptr, MeshVertex3* vertices, int count)
{
	Polyhedron3<EEK>::GetVertices(ptr, vertices, count);
}

void Polyhedron3_EEK_GetFaces(void* ptr, MeshFace3* faces, int count)
{
	Polyhedron3<EEK>::GetFaces(ptr, faces, count);
}

void Polyhedron3_EEK_GetHalfedges(void* ptr, MeshHalfedge3* edges, int count)
{
	Polyhedron3<EEK>::GetHalfedges(ptr, edges, count);
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

void Polyhedron3_EEK_GetCentroids(void* ptr, Point3d* points, int count)
{
	Polyhedron3<EEK>::GetCentroids(ptr, points, count);
}

void Polyhedron3_EEK_ComputeVertexNormals(void* ptr)
{
	Polyhedron3<EEK>::ComputeVertexNormals(ptr);
}

void Polyhedron3_EEK_ComputeFaceNormals(void* ptr)
{
	Polyhedron3<EEK>::ComputeFaceNormals(ptr);
}

void Polyhedron3_EEK_GetVertexNormals(void* ptr, Vector3d* normals, int count)
{
	Polyhedron3<EEK>::GetVertexNormals(ptr, normals, count);
}

void Polyhedron3_EEK_GetFaceNormals(void* ptr, Vector3d* normals, int count)
{
	Polyhedron3<EEK>::GetFaceNormals(ptr, normals, count);
}

void Polyhedron3_EEK_CreatePolygonMesh(void* ptr, Point2d* points, int pointsCount, BOOL xz)
{
	Polyhedron3<EEK>::CreatePolygonMesh(ptr, points, pointsCount, xz);
}

PolygonalCount Polyhedron3_EEK_GetPolygonalCount(void* ptr)
{
	return Polyhedron3<EEK>::GetPolygonalCount(ptr);
}

PolygonalCount Polyhedron3_EEK_GetDualPolygonalCount(void* ptr)
{
	return Polyhedron3<EEK>::GetDualPolygonalCount(ptr);
}

void Polyhedron3_EEK_CreatePolygonalMesh(void* ptr,
	Point3d* points, int pointsCount,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	Polyhedron3<EEK>::CreatePolygonalMesh(ptr, 
		points, pointsCount, 
		triangles, triangleCount, 
		quads, quadCount, 
		pentagons, pentagonCount, 
		hexagons, hexagonCount);
}

void Polyhedron3_EEK_GetPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	Polyhedron3<EEK>::GetPolygonalIndices(ptr,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

void Polyhedron3_EEK_GetDualPolygonalIndices(void* ptr,
	int* triangles, int triangleCount,
	int* quads, int quadCount,
	int* pentagons, int pentagonCount,
	int* hexagons, int hexagonCount)
{
	Polyhedron3<EEK>::GetDualPolygonalIndices(ptr,
		triangles, triangleCount,
		quads, quadCount,
		pentagons, pentagonCount,
		hexagons, hexagonCount);
}

int Polyhedron3_EEK_AddFacetToBorder(void* ptr, int h, int g)
{
	return Polyhedron3<EEK>::AddFacetToBorder(ptr, h, g);
}

int Polyhedron3_EEK_AddVertexAndFacetToBorder(void* ptr, int h, int g)
{
	return Polyhedron3<EEK>::AddVertexAndFacetToBorder(ptr, h, g);
}

int Polyhedron3_EEK_CreateCenterVertex(void* ptr, int h)
{
	return Polyhedron3<EEK>::CreateCenterVertex(ptr, h);
}

int Polyhedron3_EEK_EraseCenterVertex(void* ptr, int h)
{
	return Polyhedron3<EEK>::EraseCenterVertex( ptr, h);
}

BOOL Polyhedron3_EEK_EraseConnectedComponent(void* ptr, int h)
{
	return Polyhedron3<EEK>::EraseConnectedComponent(ptr, h);
}

BOOL Polyhedron3_EEK_EraseFacet(void* ptr, int h)
{
	return Polyhedron3<EEK>::EraseFacet(ptr, h);
}

int Polyhedron3_EEK_FillHole(void* ptr, int h)
{
	return Polyhedron3<EEK>::FillHole(ptr, h);
}

int Polyhedron3_EEK_FlipEdge(void* ptr, int h)
{
	return Polyhedron3<EEK>::FlipEdge(ptr, h);
}

int Polyhedron3_EEK_JoinFacet(void* ptr, int h)
{
	return Polyhedron3<EEK>::JoinFacet(ptr, h);
}

int Polyhedron3_EEK_JoinLoop(void* ptr, int h, int g)
{
	return Polyhedron3<EEK>::JoinLoop(ptr, h, g);
}

int Polyhedron3_EEK_JoinVertex(void* ptr, int h)
{
	return Polyhedron3<EEK>::JoinVertex(ptr, h);
}

int Polyhedron3_EEK_MakeHole(void* ptr, int h)
{
	return Polyhedron3<EEK>::MakeHole(ptr, h);
}

int Polyhedron3_EEK_SplitEdge(void* ptr, int h)
{
	return Polyhedron3<EEK>::SplitEdge(ptr, h);
}

int Polyhedron3_EEK_SplitFacet(void* ptr, int h, int g)
{
	return Polyhedron3<EEK>::SplitFacet(ptr, h, g);
}

int Polyhedron3_EEK_SplitLoop(void* ptr, int h, int g, int k)
{
	return Polyhedron3<EEK>::SplitLoop(ptr, h, g, k);
}

int Polyhedron3_EEK_SplitVertex(void* ptr, int h, int g)
{
	return Polyhedron3<EEK>::SplitVertex(ptr, h, g);
}

/*
typedef typename EEK::FT FT;
typedef typename EEK::Point_3 Point;
typedef typename EEK::Vector_3 Vector;
typedef CGAL::Polyhedron_3<EEK, CGAL::Polyhedron_items_with_id_3> Polyhedron;
typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
typedef typename HalfedgeDS::Vertex Vertex;
typedef typename HalfedgeDS::Face Face;
typedef typename HalfedgeDS::Halfedge Halfedge;

//typedef typename boost::graph_traits<Polyhedron>::vertex_descriptor	Vertex_Des;
typedef typename boost::graph_traits<Polyhedron>::face_descriptor Face_Des;
typedef typename boost::graph_traits<Polyhedron>::edge_descriptor Edge_Des;
typedef typename boost::graph_traits<Polyhedron>::halfedge_descriptor Halfedge_Des;

typedef typename HalfedgeDS::Vertex_iterator Vertex_Iter;

void Test()
{

	Polyhedron model;

}
*/














