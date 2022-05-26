using System;
using System.Collections.Generic;

using CGALDotNet.Polygons;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// Enum for the type of intersection geomerty.
    /// </summary>
    public enum INTERSECTION_RESULT_2D
    {
        NONE,
        POINT2,
        LINE2,
        RAY2,
        SEGMENT2,
        BOX2,
        TRIANGLE2,
        POLYGON2
    }

    /// <summary>
    /// The intersection result struct.
    /// May contain up tp 6 points of data.
    /// </summary>
    public unsafe struct IntersectionResult2d
    {
        /// <summary>
        /// The point data for the intersection.
        /// Represents up to 6 points in xy order.
        /// </summary>
        private fixed double Data[12];

        /// <summary>
        /// The number of points of data used.
        /// </summary>
        private int Count;

        /// <summary>
        /// Was there a intersection.
        /// </summary>
        public bool Hit => Type != INTERSECTION_RESULT_2D.NONE;

        /// <summary>
        /// Is the intersection a polygon.
        /// </summary>
        public bool IsPolygon => Type == INTERSECTION_RESULT_2D.POLYGON2;

        /// <summary>
        /// The intersection geometry type.
        /// </summary>
        public INTERSECTION_RESULT_2D Type;

        /// <summary>
        /// Array accessor for the point data.
        /// </summary>
        /// <param name="i">The array index from 0 to 6.</param>
        /// <returns>The point at index i.</returns>
        public Point2d this[int i]
        {
            get
            {
                if ((uint)i >= 6)
                    throw new IndexOutOfRangeException("IntersectionResult2d index out of range.");

                fixed (IntersectionResult2d* array = &this) { return ((Point2d*)array)[i]; }
            }
        }

        /// <summary>
        /// Results information as string.
        /// </summary>
        /// <returns>esults information as string</returns>
        public override string ToString()
        {
            return string.Format("[IntersectionResult2d: Type={0}, Count={1}]", Type, Count);
        }

        /// <summary>
        /// If result type was point get the point geometry.
        /// </summary>
        public Point2d Point => this[0];

        /// <summary>
        /// If result type was line get the line geometry.
        /// </summary>
        public Line2d Line => new Line2d(Data[0], Data[1], Data[2]);

        /// <summary>
        /// If result type was ray get the ray geometry.
        /// </summary>
        public Ray2d Ray => new Ray2d(this[0], this[1]);

        /// <summary>
        /// If result type was segment get the segment geometry.
        /// </summary>
        public Segment2d Segment => new Segment2d(this[0], this[1]);

        /// <summary>
        /// If result type was box get the box geometry.
        /// </summary>
        public Box2d Box => new Box2d(this[0], this[1]);

        /// <summary>
        /// If result type was triangle get the triangle geometry.
        /// </summary>
        public Triangle2d Triangle => new Triangle2d(this[0], this[1], this[2]);

        /// <summary>
        /// If result type was polygon get the points that
        /// make up the polygon geometry.
        /// Should only ever have at most 6 points.
        /// </summary>
        public Point2d[] PolygonPoints
        {
            get
            {
                if (Count > 6)
                    throw new Exception("Unexpected number of polygon points.");

                if (!IsPolygon)
                    throw new Exception("Intersection not a polygon.");

                var points = new Point2d[Count];
                for (int i = 0; i < Count; i++)
                    points[i] = this[i];

                return points;
            }
        }

        /// <summary>
        /// The intersection result as a polygon.
        /// </summary>
        /// <typeparam name="K">The polygons kernel.</typeparam>
        /// <returns>The polygon.</returns>
        public Polygon2<K> Polygon<K>() where K : CGALKernel, new()
        {
            return new Polygon2<K>(PolygonPoints);
        }

    }
}
