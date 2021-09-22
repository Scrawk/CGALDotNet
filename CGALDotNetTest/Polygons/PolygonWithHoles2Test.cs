using System;
using System.Text;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetTest.Polygons
{
    [TestClass]
    public class PolygonWithHoles2Test
    {


        [TestMethod]
        public void CreatePolygon()
        {
            var poly = new PolygonWithHoles2<EEK>();

            Assert.AreEqual(0, poly.Count);
            Assert.IsFalse(poly.IsSimple);
            Assert.IsTrue(poly.IsDegenerate);
        }

        [TestMethod]
        public void ReleasePolygon()
        {
            var poly = new PolygonWithHoles2<EEK>();
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

            var poly = new PolygonWithHoles2<EEK>(points);

            Assert.AreEqual(4, poly.Count);
            Assert.IsFalse(poly.IsUnbounded);
            Assert.IsTrue(poly.IsSimple);
            Assert.IsTrue(poly.IsCounterClockWise);
            Assert.IsFalse(poly.IsDegenerate);
            Assert.IsTrue(poly.Orientation == ORIENTATION.POSITIVE);
            Assert.IsTrue(poly.ClockDir == CLOCK_DIR.COUNTER_CLOCKWISE);
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

            var poly = new PolygonWithHoles2<EEK>(points);

            Assert.IsFalse(poly.IsUnbounded);
            Assert.AreEqual(4, poly.Count);
            Assert.IsTrue(poly.IsSimple);
            Assert.IsTrue(poly.IsCounterClockWise);
            Assert.IsFalse(poly.IsDegenerate);
            Assert.IsTrue(poly.Orientation == ORIENTATION.POSITIVE);
            Assert.IsTrue(poly.ClockDir == CLOCK_DIR.COUNTER_CLOCKWISE);
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

            var poly = new PolygonWithHoles2<EEK>(points);
            Assert.IsFalse(poly.IsUnbounded);
            Assert.AreEqual(4, poly.Count);
            Assert.IsFalse(poly.IsSimple);
            Assert.IsTrue(poly.IsDegenerate);
            Assert.IsTrue(poly.Orientation == ORIENTATION.ZERO);
            Assert.IsTrue(poly.ClockDir == CLOCK_DIR.ZERO);
        }

        [TestMethod]
        public void Clear()
        {
            var poly = PolygonFactory<EEK>.FromDounut(2, 1, 4);

            Assert.IsFalse(poly.IsUnbounded);
            Assert.AreEqual(4, poly.Count);
            Assert.AreEqual(1, poly.HoleCount);

            poly.Clear();

            Assert.IsTrue(poly.IsUnbounded);
            Assert.AreEqual(0, poly.Count);
            Assert.AreEqual(0, poly.HoleCount);
        }

        [TestMethod]
        public void PointCount()
        {
            var poly = PolygonFactory<EEK>.FromDounut(2, 1, 4);

            Assert.AreEqual(4, poly.PointCount(POLYGON_ELEMENT.BOUNDARY));
            Assert.AreEqual(4, poly.PointCount(POLYGON_ELEMENT.HOLE, 0));
        }
    }
}
