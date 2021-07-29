using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Line3d : IEquatable<Line3d>
    {

        public Point2d Position;
        public Vector2d Direction;

        public Line3d(Point2d position, Vector2d direction)
        {
            Position = position;
            Direction = direction;
        }

        public static bool operator ==(Line3d i1, Line3d i2)
        {
            return i1.Position == i2.Position && i1.Direction == i2.Direction;
        }

        public static bool operator !=(Line3d i1, Line3d i2)
        {
            return i1.Position != i2.Position || i1.Direction != i2.Direction;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Line3d)) return false;
            Line3d line = (Line3d)obj;
            return this == line;
        }

        public bool Equals(Line3d line)
        {
            return this == line;
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
            return string.Format("[Line3d: Position={0}, Direction={1}]", Position, Direction);
        }


    }

}
