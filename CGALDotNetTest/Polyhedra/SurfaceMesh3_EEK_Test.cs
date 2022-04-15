using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polyhedra;

namespace CGALDotNetTest.Polyhedra
{
    [TestClass]
    public class SurfaceMesh3_EEK_Test
    {
        /*
        public int VertexCount();

        public int HalfedgeCount();

        public int EdgeCount();

        public int FaceCount();

        public int BorderEdgeCount();

        public int BuildStamp();

        public int RemovedVertexCount();

        public int RemovedHalfedgeCount();

        public int RemovedEdgeCount();

        public int RemovedFaceCount();

        public bool IsValid()
        {

        }

        public bool IsClosed()
        {

        }

        public bool IsTriangle()
        {

        }

        public bool IsQuad()
        {

        }

        public void Clear()
        {

        }

        public int AddVertex(Point3d point)
        {

        }


        public int AddEdge(int v0, int v1)
        {

        }
        public int AddTriangle(int v0, int v1, int v2)
        {

        }
        public int AddQuad(int v0, int v1, int v2, int v3)
        {

        }

        public int AddPentagon(int v0, int v1, int v2, int v3, int v4)
        {

        }

        public int AddHexagon(int v0, int v1, int v2, int v3, int v4, int v5)
        {

        }

        public int AddPolygon(int[] indices, int count)
        {

        }

        public bool HasGarbage => Kernel.HasGarbage(Ptr);

        public void CollectGarbage()
        {

        }

        public Point3d GetPoint(int index)
        {

        }

        public void GetPoints(Point3d[] points, int count)
        {

        }

        public void SetPoint(int index, Point3d point)
        {

        }


        public void SetPoints(Point3d[] points, int count)
        {

        }

        public bool GetSegment(int index, out Segment3d segment)
        {

        }

        public void GetSegments(Segment3d[] segments, int count)
        {

        }

        public bool GetTriangle(int index, out Triangle3d triangle)
        {
   
        }

        public void GetTriangles(Triangle3d[] triangles, int count)
        {

        }

        public bool GetVertex(int index, out MeshVertex3 vertex)
        {

        }

        public void GetVertices(MeshVertex3[] vertices, int count)
        {

        }

        public bool GetFace(int index, out MeshFace3 face)
        {

        }

        public void GetFaces(MeshFace3[] faces, int count)
        {

        }

        public bool GetHalfedge(int index, out MeshHalfedge3 halfedge)
        {

        }

        public void GetHalfedges(MeshHalfedge3[] halfedges, int count)
        {

        }

        public int VertexDegree(int vertex)
        {

        }

        public int FaceDegree(int face)
        {

        }

        public bool VertexIsIsolated(int vertex)
        {

        }

        public bool VertexIsBorder(int vertex, bool check_all_incident_halfedges = true)

        }

        public bool EdgeIsBorder(int edge)

        }

        public int NextHalfedge(int halfedge)
        {

        }

        public int PreviousHalfedge(int halfedge)
        {

        }

        public int OppositeHalfedge(int halfedge)
        {

        }

        public int SourceVertex(int halfedge)
        {

        }

        public int TargetVertex(int halfedge)
        {

        }

        public bool RemoveVertex(int vertex)
        {

        }

        public bool RemoveEdge(int edge)
        {

        }

        public bool RemoveFace(int face)
        {

        }

        public bool IsVertexRemoved(int index)
        {

        }

        public bool IsFaceRemoved(int index)
        {

        }

        public bool IsHalfedgeRemoved(int index)
        {

        }

        public bool IsEdgeRemoved(int index)
        {

        }

        public bool IsVertexValid(int vertex)
        {
    
        }

        public bool IsEdgeValid(int edge)
        {
   
        }

        public bool IsHalfedgeValid(int halfedge)
        {

        }

        public bool IsFaceValid(int face)
        {

        }

        public void Transform(Point3d translation, Quaternion3d rotation, Point3d scale)
        {

        }

        public void CreateMesh(Point3d[] points, int[] triangles, int[] quads = null)
        {

        }

        public void CreateTriangleMesh(Point3d[] points, int pointCount, int[] indices, int indexCount)
        {

        }

        public void CreateQuadMesh(Point3d[] points, int pointCount, int[] indices, int indexCount)
        {

        }

        public void CreateTriangleQuadMesh(Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadsCount)
        {

        }

        public void CreatePolygonalMesh(Point3d[] points, int pointsCount, PolygonalIndices indices)
        {

        }

        public void CreatePolygonMesh(Point2d[] points, int count, bool xz)
        {

        }

        public void GetIndices(int[] triangles, int[] quads = null)
        {

        }

        public void GetTriangleIndices(int[] triangles, int trianglesCount)
        {

        }

        public void GetQuadIndices(int[] quads, int quadsCount)
        {

        }

        public void GetTriangleQuadIndices(int[] triangles, int trianglesCount, int[] quads, int quadsCount)
        {

        }

        public PolygonalIndices GetPolygonalIndices()
        {

        }

        public bool IsVertexBorder(int index, bool check_all_incident_halfedges)
        {
          
        }

        public bool IsHalfedgeBorder(int index)
        {
           
        }

        public bool IsEdgeBorder(int index)
        {
          
        }

        public PolygonalCount GetPolygonalCount()
        {
          
        }

        public Box3d FindBoundingBox()
        {

        }

        public void Triangulate()
        {

        }

        public BOOL_OR_UNDETERMINED DoesSelfIntersect()
        {

        }

        public BOUNDED_SIDE BoundedSide(Point3d point)
        {

        }

        public bool ContainsPoint(Point3d point, bool includeBoundary = true)
        {

        }

        public abstract MeshHitResult LocateFace(Ray3d ray);

        public abstract MeshHitResult ClosestFace(Point3d point);

        public bool LocateFace(Ray3d ray, out MeshFace3 face)
        {

        }

        public bool LocateVertex(Ray3d ray, double radius, out MeshVertex3 vertex)
        {

        }

        public bool LocateHalfedge(Ray3d ray, double radius, out MeshHalfedge3 edge)
        {
 
        }

        public BOOL_OR_UNDETERMINED DoIntersect(SurfaceMesh3 mesh, bool test_bounded_sides = true)
        {

        }


        public void ComputeVertexNormals()
        {

        }


        public void ComputeFaceNormals()
        {

        }

        public void GetVertexNormals(Vector3d[] normals, int count)
        {

        }

        public void GetFaceNormals(Vector3d[] normals, int count)
        {

        }

        public Point3d[] ToArray()
        {

        }

        public List<Point3d> ToList()
        {

        }


        protected override void ReleasePtr()
        {

        }
        */
    }
}
