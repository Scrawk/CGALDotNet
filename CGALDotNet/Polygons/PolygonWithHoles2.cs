using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Triangulations;

namespace CGALDotNet.Polygons
{
    /// <summary>
    /// Polygon with holes consists of a boundary and holes.
    /// </summary>
    public enum POLYGON_ELEMENT 
    { 
        BOUNDARY, 
        HOLE
    }

    /// <summary>
    /// Generic polygon definition.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class PolygonWithHoles2<K> : PolygonWithHoles2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Default constuctor.
        /// </summary>
        public PolygonWithHoles2() : base(new K())
        {

        }

        /// <summary>
        /// Construct polygon with the boundary.
        /// </summary>
        /// <param name="boundary">A CCW polygon.</param>
        public PolygonWithHoles2(Polygon2<K> boundary) : base(new K(), boundary)
        {

        }

        /// <summary>
        /// Construct polygon with the boundary points
        /// </summary>
        /// <param name="boundary">A CCW set of points.</param>
        public PolygonWithHoles2(Point2d[] boundary) : base(new K(), boundary)
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polygons pointer.</param>
        internal PolygonWithHoles2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polygon as a string.
        /// </summary>
        /// <returns>The polygon as a string.</returns>
        public override string ToString()
        {
            return string.Format("[PolygonWithHoles2<{0}>: IsBounded={1}, PointCount={2}, HoleCount={3}]", 
                Kernel.Name, IsBounded, Count, HoleCount);
        }

        /// <summary>
        /// Create a deep copy of the polygon.
        /// </summary>
        /// <returns>The copy.</returns>
        public PolygonWithHoles2<K> Copy()
        {
            return new PolygonWithHoles2<K>(Kernel.Copy(Ptr));
        }

        /// <summary>
        /// Create a deep copy of the polygon element.
        /// </summary>
        /// <param name="element">The element type to copy.</param>
        /// <param name="index">If element os a hole thiss is the holes index.</param>
        /// <returns>The copy.</returns>
        public Polygon2<K> Copy(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                if (IsUnbounded)
                    return new Polygon2<K>();

                var ptr = Kernel.CopyPolygon(Ptr, BOUNDARY_INDEX);
                if (ptr != IntPtr.Zero)
                    return new Polygon2<K>(ptr);
                else
                    throw new InvalidOperationException("Failed to find boundary.");
            }
            else
            {
                if(index < 0 || index >= HoleCount)
                    throw new ArgumentOutOfRangeException("Hole index must be > 0 and < HoleCount.");

                return new Polygon2<K>(Kernel.CopyPolygon(Ptr, index));
            }
        }

        /// <summary>
        /// Get the boundary as a copy.
        /// If unbounded will return a empty polygon.
        /// </summary>
        /// <returns>A copy of the hole polygon.</returns>
        public Polygon2<K> GetBoundary()
        {
            return Copy(POLYGON_ELEMENT.BOUNDARY);
        }

        /// <summary>
        /// Get the hole as a copy.
        /// </summary>
        /// <param name="index">The holes index</param>
        /// <returns>A copy of the hole polygon.</returns>
        public Polygon2<K> GetHole(int index)
        {
            return Copy(POLYGON_ELEMENT.HOLE, index);
        }

        /// <summary>
        /// Add a polygon as a holes.
        /// Holes must simple and CW.
        /// </summary>
        /// <param name="polygon">The hole polygon.</param>
        public void AddHole(Polygon2<K> polygon)
        {
            Kernel.AddHoleFromPolygon(Ptr, polygon.Ptr);
            HoleCount++;
        }

        /// <summary>
        /// Create a copy of boundary and hole polygons.
        /// </summary>
        /// <returns>The list of polygons.</returns>
        public List<Polygon2<K>> ToList()
        {
            int count = HoleCount;
            if (IsBounded)
                count++;

            var polygons = new List<Polygon2<K>>(count);

            if (IsBounded)
                polygons.Add(GetBoundary());

            for (int i = 0; i < HoleCount; i++)
                polygons.Add(GetHole(i));

            return polygons;
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
                return PolygonBoolean2<K>.Instance.DoIntersect(polygon, this);
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
                return PolygonBoolean2<K>.Instance.DoIntersect(polygon, this);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { }

            return false;
        }

        /// <summary>
        /// Connect all the holes of the polygon 
        /// and return as a polygon. 
        /// Will result in a non simple polygon.
        /// </summary>
        /// <returns>The connected non-simple polygon.</returns>
        public Polygon2<K> ConnectHoles()
        {
            var ptr = Kernel.ConnectHoles(Ptr);
            return new Polygon2<K>(ptr);
        }

        /// <summary>
        /// Partition the polygon into convex pieces.
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

    }

    /// <summary>
    /// The abstract polygon definition.
    /// </summary>
    public abstract class PolygonWithHoles2 : CGALObject, IEnumerable<Point2d>
    {
        protected const int BOUNDARY_INDEX = -1;

        /// <summary>
        /// Default constructor.
        /// </summary>
        private PolygonWithHoles2()
        {
            IsUnbounded = true;
        }

        /// <summary>
        /// Construct polygon with the kernel.
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonWithHoles2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            Ptr = Kernel.Create();
            IsUnbounded = true;
        }

        /// <summary>
        /// Construct the polygon with the kernel and boundary.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="boundary">A CCW polygon.</param>
        internal PolygonWithHoles2(CGALKernel kernel, Polygon2 boundary)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            Ptr = Kernel.CreateFromPolygon(boundary.Ptr);
            IsUnbounded = false;
        }

        /// <summary>
        /// Construct the polygon with the kernel and boundary.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="boundary">A CCW set of points.</param>
        internal PolygonWithHoles2(CGALKernel kernel, Point2d[] boundary)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            Ptr = Kernel.CreateFromPoints(boundary, boundary.Length);
            IsUnbounded = false;
        }

        /// <summary>
        /// Construct the polygon with the kernel and pointer.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonWithHoles2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            HoleCount = Kernel.HoleCount(Ptr);
            IsUnbounded = FindIfUnbounded();
        }

        /// <summary>
        /// Is the polygon unbounded. 
        /// ie no boundary polygon has been set.
        /// </summary>
        public bool IsUnbounded { get; protected set; }

        /// <summary>
        /// Is the polygon bounded. 
        /// ie a boundary polygon has been set.
        /// </summary>
        public bool IsBounded => !IsUnbounded;

        /// <summary>
        /// Number of points in the boindary polygon.
        /// </summary>
        public int Count => PointCount(POLYGON_ELEMENT.BOUNDARY);

        /// <summary>
        /// The number of holes in polygon.
        /// </summary>
        public int HoleCount { get; protected set; }

        /// <summary>
        /// Is this a simple polygon.
        /// Certains actions can only be carried out on simple polygons.
        /// </summary>
        public bool IsSimple => FindIfSimple(POLYGON_ELEMENT.BOUNDARY);

        /// <summary>
        /// The polygons orientation.
        /// Certain actions depend on the polygons orientation.
        /// </summary>
        public ORIENTATION Orientation => FindOrientation(POLYGON_ELEMENT.BOUNDARY);

        /// <summary>
        /// The orientation expressed as the clock direction.
        /// </summary>
        public CLOCK_DIR ClockDir => (CLOCK_DIR)Orientation;

        /// <summary>
        /// Is the polygon degenerate.
        /// Polygons with less than 3 points are degenerate.
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
        /// The polygon kernel.
        /// </summary>
        protected private PolygonWithHolesKernel2 Kernel { get; private set; }

        /// <summary>
        /// The type of kernel object uses.
        /// </summary>
        public string KernelName => Kernel.Name;

        /// <summary>
        /// Valid polygon with holes must have a simple and ccw boundary
        /// and all holes must be simple and cw.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if(IsBounded)
            {
                if (!FindIfSimple(POLYGON_ELEMENT.BOUNDARY))
                    return false;

                if (FindOrientation(POLYGON_ELEMENT.BOUNDARY) != ORIENTATION.POSITIVE)
                    return false;
            }

            for(int i = 0; i < HoleCount; i++)
            {
                if (!FindIfSimple(POLYGON_ELEMENT.HOLE, i))
                    return false;

                if (FindOrientation(POLYGON_ELEMENT.HOLE, i) != ORIENTATION.NEGATIVE)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Valid holes must be simple, cw and must be contained
        /// within the boundary polygon.
        /// </summary>
        /// <param name="pwh"></param>
        /// <param name="hole"></param>
        /// <returns>True if the polygon is a valid hole.</returns>
        public static bool IsValidHole(PolygonWithHoles2 pwh, Polygon2 hole)
        {
            if (!hole.IsValidHole())
                return false;

            if (!pwh.ContainsPolygon(hole))
                return false;

            return true;
        }

        /// <summary>
        /// Clear the polygon.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
            IsUnbounded = true;
            HoleCount = 0;
        }

        /// <summary>
        /// Clear the polygons boundary.
        /// </summary>
        public void ClearBoundary()
        {
            Kernel.ClearBoundary(Ptr);
            IsUnbounded = true;
        }

        /// <summary>
        /// Clear the polygons holes.
        /// </summary>
        public void ClearHoles()
        {
            Kernel.ClearHoles(Ptr);
            HoleCount = 0;
        }

        /// <summary>
        /// Get the number of points of a polygon element.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns></returns>
        public int PointCount(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.PointCount(Ptr, BOUNDARY_INDEX);
            else
                return Kernel.PointCount(Ptr, index);
        }

        /// <summary>
        /// Remove a polygon.
        /// Can remove the boundary or a hole.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Remove(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                Kernel.ClearBoundary(Ptr);
                IsUnbounded = true;
            }
            else
            {
                Kernel.RemoveHole(Ptr, index);
                HoleCount--;
            }
        }

        /// <summary>
        /// Remove a hole from the polygon.
        /// </summary>
        /// <param name="index">The holes index.</param>
        public void RemoveHole(int index)
        {
            if (index >= 0 && index <= HoleCount)
            {
                Kernel.RemoveHole(Ptr, index);
                HoleCount--;
            }
        }

        /// <summary>
        /// Reverse the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Reverse(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.ReversePolygon(Ptr, BOUNDARY_INDEX);
            else
                Kernel.ReversePolygon(Ptr, index);
        }

        /// <summary>
        /// Get a polygons point.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="pointIndex">The index of the point in the polygon.</param>
        /// <param name="holeIndex">If element type is a hole this is the holes index.</param>
        /// <returns></returns>
        public Point2d GetPoint(POLYGON_ELEMENT element, int pointIndex, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.GetPoint(Ptr, BOUNDARY_INDEX, pointIndex);
            else
                return Kernel.GetPoint(Ptr, holeIndex, pointIndex);
        }

        /// <summary>
        /// Get the points in the polygon element.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="points">The point array to copy points into.</param>
        /// <param name="count">The ararys length.</param>
        /// <param name="holeIndex">If element type is a hole this is the holes index.</param>
        public void GetPoints(POLYGON_ELEMENT element, Point2d[] points, int count, int holeIndex = 0)
        {
            ErrorUtil.CheckArray(points, count);

            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.GetPoints(Ptr, points, BOUNDARY_INDEX, points.Length);
            else
                Kernel.GetPoints(Ptr, points, holeIndex, points.Length);
            
        }

        /// <summary>
        /// Set a polygons point.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="pointIndex">The index of the point in the polygon.</param>
        /// <param name="point">The point to set.</param>
        /// <param name="holeIndex">If element type is a hole this is the holes index.</param>
        public void SetPoint(POLYGON_ELEMENT element, int pointIndex, Point2d point, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)  
                Kernel.SetPoint(Ptr, BOUNDARY_INDEX, pointIndex, point);
            else
                Kernel.SetPoint(Ptr, holeIndex, pointIndex, point);
        }

        /// <summary>
        /// Set all the points in the polygon. If the point array is longer
        /// than the polygon is current the extra points are appended to the end.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="points">The points to set.</param>
        /// <param name="count">The ararys length.</param>
        /// <param name="holeIndex">If element type is a hole this is the holes index.</param>
        public void SetPoints(POLYGON_ELEMENT element, Point2d[] points, int count, int holeIndex = 0)
        {
            ErrorUtil.CheckArray(points, count);

            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.SetPoints(Ptr, points, BOUNDARY_INDEX, points.Length);
            else
                Kernel.SetPoints(Ptr, points, holeIndex, points.Length);
        }

        /// <summary>
        /// Triangulate the polygon.
        /// </summary>
        /// <param name="indices">The triangle indices.</param>
        public abstract void Triangulate(List<int> indices);

        /// <summary>
        /// Add a hole from a set of points.
        /// </summary>
        /// <param name="points">A CW set of points.</param>
        /// <param name="count">The ararys length.</param>
        public void AddHole(Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.AddHoleFromPoints(Ptr, points, count);
            HoleCount++;
        }

        /// <summary>
        /// Find if the polygon has a boundary.
        /// </summary>
        /// <returns>True if the polygon has a boundary.</returns>
        public bool FindIfUnbounded()
        {
            return Kernel.IsUnbounded(Ptr);
        }

        /// <summary>
        /// Find the polygons bounding box.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The polygons bounding box.</returns>
        public Box2d FindBoundingBox(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.GetBoundingBox(Ptr, BOUNDARY_INDEX);
            else
                return Kernel.GetBoundingBox(Ptr, index);
        }

        /// <summary>
        /// Find if the polygon is simple.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>True if the polygon is simple.</returns>
        public bool FindIfSimple(POLYGON_ELEMENT element, int index = 0)
        {
            if(element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.IsSimple(Ptr, BOUNDARY_INDEX);
            else
                return Kernel.IsSimple(Ptr, index);
        }

        /// <summary>
        /// Find if the polygon is convex.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>True if polygon is convex.</returns>
        public bool FindIfConvex(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.IsConvex(Ptr, BOUNDARY_INDEX);
            else
                return Kernel.IsConvex(Ptr, index);
        }

        /// <summary>
        /// Find the orientation of polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The orientation of the polygon.</returns>
        public ORIENTATION FindOrientation(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.Orientation(Ptr, BOUNDARY_INDEX);
            else
                return Kernel.Orientation(Ptr, index);
        }

        /// <summary>
        /// Find the orientated side the point is on.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="point"></param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The orientated side of point compared to the polygon.</returns>
        public ORIENTED_SIDE OrientedSide(POLYGON_ELEMENT element, Point2d point, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.OrientedSide(Ptr, BOUNDARY_INDEX, point);
            else
                return Kernel.OrientedSide(Ptr, index, point);
        }

        /// <summary>
        /// The signed area of the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The signed area is positive if polygon is ccw 
        /// and negation if cw.</returns>
        public double FindSignedArea(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.SignedArea(Ptr, BOUNDARY_INDEX);
            else
                return Kernel.SignedArea(Ptr, index);
        }

        /// <summary>
        /// The area of the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The polygons area.</returns>
        public double FindArea(POLYGON_ELEMENT element, int index = 0)
        {
            return Math.Abs(FindSignedArea(element, index));
        }

        /// <summary>
        /// Enumerate all points in the polygon.
        /// </summary>
        /// <returns>Each point in polygon.</returns>
        public IEnumerator<Point2d> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return GetPoint( POLYGON_ELEMENT.BOUNDARY, i);
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
            for (int i = 0; i < Count; i++)
                points[i] = GetPoint(POLYGON_ELEMENT.BOUNDARY, i);

            return points;
        }

        /// <summary>
        /// Get all the points in the polygons boundary into a list.
        /// </summary>
        public void ToList(List<Point2d> points)
        {
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(POLYGON_ELEMENT.BOUNDARY, i));
        }

        /// <summary>
        /// Get all the points in the polygon boundary and holes.
        /// </summary>
        /// <param name="points">The point array to copy into.</param>
        public void GetAllPoints(List<Point2d> points)
        {
            int count = PointCount(POLYGON_ELEMENT.BOUNDARY);
            var arr = new Point2d[count];
            GetPoints(POLYGON_ELEMENT.BOUNDARY, arr, arr.Length);
            points.AddRange(arr);

            for (int i = 0; i < HoleCount; i++)
            {
                count = PointCount(POLYGON_ELEMENT.HOLE, i);
                arr = new Point2d[count];
                GetPoints(POLYGON_ELEMENT.HOLE, arr, arr.Length, i);
                points.AddRange(arr);
            }
        }

        /// <summary>
        /// Round each point it polygon to a number of digits.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            int count = PointCount(POLYGON_ELEMENT.BOUNDARY);
            var arr = new Point2d[count];
            GetPoints(POLYGON_ELEMENT.BOUNDARY, arr, arr.Length);

            for(int i = 0; i < count; i++)
                arr[i] = arr[i].Rounded(digits);

            SetPoints(POLYGON_ELEMENT.BOUNDARY, arr, arr.Length);

            for (int i = 0; i < HoleCount; i++)
            {
                count = PointCount(POLYGON_ELEMENT.HOLE, i);
                arr = new Point2d[count];
                GetPoints(POLYGON_ELEMENT.HOLE, arr, arr.Length, i);

                for (int j = 0; j < count; j++)
                    arr[j] = arr[j].Rounded(digits);

                SetPoints(POLYGON_ELEMENT.HOLE, arr, arr.Length, i);
            }

        }

        /// <summary>
        /// Convert the polygon to a new polygon with a different kernel.
        /// May result in different values due to precision issues.
        /// </summary>
        /// <typeparam name="T">The new kernel type.</typeparam>
        /// <returns>The new polygon.</returns>
        public PolygonWithHoles2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.Convert(Ptr, e);
            return new PolygonWithHoles2<T>(ptr);
        }

        /// <summary>
        /// Release the unmanaged resoures.
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
        /// Does the polygon fully contain the other polygon.
        /// </summary>
        /// <param name="polygon">The other polygon.</param>
        /// <param name="inculdeBoundary">Should the boundary be included.</param>
        /// <returns>True if the polygon is contained within this polygon.</returns>
        private bool ContainsPolygon(Polygon2 polygon, bool inculdeBoundary = true)
        {
            if (IsUnbounded) return true;

            for (int i = 0; i < polygon.Count; i++)
            {
                if (!ContainsPoint(polygon.GetPoint(i), inculdeBoundary))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Does this polygon contain the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="inculdeBoundary">Should points on the boundary be 
        /// counted as being inside the polygon.</param>
        /// <returns>True if the polygon contain the point.</returns>
        public bool ContainsPoint(Point2d point, bool inculdeBoundary = true)
        {
            var orientation = FindOrientation(POLYGON_ELEMENT.BOUNDARY);
            return Kernel.ContainsPoint(Ptr, point, orientation, inculdeBoundary);
        }

        /// <summary>
        /// Translate the polygon.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Translate(Ptr, BOUNDARY_INDEX, translation);

            int count = HoleCount;
            for (int i = 0; i < count; i++)
                Kernel.Translate(Ptr, i, translation);
        }

        /// <summary>
        /// Translate the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Translate(POLYGON_ELEMENT element, Point2d translation, int index = 0)
        {
            if(element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Translate(Ptr, BOUNDARY_INDEX, translation);
            else
                Kernel.Translate(Ptr, index, translation);
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        public void Rotate(Degree rotation)
        {
            Kernel.Rotate(Ptr, BOUNDARY_INDEX, rotation.radian);

            int count = HoleCount;
            for (int i = 0; i < count; i++)
                Kernel.Rotate(Ptr, i, rotation.radian);
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="rotation">The amount to rotate in radians.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Rotate(POLYGON_ELEMENT element, Degree rotation, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Rotate(Ptr, BOUNDARY_INDEX, rotation.radian);
            else
                Kernel.Rotate(Ptr, index, rotation.radian);
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Scale(Ptr, BOUNDARY_INDEX, scale);

            int count = HoleCount;
            for (int i = 0; i < count; i++)
                Kernel.Scale(Ptr, i, scale);
        }

        /// <summary>
        /// Scale the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="scale">The amount to scale.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Scale(POLYGON_ELEMENT element, double scale, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Scale(Ptr, BOUNDARY_INDEX, scale);
            else
                Kernel.Scale(Ptr, index, scale);
        }

        /// <summary>
        /// Transform the polygon.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate in radians.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point2d translation, Degree rotation, double scale)
        {
            Kernel.Transform(Ptr, BOUNDARY_INDEX, translation, rotation.radian, scale);

            int count = HoleCount;
            for (int i = 0; i < count; i++)
                Kernel.Transform(Ptr, i, translation, rotation.radian, scale);
        }

        /// <summary>
        /// Transform the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate in radians.</param>
        /// <param name="scale">The amount to scale.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Transform(POLYGON_ELEMENT element, Point2d translation, Degree rotation, double scale, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Transform(Ptr, BOUNDARY_INDEX, translation, rotation.radian, scale);
            else
                Kernel.Transform(Ptr, index, translation, rotation.radian, scale);
        }

        /// <summary>
        /// Print debug infomation.
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Is Bounded = " + IsBounded);

            if (!IsUnbounded)
            {
                var element = POLYGON_ELEMENT.BOUNDARY;
                builder.AppendLine("Boundary point count = " + PointCount(element));
                builder.AppendLine("Boundary is simple = " + FindIfSimple(element));
                builder.AppendLine("Boundary is convex = " + FindIfConvex(element));
                builder.AppendLine("Boundary orientation = " + FindOrientation(element));
                builder.AppendLine("Boundary signed Area = " + FindSignedArea(element));
            }

            for (int i = 0; i < HoleCount; i++)
            {
                builder.AppendLine("");
                var element = POLYGON_ELEMENT.HOLE;
                builder.AppendLine("Hole " + i + " point count = " + PointCount(element, i));
                builder.AppendLine("Hole " + i + " is simple = " + FindIfSimple(element, i));
                builder.AppendLine("Hole " + i + " is convex = " + FindIfConvex(element, i));
                builder.AppendLine("Hole " + i + " is orientation = " + FindOrientation(element, i));
                builder.AppendLine("Hole " + i + " is signed area = " + FindSignedArea(element, i));
                builder.AppendLine();
            }
        }

    }
}
