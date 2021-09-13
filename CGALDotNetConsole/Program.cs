using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var star = PolygonFactory<EEK>.KochStar(10, 4);

            var polygon = new PolygonWithHoles2<EEK>(star);
            polygon.Print();

            var polygon2 = PolygonSimplification2<EEK>.Instance.Simplify(polygon, 0.5);

            polygon2.Print();

        }


    }
}
