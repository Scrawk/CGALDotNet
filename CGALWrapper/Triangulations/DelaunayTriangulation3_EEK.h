#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"

extern "C"
{
	CGALWRAPPER_API void* DelaunayTriangulation3_EEK_Create();

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_Release(void* ptr);

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_Clear(void* ptr);

	CGALWRAPPER_API void* DelaunayTriangulation3_EEK_Copy(void* ptr);

	CGALWRAPPER_API int DelaunayTriangulation3_EEK_Dimension(void* ptr);

	CGALWRAPPER_API BOOL DelaunayTriangulation3_EEK_IsValid(void* ptr);

	CGALWRAPPER_API int DelaunayTriangulation3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int DelaunayTriangulation3_EEK_CellCount(void* ptr);

	CGALWRAPPER_API int DelaunayTriangulation3_EEK_FiniteCellCount(void* ptr);

	CGALWRAPPER_API int DelaunayTriangulation3_EEK_EdgeCount(void* ptr);

	CGALWRAPPER_API int DelaunayTriangulation3_EEK_FiniteEdgeCount(void* ptr);

	CGALWRAPPER_API int DelaunayTriangulation3_EEK_FacetCount(void* ptr);

	CGALWRAPPER_API int DelaunayTriangulation3_EEK_FiniteFacetCount(void* ptr);

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_InsertPoint(void* ptr, const Point3d& point);

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_InsertPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_GetSegmentIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_GetTriangleIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_GetTetrahedraIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void DelaunayTriangulation3_EEK_Transform(void* ptr, const Matrix4x4d& matrix);
}