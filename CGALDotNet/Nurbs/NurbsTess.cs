using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{

    internal static class NurbsTess
    {

        /// <summary>
        /// Sample a curves points in a range of equally spaced parametric intervals.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <param name="points">The list of sampled points.</param>
        internal static void GetCartesianPoints(BaseNurbsCurve2d curve, List<Point2d> points, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                points.Add(curve.CartesianPoint(u));
            }
        }

    }

}