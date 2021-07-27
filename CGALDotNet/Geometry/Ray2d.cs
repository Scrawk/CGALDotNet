using System;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Ray2d : IEquatable<Ray2d>, IGeometry2d
    {

        public Point2d Position;

        public Vector2d Direction;

        public Ray2d(Point2d position, Vector2d direction)
        {
            Position = position;
            Direction = direction.Normalized;
        }

        public static bool operator ==(Ray2d r1, Ray2d r2)
        {
            return r1.Position == r2.Position && r1.Direction == r2.Direction;
        }

        public static bool operator !=(Ray2d r1, Ray2d r2)
        {
            return r1.Position != r2.Position || r1.Direction != r2.Direction;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ray2d)) return false;
            Ray2d ray = (Ray2d)obj;
            return this == ray;
        }

        public bool Equals(Ray2d ray)
        {
            return this == ray;
        }

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

        public override string ToString()
        {
            return string.Format("[Ray2d: Position={0}, Direction={1}]", Position, Direction);
        }

        /// <summary>
        /// Get the position offset along the ray at t.
        /// </summary>
        /// <param name="t">The amount to offset.</param>
        /// <returns>The position at t.</returns>
        public Point2d GetPosition(double t)
        {
            return Position + (Point2d)(t * Direction);
        }

        /// <summary>
        /// Transform the ray by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix2x2d m)
        {
            Position = m * Position;
            Direction = m * Direction;
        }

        /// <summary>
        /// Transform the ray by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix3x3d m)
        {
            Position = m * Position;
            Direction = m * Direction;
        }

        /// <summary>
        /// Transform the ray by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix4x4d m)
        {
            Position = m * Position;
            Direction = m * Direction;
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

