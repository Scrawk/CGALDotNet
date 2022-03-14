#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"
#include "../Geometry/Matrices.h"
#include "TriVertex3.h"
#include "TriCell3.h"

extern "C"
{
	CGALWRAPPER_API void* Triangulation3_EEK_Create();

	CGALWRAPPER_API void Triangulation3_EEK_Release(void* ptr);

	CGALWRAPPER_API void Triangulation3_EEK_Clear(void* ptr);

	CGALWRAPPER_API void* Triangulation3_EEK_Copy(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_BuildStamp(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_Dimension(void* ptr);

	CGALWRAPPER_API BOOL Triangulation3_EEK_IsValid(void* ptr, BOOL verbose);

	CGALWRAPPER_API int Triangulation3_EEK_FiniteVertexCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_CellCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_FiniteCellCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_EdgeCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_FiniteEdgeCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_FacetCount(void* ptr);

	CGALWRAPPER_API int Triangulation3_EEK_FiniteFacetCount(void* ptr);

	CGALWRAPPER_API void Triangulation3_EEK_InsertPoint(void* ptr, const Point3d& point);

	CGALWRAPPER_API void Triangulation3_EEK_InsertPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Triangulation3_EEK_InsertInCell(void* ptr, int index, const Point3d& point);

	CGALWRAPPER_API int Triangulation3_EEK_Locate(void* ptr, const Point3d& point);

	CGALWRAPPER_API void Triangulation3_EEK_GetCircumcenters(void* ptr, Point3d* Circumcenters, int count);

	CGALWRAPPER_API void Triangulation3_EEK_GetPoints(void* ptr, Point3d* points, int count);

	CGALWRAPPER_API void Triangulation3_EEK_GetVertices(void* ptr, TriVertex3* vertices, int count);

	CGALWRAPPER_API BOOL Triangulation3_EEK_GetVertex(void* ptr, int index, TriVertex3& vertex);

	CGALWRAPPER_API void Triangulation3_EEK_GetCells(void* ptr, TriCell3* cells, int count);

	CGALWRAPPER_API BOOL Triangulation3_EEK_GetCell(void* ptr, int index, TriCell3& cell);

	CGALWRAPPER_API void Triangulation3_EEK_GetSegmentIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void Triangulation3_EEK_GetTriangleIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void Triangulation3_EEK_GetTetrahedraIndices(void* ptr, int* indices, int count);

	CGALWRAPPER_API void Triangulation3_EEK_GetSegments(void* ptr, Segment3d* segments, int count);

	CGALWRAPPER_API void Triangulation3_EEK_GetTriangles(void* ptr, Triangle3d* triangles, int count);

	CGALWRAPPER_API void Triangulation3_EEK_GetTetahedrons(void* ptr, Tetahedron3d* tetahedrons, int count);

	CGALWRAPPER_API void Triangulation3_EEK_Transform(void* ptr, const Matrix4x4d& matrix);

}