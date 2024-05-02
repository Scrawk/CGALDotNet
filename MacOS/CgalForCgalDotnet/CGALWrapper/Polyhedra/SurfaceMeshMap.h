#pragma once

#include "../CGALWrapper.h"
#include "SurfaceMesh3.h"

#include <unordered_map>
#include <CGAL/Surface_mesh.h>

template<class K>
class SurfaceMeshMap
{
private:

	typedef typename K::Point_3 Point_3;
	typedef typename CGAL::Surface_mesh<Point_3> SurfaceMesh;
	typedef typename SurfaceMesh::Edge_index Edge;
	typedef typename SurfaceMesh::Halfedge_index Halfedge;
	typedef typename SurfaceMesh::Vertex_index Vertex;
	typedef typename SurfaceMesh::Face_index Face;

	int buildStamp = 1;

	std::unordered_map<Vertex, int> vertexIndexMap;
	std::vector<Vertex> vertexMap;
	bool rebuildVertexIndexMap = true;

	std::unordered_map<Face, int> faceIndexMap;
	std::vector<Face> faceMap;
	bool rebuildFaceIndexMap = true;

	std::unordered_map<Edge, int> edgeIndexMap;
	std::vector<Edge> edgeMap;
	bool rebuildEdgeIndexMap = true;

	std::unordered_map<Halfedge, int> halfedgeIndexMap;
	std::vector<Halfedge> halfedgeMap;
	bool rebuildHalfedgeIndexMap = true;

public:

	int VertexCount()
	{
		return (int)vertexMap.size();
	}

	int FaceCount()
	{
		return (int)faceMap.size();
	}

	int EdgeCount()
	{
		return (int)edgeMap.size();
	}

	int HalfedgeCount()
	{
		return (int)halfedgeMap.size();
	}

	int BuildStamp()
	{
		return buildStamp;
	}

	void OnVerticesChanged()
	{
		vertexMap.clear();
		vertexMap.reserve(0);
		vertexIndexMap.clear();
		vertexIndexMap.reserve(0);
		rebuildVertexIndexMap = true;
		buildStamp++;
	}

	void OnFacesChanged()
	{
		faceMap.clear();
		faceMap.reserve(0);
		faceIndexMap.clear();
		faceIndexMap.reserve(0);
		rebuildFaceIndexMap = true;
		buildStamp++;
	}

	void OnEdgesChanged()
	{
		edgeMap.clear();
		edgeMap.reserve(0);
		edgeIndexMap.clear();
		edgeIndexMap.reserve(0);
		rebuildEdgeIndexMap = true;
		buildStamp++;
	}

	void OnHalfedgesChanged()
	{
		halfedgeMap.clear();
		halfedgeMap.reserve(0);
		halfedgeIndexMap.clear();
		halfedgeIndexMap.reserve(0);
		rebuildHalfedgeIndexMap = true;
		buildStamp++;
	}

	void Clear()
	{
		OnVerticesChanged();
		OnFacesChanged();
		OnEdgesChanged();
		OnHalfedgesChanged();
	}

	void BuildVertexMaps(const SurfaceMesh& model, bool force = false)
	{
		if (!force && !rebuildVertexIndexMap) return;
		rebuildVertexIndexMap = false;

		vertexMap.clear();
		vertexMap.reserve(model.number_of_vertices());
		vertexIndexMap.clear();

		int index = 0;
		for (auto vertex : model.vertices())
		{
			//std::cout << "Vetex = " << vertex<< " Index " << index << std::endl;
			vertexMap.push_back(vertex);
			vertexIndexMap.insert(std::pair<Vertex, int>(vertex, index));
			index++;
		}
	}

	void BuildFaceMaps(const SurfaceMesh& model, bool force = false)
	{
		if (!force && !rebuildFaceIndexMap) return;
		rebuildFaceIndexMap = false;

		faceMap.clear();
		faceMap.reserve(model.number_of_faces());
		faceIndexMap.clear();

		int index = 0;
		for (auto face : model.faces())
		{
			//std::cout << "Face = " << face << " Index " << index << std::endl;
			faceMap.push_back(face);
			faceIndexMap.insert(std::pair<Face, int>(face, index));
			index++;
		}
	}

	void BuildEdgeMaps(const SurfaceMesh& model, bool force = false)
	{
		if (!force && !rebuildEdgeIndexMap) return;
		rebuildEdgeIndexMap = false;

		edgeMap.clear();
		edgeMap.reserve(model.number_of_edges());
		edgeIndexMap.clear();

		int index = 0;
		for (auto edge : model.edges())
		{
			//std::cout << "Edge = " << edge << " Index " << index << std::endl;
			edgeMap.push_back(edge);
			edgeIndexMap.insert(std::pair<Edge, int>(edge, index));
			index++;
		}
	}

	void BuildHalfedgeMaps(const SurfaceMesh& model, bool force = false)
	{
		if (!force && !rebuildHalfedgeIndexMap) return;
		rebuildHalfedgeIndexMap = false;

		halfedgeMap.clear();
		halfedgeMap.reserve(model.number_of_halfedges());
		halfedgeIndexMap.clear();

		int index = 0;
		for (auto edge : model.halfedges())
		{
			//std::cout << "Halfedge = " << edge << " Index " << index << std::endl;
			halfedgeMap.push_back(edge);
			halfedgeIndexMap.insert(std::pair<Halfedge, int>(edge, index));
			index++;
		}
	}

	int FindVertexIndex(Vertex vertex)
	{
		auto item = vertexIndexMap.find(vertex);
		if (item != vertexIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Vertex FindVertex(int index)
	{
		int count = (int)vertexMap.size();
		if (index < 0 || index >= count)
			return SurfaceMesh::null_vertex();

		return Vertex(vertexMap[index]);
	}

	Vertex GetVertex(int index)
	{
		return Vertex(vertexMap[index]);
	}

	int FindFaceIndex(Face face)
	{
		auto item = faceIndexMap.find(face);
		if (item != faceIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Face FindFace(int index)
	{
		int count = (int)faceMap.size();
		if (index < 0 || index >= count)
			return SurfaceMesh::null_face();

		return Face(faceMap[index]);
	}

	Face GetFace(int index)
	{
		return Face(faceMap[index]);
	}

	int FindEdgeIndex(Edge edge)
	{
		auto item = edgeIndexMap.find(edge);
		if (item != edgeIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Edge FindEdge(int index)
	{
		int count = (int)edgeMap.size();
		if (index < 0 || index >= count)
			return SurfaceMesh::null_edge();

		return Edge(edgeMap[index]);
	}

	Edge GetEdge(int index)
	{
		return Edge(edgeMap[index]);
	}

	int FindHalfedgeIndex(Halfedge edge)
	{
		auto item = halfedgeIndexMap.find(edge);
		if (item != halfedgeIndexMap.end())
			return item->second;
		else
			return NULL_INDEX;
	}

	Halfedge FindHalfedge(int index)
	{
		int count = (int)halfedgeMap.size();
		if (index < 0 || index >= count)
			return SurfaceMesh::null_halfedge();

		return Halfedge(halfedgeMap[index]);
	}

	Halfedge GetHalfedge(int index)
	{
		return Halfedge(halfedgeMap[index]);
	}

	void PrintVertices(const SurfaceMesh& model)
	{
		std::cout << "Vertex indices" << std::endl;
		for (auto vertex : model.vertices())
		{
			int index = FindVertexIndex(vertex);
			if (index == NULL_INDEX)
			{
				std::cout << "Vertex = " << vertex
					<< ", Index = " << index << std::endl;
			}
			else
			{
				auto point = model.point(vertex);
				std::cout << "Vertex = " << vertex
					<< ", Index = " << index
					<< ", Point = " << point << std::endl;
			}
		}
	}

	void PrintFaces(const SurfaceMesh& model)
	{
		std::cout << "Face indices" << std::endl;
		for (auto face : model.faces())
		{
			std::cout << "Face = " << face
				<< ", Index = " << FindFaceIndex(face) << std::endl;
		}
	}

	void PrintEdges(const SurfaceMesh& model)
	{
		std::cout << "Edges indices" << std::endl;
		for (auto edge : model.edges())
		{
			std::cout << "Edge = " << edge
				<< ", Index = " << FindEdgeIndex(edge) << std::endl;
		}
	}

	void PrintHalfedges(const SurfaceMesh& model)
	{
		std::cout << "Halfedges indices" << std::endl;
		for (auto edge : model.halfedges())
		{
			std::cout << "Halfedge = " << edge
				<< ", Index = " << FindHalfedgeIndex(edge) << std::endl;
		}
	}

};

