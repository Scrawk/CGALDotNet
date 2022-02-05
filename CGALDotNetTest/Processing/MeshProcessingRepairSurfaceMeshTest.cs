using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polyhedra;
using CGALDotNet.Processing;
using CGALDotNet.Extensions;

namespace CGALDotNetTest.Processing
{

    [TestClass]
    public class MeshProcessingRepairSurfaceMeshTest
    {

        private MeshProcessingRepair<EEK> Processor => MeshProcessingRepair<EEK>.Instance;

        private SurfaceMesh3<EEK> TriangleSoup
        {
            get
            {
                var points = new Point3d[]
                {
                new Point3d(0,0,0),
                new Point3d(1,0,0),
                new Point3d(1,1,0),

                new Point3d(0,0,0),
                new Point3d(0,1,0),
                new Point3d(1,1,0),
                };

                var indices = new int[]
                {
                    0, 1, 2,
                    3, 5, 4
                };

                return new SurfaceMesh3<EEK>(points, indices);
            }
        }

        [TestMethod]
        public void DegenerateEdgeCount()
        {
            var points = new Point3d[]
            {
                new Point3d(0,0,0),
                new Point3d(0,0,0),
                new Point3d(1,1,0)
            };

            var indices = new int[]
            {
                0, 1, 2,
            };

            var mesh = new SurfaceMesh3<EEK>(points, indices);
            int count = Processor.DegenerateEdgeCount(mesh);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void DegenerateTriangleCount()
        {
            var points = new Point3d[]
            {
                new Point3d(0,0,0),
                new Point3d(0,0,0),
                new Point3d(1,1,0)
            };

            var indices = new int[]
            {
                0, 1, 2,
            };

            var mesh = new SurfaceMesh3<EEK>(points, indices);
            int count = Processor.DegenerateTriangleCount(mesh);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void NeedleTriangleCount()
        {
            var points = new Point3d[]
            {
                new Point3d(0,0,0),
                new Point3d(0.01,0,0),
                new Point3d(1,1,0)
            };

            var indices = new int[]
            {
                0, 1, 2,
            };

            var mesh = new SurfaceMesh3<EEK>(points, indices);
            int count = Processor.NeedleTriangleCount(mesh, 0.1);
            Assert.AreEqual(1, count);
        }

        /*
        [TestMethod]
        public void NonManifoldVertexCount()
        {
            var mesh = new SurfaceMesh3<EEK>(points, indices);
            int count = Processor.NonManifoldVertexCount(mesh);
        }
        */

        [TestMethod]
        public void RepairPolygonSoup()
        {
            var mesh = TriangleSoup;
            Processor.RepairPolygonSoup(mesh);

            Assert.AreEqual(4, mesh.VertexCount);
            Assert.AreEqual(10, mesh.HalfedgeCount);
            Assert.AreEqual(2, mesh.FaceCount);
        }

        [TestMethod]
        public void StitchBoundaryCycles()
        {
            var mesh = TriangleSoup;
            Processor.StitchBoundaryCycles(mesh);
            //mesh.Print();
        }

        [TestMethod]
        public void StitchBorders()
        {
            var mesh = TriangleSoup;
            Processor.StitchBorders(mesh);
            Assert.AreEqual(4, mesh.VertexCount);
            Assert.AreEqual(10, mesh.HalfedgeCount);
            Assert.AreEqual(2, mesh.FaceCount);
        }

        /*
        [TestMethod]
        public void MergeDuplicatedVerticesInBoundaryCycle()
        {
            var points = new Point3d[]
            {
                new Point3d(0,0,0),
                new Point3d(0,0,0),
                new Point3d(1,0,0),
                new Point3d(1,1,0)
            };

            var indices = new int[]
            {
                    0, 1, 2, 3
            };

            var mesh = new SurfaceMesh3<EEK>();
            mesh.CreateTriangleQuadMesh(points, points.Length, null, 0, indices, indices.Length);

            mesh.Print();
            Processor.MergeDuplicatedVerticesInBoundaryCycle(mesh, 0);
            mesh.Print();
        }

        [TestMethod]
        public void MergeDuplicatedVerticesInBoundaryCycles()
        {
            var points = new Point3d[]
            {
                new Point3d(0,0,0),
                new Point3d(0,0,0),
                new Point3d(1,0,0),
                new Point3d(1,1,0)
            };

            var indices = new int[]
            {
                    0, 1, 2, 3
            };

            var mesh = new SurfaceMesh3<EEK>();
            mesh.CreateTriangleQuadMesh(points, points.Length, null, 0, indices, indices.Length);

            mesh.Print();
            Processor.MergeDuplicatedVerticesInBoundaryCycles(mesh);
            mesh.Print();
        }
        */

        [TestMethod]
        public void RemoveIsolatedVertices()
        {
            var points = new Point3d[]
            {
                new Point3d(0,0,0),
                new Point3d(1,0,0),
                new Point3d(1,1,0),

                new Point3d(0,0,0),
                new Point3d(10,0,0)
            };

            var indices = new int[]
            {
                    0, 1, 2
            };

            var mesh = new SurfaceMesh3<EEK>(points, indices);

            Assert.AreEqual(5, mesh.VertexCount);
            Processor.RemoveIsolatedVertices(mesh);
            Assert.AreEqual(3, mesh.VertexCount);
        }

    }
}
