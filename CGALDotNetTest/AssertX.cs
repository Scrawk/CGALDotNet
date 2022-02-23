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
    }
}
