
#include "PolygonOffset2_EIK.h"
#include "PolygonOffset2.h"

void* PolygonOffset2_EIK_Create()
{
	return PolygonOffset2<EIK>::NewPolygonOffset2();
}

void PolygonOffset2_EIK_Release(void* ptr)
{
	PolygonOffset2<EIK>::DeletePolygonOffset2(ptr);
}

int PolygonOffset2_EIK_PolygonBufferSize(void* ptr)
{
	return PolygonOffset2<EIK>::PolygonBufferSize(ptr);
}

void PolygonOffset2_EIK_ClearPolygonBuffer(void* ptr)
{
	PolygonOffset2<EIK>::ClearPolygonBuffer(ptr);
}

void* PolygonOffset2_EIK_GetBufferedPolygon(void* ptr, int index)
{
	return PolygonOffset2<EIK>::GetBufferedPolygon(ptr, index);
}

void PolygonOffset2_EIK_CreateInteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EIK>::CreateInteriorOffset(ptr, polyPtr, offset);
}

void PolygonOffset2_EIK_CreateExteriorOffset(void* ptr, void* polyPtr, double offset)
{
	PolygonOffset2<EIK>::CreateExteriorOffset(ptr, polyPtr, offset);
}
