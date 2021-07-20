#include "pch.h"
#include "PolygonPartition2_EEK.h"
#include "PolygonPartition2.h"
#include "Util.h"

void* PolygonPartition2_EEK_Create()
{
	return Util::Create<PolygonPartition2<EEK>>();
}

void PolygonPartition2_EEK_Release(void* ptr)
{
	Util::Release<PolygonPartition2<EEK>>(ptr);
}

BOOL PolygonPartition2_Is_Y_Monotone(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::Is_Y_Monotone(ptr, polyPtr);
}

void  PolygonPartition2_Y_MonotonePartition2(void* ptr, void* polyPtr)
{
	PolygonPartition2<EEK>::Y_MonotonePartition2(ptr, polyPtr);
}
