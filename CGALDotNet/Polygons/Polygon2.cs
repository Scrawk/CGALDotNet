using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;
using CGALDotNet.Meshing;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Polygons
{

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
                Kernel.KernelName, Count, IsSimple, Orientation);
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
        public override void Triangulate(List<int> indices)
        {
            try
            {
                var ct = ConstrainedTriangulation2<K>.Instance;
                ct.InsertConstraint(this);
                ct.GetConstrainedDomainIndices(indices);
                ct.Clear();
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { }
        }

        /// <summary>
        /// Do the polygons intersect.
        /// </summary>
        /// <param name="polygon">The other polygon.</param>
        /// <returns>Do the polygons intersect.</returns>
        public bool Intersects(Polygon2<K> polygon)
        {
            try
            {
                return PolygonBoolean2<K>.Instance.DoIntersect(this, polygon);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { }

            return false;
        }

        /// <summary>
        /// Do the polygons intersect.
        /// </summary>
        /// <param name="polygon">The other polygon.</param>
        /// <returns>Do the polygons intersect.</returns>
        public bool Intersects(PolygonWithHoles2<K> polygon)
        {
            try
            {
                return PolygonBoolean2<K>.Instance.DoIntersect(this, polygon);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { }

            return false;
        }

        /// <summary>
        /// Refine the polygon to a triangulation.
        /// Does not modify this polygon.
        /// </summary>
        /// <param name="lengthBounds">Upper bound on the length of the longest edge.</param>
        /// <returns>The base triangulation.</returns>
        public DelaunayTriangulation2<K> Refine(double lengthBounds)
        {
            return Refine(ConformingTriangulation2.MAX_ANGLE_BOUNDS, lengthBounds);
        }

        /// <summary>
        /// Refine the polygon to a triangulation.
        /// Does not modify this polygon.
        /// </summary>
        /// <param name="angleBounds">Default shape bound. 0.125 corresponds to abound 20.6 degree. Max 0.125 value.</param>
        /// <param name="lengthBounds">Upper bound on the length of the longest edge.</param>
        /// <returns>The base triangulation.</returns>
        public DelaunayTriangulation2<K> Refine(double angleBounds, double lengthBounds)
        {
            try
            {
                var ct = ConformingTriangulation2<K>.Instance;
                ct.InsertConstraint(this);
                ct.Refine(angleBounds, lengthBounds);

                int count = ct.VertexCount;
                var points = ArrayCache.Point2dArray(count);
                ct.GetPoints(points, count);
                ct.Clear();

                return new DelaunayTriangulation2<K>(points);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { }

            return new DelaunayTriangulation2<K>();
        }

        /// <summary>
        /// Partition the polygon into convex pieces.
        /// Does not modify this polygon.
        /// </summary>
        /// <param name="results">The convex partition.</param>
        /// <param name="type">The type of partition method.</param>
        public void Partition(List<Polygon2<K>> results, POLYGON_PARTITION type = POLYGON_PARTITION.GREENE_APROX_CONVEX)
        {
            try
            {
                var part = PolygonPartition2<K>.Instance;
                part.Partition(type, this, results);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { }
        }

        /// <summary>
        /// Simplify the polygon.
        /// </summary>
        /// <param name="threshold">The simplification threshold.</param>
        public void Simplify(double threshold)
        {
            var param = PolygonSimplificationParams.Default;
            param.threshold = threshold;
            Simplify(param);
        }

        /// <summary>
        /// Simplify the polygon.
        /// </summary>
        /// <param name="param">The simplification parameters.</param>
        public void Simplify(PolygonSimplificationParams param)
        {
            try
            {
                var sim = PolygonSimplification2<K>.Instance;
                var ptr = sim.SimplifyPtr(this, param);
                Swap(ptr);
                IsUpdated = false;
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { }
        }

        /// <summary>
        /// offset the polygon. Does not modify this polygon.
        /// </summary>
        /// <param name="offset">The type of offset.</param>
        /// <param name="amount">The amount to offset.</param>
        /// <param name="results">The offset results.</param>
        public void Offset(OFFSET offset, double amount, List<Polygon2<K>> results)
        {
            try
            {
                var off = PolygonOffset2<K>.Instance;
                off.CreateOffset(offset, this, amount, results);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { }
        }

        /// <summary>
        /// Create a polyhedron3 mesh with one polygon face.
        /// </summary>
        /// <param name="xz">Should the y coord of the points be used for the z coord.</param>
        /// <returns>The new polyhedron mesh</returns>
        /// <exception cref="InvalidOperationException">Thrown if the polygon is not simple.</exception>
        public Polyhedron3<K> ToPolyhedron3(bool xz)
        {
            if (!IsSimple)
                throw new InvalidOperationException("Polygon must be simple to convert to polyhedron mesh.");

            var poly = new Polyhedron3<K>();
            poly.CreatePolygonMesh(this, xz);
            return poly;
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
            SetPoints(points, points.Length);
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
        /// Mark th mesh as needing to be updated.
        /// </summary>
        public void SetIsUpdatedToFalse()
        {
            IsUpdated = false;
        }

        /// <summary>
        /// Valid polygons should be simple and ccw 
        /// for most algorithms to work on them.
        /// </summary>
        public bool IsValid()
        {
            return IsSimple && IsCounterClockWise;
        }

        /// <summary>
        /// Valid hole polygons should be simple
        /// and cw to add to a polygon with holes.
        /// </summary>
        public bool IsValidHole()
        {
            return IsSimple && IsClockWise;
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
        /// <param name="count">The array length.</param>
        public void GetPoints(Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
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
        /// Triangulate the polygon.
        /// </summary>
        /// <param name="indices">The triangle indices.</param>
        public abstract void Triangulate(List<int> indices);

        /// <summary>
        /// Get all the polygon segments.
        /// </summary>
        /// <param name="segments">The segment array to copy the data into.</param>
        /// <param name="count">The array length.</param>
        public void GetSegments(Segment2d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);
            Kernel.GetSegments(Ptr, segments, count);
        }

        /// <summary>
        /// Set the points at the index.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <param name="point">The points value.</param>
        public void SetPoint(int index, Point2d point)
        {
            Kernel.SetPoint(Ptr, index, point);
            IsUpdated = false;
        }

        /// <summary>
        /// Set the points from the array.
        /// If the array is larger than the polygon then 
        /// the new points will be appended to end of polygon.
        /// </summary>
        /// <param name="points">The points array.</param>
        /// <param name="count">The array length.</param>
        public void SetPoints(Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.SetPoints(Ptr, points, count);
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
            IsUpdated = false;
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        public void Rotate(Radian rotation)
        {
            Kernel.Rotate(Ptr, rotation.angle);
            IsUpdated = false;
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
            GetPoints(points, points.Length);
            return points;
        }

        /// <summary>
        /// Convert the polygon to a new polygon with a different kernel.
        /// May result in different values due to precision issues.
        /// </summary>
        /// <typeparam name="T">The new kernel type.</typeparam>
        /// <returns>The new polygon.</returns>
        public Polygon2<T> Convert<T>() where T : CGALKernel, new()
        {
            var points = ArrayCache.Point2dArray(Count);
            GetPoints(points, Count);
            return new Polygon2<T>(points);
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
        /// Print the polygon into a styring builder.
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            Update();
            builder.AppendLine(ToString());
            builder.AppendLine("Is convex = " + FindIfConvex());
            builder.AppendLine("Signed Area = " + FindSignedArea());
            builder.AppendLine("Area = " + FindArea());
            builder.AppendLine("CCW = " + IsCounterClockWise);
        }

        /// <summary>
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

        /// <summary>
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr(IntPtr ptr)
        {
            Kernel.Release(ptr);
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
