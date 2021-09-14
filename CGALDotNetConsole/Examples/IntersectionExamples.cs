using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Arrangements;

namespace CGALDotNetConsole.Examples
{
    public static class IntersectionExamples
    {

        public static void PointIntersections()
        {
            Console.WriteLine("Point Intersections\n");

            Point2d p0 = new Point2d(0, 0);
            Point2d p1 = new Point2d(1, 0);
            Point2d p2 = new Point2d(0, 1);
            Point2d p3 = new Point2d(1, 1);
            Point2d p4 = new Point2d(-1, -1);

            Vector2d v1 = new Vector2d(1, 0);
            Vector2d v2 = new Vector2d(0, 1);

            Line2d line = new Line2d(p0, p1);
            Ray2d ray = new Ray2d(p0, v1);
            Segment2d seg = new Segment2d(p0, p1);
            Triangle2d tri = new Triangle2d(p0, p1, p2);
            Box2d box = new Box2d(p0, p3);

            Console.WriteLine("Point " + p1 + " intersects line = " + CGALIntersections.DoIntersect(p1, line));
            Console.WriteLine("Point " + p2 + " intersects line = " + CGALIntersections.DoIntersect(p2, line));

            Console.WriteLine("Point " + p1 + " intersects ray = " + CGALIntersections.DoIntersect(p1, ray));
            Console.WriteLine("Point " + p2 + " intersects ray = " + CGALIntersections.DoIntersect(p2, ray));

            Console.WriteLine("Point " + p1 + " intersects seg = " + CGALIntersections.DoIntersect(p1, seg));
            Console.WriteLine("Point " + p2 + " intersects seg = " + CGALIntersections.DoIntersect(p2, seg));

            Console.WriteLine("Point " + p1 + " intersects tri = " + CGALIntersections.DoIntersect(p1, tri));
            Console.WriteLine("Point " + p3 + " intersects tri = " + CGALIntersections.DoIntersect(p3, tri));

            Console.WriteLine("Point " + p1 + " intersects box = " + CGALIntersections.DoIntersect(p1, box));
            Console.WriteLine("Point " + p4 + " intersects box = " + CGALIntersections.DoIntersect(p4, box));

            Console.WriteLine();

            Console.WriteLine("Point " + p1 + " intersection line result = " + PrintResult(CGALIntersections.Intersection(p1, line)));
            Console.WriteLine("Point " + p1 + " intersection ray result  = " + PrintResult(CGALIntersections.Intersection(p1, ray)));
            Console.WriteLine("Point " + p1 + " intersection seg result = " + PrintResult(CGALIntersections.Intersection(p1, seg)));
            Console.WriteLine("Point " + p1 + " intersection tri result = " + PrintResult(CGALIntersections.Intersection(p1, tri)));
            Console.WriteLine("Point " + p1 + " intersection box result = " + PrintResult(CGALIntersections.Intersection(p1, box)));
        }

        public static void LineIntersections()
        {
            Console.WriteLine("Line Intersections\n");

            Point2d p0 = new Point2d(0, 0);
            Point2d p1 = new Point2d(1, 0);
            Point2d p2 = new Point2d(0, 1);
            Point2d p3 = new Point2d(1, 1);
            Point2d p4 = new Point2d(-1, -1);
            Point2d p5 = new Point2d(-1, 0);

            Vector2d v1 = new Vector2d(1, 0);
            Vector2d v2 = new Vector2d(0, 1);

            Line2d line0 = new Line2d(p0, p1);
            Line2d line1 = new Line2d(p0, p2);
            Line2d line2 = new Line2d(p0, p3);
            Line2d line3 = new Line2d(p4, p5);

            Ray2d ray = new Ray2d(p0, v1);
            Segment2d seg = new Segment2d(p0, p1);
            Triangle2d tri = new Triangle2d(p0, p1, p2);
            Box2d box = new Box2d(p0, p3);

            Console.WriteLine("Line 0 intersects point 1 = " + CGALIntersections.DoIntersect(line0, p1));
            Console.WriteLine("Line 1 intersects point 3 = " + CGALIntersections.DoIntersect(line1, p3));

            Console.WriteLine("Line 0 intersects ray = " + CGALIntersections.DoIntersect(line0, ray));
            Console.WriteLine("Line 3 intersects ray = " + CGALIntersections.DoIntersect(line3, ray));

            Console.WriteLine("Line 0 intersects seg = " + CGALIntersections.DoIntersect(line0, seg));
            Console.WriteLine("Line 3 intersects seg = " + CGALIntersections.DoIntersect(line3, seg));

            Console.WriteLine("Line 0 intersects tri = " + CGALIntersections.DoIntersect(line0, tri));
            Console.WriteLine("Line 3 intersects tri = " + CGALIntersections.DoIntersect(line3, tri));

            Console.WriteLine("Line 0 intersects box = " + CGALIntersections.DoIntersect(line0, box));
            Console.WriteLine("Line 3 intersects box = " + CGALIntersections.DoIntersect(line3, box));

            Console.WriteLine();

            Console.WriteLine("Line intersection point result = " + PrintResult(CGALIntersections.Intersection(line0, p0)));
            Console.WriteLine("Line intersection line result = " + PrintResult(CGALIntersections.Intersection(line0, line0)));
            Console.WriteLine("Line intersection ray result  = " + PrintResult(CGALIntersections.Intersection(line0, ray)));
            Console.WriteLine("Line intersection seg result = " + PrintResult(CGALIntersections.Intersection(line0, seg)));
            Console.WriteLine("Line intersection tri result = " + PrintResult(CGALIntersections.Intersection(line0, tri)));
            Console.WriteLine("Line intersection box result = " + PrintResult(CGALIntersections.Intersection(line0, box)));
        }

        public static void Test()
        {
            Console.WriteLine("Test \n");

            var box = new Box2d(-5, 5);

            var triangle = new Triangle2d(new Point2d(0, 0), new Point2d(10, 0), new Point2d(0, 10));

            Console.WriteLine(box);
            Console.WriteLine(triangle);

            Console.WriteLine("Intersection result = " + PrintResult(CGALIntersections.Intersection(box, triangle)));

        }

        private static string PrintResult(IntersectionResult2d result)
        {
            switch (result.Type)
            {
                case INTERSECTION_RESULT_2D.NONE:
                    return "None";

                case INTERSECTION_RESULT_2D.POINT2:
                    return "Point " + result.Point;
                  
                case INTERSECTION_RESULT_2D.LINE2:
                    return "Line " + result.Line;

                case INTERSECTION_RESULT_2D.RAY2:
                    return "Ray " + result.Ray;

                case INTERSECTION_RESULT_2D.SEGMENT2:
                    return "Segment " + result.Segment;

                case INTERSECTION_RESULT_2D.BOX2:
                    return "Box " + result.Box;

                case INTERSECTION_RESULT_2D.TRIANGLE2:
                    return "Triangle " + result.Triangle;

                case INTERSECTION_RESULT_2D.POLYGON2:
                        return "Polygon " + result;
                    
            }

            return "None";
        }
    }
}
