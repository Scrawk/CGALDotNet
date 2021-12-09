
#include "PolygonPartition2_EIK.h"
#include "PolygonPartition2.h"

void* PolygonPartition2_EIK_Create()
{
	return PolygonPartition2<EIK>::NewPolygonPartition2();
}

void PolygonPartition2_EIK_Release(void* ptr)
{
	PolygonPartition2<EIK>::DeletePolygonPartition2(ptr);
}

void PolygonPartition2_EIK_ClearBuffer(void* ptr)
{
	PolygonPartition2<EIK>::ClearBuffer(ptr);
}

int PolygonPartition2_EIK_BufferCount(void* ptr)
{
	return PolygonPartition2<EIK>::BufferCount(ptr);
}

void* PolygonPartition2_EIK_CopyBufferItem(void* ptr, int index)
{
	return PolygonPartition2<EIK>::CopyBufferItem(ptr, index);
}

BOOL PolygonPartition2_EIK_Is_Y_Monotone(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::Is_Y_Monotone(ptr, polyPtr);
}

BOOL PolygonPartition2_EIK_Is_Y_MonotonePWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::Is_Y_MonotonePWH(ptr, polyPtr);
}

BOOL PolygonPartition2_EIK_PartitionIsValid(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::PartionIsValid(ptr, polyPtr);
}

BOOL PolygonPartition2_EIK_ConvexPartitionIsValid(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::ConvexPartionIsValid(ptr, polyPtr);
}

int PolygonPartition2_EIK_Y_MonotonePartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::Y_MonotonePartition(ptr, polyPtr);
}

int PolygonPartition2_EIK_Y_MonotonePartitionPWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::Y_MonotonePartitionPWH(ptr, polyPtr);
}

int PolygonPartition2_EIK_ApproxConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::ApproxConvexPartition(ptr, polyPtr);
}

int PolygonPartition2_EIK_ApproxConvexPartitionPWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::ApproxConvexPartitionPWH(ptr, polyPtr);
}

int PolygonPartition2_EIK_GreeneApproxConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::GreeneApproxConvexPartition(ptr, polyPtr);
}

int PolygonPartition2_EIK_GreeneApproxConvexPartitionPWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::GreeneApproxConvexPartitionPWH(ptr, polyPtr);
}

int PolygonPartition2_EIK_OptimalConvexPartition(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::OptimalConvexPartition(ptr, polyPtr);
}

int PolygonPartition2_EIK_OptimalConvexPartitionPWH(void* ptr, void* polyPtr)
{
	return PolygonPartition2<EIK>::OptimalConvexPartitionPWH(ptr, polyPtr);
}
