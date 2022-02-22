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

            var box = new Box2<EIK>(-2.5, 2.5);
            var boxPoly = PolygonFactory<EIK>.CreateBox(box.Shape);
            var polygon = PolygonFactory<EIK>.KochStar(new Point2d(-2, -2), 4, 1);

            box.Translate(new Point2d(-10, 10));
            polygon.Translate(new Point2d(-10, 10));

            box.Round(2);
            polygon.Round(2);


            box.Print();
            polygon.Print();

            var results = new List<PolygonWithHoles2<EIK>>();
            if (polygon.Intersection(boxPoly, results))
            {
                Console.WriteLine("Intersections : " + results.Count);

                foreach (var poly in results)
                {
                    poly.Round(2);
                    poly.Print();

                    foreach (var p in poly)
                        Console.WriteLine(p);
                }
            }
            else
            {
                Console.WriteLine("No intersections : " + results.Count);
            }
        }


    }
}
