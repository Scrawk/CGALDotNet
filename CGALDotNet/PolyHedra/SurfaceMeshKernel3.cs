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

        internal abstract void RemoveProperyMaps(IntPtr ptr);

        internal abstract bool IsVertexValid(IntPtr ptr, int index);

        internal abstract bool IsEdgeValid(IntPtr ptr, int index);

        internal abstract bool IsHalfedgeValid(IntPtr ptr, int index);

        internal abstract bool IsFaceValid(IntPtr ptr, int index);

        internal abstract Point3d GetPoint(IntPtr ptr, int index);

        internal abstract void GetPoints(IntPtr ptr, Point3d[] points, int count);

        internal abstract void Transform(IntPtr ptr, Matrix4x4d matrix);

        internal abstract bool IsVertexBorder(IntPtr ptr, int index, bool check_all_incident_halfedges);

        internal abstract bool IsHalfedgeBorder(IntPtr ptr, int index);

        internal abstract bool IsEdgeBorder(IntPtr ptr, int index);

        internal abstract int BorderEdgeCount(IntPtr ptr);

        internal abstract bool IsClosed(IntPtr ptr);

        internal abstract bool CheckFaceVertexCount(IntPtr ptr, int count);

        internal abstract FaceVertexCount GetFaceVertexCount(IntPtr ptr);

        internal abstract void CreateTriangleQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int trianglesCount, int[] quads, int quadsCount);

        internal abstract void GetTriangleQuadIndices(IntPtr ptr, int[] triangles, int trianglesCount, int[] quads, int quadsCount);

        internal abstract void Join(IntPtr ptr, IntPtr otherPtr);

        internal abstract void BuildAABBTree(IntPtr ptr);

        internal abstract void ReleaseAABBTree(IntPtr ptr);

        internal abstract Box3d GetBoundingBox(IntPtr ptr);

        internal abstract void ReadOFF(IntPtr ptr, string filename);

        internal abstract void WriteOFF(IntPtr ptr, string filename);

        internal abstract void Triangulate(IntPtr ptr);

        internal abstract bool DoesSelfIntersect(IntPtr ptr);

        internal abstract double Area(IntPtr ptr);

        internal abstract Point3d Centroid(IntPtr ptr);

        internal abstract double Volume(IntPtr ptr);

        internal abstract bool DoesBoundAVolume(IntPtr ptr);

        internal abstract BOUNDED_SIDE SideOfTriangleMesh(IntPtr ptr, Point3d point);

        internal abstract bool DoIntersects(IntPtr ptr, IntPtr otherPtr, bool test_bounded_sides);

        internal abstract MinMaxAvg MinMaxEdgeLength(IntPtr ptr);

        internal abstract void GetCentroids(IntPtr ptr, Point3d[] points, int count);

        //internal abstract void ClearVertexNormalMap(IntPtr ptr);

        //internal abstract void ClearFaceNormalMap(IntPtr ptr);

        //internal abstract void ComputeVertexNormals(IntPtr ptr);

        //internal abstract void ComputeFaceNormals(IntPtr ptr);

        //internal abstract void GetVertexNormals(IntPtr ptr, Vector3d[] normals, int count);

        //internal abstract void GetFaceNormals(IntPtr ptr, Vector3d[] normals, int count);

    }
}
