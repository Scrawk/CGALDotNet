#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "IndexMap.h"

#include "CGAL/Point_2.h"
#include <CGAL/Triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>

template<class K, class VERTEX, class FACE>
class TriangulationMap
{

private:

	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K> Fb;
	typedef CGAL::Triangulation_data_structure_2<Vb, Fb> Tds;
	typedef CGAL::Triangulation_2<K, Tds> Triangulation_2;
	typedef typename Triangulation_2::Point Point_2;

	IndexMap<VERTEX> vertexMap;

	IndexMap<FACE> faceMap;

public:

	TriangulationMap()
	{

	}

	void BuildMaps(Triangulation_2& model)
	{
		BuildVertexMap(model);
		BuildFaceMap(model);
	}

	void ClearMaps()
	{
		vertexMap.Clear();
		faceMap.Clear();
	}

	void OnModelChanged()
	{
		OnVerticesChanged();
		OnFacesChanged();
	}

	void OnVerticesChanged()
	{
		vertexMap.Clear();
	}

	void OnFacesChanged()
	{
		faceMap.Clear();
	}

	VERTEX* FindVertex(Triangulation_2& model, int index)
	{
		SetVertexIndices(model);
		BuildVertexMap(model);
		return vertexMap.Find(index);
	}

	FACE* FindFace(Triangulation_2& model, int index)
	{
		SetFaceIndices(model);
		BuildFaceMap(model);
		return faceMap.Find(index);
	}

	void SetVertexIndices(Triangulation_2& model)
	{
		if (vertexMap.indicesSet)
			return;

		vertexMap.Clear();

		for (auto& vert : model.finite_vertex_handles())
		{
			if (model.is_infinite(vert->face()))
				ResetFace(model, vert);

			vert->info() = vertexMap.NextIndex();
		}

		vertexMap.indicesSet = true;
	}

	void BuildVertexMap(Triangulation_2& model)
	{
		if (vertexMap.mapBuilt)
			return;

		vertexMap.ClearMap();

		for (auto& vert : model.finite_vertex_handles())
			vertexMap.Insert(vert->info(), vert);

		vertexMap.mapBuilt = true;
	}

	void SetFaceIndices(Triangulation_2& model)
	{
		if (faceMap.indicesSet)
			return;

		faceMap.Clear();

		for (auto& face : model.finite_face_handles())
			face->info() = faceMap.NextIndex();

		faceMap.indicesSet = true;
	}

	void BuildFaceMap(Triangulation_2& model)
	{
		if (faceMap.mapBuilt)
			return;

		faceMap.ClearMap();

		for (auto& face : model.finite_face_handles())
			faceMap.Insert(face->info(), face);

		faceMap.mapBuilt = true;
	}

	private:

		void ResetFace(const Triangulation_2& tri, VERTEX vert)
		{
			auto face = vert->face();
			auto start = vert->incident_faces(face), end(start);

			if (start != nullptr)
			{
				do
				{
					if (!tri.is_infinite(start))
					{
						vert->set_face(start);
						return;
					}
				} while (++start != end);
			}
		}

};
