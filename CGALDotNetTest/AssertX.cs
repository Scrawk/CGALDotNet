using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Geometry;
using CGALDotNet.Eigen;

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

        public static void AlmostEqual(this EigenMatrix m1, EigenMatrix m2, double eps = MathUtil.EPS_64)
        {
            Assert.AreEqual(m1.Rows, m2.Rows);
            Assert.AreEqual(m1.Columns, m2.Columns);

            for (int i = 0; i < m1.Length; i++)
            {
                Assert.IsTrue(MathUtil.AlmostEqual(m1[i], m2[i], eps));
            }
        }

        public static void AlmostEqual(this EigenColumnVector v1, EigenColumnVector v2, double eps = MathUtil.EPS_64)
        {
            Assert.AreEqual(v1.Dimension, v2.Dimension);

            for (int i = 0; i < v1.Dimension; i++)
            {
                Assert.IsTrue(MathUtil.AlmostEqual(v1[i], v2[i], eps));
            }
        }

        public static void AlmostEqual(this EigenRowVector v1, EigenRowVector v2, double eps = MathUtil.EPS_64)
        {
            Assert.AreEqual(v1.Dimension, v2.Dimension);

            for (int i = 0; i < v1.Dimension; i++)
            {
                Assert.IsTrue(MathUtil.AlmostEqual(v1[i], v2[i], eps));
            }
        }
    }
}
