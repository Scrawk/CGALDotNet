#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "ConstrainedTriangulation2.h"

extern "C"
{
	CGALWRAPPER_API void* ConstrainedTriangulation2_EEK_Create();

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_Release(void* ptr);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_Clear(void* ptr);

	CGALWRAPPER_API void* ConstrainedTriangulation2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void ConstrainedTriangulation_EEK_SetIndices(void* ptr);

	CGALWRAPPER_API int ConstrainedTriangulation2_EEK_BuildStamp(void* ptr);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_IsValid(void* ptr, int level);

	CGALWRAPPER_API int ConstrainedTriangulation2_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int ConstrainedTriangulation2_EEK_FaceCount(void* ptr);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertPoint(void* ptr, Point2d point);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int startIndex, int count);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetIndices(void* ptr, int* indices, int startIndex, int count);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_GetVertex(void* ptr, int index, TriVertex2& vertex);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetVertices(void* ptr, TriVertex2* vertices, int startIndex, int count);

	CGALWRAPPER_API bool ConstrainedTriangulation2_EEK_GetFace(void* ptr, int index, TriFace2& face);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetFaces(void* ptr, TriFace2* faces, int startIndex, int count);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_GetSegment(void* ptr, int faceIndex, int neighbourIndex, Segment2d& segment);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_GetTriangle(void* ptr, int faceIndex, Triangle2d& triangle);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetTriangles(void* ptr, Triangle2d* triangles, int startIndex, int count);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_GetCircumcenter(void* ptr, int faceIndex, Point2d& circumcenter);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetCircumcenters(void* ptr, Point2d* circumcenters, int startIndex, int count);

	CGALWRAPPER_API int ConstrainedTriangulation2_EEK_NeighbourIndex(void* ptr, int faceIndex, int index);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_LocateFace(void* ptr, Point2d point, TriFace2& face);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_MoveVertex(void* ptr, int index, Point2d point, BOOL ifNoCollision, TriVertex2& vertex);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_RemoveVertex(void* ptr, int index);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_FlipEdge(void* ptr, int faceIndex, int neighbour);

	//Constrained only

	CGALWRAPPER_API int ConstrainedTriangulation2_EEK_ConstrainedEdgesCount(void* ptr);

	CGALWRAPPER_API BOOL ConstrainedTriangulation2_EEK_HasIncidentConstraints(void* ptr, int index);

	CGALWRAPPER_API int ConstrainedTriangulation2_EEK_IncidentConstraintCount(void* ptr, int index);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertSegmentConstraintFromPoints(void* ptr, Point2d a, Point2d b);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertSegmentConstraintFromVertices(void* ptr, int vertIndex1, int vertIndex2);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int startIndex, int count);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertPolygonConstraint(void* triPtr, void* polyPtr);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetEdgeConstraints(void* ptr, TriEdge2* constraints, int startIndex, int count);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetSegmentConstraints(void* ptr, Segment2d* constraints, int startIndex, int count);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_GetIncidentConstraints(void* ptr, int vertexIndex, TriEdge2* constraints, int startIndex, int count);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_RemoveConstraint(void* ptr, int faceIndex, int neighbourIndex);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_RemoveIncidentConstraints(void* ptr, int vertexIndex);

	CGALWRAPPER_API int ConstrainedTriangulation2_EEK_MarkDomains(void* ptr, int* indices, int startIndex, int count);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_MakeDelaunay(void* ptr);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_MakeGabriel(void* ptr);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_RefineAndOptimize(void* ptr, int iterations, double angleBounds, double lengthBounds);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_RefineAndOptimizeWithSeeds(void* ptr, int iterations, double angleBounds, double lengthBounds, Point2d* points, int start, int count);

	CGALWRAPPER_API void ConstrainedTriangulation2_EEK_Transform(void* ptr, Point2d translation, double rotation, double scale);

}

