#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "IndexMap.h"

#include "CGAL/Point_2.h"
#include <CGAL/Constrained_triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>

#include <CGAL/Constrained_triangulation_face_base_2.h>
#include <CGAL/Constrained_triangulation_plus_2.h>

template<class K, class VERTEX, class FACE>
class TriangulationMap
{

private:

	/*
	typedef CGAL::Triangulation_vertex_base_with_info_2<int, K> Vb_info;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K> Fb_info;
	typedef CGAL::Triangulation_data_structure_2<Vb_info, Fb_info> Tds;
	typedef CGAL::Triangulation_2<K, Tds> Triangulation_2;

	typedef CGAL::Constrained_triangulation_face_base_2<K> CFb;
	typedef CGAL::Triangulation_face_base_with_info_2<int, K, CFb> CFb_info;
	typedef CGAL::Triangulation_data_structure_2<Vb_info, CFb_info> CTds;
	typedef CGAL::Constrained_triangulation_2<K, CTds> CTriangulation_2;
	*/

	IndexMap<VERTEX> vertexMap;

	IndexMap<FACE> faceMap;

public:

	TriangulationMap()
	{

	}

	template<class TRI>
	void BuildMaps(TRI& model)
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

	template<class TRI>
	VERTEX* FindVertex(TRI& model, int index)
	{
		SetVertexIndices(model);
		BuildVertexMap(model);
		return vertexMap.Find(index);
	}

	template<class TRI>
	FACE* FindFace(TRI& model, int index)
	{
		SetFaceIndices(model);
		BuildFaceMap(model);
		return faceMap.Find(index);
	}

	template<class TRI>
	void SetVertexIndices(TRI& model)
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

	template<class TRI>
	void BuildVertexMap(TRI& model)
	{
		if (vertexMap.mapBuilt)
			return;

		vertexMap.ClearMap();

		for (auto& vert : model.finite_vertex_handles())
			vertexMap.Insert(vert->info(), vert);

		vertexMap.mapBuilt = true;
	}

	template<class TRI>
	void SetFaceIndices(TRI& model)
	{
		if (faceMap.indicesSet)
			return;

		faceMap.Clear();

		for (auto& face : model.finite_face_handles())
			face->info() = faceMap.NextIndex();

		faceMap.indicesSet = true;
	}

	template<class TRI>
	void BuildFaceMap(TRI& model)
	{
		if (faceMap.mapBuilt)
			return;

		faceMap.ClearMap();

		for (auto& face : model.finite_face_handles())
			faceMap.Insert(face->info(), face);

		faceMap.mapBuilt = true;
	}

	private:

		template<class TRI>
		void ResetFace(const TRI& tri, VERTEX vert)
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
