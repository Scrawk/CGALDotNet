using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
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
            var poly = PolygonFactory<EEK>.CreateDounut(2, 1, 4);

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
            var poly = PolygonFactory<EEK>.CreateDounut(2, 1, 4);

            Assert.AreEqual(4, poly.PointCount(POLYGON_ELEMENT.BOUNDARY));
            Assert.AreEqual(4, poly.PointCount(POLYGON_ELEMENT.HOLE, 0));
        }

        [TestMethod]
        public void Remove()
        {
            var poly = PolygonFactory<EEK>.CreateDounut(2, 1, 4);

            Assert.IsTrue(!poly.IsUnbounded);
            Assert.AreEqual(1, poly.HoleCount);

            poly.Remove(POLYGON_ELEMENT.BOUNDARY);
            poly.Remove(POLYGON_ELEMENT.HOLE, 0);

            Assert.IsTrue(poly.IsUnbounded);
            Assert.AreEqual(0, poly.HoleCount);
        }

        [TestMethod]
        public void Reverse()
        {
            var poly = PolygonFactory<EEK>.CreateDounut(2, 1, 4);

            Assert.AreEqual(ORIENTATION.POSITIVE, poly.FindOrientation(POLYGON_ELEMENT.BOUNDARY));
            Assert.AreEqual(ORIENTATION.NEGATIVE, poly.FindOrientation(POLYGON_ELEMENT.HOLE, 0));

            poly.Reverse(POLYGON_ELEMENT.BOUNDARY);
            poly.Reverse(POLYGON_ELEMENT.HOLE, 0);

            Assert.AreEqual(ORIENTATION.NEGATIVE, poly.FindOrientation(POLYGON_ELEMENT.BOUNDARY));
            Assert.AreEqual(ORIENTATION.POSITIVE, poly.FindOrientation(POLYGON_ELEMENT.HOLE, 0));
        }

        [TestMethod]
        public void GetPoint()
        {
            var outer = PolygonFactory<EEK>.CreateBox(-2, 2);
            var inner = PolygonFactory<EEK>.CreateBox(-1, 1);
            inner.Reverse();

            var poly = new PolygonWithHoles2<EEK>(outer);
            poly.AddHole(inner);

            Assert.AreEqual(new Point2d(-2, -2), poly.GetPoint(POLYGON_ELEMENT.BOUNDARY, 0));
            Assert.AreEqual(new Point2d(2, -2), poly.GetPoint(POLYGON_ELEMENT.BOUNDARY, 1));
            Assert.AreEqual(new Point2d(2, 2), poly.GetPoint(POLYGON_ELEMENT.BOUNDARY, 2));
            Assert.AreEqual(new Point2d(-2, 2), poly.GetPoint(POLYGON_ELEMENT.BOUNDARY, 3));

            Assert.AreEqual(new Point2d(-1, -1), poly.GetPoint(POLYGON_ELEMENT.HOLE, 0, 0));
            Assert.AreEqual(new Point2d(-1, 1), poly.GetPoint(POLYGON_ELEMENT.HOLE, 1, 0));
            Assert.AreEqual(new Point2d(1, 1), poly.GetPoint(POLYGON_ELEMENT.HOLE, 2, 0));
            Assert.AreEqual(new Point2d(1, -1), poly.GetPoint(POLYGON_ELEMENT.HOLE, 3, 0));
        }

        [TestMethod]
        public void GetPoints()
        {
            var outer = PolygonFactory<EEK>.CreateBox(-2, 2);
            var inner = PolygonFactory<EEK>.CreateBox(-1, 1);
            inner.Reverse();

            var poly = new PolygonWithHoles2<EEK>(outer);
            poly.AddHole(inner);

            var boundary = new Point2d[]
            {
                new Point2d(-2, -2),
                new Point2d(2, -2),
                new Point2d(2, 2),
                new Point2d(-2, 2)
            };

            var hole = new Point2d[]
            {
                new Point2d(-1, -1),
                new Point2d(-1, 1),
                new Point2d(1, 1),
                new Point2d(1, -1)
            };

            int count = poly.PointCount(POLYGON_ELEMENT.BOUNDARY);
            var tmp = new Point2d[count];

            poly.GetPoints(POLYGON_ELEMENT.BOUNDARY, tmp, tmp.Length);

            CollectionAssert.AreEqual(boundary, tmp);

            count = poly.PointCount(POLYGON_ELEMENT.HOLE, 0);
            tmp = new Point2d[count];

            poly.GetPoints(POLYGON_ELEMENT.HOLE, tmp, tmp.Length, 0);

            CollectionAssert.AreEqual(hole, tmp);
        }

        [TestMethod]
        public void GetAllPoints()
        {
            var outer = PolygonFactory<EEK>.CreateBox(-2, 2);
            var inner = PolygonFactory<EEK>.CreateBox(-1, 1);
            inner.Reverse();

            var poly = new PolygonWithHoles2<EEK>(outer);
            poly.AddHole(inner);

            var points = new Point2d[]
            {
                new Point2d(-2, -2),
                new Point2d(2, -2),
                new Point2d(2, 2),
                new Point2d(-2, 2),
 
                new Point2d(-1, -1),
                new Point2d(-1, 1),
                new Point2d(1, 1),
                new Point2d(1, -1)
            };

            var tmp = new List<Point2d>();
            poly.GetAllPoints(tmp);

            CollectionAssert.AreEqual(points, tmp);

        }
    }
}
