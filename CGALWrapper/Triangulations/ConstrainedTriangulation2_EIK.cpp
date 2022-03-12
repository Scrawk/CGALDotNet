#pragma once

#include "ConstrainedTriangulation2_EIK.h"
#include "ConstrainedTriangulation2.h"
#include "TriVertex2.h"
#include "TriFace2.h"
#include "TriEDge2.h"

typedef typename EIK::Point_2 Point_2;
typedef CGAL::No_constraint_intersection_tag Tag1;
typedef CGAL::No_constraint_intersection_requiring_constructions_tag Tag2;
typedef CGAL::Exact_predicates_tag Tag3;
typedef CGAL::Exact_intersections_tag Tag4;

typedef CGAL::Triangulation_vertex_base_with_info_2<int, EIK> Vb;
typedef CGAL::Constrained_triangulation_face_base_2<EIK> CFb;
typedef CGAL::Triangulation_face_base_with_info_2<int, EIK, CFb> Fb;
typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;
typedef CGAL::Constrained_triangulation_2<EIK, Tds, Tag4> Triangulation_2;

typedef typename Triangulation_2::Face_handle Face;
typedef typename Triangulation_2::Vertex_handle Vertex;
typedef typename Triangulation_2::Edge Edge;

typedef ConstrainedTriangulation2<EIK, Triangulation_2, Vertex, Face> Tri2;

void* ConstrainedTriangulation2_EIK_Create()
{
	return Tri2::NewTriangulation2();
}

void ConstrainedTriangulation2_EIK_Release(void* ptr)
{
	Tri2::DeleteTriangulation2(ptr);
}

void ConstrainedTriangulation2_EIK_Clear(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->Clear();
}

void* ConstrainedTriangulation2_EIK_Copy(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->Copy();
}

void* ConstrainedTriangulation2_EIK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Tri2::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Tri2::Convert<EEK>(ptr);

	default:
		return Tri2::Convert<EIK>(ptr);
	}
}

void ConstrainedTriangulation2_EIK_SetIndices(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->SetIndices();
}

int ConstrainedTriangulation2_EIK_BuildStamp(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->BuildStamp();
}

BOOL ConstrainedTriangulation2_EIK_IsValid(void* ptr, int level)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->IsValid(level);
}

int ConstrainedTriangulation2_EIK_VertexCount(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->VertexCount();
}

int ConstrainedTriangulation2_EIK_FaceCount(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->FaceCount();
}

void ConstrainedTriangulation2_EIK_InsertPoint(void* ptr, Point2d point)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->InsertPoint(point);
}

void ConstrainedTriangulation2_EIK_InsertPoints(void* ptr, Point2d* points, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->InsertPoints(points, count);
}

void ConstrainedTriangulation2_EIK_InsertPolygon(void* triPtr, void* polyPtr)
{
	auto tri = Tri2::CastToTriangulation2(triPtr);
	tri->InsertPolygon(polyPtr);
}

void ConstrainedTriangulation2_EIK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	auto tri = Tri2::CastToTriangulation2(triPtr);
	tri->InsertPolygonWithHoles(pwhPtr);
}

void ConstrainedTriangulation2_EIK_GetPoints(void* ptr, Point2d* points, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetPoints(points, count);
}

void ConstrainedTriangulation2_EIK_GetIndices(void* ptr, int* indices, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetIndices(indices, count);
}

BOOL ConstrainedTriangulation2_EIK_GetVertex(void* ptr, int index, TriVertex2& vertex)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetVertex(index, vertex);
}

void ConstrainedTriangulation2_EIK_GetVertices(void* ptr, TriVertex2* vertices, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetVertices(vertices, count);
}

bool ConstrainedTriangulation2_EIK_GetFace(void* ptr, int index, TriFace2& face)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetFace(index, face);
}

void ConstrainedTriangulation2_EIK_GetFaces(void* ptr, TriFace2* faces, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetFaces(faces, count);
}

BOOL ConstrainedTriangulation2_EIK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetSegment(faceIndex, neighbourIndex, segment);
}

BOOL ConstrainedTriangulation2_EIK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetTriangle(faceIndex, triangle);
}

void ConstrainedTriangulation2_EIK_GetTriangles(void* ptr, Triangle2d* triangles, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetTriangles(triangles, count);
}

BOOL ConstrainedTriangulation2_EIK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->GetCircumcenter(faceIndex, circumcenter);
}

void ConstrainedTriangulation2_EIK_GetCircumcenters(void* ptr, Point2d* circumcenters, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetCircumcenters(circumcenters, count);
}

int ConstrainedTriangulation2_EIK_NeighbourIndex(void* ptr, int faceIndex, int index)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->NeighbourIndex(faceIndex, index);
}

BOOL ConstrainedTriangulation2_EIK_LocateFace(void* ptr, Point2d point, TriFace2& face)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->LocateFace(point, face);
}

BOOL ConstrainedTriangulation2_EIK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->MoveVertex(index, point, ifNoCollision, vertex);
}

BOOL ConstrainedTriangulation2_EIK_RemoveVertex(void* ptr, int index)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->RemoveVertex(index);
}

BOOL ConstrainedTriangulation2_EIK_FlipEdge(void* ptr, int faceIndex, int neighbour)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->FlipEdge(faceIndex, neighbour);
}

void ConstrainedTriangulation2_EIK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->Transform(translation, rotation, scale);
}

//Constrained only

int ConstrainedTriangulation2_EIK_ConstrainedEdgesCount(void* ptr)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->ConstrainedEdgesCount();
}

BOOL ConstrainedTriangulation2_EIK_HasIncidentConstraints(void* ptr, int index)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->HasIncidentConstraints(index);
}

int ConstrainedTriangulation2_EIK_IncidentConstraintCount(void* ptr, int index)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->IncidentConstraintCount(index);
}

void ConstrainedTriangulation2_EIK_InsertSegmentConstraintFromPoints(void* ptr, Point2d a, Point2d b)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->InsertSegmentConstraint(a, b);
}

void ConstrainedTriangulation2_EIK_InsertSegmentConstraintFromVertices(void* ptr, int vertIndex1, int vertIndex2)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->InsertSegmentConstraint(vertIndex1, vertIndex2);
}

void ConstrainedTriangulation2_EIK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->InsertSegmentConstraints(segments, count);
}

void ConstrainedTriangulation2_EIK_InsertPolygonConstraint(void* triPtr, void* polyPtr)
{
	auto tri = Tri2::CastToTriangulation2(triPtr);
	tri->InsertPolygonConstraint(polyPtr);
}

void ConstrainedTriangulation2_EIK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr)
{
	auto tri = Tri2::CastToTriangulation2(triPtr);
	tri->InsertPolygonWithHolesConstraint(pwhPtr);
}

void ConstrainedTriangulation2_EIK_GetEdgeConstraints(void* ptr, TriEdge2* constraints, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetConstraints(constraints, count);
}

void ConstrainedTriangulation2_EIK_GetSegmentConstraints(void* ptr, Segment2d* constraints, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetConstraints(constraints, count);
}

void ConstrainedTriangulation2_EIK_GetIncidentConstraints(void* ptr, int vertexIndex, TriEdge2* constraints, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->GetIncidentConstraints(vertexIndex, constraints, count);
}

void ConstrainedTriangulation2_EIK_RemoveConstraint(void* ptr, int faceIndex, int neighbourIndex)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->RemoveConstraint(faceIndex, neighbourIndex);
}

void ConstrainedTriangulation2_EIK_RemoveIncidentConstraints(void* ptr, int vertexIndex)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	tri->RemoveIncidentConstraints(vertexIndex);
}

int ConstrainedTriangulation2_EIK_MarkDomains(void* ptr, int* indices, int count)
{
	auto tri = Tri2::CastToTriangulation2(ptr);
	return tri->MarkDomains(indices, count);
}


