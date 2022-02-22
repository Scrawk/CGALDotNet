using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    /// <summary>
    /// The static intersection class.
    /// </summary>
    public static partial class CGALIntersections
    {

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Point2<EEK> point, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_DoIntersect_PointLine(point.Ptr, line.Ptr);
        }

        public static bool DoIntersect(Point2<EEK> point, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_DoIntersect_PointRay(point.Ptr, ray.Ptr);
        }

        public static bool DoIntersect(Point2<EEK> point, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_DoIntersect_PointSegment(point.Ptr, segment.Ptr);
        }

        public static bool DoIntersect(Point2<EEK> point, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_DoIntersect_PointTriangle(point.Ptr, triangle.Ptr);
        }

        public static bool DoIntersect(Point2<EEK> point, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_DoIntersect_PointBox(point.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Line2<EEK> line, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_DoIntersect_LinePoint(line.Ptr, point.Ptr);
        }

        public static bool DoIntersect(Line2<EEK> line, Line2<EEK> line2)
        {
            return Intersections_Geometry_EEK_DoIntersect_LineLine(line.Ptr, line2.Ptr);
        }

        public static bool DoIntersect(Line2<EEK> line, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_DoIntersect_LineRay(line.Ptr, ray.Ptr);
        }

        public static bool DoIntersect(Line2<EEK> line, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_DoIntersect_LineSegment(line.Ptr, segment.Ptr);
        }

        public static bool DoIntersect(Line2<EEK> line, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_DoIntersect_LineTriangle(line.Ptr, triangle.Ptr);
        }

        public static bool DoIntersect(Line2<EEK> line, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_DoIntersect_LineBox(line.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Ray2<EEK> ray, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_DoIntersect_RayPoint(ray.Ptr, point.Ptr);
        }

        public static bool DoIntersect(Ray2<EEK> ray, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_DoIntersect_RayLine(ray.Ptr, line.Ptr);
        }

        public static bool DoIntersect(Ray2<EEK> ray, Ray2<EEK> ray2)
        {
            return Intersections_Geometry_EEK_DoIntersect_RayRay(ray.Ptr, ray2.Ptr);
        }

        public static bool DoIntersect(Ray2<EEK> ray, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_DoIntersect_RaySegment(ray.Ptr, segment.Ptr);
        }

        public static bool DoIntersect(Ray2<EEK> ray, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_DoIntersect_RayTriangle(ray.Ptr, triangle.Ptr);
        }

        public static bool DoIntersect(Ray2<EEK> ray, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_DoIntersect_RayBox(ray.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Segment2<EEK> segment, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_DoIntersect_SegmentPoint(segment.Ptr, point.Ptr);
        }

        public static bool DoIntersect(Segment2<EEK> segment, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_DoIntersect_SegmentLine(segment.Ptr, line.Ptr);
        }

        public static bool DoIntersect(Segment2<EEK> segment, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_DoIntersect_SegmentRay(segment.Ptr, ray.Ptr);
        }

        public static bool DoIntersect(Segment2<EEK> segment, Segment2<EEK> segment2)
        {
            return Intersections_Geometry_EEK_DoIntersect_SegmentSegment(segment.Ptr, segment2.Ptr);
        }

        public static bool DoIntersect(Segment2<EEK> segment, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_DoIntersect_SegmentTriangle(segment.Ptr, triangle.Ptr);
        }

        public static bool DoIntersect(Segment2<EEK> segment, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_DoIntersect_SegmentBox(segment.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Triangle2<EEK> triangle, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_DoIntersect_TrianglePoint(triangle.Ptr, point.Ptr);
        }

        public static bool DoIntersect(Triangle2<EEK> triangle, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_DoIntersect_TriangleLine(triangle.Ptr, line.Ptr);
        }

        public static bool DoIntersect(Triangle2<EEK> triangle, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_DoIntersect_TriangleRay(triangle.Ptr, ray.Ptr);
        }

        public static bool DoIntersect(Triangle2<EEK> triangle, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_DoIntersect_TriangleSegment(triangle.Ptr, segment.Ptr);
        }

        public static bool DoIntersect(Triangle2<EEK> triangle, Triangle2<EEK> triangle2)
        {
            return Intersections_Geometry_EEK_DoIntersect_TriangleTriangle(triangle.Ptr, triangle2.Ptr);
        }

        public static bool DoIntersect(Triangle2<EEK> triangle, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_DoIntersect_TriangleBox(triangle.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Box2<EEK> box, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_DoIntersect_BoxPoint(box.Ptr, point.Ptr);
        }

        public static bool DoIntersect(Box2<EEK> box, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_DoIntersect_BoxLine(box.Ptr, line.Ptr);
        }

        public static bool DoIntersect(Box2<EEK> box, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_DoIntersect_BoxRay(box.Ptr, ray.Ptr);
        }

        public static bool DoIntersect(Box2<EEK> box, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_DoIntersect_BoxSegment(box.Ptr, segment.Ptr);
        }

        public static bool DoIntersect(Box2<EEK> box, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_DoIntersect_BoxTriangle(box.Ptr, triangle.Ptr);
        }

        public static bool DoIntersect(Box2<EEK> box, Box2<EEK> box2)
        {
            return Intersections_Geometry_EEK_DoIntersect_BoxBox(box.Ptr, box2.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point Intersection functions
        /// 
        /// </summary>--------------------------------------------------------

        public static IntersectionResult2d Intersection(Point2<EEK> point, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_Intersection_PointLine(point.Ptr, line.Ptr);
        }

        public static IntersectionResult2d Intersection(Point2<EEK> point, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_Intersection_PointRay(point.Ptr, ray.Ptr);
        }

        public static IntersectionResult2d Intersection(Point2<EEK> point, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_Intersection_PointSegment(point.Ptr, segment.Ptr);
        }

        public static IntersectionResult2d Intersection(Point2<EEK> point, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_Intersection_PointTriangle(point.Ptr, triangle.Ptr);
        }

        public static IntersectionResult2d Intersection(Point2<EEK> point, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_Intersection_PointBox(point.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Line2<EEK> line, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_Intersection_LinePoint(line.Ptr, point.Ptr);
        }

        public static IntersectionResult2d Intersection(Line2<EEK> line, Line2<EEK> line2)
        {
            return Intersections_Geometry_EEK_Intersection_LineLine(line.Ptr, line2.Ptr);
        }

        public static IntersectionResult2d Intersection(Line2<EEK> line, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_Intersection_LineRay(line.Ptr, ray.Ptr);
        }

        public static IntersectionResult2d Intersection(Line2<EEK> line, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_Intersection_LineSegment(line.Ptr, segment.Ptr);
        }

        public static IntersectionResult2d Intersection(Line2<EEK> line, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_Intersection_LineTriangle(line.Ptr, triangle.Ptr);
        }

        public static IntersectionResult2d Intersection(Line2<EEK> line, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_Intersection_LineBox(line.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Ray2<EEK> ray, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_Intersection_RayPoint(ray.Ptr, point.Ptr);
        }

        public static IntersectionResult2d Intersection(Ray2<EEK> ray, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_Intersection_RayLine(ray.Ptr, line.Ptr);
        }

        public static IntersectionResult2d Intersection(Ray2<EEK> ray, Ray2<EEK> ray2)
        {
            return Intersections_Geometry_EEK_Intersection_RayRay(ray.Ptr, ray2.Ptr);
        }

        public static IntersectionResult2d Intersection(Ray2<EEK> ray, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_Intersection_RaySegment(ray.Ptr, segment.Ptr);
        }

        public static IntersectionResult2d Intersection(Ray2<EEK> ray, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_Intersection_RayTriangle(ray.Ptr, triangle.Ptr);
        }

        public static IntersectionResult2d Intersection(Ray2<EEK> ray, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_Intersection_RayBox(ray.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Segment2<EEK> segment, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_Intersection_SegmentPoint(segment.Ptr, point.Ptr);
        }

        public static IntersectionResult2d Intersection(Segment2<EEK> segment, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_Intersection_SegmentLine(segment.Ptr, line.Ptr);
        }

        public static IntersectionResult2d Intersection(Segment2<EEK> segment, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_Intersection_SegmentRay(segment.Ptr, ray.Ptr);
        }

        public static IntersectionResult2d Intersection(Segment2<EEK> segment, Segment2<EEK> segment2)
        {
            return Intersections_Geometry_EEK_Intersection_SegmentSegment(segment.Ptr, segment2.Ptr);
        }

        public static IntersectionResult2d Intersection(Segment2<EEK> segment, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_Intersection_SegmentTriangle(segment.Ptr, triangle.Ptr);
        }

        public static IntersectionResult2d Intersection(Segment2<EEK> segment, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_Intersection_SegmentBox(segment.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Triangle2<EEK> triangle, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_Intersection_TrianglePoint(triangle.Ptr, point.Ptr);
        }

        public static IntersectionResult2d Intersection(Triangle2<EEK> triangle, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_Intersection_TriangleLine(triangle.Ptr, line.Ptr);
        }

        public static IntersectionResult2d Intersection(Triangle2<EEK> triangle, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_Intersection_TriangleRay(triangle.Ptr, ray.Ptr);
        }

        public static IntersectionResult2d Intersection(Triangle2<EEK> triangle, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_Intersection_TriangleSegment(triangle.Ptr, segment.Ptr);
        }

        public static IntersectionResult2d Intersection(Triangle2<EEK> triangle, Triangle2<EEK> triangle2)
        {
            return Intersections_Geometry_EEK_Intersection_TriangleTriangle(triangle.Ptr, triangle2.Ptr);
        }

        public static IntersectionResult2d Intersection(Triangle2<EEK> triangle, Box2<EEK> box)
        {
            return Intersections_Geometry_EEK_Intersection_TriangleBox(triangle.Ptr, box.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Box2<EEK> box, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_Intersection_BoxPoint(box.Ptr, point.Ptr);
        }

        public static IntersectionResult2d Intersection(Box2<EEK> box, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_Intersection_BoxLine(box.Ptr, line.Ptr);
        }

        public static IntersectionResult2d Intersection(Box2<EEK> box, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_Intersection_BoxRay(box.Ptr, ray.Ptr);
        }

        public static IntersectionResult2d Intersection(Box2<EEK> box, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_Intersection_BoxSegment(box.Ptr, segment.Ptr);
        }

        public static IntersectionResult2d Intersection(Box2<EEK> box, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_Intersection_BoxTriangle(box.Ptr, triangle.Ptr);
        }

        public static IntersectionResult2d Intersection(Box2<EEK> box, Box2<EEK> box2)
        {
            return Intersections_Geometry_EEK_Intersection_BoxBox(box.Ptr, box2.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///              The Point SqrDistance functions
        /// 
        /// </summary>-----------------------------------------------------

        public static double SqrDistance(Point2<EEK> point, Point2<EEK> point2)
        {
            return Intersections_Geometry_EEK_SqrDistance_PointPoint(point.Ptr, point2.Ptr);
        }

        public static double SqrDistance(Point2<EEK> point, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_SqrDistance_PointLine(point.Ptr, line.Ptr);
        }

        public static double SqrDistance(Point2<EEK> point, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_SqrDistance_PointRay(point.Ptr, ray.Ptr);
        }

        public static double SqrDistance(Point2<EEK> point, Segment2<EEK> seg)
        {
            return Intersections_Geometry_EEK_SqrDistance_PointSegment(point.Ptr, seg.Ptr);
        }

        public static double SqrDistance(Point2<EEK> point, Triangle2<EEK> tri)
        {
            return Intersections_Geometry_EEK_SqrDistance_PointTriangle(point.Ptr, tri.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line SqrDistance functions
        /// 
        /// </summary>--------------------------------------------------------

        public static double SqrDistance(Line2<EEK> line, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_SqrDistance_LinePoint(line.Ptr, point.Ptr);
        }

        public static double SqrDistance(Line2<EEK> line, Line2<EEK> line2)
        {
            return Intersections_Geometry_EEK_SqrDistance_LineLine(line.Ptr, line2.Ptr);
        }

        public static double SqrDistance(Line2<EEK> line, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_SqrDistance_LineRay(line.Ptr, ray.Ptr);
        }

        public static double SqrDistance(Line2<EEK> line, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_SqrDistance_LineSegment(line.Ptr, segment.Ptr);
        }

        public static double SqrDistance(Line2<EEK> line, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_SqrDistance_LineTriangle(line.Ptr, triangle.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray SqrDistance functions
        /// 
        /// </summary>--------------------------------------------------------

        public static double SqrDistance(Ray2<EEK> ray, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_SqrDistance_RayPoint(ray.Ptr, point.Ptr);
        }

        public static double SqrDistance(Ray2<EEK> ray, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_SqrDistance_RayLine(ray.Ptr, line.Ptr);
        }

        public static double SqrDistance(Ray2<EEK> ray, Ray2<EEK> ray2)
        {
            return Intersections_Geometry_EEK_SqrDistance_RayRay(ray.Ptr, ray2.Ptr);
        }

        public static double SqrDistance(Ray2<EEK> ray, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_SqrDistance_RaySegment(ray.Ptr, segment.Ptr);
        }

        public static double SqrDistance(Ray2<EEK> ray, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_SqrDistance_RayTriangle(ray.Ptr, triangle.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment SqrDistance functions
        /// 
        /// </summary>-----------------------------------------------------

        public static double SqrDistance(Segment2<EEK> segment, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_SqrDistance_SegmentPoint(segment.Ptr, point.Ptr);
        }

        public static double SqrDistance(Segment2<EEK> segment, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_SqrDistance_SegmentLine(segment.Ptr, line.Ptr);
        }

        public static double SqrDistance(Segment2<EEK> segment, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_SqrDistance_SegmentRay(segment.Ptr, ray.Ptr);
        }

        public static double SqrDistance(Segment2<EEK> segment, Segment2<EEK> segment2)
        {
            return Intersections_Geometry_EEK_SqrDistance_SegmentSegment(segment.Ptr, segment2.Ptr);
        }

        public static double SqrDistance(Segment2<EEK> segment, Triangle2<EEK> triangle)
        {
            return Intersections_Geometry_EEK_SqrDistance_SegmentTriangle(segment.Ptr, triangle.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle SqrDistance functions
        /// 
        /// </summary>-----------------------------------------------------

        public static double SqrDistance(Triangle2<EEK> triangle, Point2<EEK> point)
        {
            return Intersections_Geometry_EEK_SqrDistance_TrianglePoint(triangle.Ptr, point.Ptr);
        }

        public static double SqrDistance(Triangle2<EEK> triangle, Line2<EEK> line)
        {
            return Intersections_Geometry_EEK_SqrDistance_TriangleLine(triangle.Ptr, line.Ptr);
        }

        public static double SqrDistance(Triangle2<EEK> triangle, Ray2<EEK> ray)
        {
            return Intersections_Geometry_EEK_SqrDistance_TriangleRay(triangle.Ptr, ray.Ptr);
        }

        public static double SqrDistance(Triangle2<EEK> triangle, Segment2<EEK> segment)
        {
            return Intersections_Geometry_EEK_SqrDistance_TriangleSegment(triangle.Ptr, segment.Ptr);
        }

        public static double SqrDistance(Triangle2<EEK> triangle, Triangle2<EEK> triangle2)
        {
            return Intersections_Geometry_EEK_SqrDistance_TriangleTriangle(triangle.Ptr, triangle2.Ptr);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_PointLine(IntPtr point, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_PointRay(IntPtr point, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_PointSegment(IntPtr point, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_PointTriangle(IntPtr point, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_PointBox(IntPtr point, IntPtr box);


        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Linet DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_LinePoint(IntPtr line, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_LineLine(IntPtr line, IntPtr line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_LineRay(IntPtr line, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_LineSegment(IntPtr line, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_LineTriangle(IntPtr line, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_LineBox(IntPtr line, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_RayPoint(IntPtr ray, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_RayLine(IntPtr ray, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_RayRay(IntPtr ray, IntPtr ray2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_RaySegment(IntPtr ray, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_RayTriangle(IntPtr ray, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_RayBox(IntPtr ray, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_SegmentPoint(IntPtr segment, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_SegmentLine(IntPtr segment, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_SegmentRay(IntPtr segment, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_SegmentSegment(IntPtr segment, IntPtr segment2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_SegmentTriangle(IntPtr segment, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_SegmentBox(IntPtr segment, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_TrianglePoint(IntPtr triangle, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_TriangleLine(IntPtr triangle, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_TriangleRay(IntPtr triangle, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_TriangleSegment(IntPtr triangle, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_TriangleTriangle(IntPtr triangle, IntPtr triangle2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_TriangleBox(IntPtr triangle, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_BoxPoint(IntPtr box, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_BoxLine(IntPtr box, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_BoxRay(IntPtr box, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_BoxSegment(IntPtr box, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_BoxTriangle(IntPtr box, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Geometry_EEK_DoIntersect_BoxBox(IntPtr box, IntPtr box2);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointLine(IntPtr point, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointRay(IntPtr point, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointSegment(IntPtr point, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointTriangle(IntPtr point, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_PointBox(IntPtr point, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_LinePoint(IntPtr line, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineLine(IntPtr line, IntPtr line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineRay(IntPtr line, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineSegment(IntPtr line, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineTriangle(IntPtr line, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_LineBox(IntPtr line, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayPoint(IntPtr ray, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayLine(IntPtr ray, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayRay(IntPtr ray, IntPtr ray2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_RaySegment(IntPtr ray, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayTriangle(IntPtr ray, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_RayBox(IntPtr ray, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentPoint(IntPtr segment, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentLine(IntPtr segment, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentRay(IntPtr segment, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentSegment(IntPtr segment, IntPtr segment2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentTriangle(IntPtr segment, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_SegmentBox(IntPtr segment, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_TrianglePoint(IntPtr triangle, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleLine(IntPtr triangle, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleRay(IntPtr triangle, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleSegment(IntPtr triangle, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleTriangle(IntPtr triangle, IntPtr triangle2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_TriangleBox(IntPtr triangle, IntPtr box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxPoint(IntPtr box, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxLine(IntPtr box, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxRay(IntPtr box, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxSegment(IntPtr box, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxTriangle(IntPtr box, IntPtr triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Geometry_EEK_Intersection_BoxBox(IntPtr box, IntPtr box2);

        /// <summary>--------------------------------------------------------
        /// 
        ///               The Point SqrDistance extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_PointPoint(IntPtr point, IntPtr point2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_PointLine(IntPtr point, IntPtr line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_PointRay(IntPtr point, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_PointSegment(IntPtr point, IntPtr seg);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_PointTriangle(IntPtr point, IntPtr tri);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line SqrDistance extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_LinePoint(IntPtr line, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_LineLine(IntPtr line, IntPtr line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_LineRay(IntPtr line, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_LineSegment(IntPtr line, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_LineTriangle(IntPtr line, IntPtr triangle);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray SqrDistance extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_RayPoint(IntPtr ray, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_RayLine(IntPtr ray, IntPtr line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_RayRay(IntPtr ray, IntPtr ray2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_RaySegment(IntPtr ray, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_RayTriangle(IntPtr ray, IntPtr triangle);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment SqrDistance extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_SegmentPoint(IntPtr segment, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_SegmentLine(IntPtr segment, IntPtr line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_SegmentRay(IntPtr segment, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_SegmentSegment(IntPtr segment, IntPtr segment2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_SegmentTriangle(IntPtr segment, IntPtr triangle);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle SqrDistance extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_TrianglePoint(IntPtr triangle, IntPtr point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_TriangleLine(IntPtr triangle, IntPtr line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_TriangleRay(IntPtr triangle, IntPtr ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_TriangleSegment(IntPtr triangle, IntPtr segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Geometry_EEK_SqrDistance_TriangleTriangle(IntPtr triangle, IntPtr triangle2);

    }
}
