#pragma once
#include "pch.h"
#include "Util.h"
#include "Triangulation2_EEK.h"
#include "Triangulation2.h"

typedef Triangulation2<EEK>::Triangulation_2 Triangulation;
typedef Triangulation2<EEK>::Face Face;
typedef Triangulation2<EEK>::Vertex Vertex;

void* Triangulation2_EEK_Create()
{
	return Util::Create<Triangulation2<EEK>>();
}

void Triangulation2_EEK_Release(void* ptr)
{
	Util::Release<Triangulation2<EEK>>(ptr);
}

void Triangulation2_EEK_Clear(void* ptr)
{
	Triangulation2<EEK>::Clear(ptr);
}

void* Triangulation2_EEK_Copy(void* ptr)
{
	return Triangulation2<EEK>::Copy(ptr);
}

BOOL Triangulation2_EEK_IsValid(void* ptr)
{
	return Triangulation2<EEK>::IsValid(ptr);
}

int Triangulation2_EEK_VertexCount(void* ptr)
{
	return Triangulation2<EEK>::VertexCount(ptr);
}

int Triangulation2_EEK_FaceCount(void* ptr)
{
	return Triangulation2<EEK>::FaceCount(ptr);
}

void Triangulation2_EEK_InsertPoint(void* ptr, Point2d point)
{
	Triangulation2<EEK>::InsertPoint(ptr, point);
}

void Triangulation2_EEK_InsertPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Triangulation2<EEK>::InsertPoints(ptr, points, startIndex, count);
}

void Triangulation2_EEK_InsertPolygon(void* triPtr, void* polyPtr)
{
	Triangulation2<EEK>::InsertPolygon(triPtr, polyPtr);
}

void Triangulation2_EEK_InsertPolygonWithHoles(void* triPtr, void* pwhPtr)
{
	Triangulation2<EEK>::InsertPolygonWithHoles(triPtr, pwhPtr);
}

void Triangulation2_EEK_GetPoints(void* ptr, Point2d* points, int startIndex, int count)
{
	Triangulation2<EEK>::GetPoints(ptr, points, startIndex, count);
}

void Triangulation2_EEK_GetIndices(void* ptr, int* indices, int startIndex, int count)
{
	Triangulation2<EEK>::GetIndices(ptr, indices, startIndex, count);
}

void Triangulation2_EEK_GetVertices(void* ptr, TriVertex2* vertices, int startIndex, int count)
{
	Triangulation2<EEK>::GetVertices(ptr, vertices, startIndex, count);
}

void ResetFace(Triangulation& tri, Vertex vert)
{
	auto face = vert->face();
	auto f = vert->incident_faces(face), end(f);

	if (!f.is_empty())
	{
		do
		{
			if (!tri.is_infinite(f))
			{
				vert->set_face(f);
				return;
			}

		} while (++f != end);
	}
}

int Degree(Triangulation& tri, Vertex vert)
{
	auto face = vert->face();
	auto f = vert->incident_faces(face), end(f);

	int count = 0;

	if (!f.is_empty())
	{
		do
		{
			if (!tri.is_infinite(f))
				count++;

		} while (++f != end);
	}

	return count;
}

void Triangulation2_EEK_GetFaces(void* ptr, TriFace2* faces, int startIndex, int count)
{
	/*
	Triangulation2<EEK>::Triangulation_2 t;

	for (const auto& vert : t.all_vertex_handles())
	{
		if (t.is_infinite(vert->face()))
		{
			ResetFace(t, vert);
		}

	}
	*/
	
	Triangulation2<EEK>::GetFaces(ptr, faces, startIndex, count);
}


