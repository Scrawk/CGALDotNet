#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "ConformingTriangulation2.h"

extern "C"
{
	CGALWRAPPER_API void* ConformingTriangulation2_EIK_Create();

	CGALWRAPPER_API void ConformingTriangulation2_EIK_Release(void* ptr);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_Clear(void* ptr);

	CGALWRAPPER_API void* ConformingTriangulation2_EIK_Copy(void* ptr);

	CGALWRAPPER_API int ConformingTriangulation2_EIK_VertexCount(void* ptr);

	CGALWRAPPER_API int ConformingTriangulation2_EIK_FaceCount(void* ptr);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_InsertPoint(void* ptr, Point2d point);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_InsertPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_InsertPolygon(void* triPtr, void* polyPtr);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_GetPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_GetIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_Transform(void* ptr, Point2d translation, double rotation, double scale);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_InsertSegmentConstraint(void* ptr, Point2d a, Point2d b);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_InsertPolygonConstraint(void* triPtr, void* polyPtr);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_MakeDelaunay(void* ptr);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_MakeGabriel(void* ptr);

	CGALWRAPPER_API void Conformingriangulation2_EIK_RefineAndOptimize(void* ptr, int iterations, double angleBounds, double lengthBounds);

	CGALWRAPPER_API void ConformingTriangulation2_EIK_RefineAndOptimizeWithSeeds(void* ptr, int iterations, double angleBounds, double lengthBounds, Point2d* points, int count);
}

