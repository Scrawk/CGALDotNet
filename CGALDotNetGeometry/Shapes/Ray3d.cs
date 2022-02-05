using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A 2D ray struct represented by a position and a direction.
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry2.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Ray3d : IEquatable<Ray3d>
    {
        /// <summary>
        /// The rays position.
        /// </summary>
        public Point3d Position;

        /// <summary>
        /// The rays direction.
        /// Might not be normalized.
        /// </summary>
        public Vector3d Direction;

        /// <summary>
        /// Construct a ray from a point and the direction.
        /// </summary>
        /// <param name="position">The rays position.</param>
        /// <param name="direction">The rays direction (will be normalized)</param>
        public Ray3d(Point3d position, Vector3d direction)
        {
            Position = position;
            Direction = direction.Normalized;
        }

        /// <summary>
        /// Check if the two rays are equal.
        /// </summary>
        /// <param name="r1">The first ray.</param>
        /// <param name="r2">The second ray.</param>
        /// <returns>True if the two rays are equal.</returns>
        public static bool operator ==(Ray3d r1, Ray3d r2)
        {
            return r1.Position == r2.Position && r1.Direction == r2.Direction;
        }

        /// <summary>
        /// Check if the two rays are not equal.
        /// </summary>
        /// <param name="r1">The first ray.</param>
        /// <param name="r2">The second ray.</param>
        /// <returns>True if the two rays are not equal.</returns>
        public static bool operator !=(Ray3d r1, Ray3d r2)
        {
            return r1.Position != r2.Position || r1.Direction != r2.Direction;
        }

        /// <summary>
        /// Is the ray equal to this object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Is the ray equal to this object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Ray3d)) return false;
            Ray3d ray = (Ray3d)obj;
            return this == ray;
        }

        /// <summary>
        /// Is the ray equal to the other ray.
        /// </summary>
        /// <param name="ray">The over ray.</param>
        /// <returns>Is the ray equal to the other ray.</returns>
        public bool Equals(Ray3d ray)
        {
            return this == ray;
        }

        /// <summary>
        /// The rays hashcode.
        /// </summary>
        /// <returns>The rays hashcode.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Position.GetHashCode();
                hash = (hash * 16777619) ^ Direction.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The rays as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Ray3d: Position={0}, Direction={1}]", Position, Direction);
        }

        /// <summary>
        /// The rays directions magnidute.
        /// </summary>
        public double Magnitude => Direction.Magnitude;

        /// <summary>
        /// The rays directions square magnidute.
        /// </summary>
        public double SqrMagnitude => Direction.SqrMagnitude;

        /// <summary>
        /// Get the position offset along the ray at t.
        /// </summary>
        /// <param name="t">The amount to offset.</param>
        /// <returns>The position at t.</returns>
        public Point3d GetPosition(double t)
        {
            return Position + (t * Direction);
        }

        /// <summary>
        /// Normalize the lines direction.
        /// </summary>
        /// <param name="digits">number of digits to round to.</param>
        public void Normalize()
        {
            Direction.Normalize();
        }

        /// <summary>
        /// Round the rays position and direction.
        /// </summary>
        /// <param name="digits">number of digits to round to.</param>
        public void Round(int digits)
        {
            Position = Position.Rounded(digits);
            Direction = Direction.Rounded(digits);
        }
    }
}

