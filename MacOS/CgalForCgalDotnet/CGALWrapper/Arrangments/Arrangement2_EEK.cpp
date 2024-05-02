
#include "Arrangement2_EEK.h"
#include "Arrangement2.h"

#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>

void* Arrangement2_EEK_Create()
{
	return Arrangement2<EEK>::NewArrangement2();
}

void Arrangement2_EEK_Release(void* ptr)
{
	Arrangement2<EEK>::DeleteArrangement2(ptr);
}

BOOL Arrangement2_EEK_IsValid(void* ptr)
{
	return Arrangement2<EEK>::IsValid(ptr);
}

void Arrangement2_EEK_Clear(void* ptr)
{
	return Arrangement2<EEK>::Clear(ptr);
}

BOOL Arrangement2_EEK_IsEmpty(void* ptr)
{
	return Arrangement2<EEK>::IsEmpty(ptr);
}

int Arrangement2_EEK_BuildStamp(void* ptr)
{
	return Arrangement2<EEK>::BuildStamp(ptr);
}

void Arrangement2_EEK_Assign(void* ptr, void* ptrOther)
{
	Arrangement2<EEK>::Assign(ptr, ptrOther);
}

void* Arrangement2_EEK_Overlay(void* ptr, void* ptrOther)
{
	return Arrangement2<EEK>::Overlay(ptr, ptrOther);
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

void Arrangement2_EEK_GetPoints(void* ptr, Point2d* points, int count)
{
	Arrangement2<EEK>::GetPoints(ptr, points, count);
}

void Arrangement2_EEK_GetSegments(void* ptr, Segment2d* segments, int count)
{
	Arrangement2<EEK>::GetSegments(ptr, segments, count);
}

void Arrangement2_EEK_GetVertices(void* ptr, ArrVertex2* vertices, int count)
{
	Arrangement2<EEK>::GetVertices(ptr, vertices, count);
}

BOOL Arrangement2_EEK_GetVertex(void* ptr, int index, ArrVertex2& arrVertex)
{
	return Arrangement2<EEK>::GetVertex(ptr, index, arrVertex);
}

void Arrangement2_EEK_GetHalfEdges(void* ptr, ArrHalfEdge2* edges, int count)
{
	Arrangement2<EEK>::GetHalfEdges(ptr, edges, count);
}

BOOL Arrangement2_EEK_GetHalfEdge(void* ptr, int index, ArrHalfEdge2& arrEdge)
{
	return Arrangement2<EEK>::GetHalfEdge(ptr, index, arrEdge);
}

void Arrangement2_EEK_GetFaces(void* ptr, ArrFace2* faces, int count)
{
	Arrangement2<EEK>::GetFaces(ptr, faces, count);
}

BOOL Arrangement2_EEK_GetFace(void* ptr, int index, ArrFace2& arrFace)
{
	return Arrangement2<EEK>::GetFace(ptr, index, arrFace);
}

int Arrangement2_EEK_GetFaceHoleCount(void* ptr, int index)
{
	return Arrangement2<EEK>::GetFaceHoleCount(ptr, index);
}

int Arrangement2_EEK_GetHoleVertexCount(void* ptr, int faceIndex, int holeIndex)
{
	return Arrangement2<EEK>::GetHoleVertexCount(ptr, faceIndex, holeIndex);
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

BOOL Arrangement2_EEK_BatchedPointQuery(void* ptr, Point2d* points, ArrQuery* results, int count)
{
	return Arrangement2<EEK>::BatchedPointQuery(ptr, points, results, count);
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

void Arrangement2_EEK_InsertPolygon(void* ptr, void* polyPtr, BOOL nonItersecting)
{
	Arrangement2<EEK>::InsertPolygon(ptr, polyPtr, nonItersecting);
}

void Arrangement2_EEK_InsertPolygonWithHoles(void* ptr, void* pwhPtr, BOOL nonItersecting)
{
	Arrangement2<EEK>::InsertPolygonWithHoles(ptr, pwhPtr, nonItersecting);
}

void Arrangement2_EEK_InsertSegment(void* ptr, Segment2d segment, BOOL nonItersecting)
{
	Arrangement2<EEK>::InsertSegment(ptr, segment, nonItersecting);
}

void Arrangement2_EEK_InsertSegments(void* ptr, Segment2d* segments, int count, BOOL nonItersecting)
{
	Arrangement2<EEK>::InsertSegments(ptr, segments, count, nonItersecting);
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




