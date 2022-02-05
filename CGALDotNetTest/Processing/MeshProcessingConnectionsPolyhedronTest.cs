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
    public class MeshProcessingConnectionsPolyhedronTest
    {

        private MeshProcessingConnections<EEK> Processor => MeshProcessingConnections<EEK>.Instance;

        private Polyhedron3<EEK> testMesh;

        private Polyhedron3<EEK> TestMesh
        {
            get
            {
                if (testMesh == null)
                {
                    var cube1 = SurfaceMeshFactory<EEK>.CreateCube();
                    cube1.Translate(new Point3d(-1, 0, 0));

                    var cube2 = SurfaceMeshFactory<EEK>.CreateCube(1, true);
                    cube2.Translate(new Point3d(1, 0, 0));

                    cube1.Join(cube2);

                    testMesh = cube1.ToPolyhedronMesh();
                }

                return testMesh.Copy();
            }
        }

        /*
        [TestMethod]
        public void UnconnectedComponents()
        {
            Assert.AreEqual(2, Processor.UnconnectedComponents(TestMesh));
        }
        */

        [TestMethod]
        public void ConnectedFaces()
        {
            var faces = new List<int>();
            Processor.ConnectedFaces(TestMesh, 0, faces);
            Assert.AreEqual(12, faces.Count);
            Assert.IsFalse(faces.HasNullIndex());
        }

        [TestMethod]
        public void SplitUnconnectedComponents()
        {
            var faces = new List<Polyhedron3<EEK>>();
            Processor.SplitUnconnectedComponents(TestMesh, faces);
            Assert.AreEqual(2, faces.Count);
        }

        [TestMethod]
        public void KeepLargeComponents()
        {
            int removed = Processor.KeepLargeComponents(TestMesh, 12);
            Assert.AreEqual(1, removed);
        }

        [TestMethod]
        public void KeepLargestComponents()
        {
            int removed = Processor.KeepLargestComponents(TestMesh, 1);
            Assert.AreEqual(1, removed);
        }


    }
}
