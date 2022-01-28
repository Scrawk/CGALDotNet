#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Collections/IndexMap.h"

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

	int buildStamp;

public:

	ArrangementMap()
	{

	}

	int BuildStamp()
	{
		return buildStamp;
	}

	void IncrementBuildStamp()
	{
		++buildStamp;
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
		buildStamp++;
		vertexMap.Clear();
	}

	void OnFacesChanged()
	{
		buildStamp++;
		faceMap.Clear();
	}

	void OnEdgesChanged()
	{
		buildStamp++;
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

		for (auto vert = model.vertices_begin(); vert != model.vertices_end(); ++vert)
			vert->set_data(vertexMap.NextIndex());

		vertexMap.indicesSet = true;
	}

	template<class ARR>
	void BuildVertexMap(ARR& model)
	{
		if (vertexMap.mapBuilt)
			return;

		vertexMap.ClearMap();

		for (auto vert = model.vertices_begin(); vert != model.vertices_end(); ++vert)
			vertexMap.Insert(vert->data(), vert);

		vertexMap.mapBuilt = true;
	}

	template<class ARR>
	void SetFaceIndices(ARR& model)
	{
		if (faceMap.indicesSet)
			return;

		faceMap.Clear();

		for (auto face = model.faces_begin(); face != model.faces_end(); ++face)
		{
			if (!face->is_unbounded())
				face->set_data(faceMap.NextIndex());
			else
				face->set_data(-1);
		}
			
		faceMap.indicesSet = true;
	}

	template<class ARR>
	void BuildFaceMap(ARR& model)
	{
		if (faceMap.mapBuilt)
			return;

		faceMap.ClearMap();

		for (auto face = model.faces_begin(); face != model.faces_end(); ++face)
		{
			if(!face->is_unbounded())
				faceMap.Insert(face->data(), face);
		}
			
		faceMap.mapBuilt = true;
	}

	template<class ARR>
	void SetEdgeIndices(ARR& model)
	{
		if (edgeMap.indicesSet)
			return;

		edgeMap.Clear();

		for (auto edge = model.halfedges_begin(); edge != model.halfedges_end(); ++edge)
			edge->set_data(edgeMap.NextIndex());

		edgeMap.indicesSet = true;
	}

	template<class ARR>
	void BuildEdgeMap(ARR& model)
	{
		if (edgeMap.mapBuilt)
			return;

		edgeMap.ClearMap();

		for (auto edge = model.halfedges_begin(); edge != model.halfedges_end(); ++edge)
			edgeMap.Insert(edge->data(), edge);

		edgeMap.mapBuilt = true;
	}

};
