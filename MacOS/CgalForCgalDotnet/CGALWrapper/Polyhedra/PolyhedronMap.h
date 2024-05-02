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
	typedef CGAL::Polyhedron_3<K> Polyhedron;
	//typedef CGAL::Polyhedron_3<K, CGAL::Polyhedron_items_with_id_3> Polyhedron;
	//typedef typename boost::graph_traits<Polyhedron>::vertex_descriptor	Vertex_Des;
	//typedef typename boost::graph_traits<Polyhedron>::face_descriptor Face_Des;
	//typedef typename boost::graph_traits<Polyhedron>::edge_descriptor Edge_Des;
	//typedef typename boost::graph_traits<Polyhedron>::halfedge_descriptor Halfedge_Des;

	typedef typename Polyhedron::HalfedgeDS HalfedgeDS;
	typedef typename HalfedgeDS::Vertex Vertex;
	typedef typename HalfedgeDS::Face Face;
	typedef typename HalfedgeDS::Halfedge Halfedge;

	typedef typename HalfedgeDS::Vertex_iterator Vertex_Iter;
	typedef typename HalfedgeDS::Face_iterator Face_Iter;
	typedef typename HalfedgeDS::Halfedge_iterator Halfedge_Iter;

	int buildStamp = 1;

	std::unordered_map<Vertex_Iter, int> vertexIndexMap;
	//std::vector<Vertex> vertexMap;
	std::vector<Vertex_Iter> vertexIterMap;
	bool rebuildVertexIndexMap = true;

	std::unordered_map<Face_Iter, int> faceIndexMap;
	std::vector<Face_Iter> faceIterMap;
	bool rebuildFaceIndexMap = true;

	std::unordered_map<Halfedge_Iter, int> halfedgeIndexMap;
	std::vector<Halfedge_Iter> halfedgeIterMap;
	bool rebuildHalfedgeIndexMap = true;

public:

	int BuildStamp()
	{
		return buildStamp;
	}

	void OnVerticesChanged()
	{
		vertexIterMap.clear();
		vertexIterMap.reserve(0);
		//vertexIndexMap.clear();
		rebuildVertexIndexMap = true;
	}

	void OnFacesChanged()
	{
		faceIterMap.clear();
		faceIterMap.reserve(0);
		//faceIndexMap.clear();
		rebuildFaceIndexMap = true;
	}

	void OnHalfedgesChanged()
	{
		halfedgeIterMap.clear();
		halfedgeIterMap.reserve(0);
		//halfedgeIndexMap.clear();
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
		//vertexMap.reserve(count);
		vertexIterMap.reserve(count);
		vertexIndexMap.clear();

		int index = 0;
		for (auto vert = model.vertices_begin(); vert != model.vertices_end(); ++vert)
		{
			//vert->id() = index;
			//vertexMap.push_back(*vert);
			vertexIterMap.push_back(vert);
			vertexIndexMap.insert(std::pair<Vertex_Iter, int>(vert, index));
			index++;
		}
		
	}

	void BuildFaceMaps(Polyhedron& model, bool force = false)
	{
		if (!force && !rebuildFaceIndexMap) return;
		rebuildFaceIndexMap = false;

		auto count = model.size_of_facets();
		faceIterMap.reserve(count);
		faceIndexMap.clear();

		int index = 0;
		for (Face_Iter face = model.facets_begin(); face != model.facets_end(); ++face)
		{
			//face->id() = index;
			faceIterMap.push_back(face);
			faceIndexMap.insert(std::pair<Face_Iter, int>(face, index));
			index++;
		}
	}

	void BuildHalfedgeMaps(Polyhedron& model, bool force = false)
	{
		if (!force && !rebuildHalfedgeIndexMap) return;
		rebuildHalfedgeIndexMap = false;

		auto count = model.size_of_halfedges();
		halfedgeIterMap.reserve(count);
		halfedgeIndexMap.clear();

		int index = 0;
		for (Halfedge_Iter hedge = model.halfedges_begin(); hedge != model.halfedges_end(); ++hedge)
		{
			//hedge->id() = index;
			halfedgeIterMap.push_back(hedge);
			halfedgeIndexMap.insert(std::pair<Halfedge_Iter, int>(hedge, index));
			index++;
		}
	}

	int FindVertexIndex(Polyhedron& model, Vertex_Iter v)
	{
		//return v->id();

		/*
		int i = 0;
		for (Vertex_Iter vert = model.vertices_begin(); vert != model.vertices_end(); ++vert)
		{
			if (v == vert) return i;
			i++;
		}

		*/

		auto item = vertexIndexMap.find(v);
		if (item != vertexIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Vertex_Iter* FindVertexIter(Polyhedron& model, int index)
	{
		/*
		int i = 0;
		for (Vertex_Iter vert = model.vertices_begin(); vert != model.vertices_end(); ++vert)
		{
			if (i == index) return &vert;
			i++;
		}

		return nullptr;
		*/

		int count = (int)vertexIterMap.size();
		if (index < 0 || index >= count)
			return nullptr;

		return &vertexIterMap[index];

	}

	Vertex* FindVertex(Polyhedron& model, int index)
	{
		int count = (int)model.size_of_vertices();

		int i = 0;
		for (Vertex_Iter vert = model.vertices_begin(); vert != model.vertices_end(); ++vert)
		{
			if (i == index) return &(*vert);
			i++;
		}

		return nullptr;

		/*
		int count = (int)vertexMap.size();
		if (index < 0 || index >= count)
			return nullptr;

		return &vertexMap[index];
		*/
	}

	int FindFaceIndex(Face_Iter face)
	{
		//return face->id();

		auto item = faceIndexMap.find(face);
		if (item != faceIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Face_Iter* FindFaceIter(int index)
	{
		int count = (int)faceIterMap.size();
		if (index < 0 || index >= count)
			return nullptr;

		return &faceIterMap[index];
	}

	int FindHalfedgeIndex(Halfedge_Iter edge)
	{
		//return edge->id();
		
		auto item = halfedgeIndexMap.find(edge);
		if (item != halfedgeIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
			
	}

	Halfedge_Iter* FindHalfedgeIter(int index)
	{
		int count = (int)halfedgeIterMap.size();
		if (index < 0 || index >= count)
			return nullptr;

		return &halfedgeIterMap[index];
	}

	Halfedge_Iter GetHalfedgeIter(int index)
	{
		return halfedgeIterMap[index];
	}

};
