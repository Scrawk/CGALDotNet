using System;
using System.Collections;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public abstract class Polygon2 : IDisposable, IEnumerable<Point2d>
    {
        
        ~Polygon2()
        {
            Release();
        }

        public int Count { get; protected set; }

        public bool IsDisposed { get; private set; }

        internal IntPtr Ptr { get; private set; }

        public Point2d this[int i]
        {
            get => GetPointWrapped(i);
            set => SetPoint(i, value);
        }

        protected void SetPtr(IntPtr ptr)
        {
            Ptr = ptr;
        }

        public abstract Point2d GetPoint(int index);

        public abstract Point2d GetPointWrapped(int index);

        public abstract Point2d GetPointClamped(int index);

        public abstract void GetPoints(Point2d[] points, int startIndex = 0);

        public abstract void GetPoints(Point2d[] points, int startIndex, int count);

        public abstract void SetPoint(int index, Point2d point);

        public abstract void SetPoints(Point2d[] points, int startIndex = 0);

        public abstract void SetPoints(Point2d[] points, int startIndex, int count);

        public abstract void Reverse();

        public abstract bool IsSimple();

        public abstract bool IsConvex();

        public abstract CGAL_ORIENTATION Orientation();

        public abstract CGAL_ORIENTED_SIDE OrientedSide(Point2d point);

        public abstract double SignedArea();

        public double Area()
        {
            return Math.Abs(SignedArea());
        }

        public abstract void Clear();

        public IEnumerator<Point2d> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return GetPoint(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Point2d[] ToArray()
        {
            var points = new Point2d[Count];
            GetPoints(points, 0);
            return points;
        }

        public void Dispose()
        {
            Release();
            GC.SuppressFinalize(this);
        }

        private void Release()
        {
            if (!IsDisposed)
            {
                ReleasePtr();
                Ptr = IntPtr.Zero;
                IsDisposed = true;
            }
        }

        protected abstract void ReleasePtr();

        protected void CheckPtr()
        {
            if (Ptr == IntPtr.Zero)
                throw new NullReferenceException("Polygon unmanaged resources have been released.");
        }

        protected void CheckBounds(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("Index was out of polygon range. Must be non-negative and less than the size of the collection.");
        }

        protected void CheckBounds(Point2d[] points, int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("Index was out of polygon range. Must be non-negative and less than the size of the collection.");

            if (index >= points.Length)
                throw new ArgumentOutOfRangeException("Index was out of point array range. Must be non-negative and less than the size of the collection.");
        }

        protected void CheckBounds(Point2d[] points, int index, int count)
        {
            if (count < 0 || index < 0 || index >= Count || index + count > Count)
                throw new ArgumentOutOfRangeException("Index was out of polygon range. Must be non-negative and less than the size of the collection.");

            if (index >= points.Length || index + count > points.Length)
                throw new ArgumentOutOfRangeException("Index was out of point array range. Must be non-negative and less than the size of the collection.");
        }

    }
}
