#include "pch.h"
#include "PolygonBoolean2_EEK.h"
#include "PolygonBoolean2.h"

bool PolygonBoolean2_EEK_DoIntersect(void* ptr1, void* ptr2)
{
	return PolygonBoolean2_DoIntersect<Polygon2_EEK>(ptr1, ptr2);
}
