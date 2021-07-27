using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Circle2d : IEquatable<Circle2d>, IGeometry2d
    {

        public Point2d Center;

        public double Radius;

        public Circle2d(Point2d centre, double radius)
        {
            Center = centre;
            Radius = radius;
        }

        public Circle2d(double x, double y, double radius)
        {
            Center = new Point2d(x, y);
            Radius = radius;
        }

        /// <summary>
        /// The squared radius.
        /// </summary>
        public double Radius2
        {
            get { return Radius * Radius; }
        }

        /// <summary>
        /// The circles diameter.
        /// </summary>
        public double Diameter
        {
            get { return Radius * 2.0; }
        }

        /// <summary>
        /// The circles area.
        /// </summary>
        public double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        /// <summary>
        /// The circles circumference.
        /// </summary>
        public double Circumference
        {
            get { return Math.PI * Radius * 2.0; }
        }

        public static bool operator ==(Circle2d c1, Circle2d c2)
        {
            return c1.Radius == c2.Radius && c1.Center == c2.Center;
        }

        public static bool operator !=(Circle2d c1, Circle2d c2)
        {
            return c1.Radius != c2.Radius || c1.Center != c2.Center;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Circle2d)) return false;
            Circle2d cir = (Circle2d)obj;
            return this == cir;
        }

        public bool Equals(Circle2d cir)
        {
            return this == cir;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Radius.GetHashCode();
                hash = (hash * 16777619) ^ Center.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("[Circle2d: Center={0}, Radius={1}]", Center, Radius);
        }

        /// <summary>
        /// Does the circle contain the point.
        /// </summary>
        /// <param name="p">The point</param>
        /// <returns>true if circle contains point</returns>
        public bool Contains(Point2d p)
        {
            return Point2d.SqrDistance(Center, p) <= Radius2;
        }

        /// <summary>
        /// Does this circle intersect with the other circle.
        /// </summary>
        /// <param name="circle">The other circle</param>
        /// <returns>True if the circles intersect</returns>
        public bool Intersects(Circle2d circle)
        {
            double r = Radius + circle.Radius;
            return Point2d.SqrDistance(Center, circle.Center) <= r * r;
        }
    }
}