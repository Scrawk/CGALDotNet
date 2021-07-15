using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{

    public sealed class Polygon2<K> : Polygon2 where K : CGALKernel, new() 
    {
        public Polygon2() : base(new K())
        {

        }

        public Polygon2(Point2d[] points) : base(new K(), points)
        {

        }

        internal Polygon2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Polygon2<{0}>: Count={1}, IsSimple={2}, Orientation={3}]",
                Kernel.Name, Count, IsSimple, Orientation);
        }

        public Polygon2<K> Copy()
        {
            var copy = new Polygon2<K>(Kernel.Copy(GetCheckedPtr()));
            copy.Update(IsSimple, Orientation);
            return copy;
        }

    }

    public abstract class Polygon2 : CGALObject, IEnumerable<Point2d>
    {

        private bool m_isSimple;

        private CGAL_ORIENTATION m_orientation;

        private Polygon2()
        {

        }

        internal Polygon2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonKernel2;
            SetPtr(Kernel.Create());
        }

        internal Polygon2(CGALKernel kernel, Point2d[] points)
        {
            Kernel = kernel.PolygonKernel2;
            Count = points.Length;
            SetPtr(Kernel.CreateFromPoints(points, 0, points.Length));
            Update();
        }

        internal Polygon2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonKernel2;
            Count = Kernel.Count(Ptr);
            Update();
        }

        public int Count { get; private set; }

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

        public CGAL_ORIENTATION Orientation
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

        public CGAL_CLOCK_DIR ClockDir => (CGAL_CLOCK_DIR)Orientation;

        public bool IsDegenerate => Count < 3 || Orientation == CGAL_ORIENTATION.ZERO;

        public bool IsClockWise => ClockDir == CGAL_CLOCK_DIR.CLOCKWISE;

        public bool IsCounterClockWise => ClockDir == CGAL_CLOCK_DIR.COUNTER_CLOCKWISE;

        protected bool IsUpdated { get; set; }

        protected private PolygonKernel2 Kernel { get; private set; }

        public void Clear()
        {
            Count = 0;
            Kernel.Clear(GetCheckedPtr());
            Update(false, CGAL_ORIENTATION.ZERO);
        }

        public Point2d GetPoint(int index)
        {
            ErrorUtil.CheckBounds(index, Count);
            return Kernel.GetPoint(GetCheckedPtr(), index);
        }

        public Point2d GetPointWrapped(int index)
        {
            index = MathUtil.Wrap(index, Count);
            return Kernel.GetPoint(GetCheckedPtr(), index);
        }

        public Point2d GetPointClamped(int index)
        {
            index = MathUtil.Clamp(index, 0, Count - 1);
            return Kernel.GetPoint(GetCheckedPtr(), index);
        }

        public void GetPoints(Point2d[] points, int startIndex = 0)
        {
            ErrorUtil.CheckBounds(points, startIndex, Count);
            Kernel.GetPoints(GetCheckedPtr(), points, startIndex, Count);
        }

        public void GetPoints(List<Point2d> points)
        {
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(i));
        }

        public void SetPoint(int index, Point2d point)
        {
            ErrorUtil.CheckBounds(index, Count);
            Kernel.SetPoint(GetCheckedPtr(), index, point);
            IsUpdated = false;
        }

        public void SetPoints(Point2d[] points, int startIndex = 0)
        {
            ErrorUtil.CheckBounds(points, startIndex, Count);
            Kernel.SetPoints(GetCheckedPtr(), points, startIndex, Count);
            IsUpdated = false;
        }

        public void Reverse()
        {
            Kernel.Reverse(GetCheckedPtr());
            m_orientation = CGALEnum.Opposite(m_orientation);
        }

        public bool FindIfSimple()
        {
            if (Count < 3)
                return false;
            else
                return Kernel.IsSimple(GetCheckedPtr());
        }

        public bool FindIfConvex()
        {
            if (IsSimple)
                return Kernel.IsConvex(GetCheckedPtr());
            else
                return false;
        }

        public CGAL_ORIENTATION FindOrientation()
        {
            if (IsSimple)
                return Kernel.Orientation(GetCheckedPtr());
            else
                return CGAL_ORIENTATION.ZERO;
        }

        public CGAL_ORIENTED_SIDE OrientedSide(Point2d point)
        {
            if (IsSimple)
                return Kernel.OrientedSide(GetCheckedPtr(), point);
            else
                return CGAL_ORIENTED_SIDE.UNDETERMINED;
        }

        public double FindSignedArea()
        {
            if (IsSimple)
                return Kernel.SignedArea(GetCheckedPtr());
            else
                return 0;
        }

        public double FindArea()
        {
            return Math.Abs(FindSignedArea());
        }

        public bool ContainsPoint(Point2d point, bool inculdeBoundary = true)
        {
            var side = OrientedSide(point);

            if (side == CGAL_ORIENTED_SIDE.UNDETERMINED)
                return false;

            if (inculdeBoundary && side == CGAL_ORIENTED_SIDE.ON_BOUNDARY)
                return true;

            return side == CGAL_ORIENTED_SIDE.ON_POSITIVE_SIDE;
        }

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
            GetPoints(points);
            return points;
        }

        public List<Point2d> ToList()
        {
            var points = new List<Point2d>(Count);
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(i));

            return points;
        }

        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        public void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Is convex = " + FindIfConvex());
            builder.AppendLine("Signed Area = " + FindSignedArea());
            builder.AppendLine("Area = " + FindArea());
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(GetCheckedPtr());
        }

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
                Orientation = CGAL_ORIENTATION.ZERO;
            }
        }

        protected void Update(bool isSimple, CGAL_ORIENTATION orientation)
        {
            IsSimple = isSimple;
            Orientation = orientation;
            IsUpdated = true;
        }

    }
}
