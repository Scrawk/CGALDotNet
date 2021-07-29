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
        public void TestMethod1()
        {


            var poly = PolygonFactory<EEK>.FromCircle(10, 5);

            poly.Print();
            
        }
    }
}
