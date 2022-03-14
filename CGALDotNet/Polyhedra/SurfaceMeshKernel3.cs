using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
    internal abstract class SurfaceMeshKernel3 : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract int GetBuildStamp(IntPtr ptr);

        internal abstract void Clear(IntPtr ptr);

        internal abstract void ClearIndexMaps(IntPtr ptr, bool vertices, bool faces, bool edges, bool halfedges);

        internal abstract void ClearNormalMaps(IntPtr ptr, bool vertices, bool faces);

        internal abstract void ClearProperyMaps(IntPtr ptr);

        internal abstract void BuildIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool halfedges, bool force);

        internal abstract void PrintIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool halfedges, bool force);

        internal abstract IntPtr Copy(IntPtr ptr);

        internal abstract bool IsValid(IntPtr ptr);

        internal abstract int VertexCount(IntPtr ptr);

        internal abstract int HalfedgeCount(IntPtr ptr);

        internal abstract int EdgeCount(IntPtr ptr);

        internal abstract int FaceCount(IntPtr ptr);

        internal abstract int RemovedVertexCount(IntPtr ptr);

        internal abstract int RemovedHalfedgeCount(IntPtr ptr);

        internal abstract int RemovedEdgeCount(IntPtr ptr);

        internal abstract int RemovedFaceCount(IntPtr ptr);

        internal abstract bool IsVertexRemoved(IntPtr ptr, int index);

        internal abstract bool IsFaceRemoved(IntPtr ptr, int index);

        internal abstract bool IsHalfedgeRemoved(IntPtr ptr, int index);

        internal abstract bool IsEdgeRemoved(IntPtr ptr, int index);

        internal abstract int AddVertex(IntPtr ptr, Point3d point);

        internal abstract int AddEdge(IntPtr ptr, int v0, int v1);

        internal abstract int AddTriangle(IntPtr ptr, int v0, int v1, int v2);

        internal abstract int AddQuad(IntPtr ptr, int v0, int v1, int v2, int v3);

        internal abstract int AddPentagon(IntPtr ptr, int v0, int v1, int v2, int v3, int v4);

        internal abstract int AddHexagon(IntPtr ptr, int v0, int v1, int v2, int v3, int v4, int v5);

        internal abstract int AddFace(IntPtr ptr, int[] indices, int count);

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

        internal abstract int NextAroundSource(IntPtr ptr, int index);

        internal abstract int NextAroundTarget(IntPtr ptr, int index);

        internal abstract int PreviousAroundSource(IntPtr ptr, int index);

        internal abstract int PreviousAroundTarget(IntPtr ptr, int index);

        internal abstract int EdgesHalfedge(IntPtr ptr, int edgeIndex, int halfedgeIndex);

        internal abstract bool RemoveVertex(IntPtr ptr, int index);

        internal abstract bool RemoveEdge(IntPtr ptr, int index);

        internal abstract bool RemoveFace(IntPtr ptr, int index);

        internal abstract bool IsVertexValid(IntPtr ptr, int index);

        internal abstract bool IsEdgeValid(IntPtr ptr, int index);

        internal abstract bool IsHalfedgeValid(IntPtr ptr, int index);

        internal abstract bool IsFaceValid(IntPtr ptr, int index);

        internal abstract Point3d GetPoint(IntPtr ptr, int index);

        internal abstract void GetPoints(IntPtr ptr, Point3d[] points, int count);

        internal abstract void SetPoint(IntPtr ptr, int index, Point3d point);

        internal abstract void SetPoints(IntPtr ptr, Point3d[] points, int count);

        internal abstract bool GetSegment(IntPtr ptr, int index, out Segment3d segment);

        internal abstract void GetSegments(IntPtr ptr, Segment3d[] segments, int count);

        internal abstract bool GetTriangle(IntPtr ptr, int index, out Triangle3d tri);

        internal abstract void GetTriangles(IntPtr ptr, Triangle3d[] triangles, int count);

        internal abstract bool GetVertex(IntPtr ptr, int index, out MeshVertex3 vert);

        internal abstract void GetVertices(IntPtr ptr, MeshVertex3[] vertexArray, int count);

        internal abstract bool GetFace(IntPtr ptr, int index, out MeshFace3 face);

        internal abstract void GetFaces(IntPtr ptr, MeshFace3[] faceArray, int count);

        internal abstract bool GetHalfedge(IntPtr ptr, int index, out MeshHalfedge3 edge);

        internal abstract void GetHalfedges(IntPtr ptr, MeshHalfedge3[] edgeArray, int count);

        internal abstract void Transform(IntPtr ptr, Matrix4x4d matrix);

        internal abstract bool IsVertexBorder(IntPtr ptr, int index, bool check_all_incident_halfedges);

        internal abstract bool IsHalfedgeBorder(IntPtr ptr, int index);

        internal abstract bool IsEdgeBorder(IntPtr ptr, int index);

        internal abstract int BorderEdgeCount(IntPtr ptr);

        internal abstract bool IsClosed(IntPtr ptr);

        internal abstract bool CheckFaceVertexCount(IntPtr ptr, int count);

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

        internal abstract void GetCentroids(IntPtr ptr, Point3d[] points, int count);

        internal abstract void ComputeVertexNormals(IntPtr ptr);

        internal abstract void ComputeFaceNormals(IntPtr ptr);

        internal abstract void GetVertexNormals(IntPtr ptr, Vector3d[] normals, int count);

        internal abstract void GetFaceNormals(IntPtr ptr, Vector3d[] normals, int count);

        internal abstract PolygonalCount GetPolygonalCount(IntPtr ptr);

        internal abstract PolygonalCount GetDualPolygonalCount(IntPtr ptr);

        internal abstract void CreatePolygonMesh(IntPtr ptr, Point2d[] points, int count, bool xz);

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


    }
}
