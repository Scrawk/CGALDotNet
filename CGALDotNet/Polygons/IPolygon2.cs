using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet;
using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public interface IPolygon2
    {

        /// <summary>
        /// The number of points in the polygon.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Is this a simple polygon.
        /// Certains actions can only be carried out on sime polygons.
        /// </summary>
        bool IsSimple { get; }

        /// <summary>
        /// The polygons orientation.
        /// Certain actions depend on the polygons orientation.
        /// </summary>
        CGAL_ORIENTATION Orientation { get; }

        /// <summary>
        /// The orientation expressed as the clock direction.
        /// </summary>
        CGAL_CLOCK_DIR ClockDir => (CGAL_CLOCK_DIR)Orientation;

        /// <summary>
        /// Is the polygon degenerate.
        /// Polygons with < 3 points are degenerate.
        /// </summary>
        bool IsDegenerate => Count < 3 || Orientation == CGAL_ORIENTATION.ZERO;

        /// <summary>
        /// Is the polygon cw orientated.
        /// </summary>
        bool IsClockWise => ClockDir == CGAL_CLOCK_DIR.CLOCKWISE;

        /// <summary>
        /// Is the polygon ccw orientated.
        /// </summary>
        bool IsCounterClockWise => ClockDir == CGAL_CLOCK_DIR.COUNTER_CLOCKWISE;

        /// <summary>
        /// Clear the polygon of all points.
        /// </summary>
        void Clear();

        /// <summary>
        /// Reverse the polygon.
        /// Swithches the orientation.
        /// </summary>
        void Reverse();

        /// <summary>
        /// Does the polygon contain the points.
        /// Must be simple to determine.
        /// </summary>
        /// <param name="point">The point to find.</param>
        /// <param name="inculdeBoundary">Does the point on the boundary count</param>
        /// <returns>True if the point is inside the polygon.</returns>
        bool ContainsPoint(Point2d point, bool inculdeBoundary = true);

        /// <summary>
        /// Translate the polygon.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        void Translate(Point2d translation);

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        void Rotate(Radian rotation);

        /// <summary>
        /// Scale the polygon.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        void Scale(double scale);

        /// <summary>
        /// Transform the polygon with a TRS matrix.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        void Transform(Point2d translation, Radian rotation, double scale);

        /// <summary>
        /// Print the polygon.
        /// </summary>
        void Print();

        /// <summary>
        /// Print the polygon into a styring builder.
        /// </summary>
        /// <param name="builder"></param>
        void Print(StringBuilder builder);
    }
}
