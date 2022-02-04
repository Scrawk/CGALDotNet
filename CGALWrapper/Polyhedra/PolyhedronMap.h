#pragma once

#include "../CGALWrapper.h"
#include "Polyhedron3.h"

#include <vector>
#include <unordered_map>
#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_items_with_id_3.h>

template<class K>
class PolyhedronMap
{
private:

	typedef typename K::Point_3 Point;
	typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;
	typedef typename boost::graph_traits<Polyhedron>::vertex_descriptor	Vertex_Des;
	typedef typename boost::graph_traits<Polyhedron>::face_descriptor Face_Des;
	typedef typename boost::graph_traits<Polyhedron>::edge_descriptor Edge_Des;
	typedef typename boost::graph_traits<Polyhedron>::halfedge_descriptor Halfedge_Des;

	typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
	typedef typename HalfedgeDS::Vertex Vertex;
	typedef typename HalfedgeDS::Face Face;
	typedef typename HalfedgeDS::Halfedge Halfedge;

	int buildStamp = 1;

	std::unordered_map<Vertex_Des, int> vertexIndexMap;
	std::vector<Vertex> vertexMap;
	std::vector<Vertex_Des> vertexDesMap;
	bool rebuildVertexIndexMap = true;

	std::unordered_map<Face_Des, int> faceIndexMap;
	std::vector<Face_Des> faceDesMap;
	bool rebuildFaceIndexMap = true;

	std::unordered_map<Halfedge_Des, int> halfedgeIndexMap;
	std::vector<Halfedge_Des> halfedgeDesMap;
	bool rebuildHalfedgeIndexMap = true;

public:

	int VertexCount()
	{
		return (int)vertexDesMap.size();
	}

	int FaceCount()
	{
		return (int)faceDesMap.size();
	}

	int HalfedgeCount()
	{
		return (int)halfedgeDesMap.size();
	}

	int BuildStamp()
	{
		return buildStamp;
	}

	void OnVerticesChanged()
	{
		vertexDesMap.clear();
		vertexDesMap.reserve(0);
		vertexIndexMap.clear();
		rebuildVertexIndexMap = true;
	}

	void OnFacesChanged()
	{
		faceDesMap.clear();
		faceDesMap.reserve(0);
		faceIndexMap.clear();
		rebuildFaceIndexMap = true;
	}

	void OnHalfedgesChanged()
	{
		halfedgeDesMap.clear();
		halfedgeDesMap.reserve(0);
		halfedgeIndexMap.clear();
		rebuildHalfedgeIndexMap = true;
	}

	void Clear()
	{
		OnVerticesChanged();
		OnFacesChanged();
		OnHalfedgesChanged();
	}

	void BuildVertexMaps(Polyhedron& model, bool force = false)
	{
		if (!force && !rebuildVertexIndexMap) return;
		rebuildVertexIndexMap = false;

		auto count = model.size_of_vertices();
		vertexMap.reserve(count);
		vertexDesMap.reserve(count);
		vertexIndexMap.clear();

		int index = 0;
		for (auto vert = model.vertices_begin(); vert != model.vertices_end(); ++vert)
		{
			//vert->id() = index;
			vertexMap.push_back(*vert);
			vertexDesMap.push_back(vert);
			vertexIndexMap.insert(std::pair<Vertex_Des, int>(vert, index));
			index++;
		}
	}

	void BuildFaceMaps(Polyhedron& model, bool force = false)
	{
		if (!force && !rebuildFaceIndexMap) return;
		rebuildFaceIndexMap = false;

		auto count = model.size_of_facets();
		faceDesMap.reserve(count);
		faceIndexMap.clear();

		int index = 0;
		for (auto face = model.facets_begin(); face != model.facets_end(); ++face)
		{
			//face->id() = index;
			faceDesMap.push_back(face);
			faceIndexMap.insert(std::pair<Face_Des, int>(face, index));
			index++;
		}
	}

	void BuildHalfedgeMaps(Polyhedron& model, bool force = false)
	{
		if (!force && !rebuildHalfedgeIndexMap) return;
		rebuildHalfedgeIndexMap = false;

		auto count = model.size_of_halfedges();
		halfedgeDesMap.reserve(count);
		halfedgeIndexMap.clear();

		int index = 0;
		for (auto hedge = model.halfedges_begin(); hedge != model.halfedges_end(); ++hedge)
		{
			//hedge->id() = index;
			halfedgeDesMap.push_back(hedge);
			halfedgeIndexMap.insert(std::pair<Halfedge_Des, int>(hedge, index));
			index++;
		}
	}

	int FindVertexIndex(Vertex_Des vert)
	{
		auto item = vertexIndexMap.find(vert);
		if (item != vertexIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Vertex_Des* FindVertexDes(int index)
	{
		int count = (int)vertexDesMap.size();
		if (index < 0 || index >= count)
			return nullptr;

		return &vertexDesMap[index];
	}

	Vertex* FindVertex(int index)
	{
		int count = (int)vertexMap.size();
		if (index < 0 || index >= count)
			return nullptr;

		return &vertexMap[index];
	}

	Vertex* GetVertex(int index)
	{
		return &vertexMap[index];
	}

	int FindFaceIndex(Face_Des vert)
	{
		auto item = faceIndexMap.find(vert);
		if (item != faceIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Face_Des* FindFaceDes(int index)
	{
		int count = (int)faceDesMap.size();
		if (index < 0 || index >= count)
			return nullptr;

		return &faceDesMap[index];
	}

	int FindHalfedgeIndex(Halfedge_Des edge)
	{
		auto item = halfedgeIndexMap.find(edge);
		if (item != halfedgeIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Halfedge_Des* FindHalfedgeDes(int index)
	{
		int count = (int)halfedgeDesMap.size();
		if (index < 0 || index >= count)
			return nullptr;

		return &halfedgeDesMap[index];
	}

	Halfedge_Des GetHalfedgeDes(int index)
	{
		return halfedgeDesMap[index];
	}

};
