
#include "PolygonOffset2_EEK.h"
#include "PolygonOffset2.h"

#include <vector>
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/create_offset_polygons_2.h>
#include <CGAL/create_straight_skeleton_from_polygon_with_holes_2.h>
#include <boost/shared_ptr.hpp>

void* PolygonOffset2_EEK_Create()
{
	return PolygonOffset2<EEK>::NewPolygonOffset2();
}

void PolygonOffset2_EEK_Release(void* ptr)
{
	PolygonOffset2<EEK>::DeletePolygonOffset2(ptr);
}

int PolygonOffset2_EEK_PolygonBufferSize(void* ptr)
{
	return PolygonOffset2<EEK>::PolygonBufferSize(ptr);
}

void PolygonOffset2_EEK_ClearPolygonBuffer(void* ptr)
{
	PolygonOffset2<EEK>::ClearPolygonBuffer(ptr);
}

int PolygonOffset2_EEK_VertexBufferSize(void* ptr)
{
	return PolygonOffset2<EEK>::VertexBufferSize(ptr);
}

int PolygonOffset2_EEK_EdgeBufferSize(void* ptr)
{
	return PolygonOffset2<EEK>::EdgeBufferSize(ptr);
}

void PolygonOffset2_EEK_ClearEdgeAndVertexBuffers(void* ptr)
{
	PolygonOffset2<EEK>::ClearEdgeAndVertexBuffers(ptr);
}

void* PolygonOffset2_EEK_GetBufferedPolygon(void* ptr, int index)
{
	return PolygonOffset2<EEK>::GetBufferedPolygon(ptr, index);
}

void PolygonOffset2_EEK_GetVertices(void* ptr, DCELVertex* vertices, int start, int count)
{
	PolygonOffset2<EEK>::GetVertices(ptr, vertices, start, count);
}

void PolygonOffset2_EEK_GetEdges(void* ptr, DCELHalfEdge* edges, int start, int count)
{
	PolygonOffset2<EEK>::GetEdges(ptr, edges, start, count);
}

void PolygonOffset2_EEK_CreateInteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EEK>::CreateInteriorOffset(ptr, polyPtr, offset);
}

void PolygonOffset2_EEK_CreateExteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EEK>::CreateExteriorOffset(ptr, polyPtr, offset);
}

void PolygonOffset2_EEK_CreateInteriorSkeleton(void* ptr, void* polyPtr, BOOL includeBorder)
{
	//PolygonOffset2<EEK>::CreateInteriorSkeleton(ptr, polyPtr, includeBorder);
}

void PolygonOffset2_EEK_CreateExteriorSkeleton(void* ptr, void* polyPtr, double maxOffset, BOOL includeBorder)
{
	//PolygonOffset2<EEK>::CreateExteriorSkeleton(ptr, polyPtr, maxOffset, includeBorder);
}

