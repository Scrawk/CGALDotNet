#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "ConformingTriangulation2.h"

extern "C"
{
	CGALWRAPPER_API void* ConformingTriangulation2_EEK_Create();

	CGALWRAPPER_API void ConformingTriangulation2_EEK_Release(void* ptr);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_Clear(void* ptr);

	CGALWRAPPER_API void* ConformingTriangulation2_EEK_Copy(void* ptr);

	CGALWRAPPER_API int ConformingTriangulation2_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int ConformingTriangulation2_EEK_FaceCount(void* ptr);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_InsertPoint(void* ptr, Point2d point);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_GetPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_GetIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_Transform(void* ptr, Point2d translation, double rotation, double scale);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_InsertSegmentConstraint(void* ptr, Point2d a, Point2d b);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int count);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_InsertPolygonConstraint(void* triPtr, void* polyPtr);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_MakeDelaunay(void* ptr);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_MakeGabriel(void* ptr);

	CGALWRAPPER_API void Conformingriangulation2_EEK_RefineAndOptimize(void* ptr, int iterations, double angleBounds, double lengthBounds);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_RefineAndOptimizeWithSeeds(void* ptr, int iterations, double angleBounds, double lengthBounds, Point2d* points, int count);
}

