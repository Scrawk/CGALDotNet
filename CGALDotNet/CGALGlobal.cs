using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using CGALDotNet.Geometry;

namespace CGALDotNet
{
    public static class CGALGlobal
    {

        public const double RAD_TO_DEG = 180.0 / Math.PI;

        public const double DEG_TO_RAD = Math.PI / 180.0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int v, int min, int max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(double v, double min, double max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp01(double v)
        {
            if (v < 0.0) v = 0.0;
            if (v > 1.0) v = 1.0;
            return v;

        }

        /// <summary>
        /// Wrap a value between 0 and count-1 (inclusive).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Wrap(int v, int count)
        {
            int r = v % count;
            return r < 0 ? r + count : r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRadians(double degrees)
        {
            return degrees * DEG_TO_RAD;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Sin(Radian radian)
        {
            return new Radian(Math.Sin(radian.angle));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree Sin(Degree degree)
        {
            return new Degree(Math.Sin(degree.angle * DEG_TO_RAD));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Cos(Radian radian)
        {
            return new Radian(Math.Cos(radian.angle));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree Cos(Degree degree)
        {
            return new Degree(Math.Cos(degree.angle * DEG_TO_RAD));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Tan(Radian radian)
        {
            return new Radian(Math.Tan(radian.angle));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree Tan(Degree degree)
        {
            return new Degree(Math.Tan(degree.angle * DEG_TO_RAD));
        }

        public static CGAL_ANGLE Angle(Vector2d v1, Vector2d v2)
        {
            throw new NotImplementedException();
        }

        public static CGAL_ANGLE Angle(Vector3d v1, Vector3d v2)
        {
            throw new NotImplementedException();
        }

        public static double ApproxAngle(Vector2d v1, Vector2d v2)
        {
            throw new NotImplementedException();
        }

        public static double ApproxAngle(Vector3d v1, Vector3d v2)
        {
            throw new NotImplementedException();
        }

        public static double ApproxDihedralAngle(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            throw new NotImplementedException();
        }

        public static bool AreOrderedAlongLine(Point2d p, Point2d q, Point2d r)
        {
            throw new NotImplementedException();
        }

        public static bool AreOrderedAlongLine(Point3d p, Point3d q, Point3d r)
        {
            throw new NotImplementedException();
        }

        public static bool AreStrictlyOrderedAlongLine(Point2d p, Point2d q, Point2d r)
        {
            throw new NotImplementedException();
        }

        public static bool AreStrictlyOrderedAlongLine(Point3d p, Point3d q, Point3d r)
        {
            throw new NotImplementedException();
        }

        public static bool Colinear(Point2d p, Point2d q, Point2d r)
        {
            throw new NotImplementedException();
        }

        public static bool Colinear(Point3d p, Point3d q, Point3d r)
        {
            throw new NotImplementedException();
        }

        public static Line2d Bisector(Point3d p, Point3d q)
        {
            throw new NotImplementedException();
        }

        public static Line2d Bisector(Line2d p, Line2d q)
        {
            throw new NotImplementedException();
        }

        public static bool Coplanar(Point3d p, Point3d q, Point3d r)
        {
            throw new NotImplementedException();
        }

        public static bool Coplanar(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            throw new NotImplementedException();
        }

        public static CGAL_ORIENTATION CoplanarOrientation(Point3d p, Point3d q, Point3d r)
        {
            throw new NotImplementedException();
        }

        public static CGAL_ORIENTATION CoplanarOrientation(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            throw new NotImplementedException();
        }

        public static Line2d EquidistantLine(Point3d p, Point3d q, Point3d r)
        {
            throw new NotImplementedException();
        }

        public static bool LeftTurn(Point2d p, Point2d q, Point2d r)
        {
            throw new NotImplementedException();
        }

        public static bool RightTurn(Point2d p, Point2d q, Point2d r)
        {
            throw new NotImplementedException();
        }

        public static CGAL_ORIENTATION Orientation(Point2d p, Point2d q, Point2d r)
        {
            throw new NotImplementedException();
        }

        public static CGAL_ORIENTATION Orientation(Vector2d u, Vector2d v)
        {
            throw new NotImplementedException();
        }

        public static CGAL_ORIENTATION Orientation(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            throw new NotImplementedException();
        }

        public static CGAL_ORIENTATION Orientation(Vector3d u, Vector3d v, Vector3d w)
        {
            throw new NotImplementedException();
        }

        public static Vector3d OrthogonalVector(Point3d p, Point3d q, Point3d r)
        {
            throw new NotImplementedException();
        }

        public static Vector3d OrthogonalVector(Vector3d u, Vector3d v, Vector3d w)
        {
            throw new NotImplementedException();
        }

        public static bool Parallel(Line2d l1, Line2d l2)
        {
            throw new NotImplementedException();
        }

        public static bool Parallel(Ray2d r1, Ray2d r2)
        {
            throw new NotImplementedException();
        }

        public static bool Parallel(Segment2d s1, Segment2d s2)
        {
            throw new NotImplementedException();
        }

    }
}
