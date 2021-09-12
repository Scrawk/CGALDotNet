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
        public void CheckFlag()
        {
            var poly = new Polygon2<EEK>();
            poly.CheckFlag = POLYGON_CHECK.NONE;

            Console.WriteLine(poly.CheckFlag);
        
        }

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
            Assert.IsTrue(poly.ClockDir == CLOCK_DIR.COUNTER_CLOCKWISE);
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
            Assert.IsTrue(poly.ClockDir == CLOCK_DIR.COUNTER_CLOCKWISE);
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
            Assert.IsTrue(poly.ClockDir == CLOCK_DIR.ZERO);

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

        [TestMethod]
        public void GetPoints()
        {
            var expected = new Point2d[]
            {
                new Point2d(-1, -1),
                new Point2d(1, -1),
                new Point2d(1, 1),
                new Point2d(-1, 1)
            };

            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            var points = new Point2d[4];
            poly.GetPoints(points);

            CollectionAssert.AreEqual(expected, points);
        }

        [TestMethod]
        public void GetSegments()
        {
            var p0 = new Point2d(-1, -1);
            var p1 = new Point2d(1, -1);
            var p2 = new Point2d(1, 1);
            var p3 = new Point2d(-1, 1);

            var expected = new Segment2d[]
            {
                new Segment2d(p0, p1),
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p0)
            };

            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            var segments = new Segment2d[4];
            poly.GetSegments(segments);

            CollectionAssert.AreEqual(expected, segments);
        }

        [TestMethod]
        public void SetPoint()
        {
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            var p0 = new Point2d(2, 3);
            var p3 = new Point2d(4, 5);

            poly.SetPoint(0, p0);
            poly.SetPoint(3, p3);

            Assert.AreEqual(p0, poly.GetPoint(0));
            Assert.AreEqual(p3, poly.GetPoint(3));
        }

        [TestMethod]
        public void SetPoints()
        {
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            var expected = new Point2d[]
            {
                new Point2d(-2, -2),
                new Point2d(2, -2),
                new Point2d(4, -2),
                new Point2d(4, 2),
                new Point2d(2, 2),
                new Point2d(-2, 2)
            };

            poly.SetPoints(expected);

            var points = new Point2d[6];
            poly.GetPoints(points);

            CollectionAssert.AreEqual(expected, points);
        }

        [TestMethod]
        public void Reverse()
        {
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            Assert.AreEqual(ORIENTATION.POSITIVE, poly.Orientation);
            Assert.AreEqual(CLOCK_DIR.COUNTER_CLOCKWISE, poly.ClockDir);
            Assert.AreEqual(4.0, poly.FindSignedArea());

            poly.Reverse();

            Assert.AreEqual(ORIENTATION.NEGATIVE, poly.Orientation);
            Assert.AreEqual(CLOCK_DIR.CLOCKWISE, poly.ClockDir);
            Assert.AreEqual(-4.0, poly.FindSignedArea());
        }

        [TestMethod]
        public void OrientatedSide()
        {
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);
            var p1 = new Point2d(0, 0);
            var p2 = new Point2d(2, 2);
            var p3 = new Point2d(1, 1);

            Assert.AreEqual(ORIENTED_SIDE.ON_POSITIVE_SIDE, poly.OrientedSide(p1));
            Assert.AreEqual(ORIENTED_SIDE.ON_NEGATIVE_SIDE, poly.OrientedSide(p2));
            Assert.AreEqual(ORIENTED_SIDE.ON_BOUNDARY, poly.OrientedSide(p3));

        }
    }
}
