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
                new Point2d(6, 2),
                new Point2d(6, 3),
                new Point2d(5, 5),
                new Point2d(2, 2),
                new Point2d(0, 5)
            };

            var polygon = new Polygon2<EEK>(points);

            var tri = new ConstrainedTriangulation2<EEK>();
            tri.InsertPolygonConstraint(polygon);

            tri.RemoveConstraint(3, 2);

            int constraintCount = tri.ConstrainedEdgeCount;

            int incidentCount = tri.IncidentConstraintCount(0);

            Console.WriteLine("Constraint count = " + constraintCount);

            Console.WriteLine("Has constraint for vert = " + tri.HasIncidentConstraint(0));

            Console.WriteLine("Incident constraint count for vert = " + incidentCount);

            Console.WriteLine();
            Console.WriteLine("Constraints");

            var constraints = new TriEdge2[constraintCount];
            tri.GetConstraints(constraints);

            foreach (var constraint in constraints)
                Console.WriteLine(constraint);

            Console.WriteLine();
            Console.WriteLine("Incident constraints");

            constraints = new TriEdge2[incidentCount];
            tri.GetIncidentConstraints(0, constraints);

            foreach (var constraint in constraints)
                Console.WriteLine(constraint);

            Console.WriteLine();
            tri.Print();

        }

        public static void GetPolygonIndices()
        {
            Console.WriteLine("Get polygon indices example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(2, 2),
                new Point2d(0, 5)
            };

            var polygon = new Polygon2<EEK>(points);

            var tri = new ConstrainedTriangulation2<EEK>();
            tri.InsertPolygonConstraint(polygon);

            var indices = new List<int>();
            tri.GetPolygonIndices(polygon, indices);

            foreach (int i in indices)
                Console.WriteLine(i);

        }
    }
}
