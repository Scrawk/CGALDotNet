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
    public class Polyhedron3_EEK_Test
    {

        Point3d[] cube_points = new Point3d[]
        {
            new Point3d(-0.5, -0.5, -0.5),
            new Point3d(0.5, -0.5, -0.5),
            new Point3d(0.5, 0.5, -0.5),
            new Point3d(-0.5, 0.5, -0.5),
            new Point3d(-0.5, 0.5, 0.5),
            new Point3d(0.5, 0.5, 0.5),
            new Point3d(0.5, -0.5, 0.5),
            new Point3d(-0.5, -0.5, 0.5)
        };

        [TestMethod]
        public void CreatePolyhedron()
        {
            var poly = new Polyhedron3<EEK>();

            Assert.AreEqual(0, poly.VertexCount);
            Assert.IsTrue(poly.IsValid);
        }

        [TestMethod]
        public void ReleasePolyhedron()
        {
            var poly = new Polyhedron3<EEK>();
            poly.Dispose();

            Assert.IsTrue(poly.IsDisposed);
        }

        [TestMethod]
        public void VertexCount()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);
            Assert.AreEqual(8, poly.VertexCount);
        }

        [TestMethod]
        public void FaceCount()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);
            Assert.AreEqual(6, poly.FaceCount);
        }

        [TestMethod]
        public void HalfedgeCount()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);
            Assert.AreEqual(24, poly.HalfedgeCount);
        }

        public void BorderEdgeCount()
        {

        }


        public void BorderHalfEdgeCount()
        {

        }

        [TestMethod]
        public void IsValid()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);
            Assert.IsTrue(poly.IsValid);
        }

        [TestMethod]
        public void IsClosed()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);
            Assert.IsTrue(poly.IsClosed);
        }

        [TestMethod]
        public void IsTriangle()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, false);
            Assert.IsTrue(poly.IsTriangle);
        }

        [TestMethod]
        public void IsQuad()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);
            Assert.IsTrue(poly.IsQuad);
        }

        [TestMethod]
        public void Clear()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);
            poly.Clear();
            Assert.AreEqual(0, poly.VertexCount);
        }

        public void CreateMesh()
        {
   
        }

        public void CreateTriangleMesh()
        {

        }

        public void CreateQuadMesh()
        {

        }

        public void CreateTriangleQuadMesh()
        {

        }

        public void CreatePolygonalMesh()
        {

        }

        public void CreatePolygonMesh()
        {

        }

        public void GetIndices()
        {

        }

        public void GetTriangleIndices()
        {

        }


        public void GetQuadIndices()
        {

        }

        public void GetTriangleQuadIndices()
        {
    
        }

        public void GetPolygonalIndices()
        {

        }

        public void GetDualPolygonalIndices()
        {
        }

        [TestMethod]
        public void GetPoint()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);

            for(int i = 0; i < poly.VertexCount; i++)
            {
                Assert.AreEqual(cube_points[i], poly.GetPoint(i));
            }

        }

        [TestMethod]
        public void GetPoints()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);

            var points = new Point3d[poly.VertexCount];
            poly.GetPoints(points, points.Length);

            for (int i = 0; i < poly.VertexCount; i++)
            {
                Assert.AreEqual(cube_points[i], points[i]);
            }

        }

        [TestMethod]
        public void SetPoint()
        {
            var poly = PolyhedronFactory<EEK>.CreateCube(1, true);

            var p0 = new Point3d(1, 2, 3);
            var p3 = new Point3d(-1, -2, -3);
   
            poly.SetPoint(0, p0);
            poly.SetPoint(3, p3);

            Assert.AreEqual(p0, poly.GetPoint(0));
            Assert.AreEqual(p3, poly.GetPoint(3));
        }

        [TestMethod]
        public void SetPoints()
        {
            var poly = new Polyhedron3<EEK>();
            poly.SetPoints(cube_points, cube_points.Length);

            for (int i = 0; i < poly.VertexCount; i++)
            {
                Assert.AreEqual(cube_points[i], poly.GetPoint(i));
            }
        }

        public void GetSegment()
        {
    
        }

        public void GetSegments()
        {

        }

        public void GetTriangle()
        {
         
        }

        public void GetTriangles()
        {

        }

        public void GetVertex()
        {
           
        }

        public void GetVertices()
        {

        }

        public void GetFace()
        {
            
        }

        public void GetFaces()
        {

        }

   
        public void GetHalfedge()
        {
   
        }

        public void GetHalfedges()
        {

        }

        public void GetPolygonalCount()
        {
          
        }

        public void GetDualPolygonalCount()
        {
           
        }

        public void GetCentroids()
        {

        }

        public void GetVertexNormals()
        {

        }

        public void GetFaceNormals()
        {

        }

        public void Transform()
        {

        }

        public void Triangulate()
        {

        }


        public void BoundedSide()
        {

        }

        public void ContainsPoint()
        {
   
        }

        public void LocateFace()
        {

        }

        public void LocateVertex()
        {

        }

        public void LocateHalfedge()
        {
 
        }

        public void DoesSelfIntersect()
        {
     
        }

        public void FindIfValid()
        {
            
        }

        public void FindBoundingBox()
        {
            
        }

 
        public void FindArea()
        {

        }

 
        public void FindCentroid()
        {

        }

        public void FindVolume()
        {

        }

        public void FindIfClosed()
        {

        }

        public void FindIfTriangleMesh()
        {

        }

        public void FindIfQuadMesh()
        {
      
        }

        public void ToArray()
        {

        }

        public void ToList()
        {

        }

    }
}
