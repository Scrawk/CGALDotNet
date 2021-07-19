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

            var arr = new Arrangement2<EEK>(segments);
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

            var arr = new Arrangement2<EEK>(segments);

            var points = new Point2d[arr.VertexCount];
            arr.GetPoints(points);

            Console.WriteLine("Arrangement Points.");
            Console.WriteLine();

            foreach (var p in points)
                Console.WriteLine(p.ToString());

            segments = new Segment2d[arr.EdgeCount];
            arr.GetSegments(segments);

            Console.WriteLine();
            Console.WriteLine("Arrangement Segments\n.");

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

            var arr = new Arrangement2<EEK>(segments);

            arr.SetIndices();

            var vertices = new ArrVertex2[arr.VertexCount];
            arr.GetVertices(vertices);

            Console.WriteLine("Arrangement Vertices.\n");

            foreach (var v in vertices)
            {
                Console.WriteLine(v.ToString());

                Console.WriteLine("Index = " + v.Index);
                Console.WriteLine("Face Index = " + v.FaceIndex);
                Console.WriteLine("HalfEdge Index = " + v.HalfEdgeIndex);

                Console.WriteLine();
            }

            Console.WriteLine("Arrangement Half Edges.\n");

            var edges = new ArrHalfEdge2[arr.HalfEdgeCount];
            arr.GetHalfEdges(edges);

            foreach (var e in edges)
            {
                Console.WriteLine(e.ToString());

                Console.WriteLine("Index = " + e.Index);
                Console.WriteLine("Source Index = " + e.SourceIndex);
                Console.WriteLine("Target Index = " + e.TargetIndex);
                Console.WriteLine("Face Index = " + e.FaceIndex);
                Console.WriteLine("Next Index = " + e.NextIndex);
                Console.WriteLine("Previous Index = " + e.PreviousIndex);
                Console.WriteLine("Twin Index = " + e.TwinIndex);

                Console.WriteLine();
            }

            Console.WriteLine("Arrangement Faces.\n");

            var faces = new ArrFace2[arr.FaceCount];
            arr.GetFaces(faces);

            foreach (var e in faces)
            {
                Console.WriteLine(e.ToString());

                Console.WriteLine("Index = " + e.Index);
                Console.WriteLine("HalfEdge Index = " + e.HalfEdgeIndex);

                Console.WriteLine();
            }

            Console.WriteLine();
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

            var arr = new Arrangement2<EEK>(segments);

            arr.SetIndices();
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

            var arr = new Arrangement2<EEK>(segments);

            arr.SetIndices();
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

            var arr = new Arrangement2<EEK>(segments);

            arr.SetIndices();
            arr.CreateLocator(ARR_LOCATOR.WALK);

            ArrQuery result;

            if (arr.RayQuery(new Point2d(1, 1), true, out result))
                Console.WriteLine("Point result = " + result);
            else
                Console.WriteLine("Point did not hit a element.");
        }

    }
}
