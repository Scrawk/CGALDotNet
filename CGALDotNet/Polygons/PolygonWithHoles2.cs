using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{

    public enum BOUNDARY_OR_HOLE { BOUNDARY, HOLE }

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
            return new PolygonWithHoles2<K>(Kernel.Copy(Ptr));
        }

        public Polygon2<K> Copy(BOUNDARY_OR_HOLE op, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
            {
                var ptr = Kernel.CopyHole(Ptr, BOUNDARY_INDEX);
                if (ptr != IntPtr.Zero)
                    return new Polygon2<K>(ptr);
                else
                    return null;
            }
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return new Polygon2<K>(Kernel.CopyHole(Ptr, index));
            }
        
        }

        public void AddHole(Point2d[] points)
        {
            AddHole(new Polygon2<K>(points));
        }

        public List<Polygon2<K>> ToList()
        {
            var unbounded = FindIfUnbounded();

            int count = HoleCount;
            if (!unbounded)
                count++;

            var polygons = new List<Polygon2<K>>(count);

            if (!unbounded)
                polygons.Add(Copy(BOUNDARY_OR_HOLE.BOUNDARY));

            for (int i = 0; i < HoleCount; i++)
                polygons.Add(Copy(BOUNDARY_OR_HOLE.HOLE, i));

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
            Kernel.Clear(Ptr);
        }

        public void Remove(BOUNDARY_OR_HOLE op, int index = 0)
        {
            if(op == BOUNDARY_OR_HOLE.BOUNDARY)
                Kernel.ClearBoundary(Ptr);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.RemoveHole(Ptr, index);
                HoleCount--;
            }

        }

        public void Reverse(BOUNDARY_OR_HOLE op, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
                Kernel.ReverseHole(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.ReverseHole(Ptr, index);
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

        public bool FindIfSimple(BOUNDARY_OR_HOLE op, int index = 0)
        {
            if(op == BOUNDARY_OR_HOLE.BOUNDARY)
                return Kernel.IsSimple(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.IsSimple(Ptr, index);
            }
        }

        public bool FindIfConvex(BOUNDARY_OR_HOLE op, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
                return Kernel.IsConvex(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.IsConvex(Ptr, index);
            }
        }

        public CGAL_ORIENTATION FindOrientation(BOUNDARY_OR_HOLE op, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
                return Kernel.Orientation(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.Orientation(Ptr, index);
            }
        }

        public CGAL_ORIENTED_SIDE OrientedSide(BOUNDARY_OR_HOLE op, Point2d point, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
                return Kernel.OrientedSide(Ptr, BOUNDARY_INDEX, point);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.OrientedSide(Ptr, index, point);
            }
        }

        public double FindSignedArea(BOUNDARY_OR_HOLE op, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
                return Kernel.SignedArea(Ptr, BOUNDARY_INDEX);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return Kernel.SignedArea(Ptr, index);
            }
        }

        public double FindArea(BOUNDARY_OR_HOLE op, int index = 0)
        {
            return Math.Abs(FindSignedArea(op, index));
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
            if (ContainsPoint(BOUNDARY_OR_HOLE.BOUNDARY, point, inculdeBoundary))
            {
                for (int i = 0; i < HoleCount; i++)
                {
                    if (ContainsPoint(BOUNDARY_OR_HOLE.HOLE, point, inculdeBoundary, i))
                        return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsPoint(BOUNDARY_OR_HOLE op, Point2d point, bool inculdeBoundary = true, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
            {
                if (FindIfUnbounded())
                    return true;

                var side = OrientedSide(op, point);

                if (side == CGAL_ORIENTED_SIDE.UNDETERMINED)
                    return false;

                if (inculdeBoundary && side == CGAL_ORIENTED_SIDE.ON_BOUNDARY)
                    return true;

                return side == CGAL_ORIENTED_SIDE.ON_POSITIVE_SIDE;
            }
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                var side = OrientedSide(op, point, index);

                if (side == CGAL_ORIENTED_SIDE.UNDETERMINED)
                    return false;

                if (inculdeBoundary && side == CGAL_ORIENTED_SIDE.ON_BOUNDARY)
                    return true;

                return side == CGAL_ORIENTED_SIDE.ON_NEGATIVE_SIDE;
            }
        }

        public void Translate(BOUNDARY_OR_HOLE op, Point2d translation, int index = 0)
        {
            if(op == BOUNDARY_OR_HOLE.BOUNDARY)
                Kernel.Translate(Ptr, BOUNDARY_INDEX, translation);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.Translate(Ptr, index, translation);
            }
        }

        public void Rotate(BOUNDARY_OR_HOLE op, Radian rotation, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
                Kernel.Rotate(Ptr, BOUNDARY_INDEX, rotation.angle);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.Rotate(Ptr, index, rotation.angle);
            }
        }

        public void Scale(BOUNDARY_OR_HOLE op, double scale, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
                Kernel.Scale(Ptr, BOUNDARY_INDEX, scale);
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                Kernel.Scale(Ptr, index, scale);
            }
        }

        public void Transform(BOUNDARY_OR_HOLE op, Point2d translation, Radian rotation, double scale, int index = 0)
        {
            if (op == BOUNDARY_OR_HOLE.BOUNDARY)
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

            bool isUnbounded = FindIfUnbounded();
            builder.AppendLine("Is unbounded = " + isUnbounded);

            if (!isUnbounded)
            {
                var op = BOUNDARY_OR_HOLE.BOUNDARY;
                builder.AppendLine("Boundary is simple = " + FindIfSimple(op));
                builder.AppendLine("Boundary is convex = " + FindIfConvex(op));
                builder.AppendLine("Boundary orientation = " + FindOrientation(op));
                builder.AppendLine("Boundary signed Area = " + FindSignedArea(op));
            }

            for (int i = 0; i < HoleCount; i++)
            {
                var op = BOUNDARY_OR_HOLE.HOLE;
                builder.AppendLine("Hole " + i + " is simple = " + FindIfSimple(op, i));
                builder.AppendLine("Hole " + i + " is convex = " + FindIfConvex(op, i));
                builder.AppendLine("Hole " + i + " is orientation = " + FindOrientation(op, i));
                builder.AppendLine("Hole " + i + " is signed area = " + FindSignedArea(op, i));
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
