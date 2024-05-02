#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* PolygonWithHoles2_EIK_Create();

	CGALWRAPPER_API void PolygonWithHoles2_EIK_Release(void* ptr);

	CGALWRAPPER_API int PolygonWithHoles2_EIK_HoleCount(void* ptr);

	CGALWRAPPER_API int PolygonWithHoles2_EIK_PointCount(void* ptr, int index);

	CGALWRAPPER_API void* PolygonWithHoles2_EIK_Copy(void* ptr);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_Clear(void* ptr);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_ClearBoundary(void* ptr);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_ClearHoles(void* ptr);

	CGALWRAPPER_API void* PolygonWithHoles2_EIK_CreateFromPolygon(void* ptr);

	CGALWRAPPER_API void* PolygonWithHoles2_EIK_CreateFromPoints(Point2d* points, int count);

	CGALWRAPPER_API Point2d PolygonWithHoles2_EIK_GetPoint(void* ptr, int polyIndex, int pointIndex);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_GetPoints(void* ptr, Point2d* points, int polyIndex, int count);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_SetPoint(void* ptr, int polyIndex, int pointIndex, const Point2d& point);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_SetPoints(void* ptr, Point2d* points, int polyIndex, int count);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_AddHoleFromPolygon(void* pwhPtr, void* polygonPtr);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_AddHoleFromPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_RemoveHole(void* ptr, int index);

	CGALWRAPPER_API void* PolygonWithHoles2_EIK_CopyPolygon(void* ptr, int index);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_ReversePolygon(void* ptr, int index);

	CGALWRAPPER_API BOOL PolygonWithHoles2_EIK_IsUnbounded(void* ptr);

	CGALWRAPPER_API Box2d PolygonWithHoles2_EIK_GetBoundingBox(void* ptr, int index);

	CGALWRAPPER_API BOOL PolygonWithHoles2_EIK_IsSimple(void* ptr, int index);

	CGALWRAPPER_API BOOL PolygonWithHoles2_EIK_IsConvex(void* ptr, int index);

	CGALWRAPPER_API CGAL::Orientation PolygonWithHoles2_EIK_Orientation(void* ptr, int index);

	CGALWRAPPER_API CGAL::Oriented_side PolygonWithHoles2_EIK_OrientedSide(void* ptr, int index, const Point2d& point);

	CGALWRAPPER_API double PolygonWithHoles2_EIK_SignedArea(void* ptr, int index);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_Translate(void* ptr, int index, const Point2d& translation);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_Rotate(void* ptr, int index, double rotation);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_Scale(void* ptr, int index, double scale);

	CGALWRAPPER_API void PolygonWithHoles2_EIK_Transform(void* ptr, int index, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API BOOL PolygonWithHoles2_EIK_ContainsPoint(void* ptr, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary);

	CGALWRAPPER_API void* PolygonWithHoles2_EIK_ConnectHoles(void* ptr);
}
