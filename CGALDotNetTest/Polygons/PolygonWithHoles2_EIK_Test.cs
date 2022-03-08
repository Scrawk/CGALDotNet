using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polygons;

namespace CGALDotNetTest.Polygons
{
    [TestClass]
    public class PolygonWithHoles2_EIK_Test
    {


        [TestMethod]
        public void CreatePolygon()
        {
            var poly = new PolygonWithHoles2<EIK>();

            Assert.AreEqual(0, poly.Count);
            Assert.IsFalse(poly.IsSimple);
            Assert.IsTrue(poly.IsDegenerate);
        }

        [TestMethod]
        public void ReleasePolygon()
        {
            var poly = new PolygonWithHoles2<EIK>();
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

            var poly = new PolygonWithHoles2<EIK>(points);

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

            var poly = new PolygonWithHoles2<EIK>(points);

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

            var poly = new PolygonWithHoles2<EIK>(points);
            Assert.IsFalse(poly.IsUnbounded);
            Assert.AreEqual(4, poly.Count);
            Assert.IsFalse(poly.IsSimple);
            Assert.IsTrue(poly.IsDegenerate);
            Assert.IsTrue(poly.Orientation == ORIENTATION.ZERO);
            Assert.IsTrue(poly.ClockDir == CLOCK_DIR.ZERO);
        }

        [TestMethod]
        public void Copy()
        {
            var poly1 = PolygonFactory<EIK>.CreateDounut(5, 4, 8);
            var poly2 = poly1.Copy();

            Assert.AreEqual(poly1.Count, poly2.Count);
            Assert.AreEqual(poly1.HoleCount, poly2.HoleCount);

            for (int i = 0; i < poly1.Count; i++)
            {
                var p1 = poly1.GetPoint(POLYGON_ELEMENT.BOUNDARY, i);
                var p2 = poly2.GetPoint(POLYGON_ELEMENT.BOUNDARY, i);
                AssertX.AlmostEqual(p1, p2, 0);
            }

            for (int i = 0; i < poly1.HoleCount; i++)
            {
                var hole1 = poly1.GetHole(i);
                var hole2 = poly2.GetHole(i);

                for (int j = 0; j < hole1.Count; j++)
                {
                    var p1 = hole1.GetPoint(j);
                    var p2 = hole2.GetPoint(j);
                    AssertX.AlmostEqual(p1, p2, 0);
                }
            }
        }

        [TestMethod]
        public void Convert()
        {
            var poly1 = PolygonFactory<EIK>.CreateDounut(5, 4, 8);
            var poly2 = poly1.Convert<EEK>();

            Assert.AreEqual(poly1.Count, poly2.Count);
            Assert.AreEqual(poly1.HoleCount, poly2.HoleCount);
            Assert.AreEqual("EEK", poly2.KernelName);

            for (int i = 0; i < poly1.Count; i++)
            {
                var p1 = poly1.GetPoint(POLYGON_ELEMENT.BOUNDARY, i);
                var p2 = poly2.GetPoint(POLYGON_ELEMENT.BOUNDARY, i);
                AssertX.AlmostEqual(p1, p2);
            }

            for (int i = 0; i < poly1.HoleCount; i++)
            {
                var hole1 = poly1.GetHole(i);
                var hole2 = poly2.GetHole(i);

                for (int j = 0; j < hole1.Count; j++)
                {
                    var p1 = hole1.GetPoint(j);
                    var p2 = hole2.GetPoint(j);
                    AssertX.AlmostEqual(p1, p2);
                }
            }
        }

        [TestMethod]
        public void Clear()
        {
            var poly = PolygonFactory<EIK>.CreateDounut(2, 1, 4);

            Assert.IsFalse(poly.IsUnbounded);
            Assert.AreEqual(4, poly.Count);
            Assert.AreEqual(1, poly.HoleCount);

            poly.Clear();

            Assert.IsTrue(poly.IsUnbounded);
            Assert.AreEqual(0, poly.Count);
            Assert.AreEqual(0, poly.HoleCount);
        }

        [TestMethod]
        public void ClearHoles()
        {
            var poly = PolygonFactory<EIK>.CreateDounut(2, 1, 4);

            Assert.AreEqual(1, poly.HoleCount);

            poly.ClearHoles();

            Assert.AreEqual(0, poly.HoleCount);
        }

        [TestMethod]
        public void PointCount()
        {
            var poly = PolygonFactory<EIK>.CreateDounut(2, 1, 4);

            Assert.AreEqual(4, poly.PointCount(POLYGON_ELEMENT.BOUNDARY));
            Assert.AreEqual(4, poly.PointCount(POLYGON_ELEMENT.HOLE, 0));
        }

        [TestMethod]
        public void Remove()
        {
            var poly = PolygonFactory<EIK>.CreateDounut(2, 1, 4);

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
            var poly = PolygonFactory<EIK>.CreateDounut(2, 1, 4);

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
            var outer = PolygonFactory<EIK>.CreateBox(-2, 2);
            var inner = PolygonFactory<EIK>.CreateBox(-1, 1);
            inner.Reverse();

            var poly = new PolygonWithHoles2<EIK>(outer);
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
            var outer = PolygonFactory<EIK>.CreateBox(-2, 2);
            var inner = PolygonFactory<EIK>.CreateBox(-1, 1);
            inner.Reverse();

            var poly = new PolygonWithHoles2<EIK>(outer);
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
            var outer = PolygonFactory<EIK>.CreateBox(-2, 2);
            var inner = PolygonFactory<EIK>.CreateBox(-1, 1);
            inner.Reverse();

            var poly = new PolygonWithHoles2<EIK>(outer);
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
