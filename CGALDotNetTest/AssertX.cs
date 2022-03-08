using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Geometry;

namespace CGALDotNetTest
{
    public static class AssertX
    {
        public static void AlmostEqual(this double d, double d2, double eps = MathUtil.EPS_64)
        {
            Assert.IsTrue(MathUtil.AlmostEqual(d, d2, eps));
        }

        public static void AlmostEqual(this Point2d p1, Point2d p2, double eps = MathUtil.EPS_64)
        {
            Assert.IsTrue(Point2d.AlmostEqual(p1, p2, eps));
        }

        public static void AlmostEqual(this Point3d p1, Point3d p2, double eps = MathUtil.EPS_64)
        {
            Assert.IsTrue(Point3d.AlmostEqual(p1, p2, eps));
        }

        public static void AlmostEqual(this Vector2d p1, Vector2d p2, double eps = MathUtil.EPS_64)
        {
            Assert.IsTrue(Vector2d.AlmostEqual(p1, p2, eps));
        }

        public static void AlmostEqual(this Vector3d p1, Vector3d p2, double eps = MathUtil.EPS_64)
        {
            Assert.IsTrue(Vector3d.AlmostEqual(p1, p2, eps));
        }
    }
}
