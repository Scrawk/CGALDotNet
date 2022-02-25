using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Geometry;

namespace CGALDotNetTest.Geometry
{

    [TestClass]
    public class Point2_EIK_Test
    {

        [TestMethod]
        public void CreatePoint_EIK()
        {
            var p = new Point2<EIK>(1, 2);

            Assert.AreEqual(1, p.x);
            Assert.AreEqual(2, p.y);
        }

        [TestMethod]
        public void SetXY_EIK()
        {
            var p = new Point2<EIK>(1, 2);

            p.x = 3;
            p.y = 4;

            AssertX.AlmostEqual(3, p.x);
            AssertX.AlmostEqual(4, p.y);
        }

        [TestMethod]
        public void Release_EIK()
        {
            var p = new Point2<EIK>(0, 0);
            p.Dispose();

            Assert.IsTrue(p.IsDisposed);
        }

        [TestMethod]
        public void Clamp_EIK()
        {
            var p = new Point2<EIK>(-1, 4);

            p.Clamp(0, 3);

            Assert.AreEqual(0, p.x);
            Assert.AreEqual(3, p.y);
        }

        [TestMethod]
        public void Clamp01_EIK()
        {
            var p = new Point2<EIK>(-0.1, 3.2);

            p.Clamp01();

            Assert.AreEqual(0, p.x);
            Assert.AreEqual(1, p.y);
        }

        [TestMethod]
        public void Round_EIK()
        {
            var p1 = new Point2<EIK>(0.1);
            var p2 = new Point2<EIK>(0.01);
            var p3 = new Point2<EIK>(0.001);
            var p4 = new Point2<EIK>(0.0001);
            var p5 = new Point2<EIK>(0.00001);
            var p6 = new Point2<EIK>(0.000001);
            var p7 = new Point2<EIK>(0.0000001);
            var p8 = new Point2<EIK>(0.00000001);

            p1.Round(1);
            p2.Round(2);
            p3.Round(3);
            p4.Round(4);
            p5.Round(5);
            p6.Round(6);
            p7.Round(7);
            p8.Round(8);

            AssertX.AlmostEqual(0.1, p1.x);
            AssertX.AlmostEqual(0.01, p2.x);
            AssertX.AlmostEqual(0.001, p3.x);
            AssertX.AlmostEqual(0.0001, p4.x);
            AssertX.AlmostEqual(0.00001, p5.x);
            AssertX.AlmostEqual(0.000001, p6.x);
            AssertX.AlmostEqual(0.0000001, p7.x);
            AssertX.AlmostEqual(0.00000001, p8.x);
        }

        [TestMethod]
        public void Copy_EIK()
        {
            var p = new Point2<EIK>(3, 4);
            var p2 = p.Copy();

            Assert.AreNotEqual(p.Ptr, p2.Ptr);
            Assert.AreEqual(3, p2.x);
            Assert.AreEqual(4, p2.y);
        }

        [TestMethod]
        public void Convert_EIK()
        {
            var p1 = new Point2<EIK>(1,2);
            var p2 = p1.Convert<EEK>();

            Assert.AreNotEqual(p1.Ptr, p2.Ptr);
            Assert.AreEqual(1, p2.x);
            Assert.AreEqual(2, p2.y);
            Assert.AreEqual("EEK", p2.KernelName);
        }

    }

}
