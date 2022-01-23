using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
    internal abstract class SurfaceMeshKernel3 : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void Clear(IntPtr ptr);

        internal abstract IntPtr Copy(IntPtr ptr);

        internal abstract bool IsValid(IntPtr ptr);

        internal abstract int VertexCount(IntPtr ptr);

        internal abstract int HalfEdgeCount(IntPtr ptr);

        internal abstract int EdgeCount(IntPtr ptr);

        internal abstract int FaceCount(IntPtr ptr);

        internal abstract int AddVertex(IntPtr ptr, Point3d point);

        internal abstract int AddEdge(IntPtr ptr, int v0, int v1);

        internal abstract int AddTriangle(IntPtr ptr, int v0, int v1, int v2);

        internal abstract int AddQuad(IntPtr ptr, int v0, int v1, int v2, int v3);

        internal abstract bool HasGarbage(IntPtr ptr);

        internal abstract void CollectGarbage(IntPtr ptr);

        internal abstract void SetRecycleGarbage(IntPtr ptr, bool collect);

        internal abstract bool DoesRecycleGarbage(IntPtr ptr);

        internal abstract int VertexDegree(IntPtr ptr, int index);

        internal abstract int FaceDegree(IntPtr ptr, int index);

        internal abstract bool VertexIsIsolated(IntPtr ptr, int index);

        internal abstract bool VertexIsBorder(IntPtr ptr, int index, bool check_all_incident_halfedges);

        internal abstract bool EdgeIsBorder(IntPtr ptr, int index);

        internal abstract int NextHalfedge(IntPtr ptr, int index);

        internal abstract int PreviousHalfedge(IntPtr ptr, int index);

        internal abstract int OppositeHalfedge(IntPtr ptr, int index);

        internal abstract int SourceVertex(IntPtr ptr, int index);

        internal abstract int TargetVertex(IntPtr ptr, int index);

        internal abstract void RemoveVertex(IntPtr ptr, int index);

        internal abstract void RemoveEdge(IntPtr ptr, int index);

        internal abstract void RemoveFace(IntPtr ptr, int index);

        internal abstract bool IsVertexValid(IntPtr ptr, int index);

        internal abstract bool IsEdgeValid(IntPtr ptr, int index);

        internal abstract bool IsHalfedgeValid(IntPtr ptr, int index);

        internal abstract bool IsFaceValid(IntPtr ptr, int index);

        internal abstract Point3d GetPoint(IntPtr ptr, int index);

        internal abstract void GetPoints(IntPtr ptr, Point3d[] points, int count);

        internal abstract void Transform(IntPtr ptr, Matrix4x4d matrix);

        internal abstract void CreateTriangleMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] indices, int indicesCount);

        //internal abstract bool CheckFaceVertices(IntPtr ptr, int count);

        internal abstract int MaxFaceVertices(IntPtr ptr);

        //internal abstract void GetTriangleIndices(IntPtr ptr, int[] indices, int count);

    }
}
