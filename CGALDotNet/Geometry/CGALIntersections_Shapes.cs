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
    /// The static intersection class.
    /// </summary>
    public static partial class CGALIntersections
    {
        public const string DLL_NAME = "CGALWrapper.dll";

        public const CallingConvention CDECL = CallingConvention.Cdecl;

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Point2d point, Line2d line)
        {
            return Intersections_Shapes_EIK_DoIntersect_PointLine(point, line);
        }

        public static bool DoIntersect(Point2d point, Ray2d ray)
        {
            return Intersections_Shapes_EIK_DoIntersect_PointRay(point, ray);
        }

        public static bool DoIntersect(Point2d point, Segment2d segment)
        {
            return Intersections_Shapes_EIK_DoIntersect_PointSegment(point, segment);
        }

        public static bool DoIntersect(Point2d point, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_DoIntersect_PointTriangle(point, triangle);
        }

        public static bool DoIntersect(Point2d point, Box2d box)
        {
            return Intersections_Shapes_EIK_DoIntersect_PointBox(point, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Line2d line, Point2d point)
        {
            return Intersections_Shapes_EIK_DoIntersect_LinePoint(line, point);
        }

        public static bool DoIntersect(Line2d line, Line2d line2)
        {
            return Intersections_Shapes_EIK_DoIntersect_LineLine(line, line2);
        }

        public static bool DoIntersect(Line2d line, Ray2d ray)
        {
            return Intersections_Shapes_EIK_DoIntersect_LineRay(line, ray);
        }

        public static bool DoIntersect(Line2d line, Segment2d segment)
        {
            return Intersections_Shapes_EIK_DoIntersect_LineSegment(line, segment);
        }

        public static bool DoIntersect(Line2d line, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_DoIntersect_LineTriangle(line, triangle);
        }

        public static bool DoIntersect(Line2d line, Box2d box)
        {
            return Intersections_Shapes_EIK_DoIntersect_LineBox(line, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Ray2d ray, Point2d point)
        {
            return Intersections_Shapes_EIK_DoIntersect_RayPoint(ray, point);
        }

        public static bool DoIntersect(Ray2d ray, Line2d line)
        {
            return Intersections_Shapes_EIK_DoIntersect_RayLine(ray, line);
        }

        public static bool DoIntersect(Ray2d ray, Ray2d ray2)
        {
            return Intersections_Shapes_EIK_DoIntersect_RayRay(ray, ray2);
        }

        public static bool DoIntersect(Ray2d ray, Segment2d segment)
        {
            return Intersections_Shapes_EIK_DoIntersect_RaySegment(ray, segment);
        }

        public static bool DoIntersect(Ray2d ray, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_DoIntersect_RayTriangle(ray, triangle);
        }

        public static bool DoIntersect(Ray2d ray, Box2d box)
        {
            return Intersections_Shapes_EIK_DoIntersect_RayBox(ray, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Segment2d segment, Point2d point)
        {
            return Intersections_Shapes_EIK_DoIntersect_SegmentPoint(segment, point);
        }

        public static bool DoIntersect(Segment2d segment, Line2d line)
        {
            return Intersections_Shapes_EIK_DoIntersect_SegmentLine(segment, line);
        }

        public static bool DoIntersect(Segment2d segment, Ray2d ray)
        {
            return Intersections_Shapes_EIK_DoIntersect_SegmentRay(segment, ray);
        }

        public static bool DoIntersect(Segment2d segment, Segment2d segment2)
        {
            return Intersections_Shapes_EIK_DoIntersect_SegmentSegment(segment, segment2);
        }

        public static bool DoIntersect(Segment2d segment, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_DoIntersect_SegmentTriangle(segment, triangle);
        }

        public static bool DoIntersect(Segment2d segment, Box2d box)
        {
            return Intersections_Shapes_EIK_DoIntersect_SegmentBox(segment, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Triangle2d triangle, Point2d point)
        {
            return Intersections_Shapes_EIK_DoIntersect_TrianglePoint(triangle, point);
        }

        public static bool DoIntersect(Triangle2d triangle, Line2d line)
        {
            return Intersections_Shapes_EIK_DoIntersect_TriangleLine(triangle, line);
        }

        public static bool DoIntersect(Triangle2d triangle, Ray2d ray)
        {
            return Intersections_Shapes_EIK_DoIntersect_TriangleRay(triangle, ray);
        }

        public static bool DoIntersect(Triangle2d triangle, Segment2d segment)
        {
            return Intersections_Shapes_EIK_DoIntersect_TriangleSegment(triangle, segment);
        }

        public static bool DoIntersect(Triangle2d triangle, Triangle2d triangle2)
        {
            return Intersections_Shapes_EIK_DoIntersect_TriangleTriangle(triangle, triangle2);
        }

        public static bool DoIntersect(Triangle2d triangle, Box2d box)
        {
            return Intersections_Shapes_EIK_DoIntersect_TriangleBox(triangle, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box DoIntersect functions
        /// 
        /// </summary>--------------------------------------------------------

        public static bool DoIntersect(Box2d box, Point2d point)
        {
            return Intersections_Shapes_EIK_DoIntersect_BoxPoint(box, point);
        }

        public static bool DoIntersect(Box2d box, Line2d line)
        {
            return Intersections_Shapes_EIK_DoIntersect_BoxLine(box, line);
        }

        public static bool DoIntersect(Box2d box, Ray2d ray)
        {
            return Intersections_Shapes_EIK_DoIntersect_BoxRay(box, ray);
        }

        public static bool DoIntersect(Box2d box, Segment2d segment)
        {
            return Intersections_Shapes_EIK_DoIntersect_BoxSegment(box, segment);
        }

        public static bool DoIntersect(Box2d box, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_DoIntersect_BoxTriangle(box, triangle);
        }

        public static bool DoIntersect(Box2d box, Box2d boxd)
        {
            return Intersections_Shapes_EIK_DoIntersect_BoxBox(box, boxd);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point Intersection functions
        /// 
        /// </summary>--------------------------------------------------------

        public static IntersectionResult2d Intersection(Point2d point, Line2d line)
        {
            return Intersections_Shapes_EIK_Intersection_PointLine(point, line);
        }

        public static IntersectionResult2d Intersection(Point2d point, Ray2d ray)
        {
            return Intersections_Shapes_EIK_Intersection_PointRay(point, ray);
        }

        public static IntersectionResult2d Intersection(Point2d point, Segment2d segment)
        {
            return Intersections_Shapes_EIK_Intersection_PointSegment(point, segment);
        }

        public static IntersectionResult2d Intersection(Point2d point, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_Intersection_PointTriangle(point, triangle);
        }

        public static IntersectionResult2d Intersection(Point2d point, Box2d box)
        {
            return Intersections_Shapes_EIK_Intersection_PointBox(point, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Line2d line, Point2d point)
        {
            return Intersections_Shapes_EIK_Intersection_LinePoint(line, point);
        }

        public static IntersectionResult2d Intersection(Line2d line, Line2d line2)
        {
            return Intersections_Shapes_EIK_Intersection_LineLine(line, line2);
        }

        public static IntersectionResult2d Intersection(Line2d line, Ray2d ray)
        {
            return Intersections_Shapes_EIK_Intersection_LineRay(line, ray);
        }

        public static IntersectionResult2d Intersection(Line2d line, Segment2d segment)
        {
            return Intersections_Shapes_EIK_Intersection_LineSegment(line, segment);
        }

        public static IntersectionResult2d Intersection(Line2d line, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_Intersection_LineTriangle(line, triangle);
        }

        public static IntersectionResult2d Intersection(Line2d line, Box2d box)
        {
            return Intersections_Shapes_EIK_Intersection_LineBox(line, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Ray2d ray, Point2d point)
        {
            return Intersections_Shapes_EIK_Intersection_RayPoint(ray, point);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Line2d line)
        {
            return Intersections_Shapes_EIK_Intersection_RayLine(ray, line);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Ray2d ray2)
        {
            return Intersections_Shapes_EIK_Intersection_RayRay(ray, ray2);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Segment2d segment)
        {
            return Intersections_Shapes_EIK_Intersection_RaySegment(ray, segment);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_Intersection_RayTriangle(ray, triangle);
        }

        public static IntersectionResult2d Intersection(Ray2d ray, Box2d box)
        {
            return Intersections_Shapes_EIK_Intersection_RayBox(ray, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Segment2d segment, Point2d point)
        {
            return Intersections_Shapes_EIK_Intersection_SegmentPoint(segment, point);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Line2d line)
        {
            return Intersections_Shapes_EIK_Intersection_SegmentLine(segment, line);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Ray2d ray)
        {
            return Intersections_Shapes_EIK_Intersection_SegmentRay(segment, ray);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Segment2d segment2)
        {
            return Intersections_Shapes_EIK_Intersection_SegmentSegment(segment, segment2);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_Intersection_SegmentTriangle(segment, triangle);
        }

        public static IntersectionResult2d Intersection(Segment2d segment, Box2d box)
        {
            return Intersections_Shapes_EIK_Intersection_SegmentBox(segment, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Triangle2d triangle, Point2d point)
        {
            return Intersections_Shapes_EIK_Intersection_TrianglePoint(triangle, point);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Line2d line)
        {
            return Intersections_Shapes_EIK_Intersection_TriangleLine(triangle, line);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Ray2d ray)
        {
            return Intersections_Shapes_EIK_Intersection_TriangleRay(triangle, ray);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Segment2d segment)
        {
            return Intersections_Shapes_EIK_Intersection_TriangleSegment(triangle, segment);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Triangle2d triangle2)
        {
            return Intersections_Shapes_EIK_Intersection_TriangleTriangle(triangle, triangle2);
        }

        public static IntersectionResult2d Intersection(Triangle2d triangle, Box2d box)
        {
            return Intersections_Shapes_EIK_Intersection_TriangleBox(triangle, box);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box Intersection functions
        /// 
        /// </summary>-----------------------------------------------------

        public static IntersectionResult2d Intersection(Box2d box, Point2d point)
        {
            return Intersections_Shapes_EIK_Intersection_BoxPoint(box, point);
        }

        public static IntersectionResult2d Intersection(Box2d box, Line2d line)
        {
            return Intersections_Shapes_EIK_Intersection_BoxLine(box, line);
        }

        public static IntersectionResult2d Intersection(Box2d box, Ray2d ray)
        {
            return Intersections_Shapes_EIK_Intersection_BoxRay(box, ray);
        }

        public static IntersectionResult2d Intersection(Box2d box, Segment2d segment)
        {
            return Intersections_Shapes_EIK_Intersection_BoxSegment(box, segment);
        }

        public static IntersectionResult2d Intersection(Box2d box, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_Intersection_BoxTriangle(box, triangle);
        }

        public static IntersectionResult2d Intersection(Box2d box, Box2d boxd)
        {
            return Intersections_Shapes_EIK_Intersection_BoxBox(box, boxd);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///              The Point SqrDistance functions
        /// 
        /// </summary>-----------------------------------------------------

        public static double SqrDistance(Point2d point, Point2d point2)
        {
            return Intersections_Shapes_EIK_SqrDistance_PointPoint(point, point2);
        }

        public static double SqrDistance(Point2d point, Line2d line)
        {
            return Intersections_Shapes_EIK_SqrDistance_PointLine(point, line);
        }

        public static double SqrDistance(Point2d point, Ray2d ray)
        {
            return Intersections_Shapes_EIK_SqrDistance_PointRay(point, ray);
        }

        public static double SqrDistance(Point2d point, Segment2d seg)
        {
            return Intersections_Shapes_EIK_SqrDistance_PointSegment(point, seg);
        }

        public static double SqrDistance(Point2d point, Triangle2d tri)
        {
            return Intersections_Shapes_EIK_SqrDistance_PointTriangle(point, tri);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line SqrDistance functions
        /// 
        /// </summary>--------------------------------------------------------

        public static double SqrDistance(Line2d line, Point2d point)
        {
            return Intersections_Shapes_EIK_SqrDistance_LinePoint(line, point);
        }

        public static double SqrDistance(Line2d line, Line2d line2)
        {
            return Intersections_Shapes_EIK_SqrDistance_LineLine(line, line2);
        }

        public static double SqrDistance(Line2d line, Ray2d ray)
        {
            return Intersections_Shapes_EIK_SqrDistance_LineRay(line, ray);
        }

        public static double SqrDistance(Line2d line, Segment2d segment)
        {
            return Intersections_Shapes_EIK_SqrDistance_LineSegment(line, segment);
        }

        public static double SqrDistance(Line2d line, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_SqrDistance_LineTriangle(line, triangle);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray SqrDistance functions
        /// 
        /// </summary>--------------------------------------------------------

        public static double SqrDistance(Ray2d ray, Line2d line)
        {
            return Intersections_Shapes_EIK_SqrDistance_RayLine(ray, line);
        }

        public static double SqrDistance(Ray2d ray, Ray2d ray2)
        {
            return Intersections_Shapes_EIK_SqrDistance_RayRay(ray, ray2);
        }

        public static double SqrDistance(Ray2d ray, Segment2d segment)
        {
            return Intersections_Shapes_EIK_SqrDistance_RaySegment(ray, segment);
        }

        public static double SqrDistance(Ray2d ray, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_SqrDistance_RayTriangle(ray, triangle);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment SqrDistance functions
        /// 
        /// </summary>-----------------------------------------------------

        public static double SqrDistance(Segment2d segment, Point2d point)
        {
            return Intersections_Shapes_EIK_SqrDistance_SegmentPoint(segment, point);
        }

        public static double SqrDistance(Segment2d segment, Line2d line)
        {
            return Intersections_Shapes_EIK_SqrDistance_SegmentLine(segment, line);
        }

        public static double SqrDistance(Segment2d segment, Ray2d ray)
        {
            return Intersections_Shapes_EIK_SqrDistance_SegmentRay(segment, ray);
        }

        public static double SqrDistance(Segment2d segment, Segment2d segment2)
        {
            return Intersections_Shapes_EIK_SqrDistance_SegmentSegment(segment, segment2);
        }

        public static double SqrDistance(Segment2d segment, Triangle2d triangle)
        {
            return Intersections_Shapes_EIK_SqrDistance_SegmentTriangle(segment, triangle);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle SqrDistance functions
        /// 
        /// </summary>-----------------------------------------------------

        public static double SqrDistance(Triangle2d triangle, Point2d point)
        {
            return Intersections_Shapes_EIK_SqrDistance_TrianglePoint(triangle, point);
        }

        public static double SqrDistance(Triangle2d triangle, Line2d line)
        {
            return Intersections_Shapes_EIK_SqrDistance_TriangleLine(triangle, line);
        }

        public static double SqrDistance(Triangle2d triangle, Ray2d ray)
        {
            return Intersections_Shapes_EIK_SqrDistance_TriangleRay(triangle, ray);
        }

        public static double SqrDistance(Triangle2d triangle, Segment2d segment)
        {
            return Intersections_Shapes_EIK_SqrDistance_TriangleSegment(triangle, segment);
        }

        public static double SqrDistance(Triangle2d triangle, Triangle2d triangle2)
        {
            return Intersections_Shapes_EIK_SqrDistance_TriangleTriangle(triangle, triangle2);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_PointLine(Point2d point, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_PointRay(Point2d point, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_PointSegment(Point2d point, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_PointTriangle(Point2d point, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_PointBox(Point2d point, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Linet DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_LinePoint(Line2d line, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_LineLine(Line2d line, Line2d line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_LineRay(Line2d line, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_LineSegment(Line2d line, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_LineTriangle(Line2d line, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_LineBox(Line2d line, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_RayPoint(Ray2d ray, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_RayLine(Ray2d ray, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_RayRay(Ray2d ray, Ray2d ray2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_RaySegment(Ray2d ray, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_RayTriangle(Ray2d ray, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_RayBox(Ray2d ray, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_SegmentPoint(Segment2d segment, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_SegmentLine(Segment2d segment, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_SegmentRay(Segment2d segment, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_SegmentSegment(Segment2d segment, Segment2d segment2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_SegmentTriangle(Segment2d segment, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_SegmentBox(Segment2d segment, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_TrianglePoint(Triangle2d triangle, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_TriangleLine(Triangle2d triangle, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_TriangleRay(Triangle2d triangle, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_TriangleSegment(Triangle2d triangle, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_TriangleBox(Triangle2d triangle, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box DoIntersect extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_BoxPoint(Box2d box, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_BoxLine(Box2d box, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_BoxRay(Box2d box, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_BoxSegment(Box2d box, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_BoxTriangle(Box2d box, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Intersections_Shapes_EIK_DoIntersect_BoxBox(Box2d box, Box2d box2);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointLine(Point2d point, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointRay(Point2d point, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointSegment(Point2d point, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointTriangle(Point2d point, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_PointBox(Point2d point, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_LinePoint(Line2d line, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineLine(Line2d line, Line2d line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineRay(Line2d line, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineSegment(Line2d line, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineTriangle(Line2d line, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_LineBox(Line2d line, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayPoint(Ray2d ray, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayLine(Ray2d ray, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayRay(Ray2d ray, Ray2d ray2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_RaySegment(Ray2d ray, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayTriangle(Ray2d ray, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_RayBox(Ray2d ray, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentPoint(Segment2d segment, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentLine(Segment2d segment, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentRay(Segment2d segment, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentSegment(Segment2d segment, Segment2d segment2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentTriangle(Segment2d segment, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_SegmentBox(Segment2d segment, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_TrianglePoint(Triangle2d triangle, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleLine(Triangle2d triangle, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleRay(Triangle2d triangle, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleSegment(Triangle2d triangle, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_TriangleBox(Triangle2d triangle, Box2d box);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box Intersection extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxPoint(Box2d box, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxLine(Box2d box, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxRay(Box2d box, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxSegment(Box2d box, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxTriangle(Box2d box, Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntersectionResult2d Intersections_Shapes_EIK_Intersection_BoxBox(Box2d box, Box2d box2);

        /// <summary>--------------------------------------------------------
        /// 
        ///               The Point SqrDistance extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_PointPoint(Point2d point, Point2d point2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_PointLine(Point2d point, Line2d line);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_PointRay(Point2d point, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_PointSegment(Point2d point, Segment2d seg);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_PointTriangle(Point2d point, Triangle2d tri);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line SqrDistance extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_LinePoint(Line2d line, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_LineLine(Line2d line, Line2d line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_LineRay(Line2d line, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_LineSegment(Line2d line, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_LineTriangle(Line2d line, Triangle2d triangle);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray SqrDistance extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_RayPoint(Ray2d ray, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_RayLine(Ray2d ray, Line2d line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_RayRay(Ray2d ray, Ray2d ray2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_RaySegment(Ray2d ray, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_RayTriangle(Ray2d ray, Triangle2d triangle);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment SqrDistance extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_SegmentPoint(Segment2d segment, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_SegmentLine(Segment2d segment, Line2d line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_SegmentRay(Segment2d segment, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_SegmentSegment(Segment2d segment, Segment2d segment2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_SegmentTriangle(Segment2d segment, Triangle2d triangle);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle SqrDistance extern functions
        /// 
        /// </summary>------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_TrianglePoint(Triangle2d triangle, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_TriangleLine(Triangle2d triangle, Line2d line2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_TriangleRay(Triangle2d triangle, Ray2d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_TriangleSegment(Triangle2d triangle, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Intersections_Shapes_EIK_SqrDistance_TriangleTriangle(Triangle2d triangle, Triangle2d triangle2);

    }
}
