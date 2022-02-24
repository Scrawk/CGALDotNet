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
        public void GetMinMax()
        {
            var min = new Point2d(-1, -3);
            var max = new Point2d(1, 3);

            var box = new Box2<EIK>(min, max);

            Assert.AreEqual(min, box.Min);
            Assert.AreEqual(max, box.Max);
        }

        [TestMethod]
        public void SetMinMax()
        {
            var min = new Point2d(-1, -3);
            var max = new Point2d(1, 3);

            var box = new Box2<EIK>(min, max);

            box.Min = new Point2d(0, 1);
            box.Max = new Point2d(2, 4);

            Assert.AreEqual(new Point2d(0, 1), box.Min);
            Assert.AreEqual(new Point2d(2, 4), box.Max);
        }

        [TestMethod]
        public void Area()
        {
            var box = new Box2<EIK>(-1, 1);

            Assert.AreEqual(4, box.Area);
        }

        [TestMethod]
        public void BoundedSide()
        {
            var p1 = new Point2d(-2, -2);
            var p2 = new Point2d(-1, 0);
            var p3 = new Point2d(0, 0);

            var box = new Box2<EIK>(-1, 1);

            Assert.AreEqual(BOUNDED_SIDE.ON_UNBOUNDED_SIDE, box.BoundedSide(p1));
            Assert.AreEqual(BOUNDED_SIDE.ON_BOUNDARY, box.BoundedSide(p2));
            Assert.AreEqual(BOUNDED_SIDE.ON_BOUNDED_SIDE, box.BoundedSide(p3));
        }

        [TestMethod]
        public void ContainsPoint()
        {
            var p1 = new Point2d(-2, -2);
            var p2 = new Point2d(-1, 0);
            var p3 = new Point2d(0, 0);

            var box = new Box2<EIK>(-1, 1);

            Assert.IsFalse(box.ContainsPoint(p1));
            Assert.IsTrue(box.ContainsPoint(p2));
            Assert.IsTrue(box.ContainsPoint(p2, true));
            Assert.IsTrue(box.ContainsPoint(p3));
        }

        [TestMethod]
        public void IsDegenerate()
        {
            var box = new Box2<EIK>(0,0);
            Assert.IsTrue(box.IsDegenerate);
        }

        [TestMethod]
        public void Transform()
        {

            var box = new Box2<EIK>(-1, 1);
            box.Translate(new Point2d(1, 1));

            Assert.AreEqual(new Point2d(0, 0), box.Min);
            Assert.AreEqual(new Point2d(2, 2), box.Max);

            box = new Box2<EIK>(-1, 1);
            box.Scale(2);

            Assert.AreEqual(new Point2d(-2, -2), box.Min);
            Assert.AreEqual(new Point2d(2, 2), box.Max);

            box = new Box2<EIK>(-1, 1);
            box.Rotate(new Degree(90));
            box.Round(2);

            Assert.AreEqual(new Point2d(-1, -1), box.Min);
            Assert.AreEqual(new Point2d(1, 1), box.Max);

        }

        [TestMethod]
        public void Copy()
        {
            var box = new Box2<EIK>(-1, 1);
            var box2 = box.Copy();

            Assert.AreNotEqual(box.Ptr, box2.Ptr);
            Assert.AreEqual(new Point2d(-1, -1), box2.Min);
            Assert.AreEqual(new Point2d(1, 1), box2.Max);
        }

        [TestMethod]
        public void Convert()
        {
            var box1 = new Box2<EIK>(-1, 1);
            var box2 = box1.Convert<EEK>();

            Assert.AreNotEqual(box1.Ptr, box2.Ptr);
            Assert.AreEqual(new Point2d(-1, -1), box2.Min);
            Assert.AreEqual(new Point2d(1, 1), box2.Max);
            Assert.AreEqual("EEK", box2.KernelName);
        }

        [TestMethod]
        public void Shape()
        {
            var box = new Box2<EIK>(-1, 1);
            var shape = box.Shape;

            Assert.AreEqual(new Point2d(-1, -1), shape.Min);
            Assert.AreEqual(new Point2d(1, 1), shape.Max);
        }

        [TestMethod]
        public void Round()
        {
            var p1 = new Point2d(0.1);
            var p2 = new Point2d(0.01);
            var p3 = new Point2d(0.001);
            var p4 = new Point2d(0.0001);
            var p5 = new Point2d(0.00001);
            var p6 = new Point2d(0.000001);
            var p7 = new Point2d(0.0000001);
            var p8 = new Point2d(0.00000001);

            var box1 = new Box2<EIK>(p1, p1);
            var box2 = new Box2<EIK>(p2, p2);
            var box3 = new Box2<EIK>(p3, p3);
            var box4 = new Box2<EIK>(p4, p4);
            var box5 = new Box2<EIK>(p5, p5);
            var box6 = new Box2<EIK>(p6, p6);
            var box7 = new Box2<EIK>(p7, p7);
            var box8 = new Box2<EIK>(p8, p8);

            box1.Round(1);
            box2.Round(2);
            box3.Round(3);
            box4.Round(4);
            box5.Round(5);
            box6.Round(6);
            box7.Round(7);
            box8.Round(8);

            AssertX.AlmostEqual(0.1, box1.Min.x);
            AssertX.AlmostEqual(0.01, box2.Min.x);
            AssertX.AlmostEqual(0.001, box3.Min.x);
            AssertX.AlmostEqual(0.0001, box4.Min.x);
            AssertX.AlmostEqual(0.00001, box5.Min.x);
            AssertX.AlmostEqual(0.000001, box6.Min.x);
            AssertX.AlmostEqual(0.0000001, box7.Min.x);
            AssertX.AlmostEqual(0.00000001, box8.Min.x);

        }
    }

}
