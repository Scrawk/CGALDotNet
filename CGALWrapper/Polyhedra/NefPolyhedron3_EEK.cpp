#include "NefPolyhedron3_EEK.h"
#include "NefPolyhedron3.h"
#include "Polyhedron3.h"

#include <CGAL/Nef_polyhedron_3.h>

typedef typename EEK::Point_3 Point_3;
typedef typename EEK::Plane_3 Plane_3;
typedef CGAL::Nef_polyhedron_3<EEK> NefPolyhedron;
typedef Polyhedron3<EEK>::Polyhedron Polyhedron;

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

void NefPolyhedron3_EEK_Clear(void* ptr)
{
	NefPolyhedron3<EEK>::Clear(ptr);
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
