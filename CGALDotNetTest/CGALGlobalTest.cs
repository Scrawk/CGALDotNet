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
        public void Angle_Vector2()
        {
            var t2 = new Vector2d(1, 1);
            var u2 = new Vector2d(1, 0);
            var v2 = new Vector2d(0, 1);
            var w2 = new Vector2d(-1, 1);

            Assert.AreEqual(CGALGlobal.Angle(t2, u2), ANGLE.ACUTE);
            Assert.AreEqual(CGALGlobal.Angle(u2, v2), ANGLE.RIGHT);
            Assert.AreEqual(CGALGlobal.Angle(w2, u2), ANGLE.OBTUSE);
        }

        [TestMethod]
        public void Angle_Vector3()
        {
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
        public void ApproxAngle_Vector2()
        {
            var t = new Vector3d(1, 1, 0);
            var u = new Vector3d(1, 0, 0);
            var v = new Vector3d(0, 1, 0);
            var w = new Vector3d(-1, 1, 0);

            Assert.AreEqual(CGALGlobal.ApproxAngle(t, u).Rounded(6), 45.0);
            Assert.AreEqual(CGALGlobal.ApproxAngle(u, v).Rounded(6), 90.0);
            Assert.AreEqual(CGALGlobal.ApproxAngle(w, u).Rounded(6), 135.0);
        }

        [TestMethod]
        public void ApproxAngle_Vector3()
        {
            var t = new Vector3d(1, 1, 0);
            var u = new Vector3d(1, 0, 0);
            var v = new Vector3d(0, 1, 0);
            var w = new Vector3d(-1, 1, 0);

            Assert.AreEqual(CGALGlobal.ApproxAngle(t.xzy, u.xzy).Rounded(6), 45.0);
            Assert.AreEqual(CGALGlobal.ApproxAngle(u.xzy, v.xzy).Rounded(6), 90.0);
            Assert.AreEqual(CGALGlobal.ApproxAngle(w.xzy, u.xzy).Rounded(6), 135.0);
        }

        [TestMethod]
        public void AreOrderedAlongLine_Point2()
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
        public void AreStrictlyOrderedAlongLine_Point2()
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
        public void Colinear_Point2()
        {
            var p2 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var r2 = new Point2d(3, 0);

            Assert.IsTrue(CGALGlobal.Collinear(p2, q2, r2));
        }

        [TestMethod]
        public void Colinear_Point3()
        {
            var p3 = new Point3d(1, 0, 0);
            var q3 = new Point3d(2, 0, 0);
            var r3 = new Point3d(3, 0, 0);

            Assert.IsTrue(CGALGlobal.Collinear(p3, q3, r3));
            Assert.IsTrue(CGALGlobal.Collinear(p3.xzy, q3.xzy, r3.xzy));
        }

        [TestMethod]
        public void Colinear_EIK()
        {
            var p2 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var r2 = new Point2d(3, 0);

            Assert.IsTrue(CGALGlobal.Collinear(p2, q2, r2));
        }

        [TestMethod]
        public void Colinear_EEK()
        {
            var p2 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var r2 = new Point2d(3, 0);

            Assert.IsTrue(CGALGlobal.Collinear(p2, q2, r2));
        }

        [TestMethod]
        public void Barycenter_Point2()
        {
            var p = new Point2d(0, 0);
            var q = new Point2d(1, 0);
            var r = new Point2d(1, 1);

            var bc = CGALGlobal.Barycenter(p, q, r);
            bc.Round(2);

            Assert.AreEqual(0.67, bc.x);
            Assert.AreEqual(0.33, bc.y);
        }

        [TestMethod]
        public void Barycenter_Point3()
        {
            var p = new Point3d(0, 0, 0);
            var q = new Point3d(1, 0, 0);
            var r = new Point3d(1, 1, 0);

            var bc = CGALGlobal.Barycenter(p, q, r);
            bc.Round(2);

            Assert.AreEqual(0.67, bc.x);
            Assert.AreEqual(0.33, bc.y);
        }

        [TestMethod]
        public void Barycenter_EIK()
        {
            var p = new Point2<EIK>(0, 0);
            var q = new Point2<EIK>(1, 0);
            var r = new Point2<EIK>(1, 1);

            var bc = CGALGlobal.Barycenter(p, q, r);
            bc.Round(2);

            Assert.AreEqual(0.67, bc.x);
            Assert.AreEqual(0.33, bc.y);
        }

        [TestMethod]
        public void Barycenter_EEK()
        {
            var p = new Point2<EEK>(0, 0);
            var q = new Point2<EEK>(1, 0);
            var r = new Point2<EEK>(1, 1);

            var bc = CGALGlobal.Barycenter(p, q, r);
            bc.Round(2);

            Assert.AreEqual(0.67, bc.x);
            Assert.AreEqual(0.33, bc.y);
        }

        [TestMethod]
        public void Bisector_Point2()
        {
            var p = new Point3d(1, 0, 0);
            var q = new Point3d(1, 1, 0);

            Assert.AreEqual(CGALGlobal.Bisector(p, q), new Line2d(0, -2, 0));
        }

        [TestMethod]
        public void Bisector_Line2()
        {
            var l1 = new Line2d(new Point2d(0, 0), new Point2d(1, 0));
            var l2 = new Line2d(new Point2d(0, 1), new Point2d(1, 1));

            Assert.AreEqual(CGALGlobal.Bisector(l1, l2), new Line2d(0, 2, -1));
        }

        [TestMethod]
        public void Bisector_EIK()
        {
            var l1 = new Line2<EIK>(new Point2d(0, 0), new Point2d(1, 0));
            var l2 = new Line2<EIK>(new Point2d(0, 1), new Point2d(1, 1));
            var bs = CGALGlobal.Bisector(l1, l2);

            Assert.AreEqual(bs.A, 0);
            Assert.AreEqual(bs.B, 2);
            Assert.AreEqual(bs.C, -1);
        }

        [TestMethod]
        public void Bisector_EEK()
        {
            var l1 = new Line2<EEK>(new Point2d(0, 0), new Point2d(1, 0));
            var l2 = new Line2<EEK>(new Point2d(0, 1), new Point2d(1, 1));

            var bs = CGALGlobal.Bisector(l1, l2);

            Assert.AreEqual(bs.A, 0);
            Assert.AreEqual(bs.B, 2);
            Assert.AreEqual(bs.C, -1);
        }

        [TestMethod]
        public void Coplanar_Point3()
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
        public void CoplanarOrientation_Point3()
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

        [TestMethod]
        public void EquidistantLine_Point3()
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

        [TestMethod]
        public void OrthogonalVector_Point3()
        {
            var p = new Point3d(1, 0, 0);
            var q = new Point3d(1, 1, 0);
            var r = new Point3d(0, 1, 0);

            Assert.AreEqual(CGALGlobal.OrthogonalVector(p, q, r), new Vector3d(0,0,1));
        }

        [TestMethod]
        public void Parallel_Line2()
        {
            var l1 = new Line2d(new Point2d(0, 0), new Point2d(1, 0));
            var l2 = new Line2d(new Point2d(1, 0), new Point2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(l1 ,l2));
        }

        [TestMethod]
        public void Parallel_EIK_Line2()
        {
            var l1 = new Line2<EIK>(new Point2d(0, 0), new Point2d(1, 0));
            var l2 = new Line2<EIK>(new Point2d(1, 0), new Point2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(l1, l2));
        }

        [TestMethod]
        public void Parallel_EEK_Line2()
        {
            var l1 = new Line2<EEK>(new Point2d(0, 0), new Point2d(1, 0));
            var l2 = new Line2<EEK>(new Point2d(1, 0), new Point2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(l1, l2));
        }

        [TestMethod]
        public void Parallel_Ray2()
        {
            var r1 = new Ray2d(new Point2d(0, 0), new Vector2d(1, 0));
            var r2 = new Ray2d(new Point2d(1, 0), new Vector2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(r1, r2));
        }

        [TestMethod]
        public void Parallel_EIK_Ray2()
        {
            var r1 = new Ray2<EIK>(new Point2d(0, 0), new Vector2d(1, 0));
            var r2 = new Ray2<EIK>(new Point2d(1, 0), new Vector2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(r1, r2));
        }

        [TestMethod]
        public void Parallel_EEK_Ray2()
        {
            var r1 = new Ray2<EEK>(new Point2d(0, 0), new Vector2d(1, 0));
            var r2 = new Ray2<EEK>(new Point2d(1, 0), new Vector2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(r1, r2));
        }

        [TestMethod]
        public void Parallel_Segment2()
        {
            var s1 = new Segment2d(new Point2d(0, 0), new Point2d(1, 0));
            var s2 = new Segment2d(new Point2d(1, 0), new Point2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(s1, s2));
        }

        [TestMethod]
        public void Parallel_EIK_Segment2()
        {
            var s1 = new Segment2<EIK>(new Point2d(0, 0), new Point2d(1, 0));
            var s2 = new Segment2<EIK>(new Point2d(1, 0), new Point2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(s1, s2));
        }

        [TestMethod]
        public void Parallel_EEK_Segment2()
        {
            var s1 = new Segment2<EEK>(new Point2d(0, 0), new Point2d(1, 0));
            var s2 = new Segment2<EEK>(new Point2d(1, 0), new Point2d(1, 0));

            Assert.IsTrue(CGALGlobal.Parallel(s1, s2));
        }

        [TestMethod]
        public void LeftTurn_Point2()
        {
            var p = new Point2d(0, 0);
            var q = new Point2d(1, 0);
            var r = new Point2d(1, 1);

            Assert.IsTrue(CGALGlobal.LeftTurn(p, q, r));
        }

        [TestMethod]
        public void LeftTurn_EIK()
        {
            var p = new Point2<EIK>(0, 0);
            var q = new Point2<EIK>(1, 0);
            var r = new Point2<EIK>(1, 1);

            Assert.IsTrue(CGALGlobal.LeftTurn(p, q, r));
        }

        [TestMethod]
        public void LeftTurn_EEK()
        {
            var p = new Point2<EEK>(0, 0);
            var q = new Point2<EEK>(1, 0);
            var r = new Point2<EEK>(1, 1);

            Assert.IsTrue(CGALGlobal.LeftTurn(p, q, r));
        }

        [TestMethod]
        public void RightTurn_Point2()
        {
            var p = new Point2d(0, 0);
            var q = new Point2d(1, 0);
            var r = new Point2d(1, 1);

            Assert.IsTrue(CGALGlobal.RightTurn(r, q, p));
        }

        [TestMethod]
        public void RightTurn_EIK()
        {
            var p = new Point2<EIK>(0, 0);
            var q = new Point2<EIK>(1, 0);
            var r = new Point2<EIK>(1, 1);

            Assert.IsTrue(CGALGlobal.RightTurn(r, q, p));
        }

        [TestMethod]
        public void RightTurn_EEK()
        {
            var p = new Point2<EEK>(0, 0);
            var q = new Point2<EEK>(1, 0);
            var r = new Point2<EEK>(1, 1);

            //Assert.IsTrue(CGALGlobal.RightTurn(r, q, p));
        }

        [TestMethod]
        public void Orientation_Point2()
        {
            var p = new Point2d(0, 0);
            var q1 = new Point2d(1, 0);
            var q2 = new Point2d(2, 0);
            var q3 = new Point2d(3, 0);
            var r = new Point2d(1, 1);

            Assert.AreEqual(ORIENTATION.POSITIVE, CGALGlobal.Orientation(p, q1, r));
            Assert.AreEqual(ORIENTATION.NEGATIVE, CGALGlobal.Orientation(r, q1, p));
            Assert.AreEqual(ORIENTATION.ZERO, CGALGlobal.Orientation(q1, q2, q3));
        }

        [TestMethod]
        public void Orientation_EIK()
        {
            var p = new Point2<EIK>(0, 0);
            var q1 = new Point2<EIK>(1, 0);
            var q2 = new Point2<EIK>(2, 0);
            var q3 = new Point2<EIK>(3, 0);
            var r = new Point2<EIK>(1, 1);

            Assert.AreEqual(ORIENTATION.POSITIVE, CGALGlobal.Orientation(p, q1, r));
            Assert.AreEqual(ORIENTATION.NEGATIVE, CGALGlobal.Orientation(r, q1, p));
            Assert.AreEqual(ORIENTATION.ZERO, CGALGlobal.Orientation(q1, q2, q3));
        }

        [TestMethod]
        public void Orientation_EEK()
        {
            var p = new Point2<EEK>(0, 0);
            var q1 = new Point2<EEK>(1, 0);
            var q2 = new Point2<EEK>(2, 0);
            var q3 = new Point2<EEK>(3, 0);
            var r = new Point2<EEK>(1, 1);

            Assert.AreEqual(ORIENTATION.POSITIVE, CGALGlobal.Orientation(p, q1, r));
            Assert.AreEqual(ORIENTATION.NEGATIVE, CGALGlobal.Orientation(r, q1, p));
            Assert.AreEqual(ORIENTATION.ZERO, CGALGlobal.Orientation(q1, q2, q3));
        }

        [TestMethod]
        public void Orientation_Vector2()
        {
            var p = new Vector2d(1, 0);
            var q = new Vector2d(0, 1);
            var q2 = new Vector2d(0, 1);
            var r = new Vector2d(1, 1);

            Assert.AreEqual(ORIENTATION.POSITIVE, CGALGlobal.Orientation(p, r));
            Assert.AreEqual(ORIENTATION.NEGATIVE, CGALGlobal.Orientation(r, p));
            Assert.AreEqual(ORIENTATION.ZERO, CGALGlobal.Orientation(q, q2));
        }

        [TestMethod]
        public void Orientation_EIK_Vector2()
        {
            var p = new Vector2<EIK>(1, 0);
            var q = new Vector2<EIK>(0, 1);
            var q2 = new Vector2<EIK>(0, 1);
            var r = new Vector2<EIK>(1, 1);

            Assert.AreEqual(ORIENTATION.POSITIVE, CGALGlobal.Orientation(p, r));
            Assert.AreEqual(ORIENTATION.NEGATIVE, CGALGlobal.Orientation(r, p));
            Assert.AreEqual(ORIENTATION.ZERO, CGALGlobal.Orientation(q, q2));
        }

        [TestMethod]
        public void Orientation_EEK_Vector2()
        {
            var p = new Vector2<EEK>(1, 0);
            var q = new Vector2<EEK>(0, 1);
            var q2 = new Vector2<EEK>(0, 1);
            var r = new Vector2<EEK>(1, 1);

            Assert.AreEqual(ORIENTATION.POSITIVE, CGALGlobal.Orientation(p, r));
            Assert.AreEqual(ORIENTATION.NEGATIVE, CGALGlobal.Orientation(r, p));
            Assert.AreEqual(ORIENTATION.ZERO, CGALGlobal.Orientation(q, q2));
        }

        [TestMethod]
        public void Orientation_Point3()
        {
            var p = new Point3d(0, 0, 0);
            var q = new Point3d(1, 0, 0);
            var r = new Point3d(1, 1, 0);

            var v = CGALGlobal.OrthogonalVector(p, q, r);

            Assert.AreEqual(0, v.x);
            Assert.AreEqual(0, v.y);
            Assert.AreEqual(1, v.z);
        }

   
    }
}
