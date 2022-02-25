using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Polylines;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.Polyhedra;
using CGALDotNet.Meshing;
using CGALDotNet.Hulls;
using CGALDotNet.Processing;
using CGALDotNet.Extensions;
using CGALDotNet.Collections;
using CGALDotNet.Eigen;

namespace CGALDotNetConsole
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            var tmp = new Box2<EEK>(-2.5, 2.5);
            var boxPoly = PolygonFactory<EEK>.CreateBox(tmp.Shape);
            var polygon = PolygonFactory<EEK>.KochStar(new Point2d(-2, -2), 4, 1);

            boxPoly.Translate(new Point2d(-10, 10));
            polygon.Translate(new Point2d(-10, 10));

            boxPoly.Print();
            polygon.Print();

            var results = new List<PolygonWithHoles2<EEK>>();
            if (polygon.Intersection(boxPoly, results))
            {
                Console.WriteLine("Intersections : " + results.Count);

                foreach (var poly in results)
                {
                    poly.Print();

                }
            }
            else
            {
                Console.WriteLine("No intersections : " + results.Count);
            }
        }


    }
}
