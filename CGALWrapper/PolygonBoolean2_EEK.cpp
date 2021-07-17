#include "pch.h"
#include "PolygonBoolean2_EEK.h"
#include "PolygonBoolean2.h"
#include <vector>
#include <list>

using PWH = CGAL::Polygon_with_holes_2<EEK>;
using LIST = std::vector<PWH>;
auto buffer = LIST();

void PolygonBoolean2_EEK_ClearBuffer()
{
	buffer.clear();
}

void* PolygonBoolean2_EEK_CopyBufferItem(int index)
{
	return new PWH(buffer[index]);
}

bool PolygonBoolean2_EEK_DoIntersect_P_P(void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::DoIntersect_P_P(ptr1, ptr2);
}

bool PolygonBoolean2_EEK_DoIntersect_P_PWH(void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::DoIntersect_P_PWH(ptr1, ptr2);
}

bool PolygonBoolean2_EEK_DoIntersect_PWH_PWH(void* ptr1, void* ptr2)
{
	return PolygonBoolean2<EEK>::DoIntersect_PWH_PWH(ptr1, ptr2);
}

bool PolygonBoolean2_EEK_Join_P_P(void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EEK>::Join_P_P(ptr1, ptr2, resultPtr);
}

bool PolygonBoolean2_EEK_Join_P_PWH(void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EEK>::Join_P_PWH(ptr1, ptr2, resultPtr);
}

bool PolygonBoolean2_EEK_Join_PWH_PWH(void* ptr1, void* ptr2, void** resultPtr)
{
	return PolygonBoolean2<EEK>::Join_PWH_PWH(ptr1, ptr2, resultPtr);
}

int PolygonBoolean2_EEK_Intersect_P_P(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::Intersect_P_P(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_Intersect_P_PWH(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::Intersect_P_PWH(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_Intersect_PWH_PWH(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::Intersect_PWH_PWH(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_Difference_P_P(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::Difference_P_P(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_Difference_P_PWH(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::Difference_P_PWH(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_Difference_PWH_PWH(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::Difference_PWH_PWH(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_SymmetricDifference_P_P(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::SymmetricDifference_P_P(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_SymmetricDifference_P_PWH(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::SymmetricDifference_P_PWH(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_SymmetricDifference_PWH_PWH(void* ptr1, void* ptr2)
{
	buffer.clear();
	PolygonBoolean2<EEK>::SymmetricDifference_PWH_PWH(ptr1, ptr2, buffer);
	return buffer.size();
}

int PolygonBoolean2_EEK_Complement_PWH(void* ptr)
{
	buffer.clear();
	PolygonBoolean2<EEK>::Complement_PWH(ptr, buffer);
	return buffer.size();
}
