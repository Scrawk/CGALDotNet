#include "ConformingTriangulation2_EEK.h"


void* ConformingTriangulation2_EEK_Create()
{
	return ConformingTriangulation2<EEK>::NewTriangulation2();
}

void ConformingTriangulation2_EEK_Release(void* ptr)
{
	ConformingTriangulation2<EEK>::DeleteTriangulation2(ptr);
}

void ConformingTriangulation2_EEK_Clear(void* ptr)
{
	ConformingTriangulation2<EEK>::Clear(ptr);
}

void* ConformingTriangulation2_EEK_Copy(void* ptr)
{
	return ConformingTriangulation2<EEK>::Copy(ptr);
}

int ConformingTriangulation2_EEK_VertexCount(void* ptr)
{
	return ConformingTriangulation2<EEK>::VertexCount(ptr);
}

int ConformingTriangulation2_EEK_FaceCount(void* ptr)
{
	return ConformingTriangulation2<EEK>::FaceCount(ptr);
}

void ConformingTriangulation2_EEK_InsertPoint(void* ptr, Point2d point)
{
	ConformingTriangulation2<EEK>::InsertPoint(ptr, point);
}

void ConformingTriangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int count)
{
	ConformingTriangulation2<EEK>::InsertPoints(ptr, points, count);
}

void ConformingTriangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr)
{
	ConformingTriangulation2<EEK>::InsertPolygon(triPtr, polyPtr);
}

void ConformingTriangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	ConformingTriangulation2<EEK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void ConformingTriangulation2_EEK_GetPoints(void* ptr, Point2d* points, int count)
{
	ConformingTriangulation2<EEK>::GetPoints(ptr, points, count);
}

void ConformingTriangulation2_EEK_GetIndices(void* ptr, int* indices, int count)
{
	ConformingTriangulation2<EEK>::GetIndices(ptr, indices, count);
}

void ConformingTriangulation2_EEK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	ConformingTriangulation2<EEK>::Transform(ptr, translation, rotation, scale);
}

void ConformingTriangulation2_EEK_InsertSegmentConstraint(void* ptr, Point2d a, Point2d b)
{
	ConformingTriangulation2<EEK>::InsertSegmentConstraint(ptr, a, b);
}

void ConformingTriangulation2_EEK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int count)
{
	ConformingTriangulation2<EEK>::InsertSegmentConstraints(ptr, segments, count);
}

void ConformingTriangulation2_EEK_InsertPolygonConstraint(void* triPtr, void* polyPtr)
{
	ConformingTriangulation2<EEK>::InsertPolygonConstraint(triPtr, polyPtr);
}

void ConformingTriangulation2_EEK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr)
{
	ConformingTriangulation2<EEK>::InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
}

void ConformingTriangulation2_EEK_MakeDelaunay(void* ptr)
{
	ConformingTriangulation2<EEK>::MakeConformingDelaunay(ptr);
}

void ConformingTriangulation2_EEK_MakeGabriel(void* ptr)
{
	ConformingTriangulation2<EEK>::MakeConformingGabriel(ptr);
}

void Conformingriangulation2_EEK_RefineAndOptimize(void* ptr, int iterations, double angleBounds, double lengthBounds)
{
	ConformingTriangulation2<EEK>::RefineAndOptimize(ptr, iterations, angleBounds, lengthBounds);
}

void ConformingTriangulation2_EEK_RefineAndOptimizeWithSeeds(void* ptr, int iterations, double angleBounds, double lengthBounds, Point2d* points, int count)
{
	ConformingTriangulation2<EEK>::RefineAndOptimize(ptr, iterations, angleBounds, lengthBounds, points, count);
}





