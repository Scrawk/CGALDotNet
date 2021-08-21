using System;

using CGALDotNetConsole.Examples;

using CGeom2D.Geometry;
using CGeom2D.Points;

namespace CGALDotNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var collection = new PointCollection(Point2i.Zero, 1000000);

            collection.AddPoint(0, 0);
            collection.AddPoint(4, 0);
            collection.AddPoint(2, 2);
            collection.AddPoint(4, -4);
            collection.AddPoint(6, -6);
            collection.AddPoint(8, -4);

            collection.AddSegment(0, 1);
            collection.AddSegment(0, 2);
            collection.AddSegment(0, 3);
            collection.AddSegment(3, 4);
            collection.AddSegment(3, 5);

            var line = collection.CreateSweepLine();

            SweepEvent e;

            do
            {
                e = line.PopEvent();
            }
            while (line.HandleEvent(e));

    

            //Polygon2Examples.SimplifyPolygon();

            //var points = new Point2d[]
            //{
            //    new Point2d(-10,-10),
            //    new Point2d(10,-10),
             //   new Point2d(10,10),
             //   new Point2d(-10,10)
            //};

            //ConformingTriangulation.MakeConforming(points, 0, 4);

            //Geometry2Examples.Transform();

            //Polygon2Examples.CreateSimplePolygon();
            //Polygon2Examples.CreateRelativelySimplePolygon();
            //Polygon2Examples.CreateConcavePolygon();
            //Polygon2Examples.CreateNonSimplePolygon();
            //Polygon2Examples.PolygonContainsPoint();
            //Polygon2Examples.CreatePolygonWithHoles();
            //Polygon2Examples.PolygonWithHolesContainsPoint();
            //Polygon2Examples.TransformPolygon();

            //Polygon2BooleanExamples.DoIntersect();
            //Polygon2BooleanExamples.Join();
            //Polygon2BooleanExamples.Intersect();
            //Polygon2BooleanExamples.Difference();
            //Polygon2BooleanExamples.SymmetricDifference();
            //Polygon2BooleanExamples.Complement();

            //Arrangement2Examples.CreateArrangement();
            //Arrangement2Examples.GetGeometryExample();
            //Arrangement2Examples.GetElementsExample();
            //Arrangement2Examples.PointQueryExample();
            //Arrangement2Examples.BatchedPointQueryExample();
            //Arrangement2Examples.RayQueryExample();
            //Arrangement2Examples.RemoveVertex();
            //Arrangement2Examples.RemoveEdge();

            //Triangulation2Examples.CreateTriangulation();
            //Triangulation2Examples.GetPointsAndIndices();
            //Triangulation2Examples.GetVerticesAndFaces();

            //DelaunayTriangulation2Examples.CreateDelaunayTriangulation();

            //ConstrainedTriangulation2Examples.CreateConstrainedTriangulation();

            //ConstrainedTriangulation2Examples.GetPolygonIndices();

            //PolygonPartition2Examples.CreatePolygonPartition();

            //IntersectionExamples.PointIntersections();
            //IntersectionExamples.LineIntersections();

            //IntersectionExamples.Test();

        }

    }
}
