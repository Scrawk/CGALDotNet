#include "NefPolyhedron3_EEK.h"
#include "NefPolyhedron3.h"
#include "Polyhedron3.h"

#include <CGAL/Nef_polyhedron_3.h>

void* NefPolyhedron3_EEK_CreateFromSpace(int space)
{
	return NefPolyhedron3<EEK>::CreateFromSpace(space);
}

void* NefPolyhedron3_EEK_CreateFromPlane(Plane3d plane, int boundary)
{
	return NefPolyhedron3<EEK>::CreateFromPlane(plane, boundary);
}

void* NefPolyhedron3_EEK_CreateFromPolyhedron(void* ptr)
{
	return NefPolyhedron3<EEK>::CreateFromPolyhedron(ptr);
}

void NefPolyhedron3_EEK_Release(void* ptr)
{
	NefPolyhedron3<EEK>::DeleteNefPolyhedron(ptr);
}

void NefPolyhedron3_EEK_Clear(void* ptr, int space)
{
	NefPolyhedron3<EEK>::Clear(ptr, space);
}

BOOL NefPolyhedron3_EEK_IsEmpty(void* ptr)
{
	return NefPolyhedron3<EEK>::IsEmpty(ptr);
}

BOOL NefPolyhedron3_EEK_IsSimple(void* ptr)
{
	return NefPolyhedron3<EEK>::IsSimple(ptr);
}

BOOL NefPolyhedron3_EEK_IsSpace(void* ptr)
{
	return NefPolyhedron3<EEK>::IsSpace(ptr);
}

BOOL NefPolyhedron3_EEK_IsValid(void* ptr)
{
	return NefPolyhedron3<EEK>::IsValid(ptr);
}

int NefPolyhedron3_EEK_EdgeCount(void* ptr)
{
	return NefPolyhedron3<EEK>::EdgeCount(ptr);
}

int NefPolyhedron3_EEK_FacetCount(void* ptr)
{
	return NefPolyhedron3<EEK>::FacetCount(ptr);
}

int NefPolyhedron3_EEK_HalfEdgeCount(void* ptr)
{
	return NefPolyhedron3<EEK>::HalfEdgeCount(ptr);
}

int NefPolyhedron3_EEK_HalfFacetCount(void* ptr)
{
	return NefPolyhedron3<EEK>::HalfFacetCount(ptr);
}

int NefPolyhedron3_EEK_VertexCount(void* ptr)
{
	return NefPolyhedron3<EEK>::VertexCount(ptr);
}

int NefPolyhedron3_EEK_VolumeCount(void* ptr)
{
	return NefPolyhedron3<EEK>::VolumeCount(ptr);
}

void* NefPolyhedron3_EEK_Intersection(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EEK>::Intersection(ptr1, ptr2);
}

void* NefPolyhedron3_EEK_Join(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EEK>::Join(ptr1, ptr2);
}

void* NefPolyhedron3_EEK_Difference(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EEK>::Difference(ptr1, ptr2);
}

void* NefPolyhedron3_EEK_SymmetricDifference(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EEK>::SymmetricDifference(ptr1, ptr2);
}

void* NefPolyhedron3_EEK_Complement(void* ptr)
{
	return NefPolyhedron3<EEK>::Complement(ptr);
}

void* NefPolyhedron3_EEK_Interior(void* ptr)
{
	return NefPolyhedron3<EEK>::Interior(ptr);
}

void* NefPolyhedron3_EEK_Boundary(void* ptr)
{
	return NefPolyhedron3<EEK>::Boundary(ptr);
}

void* NefPolyhedron3_EEK_Closure(void* ptr)
{
	return NefPolyhedron3<EEK>::Closure(ptr);
}

void* NefPolyhedron3_EEK_Regularization(void* ptr)
{
	return NefPolyhedron3<EEK>::Regularization(ptr);
}

void* NefPolyhedron3_EEK_MinkowskiSum(void* ptr1, void* ptr2)
{
	return NefPolyhedron3<EEK>::MinkowskiSum(ptr1, ptr2);
}

void* NefPolyhedron3_EEK_ConvertToPolyhedron(void* ptr)
{
	return NefPolyhedron3<EEK>::ConvertToPolyhedron(ptr);
}

void* NefPolyhedron3_EEK_ConvertToSurfaceMesh(void* ptr)
{
	return NefPolyhedron3<EEK>::ConvertToSurfaceMesh(ptr);
}

void NefPolyhedron3_EEK_ConvexDecomposition(void* ptr)
{
	NefPolyhedron3<EEK>::ConvexDecomposition(ptr);
}

void NefPolyhedron3_EEK_GetVolumes(void* ptr, void** volumes, int count)
{
	NefPolyhedron3<EEK>::GetVolumes(ptr, volumes, count);
}
