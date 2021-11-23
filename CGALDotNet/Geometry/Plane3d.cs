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

        public readonly static Plane3d UnitX = new Plane3d(Vector3d.UnitX);

        public readonly static Plane3d UnitY = new Plane3d(Vector3d.UnitY);

        public readonly static Plane3d UnitZ = new Plane3d(Vector3d.UnitZ);

        public Point3d Position;

        public Vector3d Normal;

        public Plane3d(Vector3d normal)
        {
            Normal = normal;
            Position = Point3d.Zero;
        }

        public Plane3d(Point3d position, Vector3d normal)
        {
            Normal = normal;
            Position = position;
        }

        public Plane3d(Vector3d normal, double distance)
        {
            Normal = normal;
            Position = Normal * distance;
        }

        /// <summary>
        /// From three noncollinear points (ordered ccw).
        /// </summary>
        public Plane3d(Point3d a, Point3d b, Point3d c)
        {
            Normal = Vector3d.Cross(b - a, c - a);
            Normal.Normalize();
            Position = Normal * Vector3d.Dot(Normal, a);
        }

        public double Distance
        {
            get { return Position.Magnitude; }
        }

        public double SqrDistance
        {
            get { return Position.SqrMagnitude; }
        }

        public static bool operator ==(Plane3d p1, Plane3d p2)
        {
            return p1.Position == p2.Position && p1.Normal == p2.Normal;
        }

        public static bool operator !=(Plane3d p1, Plane3d p2)
        {
            return p1.Position != p2.Position || p1.Normal != p2.Normal;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Plane3d)) return false;
            Plane3d plane = (Plane3d)obj;
            return this == plane;
        }

        public bool Equals(Plane3d plane)
        {
            return this == plane;
        }

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

        public override string ToString()
        {
            return string.Format("[Plane3d: Positions{0}, Normal={1}]", Position, Normal);
        }

        public Point3d Closest(Point3d p)
        {
            double t = Vector3d.Dot(Normal, p) - Distance;
            return p - (t * Normal).Point3d;
        }
    }
}
