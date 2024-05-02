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

void* SkinSurfaceMeshing_EEK_MakeSkinSurface_Point3d(double shrinkfactor, BOOL subdivide, Point3d* points, int count)
{
	return SkinSurfaceMeshing<EEK>::MakeSkinSurface(shrinkfactor, subdivide, points, count);
}

void* SkinSurfaceMeshing_EEK_MakeSkinSurface_HPoint3d(double shrinkfactor, BOOL subdivide, HPoint3d* points, int count)
{
	return SkinSurfaceMeshing<EEK>::MakeSkinSurface(shrinkfactor, subdivide, points, count);
}