#include "NefPolyhedron3_EIK.h"
#include "NefPolyhedron3.h"
#include "Polyhedron3.h"

#include <CGAL/Nef_polyhedron_3.h>

void* NefPolyhedron3_EIK_CreateFromSpace(int space)
{
	return NefPolyhedron3<EIK>::CreateFromSpace(space);
}

void* NefPolyhedron3_EIK_CreateFromPlane(Plane3d plane, int boundary)
{
	return NefPolyhedron3<EIK>::CreateFromPlane(plane, boundary);
}

void* NefPolyhedron3_EIK_CreateFromPolyhedron(void* ptr)
{
	return NefPolyhedron3<EIK>::CreateFromPolyhedron(ptr);
}

void NefPolyhedron3_EIK_Release(void* ptr)
{
	NefPolyhedron3<EIK>::DeleteNefPolyhedron(ptr);
}

void NefPolyhedron3_EIK_Clear(void* ptr, int space)
{
	NefPolyhedron3<EIK>::Clear(ptr, space);
}

BOOL NefPolyhedron3_EIK_IsEmpty(void* ptr)
{
	return NefPolyhedron3<EIK>::IsEmpty(ptr);
}

BOOL NefPolyhedron3_EIK_IsSimple(void* ptr)
{
	return NefPolyhedron3<EIK>::IsSimple(ptr);
}

BOOL NefPolyhedron3_EIK_IsSpace(void* ptr)
{
	return NefPolyhedron3<EIK>::IsSpace(ptr);
}

BOOL NefPolyhedron3_EIK_IsValid(void* ptr)
{
	return NefPolyhedron3<EIK>::IsValid(ptr);
}

int NefPolyhedron3_EIK_EdgeCount(void* ptr)
{
	return NefPolyhedron3<EIK>::EdgeCount(ptr);
}

int NefPolyhedron3_EIK_FacetCount(void* ptr)
{
	return NefPolyhedron3<EIK>::FacetCount(ptr);
}

int NefPolyhedron3_EIK_HalfEdgeCount(void* ptr)
{
	return NefPolyhedron3<EIK>::HalfEdgeCount(ptr);
}

int NefPolyhedron3_EIK_HalfFacetCount(void* ptr)
{
	return NefPolyhedron3<EIK>::HalfFacetCount(ptr);
}

int NefPolyhedron3_EIK_VertexCount(void* ptr)
{
	return NefPolyhedron3<EIK>::VertexCount(ptr);
}

int NefPolyhedron3_EIK_VolumeCount(void* ptr)
{
	return NefPolyhedron3<EIK>::VolumeCount(ptr);
}

void* NefPolyhedron3_EIK_Intersection(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EIK>::Intersection(ptr1, ptr2);
}

void* NefPolyhedron3_EIK_Join(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EIK>::Join(ptr1, ptr2);
}

void* NefPolyhedron3_EIK_Difference(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EIK>::Difference(ptr1, ptr2);
}

void* NefPolyhedron3_EIK_SymmetricDifference(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EIK>::SymmetricDifference(ptr1, ptr2);
}

void* NefPolyhedron3_EIK_Complement(void* ptr)
{
	return NefPolyhedron3<EIK>::Complement(ptr);
}

void* NefPolyhedron3_EIK_Interior(void* ptr)
{
	return NefPolyhedron3<EIK>::Interior(ptr);
}

void* NefPolyhedron3_EIK_Boundary(void* ptr)
{
	return NefPolyhedron3<EIK>::Boundary(ptr);
}

void* NefPolyhedron3_EIK_Closure(void* ptr)
{
	return NefPolyhedron3<EIK>::Closure(ptr);
}

void* NefPolyhedron3_EIK_Regularization(void* ptr)
{
	return NefPolyhedron3<EIK>::Regularization(ptr);
}

void* NefPolyhedron3_EIK_MinkowskiSum(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EIK>::MinkowskiSum(ptr1, ptr2);
}

void* NefPolyhedron3_EIK_ConvertToPolyhedron(void* ptr)
{
	return NefPolyhedron3<EIK>::ConvertToPolyhedron(ptr);
}

void* NefPolyhedron3_EIK_ConvertToSurfaceMesh(void* ptr)
{
	return NefPolyhedron3<EIK>::ConvertToSurfaceMesh(ptr);
}

void NefPolyhedron3_EIK_ConvexDecomposition(void* ptr)
{
	NefPolyhedron3<EIK>::ConvexDecomposition(ptr);
}

void NefPolyhedron3_EIK_GetVolumes(void* ptr, void** volumes, int count)
{
	NefPolyhedron3<EIK>::GetVolumes(ptr, volumes, count);
}
