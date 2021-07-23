using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole.Examples
{
    class DelaunayTriangulation2Examples
    {
        public static void CreateDelaunayTriangulation()
        {
            Console.WriteLine("Create delaunau triangulation example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(2, 2),
                new Point2d(0, 5)
            };

            var tri = new DelaunayTriangulation2<EEK>(points);
            tri.Print();
        }
    }
}
