#pragma once

#include "DelaunayTriangulation2_EEK.h"
#include "DelaunayTriangulation2.h"

typedef CGAL::Triangulation_vertex_base_with_info_2<int, EEK> Vb;
typedef CGAL::Triangulation_face_base_with_info_2<int, EEK> Fb;
typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;
typedef CGAL::Delaunay_triangulation_2<EEK, Tds> Triangulation_2;
typedef typename Triangulation_2::Face_handle Face;
typedef typename Triangulation_2::Vertex_handle Vertex;

typedef DelaunayTriangulation2<EEK, Triangulation_2, Vertex, Face> Tri2;

void* DelaunayTriangulation2_EEK_Create()
{
	return Tri2::NewTriangulation2();
}

void DelaunayTriangulation2_EEK_Release(void* ptr)
{
	Tri2::DeleteTriangulation2(ptr);
}

void DelaunayTriangulation2_EEK_Clear(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->Clear();
}

void* DelaunayTriangulation2_EEK_Copy(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->Copy();
}

void* DelaunayTriangulation2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Tri2::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Tri2::Convert<EEK>(ptr);

	default:
		return Tri2::Convert<EEK>(ptr);
	}
}

void DelaunayTriangulation2_EEK_SetIndices(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->SetIndices();
}

int DelaunayTriangulation2_EEK_BuildStamp(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->BuildStamp();
}

BOOL DelaunayTriangulation2_EEK_IsValid(void* ptr, int level)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->IsValid(level);
}

int DelaunayTriangulation2_EEK_VertexCount(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->VertexCount();
}

int DelaunayTriangulation2_EEK_FaceCount(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->FaceCount();
}

void DelaunayTriangulation2_EEK_InsertPoint(void* ptr, Point2d point)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->InsertPoint(point);
}

void DelaunayTriangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->InsertPoints(points, count);
}

void DelaunayTriangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr)
{
	auto tri = Tri2::CastToTriangulation2(triPtr);
	tri->InsertPolygon(polyPtr);
}

void DelaunayTriangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	auto tri = Tri2::CastToTriangulation2(triPtr);
	tri->InsertPolygonWithHoles(pwhPtr);
}

void DelaunayTriangulation2_EEK_GetPoints(void* ptr, Point2d* points, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetPoints(points, count);
}

void DelaunayTriangulation2_EEK_GetIndices(void* ptr, int* indices, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetIndices(indices, count);
}

BOOL DelaunayTriangulation2_EEK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetVertex(index, vertex);
}

void DelaunayTriangulation2_EEK_GetVertices(void* ptr, TriVertex2* vertices, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetVertices(vertices, count);
}

bool DelaunayTriangulation2_EEK_GetFace(void* ptr, int index, TriFace2& face)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetFace(index, face);
}

void DelaunayTriangulation2_EEK_GetFaces(void* ptr, TriFace2* faces, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetFaces(faces, count);
}

BOOL DelaunayTriangulation2_EEK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetSegment(faceIndex, neighbourIndex, segment);
}

BOOL DelaunayTriangulation2_EEK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetTriangle(faceIndex, triangle);
}

void DelaunayTriangulation2_EEK_GetTriangles(void* ptr, Triangle2d* triangles, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetTriangles(triangles, count);
}

BOOL DelaunayTriangulation2_EEK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetCircumcenter(faceIndex, circumcenter);
}

void DelaunayTriangulation2_EEK_GetCircumcenters(void* ptr, Point2d* circumcenters, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetCircumcenters(circumcenters, count);
}

int DelaunayTriangulation2_EEK_NeighbourIndex(void* ptr, int faceIndex, int index)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->NeighbourIndex(faceIndex, index);
}

BOOL DelaunayTriangulation2_EEK_LocateFace(void* ptr, Point2d point, TriFace2& face)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->LocateFace(point, face);
}

BOOL DelaunayTriangulation2_EEK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->MoveVertex(index, point, ifNoCollision, vertex);
}

BOOL DelaunayTriangulation2_EEK_RemoveVertex(void* ptr, int index)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->RemoveVertex(index);
}

BOOL DelaunayTriangulation2_EEK_FlipEdge(void* ptr, int faceIndex, int neighbour)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->FlipEdge(faceIndex, neighbour);
}

void DelaunayTriangulation2_EEK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->Transform(translation, rotation, scale);
}

//Delaunay only

int DelaunayTriangulation2_EEK_VoronoiSegmentCount(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->VoronoiSegmentCount();
}

int DelaunayTriangulation2_EEK_VoronoiRayCount(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->VoronoiRayCount();
}

void DelaunayTriangulation2_EEK_VoronoiCount(void* ptr, int& numSegments, int& numRays)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->VoronoiCount(numSegments, numRays);
}

void DelaunayTriangulation2_EEK_GetVoronoiSegments(void* ptr, Segment2d* segments, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetVoronoiSegments(segments, count);
}

void DelaunayTriangulation2_EEK_GetVoronoiRays(void* ptr, Ray2d* rays, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetVoronoiRays(rays, count);
}