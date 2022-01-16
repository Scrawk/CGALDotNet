using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
    internal abstract class PolyhedronKernel3 : FuncKernel
	{
        internal abstract IntPtr Create();

		internal abstract void Release(IntPtr ptr);

		internal abstract void Clear(IntPtr ptr);

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

		internal abstract int IsPureTriangle(IntPtr ptr);

		internal abstract int IsPureQuad(IntPtr ptr);

		internal abstract void MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

		internal abstract void MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3);

		internal abstract void CreateTriangleMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount);

		internal abstract void CreateQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] quads, int quadCount);

		internal abstract void CreateTriangleQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadCount);

		internal abstract void GetPoints(IntPtr ptr, Point3d[] points, int count);

		internal abstract PrimativeCount GetPrimativeCount(IntPtr ptr);

		internal abstract void GetTriangleIndices(IntPtr ptr, int[] indices, int count);

		internal abstract void GetQuadIndices(IntPtr ptr, int[] indices, int count);

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

	}
}
