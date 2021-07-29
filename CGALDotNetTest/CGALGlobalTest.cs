using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNet.Geometry;

namespace CGALDotNetTest
{
    [TestClass]
    public class CGALGlobalTest
    {
        [TestMethod]
        public void Angle()
        {
            var t2 = new Vector2d(1, 1);
            var u2 = new Vector2d(1, 0);
            var v2 = new Vector2d(0, 1);
            var w2 = new Vector2d(-1, 1);

            Assert.AreEqual(CGALGlobal.Angle(t2, u2), CGAL_ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u2, v2), CGAL_ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w2, u2), CGAL_ANGLE.OBTUSE);

            var t3 = new Vector3d(1, 1, 0);
            var u3 = new Vector3d(1, 0, 0);
            var v3 = new Vector3d(0, 1, 0);
            var w3 = new Vector3d(-1, 1, 0);

            Assert.AreEqual(CGALGlobal.Angle(t3, u3), CGAL_ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u3, v3), CGAL_ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w3, u3), CGAL_ANGLE.OBTUSE);

            Assert.AreEqual(CGALGlobal.Angle(t3.xzy, u3.xzy), CGAL_ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u3.xzy, v3.xzy), CGAL_ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w3.xzy, u3.xzy), CGAL_ANGLE.OBTUSE);
        }

        [TestMethod]
        public void ApproxAngle()
        {
            var t = new Vector3d(1, 1, 0);
            var u = new Vector3d(1, 0, 0);
            var v = new Vector3d(0, 1, 0);
            var w = new Vector3d(-1, 1, 0);

            Assert.AreEqual(CGALGlobal.ApproxAngle(t, u).Rounded(6), 45.0);
            Assert.AreEqual(CGALGlobal.ApproxAngle(u, v).Rounded(6), 90.0);
            Assert.AreEqual(CGALGlobal.ApproxAngle(w, u).Rounded(6), 135.0);

            Assert.AreEqual(CGALGlobal.ApproxAngle(t.xzy, u.xzy).Rounded(6), 45.0);
            Assert.AreEqual(CGALGlobal.ApproxAngle(u.xzy, v.xzy).Rounded(6), 90.0);
            Assert.AreEqual(CGALGlobal.ApproxAngle(w.xzy, u.xzy).Rounded(6), 135.0);
        }


        [TestMethod]
        public void ApproxDihedralAngle()
        {
            var p = new Point3d(1, 1, 0);
            var q = new Point3d(-1, 1, 0);
            var r = new Point3d(1, 0, 1);
            var s = new Point3d(-1, 0, 1);

            var d = CGALGlobal.ApproxDihedralAngle(p, q, r, s);
        }

        [TestMethod]
        public void AreOrderedAlongLine()
        {
            var p2 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var r2 = new Point2d(3, 0);
  
            Assert.IsTrue(CGALGlobal.AreOrderedAlongLine(p2, q2, r2));

            var p3 = new Point3d(1, 0, 0);
            var q3 = new Point3d(2, 0, 0);
            var r3 = new Point3d(3, 0, 0);

            Assert.IsTrue(CGALGlobal.AreOrderedAlongLine(p3, q3, r3));
            Assert.IsTrue(CGALGlobal.AreOrderedAlongLine(p3.xzy, q3.xzy, r3.xzy));
        }

        [TestMethod]
        public void AreStrictlyOrderedAlongLine()
        {
            var p2 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var r2 = new Point2d(3, 0);

            Assert.IsTrue(CGALGlobal.AreStrictlyOrderedAlongLine(p2, q2, r2));
            Assert.IsFalse(CGALGlobal.AreStrictlyOrderedAlongLine(p2, r2, r2));

            var p3 = new Point3d(1, 0, 0);
            var q3 = new Point3d(2, 0, 0);
            var r3 = new Point3d(3, 0, 0);

            Assert.IsTrue(CGALGlobal.AreStrictlyOrderedAlongLine(p3, q3, r3));
            Assert.IsTrue(CGALGlobal.AreStrictlyOrderedAlongLine(p3.xzy, q3.xzy, r3.xzy));
            Assert.IsFalse(CGALGlobal.AreStrictlyOrderedAlongLine(p3, q3, q3));
        }

        [TestMethod]
        public void Colinear()
        {
            var p2 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var r2 = new Point2d(3, 0);

            Assert.IsTrue(CGALGlobal.Collinear(p2, q2, r2));

            var p3 = new Point3d(1, 0, 0);
            var q3 = new Point3d(2, 0, 0);
            var r3 = new Point3d(3, 0, 0);

            Assert.IsTrue(CGALGlobal.Collinear(p3, q3, r3));
            Assert.IsTrue(CGALGlobal.Collinear(p3.xzy, q3.xzy, r3.xzy));
        }

        [TestMethod]
        public void Bisector()
        {
            var p = new Point3d(1, 0, 0);
            var q = new Point3d(1, 1, 0);

            var line = CGALGlobal.Bisector(p, q);
            Console.WriteLine(line);

            var l1 = new Line2d(Point2d.Zero, new Point2d(1, 0));
            var l2 = new Line2d(Point2d.Zero, new Point2d(1, 1));

            line = CGALGlobal.Bisector(l1, l2);
            Console.WriteLine(line);
        }

        [TestMethod]
        public void Coplanar()
        {
            var p = new Point3d(1, 0, 0);
            var q = new Point3d(2, 0, 0);
            var r = new Point3d(1, 1, 0);
            var s = new Point3d(2, 1, 0);
            var t = new Point3d(2, 0, 1);

            Assert.IsTrue(CGALGlobal.Coplanar(p, q, r, s));
            Assert.IsFalse(CGALGlobal.Coplanar(p, q, r, t));
            Assert.IsTrue(CGALGlobal.Coplanar(p.xzy, q.xzy, r.xzy, s.xzy));
            Assert.IsFalse(CGALGlobal.Coplanar(p.xzy, q.xzy, r.xzy, t.xzy));
        }

        [TestMethod]
        public void CoplanarOrientation()
        {
            var p = new Point3d(1, 0, 0);
            var q = new Point3d(2, 0, 0);
            var r = new Point3d(1, 1, 0);
            var s = new Point3d(2, 1, 0);
            var t = new Point3d(2, 0, 1);

            Assert.AreEqual(CGALGlobal.CoplanarOrientation(p, q, r, s), CGAL_ORIENTATION.POSITIVE);
        }

        [TestMethod]
        public void EquidistantLine()
        {
            var p = new Point3d(1, 0, 0);
            var q = new Point3d(2, 0, 0);
            var r = new Point3d(1, 1, 0);
            var s = new Point3d(2, 1, 0);
            var t = new Point3d(2, 0, 1);

            Console.WriteLine(CGALGlobal.EquidistantLine(p, q, r));
        }
    }
}
