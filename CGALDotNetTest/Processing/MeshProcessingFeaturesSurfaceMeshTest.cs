using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNetGeometry.Extensions;
using CGALDotNet.Polyhedra;
using CGALDotNet.Processing;


namespace CGALDotNetTest.Processing
{

    [TestClass]
    public class MeshProcessingFeaturesSurfaceMeshTest
    {

        private MeshProcessingFeatures<EEK> Processor => MeshProcessingFeatures<EEK>.Instance;

        private SurfaceMesh3<EEK> testMesh;

        private SurfaceMesh3<EEK> TestMesh
        {
            get
            {
                if (testMesh == null)
                {
                    testMesh = SurfaceMeshFactory<EEK>.CreateCube(1, true);
                }

                return testMesh.Copy();
            }
        }

        [TestMethod]
        public void DetectSharpEdges()
        {
            var featureEdges = new List<int>();
            var angle = new Degree(90);
            Processor.DetectSharpEdges(TestMesh, angle, featureEdges);

            Assert.AreEqual(12, featureEdges.Count);
            Assert.IsFalse(featureEdges.HasNullIndex());
        }

        [TestMethod]
        public void SharpEdgesSegmentation()
        {
            var featureEdges = new List<int>();
            var featurePatches = new List<List<int>>();
            var angle = new Degree(90);
            Processor.SharpEdgesSegmentation(TestMesh, angle, featureEdges, featurePatches);

            Assert.AreEqual(12, featureEdges.Count);
            Assert.AreEqual(5, featurePatches.Count);
            Assert.IsFalse(featureEdges.HasNullIndex());

            foreach(var patch in featurePatches)    
                Assert.IsFalse(patch.HasNullIndex());

        }

        [TestMethod]
        public void EdgeLengthMinMaxAvg()
        {
            var mesh = TestMesh;
            mesh.Scale(new Point3d(2, 0.5, 1));

            var minmax = Processor.EdgeLengthMinMaxAvg(mesh);

            Assert.AreEqual(0.5, minmax.Min);
            Assert.AreEqual(2, minmax.Max);
            Assert.AreEqual(1.17, Math.Round(minmax.Average, 2));
        }

        [TestMethod]
        public void FaceAreaMinMaxAvg()
        {
            var mesh = TestMesh;
            mesh.Scale(new Point3d(2, 0.5, 1));

            var minmax = Processor.FaceAreaMinMaxAvg(mesh);

            Console.WriteLine(minmax);

            Assert.AreEqual(0.25, minmax.Min);
            Assert.AreEqual(1, minmax.Max);
            Assert.AreEqual(0.58, Math.Round(minmax.Average, 2));
        }

    }
}
