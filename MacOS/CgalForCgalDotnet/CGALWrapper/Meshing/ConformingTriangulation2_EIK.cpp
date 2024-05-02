#include "ConformingTriangulation2_EIK.h"


void* ConformingTriangulation2_EIK_Create()
{
	return ConformingTriangulation2<EIK>::NewTriangulation2();
}

void ConformingTriangulation2_EIK_Release(void* ptr)
{
	ConformingTriangulation2<EIK>::DeleteTriangulation2(ptr);
}

void ConformingTriangulation2_EIK_Clear(void* ptr)
{
	ConformingTriangulation2<EIK>::Clear(ptr);
}

void* ConformingTriangulation2_EIK_Copy(void* ptr)
{
	return ConformingTriangulation2<EIK>::Copy(ptr);
}

int ConformingTriangulation2_EIK_VertexCount(void* ptr)
{
	return ConformingTriangulation2<EIK>::VertexCount(ptr);
}

int ConformingTriangulation2_EIK_FaceCount(void* ptr)
{
	return ConformingTriangulation2<EIK>::FaceCount(ptr);
}

void ConformingTriangulation2_EIK_InsertPoint(void* ptr, Point2d point)
{
	ConformingTriangulation2<EIK>::InsertPoint(ptr, point);
}

void ConformingTriangulation2_EIK_InsertPoints(void* ptr, Point2d* points, int count)
{
	ConformingTriangulation2<EIK>::InsertPoints(ptr, points, count);
}

void ConformingTriangulation2_EIK_InsertPolygon(void* triPtr, void* polyPtr)
{
	ConformingTriangulation2<EIK>::InsertPolygon(triPtr, polyPtr);
}

void ConformingTriangulation2_EIK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	ConformingTriangulation2<EIK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void ConformingTriangulation2_EIK_GetPoints(void* ptr, Point2d* points, int count)
{
	ConformingTriangulation2<EIK>::GetPoints(ptr, points, count);
}

void ConformingTriangulation2_EIK_GetIndices(void* ptr, int* indices, int count)
{
	ConformingTriangulation2<EIK>::GetIndices(ptr, indices, count);
}

void ConformingTriangulation2_EIK_Transform(void* ptr, Point2d translation, double rotation, double scale)
{
	ConformingTriangulation2<EIK>::Transform(ptr, translation, rotation, scale);
}

void ConformingTriangulation2_EIK_InsertSegmentConstraint(void* ptr, Point2d a, Point2d b)
{
	ConformingTriangulation2<EIK>::InsertSegmentConstraint(ptr, a, b);
}

void ConformingTriangulation2_EIK_InsertSegmentConstraints(void* ptr, Segment2d* segments, int count)
{
	ConformingTriangulation2<EIK>::InsertSegmentConstraints(ptr, segments, count);
}

void ConformingTriangulation2_EIK_InsertPolygonConstraint(void* triPtr, void* polyPtr)
{
	ConformingTriangulation2<EIK>::InsertPolygonConstraint(triPtr, polyPtr);
}

void ConformingTriangulation2_EIK_InsertPolygonWithHolesConstraint(void* triPtr, void* pwhPtr)
{
	ConformingTriangulation2<EIK>::InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
}

void ConformingTriangulation2_EIK_MakeDelaunay(void* ptr)
{
	ConformingTriangulation2<EIK>::MakeConformingDelaunay(ptr);
}

void ConformingTriangulation2_EIK_MakeGabriel(void* ptr)
{
	ConformingTriangulation2<EIK>::MakeConformingGabriel(ptr);
}

void Conformingriangulation2_EIK_RefineAndOptimize(void* ptr, int iterations, double angleBounds, double lengthBounds)
{
	ConformingTriangulation2<EIK>::RefineAndOptimize(ptr, iterations, angleBounds, lengthBounds);
}

void ConformingTriangulation2_EIK_RefineAndOptimizeWithSeeds(void* ptr, int iterations, double angleBounds, double lengthBounds, Point2d* points, int count)
{
	ConformingTriangulation2<EIK>::RefineAndOptimize(ptr, iterations, angleBounds, lengthBounds, points, count);
}





