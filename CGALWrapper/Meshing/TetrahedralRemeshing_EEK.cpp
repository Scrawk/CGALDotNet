#include "TetrahedralRemeshing_EEK.h"

#include "TetrahedralRemeshing.h"

void* TetrahedralRemeshing_EEK_Create()
{
	return TetrahedralRemeshing<EEK>::NewTetrahedralRemeshing();
}

void TetrahedralRemeshing_EEK_Release(void* ptr)
{
	TetrahedralRemeshing<EEK>::DeleteTetrahedralRemeshing(ptr);
}