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
    public class Box2Test
    {
        [TestMethod]
        public void CreateBox()
        {
            var min = new Point2d(-1, -2);
            var max = new Point2d(1, 2);
            var box = new Box2<EIK>(min, max);

            Assert.AreEqual(new Point2d(-1, -2), box.Min);
            Assert.AreEqual(new Point2d(1, 2), box.Max);
        }

        [TestMethod]
        public void Release()
        {
            var box = new Box2<EIK>(-1, -1);
            box.Dispose();

            Assert.IsTrue(box.IsDisposed);
        }

        [TestMethod]
        public void GetMin()
        {

        }

        [TestMethod]
        public void SetMin()
        {

        }

        [TestMethod]
        public void GetMax()
        {

        }

        [TestMethod]
        public void SetMax()
        {

        }

        [TestMethod]
        public void Area()
        {

        }

        [TestMethod]
        public void BoundedSide()
        {

        }

        [TestMethod]
        public void ContainsPoint()
        {

        }

        [TestMethod]
        public void IsDegenerate()
        {

        }

        [TestMethod]
        public void Transform()
        {

        }

        [TestMethod]
        public void Copy()
        {

        }

        [TestMethod]
        public void Convert()
        {

        }

        [TestMethod]
        public void Shape()
        {

        }

        [TestMethod]
        public void Round()
        {

        }
    }

}
