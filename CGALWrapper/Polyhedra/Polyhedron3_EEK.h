#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include <CGAL/enum.h>


extern "C"
{
	CGALWRAPPER_API void* Polyhedron3_EEK_Create();

	CGALWRAPPER_API void* Polyhedron3_EEK_CreateFromSize(int vertices, int halfedges, int faces);

	CGALWRAPPER_API void Polyhedron3_EEK_Release(void* ptr);

	CGALWRAPPER_API void Polyhedron3_EEK_Clear(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_VertexCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_FaceCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_HalfEdgeCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_BorderEdgeCount(void* ptr);

	CGALWRAPPER_API int Polyhedron3_EEK_BorderHalfEdgeCount(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsValid(void* ptr, int level);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsClosed(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsPureBivalent(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsPureTrivalent(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsPureTriangle(void* ptr);

	CGALWRAPPER_API BOOL Polyhedron3_EEK_IsPureQuad(void* ptr);

}