using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public abstract class Polygon2 : CGALObject, IEnumerable<Point2d>
    {

        private bool m_isSimple;

        private CGAL_ORIENTATION m_orientation;

        public Polygon2()
        {

        }

        internal Polygon2(IntPtr ptr) : base(ptr)
        {
            CheckPtr();
        }

        public int Count { get; protected set; }

        protected bool IsUpdated { get; set; }

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

        public Point2d this[int i]
        {
            get => GetPointWrapped(i);
            set => SetPoint(i, value);
        }

        public abstract void Clear();

        public abstract Point2d GetPoint(int index);

        public abstract Point2d GetPointWrapped(int index);

        public abstract Point2d GetPointClamped(int index);

        public abstract void GetPoints(Point2d[] points, int startIndex = 0);

        public void GetPoints(List<Point2d> points)
        {
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(i));
        }

        public abstract void SetPoint(int index, Point2d point);

        public abstract void SetPoints(Point2d[] points, int startIndex = 0);

        public abstract void Reverse();

        protected void ReverseOrientation()
        {
            m_orientation = CGALEnum.Opposite(m_orientation);
        }

        public abstract bool FindIfSimple();

        public abstract bool FindIfConvex();

        public abstract CGAL_ORIENTATION FindOrientation();

        public abstract CGAL_ORIENTED_SIDE OrientedSide(Point2d point);

        public abstract double FindSignedArea();

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

            return CGALEnum.SameOrientation(Orientation, side);
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

    }
}
