
#include "PolygonOffset2_EIK.h"
#include "PolygonOffset2.h"

void* PolygonOffset2_EIK_Create()
{
	return PolygonOffset2<EIK>::NewPolygonOffset2();
}

void PolygonOffset2_EIK_Release(void* ptr)
{
	PolygonOffset2<EIK>::DeletePolygonOffset2(ptr);
}

int PolygonOffset2_EIK_PolygonBufferSize(void* ptr)
{
	return PolygonOffset2<EIK>::PolygonBufferSize(ptr);
}

void PolygonOffset2_EIK_ClearPolygonBuffer(void* ptr)
{
	PolygonOffset2<EIK>::ClearPolygonBuffer(ptr);
}

int PolygonOffset2_EIK_VertexBufferSize(void* ptr)
{
	return PolygonOffset2<EIK>::VertexBufferSize(ptr);
}

int PolygonOffset2_EIK_EdgeBufferSize(void* ptr)
{
	return PolygonOffset2<EIK>::EdgeBufferSize(ptr);
}

void PolygonOffset2_EIK_ClearEdgeAndVertexBuffers(void* ptr)
{
	PolygonOffset2<EIK>::ClearEdgeAndVertexBuffers(ptr);
}

void* PolygonOffset2_EIK_GetBufferedPolygon(void* ptr, int index)
{
	return PolygonOffset2<EIK>::GetBufferedPolygon(ptr, index);
}

void PolygonOffset2_EIK_GetVertices(void* ptr, DCELVertex* vertices, int start, int count)
{
	PolygonOffset2<EIK>::GetVertices(ptr, vertices, start, count);
}

void PolygonOffset2_EIK_GetEdges(void* ptr, DCELHalfEdge* edges, int start, int count)
{
	PolygonOffset2<EIK>::GetEdges(ptr, edges, start, count);
}

void PolygonOffset2_EIK_CreateInteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EIK>::CreateInteriorOffset(ptr, polyPtr, offset);
}

void PolygonOffset2_EIK_CreateExteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EIK>::CreateExteriorOffset(ptr, polyPtr, offset);
}

void PolygonOffset2_EIK_CreateInteriorSkeleton(void* ptr, void* polyPtr, BOOL includeBorder)
{
	//PolygonOffset2<EIK>::CreateInteriorSkeleton(ptr, polyPtr, includeBorder);
}

void PolygonOffset2_EIK_CreateExteriorSkeleton(void* ptr, void* polyPtr, double maxOffset, BOOL includeBorder)
{
	//PolygonOffset2<EIK>::CreateExteriorSkeleton(ptr, polyPtr, maxOffset, includeBorder);
}

