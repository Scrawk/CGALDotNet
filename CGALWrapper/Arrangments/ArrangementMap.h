#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Utility/IndexMap.h"

#include <vector>
#include "CGAL/Point_2.h"
#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>

template<class K, class VERTEX, class FACE, class EDGE>
class ArrangementMap
{

private:

	IndexMap<VERTEX> vertexMap;

	IndexMap<FACE> faceMap;

	IndexMap<EDGE> edgeMap;

public:

	ArrangementMap()
	{

	}

	template<class ARR>
	void BuildMaps(ARR& model)
	{
		BuildVertexMap(model);
		BuildFaceMap(model);
	}

	void ClearMaps()
	{
		vertexMap.Clear();
		faceMap.Clear();
		edgeMap.Clear();
	}

	void OnModelChanged()
	{
		OnVerticesChanged();
		OnFacesChanged();
		OnEdgesChanged();
	}

	template<class ARR>
	void SetIndices(ARR& model)
	{
		SetVertexIndices(model);
		SetFaceIndices(model);
		SetEdgeIndices(model);
	}

	void OnVerticesChanged()
	{
		vertexMap.Clear();
	}

	void OnFacesChanged()
	{
		faceMap.Clear();
	}

	void OnEdgesChanged()
	{
		edgeMap.Clear();
	}

	template<class ARR>
	VERTEX* FindVertex(ARR& model, int index)
	{
		if (index == NULL_INDEX)
			return nullptr;

		SetVertexIndices(model);
		BuildVertexMap(model);
		return vertexMap.Find(index);
	}

	template<class ARR>
	FACE* FindFace(ARR& model, int index)
	{
		if (index == NULL_INDEX)
			return nullptr;

		SetFaceIndices(model);
		BuildFaceMap(model);
		return faceMap.Find(index);
	}

	template<class ARR>
	EDGE* FindEdge(ARR& model, int index)
	{
		if (index == NULL_INDEX)
			return nullptr;

		SetEdgeIndices(model);
		BuildEdgeMap(model);
		return edgeMap.Find(index);
	}

	template<class ARR>
	void SetVertexIndices(ARR& model)
	{
		if (vertexMap.indicesSet)
			return;

		vertexMap.Clear();

		for (auto iter = model.vertices_begin(); iter != model.vertices_end(); ++iter)
			iter->set_data(vertexMap.NextIndex());

		vertexMap.indicesSet = true;
	}

	template<class ARR>
	void BuildVertexMap(ARR& model)
	{
		if (vertexMap.mapBuilt)
			return;

		vertexMap.ClearMap();

		for (auto iter = model.vertices_begin(); iter != model.vertices_end(); ++iter)
			vertexMap.Insert(iter->data(), iter);

		vertexMap.mapBuilt = true;
	}

	template<class ARR>
	void SetFaceIndices(ARR& model)
	{
		if (faceMap.indicesSet)
			return;

		faceMap.Clear();

		for (auto iter = model.faces_begin(); iter != model.faces_end(); ++iter)
			iter->set_data(faceMap.NextIndex());

		faceMap.indicesSet = true;
	}

	template<class ARR>
	void BuildFaceMap(ARR& model)
	{
		if (faceMap.mapBuilt)
			return;

		faceMap.ClearMap();

		for (auto iter = model.faces_begin(); iter != model.faces_end(); ++iter)
			faceMap.Insert(iter->data(), iter);

		faceMap.mapBuilt = true;
	}

	template<class ARR>
	void SetEdgeIndices(ARR& model)
	{
		if (edgeMap.indicesSet)
			return;

		edgeMap.Clear();

		for (auto iter = model.halfedges_begin(); iter != model.halfedges_end(); ++iter)
			iter->set_data(edgeMap.NextIndex());

		edgeMap.indicesSet = true;
	}

	template<class ARR>
	void BuildEdgeMap(ARR& model)
	{
		if (edgeMap.mapBuilt)
			return;

		edgeMap.ClearMap();

		for (auto iter = model.halfedges_begin(); iter != model.halfedges_end(); ++iter)
			edgeMap.Insert(iter->data(), iter);

		edgeMap.mapBuilt = true;
	}

};
