#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* PolygonWithHoles2_EEK_Create();

	CGALWRAPPER_API void PolygonWithHoles2_EEK_Release(void* ptr);

	CGALWRAPPER_API int PolygonWithHoles2_EEK_HoleCount(void* ptr);

	CGALWRAPPER_API int PolygonWithHoles2_EEK_PointCount(void* ptr, int index);

	CGALWRAPPER_API void* PolygonWithHoles2_EEK_Copy(void* ptr);

	CGALWRAPPER_API void* PolygonWithHoles2_EEK_Convert(void* ptr, CGAL_KERNEL k);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_Clear(void* ptr);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_ClearBoundary(void* ptr);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_ClearHoles(void* ptr);

	CGALWRAPPER_API void* PolygonWithHoles2_EEK_CreateFromPolygon(void* ptr);

	CGALWRAPPER_API void* PolygonWithHoles2_EEK_CreateFromPoints(Point2d * points, int count);

	CGALWRAPPER_API Point2d PolygonWithHoles2_EEK_GetPoint(void* ptr, int polyIndex, int pointIndex);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_GetPoints(void* ptr, Point2d* points, int polyIndex, int count);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_SetPoint(void* ptr, int polyIndex, int pointIndex, const Point2d& point);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_SetPoints(void* ptr, Point2d* points, int polyIndex, int count);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_AddHoleFromPolygon(void* pwhPtr, void* polygonPtr);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_AddHoleFromPoints(void* ptr, Point2d* points, int count);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_RemoveHole(void* ptr, int index);

	CGALWRAPPER_API void* PolygonWithHoles2_EEK_CopyPolygon(void* ptr, int index);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_ReversePolygon(void* ptr, int index);

	CGALWRAPPER_API BOOL PolygonWithHoles2_EEK_IsUnbounded(void* ptr);

	CGALWRAPPER_API Box2d PolygonWithHoles2_EEK_GetBoundingBox(void* ptr, int index);

	CGALWRAPPER_API BOOL PolygonWithHoles2_EEK_IsSimple(void* ptr, int index);

	CGALWRAPPER_API BOOL PolygonWithHoles2_EEK_IsConvex(void* ptr, int index);

	CGALWRAPPER_API CGAL::Orientation PolygonWithHoles2_EEK_Orientation(void* ptr, int index);

	CGALWRAPPER_API CGAL::Oriented_side PolygonWithHoles2_EEK_OrientedSide(void* ptr, int index, const Point2d& point);

	CGALWRAPPER_API double PolygonWithHoles2_EEK_SignedArea(void* ptr, int index);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_Translate(void* ptr, int index, const Point2d& translation);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_Rotate(void* ptr, int index, double rotation);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_Scale(void* ptr, int index, double scale);

	CGALWRAPPER_API void PolygonWithHoles2_EEK_Transform(void* ptr, int index, const Point2d& translation, double rotation, double scale);

	CGALWRAPPER_API BOOL PolygonWithHoles2_EEK_ContainsPoint(void* ptr, const Point2d& point, CGAL::Orientation orientation, BOOL inculdeBoundary);

	CGALWRAPPER_API void* PolygonWithHoles2_EEK_ConnectHoles(void* ptr);
}
