#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Polyhedron_incremental_builder_3.h>

template <class HDS, class K>
class BuildTriangleMesh : public CGAL::Modifier_base<HDS>
{
public:

	Point3d* vertices;

	int verticesCount;

	int* triangles;

	int triangleCount;

	void operator()(HDS& hds)
	{
		typedef typename HDS::Vertex   Vertex;
		typedef typename Vertex::Point Point;

		CGAL::Polyhedron_incremental_builder_3<HDS> B(hds);

		//Only a estimate of actual count
		int numTriangles = triangleCount / 3;
		int numEdges = numTriangles * 6;

		B.begin_surface(verticesCount, numTriangles, numEdges, B.ABSOLUTE_INDEXING);

		for (int i = 0; i < verticesCount; i++)
		{
			auto p = vertices[i].ToCGAL<K>();
			B.add_vertex(p);
		}

		for (int i = 0; i < numTriangles; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(triangles[i * 3 + 0]);
			B.add_vertex_to_facet(triangles[i * 3 + 1]);
			B.add_vertex_to_facet(triangles[i * 3 + 2]);
			B.end_facet();
		}

		B.end_surface();
	}
};

template <class HDS, class K>
class BuildQuadMesh : public CGAL::Modifier_base<HDS>
{
public:

	Point3d* vertices;

	int verticesCount;

	int* quads;

	int quadCount;

	void operator()(HDS& hds)
	{
		typedef typename HDS::Vertex   Vertex;
		typedef typename Vertex::Point Point;

		CGAL::Polyhedron_incremental_builder_3<HDS> B(hds);

		//Only a estimate of actual count
		int numQuads = quadCount / 4;
		int numEdges = numQuads * 8;

		B.begin_surface(verticesCount, numQuads, numEdges, B.ABSOLUTE_INDEXING);

		for (int i = 0; i < verticesCount; i++)
		{
			auto p = vertices[i].ToCGAL<K>();
			B.add_vertex(p);
		}

		for (int i = 0; i < numQuads; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(quads[i * 4 + 0]);
			B.add_vertex_to_facet(quads[i * 4 + 1]);
			B.add_vertex_to_facet(quads[i * 4 + 2]);
			B.add_vertex_to_facet(quads[i * 4 + 3]);
			B.end_facet();
		}

		B.end_surface();
	}
};

template <class HDS, class K>
class BuildTriangleQuadMesh : public CGAL::Modifier_base<HDS>
{
public:

	Point3d* vertices;

	int verticesCount;

	int* triangles;

	int triangleCount;

	int* quads;

	int quadCount;

	void operator()(HDS& hds)
	{
		typedef typename HDS::Vertex   Vertex;
		typedef typename Vertex::Point Point;

		CGAL::Polyhedron_incremental_builder_3<HDS> B(hds);

		//Only a estimate of actual count
		int numTriangles = triangleCount / 3;
		int numQuads = quadCount / 4;
		int numFaces = numTriangles + numQuads;
		int numEdges = numTriangles * 6 + numQuads * 8;

		B.begin_surface(verticesCount, numFaces, numEdges, B.ABSOLUTE_INDEXING);

		for (int i = 0; i < verticesCount; i++)
		{
			auto p = vertices[i].ToCGAL<K>();
			B.add_vertex(p);
		}

		for (int i = 0; i < numTriangles; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(triangles[i * 3 + 0]);
			B.add_vertex_to_facet(triangles[i * 3 + 1]);
			B.add_vertex_to_facet(triangles[i * 3 + 2]);
			B.end_facet();
		}

		for (int i = 0; i < numQuads; i++)
		{
			B.begin_facet();
			B.add_vertex_to_facet(quads[i * 4 + 0]);
			B.add_vertex_to_facet(quads[i * 4 + 1]);
			B.add_vertex_to_facet(quads[i * 4 + 2]);
			B.add_vertex_to_facet(quads[i * 4 + 3]);
			B.end_facet();
		}

		B.end_surface();
	}
};
