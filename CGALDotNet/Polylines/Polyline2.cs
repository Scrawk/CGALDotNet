using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polygons;

namespace CGALDotNet.Polylines
{

    /// <summary>
    /// Generic polyline definition.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class Polyline2<K> : Polyline2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Polyline2() : base(new K())
        {

        }

        /// <summary>
        /// Create from a set of points.
        /// </summary>
        /// <param name="points">The polylines points.</param>
        public Polyline2(Point2d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polylines pointer.</param>
        internal Polyline2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polyline as a string.
        /// </summary>
        /// <returns>The polyline as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Polyline2<{0}>: Count={1}]",
                Kernel.Name, Count);
        }

        /// <summary>
        /// Copy the polyline.
        /// </summary>
        /// <returns>The copied polyline.</returns>
        public Polyline2<K> Copy()
        {
            var ptr = Kernel.Copy(Ptr);
            var copy = new Polyline2<K>(ptr);
            return copy;
        }

        /// <summary>
        /// Create a polygon from the line.
        /// </summary>
        /// <param name="threshold">Threshold for the firat and last points being equal.</param>
        /// <returns>The polygon.</returns>
        public Polygon2<K> ToPoylgon(double threshold = MathUtil.EPS_64)
        {
            var points = ToList();

            if (Point2d.Distance(First, Last) < threshold)
                points.RemoveAt(points.Count-1);

            return new Polygon2<K>(points.ToArray());
        }

    }

    /// <summary>
    /// The abstract polyline definition.
    /// </summary>
    public abstract class Polyline2 : CGALObject, IEnumerable<Point2d>
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Polyline2()
        {

        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyline kernel.</param>
        internal Polyline2(CGALKernel kernel)
        {
            Kernel = kernel.PolylineKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyline kernel.</param>
        /// <param name="points">The points to construct from.</param>
        internal Polyline2(CGALKernel kernel, Point2d[] points)
        {
            Kernel = kernel.PolylineKernel2;
            Ptr = Kernel.Create();
            SetPoints(points, points.Length);
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyline kernel.</param>
        /// <param name="ptr">The polylines pointer.</param>
        internal Polyline2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolylineKernel2;
            Count = Kernel.Count(Ptr);
        }

        /// <summary>
        /// The number of points in the polyline.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// The capacity of the point array.
        /// </summary>
        public int Capacity => Kernel.Capacity(Ptr);

        /// <summary>
        /// Get the first point.
        /// </summary>
        public Point2d First => this[0];

        /// <summary>
        /// Get the last point.
        /// </summary>
        public Point2d Last => this[Count-1];

        /// <summary>
        /// The polylines kernel.
        /// Contains the functions to the unmanaged CGAL polyline.
        /// </summary>
        protected private PolylineKernel2 Kernel { get; private set; }

        /// <summary>
        /// Array accessor for the polyline.
        /// Getting a point clamps to the last point in polyline.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Point2d this[int i]
        {
            get => GetPointClamped(i);
            set => SetPoint(i, value);
        }

        /// <summary>
        /// Clear the polyline of all points.
        /// </summary>
        public void Clear()
        {
            Count = 0;
            Kernel.Clear(Ptr);
        }

        /// <summary>
        /// Shrink the capacity to match the point count.
        /// </summary>
        public void ShrinkCapacityToFitCount()
        {
            Kernel.ShrinkToFit(Ptr);
        }

        /// <summary>
        /// Resize the point array.
        /// New elements will default to zero.
        /// </summary>
        /// <param name="count"></param>
        public void Resize(int count)
        {
            Count = count;
            Kernel.Resize(Ptr, count);
        }

        /// <summary>
        /// Reverse the polints in the line.
        /// </summary>
        public void Reverse()
        {
            Kernel.Reverse(Ptr);
        }

        /// <summary>
        /// Remove the point at the index from the array.
        /// </summary>
        /// <param name="index">The points index</param>
        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index out of range.");

            Count--;
            Kernel.Erase(Ptr, index);
        }

        /// <summary>
        /// Remove a range of points from the array.
        /// </summary>
        /// <param name="start">The starting index</param>
        /// <param name="count">The number of points to remove.</param>
        public void Remove(int start, int count)
        {
            if (start < 0 || start >= Count ||  start + count >= Count || count > Count)
                throw new IndexOutOfRangeException("Index out of range.");

            Count -= count;
            Kernel.EraseRange(Ptr, start, count);
        }

        /// <summary>
        /// Remove the last point.
        /// </summary>
        public void RemoveLast()
        {
            if (Count == 0) return;
            Kernel.Erase(Ptr, Count-1);
            Count--;
        }

        /// <summary>
        /// Remove the point at the index from the array.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <param name="point">The point to insert.</param>
        public void Insert(int index, Point2d point)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index out of range.");

            Count++;
            Kernel.Insert(Ptr, index, point);
        }

        /// <summary>
        /// Remove a range of points from the array.
        /// </summary>
        /// <param name="points">The points to insert.</param>
        /// <param name="start">The starting index.</param>
        /// <param name="count">The number of points to insert.</param>
        public void Insert(Point2d[] points, int start, int count)
        {
            if (start < 0 || start >= Count)
                throw new IndexOutOfRangeException("Index out of range.");

            ErrorUtil.CheckArray(points, count);
            Count += count;
            Kernel.InsertRange(Ptr, start, count, points);
        }

        /// <summary>
        /// Add the point to the end of the poylline.
        /// </summary>
        /// <param name="point">The point to add.</param>
        public void Add(Point2d point)
        {
            Insert(Count - 1, point);
        }

        /// <summary>
        /// Does the first and last point match.
        /// </summary>
        /// <param name="threshold">The distance threshold that counts as match.</param>
        /// <returns></returns>
        public bool IsClosed(double threshold = 0)
        {
            return Kernel.IsClosed(Ptr, threshold);
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
        /// and wrap around the polyline.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <returns>The point at the index.</returns>
        public Point2d GetPointWrapped(int index)
        {
            index = MathUtil.Wrap(index, Count);
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get the point at the index
        /// and clamp to the polylines last point.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <returns>The point at the index.</returns>
        public Point2d GetPointClamped(int index)
        {
            index = MathUtil.Clamp(index, 0, Count - 1);
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get all the points in the polyline.
        /// </summary>
        /// <param name="points">The point array to copy the data into.</param>
        /// <param name="count">The array length.</param>
        public void GetPoints(Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
        }

        /// <summary>
        /// Get all the polyline points.
        /// </summary>
        /// <param name="points">The list to copy the data into.</param>
        public void GetPoints(List<Point2d> points)
        {
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(i));
        }

        /// <summary>
        /// Get all the polyline segments.
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
        }

        /// <summary>
        /// Set the points from the array.
        /// If the array is larger than the polyline then 
        /// the new points will be appended to end of polyline.
        /// </summary>
        /// <param name="points">The points array.</param>
        /// <param name="count">The array length.</param>
        public void SetPoints(Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.SetPoints(Ptr, points, count);
            Count = count;
        }

        /// <summary>
        /// Finds the length of the polyline.
        /// </summary>
        /// <returns></returns>
        public double FindLength()
        {
            return Math.Sqrt(Kernel.SqLength(Ptr));
        }

        /// <summary>
        /// Finds the square length of the polyline.
        /// </summary>
        /// <returns></returns>
        public double FindSquareLength()
        {
            return Kernel.SqLength(Ptr);
        }

        /// <summary>
        /// Translate the polyline.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Translate(Ptr, translation);
        }

        /// <summary>
        /// Rotate the polyline.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        public void Rotate(Radian rotation)
        {
            Kernel.Rotate(Ptr, rotation.angle);
        }

        /// <summary>
        /// Scale the polyline.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Scale(Ptr, scale);
        }

        /// <summary>
        /// Transform the polyline with a TRS matrix.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point2d translation, Radian rotation, double scale)
        {
            Kernel.Transform(Ptr, translation, rotation.angle, scale);
        }

        /// <summary>
        /// Enumerate all points in the polyline.
        /// </summary>
        /// <returns>Each point in polyline.</returns>
        public IEnumerator<Point2d> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return GetPoint(i);
        }

        /// <summary>
        /// Enumerate all points in the polyline.
        /// </summary>
        /// <returns>Each point in polyline.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Return all the points in the polyline in a array.
        /// </summary>
        /// <returns>The array.</returns>
        public Point2d[] ToArray()
        {
            var points = new Point2d[Count];
            GetPoints(points, points.Length);
            return points;
        }

        /// <summary>
        /// Return all the points in the polyline in a list.
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
        /// Convert the polyline to a new polyline with a different kernel.
        /// May result in different values due to precision issues.
        /// </summary>
        /// <typeparam name="T">The new kernel type.</typeparam>
        /// <returns>The new polline.</returns>
        public Polyline2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.Convert(Ptr, e);
            return new Polyline2<T>(ptr);
        }

        /// <summary>
        /// Print the polyline into a styring builder.
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Capacity = " + Capacity);
            builder.AppendLine("IsClosed = " + IsClosed());
            builder.AppendLine("Length = " + FindLength());
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

    }
}
