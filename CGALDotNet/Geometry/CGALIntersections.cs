using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using CGALDotNet.Polygons;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// Enum for the type of intersection geomerty.
    /// </summary>
    public enum INTERSECTION_RESULT_2D
    {
        NONE, 
        POINT2,
        LINE2,
        RAY2,
        SEGMENT2,
        BOX2,
        TRIANGLE2,
        POLYGON2
    }

    /// <summary>
    /// The intersection result struct.
    /// May contain up tp 6 points of data.
    /// </summary>
    public unsafe struct IntersectionResult2d
    {
        /// <summary>
        /// The point data for the intersection.
        /// Represents up to 6 points in xy order.
        /// </summary>
        private fixed double Data[12];

        /// <summary>
        /// The number of points of data used.
        /// </summary>
        private int Count;

        /// <summary>
        /// Was there a intersection.
        /// </summary>
        public bool Hit => Type != INTERSECTION_RESULT_2D.NONE;

        /// <summary>
        /// Is the intersection a polygon.
        /// </summary>
        public bool IsPolygon => Type == INTERSECTION_RESULT_2D.POLYGON2;

        /// <summary>
        /// The intersection geometry type.
        /// </summary>
        public INTERSECTION_RESULT_2D Type;

        /// <summary>
        /// Array accessor for the point data.
        /// </summary>
        /// <param name="i">The array index from 0 to 6.</param>
        /// <returns>The point at index i.</returns>
        public Point2d this[int i]
        {
            get
            {
                if ((uint)i >= 6)
                    throw new IndexOutOfRangeException("IntersectionResult2d index out of range.");

                fixed (IntersectionResult2d* array = &this) { return ((Point2d*)array)[i]; }
            }
        }

        /// <summary>
        /// Results information as string.
        /// </summary>
        /// <returns>esults information as string</returns>
        public override string ToString()
        {
            return string.Format("[IntersectionResult2d: Type={0}, Count={1}]", Type, Count);
        }

        /// <summary>
        /// If result type was point get the point geometry.
        /// </summary>
        public Point2d Point => this[0];

        /// <summary>
        /// If result type was line get the line geometry.
        /// </summary>
        public Line2d Line => new Line2d(Data[0], Data[1], Data[2]);

        /// <summary>
        /// If result type was ray get the ray geometry.
        /// </summary>
        public Ray2d Ray => new Ray2d(this[0], this[1].Vector2d);

        /// <summary>
        /// If result type was segment get the segment geometry.
        /// </summary>
        public Segment2d Segment => new Segment2d(this[0], this[1]);

        /// <summary>
        /// If result type was box get the box geometry.
        /// </summary>
        public Box2d Box => new Box2d(this[0], this[1]);

        /// <summary>
        /// If result type was triangle get the triangle geometry.
        /// </summary>
        public Triangle2d Triangle => new Triangle2d(this[0], this[1], this[2]);

        /// <summary>
        /// If result type was polygon get the points that
        /// make up the polygon geometry.
        /// Should only ever have at most 6 points.
        /// </summary>
        public Point2d[] PolygonPoints
        {
            get
            {
                if (Count > 6)
                    throw new Exception("Unexpected number of polygon points.");

                if (!IsPolygon)
                    throw new Exception("Intersection not a polygon.");

                var points = new Point2d[Count];
                for (int i = 0; i < Count; i++)
                    points[i] = this[i];

                return points;
            }
        }

        /// <summary>
        /// The intersection result as a polygon.
        /// </summary>
        /// <typeparam name="K">The polygons kernel.</typeparam>
        /// <returns>The polygon.</returns>
        public Polygon2<K> Polygon<K>() where K : CGALKernel, new()
        {
            return new Polygon2<K>(PolygonPoints);
        }
        
    }

    
    /// <summary>
    /// The static intersection class.
    /// </summary>
    public static class CGALIntersections
    {
        private const string DLL_NAME = "CGALWrapper.dll";

        private const CallingConvention CDECL = CallingConvention.Cdecl;

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

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

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

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

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

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

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Segment2d segment, Point2d point)
        {
            return Intersections_EEK_DoIntersect_SegmentPoint(segment, point);
        }

        public static bool DoIntersect(Segment2d segment, Line2d line)
        {
            return Intersections_EEK_DoIntersect_SegmentLine(segment, line);
        }

        public static bool DoIntersect(Segment2d segment, Ray2d ray)
        {
            return Intersections_EEK_DoIntersect_SegmentRay(segment, ray);
        }

        public static bool DoIntersect(Segment2d segment, Segment2d segment2)
        {
            return Intersections_EEK_DoIntersect_SegmentSegment(segment, segment2);
        }

        public static bool DoIntersect(Segment2d segment, Triangle2d triangle)
        {
            return Intersections_EEK_DoIntersect_SegmentTriangle(segment, triangle);
        }

        public static bool DoIntersect(Segment2d segment, Box2d box)
        {
            return Intersections_EEK_DoIntersect_SegmentBox(segment, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Triangle2d triangle, Point2d point)
        {
            return Intersections_EEK_DoIntersect_TrianglePoint(triangle, point);
        }

        public static bool DoIntersect(Triangle2d triangle, Line2d line)
        {
            return Intersections_EEK_DoIntersect_TriangleLine(triangle, line);
        }

        public static bool DoIntersect(Triangle2d triangle, Ray2d ray)
        {
            return Intersections_EEK_DoIntersect_TriangleRay(triangle, ray);
        }

        public static bool DoIntersect(Triangle2d triangle, Segment2d segment)
        {
            return Intersections_EEK_DoIntersect_TriangleSegment(triangle, segment);
        }

        public static bool DoIntersect(Triangle2d triangle, Triangle2d triangle2)
        {
            return Intersections_EEK_DoIntersect_TriangleTriangle(triangle, triangle2);
        }

        public static bool DoIntersect(Triangle2d triangle, Box2d box)
        {
            return Intersections_EEK_DoIntersect_TriangleBox(triangle, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Box2d box, Point2d point)
        {
            return Intersections_EEK_DoIntersect_BoxPoint(box, point);
        }

        public static bool DoIntersect(Box2d box, Line2d line)
        {
            return Intersections_EEK_DoIntersect_BoxLine(box, line);
        }

        public static bool DoIntersect(Box2d box, Ray2d ray)
        {
            return Intersections_EEK_DoIntersect_BoxRay(box, ray);
        }

        public static bool DoIntersect(Box2d box, Segment2d segment)
        {
            return Intersections_EEK_DoIntersect_BoxSegment(box, segment);
        }

        public static bool DoIntersect(Box2d box, Triangle2d triangle)
        {
            return Intersections_EEK_DoIntersect_BoxTriangle(box, triangle);
        }

        public static bool DoIntersect(Box2d box, Box2d boxd)
        {
            return Intersections_EEK_DoIntersect_BoxBox(box, boxd);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point Intersection functions
        /// 
        /// </summary>--------------------------------------------------------

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

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

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

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

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

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Segment2d segment, Point2d point)
        {
            return Intersections_EEK_Intersection_SegmentPoint(segment, point);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Line2d line)
        {
            return Intersections_EEK_Intersection_SegmentLine(segment, line);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Ray2d ray)
        {
            return Intersections_EEK_Intersection_SegmentRay(segment, ray);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Segment2d segment2)
        {
            return Intersections_EEK_Intersection_SegmentSegment(segment, segment2);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Triangle2d triangle)
        {
            return Intersections_EEK_Intersection_SegmentTriangle(segment, triangle);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Box2d box)
        {
            return Intersections_EEK_Intersection_SegmentBox(segment, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Triangle2d triangle, Point2d point)
        {
            return Intersections_EEK_Intersection_TrianglePoint(triangle, point);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Line2d line)
        {
            return Intersections_EEK_Intersection_TriangleLine(triangle, line);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Ray2d ray)
        {
            return Intersections_EEK_Intersection_TriangleRay(triangle, ray);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Segment2d segment)
        {
            return Intersections_EEK_Intersection_TriangleSegment(triangle, segment);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Triangle2d triangle2)
        {
            return Intersections_EEK_Intersection_TriangleTriangle(triangle, triangle2);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Box2d box)
        {
            return Intersections_EEK_Intersection_TriangleBox(triangle, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Box2d box, Point2d point)
        {
            return Intersections_EEK_Intersection_BoxPoint(box, point);
        }

        public static IntersectionResult2d Intersection(Box2d box, Line2d line)
        {
            return Intersections_EEK_Intersection_BoxLine(box, line);
        }

        public static IntersectionResult2d Intersection(Box2d box, Ray2d ray)
        {
            return Intersections_EEK_Intersection_BoxRay(box, ray);
        }

        public static IntersectionResult2d Intersection(Box2d box, Segment2d segment)
        {
            return Intersections_EEK_Intersection_BoxSegment(box, segment);
        }

        public static IntersectionResult2d Intersection(Box2d box, Triangle2d triangle)
        {
            return Intersections_EEK_Intersection_BoxTriangle(box, triangle);
        }

        public static IntersectionResult2d Intersection(Box2d box, Box2d boxd)
        {
            return Intersections_EEK_Intersection_BoxBox(box, boxd);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_PointLine(Point2d point, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_PointRay(Point2d point, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_PointSegment(Point2d point, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_PointTriangle(Point2d point, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_PointBox(Point2d point, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Linet DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_LinePoint(Line2d line, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_LineLine(Line2d line, Line2d line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_LineRay(Line2d line, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_LineSegment(Line2d line, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_LineTriangle(Line2d line, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_LineBox(Line2d line, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_RayPoint(Ray2d ray, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_RayLine(Ray2d ray, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_RayRay(Ray2d ray, Ray2d ray2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_RaySegment(Ray2d ray, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_RayTriangle(Ray2d ray, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_RayBox(Ray2d ray, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_SegmentPoint(Segment2d segment, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_SegmentLine(Segment2d segment, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_SegmentRay(Segment2d segment, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_SegmentSegment(Segment2d segment, Segment2d segment2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_SegmentTriangle(Segment2d segment, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_SegmentBox(Segment2d segment, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_TrianglePoint(Triangle2d triangle, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_TriangleLine(Triangle2d triangle, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_TriangleRay(Triangle2d triangle, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_TriangleSegment(Triangle2d triangle, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_TriangleBox(Triangle2d triangle, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_BoxPoint(Box2d box, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_BoxLine(Box2d box, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_BoxRay(Box2d box, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_BoxSegment(Box2d box, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_BoxTriangle(Box2d box, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_EEK_DoIntersect_BoxBox(Box2d box, Box2d box2);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointLine(Point2d point, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointRay(Point2d point, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointSegment(Point2d point, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointTriangle(Point2d point, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_PointBox(Point2d point, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LinePoint(Line2d line, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineLine(Line2d line, Line2d line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineRay(Line2d line, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineSegment(Line2d line, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineTriangle(Line2d line, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_LineBox(Line2d line, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayPoint(Ray2d ray, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayLine(Ray2d ray, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayRay(Ray2d ray, Ray2d ray2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RaySegment(Ray2d ray, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayTriangle(Ray2d ray, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_RayBox(Ray2d ray, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_SegmentPoint(Segment2d segment, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_SegmentLine(Segment2d segment, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_SegmentRay(Segment2d segment, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_SegmentSegment(Segment2d segment, Segment2d segment2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_SegmentTriangle(Segment2d segment, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_SegmentBox(Segment2d segment, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_TrianglePoint(Triangle2d triangle, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_TriangleLine(Triangle2d triangle, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_TriangleRay(Triangle2d triangle, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_TriangleSegment(Triangle2d triangle, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_TriangleBox(Triangle2d triangle, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_BoxPoint(Box2d box, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_BoxLine(Box2d box, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_BoxRay(Box2d box, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_BoxSegment(Box2d box, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_BoxTriangle(Box2d box, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_EEK_Intersection_BoxBox(Box2d box, Box2d box2);
    }
}
