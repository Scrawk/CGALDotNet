using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetTest.Polygons
{
    [TestClass]
    public class Polygon2Test
    {
        [TestMethod]
        public void CreatePolygon()
        {
            var poly = new Polygon2<EEK>();

            Assert.AreEqual(0, poly.Count);
            Assert.IsFalse(poly.IsSimple);
            Assert.IsTrue(poly.IsDegenerate);
        }

        [TestMethod]
        public void ReleasePolygon()
        {
            var poly = new Polygon2<EEK>();
            poly.Dispose();

            Assert.IsTrue(poly.IsDisposed);
        }

        [TestMethod]
        public void CreateSimplePolygon()
        {
            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(0, 5)
            };

            var poly = new Polygon2<EEK>(points);

            Assert.AreEqual(4, poly.Count);
            Assert.IsTrue(poly.IsSimple);
            Assert.IsTrue(poly.IsCounterClockWise);
            Assert.IsTrue(poly.Orientation == ORIENTATION.POSITIVE);
            Assert.IsTrue(poly.FindIfConvex());
        }

        [TestMethod]
        public void CreateConcavePolygon()
        {
            var points = new Point2d[]
            {
                new Point2d(0,0),
                new Point2d(5.1,0),
                new Point2d(1,1),
                new Point2d(0.5,6)
            };

            var poly = new Polygon2<EEK>(points);

            Assert.AreEqual(4, poly.Count);
            Assert.IsTrue(poly.IsSimple);
            Assert.IsTrue(poly.IsCounterClockWise);
            Assert.IsTrue(poly.Orientation == ORIENTATION.POSITIVE);
            Assert.IsFalse(poly.FindIfConvex());
        }

        [TestMethod]
        public void CreateNonSimplePolygon()
        {
            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(8, 4),
                new Point2d(8, 0),
                new Point2d(0, 4),
            };

            var poly = new Polygon2<EEK>(points);

            Assert.AreEqual(4, poly.Count);
            Assert.IsFalse(poly.IsSimple);
            Assert.IsTrue(poly.IsDegenerate);
            Assert.IsTrue(poly.Orientation == ORIENTATION.ZERO);

        }

        [TestMethod]
        public void ArrayAcessor()
        {
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            Assert.AreEqual(new Point2d(-1, -1), poly[0]);

            poly[0] = new Point2d(-2, -2);
            Assert.AreEqual(new Point2d(-2, -2), poly[0]);
        }

        [TestMethod]
        public void Clear()
        {
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            Assert.AreEqual(4, poly.Count);

            poly.Clear();
            Assert.AreEqual(0, poly.Count);
        }

        [TestMethod]
        public void Copy()
        {
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);
            var copy = poly.Copy();

            Assert.AreEqual(4, poly.Count);
            Assert.AreEqual(4, copy.Count);

            for (int i = 0; i < poly.Count; i++)
                Assert.AreEqual(poly[i], copy[i]);
        }

        [TestMethod]
        public void GetPoint()
        {
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            Assert.AreEqual(new Point2d(-1, -1), poly.GetPoint(0));
            Assert.AreEqual(new Point2d(1, -1), poly.GetPoint(1));
            Assert.AreEqual(new Point2d(1, 1), poly.GetPoint(2));
            Assert.AreEqual(new Point2d(-1, 1), poly.GetPoint(3));

            Assert.AreEqual(new Point2d(-1, -1), poly.GetPointClamped(-1));
            Assert.AreEqual(new Point2d(-1, -1), poly.GetPointClamped(0));
            Assert.AreEqual(new Point2d(1, -1), poly.GetPointClamped(1));
            Assert.AreEqual(new Point2d(1, 1), poly.GetPointClamped(2));
            Assert.AreEqual(new Point2d(-1, 1), poly.GetPointClamped(3));
            Assert.AreEqual(new Point2d(-1, 1), poly.GetPointClamped(4));

            Assert.AreEqual(new Point2d(-1, 1), poly.GetPointWrapped(-1));
            Assert.AreEqual(new Point2d(-1, -1), poly.GetPointWrapped(0));
            Assert.AreEqual(new Point2d(1, -1), poly.GetPointWrapped(1));
            Assert.AreEqual(new Point2d(1, 1), poly.GetPointWrapped(2));
            Assert.AreEqual(new Point2d(-1, 1), poly.GetPointWrapped(3));
            Assert.AreEqual(new Point2d(-1, -1), poly.GetPointWrapped(4));
        }
    }
}
