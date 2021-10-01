#include "Polyhedron3_EEK.h"

#include "Polyhedron3.h"

void* Polyhedron3_EEK_Create()
{
	return Polyhedron3<EEK>::NewPolyhedron();
}

void Polyhedron3_EEK_Release(void* ptr)
{
	Polyhedron3<EEK>::DeletePolyhedron(ptr);
}

void Polyhedron3_EEK_Clear(void* ptr)
{
	Polyhedron3<EEK>::Clear(ptr);
}

int Polyhedron3_EEK_VertexCount(void* ptr)
{
	return Polyhedron3<EEK>::VertexCount(ptr);
}

int Polyhedron3_EEK_FaceCount(void* ptr)
{
	return Polyhedron3<EEK>::FaceCount(ptr);
}

int Polyhedron3_EEK_HalfEdgeCount(void* ptr)
{
	return Polyhedron3<EEK>::HalfEdgeCount(ptr);
}

int Polyhedron3_EEK_BorderEdgeCount(void* ptr)
{
	return Polyhedron3<EEK>::BorderEdgeCount(ptr);
}

int Polyhedron3_EEK_BorderHalfEdgeCount(void* ptr)
{
	return Polyhedron3<EEK>::BorderHalfEdgeCount(ptr);
}

BOOL Polyhedron3_EEK_IsClosed(void* ptr)
{
	return Polyhedron3<EEK>::IsClosed(ptr);
}

BOOL Polyhedron3_EEK_IsPureBivalent(void* ptr)
{
	return Polyhedron3<EEK>::IsPureBivalent(ptr);
}

BOOL Polyhedron3_EEK_IsPureTrivalent(void* ptr)
{
	return Polyhedron3<EEK>::IsPureTrivalent(ptr);
}

BOOL Polyhedron3_EEK_IsPureTriangle(void* ptr)
{
	return Polyhedron3<EEK>::IsPureTriangle(ptr);
}

BOOL Polyhedron3_EEK_IsPureQuad(void* ptr)
{
	return Polyhedron3<EEK>::IsPureQuad(ptr);
}