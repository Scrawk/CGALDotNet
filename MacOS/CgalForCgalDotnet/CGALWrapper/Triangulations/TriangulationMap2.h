#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Collections/IndexMap.h"

#include "CGAL/Point_2.h"
#include <CGAL/Constrained_triangulation_2.h>
#include <CGAL/Triangulation_face_base_with_info_2.h>
#include <CGAL/Triangulation_vertex_base_with_info_2.h>

#include <CGAL/Constrained_triangulation_face_base_2.h>
#include <CGAL/Constrained_triangulation_plus_2.h>

/// <summary>
/// A helper class to hold a triangulations faces and vertices
/// by a int key value that represents their index in the triangulation.
/// Infinite faces/vertices will have a index of -1 set and not be 
/// inculded in the map.
/// </summary>
/// <typeparam name="K">The triangulations kernel type.</typeparam>
/// <typeparam name="VERTEX">The vertex type</typeparam>
/// <typeparam name="FACE">The face type.</typeparam>
template<class K, class VERTEX, class FACE>
class TriangulationMap2
{

private:

	/// <summary>
	/// The map that holds the vertices.
	/// </summary>
	IndexMap<VERTEX> vertexMap;

	/// <summary>
	/// The mape that holds the faces.
	/// </summary>
	IndexMap<FACE> faceMap;

	/// <summary>
	/// A build stamp that is increment anytime the map changes.
	/// </summary>
	int buildStamp;

public:

	TriangulationMap2()
	{
		
	}

	/// <summary>
	/// Get the current build stamp.
	/// </summary>
	/// <returns></returns>
	int BuildStamp()
	{
		return buildStamp;
	}

	/// <summary>
	/// Increment the build stamp.
	/// </summary>
	void IncrementBuildStamp()
	{
		++buildStamp;
	}

	/// <summary>
	/// Build the face and vertex maps
	/// if not already built.
	/// </summary>
	/// <typeparam name="TRI">The triangulations type</typeparam>
	/// <param name="model">The triangulation.</param>
	template<class TRI>
	void BuildMaps(TRI& model)
	{
		BuildVertexMap(model);
		BuildFaceMap(model);
	}

	/// <summary>
	/// Clear the maps to a empty state.
	/// </summary>
	void ClearMaps()
	{
		vertexMap.Clear();
		faceMap.Clear();
	}

	/// <summary>
	/// Call when the triangulation model has changed.
	/// Will mark the faces and vertex maps as needing
	/// to be updated.
	/// </summary>
	void OnModelChanged()
	{
		OnVerticesChanged();
		OnFacesChanged();
	}

	/// <summary>
	/// Call when the triangulation vertices have changed.
	/// </summary>
	void OnVerticesChanged()
	{
		buildStamp++;
		vertexMap.Clear();
	}

	/// <summary>
	/// Call when th triangulation faces have changed.
	/// </summary>
	void OnFacesChanged()
	{
		buildStamp++;
		faceMap.Clear();
	}

	/// <summary>
	/// Find the vertex by its key.
	/// </summary>
	/// <typeparam name="TRI">The triangulation type.</typeparam>
	/// <param name="model">The triangulation.</param>
	/// <param name="index">The vertices index key value.</param>
	/// <returns>The vertex or null.</returns>
	template<class TRI>
	VERTEX* FindVertex(TRI& model, int index)
	{
		if (index == NULL_INDEX) 
			return nullptr;

		SetVertexIndices(model);
		BuildVertexMap(model);
		return vertexMap.Find(index);
	}

	/// <summary>
	/// Find the face by its key.
	/// </summary>
	/// <typeparam name="TRI">The triangulation type.</typeparam>
	/// <param name="model">The triangulation.</param>
	/// <param name="index">The face index key value.</param>
	/// <returns>The face or null.</returns>
	template<class TRI>
	FACE* FindFace(TRI& model, int index)
	{
		if (index == NULL_INDEX)
			return nullptr;

		SetFaceIndices(model);
		BuildFaceMap(model);
		return faceMap.Find(index);
	}

	/// <summary>
	/// Sets the indices of the vertices and faces.
	/// Infinite faces/vertices will have a index of
	/// -1 set and not be inculded in the map.
	/// </summary>
	/// <typeparam name="TRI">The triangulation type.</typeparam>
	/// <param name="model">The triangulation model.</param>
	template<class TRI>
	void SetIndices(TRI& model)
	{
		SetVertexIndices(model);
		SetFaceIndices(model);
	}

	/// <summary>
	/// Sets the indices of the vertices if they have not already been set.
	/// Infinite vertices will have a index of
	/// -1 set and not be inculded in the map.
	/// </summary>
	/// <typeparam name="TRI">The triangulation type.</typeparam>
	/// <param name="model">The triangulation model.</param>
	template<class TRI>
	void SetVertexIndices(TRI& model)
	{
		if (vertexMap.indicesSet)
			return;

		vertexMap.Clear();
		model.infinite_vertex()->info() = NULL_INDEX;

		for (auto& vert : model.finite_vertex_handles())
		{
			//If the vertices face is infinite then try and
			//find one of its other surrounding faces that is 
			//finite and set that as the face.
			if (model.is_infinite(vert->face()))
				ResetFace(model, vert);

			vert->info() = vertexMap.NextIndex();
		}

		vertexMap.indicesSet = true;
	}

	/// <summary>
	/// Build the vertex map by adding each vertex to the map
	/// using its index as the key.
	/// </summary>
	/// <typeparam name="TRI">The triangulation type.</typeparam>
	/// <param name="model">The triangulation model.</param>
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

	/// <summary>
	/// Sets the indices of the faces if they have not already been set.
	/// Infinite faces will have a index of
	/// -1 set and not be inculded in the map.
	/// </summary>
	/// <typeparam name="TRI">The triangulation type.</typeparam>
	/// <param name="model">The triangulation model.</param>
	template<class TRI>
	void SetFaceIndices(TRI& model)
	{
		if (faceMap.indicesSet)
			return;

		faceMap.Clear();
		model.infinite_face()->info() = NULL_INDEX;

		for (auto& face : model.finite_face_handles())
			face->info() = faceMap.NextIndex();

		faceMap.indicesSet = true;
	}

	/// <summary>
	/// Set all the faces indices to the value.
	/// </summary>
	/// <typeparam name="TRI">The triangulation type.</typeparam>
	/// <param name="model">The triangulation model.</param>
	/// <param name="value">The faces index value to uses.</param>
	template<class TRI>
	void ForceSetFaceIndices(TRI& model, int value)
	{
		faceMap.mapBuilt = false;

		for (auto& face : model.finite_face_handles())
			face->info() = value;
	}

	/// <summary>
	/// Build the face map by adding each face to the map
	/// using its index as the key.
	/// </summary>
	/// <typeparam name="TRI">The triangulation type.</typeparam>
	/// <param name="model">The triangulation model.</param>
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

		/// <summary>
		/// If the vertices face is infinite then try and
		/// find one of its other surrounding faces that is 
		/// finite and set that as the face.
		/// </summary>
		/// <typeparam name="TRI">The triangulation type.</typeparam>
		/// <param name="tri">The triangulation model.</param>
		/// <param name="vert">The vertex to reset.</param>
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
