using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Geometry;

[assembly: InternalsVisibleTo("CGALDotNetConsole")]
[assembly: InternalsVisibleTo("CGALDotNetTest")]

namespace CGALDotNet
{
    /// <summary>
    /// Global utility functions.
    /// </summary>
    public static class CGALGlobal
    {
        public const int NULL_INDEX = -1;

        private const string DLL_NAME = "CGALWrapper.dll";

        private const CallingConvention CDECL = CallingConvention.Cdecl;

        /// <summary>
        /// Get the version of CGAL in use.
        /// </summary>
        public static string Version
        {
            get
            {
                int v = CGALGlobal_VersionNumber();

                int MAJOR = v / 10000000 % 100;
                int MINOR = v / 100000 % 100;
                int PATCH = v / 10000 % 10;
                int BUILD = v % 10000;

                return string.Format("{0}.{1}.{2}.{3}", MAJOR, MINOR, PATCH, BUILD);
            }
        }

        /// <summary>
        /// Get the version of eigen being used.
        /// </summary>
        public static string EigenVersion
        {
            get
            {
                var v = CGALGlobal_EigenVersionNumber();

                int WORLD = v.first;
                int MAJOR = v.second;
                int MINOR = v.third;

                return string.Format("{0}.{1}.{2}", WORLD, MAJOR, MINOR);
            }
        }

        /// <summary>
        /// Returns OBTUSE, RIGHT or ACUTE depending on the 
        /// angle formed by the two vectors u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>OBTUSE, RIGHT or ACUTE depending on the 
        /// angle formed by the two vectors u and v.</returns>
        public static ANGLE Angle(Vector2d u, Vector2d v)
        {
            return CGALGlobal_EIK_Angle_Vector2(u, v);
        }

        /// <summary>
        /// Returns OBTUSE, RIGHT or ACUTE depending on the 
        /// angle formed by the two vectors u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>OBTUSE, RIGHT or ACUTE depending on the 
        /// angle formed by the two vectors u and v.</returns>
        public static ANGLE Angle(Vector2<EIK> u, Vector2<EIK> v)
        {
            return CGALGlobal_EIK_Angle_Vector2(u.Ptr, v.Ptr);
        }

        /// <summary>
        /// Returns OBTUSE, RIGHT or ACUTE depending on the 
        /// angle formed by the two vectors u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>OBTUSE, RIGHT or ACUTE depending on the 
        /// angle formed by the two vectors u and v.</returns>
        public static ANGLE Angle(Vector2<EEK> u, Vector2<EEK> v)
        {
            return CGALGlobal_EEK_Angle_Vector2(u.Ptr, v.Ptr);
        }

        /// <summary>
        /// returns OBTUSE, RIGHT or ACUTE depending on the 
        /// angle formed by the two vectors u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>OBTUSE, RIGHT or ACUTE depending on the 
        /// angle formed by the two vectors u and v.</returns>
        public static ANGLE Angle(Vector3d u, Vector3d v)
        {
            return CGALGlobal_EIK_Angle_Vector3d(u, v);
        }

        /// <summary>
        /// Returns an approximation of the angle between u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>The angle is given in degrees.</returns>
        public static Degree ApproxAngle(Vector2d u, Vector2d v)
        {
            return new Degree(CGALGlobal_EIK_ApproxAngle_Vector3d(u.xy0, v.xy0));
        }

        /// <summary>
        /// Returns an approximation of the angle between p-q and r-q.
        /// </summary>
        /// <param name="p">The first tetrahedrons point.</param>
        /// <param name="q">The second tetrahedrons point.</param>
        /// <param name="r">The third tetrahedrons point.</param>
        /// <returns>The angle is given in degrees.</returns>
        public static Degree ApproxAngle(Point2d p, Point2d q, Point2d r)
        {
            var u = Point2d.Direction(q, p).xy0;
            var v = Point2d.Direction(q, r).xy0;

            return new Degree(CGALGlobal_EIK_ApproxAngle_Vector3d(u, v));
        }

        /// <summary>
        /// Returns an approximation of the angle between u and v.
        /// </summary>
        /// <param name="u">The first vector.</param>
        /// <param name="v">The second vector.</param>
        /// <returns>The angle is given in degrees.</returns>
        public static Degree ApproxAngle(Vector3d u, Vector3d v)
        {
            return new Degree(CGALGlobal_EIK_ApproxAngle_Vector3d(u, v));
        }

        /// <summary>
        /// Returns an approximation of the angle between p-q and r-q.
        /// </summary>
        /// <param name="p">The first tetrahedrons point.</param>
        /// <param name="q">The second tetrahedrons point.</param>
        /// <param name="r">The third tetrahedrons point.</param>
        /// <returns>The angle is given in degrees.</returns>
        public static Degree ApproxAngle(Point3d p, Point3d q, Point3d r)
        {
            var u = Point3d.Direction(q, p);
            var v = Point3d.Direction(q, r);

            return new Degree(CGALGlobal_EIK_ApproxAngle_Vector3d(u, v));
        }

        /// <summary>
        /// Returns an approximation of the signed dihedral angle 
        /// in the tetrahedron pqrs of edge pq.
        /// p,q,r and p,q,s are not collinear.
        /// </summary>
        /// <param name="p">The first tetrahedrons point.</param>
        /// <param name="q">The second tetrahedrons point.</param>
        /// <param name="r">The third tetrahedrons point.</param>
        /// <param name="s">The fourth tetrahedrons point.</param>
        /// <returns>The sign is negative if orientation(p,q,r,s) 
        /// is CGAL::NEGATIVE and positive otherwise.
        /// The angle is given in degrees.</returns>
        public static Degree ApproxDihedralAngle(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            return new Degree(CGALGlobal_EIK_ApproxDihedralAngle_Point3(p, q, r, s));
        }

        /// <summary>
        /// Returns true, if the three points are collinear 
        /// and q lies between p and r.
        /// Note that true is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true, if the three points are 
        /// collinear and q lies between p and r.</returns>
        public static bool AreOrderedAlongLine(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EIK_AreOrderedAlongLine_Point2d(p, q, r);
        }

        /// <summary>
        /// Returns true, if the three points are collinear 
        /// and q lies between p and r.
        /// Note that true is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true, if the three points are 
        /// collinear and q lies between p and r.</returns>
        public static bool AreOrderedAlongLine(Point2<EIK> p, Point2<EIK> q, Point2<EIK> r)
        {
            return CGALGlobal_EIK_AreOrderedAlongLine_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns true, if the three points are collinear 
        /// and q lies between p and r.
        /// Note that true is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true, if the three points are 
        /// collinear and q lies between p and r.</returns>
        public static bool AreOrderedAlongLine(Point2<EEK> p, Point2<EEK> q, Point2<EEK> r)
        {
            return CGALGlobal_EEK_AreOrderedAlongLine_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns true, if the three points are collinear 
        /// and q lies between p and r.
        /// Note that true is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true, if the three points are 
        /// collinear and q lies between p and r.</returns>
        public static bool AreOrderedAlongLine(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EIK_AreOrderedAlongLine_Point3d(p, q, r);
        }

        /// <summary>
        /// returns true, if the three points are collinear 
        /// and q lies strictly between p and r.
        /// Note that false is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>returns true, iff the three points are 
        /// collinear and q lies strictly between p and r.</returns>
        public static bool AreStrictlyOrderedAlongLine(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point2d(p, q, r);
        }

        /// <summary>
        /// returns true, if the three points are collinear 
        /// and q lies strictly between p and r.
        /// Note that false is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>returns true, iff the three points are 
        /// collinear and q lies strictly between p and r.</returns>
        public static bool AreStrictlyOrderedAlongLine(Point2<EIK> p, Point2<EIK> q, Point2<EIK> r)
        {
            return CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// returns true, if the three points are collinear 
        /// and q lies strictly between p and r.
        /// Note that false is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>returns true, iff the three points are 
        /// collinear and q lies strictly between p and r.</returns>
        public static bool AreStrictlyOrderedAlongLine(Point2<EEK> p, Point2<EEK> q, Point2<EEK> r)
        {
            return CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// returns true, if the three points are collinear 
        /// and q lies strictly between p and r.
        /// Note that false is returned, if q==p or q==r.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>returns true, iff the three points are 
        /// collinear and q lies strictly between p and r.</returns>
        public static bool AreStrictlyOrderedAlongLine(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point3d(p, q, r);
        }

        /// <summary>
        /// Returns true, if p, q, and r are collinear
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>returns true, if p, q, and r are collinear</returns>
        public static bool Collinear(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EIK_Collinear_Point2d(p, q, r);
        }

        /// <summary>
        /// Returns true, if p, q, and r are collinear
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>returns true, if p, q, and r are collinear</returns>
        public static bool Collinear(Point2<EIK> p, Point2<EIK> q, Point2<EIK> r)
        {
            return CGALGlobal_EIK_Collinear_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns true, if p, q, and r are collinear
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>returns true, if p, q, and r are collinear</returns>
        public static bool Collinear(Point2<EEK> p, Point2<EEK> q, Point2<EEK> r)
        {
            return CGALGlobal_EEK_Collinear_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns true, if p, q, and r are collinear
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true, iff p, q, and r are collinear</returns>
        public static bool Collinear(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EIK_Collinear_Point3d(p, q, r);
        }

        /// <summary>
        /// Compute the barycenter of the points p1, p2 and p3 
        /// with corresponding weights w1, w2 and w3 as 1.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Compute the barycenter of the points.</returns>
        public static Point2d Barycenter(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EIK_Barycenter_Point2d(p, q, r);
        }

        /// <summary>
        /// Compute the barycenter of the points p1, p2 and p3 
        /// with corresponding weights w1, w2 and w3 as 1.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Compute the barycenter of the points.</returns>
        public static Point2<EIK> Barycenter(Point2<EIK> p, Point2<EIK> q, Point2<EIK> r)
        {
            var ptr = CGALGlobal_EIK_Barycenter_Point2(p.Ptr, q.Ptr, r.Ptr);
            return new Point2<EIK>(ptr);
        }

        /// <summary>
        /// Compute the barycenter of the points p1, p2 and p3 
        /// with corresponding weights w1, w2 and w3 as 1.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Compute the barycenter of the points.</returns>
        public static Point2<EEK> Barycenter(Point2<EEK> p, Point2<EEK> q, Point2<EEK> r)
        {
            var ptr = CGALGlobal_EEK_Barycenter_Point2(p.Ptr, q.Ptr, r.Ptr);
            return new Point2<EEK>(ptr);
        }

        /// <summary>
        /// Compute the barycenter of the points p1, p2 and p3 
        /// with corresponding weights w1, w2 and w3 as 1.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Compute the barycenter of the points.</returns>
        public static Point3d Barycenter(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EIK_Barycenter_Point3d(p, q, r);
        }

        /// <summary>
        /// Constructs the bisector line of the two points p and q.
        /// The bisector is oriented in such a way that p lies on its positive side.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <returns>Constructs the bisector line of the two points p and q.</returns>
        public static Line2d Bisector(Point3d p, Point3d q)
        {
            return CGALGlobal_EIK_Bisector_Point3d(p, q);
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
        /// <param name="l1">The first line.</param>
        /// <param name="l2">The second line.</param>
        /// <returns>Constructs the bisector of the two lines l1 and l2.</returns>
        public static Line2d Bisector(Line2d l1, Line2d l2)
        {
            return CGALGlobal_EIK_Bisector_Line2d(l1, l2);
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
        /// <param name="l1">The first line.</param>
        /// <param name="l2">The second line.</param>
        /// <returns>Constructs the bisector of the two lines l1 and l2.</returns>
        public static Line2<EIK> Bisector(Line2<EIK> l1, Line2<EIK> l2)
        {
            var ptr = CGALGlobal_EIK_Bisector_Line2(l1.Ptr, l2.Ptr);
            return new Line2<EIK>(ptr);
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
        /// <param name="l1">The first line.</param>
        /// <param name="l2">The second line.</param>
        /// <returns>Constructs the bisector of the two lines l1 and l2.</returns>
        public static Line2<EEK> Bisector(Line2<EEK> l1, Line2<EEK> l2)
        {
            var ptr = CGALGlobal_EEK_Bisector_Line2(l1.Ptr, l2.Ptr);
            return new Line2<EEK>(ptr);
        }

        /// <summary>
        /// Returns true, if p, q, r, and s are coplanar.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <param name="s">The fourth point</param>
        /// <returns>Returns true, if p, q, r, and s are coplanar.</returns>
        public static bool Coplanar(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            return CGALGlobal_EIK_Coplanar_Point3d(p, q, r, s);
        }

        /// <summary>
        /// If p,q,r are collinear, then CGAL_COLLINEAR is returned.
        /// If not, then p,q,r define a plane p. The return value in this 
        /// case is either CGAL_POSITIVE or CGAL_NEGATIVE, but we don't 
        /// specify it explicitly. However, we guarantee that all calls to
        /// this predicate over 3 points in p will return a coherent 
        /// orientation if considered a 2D orientation in p
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>If p,q,r are collinear, then CGAL_COLLINEAR is returned.</returns>
        public static ORIENTATION CoplanarOrientation(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EIK_CoplanarOrientation_3Point3d(p, q, r);
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
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <param name="s">The fourth point</param>
        /// <returns></returns>
        public static ORIENTATION CoplanarOrientation(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            return CGALGlobal_EIK_CoplanarOrientation_4Point3d(p, q, r, s);
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
            return CGALGlobal_EIK_EquidistantLine_Line3d(p, q, r);
        }

        /// <summary>
        /// Returns true if p, q, and r form a left turn.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true if p, q, and r form a left turn.</returns>
        public static bool LeftTurn(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EIK_LeftTurn_Point2d(p, q, r);
        }

        /// <summary>
        /// Returns true if p, q, and r form a left turn.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true if p, q, and r form a left turn.</returns>
        public static bool LeftTurn(Point2<EIK> p, Point2<EIK> q, Point2<EIK> r)
        {
            return CGALGlobal_EIK_LeftTurn_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns true if p, q, and r form a left turn.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true if p, q, and r form a left turn.</returns>
        public static bool LeftTurn(Point2<EEK> p, Point2<EEK> q, Point2<EEK> r)
        {
            return CGALGlobal_EEK_LeftTurn_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns true if p, q, and r form a right turn.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true if p, q, and r form a right turn.</returns>
        public static bool RightTurn(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EIK_RightTurn_Point2d(p, q, r);
        }

        /// <summary>
        /// Returns true if p, q, and r form a right turn.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true if p, q, and r form a right turn.</returns>
        public static bool RightTurn(Point2<EIK> p, Point2<EIK> q, Point2<EIK> r)
        {
            return CGALGlobal_EIK_RightTurn_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns true if p, q, and r form a right turn.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>Returns true if p, q, and r form a right turn.</returns>
        public static bool RightTurn(Point2<EEK> p, Point2<EEK> q, Point2<EEK> r)
        {
            return CGALGlobal_EIK_RightTurn_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns LEFT_TURN, if r lies to the left of the oriented 
        /// line l defined by p and q, returns RIGHT_TURN if r lies 
        /// to the right of l, and returns COLLINEAR if r lies on l.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Point2d p, Point2d q, Point2d r)
        {
            return CGALGlobal_EIK_Orientation_Point2d(p, q, r);
        }

        /// <summary>
        /// Returns LEFT_TURN, if r lies to the left of the oriented 
        /// line l defined by p and q, returns RIGHT_TURN if r lies 
        /// to the right of l, and returns COLLINEAR if r lies on l.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Point2<EIK> p, Point2<EIK> q, Point2<EIK> r)
        {
            return CGALGlobal_EIK_Orientation_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// Returns LEFT_TURN, if r lies to the left of the oriented 
        /// line l defined by p and q, returns RIGHT_TURN if r lies 
        /// to the right of l, and returns COLLINEAR if r lies on l.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Point2<EEK> p, Point2<EEK> q, Point2<EEK> r)
        {
            return CGALGlobal_EEK_Orientation_Point2(p.Ptr, q.Ptr, r.Ptr);
        }

        /// <summary>
        /// returns LEFT_TURN if u and v form a left turn, returns 
        /// RIGHT_TURN if u and v form a right turn, and returns 
        /// COLLINEAR if u and v are collinear.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Vector2d u, Vector2d v)
        {
            return CGALGlobal_EIK_Orientation_Vector2d(u, v);
        }

        /// <summary>
        /// Returns LEFT_TURN, if r lies to the left of the oriented 
        /// line l defined by p and q, returns RIGHT_TURN if r lies 
        /// to the right of l, and returns COLLINEAR if r lies on l.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Vector2<EIK> p, Vector2<EIK> q)
        {
            return CGALGlobal_EIK_Orientation_Vector2(p.Ptr, q.Ptr);
        }

        /// <summary>
        /// Returns LEFT_TURN, if r lies to the left of the oriented 
        /// line l defined by p and q, returns RIGHT_TURN if r lies 
        /// to the right of l, and returns COLLINEAR if r lies on l.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Vector2<EEK> p, Vector2<EEK> q)
        {
            return CGALGlobal_EEK_Orientation_Vector2(p.Ptr, q.Ptr);
        }

        /// <summary>
        /// returns POSITIVE, if s lies on the positive side of the 
        /// oriented plane h defined by p, q, and r, returns NEGATIVE
        /// if s lies on the negative side of h, and returns COPLANAR 
        /// if s lies on h.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <param name="s">The fourth point</param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Point3d p, Point3d q, Point3d r, Point3d s)
        {
            return CGALGlobal_EIK_Orientation_Point3d(p, q, r, s);
        }

        /// <summary>
        /// returns NEGATIVE if u, v and w are negatively oriented, 
        /// POSITIVE if u, v and w are positively oriented,
        /// and COPLANAR if u, v and w are coplanar.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public static ORIENTATION Orientation(Vector3d u, Vector3d v, Vector3d w)
        {
            return CGALGlobal_EIK_Orientation_Vector3d(u, v, w);
        }

        /// <summary>
        /// computes an orthogonal vector of the plane defined by p, q
        /// and r, which is directed to the positive side of this plane.
        /// </summary>
        /// <param name="p">The first point.</param>
        /// <param name="q">The second point.</param>
        /// <param name="r">The third point.</param>
        /// <returns>computes an orthogonal vector of the plane</returns>
        public static Vector3d OrthogonalVector(Point3d p, Point3d q, Point3d r)
        {
            return CGALGlobal_EIK_OrthogonalVector_Point3d(p, q, r);
        }

        /// <summary>
        /// returns true, if l1 and l2 are parallel or if one of those 
        /// (or both) is degenerate.
        /// </summary>
        /// <param name="l1">The first line.</param>
        /// <param name="l2">The seconed line.</param>
        /// <returns>returns true, if l1 and l2 are parallel</returns>
        public static bool Parallel(Line2d l1, Line2d l2)
        {
            return CGALGlobal_EIK_Parallel_Line2d(l1, l2);
        }

        /// <summary>
        /// returns true, if l1 and l2 are parallel or if one of those 
        /// (or both) is degenerate.
        /// </summary>
        /// <param name="l1">The first line.</param>
        /// <param name="l2">The seconed line.</param>
        /// <returns>returns true, if l1 and l2 are parallel</returns>
        public static bool Parallel(Line2<EIK> l1, Line2<EIK> l2)
        {
            return CGALGlobal_EIK_Parallel_Line2(l1.Ptr, l2.Ptr);
        }

        /// <summary>
        /// returns true, if l1 and l2 are parallel or if one of those 
        /// (or both) is degenerate.
        /// </summary>
        /// <param name="l1">The first line.</param>
        /// <param name="l2">The seconed line.</param>
        /// <returns>returns true, if l1 and l2 are parallel</returns>
        public static bool Parallel(Line2<EEK> l1, Line2<EEK> l2)
        {
            return CGALGlobal_EEK_Parallel_Line2(l1.Ptr, l2.Ptr);
        }

        /// <summary>
        /// returns true, if r1 and r2 are parallel or if one of 
        /// those (or both) is degenerate.
        /// </summary>
        /// <param name="r1">The first ray.</param>
        /// <param name="r2">The second ray.</param>
        /// <returns>returns true, if r1 and r2 are parallel</returns>
        public static bool Parallel(Ray2d r1, Ray2d r2)
        {
            return CGALGlobal_EIK_Parallel_Ray2d(r1, r2);
        }

        /// <summary>
        /// returns true, if r1 and r2 are parallel or if one of 
        /// those (or both) is degenerate.
        /// </summary>
        /// <param name="r1">The first ray.</param>
        /// <param name="r2">The second ray.</param>
        /// <returns>returns true, if r1 and r2 are parallel</returns>
        public static bool Parallel(Ray2<EIK> r1, Ray2<EIK> r2)
        {
            return CGALGlobal_EIK_Parallel_Ray2(r1.Ptr, r2.Ptr);
        }

        /// <summary>
        /// returns true, if r1 and r2 are parallel or if one of 
        /// those (or both) is degenerate.
        /// </summary>
        /// <param name="r1">The first ray.</param>
        /// <param name="r2">The second ray.</param>
        /// <returns>returns true, if r1 and r2 are parallel</returns>
        public static bool Parallel(Ray2<EEK> r1, Ray2<EEK> r2)
        {
            return CGALGlobal_EEK_Parallel_Ray2(r1.Ptr, r2.Ptr);
        }

        /// <summary>
        /// returns true, if s1 and s2 are parallel or if one of 
        /// those (or both) is degenerate.
        /// </summary>
        /// <param name="s1">The first segment.</param>
        /// <param name="s2">The secong segment.</param>
        /// <returns>returns true, if s1 and s2 are parallel</returns>
        public static bool Parallel(Segment2d s1, Segment2d s2)
        {
            return CGALGlobal_EIK_Parallel_Segment2d(s1, s2);
        }

        /// <summary>
        /// returns true, if s1 and s2 are parallel or if one of 
        /// those (or both) is degenerate.
        /// </summary>
        /// <param name="s1">The first segment.</param>
        /// <param name="s2">The secong segment.</param>
        /// <returns>returns true, if s1 and s2 are parallel</returns>
        public static bool Parallel(Segment2<EIK> s1, Segment2<EIK> s2)
        {
            return CGALGlobal_EIK_Parallel_Segment2(s1.Ptr, s2.Ptr);
        }

        /// <summary>
        /// returns true, if s1 and s2 are parallel or if one of 
        /// those (or both) is degenerate.
        /// </summary>
        /// <param name="s1">The first segment.</param>
        /// <param name="s2">The secong segment.</param>
        /// <returns>returns true, if s1 and s2 are parallel</returns>
        public static bool Parallel(Segment2<EEK> s1, Segment2<EEK> s2)
        {
            return CGALGlobal_EEK_Parallel_Segment2(s1.Ptr, s2.Ptr);
        }

        //---------------------------------------------------------------------------//
        //                               Version                                     //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int CGALGlobal_VersionNumber();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Index3 CGALGlobal_EigenVersionNumber();

        //---------------------------------------------------------------------------//
        //                               Angle                                       //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ANGLE CGALGlobal_EIK_Angle_Vector2(Vector2d u, Vector2d v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ANGLE CGALGlobal_EIK_Angle_Vector2(IntPtr u, IntPtr v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ANGLE CGALGlobal_EEK_Angle_Vector2(IntPtr u, IntPtr v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ANGLE CGALGlobal_EIK_Angle_Vector3d(Vector3d u, Vector3d v);

        //---------------------------------------------------------------------------//
        //                               ApproxAngle                                 //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double CGALGlobal_EIK_ApproxAngle_Vector3d(Vector3d u, Vector3d v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double CGALGlobal_EIK_ApproxAngle_Vector2(IntPtr u, IntPtr v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double CGALGlobal_EEK_ApproxAngle_Vector2(IntPtr u, IntPtr v);

        //---------------------------------------------------------------------------//
        //                               ApproxDihedralAngle                         //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double CGALGlobal_EIK_ApproxDihedralAngle_Point3(Point3d p, Point3d q, Point3d r, Point3d s);

        //---------------------------------------------------------------------------//
        //                               AreOrderedAlongLine                         //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_AreOrderedAlongLine_Point2d(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_AreOrderedAlongLine_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_AreOrderedAlongLine_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_AreOrderedAlongLine_Point3d(Point3d p, Point3d q, Point3d r);

        //---------------------------------------------------------------------------//
        //                               AreStrictlyOrderedAlongLine                 //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point2d(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point3d(Point3d p, Point3d q, Point3d r);

        //---------------------------------------------------------------------------//
        //                                 Collinear                                 //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Collinear_Point2d(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Collinear_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Collinear_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Collinear_Point3d(Point3d p, Point3d q, Point3d r);

        //---------------------------------------------------------------------------//
        //                                  Barycenter                               //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d CGALGlobal_EIK_Barycenter_Point2d(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr CGALGlobal_EIK_Barycenter_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr CGALGlobal_EEK_Barycenter_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point3d CGALGlobal_EIK_Barycenter_Point3d(Point3d p, Point3d q, Point3d r);

        //---------------------------------------------------------------------------//
        //                               Bisector                                    //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Line2d CGALGlobal_EIK_Bisector_Point3d(Point3d p, Point3d q);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Line2d CGALGlobal_EIK_Bisector_Line2d(Line2d p, Line2d q);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr CGALGlobal_EIK_Bisector_Line2(IntPtr p, IntPtr q);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr CGALGlobal_EEK_Bisector_Line2(IntPtr p, IntPtr q);

        //---------------------------------------------------------------------------//
        //                               Coplanar                                    //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Coplanar_Point3d(Point3d p, Point3d q, Point3d r, Point3d s);

        //---------------------------------------------------------------------------//
        //                            CoplanarOrientation                            //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EIK_CoplanarOrientation_3Point3d(Point3d p, Point3d q, Point3d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EIK_CoplanarOrientation_4Point3d(Point3d p, Point3d q, Point3d r, Point3d s);

        //---------------------------------------------------------------------------//
        //                             EquidistantLine                               //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Line3d CGALGlobal_EIK_EquidistantLine_Line3d(Point3d p, Point3d q, Point3d r);

        //---------------------------------------------------------------------------//
        //                              LeftTurn                                     //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_LeftTurn_Point2d(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_LeftTurn_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_LeftTurn_Point2(IntPtr p, IntPtr q, IntPtr r);

        //---------------------------------------------------------------------------//
        //                               RightTurn                                   //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_RightTurn_Point2d(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_RightTurn_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_RightTurn_Point2(IntPtr p, IntPtr q, IntPtr r);

        //---------------------------------------------------------------------------//
        //                               Orientation                                 //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EIK_Orientation_Point2d(Point2d p, Point2d q, Point2d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EIK_Orientation_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EEK_Orientation_Point2(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EIK_Orientation_Vector2d(Vector2d u, Vector2d v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EIK_Orientation_Vector2(IntPtr p, IntPtr q);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EEK_Orientation_Vector2(IntPtr p, IntPtr q);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EIK_Orientation_Point3d(Point3d p, Point3d q, Point3d r, Point3d s);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION CGALGlobal_EIK_Orientation_Vector3d(Vector3d u, Vector3d v, Vector3d w);

        //---------------------------------------------------------------------------//
        //                              OrthogonalVector                             //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Vector3d CGALGlobal_EIK_OrthogonalVector_Point3d(Point3d p, Point3d q, Point3d r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr CGALGlobal_EIK_OrthogonalVector_Point3(IntPtr p, IntPtr q, IntPtr r);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr CGALGlobal_EEK_OrthogonalVector_Point3(IntPtr p, IntPtr q, IntPtr r);

        //---------------------------------------------------------------------------//
        //                               Parallel                                    //
        //---------------------------------------------------------------------------//

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Parallel_Line2d(Line2d l1, Line2d l2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Parallel_Line2(IntPtr l1, IntPtr l2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Parallel_Line2(IntPtr l1, IntPtr l2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Parallel_Ray2d(Ray2d r1, Ray2d r2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Parallel_Ray2(IntPtr l1, IntPtr l2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Parallel_Ray2(IntPtr l1, IntPtr l2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Parallel_Segment2d(Segment2d s1, Segment2d s2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EIK_Parallel_Segment2(IntPtr l1, IntPtr l2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool CGALGlobal_EEK_Parallel_Segment2(IntPtr l1, IntPtr l2);

    }
}
