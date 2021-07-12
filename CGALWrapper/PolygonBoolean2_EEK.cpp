#include "pch.h"
#include "PolygonBoolean2_EEK.h"
#include "PolygonWithHoles2_EEK.h"
#include "PolygonBoolean2.h"

bool PolygonBoolean2_EEK_DoIntersect(void* ptr1, void* ptr2)
{
	return PolygonBoolean2_DoIntersect<Polygon2_EEK>(ptr1, ptr2);
}

bool PolygonBoolean2_EEK_Join(void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2_Join<Polygon2_EEK, PolygonWithHoles2_EEK>(ptr1, ptr2, resultPtr);
}
