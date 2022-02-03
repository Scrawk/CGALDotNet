﻿using System;
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
    public class MeshProcessingFeaturesPolyhedronTest
    {

        private MeshProcessingFeatures<EEK> Processor => MeshProcessingFeatures<EEK>.Instance;

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
        public void DetectSharpEdges()
        {
            var featureEdges = new List<int>();
            var angle = new Degree(90);
            Processor.DetectSharpEdges(TestMesh, angle, featureEdges);

            Assert.AreEqual(12, featureEdges.Count);
            Assert.IsFalse(featureEdges.HasNullIndex());
        }

        /*
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

            foreach (var patch in featurePatches)
                Assert.IsFalse(patch.HasNullIndex());

        }
        */
    }
}
