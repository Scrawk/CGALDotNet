#include "pch.h"
#include "Util.h"
#include "Arrangement2_EEK.h"
#include "Arrangement2.h"

#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>


void* Arrangement2_EEK_Create()
{
	return Util::Create<Arrangement2<EEK>>();
}

void* Arrangement2_EEK_CreateFromSegments(Segment2d* segments, int startIndex, int count)
{
	return Arrangement2<EEK>::CreateFromSegments(segments, startIndex, count);
}

void Arrangement2_EEK_Release(void* ptr)
{
	Util::Release<Arrangement2<EEK>>(ptr);
}

BOOL Arrangement2_EEK_IsValid(void* ptr)
{
	return Arrangement2<EEK>::IsValid(ptr);
}

int Arrangement2_EEK_VertexCount(void* ptr)
{
	return Arrangement2<EEK>::VertexCount(ptr);
}

int Arrangement2_EEK_IsolatedVerticesCount(void* ptr)
{
	return Arrangement2<EEK>::IsolatedVerticesCount(ptr);
}

int Arrangement2_EEK_VerticesAtInfinityCount(void* ptr)
{
	return Arrangement2<EEK>::VerticesAtInfinityCount(ptr);
}

int Arrangement2_EEK_HalfEdgeCount(void* ptr)
{
	return Arrangement2<EEK>::HalfEdgeCount(ptr);
}

int Arrangement2_EEK_FaceCount(void* ptr)
{
	return Arrangement2<EEK>::FaceCount(ptr);
}

int Arrangement2_EEK_EdgeCount(void* ptr)
{
	return Arrangement2<EEK>::EdgeCount(ptr);
}

int Arrangement2_EEK_UnboundedFaceCount(void* ptr)
{
	return Arrangement2<EEK>::UnboundedFaceCount(ptr);
}

void Arrangement2_EEK_SetVertexIndices(void* ptr)
{
	Arrangement2<EEK>::SetVertexIndices(ptr);
}

void Arrangement2_EEK_SetHalfEdgeIndices(void* ptr)
{
	Arrangement2<EEK>::SetHalfEdgeIndices(ptr);
}

void Arrangement2_EEK_SetFaceIndices(void* ptr)
{
	Arrangement2<EEK>::SetFaceIndices(ptr);
}

void Arrangement2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Arrangement2<EEK>::GetPoints(ptr, points, startIndex, count);
}

void Arrangement2_EEK_GetSegments(void* ptr, Segment2d* segments, int startIndex, int count)
{
	Arrangement2<EEK>::GetSegments(ptr, segments, startIndex, count);
}

void Arrangement2_EEK_GetVertices(void* ptr, ArrVertex2* vertices, int startIndex, int count)
{
	Arrangement2<EEK>::GetVertices(ptr, vertices, startIndex, count);
}

void Arrangement2_EEK_GetHalfEdges(void* ptr, ArrHalfEdge2* edges, int startIndex, int count)
{
	Arrangement2<EEK>::GetHalfEdges(ptr, edges, startIndex, count);
}

void Arrangement2_EEK_GetFaces(void* ptr, ArrFace2* faces, int startIndex, int count)
{
	Arrangement2<EEK>::GetFaces(ptr, faces, startIndex, count);
}

void Arrangement2_EEK_CreateLocator(void* ptr, ARR_LOCATOR type)
{
	Arrangement2<EEK>::CreateLocator(ptr, type);
}

void Arrangement2_EEK_ReleaseLocator(void* ptr)
{
	Arrangement2<EEK>::ReleaseLocator(ptr);
}

BOOL Arrangement2_EEK_PointQuery(void* ptr, Point2d point, ArrQuery& result)
{
	return Arrangement2<EEK>::PointQuery(ptr, point, result);
}

BOOL Arrangement2_EEK_BatchedPointQuery(void* ptr, Point2d* points, ArrQuery* results, int startIndex, int count)
{
	return Arrangement2<EEK>::BatchedPointQuery(ptr, points, results, startIndex, count);
}

BOOL Arrangement2_EEK_RayQuery(void* ptr, Point2d point, BOOL up, ArrQuery& result)
{
	return Arrangement2<EEK>::RayQuery(ptr, point, up, result);
}

BOOL Arrangement2_EEK_IntersectsSegment(void* ptr, Segment2d segment)
{
	return Arrangement2<EEK>::IntersectsSegment(ptr, segment);
}

void Arrangement2_EEK_InsertPoint(void* ptr, Point2d point)
{
	Arrangement2<EEK>::InsertPoint(ptr, point);
}

void Arrangement2_EEK_InsertSegment(void* ptr, Segment2d segment, BOOL nonItersecting)
{
	Arrangement2<EEK>::InsertSegment(ptr, segment, nonItersecting);
}

BOOL Arrangement2_EEK_RemoveVertexByIndex(void* ptr, int index)
{
	return Arrangement2<EEK>::RemoveVertex(ptr, index);
}

BOOL Arrangement2_EEK_RemoveVertexByPoint(void* ptr, Point2d point)
{
	return Arrangement2<EEK>::RemoveVertex(ptr, point);
}

BOOL Arrangement2_EEK_RemoveEdgeByIndex(void* ptr, int index)
{
	return Arrangement2<EEK>::RemoveEdge(ptr, index);
}

BOOL Arrangement2_EEK_RemoveEdgeBySegment(void* ptr, Segment2d segment)
{
	return Arrangement2<EEK>::RemoveEdge(ptr, segment);
}
