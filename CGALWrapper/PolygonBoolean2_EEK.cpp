#include "pch.h"
#include "PolygonBoolean2_EEK.h"
#include "PolygonWithHoles2_EEK.h"
#include "PolygonBoolean2.h"

bool PolygonBoolean2_EEK_DoIntersect_P_P(void* ptr1, void* ptr2)
{
	return PolygonBoolean2_DoIntersect_P_P<EEK>(ptr1, ptr2);
}

bool PolygonBoolean2_EEK_DoIntersect_P_PWH(void* ptr1, void* ptr2)
{
	return PolygonBoolean2_DoIntersect_P_PWH<EEK>(ptr1, ptr2);
}

bool PolygonBoolean2_EEK_DoIntersect_PWH_PWH(void* ptr1, void* ptr2)
{
	return PolygonBoolean2_DoIntersect_PWH_PWH<EEK>(ptr1, ptr2);
}

bool PolygonBoolean2_EEK_Join_P_P(void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2_Join_P_P<EEK>(ptr1, ptr2, resultPtr);
}

bool PolygonBoolean2_EEK_Join_P_PWH(void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2_Join_P_PWH<EEK>(ptr1, ptr2, resultPtr);
}

bool PolygonBoolean2_EEK_Join_PWH_PWH(void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2_Join_PWH_PWH<EEK>(ptr1, ptr2, resultPtr);
}
