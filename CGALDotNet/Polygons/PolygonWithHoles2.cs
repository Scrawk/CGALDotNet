using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{

    public enum POLYGON_ELEMENT 
    { 
        BOUNDARY, 
        HOLE 
    }

    public sealed class PolygonWithHoles2<K> : PolygonWithHoles2 where K : CGALKernel, new()
    {
        public PolygonWithHoles2() : base(new K())
        {

        }

        public PolygonWithHoles2(Polygon2<K> boundary) : base(new K(), boundary)
        {

        }

        public PolygonWithHoles2(Point2d[] boundary) : base(new K(), boundary)
        {

        }

        internal PolygonWithHoles2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[PolygonWithHoles2<{0}>: IsUnbounded={1}, HoleCount={2}]", 
                Kernel.Name, IsUnbounded, HoleCount);
        }

        public PolygonWithHoles2<K> Copy()
        {
            return new PolygonWithHoles2<K>(Kernel.Copy(Ptr));
        }

        public Polygon2<K> Copy(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                CheckIsBounded();
                var ptr = Kernel.CopyPolygon(Ptr, BOUNDARY_INDEX);

                if (ptr != IntPtr.Zero)
                    return new Polygon2<K>(ptr);
                else
                    throw new InvalidOperationException("Failed to find boundary.");
            }
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return new Polygon2<K>(Kernel.CopyPolygon(Ptr, index));
            }
        }

        public void AddHole(Point2d[] points)
        {
            AddHole(new Polygon2<K>(points));
        }

        public List<Polygon2<K>> ToList()
        {
            int count = HoleCount;
            if (!IsUnbounded)
                count++;

            var polygons = new List<Polygon2<K>>(count);

            if (!IsUnbounded)
                polygons.Add(Copy(POLYGON_ELEMENT.BOUNDARY));

            for (int i = 0; i < HoleCount; i++)
                polygons.Add(Copy(POLYGON_ELEMENT.HOLE, i));

            return polygons;
        }
    }

    public abstract class PolygonWithHoles2 : CGALObject
    {
        protected const int BOUNDARY_INDEX = -1;

        private PolygonWithHoles2()
        {

        }

        internal PolygonWithHoles2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            Ptr = Kernel.Create();
        }

        internal PolygonWithHoles2(CGALKernel kernel, Polygon2 boundary)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            CheckBoundary(boundary);
            Ptr = Kernel.CreateFromPolygon(boundary.Ptr);
            IsUnbounded = false;
        }

        internal PolygonWithHoles2(CGALKernel kernel, Point2d[] boundary)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            Ptr = Kernel.Create();
            SetPoints(POLYGON_ELEMENT.BOUNDARY, boundary, 0);
            IsUnbounded = false;
        }

        internal PolygonWithHoles2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            HoleCount = Kernel.HoleCount(Ptr);
        }

        public bool IsUnbounded { get; protected set; }

        public int HoleCount { get; protected set; }

        protected private PolygonWithHolesKernel2 Kernel { get; private set; }

        public void Clear()
        {
            Kernel.Clear(Ptr);
            IsUnbounded = true;
        }

        public int PointCount(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.PointCount(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.PointCount(Ptr, index);
            }
        }

        public void Remove(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                Kernel.ClearBoundary(Ptr);
                IsUnbounded = true;
            }
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.RemoveHole(Ptr, index);
                HoleCount--;
            }
        }

        public void Reverse(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.ReversePolygon(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.ReversePolygon(Ptr, index);
            }
        }

        public Point2d GetPoint(POLYGON_ELEMENT element, int pointIndex, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                int count = Kernel.PointCount(Ptr, BOUNDARY_INDEX);
                ErrorUtil.CheckBounds(pointIndex, count);
                return Kernel.GetPoint(Ptr, BOUNDARY_INDEX, pointIndex);
            }
            else
            {
                ErrorUtil.CheckBounds(holeIndex, HoleCount);
                int count = Kernel.PointCount(Ptr, holeIndex);

                ErrorUtil.CheckBounds(pointIndex, count);
                return Kernel.GetPoint(Ptr, holeIndex, pointIndex);
            }
        }

        public void GetPoints(POLYGON_ELEMENT element, Point2d[] points, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                int count = Kernel.PointCount(Ptr, BOUNDARY_INDEX);
                ErrorUtil.CheckBounds(points, 0, count);
                Kernel.GetPoints(Ptr, points, BOUNDARY_INDEX, 0, count);
            }
            else
            {
                ErrorUtil.CheckBounds(holeIndex, HoleCount);
                int count = Kernel.PointCount(Ptr, holeIndex);

                ErrorUtil.CheckBounds(points, 0, count);
                Kernel.GetPoints(Ptr, points, holeIndex, 0, count);
            }
        }

        public void SetPoint(POLYGON_ELEMENT element, int pointIndex, Point2d point, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                int count = Kernel.PointCount(Ptr, BOUNDARY_INDEX);
                ErrorUtil.CheckBounds(pointIndex, count);
                Kernel.SetPoint(Ptr, BOUNDARY_INDEX, pointIndex, point);
            }
            else
            {
                ErrorUtil.CheckBounds(holeIndex, HoleCount);
                int count = Kernel.PointCount(Ptr, holeIndex);

                ErrorUtil.CheckBounds(pointIndex, count);
                Kernel.SetPoint(Ptr, holeIndex, pointIndex, point);
            }
        }

        public void SetPoints(POLYGON_ELEMENT element, Point2d[] points, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                int count = Kernel.PointCount(Ptr, BOUNDARY_INDEX);
                count = Math.Max(count, points.Length);

                ErrorUtil.CheckBounds(points, 0, count);
                Kernel.SetPoints(Ptr, points, BOUNDARY_INDEX, 0, count);
                IsUnbounded = count > 0;
            }
            else
            {
                ErrorUtil.CheckBounds(holeIndex, HoleCount);

                int count = Kernel.PointCount(Ptr, holeIndex);
                count = Math.Max(count, points.Length);

                ErrorUtil.CheckBounds(points, 0, count);
                Kernel.SetPoints(Ptr, points, holeIndex, 0, count);
            }
        }

        public void AddHole(Polygon2 polygon)
        {
            CheckHole(this, polygon);
            Kernel.AddHoleFromPolygon(Ptr, polygon.Ptr);
            HoleCount++;
        }

        public bool FindIfUnbounded()
        {
            return Kernel.IsUnbounded(Ptr);
        }

        public bool FindIfSimple(POLYGON_ELEMENT element, int index = 0)
        {
            if(element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.IsSimple(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.IsSimple(Ptr, index);
            }
        }

        public bool FindIfConvex(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.IsConvex(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.IsConvex(Ptr, index);
            }
        }

        public CGAL_ORIENTATION FindOrientation(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.Orientation(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.Orientation(Ptr, index);
            }
        }

        public CGAL_ORIENTED_SIDE OrientedSide(POLYGON_ELEMENT element, Point2d point, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.OrientedSide(Ptr, BOUNDARY_INDEX, point);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.OrientedSide(Ptr, index, point);
            }
        }

        public double FindSignedArea(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.SignedArea(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.SignedArea(Ptr, index);
            }
        }

        public double FindArea(POLYGON_ELEMENT element, int index = 0)
        {
            return Math.Abs(FindSignedArea(element, index));
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

        public bool ContainsPolygon(Polygon2 polygon, bool inculdeBoundary = true)
        {
            for (int i = 0; i < polygon.Count; i++)
            {
                if (!ContainsPoint(polygon.GetPoint(i), inculdeBoundary))
                    return false;
            }

            return true;
        }

        public bool ContainsPoint(Point2d point, bool inculdeBoundary = true)
        {
            var orientation = FindOrientation(POLYGON_ELEMENT.BOUNDARY);
            return Kernel.ContainsPoint(Ptr, point, orientation, inculdeBoundary);
        }

        public void Translate(POLYGON_ELEMENT element, Point2d translation, int index = 0)
        {
            if(element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Translate(Ptr, BOUNDARY_INDEX, translation);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.Translate(Ptr, index, translation);
            }
        }

        public void Rotate(POLYGON_ELEMENT element, Radian rotation, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Rotate(Ptr, BOUNDARY_INDEX, rotation.angle);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.Rotate(Ptr, index, rotation.angle);
            }
        }

        public void Scale(POLYGON_ELEMENT element, double scale, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Scale(Ptr, BOUNDARY_INDEX, scale);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.Scale(Ptr, index, scale);
            }
        }

        public void Transform(POLYGON_ELEMENT element, Point2d translation, Radian rotation, double scale, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Transform(Ptr, BOUNDARY_INDEX, translation, rotation.angle, scale);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.Transform(Ptr, index, translation, rotation.angle, scale);
            }
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
            builder.AppendLine("Is unbounded = " + IsUnbounded);

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

        public static bool IsValidBoundary(Polygon2 polygon)
        {
            return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        public static bool IsValidHole(PolygonWithHoles2 pwh, Polygon2 polygon)
        {
            return polygon.IsSimple && polygon.IsClockWise && pwh.ContainsPolygon(polygon);
        }

        protected void CheckBoundary(Polygon2 polygon)
        {
            if (!IsValidBoundary(polygon))
                throw new Exception("Boundary must be simple and counter clock wise.");
        }

        protected void CheckHole(PolygonWithHoles2 pwh, Polygon2 polygon)
        {
            if (!IsValidHole(pwh, polygon))
                throw new Exception("Polygon must be simple, clock wise and not intersect the boundary or holes to be a polygon hole.");
        }

        protected void CheckIsBounded()
        {
            if (IsUnbounded)
                throw new NullReferenceException("This is not a valid operation on a unbounded polygon.");
        }
    }
}
