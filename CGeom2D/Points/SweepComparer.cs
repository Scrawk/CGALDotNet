using System;
using System.Collections.Generic;

namespace CGeom2D.Points
{
    public enum SWEEP {  X, Y }

    public class SweepComparer : IComparer<SweepEvent>, IComparer<Point2i>
    {
        public SweepComparer(SWEEP axis)
        {
            Axis = axis;
        }

        public SWEEP Axis { get; private set; }

        public COMPARISON Comparison(SweepEvent a, SweepEvent b)
        {
            return (COMPARISON)Compare(a, b);
        }

        public int Compare(SweepEvent a, SweepEvent b)
        {
            if(Axis == SWEEP.X)
                return SweepComparerX.Instance.Compare(a.Point, b.Point);
            else
                return SweepComparerY.Instance.Compare(a.Point, b.Point);
        }

        public COMPARISON Comparison(Point2i a, Point2i b)
        {
            return (COMPARISON)Compare(a, b);
        }

        public int Compare(Point2i a, Point2i b)
        {
            if (Axis == SWEEP.X)
                return SweepComparerX.Instance.Compare(a, b);
            else
                return SweepComparerY.Instance.Compare(a, b);
        }

    }

    public class SweepComparerX : IComparer<SweepEvent>, IComparer<Point2i>
    {

        public static readonly SweepComparerX Instance = new SweepComparerX();

        public int Compare(SweepEvent a, SweepEvent b)
        {
            return Compare(a.Point, b.Point);
        }

        public int Compare(Point2i a, Point2i b)
        {
            if (a.x != b.x)
            {
                //Left to right
                return a.x < b.x ? -1 : 1;
            }
            else if (a.y != b.y)
            {
                //top to bottom
                return a.y > b.y ? -1 : 1;
            }
            else
            {
                //equal
                return 0;
            }
        }

    }

    public class SweepComparerY : IComparer<SweepEvent>, IComparer<Point2i>
    {

        public static readonly SweepComparerY Instance = new SweepComparerY();

        public int Compare(SweepEvent a, SweepEvent b)
        {
            return Compare(a.Point, b.Point);
        }

        public int Compare(Point2i a, Point2i b)
        {
            if (a.y != b.y)
            {
                //top to bottom
                return a.y > b.y ? -1 : 1;
            }
            else if (a.x != b.x)
            {
                //Left to right
                return a.x < b.x ? -1 : 1;
            }
            else
            {
                //equal
                return 0;
            }
        }

    }
}
