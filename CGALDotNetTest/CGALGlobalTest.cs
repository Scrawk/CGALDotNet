using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNetTest
{
    [TestClass]
    public class CGALGlobalTest
    {
        [TestMethod]
        public void Angle_Shape()
        {
            var t2 = new Vector2d(1, 1);
            var u2 = new Vector2d(1, 0);
            var v2 = new Vector2d(0, 1);
            var w2 = new Vector2d(-1, 1);

            Assert.AreEqual(CGALGlobal.Angle(t2, u2), ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u2, v2), ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w2, u2), ANGLE.OBTUSE);

            var t3 = new Vector3d(1, 1, 0);
            var u3 = new Vector3d(1, 0, 0);
            var v3 = new Vector3d(0, 1, 0);
            var w3 = new Vector3d(-1, 1, 0);

            Assert.AreEqual(CGALGlobal.Angle(t3, u3), ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u3, v3), ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w3, u3), ANGLE.OBTUSE);

            Assert.AreEqual(CGALGlobal.Angle(t3.xzy, u3.xzy), ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u3.xzy, v3.xzy), ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w3.xzy, u3.xzy), ANGLE.OBTUSE);
        }

        [TestMethod]
        public void Angle_EIK()
        {
            var t2 = new Vector2<EIK>(1, 1);
            var u2 = new Vector2<EIK>(1, 0);
            var v2 = new Vector2<EIK>(0, 1);
            var w2 = new Vector2<EIK>(-1, 1);

            Assert.AreEqual(CGALGlobal.Angle(t2, u2), ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u2, v2), ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w2, u2), ANGLE.OBTUSE);
        }

        [TestMethod]
        public void Angle_EEK()
        {
            var t2 = new Vector2<EEK>(1, 1);
            var u2 = new Vector2<EEK>(1, 0);
            var v2 = new Vector2<EEK>(0, 1);
            var w2 = new Vector2<EEK>(-1, 1);

            Assert.AreEqual(CGALGlobal.Angle(t2, u2), ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u2, v2), ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w2, u2), ANGLE.OBTUSE);
        }

        [TestMethod]
        public void ApproxAngle_Shape()
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
        public void AreOrderedAlongLine_Shape()
        {
            var p2 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var r2 = new Point2d(3, 0);

            Assert.IsTrue(CGALGlobal.AreOrderedAlongLine(p2, q2, r2));
        }

        [TestMethod]
        public void AreOrderedAlongLine_EIK()
        {
            var p2 = new Point2<EIK>(1, 0);
            var q2 = new Point2<EIK>(2, 0);
            var r2 = new Point2<EIK>(3, 0);

            Assert.IsTrue(CGALGlobal.AreOrderedAlongLine(p2, q2, r2));
        }

        [TestMethod]
        public void AreOrderedAlongLine_EEK()
        {
            var p2 = new Point2<EEK>(1, 0);
            var q2 = new Point2<EEK>(2, 0);
            var r2 = new Point2<EEK>(3, 0);

            Assert.IsTrue(CGALGlobal.AreOrderedAlongLine(p2, q2, r2));
        }

        [TestMethod]
        public void AreStrictlyOrderedAlongLine_Shape()
        {
            var p2 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var r2 = new Point2d(3, 0);

            Assert.IsTrue(CGALGlobal.AreStrictlyOrderedAlongLine(p2, q2, r2));
            Assert.IsFalse(CGALGlobal.AreStrictlyOrderedAlongLine(p2, r2, r2));
        }

        [TestMethod]
        public void AreStrictlyOrderedAlongLine_EIK()
        {
            var p2 = new Point2<EIK>(1, 0);
            var q2 = new Point2<EIK>(2, 0);
            var r2 = new Point2<EIK>(3, 0);

            Assert.IsTrue(CGALGlobal.AreStrictlyOrderedAlongLine(p2, q2, r2));
            Assert.IsFalse(CGALGlobal.AreStrictlyOrderedAlongLine(p2, r2, r2));
        }

        [TestMethod]
        public void AreStrictlyOrderedAlongLine_EEK()
        {
            var p2 = new Point2<EEK>(1, 0);
            var q2 = new Point2<EEK>(2, 0);
            var r2 = new Point2<EEK>(3, 0);

            Assert.IsTrue(CGALGlobal.AreStrictlyOrderedAlongLine(p2, q2, r2));
            Assert.IsFalse(CGALGlobal.AreStrictlyOrderedAlongLine(p2, r2, r2));
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

            Assert.AreEqual(CGALGlobal.Bisector(p, q), new Line2d(0, -2, 0));

            var l1 = new Line2d(new Point2d(0, 0), new Point2d(1, 0));
            var l2 = new Line2d(new Point2d(0, 1), new Point2d(1, 1));

            Assert.AreEqual(CGALGlobal.Bisector(l1, l2), new Line2d(0, 2, -1));
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
            var p = new Point3d(0, 0, 0);
            var q = new Point3d(1, 0, 0);
            var r = new Point3d(0, -1, 0);
            var s = new Point3d(1, -1, 0);
            var t = new Point3d(0, 0, 1);

            Assert.AreEqual(CGALGlobal.CoplanarOrientation(p, q, r, s), ORIENTATION.POSITIVE);
            Assert.AreEqual(CGALGlobal.CoplanarOrientation(p, q, r, t), ORIENTATION.ZERO);
            Assert.AreEqual(CGALGlobal.CoplanarOrientation(p, q, r, t.xzy), ORIENTATION.NEGATIVE);
        }

        /*
        [TestMethod]
        public void EquidistantLine()
        {
            var p = new Point3d(1, 0, 0);
            var q = new Point3d(0, 1, 0);
            var r = new Point3d(0, 0, 1);

            var l1 = CGALGlobal.EquidistantLine(p, q, r);
            l1.Normalize();
            l1.Round(2);

            var pos = new Point3d(0.33);
            var dir = new Vector3d(0.58);

            var l2 = new Line3d(pos, dir);
            l2.Round(2);

            Assert.AreEqual(l1, l2);
        }
        */

        [TestMethod]
        public void OrthogonalVector()
        {
            var p = new Point3d(1, 0, 0);
            var q = new Point3d(1, 1, 0);
            var r = new Point3d(0, 1, 0);

            Assert.AreEqual(CGALGlobal.OrthogonalVector(p, q, r), new Vector3d(0,0,1));
        }

        [TestMethod]
        public void Parallel()
        {
            var l1 = new Line2d(new Point2d(0, 0), new Point2d(1, 0));
            var l2 = new Line2d(new Point2d(1, 0), new Point2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(l1 ,l2));

            var r1 = new Ray2d(new Point2d(0, 0), new Vector2d(1, 0));
            var r2 = new Ray2d(new Point2d(1, 0), new Vector2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(r1, r2));

            var s1 = new Segment2d(new Point2d(0, 0), new Point2d(1, 0));
            var s2 = new Segment2d(new Point2d(1, 0), new Point2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(s1, s2));
        }
    }
}
