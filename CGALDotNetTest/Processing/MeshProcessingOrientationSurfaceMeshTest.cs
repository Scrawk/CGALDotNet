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
    public class MeshProcessingOrientationSurfaceMeshTest
    {

        private MeshProcessingOrientation<EEK> Processor => MeshProcessingOrientation<EEK>.Instance;

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
