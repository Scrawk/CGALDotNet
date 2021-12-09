#include "../pch.h"
#include "PolygonBoolean2_EIK.h"
#include "PolygonBoolean2.h"
#include <vector>
#include <list>

void* PolygonBoolean2_EIK_Create()
{
	return PolygonBoolean2<EIK>::NewPolygonBoolean2();
}

void PolygonBoolean2_EIK_Release(void* ptr)
{
	PolygonBoolean2<EIK>::DeletePolygonBoolean2(ptr);
}

void PolygonBoolean2_EIK_ClearBuffer(void* ptr)
{
	PolygonBoolean2<EIK>::ClearBuffer(ptr);
}

void* PolygonBoolean2_EIK_CopyBufferItem(void* ptr, int index)
{
	return PolygonBoolean2<EIK>::CopyBufferItem(ptr, index);
}

BOOL PolygonBoolean2_EIK_DoIntersect_P_P(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::DoIntersect_P_P(ptr0, ptr1, ptr2);
}

BOOL PolygonBoolean2_EIK_DoIntersect_P_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::DoIntersect_P_PWH(ptr0, ptr1, ptr2);
}

BOOL PolygonBoolean2_EIK_DoIntersect_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::DoIntersect_PWH_PWH(ptr0, ptr1, ptr2);
}

BOOL PolygonBoolean2_EIK_Join_P_P(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EIK>::Join_P_P(ptr0, ptr1, ptr2, resultPtr);
}

BOOL PolygonBoolean2_EIK_Join_P_PWH(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EIK>::Join_P_PWH(ptr0, ptr1, ptr2, resultPtr);
}

BOOL PolygonBoolean2_EIK_Join_PWH_PWH(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EIK>::Join_PWH_PWH(ptr0, ptr1, ptr2, resultPtr);
}

int PolygonBoolean2_EIK_Intersect_P_P(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::Intersect_P_P(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_Intersect_P_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::Intersect_P_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_Intersect_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::Intersect_PWH_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_Difference_P_P(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::Difference_P_P(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_Difference_P_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::Difference_P_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_Difference_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::Difference_PWH_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_SymmetricDifference_P_P(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::SymmetricDifference_P_P(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_SymmetricDifference_P_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::SymmetricDifference_P_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_SymmetricDifference_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EIK>::SymmetricDifference_PWH_PWH(ptr0, ptr1, ptr2);
}

int PolygonBoolean2_EIK_Complement_PWH(void* ptr0, void* ptr1)
{
	return PolygonBoolean2<EIK>::Complement_PWH(ptr0, ptr1);
}
