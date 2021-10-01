#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

#include "../DCEL/DCELVertex.h"
#include "../DCEL/DCELHalfEdge.h"
#include "../DCEL/DCELFace.h"

extern "C"
{
	CGALWRAPPER_API void* PolygonOffset2_EIK_Create();

	CGALWRAPPER_API void PolygonOffset2_EIK_Release(void* ptr);

	CGALWRAPPER_API int PolygonOffset2_EIK_PolygonBufferSize(void* ptr);

	CGALWRAPPER_API void PolygonOffset2_EIK_ClearPolygonBuffer(void* ptr);

	CGALWRAPPER_API int PolygonOffset2_EIK_VertexBufferSize(void* ptr);

	CGALWRAPPER_API int PolygonOffset2_EIK_EdgeBufferSize(void* ptr);

	CGALWRAPPER_API void PolygonOffset2_EIK_ClearEdgeAndVertexBuffers(void* ptr);

	CGALWRAPPER_API void PolygonOffset2_EIK_GetVertices(void* ptr, DCELVertex* vertices, int start, int count);

	CGALWRAPPER_API void PolygonOffset2_EIK_GetEdges(void* ptr, DCELHalfEdge* edges, int start, int count);

	CGALWRAPPER_API void* PolygonOffset2_EIK_GetBufferedPolygon(void* ptr, int index);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateInteriorOffset(void* ptr, void* polyPtr, double offset);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateExteriorOffset(void* ptr, void* polyPtr, double offset);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateInteriorSkeleton(void* ptr, void* polyPtr, BOOL includeBorder);

	CGALWRAPPER_API void PolygonOffset2_EIK_CreateExteriorSkeleton(void* ptr, void* polyPtr, double maxOffset, BOOL includeBorder);

}
