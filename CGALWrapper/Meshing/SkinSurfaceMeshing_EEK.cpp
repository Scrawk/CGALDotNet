#include "SkinSurfaceMeshing_EEK.h"

#include "SkinSurfaceMesing.h"

void* SkinSurfaceMeshing_EEK_Create()
{
	return SkinSurfaceMeshing<EEK>::NewSkinSurfaceMeshing();
}

void SkinSurfaceMeshing_EEK_Release(void* ptr)
{
	SkinSurfaceMeshing<EEK>::DeleteSkinSurfaceMeshing(ptr);
}