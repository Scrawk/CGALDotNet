using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole.Examples
{
    class ConstrainedTriangulation2Examples
    {
        public static void CreateConstrainedTriangulation()
        {
            Console.WriteLine("Create constrained triangulation example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(2, 2),
                new Point2d(0, 5)
            };

            var tri = new ConstrainedTriangulation2<EEK>(points);

            //tri.InsertConstraint(new Segment2d(points[0], points[3]));

            tri.Print();

            points = new Point2d[tri.VertexCount];
            tri.GetPoints(points);

            Console.WriteLine("Points " + points.Length);
            Console.WriteLine();

            for (int i = 0; i < points.Length; i++)
                Console.WriteLine("Point " + i + " = " + points[i]);
        }
    }
}
