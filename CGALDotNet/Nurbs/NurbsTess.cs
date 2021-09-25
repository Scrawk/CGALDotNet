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
        internal static void GetPoints(NurbsCurve2d curve, List<Point2d> points, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                points.Add(curve.Point(u));
            }
        }

        /// <summary>
        /// Sample a curves points in a range of equally spaced parametric intervals.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <param name="points">The list of sampled points.</param>
        internal static  void GetPoints(NurbsCurve3d curve, List<Point3d> points, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                points.Add(curve.Point(u));
            }
        }

        /// <summary>
        /// Sample a curves tangents in a range of equally spaced parametric intervals.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <param name="tangents">The list of sampled points.</param>
        internal static void GetTangents(NurbsCurve2d curve, List<Vector2d> tangents, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                tangents.Add(curve.Tangent(u));
            }
        }

        /// <summary>
        /// Sample a curves tangents in a range of equally spaced parametric intervals.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <param name="tangents">The list of sampled points.</param>
        internal static void GetTangents(NurbsCurve3d curve, List<Vector3d> tangents, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                tangents.Add(curve.Tangent(u));
            }
        }

        /// <summary>
        /// Estimate the length of the curve.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <returns>The curves estmated length.</returns>
        internal static double EstimateLength(NurbsCurve2d curve, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            double len = 0;
            Point2d previous = new Point2d();

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                var point = curve.Point(u);

                if (i > 0)
                    len += Point2d.Distance(previous, point);

                previous = point;
            }

            return len;
        }

        /// <summary>
        /// Estimate the length of the curve.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <returns>The curves estmated length.</returns>
        internal static double EstimateLength(NurbsCurve3d curve, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            double len = 0;
            Point3d previous = new Point3d();

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                var point = curve.Point(u);

                if (i > 0)
                    len += Point3d.Distance(previous, point);

                previous = point;
            }

            return len;
        }

    }

}