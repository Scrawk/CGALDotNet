using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet
{
    /// <summary>
    /// Global utility functions.
    /// </summary>
    public static class CGALGlobal
    {
        private const string DLL_NAME = "CGALWrapper.dll";

        private const CallingConvention CDECL = CallingConvention.Cdecl;

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        public const double RAD_TO_DEG = 180.0 / Math.PI;

        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        public const double DEG_TO_RAD = Math.PI / 180.0;

        /// <summary>
        /// Clamp v to min and max.
        /// </summary>
        /// <param name="v">The value v.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>The clamped value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int v, int min, int max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

        /// <summary>
        /// Clamp v to min and max.
        /// </summary>
        /// <param name="v">The value v.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>The clamped value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(double v, double min, double max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

        /// <summary>
        /// Clamp v to 0 and 1.
        /// </summary>
        /// <param name="v">The value v.</param>
        /// <returns>The clamped value</returns>
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
        /// <param name="v">The value v</param>
        /// <param name="count">The value to wrap at.</param>
        /// <returns>The value between 0 and count-1 (inclusive).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Wrap(int v, int count)
        {
            int r = v % count;
            return r < 0 ? r + count : r;
        }

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRadians(double degrees)
        {
            return degrees * DEG_TO_RAD;
        }

        /// <summary>
        /// Sin func using radians.
        /// </summary>
        /// <param name="radian">The input in radians.</param>
        /// <returns>The output in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Sin(Radian radian)
        {
            return new Radian(Math.Sin(radian.angle));
        }

        /// <summary>
        /// Cos func using radians.
        /// </summary>
        /// <param name="radian">The input in radians.</param>
        /// <returns>The output in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Cos(Radian radian)
        {
            return new Radian(Math.Cos(radian.angle));
        }

        /// <summary>
        /// Tan func using radians.
        /// </summary>
        /// <param name="radian">The input in radians.</param>
        /// <returns>The output in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Tan(Radian radian)
        {
            return new Radian(Math.Tan(radian.angle));
        }

        /// <summary>
        /// Returns CGAL_OBTUSE, CGAL_RIGHT or CGAL_ACUTE depending on the 
        /// angle formed by the two vectors u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>CGAL_OBTUSE, CGAL_RIGHT or CGAL_ACUTE depending on the 
        /// angle formed by the two vectors u and v.</returns>
        public static ANGLE Angle(Vector2d u, Vector2d v)
        {
            return CGALGlobal_EEK_Angle_Vector2(u, v);
        }

        /// <summary>
        /// returns CGAL_OBTUSE, CGAL_RIGHT or CGAL_ACUTE depending on the 
        /// angle formed by the two vectors u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>CGAL_OBTUSE, CGAL_RIGHT or CGAL_ACUTE depending on the 
        /// angle formed by the two vectors u and v.</returns>
        public static ANGLE Angle(Vector3d u, Vector3d v)
        {
            return CGALGlobal_EEK_Angle_Vector3(u, v);
        }

        /// <summary>
        /// Returns an approximation of the angle between u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>The angle is given in degrees.</returns>
        public static Degree ApproxAngle(Vector3d u, Vector3d v)
        {
            return new Degree(CGALGlobal_EEK_ApproxAngle_Vector3(u, v));
        }

        /// <summary>
        /// Returns an approximation of the signed dihedral angle 
        /// in the tetrahedron pqrs of edge pq.
        /// p,q,r and p,q,s are not collinear.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <returns>The sign is negative if orientation(p,q,r,s) 
        /// is CGAL::NEGATIVE and positive otherwise.
        /// The angle is given in degrees.</returns>
        public static Degree ApproxDihedralAngle(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            return new Degree(CGALGlobal_EEK_ApproxDihedralAngle_Point3(p, q, r, s));
        }

        /// <summary>
        /// Returns true, if the three points are collinear 
        /// and q lies between p and r.
        /// Note that true is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>Returns true, if the three points are 
        /// collinear and q lies between p and r.</returns>
        public static bool AreOrderedAlongLine(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EEK_AreOrderedAlongLine_Point2(p, q, r);
        }

        /// <summary>
        /// Returns true, if the three points are collinear 
        /// and q lies between p and r.
        /// Note that true is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>Returns true, if the three points are 
        /// collinear and q lies between p and r.</returns>
        public static bool AreOrderedAlongLine(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EEK_AreOrderedAlongLine_Point3(p, q, r);
        }

        /// <summary>
        /// returns true, if the three points are collinear 
        /// and q lies strictly between p and r.
        /// Note that false is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>returns true, iff the three points are 
        /// collinear and q lies strictly between p and r.</returns>
        public static bool AreStrictlyOrderedAlongLine(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point2(p, q, r);
        }

        /// <summary>
        /// returns true, if the three points are collinear 
        /// and q lies strictly between p and r.
        /// Note that false is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>returns true, iff the three points are 
        /// collinear and q lies strictly between p and r.</returns>
        public static bool AreStrictlyOrderedAlongLine(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point3(p, q, r);
        }

        /// <summary>
        /// Returns true, if p, q, and r are collinear
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>returns true, if p, q, and r are collinear</returns>
        public static bool Collinear(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EEK_Collinear_Point2(p, q, r);
        }

        /// <summary>
        /// Returns true, if p, q, and r are collinear
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>Returns true, iff p, q, and r are collinear</returns>
        public static bool Collinear(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EEK_Collinear_Point3(p, q, r);
        }

        /// <summary>
        /// Constructs the bisector line of the two points p and q.
        /// The bisector is oriented in such a way that p lies on its positive side.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns>Constructs the bisector line of the two points p and q.</returns>
        public static Line2d Bisector(Point3d p, Point3d q)
        {
            return CGALGlobal_EEK_Bisector_Point3(p, q);
        }

        /// <summary>
        /// Constructs the bisector of the two lines l1 and l2.
        /// 
        /// In the general case, the bisector has the direction of
        /// the vector which is the sum of the normalized directions 
        /// of the two lines, and which passes through the intersection 
        /// of l1 and l2. If l1 and l2 are parallel, then the bisector 
        /// is defined as the line which has the same direction as l1, 
        /// and which is at the same distance from l1 and l2. 
        /// If Kernel::FT is not a model of FieldWithSqrt an 
        /// approximation of the square root will be used in this 
        /// function, impacting the exactness of the result even 
        /// with an (exact) multiprecision number type.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns>Constructs the bisector of the two lines l1 and l2.</returns>
        public static Line2d Bisector(Line2d l1, Line2d l2)
        {
            return CGALGlobal_EEK_Bisector_Line2(l1, l2);
        }

        /// <summary>
        /// Returns true, if p, q, r, and s are coplanar.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <returns>Returns true, if p, q, r, and s are coplanar.</returns>
        public static bool Coplanar(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            return CGALGlobal_EEK_Coplanar_Point3(p, q, r, s);
        }

        /// <summary>
        /// If p,q,r are collinear, then CGAL_COLLINEAR is returned.
        /// If not, then p,q,r define a plane p. The return value in this 
        /// case is either CGAL_POSITIVE or CGAL_NEGATIVE, but we don't 
        /// specify it explicitly. However, we guarantee that all calls to
        /// this predicate over 3 points in p will return a coherent 
        /// orientation if considered a 2D orientation in p
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>If p,q,r are collinear, then CGAL_COLLINEAR is returned.</returns>
        public static ORIENTATION CoplanarOrientation(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EEK_CoplanarOrientation_3Point3(p, q, r);
        }

        /// <summary>
        /// Let P be the plane defined by the points p, q, and r.
        /// Note that the order defines the orientation of P. The function computes 
        /// the orientation of points p, q, and s in P: If p, q, s are collinear, 
        /// CGAL_COLLINEAR is returned. If P and the plane defined by p, q,
        /// and s have the same orientation, CGAL_POSITIVE is returned; 
        /// otherwise CGAL_NEGATIVE is returned.
        /// p, q, r, and s are coplanar and p, q, and r are not collinear.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ORIENTATION CoplanarOrientation(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            return CGALGlobal_EEK_CoplanarOrientation_4Point3(p, q, r, s);
        }

        /// <summary>
        /// Constructs the line which is at the same distance from the three points p, q and r.
        /// p, q and r are not collinear.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>Constructs the line which is at the same distance from the three points p, q and r.</returns>
        public static Line3d EquidistantLine(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EEK_EquidistantLine_Line3(p, q, r);
        }

        /// <summary>
        /// Returns true if p, q, and r form a left turn.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>Returns true if p, q, and r form a left turn.</returns>
        public static bool LeftTurn(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EEK_LeftTurn_Point2(p, q, r);
        }

        /// <summary>
        /// Returns true if p, q, and r form a right turn.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>Returns true if p, q, and r form a right turn.</returns>
        public static bool RightTurn(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EEK_RightTurn_Point2(p, q, r);
        }

        /// <summary>
        /// returns CGAL::LEFT_TURN, if r lies to the left of the oriented 
        /// line l defined by p and q, returns CGAL::RIGHT_TURN if r lies 
        /// to the right of l, and returns CGAL::COLLINEAR if r lies on l.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EEK_Orientation_Point2(p, q, r);
        }

        /// <summary>
        /// returns CGAL::LEFT_TURN if u and v form a left turn, returns 
        /// CGAL::RIGHT_TURN if u and v form a right turn, and returns 
        /// CGAL::COLLINEAR if u and v are collinear.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Vector2d u, Vector2d v)
        {
            return CGALGlobal_EEK_Orientation_Vector2(u, v);
        }

        /// <summary>
        /// returns CGAL::POSITIVE, if s lies on the positive side of the 
        /// oriented plane h defined by p, q, and r, returns CGAL::NEGATIVE
        /// if s lies on the negative side of h, and returns CGAL::COPLANAR 
        /// if s lies on h.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            return CGALGlobal_EEK_Orientation_Point3(p, q, r, s);
        }

        /// <summary>
        /// returns CGAL::NEGATIVE if u, v and w are negatively oriented, 
        /// CGAL::POSITIVE if u, v and w are positively oriented,
        /// and CGAL::COPLANAR if u, v and w are coplanar.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Vector3d u, Vector3d v, Vector3d w)
        {
            return CGALGlobal_EEK_Orientation_Vector3(u, v, w);
        }

        /// <summary>
        /// computes an orthogonal vector of the plane defined by p, q
        /// and r, which is directed to the positive side of this plane.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns>computes an orthogonal vector of the plane</returns>
        public static Vector3d OrthogonalVector(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EEK_OrthogonalVector_Point3(p, q, r);
        }

        /// <summary>
        /// returns true, if l1 and l2 are parallel or if one of those 
        /// (or both) is degenerate.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns>returns true, if l1 and l2 are parallel</returns>
        public static bool Parallel(Line2d l1, Line2d l2)
        {
            return CGALGlobal_EEK_Parallel_Line2(l1, l2);
        }

        /// <summary>
        /// returns true, if r1 and r2 are parallel or if one of 
        /// those (or both) is degenerate.
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns>returns true, if r1 and r2 are parallel</returns>
        public static bool Parallel(Ray2d r1, Ray2d r2)
        {
            return CGALGlobal_EEK_Parallel_Ray2(r1, r2);
        }

        /// <summary>
        /// returns true, if s1 and s2 are parallel or if one of 
        /// those (or both) is degenerate.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>returns true, if s1 and s2 are parallel</returns>
        public static bool Parallel(Segment2d s1, Segment2d s2)
        {
            return CGALGlobal_EEK_Parallel_Segment2(s1, s2);
        }


        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ANGLE CGALGlobal_EEK_Angle_Vector2(Vector2d u, Vector2d v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ANGLE CGALGlobal_EEK_Angle_Vector3(Vector3d u, Vector3d v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double CGALGlobal_EEK_ApproxAngle_Vector3(Vector3d u, Vector3d v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double CGALGlobal_EEK_ApproxDihedralAngle_Point3(Point3d p, Point3d q, Point3d r, Point3d s);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_AreOrderedAlongLine_Point2(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_AreOrderedAlongLine_Point3(Point3d p, Point3d q, Point3d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point2(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point3(Point3d p, Point3d q, Point3d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Collinear_Point2(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Collinear_Point3(Point3d p, Point3d q, Point3d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Line2d CGALGlobal_EEK_Bisector_Point3(Point3d p, Point3d q);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Line2d CGALGlobal_EEK_Bisector_Line2(Line2d p, Line2d q);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Coplanar_Point3(Point3d p, Point3d q, Point3d r, Point3d s);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EEK_CoplanarOrientation_3Point3(Point3d p, Point3d q, Point3d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EEK_CoplanarOrientation_4Point3(Point3d p, Point3d q, Point3d r, Point3d s);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Line3d CGALGlobal_EEK_EquidistantLine_Line3(Point3d p, Point3d q, Point3d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_LeftTurn_Point2(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_RightTurn_Point2(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EEK_Orientation_Point2(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EEK_Orientation_Vector2(Vector2d u, Vector2d v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EEK_Orientation_Point3(Point3d p, Point3d q, Point3d r, Point3d s);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EEK_Orientation_Vector3(Vector3d u, Vector3d v, Vector3d w);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Vector3d CGALGlobal_EEK_OrthogonalVector_Point3(Point3d p, Point3d q, Point3d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Parallel_Line2(Line2d l1, Line2d l2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Parallel_Ray2(Ray2d r1, Ray2d r2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Parallel_Segment2(Segment2d s1, Segment2d s2);

    }
}
