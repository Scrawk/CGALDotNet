using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polyhedra;
using CGALDotNet.Processing;
using CGALDotNet.Extensions;

namespace CGALDotNetTest.Processing
{

    [TestClass]
    public class MeshProcessingMeshingPolyhedronTest
    {

        private MeshProcessingMeshing<EEK> Processor => MeshProcessingMeshing<EEK>.Instance;

        private Polyhedron3<EEK> testMesh;

        private Polyhedron3<EEK> TestMesh
        {
            get
            {
                if (testMesh == null)
                {
                    testMesh = PolyhedronFactory<EEK>.CreateCube(1, true);
                }

                return testMesh.Copy();
            }
        }

        [TestMethod]
        public void Extrude()
        {
            var extured = Processor.Extrude(TestMesh, new Vector3d(0, 1, 0));
        }

        [TestMethod]
        public void Fair()
        {
            var success = Processor.Fair(TestMesh, 0, 1);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Refine()
        {
            var mesh = TestMesh;
            mesh.Triangulate();

            double factor = 5;
            int new_verts = Processor.Refine(mesh, factor);
        }

        [TestMethod]
        public void IsotropicRemeshing()
        {
            var mesh = TestMesh;
            mesh.Triangulate();

            int new_verts = Processor.IsotropicRemeshing(mesh, 0.1, 2);
        }

        [TestMethod]
        public void RandomPerturbation()
        {
            var mesh = TestMesh;
            mesh.Triangulate();

            Processor.RandomPerturbation(mesh, 0.1);
        }

        /*
        [TestMethod]
        public void SmoothByAngle()
        {
            var mesh = TestMesh;
            mesh.Triangulate();

            var featureAngle = new Degree(120);
            Processor.SmoothMeshByAngle(mesh, featureAngle, 1);
        }
        */

        /*
        [TestMethod]
        public void SmoothShape()
        {
            var mesh = TestMesh;
            mesh.Triangulate();

            double time_step = 0.001;
            Processor.SmoothShape(mesh, time_step, 1);

            Console.WriteLine("Vertices = " + mesh.VertexCount);
            mesh.PrintVertices();
        }
        */

        [TestMethod]
        public void SplitLongEdges()
        {
            var mesh = TestMesh;
            int new_edges = Processor.SplitLongEdges(mesh, 0.1);
        }

        [TestMethod]
        public void TriangulateFace()
        {
            var mesh = TestMesh;
            bool success = Processor.TriangulateFace(mesh, 0);

            Assert.IsTrue(success);
            Assert.AreEqual(7, mesh.FaceCount);
        }

        [TestMethod]
        public void TriangulateFaces()
        {
            var mesh = TestMesh;
            bool success = Processor.TriangulateFaces(mesh, new int[] { 0, 1 }, 2);

            Assert.IsTrue(success);
            Assert.AreEqual(8, mesh.FaceCount);
        }

    }
}
