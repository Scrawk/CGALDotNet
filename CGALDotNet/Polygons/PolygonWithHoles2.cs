using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public abstract class PolygonWithHoles2 : CGALObject
    {
        public PolygonWithHoles2()
        {
      
        }

        internal PolygonWithHoles2(IntPtr ptr) : base(ptr)
        {
            
        }

        public int HoleCount { get; protected set; }

        public abstract void Clear();

        public abstract void RemoveBoundary();

        public abstract void ReverseBoundary();

        public abstract void AddHole(Point2d[] points);

        public abstract void AddHole(Polygon2 polygon);

        public abstract void RemoveHole(int index);

        public abstract void ReverseHole(int index);

        public abstract bool IsUnbounded();

        public abstract bool BoundaryIsSimple();

        public abstract bool BoundaryIsConvex();

        public abstract CGAL_ORIENTATION BoundaryOrientation();

        public abstract CGAL_ORIENTED_SIDE BoundaryOrientedSide(Point2d point);

        public abstract double BoundarySignedArea();

        public double BoundaryArea()
        {
            return Math.Abs(BoundarySignedArea());
        }

        public abstract bool HoleIsSimple(int index);

        public abstract bool HoleIsConvex(int index);

        public abstract CGAL_ORIENTATION HoleOrientation(int index);

        public abstract CGAL_ORIENTED_SIDE HoleOrientedSide(int index, Point2d point);

        public abstract double HoleSignedArea(int index);

        public double HoleArea(int index)
        {
            return Math.Abs(HoleSignedArea(index));
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

            bool isUnbounded = IsUnbounded();
            builder.AppendLine("Is unbounded = " + isUnbounded);

            if (!isUnbounded)
            {
                bool boundaryIsSimple = BoundaryIsSimple();
                builder.AppendLine("Boundary is simple = " + boundaryIsSimple);

                if (boundaryIsSimple)
                {
                    builder.AppendLine("Boundary is convex = " + BoundaryIsConvex());
                    builder.AppendLine("Boundary orientation = " + BoundaryOrientation());
                    builder.AppendLine("Boundary signed Area = " + BoundarySignedArea());
                }
            }

            for (int i = 0; i < HoleCount; i++)
            {

                bool holeIsSimple = HoleIsSimple(i);
                builder.AppendLine("Hole " + i + " is simple = " + HoleIsSimple(i));

                if (holeIsSimple)
                {
                    builder.AppendLine("Hole " + i + " is convex = " + HoleIsConvex(i));
                    builder.AppendLine("Hole " + i + " is orientation = " + HoleOrientation(i));
                    builder.AppendLine("Hole " + i + " is signed area = " + HoleSignedArea(i));
                }

                builder.AppendLine();
            }
        }
    }
}
