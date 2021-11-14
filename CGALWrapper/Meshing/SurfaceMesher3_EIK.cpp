#include "SurfaceMesher3_EIK.h"
#include "SurfaceMesher3.h"

int SurfaceMesher3_EIK_VertexCount()
{
	return SurfaceMesher3::VertexCount();
}

int SurfaceMesher3_EIK_TriangleCount()
{
	return SurfaceMesher3::TriangleCount();
}

void SurfaceMesher3_EIK_ClearMesh()
{
	SurfaceMesher3::ClearMesh();
}

Point3d SurfaceMesher3_EIK_GetPoint(int i)
{
	return SurfaceMesher3::GetPoint(i);
}

TriangleIndex SurfaceMesher3_EIK_GetTriangle(int i)
{
	return SurfaceMesher3::GetTriangle(i);
}

void SurfaceMesher3_EIK_Generate(double angularBound, double radiusBound, double distanceBound, double radius)
{
	SurfaceMesher3::Generate(angularBound, radiusBound, distanceBound, radius);
}
