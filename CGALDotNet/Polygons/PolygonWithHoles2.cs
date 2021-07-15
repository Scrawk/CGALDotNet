using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{

    public sealed class PolygonWithHoles2<K> : PolygonWithHoles2 where K : CGALKernel, new()
    {
        public PolygonWithHoles2() : base(new K())
        {

        }

        public PolygonWithHoles2(Polygon2<K> boundary) : base(new K(), boundary)
        {

        }

        internal PolygonWithHoles2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[PolygonWithHoles2<{0}>: HoleCount={1}]", 
                Kernel.Name, HoleCount);
        }

        public PolygonWithHoles2<K> Copy()
        {
            return new PolygonWithHoles2<K>(Kernel.Copy(GetCheckedPtr()));
        }

        public Polygon2<K> CopyBoundary()
        {
            var ptr = Kernel.CopyHole(GetCheckedPtr(), BOUNDARY_INDEX);
            if (ptr != IntPtr.Zero)
                return new Polygon2<K>(ptr);
            else
                return null;
        }

        public void AddHole(Point2d[] points)
        {
            AddHole(new Polygon2<K>(points));
        }

        public Polygon2<K> CopyHole(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return new Polygon2<K>(Kernel.CopyHole(GetCheckedPtr(), index));
        }

        public List<Polygon2<K>> ToList()
        {
            var unbounded = FindIfUnbounded();

            int count = HoleCount;
            if (!unbounded)
                count++;

            var polygons = new List<Polygon2<K>>(count);

            if (!unbounded)
                polygons.Add(CopyBoundary());

            for (int i = 0; i < HoleCount; i++)
                polygons.Add(CopyHole(i));

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
            SetPtr(Kernel.Create());
        }

        internal PolygonWithHoles2(CGALKernel kernel, Polygon2 boundary)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            CheckBoundary(boundary);
            SetPtr(Kernel.CreateFromPolygon(boundary.Ptr));
        }

        internal PolygonWithHoles2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonWithHolesKernel2;
            HoleCount = Kernel.HoleCount(Ptr);
        }

        public int HoleCount { get; protected set; }

        protected private PolygonWithHolesKernel2 Kernel { get; private set; }

        public void Clear()
        {
            Kernel.Clear(GetCheckedPtr());
        }

        public void RemoveBoundary()
        {
            Kernel.ClearBoundary(GetCheckedPtr());
        }

        public void ReverseBoundary()
        {
            Kernel.ReverseHole(GetCheckedPtr(), BOUNDARY_INDEX);
        }

        public void AddHole(Polygon2 polygon)
        {
            CheckHole(this, polygon);
            Kernel.AddHoleFromPolygon(GetCheckedPtr(), polygon.Ptr);
            HoleCount++;
        }

        public void RemoveHole(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            Kernel.RemoveHole(GetCheckedPtr(), index);
            HoleCount--;
        }

        public void ReverseHole(int index)
        {
            Kernel.ReverseHole(GetCheckedPtr(), index);
        }

        public bool FindIfUnbounded()
        {
            return Kernel.IsUnbounded(GetCheckedPtr());
        }

        public bool FindIfBoundaryIsSimple()
        {
            return Kernel.IsSimple(GetCheckedPtr(), BOUNDARY_INDEX);
        }

        public bool FindIfBoundaryIsConvex()
        {
            return Kernel.IsConvex(GetCheckedPtr(), BOUNDARY_INDEX);
        }

        public CGAL_ORIENTATION FindBoundaryOrientation()
        {
            return Kernel.Orientation(GetCheckedPtr(), BOUNDARY_INDEX);
        }

        public CGAL_ORIENTED_SIDE BoundaryOrientedSide(Point2d point)
        {
            return Kernel.OrientedSide(GetCheckedPtr(), BOUNDARY_INDEX, point);
        }

        public double FindBoundarySignedArea()
        {
            return Kernel.SignedArea(GetCheckedPtr(), BOUNDARY_INDEX);
        }

        public bool FindIfHoleIsSimple(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return Kernel.IsSimple(GetCheckedPtr(), index);
        }

        public bool FindIfHoleIsConvex(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return Kernel.IsConvex(GetCheckedPtr(), index);
        }

        public CGAL_ORIENTATION FindHoleOrientation(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return Kernel.Orientation(GetCheckedPtr(), index);
        }

        public CGAL_ORIENTED_SIDE HoleOrientedSide(int index, Point2d point)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return Kernel.OrientedSide(GetCheckedPtr(), index, point);
        }

        public double FindHoleSignedArea(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return Kernel.SignedArea(GetCheckedPtr(), index);
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(GetCheckedPtr());
        }

        public double FindHoleArea(int index)
        {
            return Math.Abs(FindHoleSignedArea(index));
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
            if (BoundaryContainsPoint(point, inculdeBoundary))
            {
                for (int i = 0; i < HoleCount; i++)
                {
                    if (HoleContainsPoint(i, point, inculdeBoundary))
                        return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BoundaryContainsPoint(Point2d point, bool inculdeBoundary = true)
        {
            if (FindIfUnbounded())
                return true;

            var side = BoundaryOrientedSide(point);

            if (side == CGAL_ORIENTED_SIDE.UNDETERMINED)
                return false;

            if (inculdeBoundary && side == CGAL_ORIENTED_SIDE.ON_BOUNDARY)
                return true;

            return side == CGAL_ORIENTED_SIDE.ON_POSITIVE_SIDE;
        }

        public bool HoleContainsPoint(int index, Point2d point, bool inculdeBoundary = true)
        {
            var side = HoleOrientedSide(index, point);

            if (side == CGAL_ORIENTED_SIDE.UNDETERMINED)
                return false;

            if (inculdeBoundary && side == CGAL_ORIENTED_SIDE.ON_BOUNDARY)
                return true;

            return side == CGAL_ORIENTED_SIDE.ON_NEGATIVE_SIDE;
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

            bool isUnbounded = FindIfUnbounded();
            builder.AppendLine("Is unbounded = " + isUnbounded);

            if (!isUnbounded)
            {
                builder.AppendLine("Boundary is simple = " + FindIfBoundaryIsSimple());
                builder.AppendLine("Boundary is convex = " + FindIfBoundaryIsConvex());
                builder.AppendLine("Boundary orientation = " + FindBoundaryOrientation());
                builder.AppendLine("Boundary signed Area = " + FindBoundarySignedArea());
            }

            for (int i = 0; i < HoleCount; i++)
            {
                builder.AppendLine("Hole " + i + " is simple = " + FindIfHoleIsSimple(i));
                builder.AppendLine("Hole " + i + " is convex = " + FindIfHoleIsConvex(i));
                builder.AppendLine("Hole " + i + " is orientation = " + FindHoleOrientation(i));
                builder.AppendLine("Hole " + i + " is signed area = " + FindHoleSignedArea(i));
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
    }
}
