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
    public class MeshProcessingLocateSurfaceMeshTest
    {

        private MeshProcessingLocate<EEK> Processor => MeshProcessingLocate<EEK>.Instance;

        private SurfaceMesh3<EEK> testMesh;

        private SurfaceMesh3<EEK> TestMesh
        {
            get
            {
                if (testMesh == null)
                {
                    testMesh = SurfaceMeshFactory<EEK>.CreateCube();
                }

                return testMesh.Copy();
            }
        }

        [TestMethod]
        public void RandomLocationOnMesh()
        {
            var point = Processor.RandomLocationOnMesh(TestMesh);
        }

        [TestMethod]
        public void LocateFace()
        {
            var ray = new Ray3d(new Point3d(2, 0, 0), new Vector3d(-1, 0, 0));

            var result = Processor.LocateFace(TestMesh, ray);
            Assert.AreEqual(4, result.Face);
            Assert.AreEqual(new Point3d(0.5, 0, 0), result.Point);
            Assert.AreEqual(new Point3d(0.5, 0, 0.5), result.Coord);
        }

        [TestMethod]
        public void ClosestFace()
        {
            var point = new Point3d(2, 0, 0);

            var result = Processor.ClosestFace(TestMesh, point);
            Assert.AreEqual(4, result.Face);
            Assert.AreEqual(new Point3d(0.5, 0, 0), result.Point);
            Assert.AreEqual(new Point3d(0.5, 0, 0.5), result.Coord);
        }

    }
}
