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
    public class MeshProcessingOrientationPolyhedronTest
    {

        private MeshProcessingOrientation<EEK> Processor => MeshProcessingOrientation<EEK>.Instance;

        private Polyhedron3<EEK> testMesh;

        private Polyhedron3<EEK> TestMesh
        {
            get
            {
                if (testMesh == null)
                {
                    testMesh = PolyhedronFactory<EEK>.CreateCube();
                }

                return testMesh.Copy();
            }
        }

        [TestMethod]
        public void DoesBoundAVolume()
        {
            Assert.IsTrue(Processor.DoesBoundAVolume(TestMesh));
        }

        [TestMethod]
        public void IsOutwardOriented()
        {
            Assert.IsTrue(Processor.IsOutwardOriented(TestMesh));
        }

        [TestMethod]
        public void Orient()
        {
            Processor.Orient(TestMesh);
        }

        [TestMethod]
        public void OrientToBoundAVolume()
        {
            Processor.OrientToBoundAVolume(TestMesh);

        }

        [TestMethod]
        public void ReverseFaceOrientations()
        {
            Processor.ReverseFaceOrientations(TestMesh);
        }

    }
}
