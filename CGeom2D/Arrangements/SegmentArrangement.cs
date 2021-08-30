using System;
using System.Collections.Generic;
using System.Text;

using CGeom2D.Geometry;
using CGeom2D.Points;

namespace CGeom2D.Arrangements
{
    public class SegmentArrangement
    {


        public static List<Segment2d> RandomSegments(int count, int seed, double range)
        {
            var rnd = new Random(seed);
            var segments = new List<Segment2d>();

            for (int i = 0; i < count; i++)
            {
                double x1 = rnd.NextDouble(-range, range);
                double y1 = rnd.NextDouble(-range, range);

                double x2 = rnd.NextDouble(-range, range);
                double y2 = rnd.NextDouble(-range, range);

                segments.Add(new Segment2d(x1, y1, x2, y2));
            }

            return segments;
        }

        public List<Segment2d> Run(List<Segment2d> input)
        {
            var output = new List<Segment2d>();

            while(input.Count > 0)
            {
                var ab = input.PopFirst();

                Run(ab, input, output);
            }

            return output;

        }

        private void Run(Segment2d ab, List<Segment2d> input, List<Segment2d> output)
        {

            while(input.Count > 0)
            {
                var cd = input.PopFirst();

                if(Intersects(ab, cd, out double t))
                {
                    var p = ab.A + t * (ab.B - ab.A);

                    var ap = new Segment2d(ab.A, p);
                    var pb = new Segment2d(p, ab.B);
                    var cp = new Segment2d(cd.A, p);
                    var pd = new Segment2d(p, cd.B);

                    output.Add(ap, pb, cp, pd);
                    input.Add(ap, pb, cp, pd);
                }
                else
                {
                    output.Add(ab, cd);
                }

            }

        }


        /// <summary>
        /// Do the two segments intersect.
        /// </summary>
        /// <param name="ab">a segment</param>
        /// <param name="cd">other segment</param>
        /// <param name="t">Intersection point = ab.A + t * (ab.B - ab.A)</param>
        /// <returns>If they intersect</returns>
        private static bool Intersects(Segment2d ab, Segment2d cd, out double t)
        {
            double area1 = CrossProductArea(ab.A, ab.B, cd.B);
            double area2 = CrossProductArea(ab.A, ab.B, cd.A);
            t = 0.0;

            if (area1 * area2 < 0.0)
            {
                double area3 = CrossProductArea(cd.A, cd.B, ab.A);
                double area4 = area3 + area2 - area1;

                if (area3 * area4 < 0.0)
                {
                    t = area3 / (area3 - area4);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Do the two segments intersect.
        /// </summary>
        /// <param name="ab">a segment</param>
        /// <param name="cd">other segment</param>
        /// <param name="s">Intersection point = ab.A + s * (ab.B - ab.A)</param>
        /// <param name="t">Intersection point = cd.A + t * (cd.B - cd.A)</param>
        /// <returns>If they intersect</returns>
        private static bool Intersects(Segment2d ab, Segment2d cd, out double s, out double t)
        {
            double area1 = CrossProductArea(ab.A, ab.B, cd.B);
            double area2 = CrossProductArea(ab.A, ab.B, cd.A);
            s = 0.0;
            t = 0.0;

            if (area1 * area2 < 0.0)
            {
                double area3 = CrossProductArea(cd.A, cd.B, ab.A);
                double area4 = area3 + area2 - area1;

                if (area3 * area4 < 0.0)
                {
                    s = area3 / (area3 - area4);

                    double a2 = area2;
                    double a3 = area3;

                    area1 = CrossProductArea(cd.A, cd.B, ab.B);
                    area2 = a3;
                    area3 = a2;
                    area4 = area3 + area2 - area1;
                    t = area3 / (area3 - area4);
                    return true;
                }
            }

            return false;
        }

        private static double CrossProductArea(Point2d a, Point2d b, Point2d c)
        {
            return (a.x - c.x) * (b.y - c.y) - (a.y - c.y) * (b.x - c.x);
        }

    }
}
