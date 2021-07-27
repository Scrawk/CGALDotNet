using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Arrangements;

namespace CGALDotNetConsole.Examples
{
    public static class Arrangement2Examples
    {

        public static void CreateArrangement()
        {
            Console.WriteLine("Create arrangement example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);

            var segments = new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>();
            arr.InsertSegments(segments, true);
            arr.Print();
        }

        public static void GetGeometryExample()
        {
            Console.WriteLine("Get geometry example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);

            var segments = new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>();
            arr.InsertSegments(segments, true);

            var points = new Point2d[arr.VertexCount];
            arr.GetPoints(points);

            Console.WriteLine("Arrangement Points.");
            Console.WriteLine();

            foreach (var p in points)
                Console.WriteLine(p.ToString());

            segments = new Segment2d[arr.EdgeCount];
            arr.GetSegments(segments);

            Console.WriteLine();
            Console.WriteLine("Arrangement Segments.\n");

            foreach (var s in segments)
                Console.WriteLine(s.ToString());

            Console.WriteLine();
        }

        public static void GetElementsExample()
        {
            Console.WriteLine("Get elements example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);

            var segments = new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>();
            arr.InsertSegments(segments, true);

            arr.Print(true);

        }

        public static void PointQueryExample()
        {
            Console.WriteLine("Point query example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);

            var segments = new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>();
            arr.InsertSegments(segments, true);
            
            arr.CreateLocator(ARR_LOCATOR.NAIVE);

            ArrQuery result;

            if (arr.PointQuery(new Point2d(1, 1), out result))
                Console.WriteLine("Point result = " + result);
            else
                Console.WriteLine("Point did not hit a element.");
        }

        public static void BatchedPointQueryExample()
        {
            Console.WriteLine("Batched point query example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);

            var segments = new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>();
            arr.InsertSegments(segments, true);

            arr.CreateLocator(ARR_LOCATOR.WALK);

            var queries = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(1, 1),
                new Point2d(0, 5)
            };

            ArrQuery[] results = new ArrQuery[queries.Length];

            if (arr.BatchedPointQuery(queries, results))
            {
                foreach (var result in results)
                    Console.WriteLine("Point result = " + result);
            }
            else
                Console.WriteLine("Queries did not hit a element.");
        }

        public static void RayQueryExample()
        {
            Console.WriteLine("Ray query example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);

            var segments = new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>();
            arr.InsertSegments(segments, true);

            arr.CreateLocator(ARR_LOCATOR.WALK);

            ArrQuery result;

            if (arr.RayQuery(new Point2d(1, 1), true, out result))
                Console.WriteLine("Point result = " + result);
            else
                Console.WriteLine("Point did not hit a element.");
        }

        public static void RemoveVertex()
        {
            Console.WriteLine("Remove vertex example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);
            Point2d p4 = new Point2d(1, 1);

            var segments = new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>();
            arr.InsertSegments(segments, true);
            arr.CreateLocator(ARR_LOCATOR.WALK);

            arr.InsertPoint(p4);

            Console.WriteLine("Removed by point " + arr.RemoveVertex(p4) + "\n");

            arr.InsertPoint(p4);

            Console.WriteLine("Removed by index " + arr.RemoveVertex(3) + "\n");

            arr.Print();
        }

        public static void RemoveEdge()
        {
            Console.WriteLine("Remove vertex example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);
            Point2d p4 = new Point2d(1, 1);

            var segments = new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>();
            arr.InsertSegments(segments, true);

            arr.CreateLocator(ARR_LOCATOR.WALK);

            Console.WriteLine("Removed by segment " + arr.RemoveEdge(new Segment2d(p2, p1)) + "\n");

            Console.WriteLine("Removed by index " + arr.RemoveEdge(3) + "\n");

            arr.Print(true);
        }

    }
}
