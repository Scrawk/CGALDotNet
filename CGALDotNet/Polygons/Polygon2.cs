using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;

namespace CGALDotNet.Polygons
{
    [Flags]
    public enum POLYGON_CHECK
    {
        NONE = 0,
        ARRAY_BOUNDS = 1,
        IS_VALID_HOLE = 2,
        IS_VALID_BOUNDARY = 4,
        ALL = ~0
    }

    /// <summary>
    /// Generic polygon definition.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class Polygon2<K> : Polygon2 where K : CGALKernel, new() 
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Polygon2() : base(new K())
        {

        }

        /// <summary>
        /// Create from a set of points.
        /// </summary>
        /// <param name="points">The polygons points.</param>
        public Polygon2(Point2d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polygons pointer.</param>
        internal Polygon2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polygon as a string.
        /// </summary>
        /// <returns>The polygon as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Polygon2<{0}>: Count={1}, IsSimple={2}, Orientation={3}]",
                Kernel.Name, Count, IsSimple, Orientation);
        }

        /// <summary>
        /// Copy the polygon.
        /// </summary>
        /// <returns>The copied polygon.</returns>
        public Polygon2<K> Copy()
        {
            var copy = new Polygon2<K>(Kernel.Copy(Ptr));
            copy.Update(IsSimple, Orientation);
            return copy;
        }

        /// <summary>
        /// Triangulate the polygon.
        /// </summary>
        /// <param name="indices">The triangle indices.</param>
        public void Triangulate(List<int> indices)
        {
            var ct = new ConstrainedTriangulation2<K>();
            ct.InsertPolygonConstraint(this);
            ct.GetConstrainedDomainIndices(indices);
        }

        /// <summary>
        /// Do the polygons intersect.
        /// </summary>
        /// <param name="polygon">The other polygon.</param>
        /// <returns>Do the polygons intersect.</returns>
        public bool Intersects(Polygon2<K> polygon)
        {
            return PolygonBoolean2<K>.Instance.DoIntersect(this, polygon);
        }

        /// <summary>
        /// Do the polygons intersect.
        /// </summary>
        /// <param name="polygon">The other polygon.</param>
        /// <returns>Do the polygons intersect.</returns>
        public bool Intersects(PolygonWithHoles2<K> polygon)
        {
            return PolygonBoolean2<K>.Instance.DoIntersect(this, polygon);
        }

    }

    /// <summary>
    /// The abstract polygon definition.
    /// </summary>
    public abstract class Polygon2 : CGALObject, IEnumerable<Point2d>
    {

        /// <summary>
        /// Is the polygon simple.
        /// Must be updated to find if simple.
        /// </summary>
        private bool m_isSimple;

        /// <summary>
        /// The polygons orientation.
        /// Must be updated to find orientation.
        /// </summary>
        private ORIENTATION m_orientation;

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Polygon2()
        {
            
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polygon kernel.</param>
        internal Polygon2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polygon kernel.</param>
        /// <param name="points">The points to construct from.</param>
        internal Polygon2(CGALKernel kernel, Point2d[] points)
        {
            Kernel = kernel.PolygonKernel2;
            Ptr = Kernel.Create();
            SetPoints(points);
            Count = points.Length;
            Update();
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polygon kernel.</param>
        /// <param name="ptr">The polygons pointer.</param>
        internal Polygon2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonKernel2;
            Count = Kernel.Count(Ptr);
            Update();
        }

        /// <summary>
        /// The number of points in the polygon.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Is this a simple polygon.
        /// Certains actions can only be carried out on simple polygons.
        /// </summary>
        public bool IsSimple
        {
            get
            {
                Update();
                return m_isSimple;
            }
            protected set
            {
                m_isSimple = value;
            }
        }

        /// <summary>
        /// The polygons orientation.
        /// Certain actions depend on the polygons orientation.
        /// </summary>
        public ORIENTATION Orientation
        {
            get
            {
                Update();
                return m_orientation;
            }
            protected set
            {
                m_orientation = value;
            }
        }

        /// <summary>
        /// The orientation expressed as the clock direction.
        /// </summary>
        public CLOCK_DIR ClockDir => (CLOCK_DIR)Orientation;

        /// <summary>
        /// Is the polygon degenerate.
        /// Polygons with < 3 points are degenerate.
        /// </summary>
        public bool IsDegenerate => Count < 3 || Orientation == ORIENTATION.ZERO;

        /// <summary>
        /// Is the polygon cw orientated.
        /// </summary>
        public bool IsClockWise => ClockDir == CLOCK_DIR.CLOCKWISE;

        /// <summary>
        /// Is the polygon ccw orientated.
        /// </summary>
        public bool IsCounterClockWise => ClockDir == CLOCK_DIR.COUNTER_CLOCKWISE;

        /// <summary>
        /// Is the polygon updated.
        /// </summary>
        protected bool IsUpdated { get; set; }

        /// <summary>
        /// The polygons kernel.
        /// Contains the functions to the unmanaged CGAL polygon.
        /// </summary>
        protected private PolygonKernel2 Kernel { get; private set; }

        /// <summary>
        /// What checks should the polygon do.
        /// </summary>
        public POLYGON_CHECK CheckFlag = POLYGON_CHECK.ALL;

        /// <summary>
        /// Array accessor for the polygon.
        /// Getting a point wraps around the polygon.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Point2d this[int i]
        {
            get => GetPointWrapped(i);
            set => SetPoint(i, value);
        }

        /// <summary>
        /// Clear the polygon of all points.
        /// </summary>
        public void Clear()
        {
            Count = 0;
            Kernel.Clear(Ptr);
            Update(false, ORIENTATION.ZERO);
        }

        /// <summary>
        /// Get the point a the index.
        /// </summary>
        /// <param name="index">The points index to get.</param>
        /// <returns>The point at index.</returns>
        public Point2d GetPoint(int index)
        {
            if(CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(index, Count);
                
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get the point at the index
        /// and wrap around the polygon.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <returns>The point at the index.</returns>
        public Point2d GetPointWrapped(int index)
        {
            index = CGALGlobal.Wrap(index, Count);
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get the point at the index
        /// and clamp to the polygons last point.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <returns>The point at the index.</returns>
        public Point2d GetPointClamped(int index)
        {
            index = CGALGlobal.Clamp(index, 0, Count - 1);
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get all the points in the polygon.
        /// </summary>
        /// <param name="points">The point array to copy the data into.</param>
        public void GetPoints(Point2d[] points)
        {
            if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(points, 0, Count);

            Kernel.GetPoints(Ptr, points, 0, Count);
        }

        /// <summary>
        /// Get all the polygon segments.
        /// </summary>
        /// <param name="segments">The segment array to copy the data into.</param>
        public void GetSegments(Segment2d[] segments)
        {
            if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(segments, 0, Count);

            Kernel.GetSegments(Ptr, segments, 0, Count);
        }

        /// <summary>
        /// Get all the polygon points.
        /// </summary>
        /// <param name="points">The list to copy the data into.</param>
        public void GetPoints(List<Point2d> points)
        {
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(i));
        }

        /// <summary>
        /// Set the points at the index.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <param name="point">The points value.</param>
        public void SetPoint(int index, Point2d point)
        {
            if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(index, Count);

            Kernel.SetPoint(Ptr, index, point);
            IsUpdated = false;
        }

        /// <summary>
        /// Set the points from the array.
        /// If the array is larger than the polygon then 
        /// the new points will be appended to end of polygon.
        /// </summary>
        /// <param name="points">The points array.</param>
        public void SetPoints(Point2d[] points)
        {
            int count = Math.Max(Count, points.Length);

            if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(points, 0, count);

            Kernel.SetPoints(Ptr, points, 0, count);
            Count = count;
            IsUpdated = false;
        }

        /// <summary>
        /// Reverse the polygon.
        /// Swithches the orientation.
        /// </summary>
        public void Reverse()
        {
            Kernel.Reverse(Ptr);
            m_orientation = CGALEnum.Opposite(m_orientation);
        }

        /// <summary>
        /// Find the bounding box for the polygon.
        /// </summary>
        /// <returns>The bounding box.</returns>
        public Box2d FindBoundingBox()
        {
            return Kernel.GetBoundingBox(Ptr);
        }

        /// <summary>
        /// Find if the polygon is simple.
        /// </summary>
        /// <returns>True if simple.</returns>
        public bool FindIfSimple()
        {
            if (Count < 3)
                return false;
            else
                return Kernel.IsSimple(Ptr);
        }

        /// <summary>
        /// Find if the polygon is convex.
        /// Must be simple to determine.
        /// </summary>
        /// <returns>True if the polygon is convex.</returns>
        public bool FindIfConvex()
        {
            if (IsSimple)
                return Kernel.IsConvex(Ptr);
            else
                return false;
        }

        /// <summary>
        /// Find the polygons orientation.
        /// Must be simple to determine.
        /// </summary>
        /// <returns>The polygons orientations.</returns>
        public ORIENTATION FindOrientation()
        {
            if (IsSimple)
                return Kernel.Orientation(Ptr);
            else
                return ORIENTATION.ZERO;
        }

        /// <summary>
        /// Find the orientated side the point lies on.
        /// Must be simple to determine.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The orientated side of the polygon the point is on.</returns>
        public ORIENTED_SIDE OrientedSide(Point2d point)
        {
            if (IsSimple)
                return Kernel.OrientedSide(Ptr, point);
            else
                return ORIENTED_SIDE.UNDETERMINED;
        }

        /// <summary>
        /// Find the bounded side the point lies on.
        /// Must be simple to determine.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The bounded side of the polygon the point is on.</returns>
        public BOUNDED_SIDE BoundedSide(Point2d point)
        {
            if (IsSimple)
                return Kernel.BoundedSide(Ptr, point);
            else
                return BOUNDED_SIDE.UNDETERMINED;
        }

        /// <summary>
        /// Find the polygons signed area. 
        /// Must be simple to determine.
        /// </summary>
        /// <returns>The signed area is positive if polygon is ccw 
        /// and negation if cw.</returns>
        public double FindSignedArea()
        {
            if (IsSimple)
                return Kernel.SignedArea(Ptr);
            else
                return 0;
        }

        /// <summary>
        /// The area of the polygon.
        /// Must be simple to determine.
        /// </summary>
        /// <returns>The abs of the signed area.</returns>
        public double FindArea()
        {
            return Math.Abs(FindSignedArea());
        }

        /// <summary>
        /// Does the polygon contain the points.
        /// Must be simple to determine.
        /// </summary>
        /// <param name="point">The point to find.</param>
        /// <param name="inculdeBoundary">Does the point on the boundary count</param>
        /// <returns>True if the point is inside the polygon.</returns>
        public bool ContainsPoint(Point2d point, bool inculdeBoundary = true)
        {
            if (IsSimple)
                 return Kernel.ContainsPoint(Ptr, point, Orientation, inculdeBoundary);
            else
                return false;
        }

        /// <summary>
        /// Translate the polygon.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Translate(Ptr, translation);
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        public void Rotate(Radian rotation)
        {
            Kernel.Rotate(Ptr, rotation.angle);
        }

        /// <summary>
        /// Scale the polygon.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Scale(Ptr, scale);
            IsUpdated = false;
        }

        /// <summary>
        /// Transform the polygon with a TRS matrix.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point2d translation, Radian rotation, double scale)
        {
            Kernel.Transform(Ptr, translation, rotation.angle, scale);
            IsUpdated = false;
        }

        /// <summary>
        /// Enumerate all points in the polygon.
        /// </summary>
        /// <returns>Each point in polygon.</returns>
        public IEnumerator<Point2d> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return GetPoint(i);
        }

        /// <summary>
        /// Enumerate all points in the polygon.
        /// </summary>
        /// <returns>Each point in polygon.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Return all the points in the polygon in a array.
        /// </summary>
        /// <returns>The array.</returns>
        public Point2d[] ToArray()
        {
            var points = new Point2d[Count];
            GetPoints(points);
            return points;
        }

        /// <summary>
        /// Return all the points in the polygon in a list.
        /// </summary>
        /// <returns>The list.</returns>
        public List<Point2d> ToList()
        {
            var points = new List<Point2d>(Count);
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(i));

            return points;
        }

        /// <summary>
        /// Print the polygon.
        /// </summary>
        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// Print the polygon into a styring builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Print(StringBuilder builder)
        {
            Update();
            builder.AppendLine(ToString());
            builder.AppendLine("Is convex = " + FindIfConvex());
            builder.AppendLine("Signed Area = " + FindSignedArea());
            builder.AppendLine("Area = " + FindArea());
        }

        /// <summary>
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

        /// <summary>
        /// Update the polygon if needed.
        /// </summary>
        protected void Update()
        {
            if (IsUpdated) return;
            IsUpdated = true;

            if (FindIfSimple())
            {
                IsSimple = true;
                Orientation = FindOrientation();
            }
            else
            {
                IsSimple = false;
                Orientation = ORIENTATION.ZERO;
            }
        }

        /// <summary>
        /// Update the polygon directly without calling the update
        /// function.
        /// </summary>
        /// <param name="isSimple">Is the polygon simepl.</param>
        /// <param name="orientation">The polygons orientation.</param>
        protected void Update(bool isSimple, ORIENTATION orientation)
        {
            IsSimple = isSimple;
            Orientation = orientation;
            IsUpdated = true;
        }

    }
}
