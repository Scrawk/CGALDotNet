using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// Plane struct defined by a position and direction.
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry3.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Plane3d : IEquatable<Plane3d>
    {
        /// <summary>
        /// A plane facing the x axis.
        /// </summary>
        public readonly static Plane3d UnitX = new Plane3d(Vector3d.UnitX);

        /// <summary>
        /// A plane facing the y axis.
        /// </summary>
        public readonly static Plane3d UnitY = new Plane3d(Vector3d.UnitY);

        /// <summary>
        /// A plane facing the z axis.
        /// </summary>
        public readonly static Plane3d UnitZ = new Plane3d(Vector3d.UnitZ);

        /// <summary>
        /// The planes position.
        /// </summary>
        public Point3d Position;

        /// <summary>
        /// The planes direction.
        /// </summary>
        public Vector3d Normal;

        /// <summary>
        /// Create a new plane.
        /// </summary>
        /// <param name="normal">The planes direction.</param>
        public Plane3d(Vector3d normal)
        {
            Normal = normal;
            Position = Point3d.Zero;
        }

        /// <summary>
        /// Create a new plane.
        /// </summary>
        /// <param name="position">The planes position.</param>
        /// <param name="normal">The planes direction.</param>
        public Plane3d(Point3d position, Vector3d normal)
        {
            Normal = normal;
            Position = position;
        }

        /// <summary>
        /// Create a new plane.
        /// </summary>
        /// <param name="normal">The planes direction.</param>
        /// <param name="distance">The planes distance from the origin.</param>
        public Plane3d(Vector3d normal, double distance)
        {
            Normal = normal;
            Position = Normal * distance;
        }

        /// <summary>
        /// From three noncollinear points (ordered ccw).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Plane3d(Point3d a, Point3d b, Point3d c)
        {
            Normal = Vector3d.Cross(b - a, c - a);
            Normal.Normalize();
            Position = Normal * Vector3d.Dot(Normal, a);
        }

        /// <summary>
        /// The planes distance from the origin.
        /// </summary>
        public double Distance
        {
            get { return Position.Magnitude; }
        }

        /// <summary>
        /// The planes square distance from the origin.
        /// </summary>
        public double SqrDistance
        {
            get { return Position.SqrMagnitude; }
        }

        /// <summary>
        /// Check if the two planes are equal.
        /// </summary>
        /// <param name="p1">The first plane.</param>
        /// <param name="p2">The second plane.</param>
        /// <returns>True if the planes are equal.</returns>
        public static bool operator ==(Plane3d p1, Plane3d p2)
        {
            return p1.Position == p2.Position && p1.Normal == p2.Normal;
        }

        /// <summary>
        /// Check if the two planes are not equal.
        /// </summary>
        /// <param name="p1">The first plane.</param>
        /// <param name="p2">The second plane.</param>
        /// <returns>True if the planes are not equal.</returns>
        public static bool operator !=(Plane3d p1, Plane3d p2)
        {
            return p1.Position != p2.Position || p1.Normal != p2.Normal;
        }

        /// <summary>
        /// Check if this plane is equal to the other object.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>Are these planes equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Plane3d)) return false;
            Plane3d plane = (Plane3d)obj;
            return this == plane;
        }

        /// <summary>
        /// Check if this plane is equal to the other plane.
        /// </summary>
        /// <param name="plane">The other plane.</param>
        /// <returns>Are these planes equal.</returns>
        public bool Equals(Plane3d plane)
        {
            return this == plane;
        }

        /// <summary>
        /// The planes hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Position.GetHashCode();
                hash = (hash * 16777619) ^ Normal.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The plane as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Plane3d: Positions{0}, Normal={1}]", Position, Normal);
        }

        /// <summary>
        /// The closest point on the plane to the point p.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <returns>The closest point on the plane.</returns>
        public Point3d Closest(Point3d p)
        {
            double t = Vector3d.Dot(Normal, p) - Distance;
            return p - (t * Normal).Point3d;
        }
    }
}
