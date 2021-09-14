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

            var circle = PolygonFactory<EEK>.FromCircle(2, 64);
            circle.Reverse();

            var polygon = new PolygonWithHoles2<EEK>(star);
            polygon.AddHole(circle);
            polygon.Print();

            var param = PolygonSimplificationParams.Default;
            param.elements = POLYGON_ELEMENT.BOUNDARY;
    
            var polygon2 = PolygonSimplification2<EEK>.Instance.Simplify(polygon, param);

            polygon2.Print();

        }


    }
}
