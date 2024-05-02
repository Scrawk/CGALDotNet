
#include "PolygonPartition2_EEK.h"
#include "PolygonPartition2.h"

void* PolygonPartition2_EEK_Create()
{
	return PolygonPartition2<EEK>::NewPolygonPartition2();
}

void PolygonPartition2_EEK_Release(void* ptr)
{
	PolygonPartition2<EEK>::DeletePolygonPartition2(ptr);
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

BOOL PolygonPartition2_EEK_Is_Y_MonotonePWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::Is_Y_MonotonePWH(ptr, polyPtr);
}

BOOL PolygonPartition2_EEK_PartitionIsValid(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::PartionIsValid(ptr, polyPtr);
}

BOOL PolygonPartition2_EEK_ConvexPartitionIsValid(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::ConvexPartionIsValid(ptr, polyPtr);
}

int PolygonPartition2_EEK_Y_MonotonePartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::Y_MonotonePartition(ptr, polyPtr);
}

int PolygonPartition2_EEK_Y_MonotonePartitionPWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::Y_MonotonePartitionPWH(ptr, polyPtr);
}

int PolygonPartition2_EEK_ApproxConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::ApproxConvexPartition(ptr, polyPtr);
}

int PolygonPartition2_EEK_ApproxConvexPartitionPWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::ApproxConvexPartitionPWH(ptr, polyPtr);
}

int PolygonPartition2_EEK_GreeneApproxConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::GreeneApproxConvexPartition(ptr, polyPtr);
}

int PolygonPartition2_EEK_GreeneApproxConvexPartitionPWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::GreeneApproxConvexPartitionPWH(ptr, polyPtr);
}

int PolygonPartition2_EEK_OptimalConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::OptimalConvexPartition(ptr, polyPtr);
}

int PolygonPartition2_EEK_OptimalConvexPartitionPWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EEK>::OptimalConvexPartitionPWH(ptr, polyPtr);
}
