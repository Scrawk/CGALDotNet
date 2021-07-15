using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{

    public abstract class PolygonWithHoles2 : CGALObject
    {

        protected const int BOUNDARY_INDEX = -1;

        public PolygonWithHoles2()
        {
      
        }

        internal PolygonWithHoles2(IntPtr ptr) : base(ptr)
        {
            CheckPtr();
        }

        public int HoleCount { get; protected set; }

        public abstract void Clear();

        public abstract void RemoveBoundary();

        public abstract void ReverseBoundary();

        public abstract void AddHole(Point2d[] points);

        public abstract void AddHole(Polygon2 polygon);

        public abstract void RemoveHole(int index);

        public abstract void ReverseHole(int index);

        public abstract bool FindIfUnbounded();

        public abstract bool FindIfBoundaryIsSimple();

        public abstract bool FindIfBoundaryIsConvex();

        public abstract CGAL_ORIENTATION FindBoundaryOrientation();

        public abstract CGAL_ORIENTED_SIDE BoundaryOrientedSide(Point2d point);

        public abstract double FindBoundarySignedArea();

        public double FindBoundaryArea()
        {
            return Math.Abs(FindBoundarySignedArea());
        }

        public abstract bool FindIfHoleIsSimple(int index);

        public abstract bool FindIfHoleIsConvex(int index);

        public abstract CGAL_ORIENTATION FindHoleOrientation(int index);

        public abstract CGAL_ORIENTED_SIDE HoleOrientedSide(int index, Point2d point);

        public abstract double FindHoleSignedArea(int index);

        public double FindHoleArea(int index)
        {
            return Math.Abs(FindHoleSignedArea(index));
        }

        public bool ContainsPolygon(Polygon2 polygon, bool inculdeBoundary = true)
        {
            for(int i = 0; i < polygon.Count; i++)
            {
                if (!ContainsPoint(polygon.GetPoint(i), inculdeBoundary))
                    return false;
            }

            return true;
        }

        public bool ContainsPoint(Point2d point, bool inculdeBoundary = true)
        {
            if(BoundaryContainsPoint(point, inculdeBoundary))
            {
                for(int i = 0; i < HoleCount; i++)
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
