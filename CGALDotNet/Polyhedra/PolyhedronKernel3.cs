using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
    internal abstract class PolyhedronKernel3 : CGALObjectKernel
	{
        internal abstract IntPtr Create();

		internal abstract void Release(IntPtr ptr);

		internal abstract int GetBuildStamp(IntPtr ptr);

		internal abstract void Clear(IntPtr ptr);

		internal abstract void ClearIndexMaps(IntPtr ptr, bool vertices, bool faces, bool edges);

		internal abstract void ClearNormalMaps(IntPtr ptr, bool vertices, bool faces);

		internal abstract void BuildIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool force);

		internal abstract IntPtr Copy(IntPtr ptr);

		internal abstract int VertexCount(IntPtr ptr);

		internal abstract int FaceCount(IntPtr ptr);

		internal abstract int HalfEdgeCount(IntPtr ptr);

		internal abstract int BorderEdgeCount(IntPtr ptr);

		internal abstract int BorderHalfEdgeCount(IntPtr ptr);

		internal abstract bool IsValid(IntPtr ptr, int level);

		internal abstract bool IsClosed(IntPtr ptr);

		internal abstract bool IsPureBivalent(IntPtr ptr);

		internal abstract bool IsPureTrivalent(IntPtr ptr);

		internal abstract bool IsPureTriangle(IntPtr ptr);

		internal abstract bool IsPureQuad(IntPtr ptr);

		internal abstract Box3d GetBoundingBox(IntPtr ptr);

		internal abstract int MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

		internal abstract int MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3);

		internal abstract Point3d GetPoint(IntPtr ptr, int index);

		internal abstract void GetPoints(IntPtr ptr, Point3d[] points, int count);

		internal abstract void SetPoint(IntPtr ptr, int index, Point3d point);

		internal abstract void SetPoints(IntPtr ptr, Point3d[] points, int count);

		internal abstract bool GetSegment(IntPtr ptr, int index, out Segment3d segment);

		internal abstract bool GetTriangle(IntPtr ptr, int index, out Triangle3d tri);

		internal abstract bool GetVertex(IntPtr ptr, int index, out MeshVertex3 vert);

		internal abstract bool GetFace(IntPtr ptr, int index, out MeshFace3 face);

		internal abstract bool GetHalfedge(IntPtr ptr, int index, out MeshHalfedge3 edge);

		internal abstract void GetSegments(IntPtr ptr, Segment3d[] segments, int count);

		internal abstract void GetTriangles(IntPtr ptr, Triangle3d[] triangles, int count);

		internal abstract void GetVertices(IntPtr ptr, MeshVertex3[] vertices, int count);

		internal abstract void GetFaces(IntPtr ptr, MeshFace3[] faces, int count);

		internal abstract void GetHalfedges(IntPtr ptr, MeshHalfedge3[] edges, int count);

		internal abstract void Transform(IntPtr ptr, Matrix4x4d matrix);

		internal abstract void InsideOut(IntPtr ptr);

		internal abstract void Triangulate(IntPtr ptr);

		internal abstract void NormalizeBorder(IntPtr ptr);

		internal abstract bool NormalizedBorderIsValid(IntPtr ptr);

		internal abstract BOUNDED_SIDE SideOfTriangleMesh(IntPtr ptr, Point3d point);

		internal abstract double Area(IntPtr ptr);

		internal abstract Point3d Centroid(IntPtr ptr);

		internal abstract double Volume(IntPtr ptr);

		internal abstract bool DoesBoundAVolume(IntPtr ptr);

		internal abstract void BuildAABBTree(IntPtr ptr);

		internal abstract void ReleaseAABBTree(IntPtr ptr);

		internal abstract bool DoesSelfIntersect(IntPtr ptr);

		internal abstract bool DoIntersects(IntPtr ptr, IntPtr otherPtr, bool test_bounded_sides);

		internal abstract void ReadOFF(IntPtr ptr, string filename);

		internal abstract void WriteOFF(IntPtr ptr, string filename);

		internal abstract void GetCentroids(IntPtr ptr, Point3d[] points, int count);

		internal abstract void ComputeVertexNormals(IntPtr ptr);

		internal abstract void ComputeFaceNormals(IntPtr ptr);

		internal abstract void GetVertexNormals(IntPtr ptr, Vector3d[] normals, int count);

		internal abstract void GetFaceNormals(IntPtr ptr, Vector3d[] normals, int count);

		internal abstract void CreatePolygonMesh(IntPtr ptr, Point2d[] points, int pointsCount, bool xz);

		internal abstract PolygonalCount GetPolygonalCount(IntPtr ptr);

		internal abstract PolygonalCount GetDualPolygonalCount(IntPtr ptr);

		internal abstract void CreatePolygonalMesh(IntPtr ptr,
			Point3d[] points, int pointsCount,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount);

		internal abstract void GetPolygonalIndices(IntPtr ptr,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount);

		internal abstract void GetDualPolygonalIndices(IntPtr ptr,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount);

		internal abstract int AddFacetToBorder(IntPtr ptr, int h, int g);

		internal abstract int AddVertexAndFacetToBorder(IntPtr ptr, int h, int g);

		internal abstract int CreateCenterVertex(IntPtr ptr, int h);

		internal abstract int EraseCenterVertex(IntPtr ptr, int h);

		internal abstract bool EraseConnectedComponent(IntPtr ptr, int h);

		internal abstract bool EraseFacet(IntPtr ptr, int h);

		internal abstract int FillHole(IntPtr ptr, int h);

		internal abstract int FlipEdge(IntPtr ptr, int h);

		internal abstract int JoinFacet(IntPtr ptr, int h);

		internal abstract int JoinLoop(IntPtr ptr, int h, int g);

		internal abstract int JoinVertex(IntPtr ptr, int h);

		internal abstract int MakeHole(IntPtr ptr, int h);

		internal abstract int SplitEdge(IntPtr ptr, int h);

		internal abstract int SplitFacet(IntPtr ptr, int h, int g);

		internal abstract int SplitLoop(IntPtr ptr, int h, int g, int k);

		internal abstract int SplitVertex(IntPtr ptr, int h, int g);

	}
}
