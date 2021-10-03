
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

void* PolygonOffset2_EEK_GetBufferedPolygon(void* ptr, int index)
{
	return PolygonOffset2<EEK>::GetBufferedPolygon(ptr, index);
}

void PolygonOffset2_EEK_CreateInteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EEK>::CreateInteriorOffset(ptr, polyPtr, offset);
}

void PolygonOffset2_EEK_CreateExteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EEK>::CreateExteriorOffset(ptr, polyPtr, offset);
}


