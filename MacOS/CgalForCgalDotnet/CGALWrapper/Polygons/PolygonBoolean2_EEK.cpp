#include "../pch.h"
#include "PolygonBoolean2_EEK.h"
#include "PolygonBoolean2.h"
#include <vector>
#include <list>

void* PolygonBoolean2_EEK_Create()
{
	return PolygonBoolean2<EEK>::NewPolygonBoolean2();
}

void PolygonBoolean2_EEK_Release(void* ptr)
{
	PolygonBoolean2<EEK>::DeletePolygonBoolean2(ptr);
}

void PolygonBoolean2_EEK_ClearBuffer(void* ptr)
{
	PolygonBoolean2<EEK>::ClearBuffer(ptr);
}

void* PolygonBoolean2_EEK_CopyBufferItem(void* ptr, int index)
{
	return PolygonBoolean2<EEK>::CopyBufferItem(ptr, index);
}

BOOL PolygonBoolean2_EEK_DoIntersect_P_P(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::DoIntersect_P_P(ptr0, ptr1, ptr2);
}

BOOL PolygonBoolean2_EEK_DoIntersect_P_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::DoIntersect_P_PWH(ptr0, ptr1, ptr2);
}

BOOL PolygonBoolean2_EEK_DoIntersect_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::DoIntersect_PWH_PWH(ptr0, ptr1, ptr2);
}

BOOL PolygonBoolean2_EEK_Join_P_P(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EEK>::Join_P_P(ptr0, ptr1, ptr2, resultPtr);
}

BOOL PolygonBoolean2_EEK_Join_P_PWH(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EEK>::Join_P_PWH(ptr0, ptr1, ptr2, resultPtr);
}

BOOL PolygonBoolean2_EEK_Join_PWH_PWH(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EEK>::Join_PWH_PWH(ptr0, ptr1, ptr2, resultPtr);
}

int PolygonBoolean2_EEK_Intersect_P_P(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::Intersect_P_P(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_Intersect_P_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::Intersect_P_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_Intersect_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::Intersect_PWH_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_Difference_P_P(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::Difference_P_P(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_Difference_P_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::Difference_P_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_Difference_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::Difference_PWH_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_SymmetricDifference_P_P(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::SymmetricDifference_P_P(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_SymmetricDifference_P_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::SymmetricDifference_P_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_SymmetricDifference_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::SymmetricDifference_PWH_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EEK_Complement_PWH(void* ptr0, void* ptr1)
{
	return PolygonBoolean2<EEK>::Complement_PWH(ptr0, ptr1);
}
