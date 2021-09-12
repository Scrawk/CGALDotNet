#include "../pch.h"
#include "PolygonPartition2_EEK.h"
#include "PolygonPartition2.h"
#include "../Utility/Util.h"

void* PolygonPartition2_EEK_Create()
{
	return Util::Create<PolygonPartition2<EEK>>();
}

void PolygonPartition2_EEK_Release(void* ptr)
{
	Util::Release<PolygonPartition2<EEK>>(ptr);
}

void PolygonPartition2_EEK_ClearBuffer(void* ptr)
{
	PolygonPartition2<EEK>::ClearBuffer(ptr);
}

int PolygonPartition2_EEK_BufferCount(void* ptr)
{
	return PolygonPartition2<EEK>::BufferCount(ptr);
}

void* PolygonPartition2_EEK_CopyBufferItem(void* ptr, int index)
{
	return PolygonPartition2<EEK>::CopyBufferItem(ptr, index);
}

BOOL PolygonPartition2_EEK_Is_Y_Monotone(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::Is_Y_Monotone(ptr, polyPtr);
}

BOOL PolygonPartition2_EEK_ConvexPartitionIsValid(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::ConvexPartionIsValid(ptr, polyPtr);
}

int PolygonPartition2_EEK_Y_MonotonePartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::Y_MonotonePartition(ptr, polyPtr);
}

int PolygonPartition2_EEK_ApproxConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::ApproxConvexPartition(ptr, polyPtr);
}

int PolygonPartition2_EEK_GreeneApproxConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::GreeneApproxConvexPartition(ptr, polyPtr);
}

int PolygonPartition2_EEK_OptimalConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::OptimalConvexPartition(ptr, polyPtr);
}
