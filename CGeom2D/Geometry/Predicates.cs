using System;
using System.Collections.Generic;
using System.Text;

using CGeom2D.Numerics;

namespace CGeom2D.Geometry
{
    public static class Predicates
    {

        /// <summary>
        /// Cross product area of a quadrilateral.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Int128 Area2(Point2i a, Point2i b, Point2i c)
        {
            return (b.x - a.x) * (c.y - a.y) - (c.x - a.x) * (b.y - a.y);
        }

        /// <summary>
        /// Is c left of the line ab.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool Left(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) > 0;
        }

        /// <summary>
        /// Is c right of the line ab.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool Right(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) < 0;
        }

        /// <summary>
        /// Is c left of or on the line ab.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool LeftOn(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) >= 0;
        }

        /// <summary>
        /// Is c right of or on the line ab.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool RightOn(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) <= 0;
        }

        /// <summary>
        /// Do the 3 points form a striaght line.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool Collinear(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) == 0;
        }

        /// <summary>
        /// True if b is within the cone formed by the
        /// edges incident at the from vertex of edge.
        /// </summary>
        public static bool InCone(Point2i a0, Point2i a, Point2i a1, Point2i b)
        {
            //if a is a convex vertex.
            if (LeftOn(a, a1, a0))
                return Left(a, b, a0) && Left(b, a, a1);

            //else a is reflex vertex.
            return !(LeftOn(a, b, a1) && LeftOn(b, a, a0));
        }

        /// <summary>
        /// Returns true if the two segments intersect
        /// and are not collinear. Does not handle point
        /// on segment cases.
        /// </summary>
        public static bool IntersectsProper(Segment2i ab, Segment2i cd)
        {
            if (Collinear(ab.A, ab.B, cd.C)) return false;
            if (Collinear(ab.A, ab.B, cd.D)) return false;
            if (Collinear(cd.C, cd.D, ab.A)) return false;
            if (Collinear(cd.C, cd.D, ab.B)) return false;

            return Xor(Left(ab.A, ab.B, cd.C), Left(ab.A, ab.B, cd.D)) &&
                   Xor(Left(cd.C, cd.D, ab.A), Left(cd.C, cd.D, ab.B));
        }

        /// <summary>
        /// True if the segments intersect.
        /// Handles all edge cases.
        /// Collinear segments count as no intersection.
        /// </summary>
        public static bool Intersects(Segment2i ab, Segment2i cd)
        {
            if (IntersectsProper(ab, cd) || Between(ab, cd))
                return true;
            else
                return false;
        }

        /// <summary>
        /// True if any end point of the segments are 
        /// in between the other segment.
        /// Point on point is considered between.
        /// </summary>
        public static bool Between(Segment2i ab, Segment2i cd)
        {
            if (Between(ab.A, ab.B, cd.C)) return true;
            if (Between(ab.A, ab.B, cd.D)) return true;
            if (Between(cd.C, cd.D, ab.A)) return true;
            if (Between(cd.C, cd.D, ab.B)) return true;
            return false;
        }

        /// <summary>
        /// True if c lies in between the segment ab.
        /// c on a or b is considered between.
        /// </summary>
        public static bool Between(Point2i a, Point2i b, Point2i c)
        {
            if (!Collinear(a, b, c)) return false;

            if (a[0] != b[0])
                return (a[0] <= c[0] && c[0] <= b[0]) || (a[0] >= c[0] && c[0] >= b[0]);
            else
                return (a[1] <= c[1] && c[1] <= b[1]) || (a[1] >= c[1] && c[1] >= b[1]);
        }

        /// <summary>
        /// True if only one argument is true.
        /// </summary>
        private static bool Xor(bool x, bool y)
        {
            return !x ^ !y;
        }

    }
}
