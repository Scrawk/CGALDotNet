using System;
using System.Collections.Generic;
using System.Text;

using CGeom2D.Numerics;
using CGeom2D.Geometry;
using CGeom2D.Points;

namespace CGeom2D
{
    public static class Predicates
    {

        /// <summary>
        /// Cross product area of a quadrilateral.
        /// </summary>
        public static Int128 Area2(Point2i a, Point2i b, Point2i c)
        {
            checked
            {
                //return (b.x - a.x) * (c.y - a.y) - (c.x - a.x) * (b.y - a.y);
                return (c.x - a.x) * (b.y - a.y) - (b.x - a.x) * (c.y - a.y);
            }
        }

        /// <summary>
        /// Is b left of the line ac.
        /// </summary>
        public static bool Left(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) > 0;
        }

        /// <summary>
        /// Is b right of the line ac.
        /// </summary>
        public static bool Right(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) < 0;
        }

        /// <summary>
        /// Is b left of or on the line ac.
        /// </summary>
        public static bool LeftOn(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) >= 0;
        }

        /// <summary>
        /// Is b right of or on the line ac.
        /// </summary>
        public static bool RightOn(Point2i a, Point2i b, Point2i c)
        {
            return Area2(a, b, c) <= 0;
        }

        /// <summary>
        /// Do the 3 points form a striaght line.
        /// </summary>
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
            if (LeftOn(a, a0, a1))
                return Left(a, a0, b) && Left(b, a1, a);

            //else a is reflex vertex.
            return !(LeftOn(a, a1, b) && LeftOn(b, a0, a));
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
        /// True if b lies in between the segment ac.
        /// b on a or c is considered between.
        /// </summary>
        public static bool Between(Point2i a, Point2i b, Point2i c)
        {
            if (!Collinear(a, b, c)) return false;

            if (a.x != c.x)
                return (a.x <= b.x && b.x <= c.x) || (a.x >= b.x && b.x >= c.x);
            else
                return (a.y <= b.y && b.y <= c.y) || (a.y >= b.y && b.y >= c.y);
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
