using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CGALDotNet.Geometry;

namespace CGALDotNet
{

    public enum INTERSECTION_RESULT_2D
    {
        NONE, 
        POINT2,
        LINE2,
        RAY2,
        SEGMENT2,
        BOX2,
        TRIANGLE2
    }

    public struct IntersectionResult2d
    {
        public INTERSECTION_RESULT_2D type;
        private Point2d a, b, c;

        public override string ToString()
        {
            return string.Format("[IntersectionResult2d: Type={0}, a={1}, b={2}, c={3}]",
                type, a, b, c);
        }

        public Point2d Point => a;

        public Line2d Line => new Line2d(a.x, a.y, b.x);

        public Ray2d Ray => new Ray2d(a, (Vector2d)b);

        public Segment2d Segment => new Segment2d(a, b);

        public Box2d Box => new Box2d(a, b);

        public Triangle2d Triangle => new Triangle2d(a, b, c);

    }

    public static class CGALIntersections
    {
        //point 

        public static bool DoIntersect(Point2d point, Line2d line)
        {
            return Intersections_EEK_DoIntersect_PointLine(point, line);
        }

        public static bool DoIntersect(Point2d point, Ray2d ray)
        {
            return Intersections_EEK_DoIntersect_PointRay(point, ray);
        }

        public static bool DoIntersect(Point2d point, Segment2d segment)
        {
            return Intersections_EEK_DoIntersect_PointSegment(point, segment);
        }

        public static bool DoIntersect(Point2d point, Triangle2d triangle)
        {
            return Intersections_EEK_DoIntersect_PointTriangle(point, triangle);
        }

        public static bool DoIntersect(Point2d point, Box2d box)
        {
            return Intersections_EEK_DoIntersect_PointBox(point, box);
        }

        //line

        public static bool DoIntersect(Line2d line, Point2d point)
        {
            return Intersections_EEK_DoIntersect_LinePoint(line, point);
        }

        public static bool DoIntersect(Line2d line, Line2d line2)
        {
            return Intersections_EEK_DoIntersect_LineLine(line, line2);
        }

        public static bool DoIntersect(Line2d line, Ray2d ray)
        {
            return Intersections_EEK_DoIntersect_LineRay(line, ray);
        }

        public static bool DoIntersect(Line2d line, Segment2d segment)
        {
            return Intersections_EEK_DoIntersect_LineSegment(line, segment);
        }

        public static bool DoIntersect(Line2d line, Triangle2d triangle)
        {
            return Intersections_EEK_DoIntersect_LineTriangle(line, triangle);
        }

        public static bool DoIntersect(Line2d line, Box2d box)
        {
            return Intersections_EEK_DoIntersect_LineBox(line, box);
        }

        //ray

        public static bool DoIntersect(Ray2d ray, Point2d point)
        {
            return Intersections_EEK_DoIntersect_RayPoint(ray, point);
        }

        public static bool DoIntersect(Ray2d ray, Line2d line)
        {
            return Intersections_EEK_DoIntersect_RayLine(ray, line);
        }

        public static bool DoIntersect(Ray2d ray, Ray2d ray2)
        {
            return Intersections_EEK_DoIntersect_RayRay(ray, ray2);
        }

        public static bool DoIntersect(Ray2d ray, Segment2d segment)
        {
            return Intersections_EEK_DoIntersect_RaySegment(ray, segment);
        }

        public static bool DoIntersect(Ray2d ray, Triangle2d triangle)
        {
            return Intersections_EEK_DoIntersect_RayTriangle(ray, triangle);
        }

        public static bool DoIntersect(Ray2d ray, Box2d box)
        {
            return Intersections_EEK_DoIntersect_RayBox(ray, box);
        }

        //segment

        public static bool DoIntersect(Segment2d segment, Point2d point)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Segment2d segment, Line2d line)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Segment2d segment, Ray2d ray)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Segment2d segment, Segment2d segment2)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Segment2d segment, Triangle2d triangle)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Segment2d segment, Box2d box)
        {
            throw new NotImplementedException();
        }

        //triangle

        public static bool DoIntersect(Triangle2d triangle, Point2d point)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Triangle2d triangle, Line2d line)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Triangle2d triangle, Ray2d ray)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Triangle2d triangle, Segment2d segment2)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Triangle2d triangle, Triangle2d triangle2)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Triangle2d triangle, Box2d box)
        {
            throw new NotImplementedException();
        }

        //box

        public static bool DoIntersect(Box2d box, Point2d point)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Box2d box, Line2d line)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Box2d box, Ray2d ray)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Box2d box, Segment2d segment2)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Box2d box, Triangle2d triangle2)
        {
            throw new NotImplementedException();
        }

        public static bool DoIntersect(Box2d box, Box2d box2)
        {
            throw new NotImplementedException();
        }

        //Intersections

        //point 

        public static IntersectionResult2d Intersection(Point2d point, Line2d line)
        {
            return Intersections_EEK_Intersection_PointLine(point, line);
        }

        public static IntersectionResult2d Intersection(Point2d point, Ray2d ray)
        {
            return Intersections_EEK_Intersection_PointRay(point, ray);
        }

        public static IntersectionResult2d Intersection(Point2d point, Segment2d segment)
        {
            return Intersections_EEK_Intersection_PointSegment(point, segment);
        }

        public static IntersectionResult2d Intersection(Point2d point, Triangle2d triangle)
        {
            return Intersections_EEK_Intersection_PointTriangle(point, triangle);
        }

        public static IntersectionResult2d Intersection(Point2d point, Box2d box)
        {
            return Intersections_EEK_Intersection_PointBox(point, box);
        }

        //line

        public static IntersectionResult2d Intersection(Line2d line, Point2d point)
        {
            return Intersections_EEK_Intersection_LinePoint(line, point);
        }

        public static IntersectionResult2d Intersection(Line2d line, Line2d line2)
        {
            return Intersections_EEK_Intersection_LineLine(line, line2);
        }

        public static IntersectionResult2d Intersection(Line2d line, Ray2d ray)
        {
            return Intersections_EEK_Intersection_LineRay(line, ray);
        }

        public static IntersectionResult2d Intersection(Line2d line, Segment2d segment)
        {
            return Intersections_EEK_Intersection_LineSegment(line, segment);
        }

        public static IntersectionResult2d Intersection(Line2d line, Triangle2d triangle)
        {
            return Intersections_EEK_Intersection_LineTriangle(line, triangle);
        }

        public static IntersectionResult2d Intersection(Line2d line, Box2d box)
        {
            return Intersections_EEK_Intersection_LineBox(line, box);
        }

        //ray

        public static IntersectionResult2d Intersection(Ray2d ray, Point2d point)
        {
            return Intersections_EEK_Intersection_RayPoint(ray, point);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Line2d line)
        {
            return Intersections_EEK_Intersection_RayLine(ray, line);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Ray2d ray2)
        {
            return Intersections_EEK_Intersection_RayRay(ray, ray2);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Segment2d segment)
        {
            return Intersections_EEK_Intersection_RaySegment(ray, segment);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Triangle2d triangle)
        {
            return Intersections_EEK_Intersection_RayTriangle(ray, triangle);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Box2d box)
        {
            return Intersections_EEK_Intersection_RayBox(ray, box);
        }

        //segment

        public static IntersectionResult2d Intersection(Segment2d segment, Point2d point)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Line2d line)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Ray2d ray)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Segment2d segment2)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Triangle2d triangle)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Box2d box)
        {
            throw new NotImplementedException();
        }

        //triangle

        public static IntersectionResult2d Intersection(Triangle2d triangle, Point2d point)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Line2d line)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Ray2d ray)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Segment2d segment2)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Triangle2d triangle2)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Box2d box)
        {
            throw new NotImplementedException();
        }

        //box

        public static IntersectionResult2d Intersection(Box2d box, Point2d point)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Box2d box, Line2d line)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Box2d box, Ray2d ray)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Box2d box, Segment2d segment2)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Box2d box, Triangle2d triangle2)
        {
            throw new NotImplementedException();
        }

        public static IntersectionResult2d Intersection(Box2d box, Box2d box2)
        {
            throw new NotImplementedException();
        }

        //point

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_PointLine(Point2d point, Line2d line);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_PointRay(Point2d point, Ray2d ray);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_PointSegment(Point2d point, Segment2d segment);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_PointTriangle(Point2d point, Triangle2d triangle);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_PointBox(Point2d point, Box2d box);

        //line

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_LinePoint(Line2d line, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_LineLine(Line2d line, Line2d line2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_LineRay(Line2d line, Ray2d ray);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_LineSegment(Line2d line, Segment2d segment);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_LineTriangle(Line2d line, Triangle2d triangle);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_LineBox(Line2d line, Box2d box);

        //ray

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_RayPoint(Ray2d ray, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_RayLine(Ray2d ray, Line2d line);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_RayRay(Ray2d ray, Ray2d ray2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_RaySegment(Ray2d ray, Segment2d segment);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_RayTriangle(Ray2d ray, Triangle2d triangle);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Intersections_EEK_DoIntersect_RayBox(Ray2d ray, Box2d box);


        //point

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointLine(Point2d point, Line2d line);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointRay(Point2d point, Ray2d ray);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointSegment(Point2d point, Segment2d segment);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointTriangle(Point2d point, Triangle2d triangle);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointBox(Point2d point, Box2d box);

        //line

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LinePoint(Line2d line, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineLine(Line2d line, Line2d line2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineRay(Line2d line, Ray2d ray);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineSegment(Line2d line, Segment2d segment);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineTriangle(Line2d line, Triangle2d triangle);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineBox(Line2d line, Box2d box);

        //ray

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayPoint(Ray2d ray, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayLine(Ray2d ray, Line2d line);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayRay(Ray2d ray, Ray2d ray2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RaySegment(Ray2d ray, Segment2d segment);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayTriangle(Ray2d ray, Triangle2d triangle);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayBox(Ray2d ray, Box2d box);
    }
}
