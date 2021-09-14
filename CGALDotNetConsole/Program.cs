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
            var star = PolygonFactory<EEK>.KochStar(10, 2);

            var poly = new PolygonWithHoles2<EEK>(star);

            Console.WriteLine(poly.FindBoundingBox(POLYGON_ELEMENT.BOUNDARY));

        }


    }
}
